using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace TUTASAPrototipo.RecepcionYDespachoUltimaMillaCD
{
    public class RecepcionYDespachoUltimaMillaCDModelo
    {
        // ===== Datos =====
        private readonly List<Fletero> _fleteros = new()
        {
            new Fletero { Dni = 28765432, Nombre = "Juan Pereyra" },
            new Fletero { Dni = 30987654, Nombre = "Carlos Maidana" },
            new Fletero { Dni = 30123456, Nombre = "Lucas Ramírez" },
            new Fletero { Dni = 32198765, Nombre = "María Ledesma" },
        };

        private readonly List<Guia> _guias = new();
        private readonly List<HDR> _hdrs = new();

        private const string ORIGEN_COD = "0040"; // CD origen del CD de trabajo
        private int _seqHdr = 1;
        private int _seqGuia = 10000;

        // Guarda la tanda de retiros confirmados para generar sus distribución pendiente
        private List<Guia> _ultimosRetirosMarcados = new();

        public RecepcionYDespachoUltimaMillaCDModelo()
        {
            // Semilla desde bloque de texto (documento que pegaste)
            if (!string.IsNullOrWhiteSpace(BULK_RAW))
                SeedFromText(BULK_RAW);

            // Antes: NormalizarTipoPorEstado();  // Ya no se usa "Tipo" en guía
            MarcarAlgunasSinFleteroParaPruebas();
        }

        // ================= API (usado por el Form) =================

        public Fletero? BuscarFleteroPorDni(int dni) =>
            _fleteros.FirstOrDefault(f => f.Dni == dni);

        public (IEnumerable<Guia> distribucion, IEnumerable<Guia> retiro) GetGuiasPorFletero(int dni)
        {
            var estadosDistribucion = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "Admitida",
                "En tránsito al CD destino",
                "En CD destino",
                "En ruta al domicilio de entrega",
                "En ruta a la agencia de entrega",
                "Pendiente de entrega"
            };

            var dist = _guias.Where(g => g.FleteroDni == dni
                                      && !string.Equals(g.Estado, "Entregada", StringComparison.OrdinalIgnoreCase)
                                      && estadosDistribucion.Contains(g.Estado))
                             .OrderBy(g => g.NroHDR).ThenBy(g => g.Numero)
                             .ToList();

            var retiro = _guias.Where(g => g.FleteroDni == dni
                                        && (string.Equals(g.Estado, "A retirar por domicilio del cliente", StringComparison.OrdinalIgnoreCase)
                                         || string.Equals(g.Estado, "A retirar en agencia de origen", StringComparison.OrdinalIgnoreCase)
                                         || string.Equals(g.Estado, "En espera de retiro al cliente", StringComparison.OrdinalIgnoreCase)
                                         || string.Equals(g.Estado, "En espera de retiro en agencia", StringComparison.OrdinalIgnoreCase)
                                         || string.Equals(g.Estado, "En ruta a CD de origen", StringComparison.OrdinalIgnoreCase)))
                               .OrderBy(g => g.NroHDR).ThenBy(g => g.Numero)
                               .ToList();

            return (dist, retiro);
        }

        /// <summary>
        /// N3–N4: Aplica cambios de negocio sobre guías marcadas.
        /// - Distribución marcada → Entregada.
        /// - Retiro marcado → EnRutaACDOrigen + guarda tanda para generar guías de distribución pendientes.
        /// </summary>
        public void ConfirmarRendicion(int dni, List<string> entregasDistribucionMarcadas, List<string> retirosMarcados)
        {
            if (BuscarFleteroPorDni(dni) == null)
                throw new InvalidOperationException("Debe seleccionar un transportista primero.");

            _ultimosRetirosMarcados = new List<Guia>();

            // Entregas (distribución) marcadas → Entregada
            foreach (var g in _guias.Where(x => x.FleteroDni == dni && !string.Equals(x.Estado, "Entregada", StringComparison.OrdinalIgnoreCase)))
            {
                if (entregasDistribucionMarcadas.Contains(g.Numero))
                {
                    g.Estado = "Entregada";
                    g.NroHDR = null; // deja de pertenecer a HDR activa
                }
            }

            // Retiros marcados → En ruta a CD de origen
            foreach (var g in _guias.Where(x => x.FleteroDni == dni &&
                                               (string.Equals(x.Estado, "A retirar por domicilio del cliente", StringComparison.OrdinalIgnoreCase)
                                             || string.Equals(x.Estado, "A retirar en agencia de origen", StringComparison.OrdinalIgnoreCase)
                                             || string.Equals(x.Estado, "En espera de retiro al cliente", StringComparison.OrdinalIgnoreCase)
                                             || string.Equals(x.Estado, "En espera de retiro en agencia", StringComparison.OrdinalIgnoreCase))))
            {
                if (retirosMarcados.Contains(g.Numero))
                {
                    g.Estado = "En ruta a CD de origen";
                    g.Tipo = "Retiro";
                    _ultimosRetirosMarcados.Add(g);
                }
            }
        }

        /// <summary>
        /// N3–N4: Adopta guías sin fletero, crea nuevas de distribución post-retiro y asigna HDR por destino (máx 5/ HDR).
        /// </summary>
        public void AsignarHDRsPorDireccion(int dni)
        {
            // 1) Adopción de guías sin fletero (del tipo que corresponda)
            AdoptarGuiasSinFletero(dni);

            // 2) Por cada retiro marcado, crear una guía de distribución pendiente (sin asignar fletero → queda para adopción)
            if (_ultimosRetirosMarcados.Count > 0)
            {
                var nuevas = new List<Guia>();
                foreach (var ret in _ultimosRetirosMarcados)
                {
                    nuevas.Add(new Guia
                    {
                        Numero = NextGuiaNumber(),
                        Tipo = "Distribución",
                        Tamaño = ret.Tamaño,
                        Origen = $"CD {ORIGEN_COD}",
                        Destino = "Domicilio",
                        Estado = "Pendiente de entrega",
                        FleteroDni = null,   // queda libre para que otro la adopte
                        NroHDR = null
                    });
                }
                _guias.AddRange(nuevas);
            }

            // 3) Asignar HDR por destino (máximo 5 guías por HDR)
            var fecha = DateTime.Now.ToString("yyyyMMdd", CultureInfo.InvariantCulture);
            var activas = _guias.Where(g => g.FleteroDni == dni && !string.Equals(g.Estado, "Entregada", StringComparison.OrdinalIgnoreCase)).ToList();

            foreach (var grp in activas.GroupBy(g => NormalizarDestino(g.Destino)))
            {
                // tomar de a 5 por HDR
                foreach (var paquete in grp.Chunk(5))
                {
                    string destinoCod = DestinoToLLL(grp.Key);
                    string nroHdr = $"H{ORIGEN_COD}{destinoCod}{fecha}{_seqHdr++:000}";

                    var hdr = new HDR
                    {
                        Numero = nroHdr,
                        Direccion = grp.Key,
                        Tipo = paquete.Any(p => EsRetiro(p)) ? "Retiro" : "Distribución",
                        Guias = paquete.Select(p => p.Numero).ToList()
                    };
                    _hdrs.Add(hdr);

                    foreach (var g in paquete)
                        g.NroHDR = nroHdr;
                }
            }

            _ultimosRetirosMarcados.Clear();
        }

        /// <summary>
        /// *** NUEVO (para que en la grilla superior ya se vea HDR):***
        /// Asigna HDR (1 por destino, máx 5 por HDR) a todas las guías activas del fletero que aún no tengan NroHDR.
        /// </summary>
        public void AsegurarHDRsAsignadasParaFletero(int dni)
        {
            var fecha = DateTime.Now.ToString("yyyyMMdd", CultureInfo.InvariantCulture);

            var activasSinHdr = _guias.Where(g => g.FleteroDni == dni && !string.Equals(g.Estado, "Entregada", StringComparison.OrdinalIgnoreCase) && string.IsNullOrEmpty(g.NroHDR))
                                      .ToList();
            if (activasSinHdr.Count == 0) return;

            foreach (var grp in activasSinHdr.GroupBy(g => NormalizarDestino(g.Destino)))
            {
                foreach (var chunk in grp.Chunk(5))
                {
                    string destinoCod = DestinoToLLL(grp.Key);
                    string nroHdr = $"H{ORIGEN_COD}{destinoCod}{fecha}{_seqHdr++:000}";

                    var hdr = new HDR
                    {
                        Numero = nroHdr,
                        Direccion = grp.Key,
                        Tipo = chunk.Any(EsRetiro) ? "Retiro" : "Distribución",
                        Guias = chunk.Select(c => c.Numero).ToList()
                    };
                    _hdrs.Add(hdr);

                    foreach (var g in chunk) g.NroHDR = nroHdr;
                }
            }
        }

        // ================= Helpers de negocio =================

        private static bool EsRetiro(Guia g) =>
            string.Equals(g.Estado, "A retirar en agencia de origen", StringComparison.OrdinalIgnoreCase)
            || string.Equals(g.Estado, "A retirar por domicilio del cliente", StringComparison.OrdinalIgnoreCase)
            || string.Equals(g.Estado, "En espera de retiro en agencia", StringComparison.OrdinalIgnoreCase)
            || string.Equals(g.Estado, "En espera de retiro al cliente", StringComparison.OrdinalIgnoreCase)
            || string.Equals(g.Estado, "En ruta a CD de origen", StringComparison.OrdinalIgnoreCase);

        private void NormalizarTipoPorEstado()
        {
            foreach (var g in _guias)
                g.Tipo = EsRetiro(g) ? "Retiro" : "Distribución";
        }

        private void MarcarAlgunasSinFleteroParaPruebas()
        {
            int i = 0;
            foreach (var g in _guias)
            {
                if (string.Equals(g.Tipo, "Retiro", StringComparison.OrdinalIgnoreCase))
                {
                    if ((++i) % 3 == 0) g.FleteroDni = null;
                }
                else
                {
                    if (g.Numero.EndsWith('5')) g.FleteroDni = null;
                }
            }
        }

        private void AdoptarGuiasSinFletero(int dni)
        {
            var estadosDistribucion = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "Admitida", "Pendiente de entrega",
                "En CD destino", "En tránsito al CD destino",
                "En ruta a la agencia de entrega", "En ruta al domicilio de entrega"
            };

            // Adopta SOLO las que corresponden y aún no tienen fletero
            foreach (var g in _guias.Where(x => x.FleteroDni == null))
            {
                if (EsRetiro(g) || (!string.Equals(g.Estado, "Entregada", StringComparison.OrdinalIgnoreCase) && estadosDistribucion.Contains(g.Estado)))
                    g.FleteroDni = dni;
            }
        }

        private static string NormalizarDestino(string destino) =>
            string.IsNullOrWhiteSpace(destino) ? "DOMICILIO" : destino.Trim().ToUpperInvariant();

        private static string DestinoToLLL(string destinoUpper)
        {
            if (destinoUpper.StartsWith("AG.", StringComparison.OrdinalIgnoreCase))
            {
                var code = SoloDigitos(destinoUpper.Substring(3)).PadLeft(4, '0');
                return code[^4..];
            }
            if (destinoUpper.StartsWith("CD", StringComparison.OrdinalIgnoreCase))
            {
                var code = SoloDigitos(destinoUpper.Substring(2)).PadLeft(4, '0');
                return code[^4..];
            }
            return "0000";
        }

        private static string SoloDigitos(string s) =>
            new string((s ?? string.Empty).Where(char.IsDigit).ToArray());

        private string NextGuiaNumber()
        {
            string lll = ORIGEN_COD.Substring(1, 3);
            return $"1{lll}{_seqGuia++:00000}";
        }

        private static string TamañoFromNumero(string numero)
        {
            int h = Math.Abs((numero ?? string.Empty).GetHashCode()) % 100;
            if (h < 42) return "S";
            if (h < 75) return "M";
            return "L";
        }

        // --------- Mapeo / importación desde tu documento ---------

        private static string MapEstado(string texto)
        {
            var t = (texto ?? "").Trim().ToLowerInvariant();

            if (t == "en espera de retiro al cliente" || t.Contains("retiro al cliente"))
                return "En espera de retiro al cliente";
            if (t == "en espera de retiro en agencia" || t == "a retirar en agencia de origen" || t.Contains("retiro en agencia"))
                return "En espera de retiro en agencia";

            if (t == "en ruta a cd de origen" || t.Contains("cd de origen")) return "En ruta a CD de origen";
            if (t == "admitida") return "Admitida";
            if (t == "en tránsito al cd destino" || (t.Contains("tránsito") && t.Contains("destino"))) return "En tránsito al CD destino";
            if (t == "en cd destino" || t.Contains("cd destino")) return "En CD destino";
            if (t == "en ruta al domicilio de entrega" || t.Contains("domicilio")) return "En ruta al domicilio de entrega";
            if (t == "en ruta a la agencia de entrega" || t.Contains("agencia de entrega")) return "En ruta a la agencia de entrega";
            if (t == "pendiente de entrega" || t.Contains("pendiente")) return "Pendiente de entrega";
            if (t == "entregada" || t.Contains("entregad")) return "Entregada";

            return "Pendiente de entrega";
        }

        private static string InferirDestino(string lugar, string estadoTxt)
        {
            string l = (lugar ?? "").Trim();

            if (!string.IsNullOrWhiteSpace(l) && l != "—" && l != "-")
            {
                if (l.StartsWith("Ag.", StringComparison.OrdinalIgnoreCase)) return $"Ag. {SoloDigitos(l)}";
                if (l.StartsWith("CD", StringComparison.OrdinalIgnoreCase)) return $"CD {SoloDigitos(l).PadLeft(4, '0')[^4..]}";
                if (l.StartsWith("Dom", StringComparison.OrdinalIgnoreCase)) return "Domicilio";
            }

            var t = (estadoTxt ?? "").ToLowerInvariant();
            if (t.Contains("domicilio")) return "Domicilio";
            if (t.Contains("agencia")) return "Ag. 0000";
            if (t.Contains("cd")) return "CD 0000";
            return "Domicilio";
        }

        public void SeedFromText(string raw, int? fleteroDniFijo = null)
        {
            if (string.IsNullOrWhiteSpace(raw)) return;

            var lines = raw.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                           .Select(l => l.Trim())
                           .Where(l => !string.IsNullOrWhiteSpace(l) && !l.StartsWith("#"))
                           .ToList();

            int rr = 0;
            foreach (var line in lines)
            {
                // Formato: "LLL NNNNN | fecha | O→D | Estado | Lugar | ..."
                var parts = line.Split('|').Select(p => p.Trim()).ToArray();
                if (parts.Length < 4) continue;

                var numTokens = parts[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (numTokens.Length < 2) continue;
                var numero = $"{numTokens[0]}-{numTokens[1]}"; // "LLL NNNNN" → "LLL-NNNNN"

                _ = DateTime.TryParse(parts[1], CultureInfo.InvariantCulture, DateTimeStyles.None, out _);

                var estadoTxt = parts[3];
                string lugar = parts.Length >= 5 ? parts[4] : string.Empty;

                var estado = MapEstado(estadoTxt);
                var destino = InferirDestino(lugar, estadoTxt);
                var tam = TamañoFromNumero(numero);

                int fleteroDni = fleteroDniFijo ?? _fleteros[(rr++) % _fleteros.Count].Dni;

                _guias.Add(new Guia
                {
                    Numero = numero,
                    Tamaño = tam,
                    Origen = "—",
                    Destino = destino,
                    Estado = estado,
                    Tipo = EsRetiro(new Guia { Estado = estado }) ? "Retiro" : "Distribución",
                    FleteroDni = fleteroDni,
                    NroHDR = null
                });
            }
        }

        // Pega aquí el bloque completo que nos pasaste (si lo querés embebido):
        private const string BULK_RAW = @"
# ===== GUIAS (originales + ampliadas) =====
1010 00015 | 2025-10-02 | 1010→0040 | En ruta a CD de origen | — | recogida en agencia por fletero
0010 04567 | 2025-09-29 | 0010→0000 | En ruta al domicilio de entrega | — | asignada HDR D 0010 000210 1020
0002 00001 | 2025-10-01 | 0002→1010 | En tránsito al CD destino | CD intermedio 0050 | media distancia
1040 00011 | 2025-10-08 | 1040→0040 | Admitida | CD 0040 | ingreso a CD
0070 00150 | 2025-09-18 | 0070→0000 | En ruta a la agencia de entrega | — | luego pasará a En agencia destino
1011 00005 | 2025-10-03 | 1011→0000 | En espera de retiro en agencia | Ag. 1011 | impuesta en agencia
1024 00007 | 2025-10-07 | 1024→0000 | En espera de retiro al cliente | Domicilio | call center
0110 00077 | 2025-10-09 | 0110→0000 | En ruta al domicilio de entrega | — | última milla
1080 00023 | 2025-10-01 | 1080→0000 | Entregada | — | con firma electrónica
1010 00016 | 2025-10-02 | 1010→0040 | En ruta a CD de origen | — | recogida en agencia por fletero
0010 04568 | 2025-09-29 | 0010→0000 | En ruta al domicilio de entrega | — |
0002 00002 | 2025-10-01 | 0002→1010 | En tránsito al CD destino | CD intermedio 0050 | media distancia
1040 00012 | 2025-10-08 | 1040→0040 | Admitida | CD 0040 | ingreso a CD
0070 00151 | 2025-09-18 | 0070→0000 | En ruta a la agencia de entrega | — | luego pasará a En agencia destino
1011 00006 | 2025-10-03 | 1011→0000 | En espera de retiro en agencia | Ag. 1011 | impuesta en agencia
1024 00008 | 2025-10-07 | 1024→0000 | En espera de retiro al cliente | Domicilio | call center
0110 00078 | 2025-10-09 | 0110→0000 | En ruta al domicilio de entrega | — | última milla
1080 00024 | 2025-10-01 | 1080→0000 | Entregada | — |
0090 00045 | 2025-10-03 | 0090→1090 | Admitida | CD 0090 | ingreso a CD
1050 00031 | 2025-10-04 | 1050→0000 | Pendiente de entrega | Ag. 1050 | espera retiro
0040 00210 | 2025-10-06 | 0040→0000 | En CD destino | CD 0050 | larga distancia completada
0001 00101 | 2025-09-30 | 0001→1001 | En ruta a la agencia de entrega | — | en tránsito urbano
1020 00029 | 2025-10-05 | 1020→0000 | En espera de retiro al cliente | Domicilio | call center
0100 00055 | 2025-10-02 | 0100→0000 | En ruta al domicilio de entrega | — | reparto local
1052 00042 | 2025-09-28 | 1052→0000 | Entregada | — | confirmada en sistema
0060 00075 | 2025-10-07 | 0060→0000 | En ruta a CD de origen | — | traslado al depósito
1095 00017 | 2025-10-03 | 1095→0000 | A retirar en agencia de origen | Ag. 1095 | lista para retiro
0040 00089 | 2025-09-25 | 0040→1040 | En ruta al domicilio de entrega | — | última milla
0020 00061 | 2025-09-27 | 0020→1020 | En tránsito al CD destino | CD intermedio 0011 | paso intermedio
1060 00022 | 2025-10-04 | 1060→0000 | En ruta al domicilio de entrega | — | en camino
0110 00081 | 2025-10-10 | 0110→0000 | Entregada | — | cierre operativo
0080 00065 | 2025-09-28 | 0080→0000 | En agencia destino | Ag. 1081 | lista para entrega
0100 00066 | 2025-09-29 | 0100→0000 | En tránsito al CD destino | CD 0090 | inter-CD
0130 00088 | 2025-10-02 | 0130→0000 | En ruta al domicilio de entrega | — | última milla
0140 00054 | 2025-10-03 | 0140→0000 | Pendiente de entrega | Ag. 1096 | espera cliente
0150 00035 | 2025-10-03 | 0150→0000 | En ruta a CD de origen | — | traslado interno
0160 00029 | 2025-10-04 | 0160→0000 | En tránsito al CD destino | CD 0050 | paso intermedio
0170 00021 | 2025-10-05 | 0170→0070 | En CD destino | CD 0070 | llegada completada
0180 00010 | 2025-10-06 | 0180→0000 | En ruta al domicilio de entrega | — | reparto final
0190 00011 | 2025-10-07 | 0190→0000 | Entregada | — | cierre
1012 00003 | 2025-09-27 | 1012→0000 | En espera de retiro en agencia | Ag. 1012 | impuesta en agencia
1013 00009 | 2025-09-26 | 1013→0000 | En espera de retiro al cliente | Domicilio | solicitud telefónica
1041 00025 | 2025-09-28 | 1041→0040 | En ruta a CD de origen | — | fletero asignado
1042 00019 | 2025-09-29 | 1042→0000 | En tránsito al CD destino | CD intermedio 0050 | media distancia
1044 00022 | 2025-09-30 | 1044→0000 | En CD destino | CD 0040 | recepción confirmada
1053 00018 | 2025-10-01 | 1053→0000 | En ruta al domicilio de entrega | — | última milla
1054 00014 | 2025-10-01 | 1054→0000 | Pendiente de entrega | Ag. 1054 | espera cliente
1055 00013 | 2025-10-02 | 1055→0000 | En ruta a la agencia de entrega | — | traslado local
1063 00011 | 2025-10-02 | 1063→0000 | En agencia destino | Ag. 1060 | lista para retiro
1072 00033 | 2025-09-28 | 1072→0000 | En espera de retiro en agencia | Ag. 1072 | lista de origen
1073 00045 | 2025-09-27 | 1073→0000 | En tránsito al CD destino | CD 0070 | ruta interprovincial
1074 00025 | 2025-09-29 | 1074→0000 | En CD destino | CD 0070 | recepción confirmada
1075 00031 | 2025-10-03 | 1075→0000 | En ruta al domicilio de entrega | — | última milla
1076 00042 | 2025-10-04 | 1076→0000 | Pendiente de entrega | Ag. 1076 | espera firma
1077 00019 | 2025-10-04 | 1077→0000 | Entregada | — | confirmada
1082 00029 | 2025-10-04 | 1082→0000 | En tránsito al CD destino | CD 0090 | media distancia
1083 00037 | 2025-10-05 | 1083→0000 | En ruta a la agencia de entrega | — | entrega en preparación
1084 00048 | 2025-10-06 | 1084→0000 | En agencia destino | Ag. 1081 | en espera
1085 00059 | 2025-10-07 | 1085→0000 | Pendiente de entrega | Ag. 1081 | espera cliente
1086 00067 | 2025-10-08 | 1086→0000 | Entregada | — | confirmada por sistema

# ===== NUEVAS GUIAS DE RETIRO (CALL CENTER – domicilio) =====
1025 00009 | 2025-10-10 | 1025→0000 | En espera de retiro al cliente | Domicilio | solicitud telefónica
1025 00010 | 2025-10-10 | 1025→0000 | En espera de retiro al cliente | Domicilio | pedido online
1026 00011 | 2025-10-10 | 1026→0000 | En espera de retiro al cliente | Domicilio | cliente corporativo
1027 00012 | 2025-10-10 | 1027→0000 | En espera de retiro al cliente | Domicilio | call center – programado
1028 00013 | 2025-10-10 | 1028→0000 | En espera de retiro al cliente | Domicilio | programado por app
1029 00014 | 2025-10-10 | 1029→0000 | En espera de retiro al cliente | Domicilio | solicitud e-commerce
1030 00015 | 2025-10-10 | 1030→0000 | En espera de retiro al cliente | Domicilio | cliente frecuente
1031 00016 | 2025-10-10 | 1031→0000 | En espera de retiro al cliente | Domicilio | pedido recurrente
1032 00017 | 2025-10-10 | 1032→0000 | En espera de retiro al cliente | Domicilio | alta demanda
1033 00018 | 2025-10-10 | 1033→0000 | En espera de retiro al cliente | Domicilio | solicitud telefónica
1034 00019 | 2025-10-10 | 1034→0000 | En espera de retiro al cliente | Domicilio | venta web
1035 00020 | 2025-10-10 | 1035→0000 | En espera de retiro al cliente | Domicilio | solicitud app móvil
1036 00021 | 2025-10-10 | 1036→0000 | En espera de retiro al cliente | Domicilio | servicio express
1037 00022 | 2025-10-10 | 1037→0000 | En espera de retiro al cliente | Domicilio | call center – turno tarde
1038 00023 | 2025-10-10 | 1038→0000 | En espera de retiro al cliente | Domicilio | pedido telefónico
1039 00024 | 2025-10-10 | 1039→0000 | En espera de retiro al cliente | Domicilio | solicitud marketplace
1040 00025 | 2025-10-10 | 1040→0000 | En espera de retiro al cliente | Domicilio | cliente preferencial
1041 00026 | 2025-10-10 | 1041→0000 | En espera de retiro al cliente | Domicilio | e-commerce
1042 00027 | 2025-10-10 | 1042→0000 | En espera de retiro al cliente | Domicilio | cliente empresa
1043 00028 | 2025-10-10 | 1043→0000 | En espera de retiro al cliente | Domicilio | solicitud telefónica
1044 00029 | 2025-10-10 | 1044→0000 | En espera de retiro al cliente | Domicilio | pedido online
1045 00030 | 2025-10-10 | 1045→0000 | En espera de retiro al cliente | Domicilio | call center – prioridad
1046 00031 | 2025-10-10 | 1046→0000 | En espera de retiro al cliente | Domicilio | solicitud manual
1047 00032 | 2025-10-10 | 1047→0000 | En espera de retiro al cliente | Domicilio | cliente premium
1048 00033 | 2025-10-10 | 1048→0000 | En espera de retiro al cliente | Domicilio | solicitud web
1049 00034 | 2025-10-10 | 1049→0000 | En espera de retiro al cliente | Domicilio | pedido express

# ===== NUEVAS GUIAS DE RETIRO (EN AGENCIA – origen) =====
1111 00001 | 2025-10-10 | 1111→0000 | En espera de retiro en agencia | Ag. 1111 | mostrador
1112 00002 | 2025-10-10 | 1112→0000 | En espera de retiro en agencia | Ag. 1112 | bultos grandes
1113 00003 | 2025-10-10 | 1113→0000 | En espera de retiro en agencia | Ag. 1113 | cliente espera
1114 00004 | 2025-10-10 | 1114→0000 | En espera de retiro en agencia | Ag. 1114 | sector paquetería
1115 00005 | 2025-10-10 | 1115→0000 | En espera de retiro en agencia | Ag. 1115 | ingreso morning

# ===== NUEVAS GUIAS DE DISTRIBUCIÓN (llegadas/para entregar) =====
2001 00001 | 2025-10-10 | 2001→0000 | Admitida | CD 0040 | ingreso a CD
2002 00002 | 2025-10-10 | 2002→0000 | En CD destino | CD 0040 | llegada completada
2003 00003 | 2025-10-10 | 2003→0000 | En agencia destino | Ag. 1050 | lista para entrega
2004 00004 | 2025-10-10 | 2004→0000 | Pendiente de entrega | Ag. 1051 | espera cliente
2005 00005 | 2025-10-10 | 2005→0000 | En ruta al domicilio de entrega | — | reparto local
2006 00006 | 2025-10-10 | 2006→0000 | En ruta a la agencia de entrega | — | traslado a agencia
2007 00007 | 2025-10-10 | 2007→0000 | Admitida | CD 0040 | ingreso vespertino
2008 00008 | 2025-10-10 | 2008→0000 | En CD destino | CD 0070 | recepcionado
2009 00009 | 2025-10-10 | 2009→0000 | En agencia destino | Ag. 1081 | en mostrador
2010 00010 | 2025-10-10 | 2010→0000 | Pendiente de entrega | Ag. 1096 | espera contacto
2011 00011 | 2025-10-10 | 2011→0000 | En ruta al domicilio de entrega | — | última milla
2012 00012 | 2025-10-10 | 2012→0000 | En ruta a la agencia de entrega | — | ruteo interno
2013 00013 | 2025-10-10 | 2013→0000 | En CD destino | CD 0090 | cross-dock ok
2014 00014 | 2025-10-10 | 2014→0000 | En agencia destino | Ag. 1060 | disponible
2015 00015 | 2025-10-10 | 2015→0000 | Pendiente de entrega | Ag. 1076 | pendiente visita
""
# pegá aquí tu lista larga de guías (las líneas que nos pasaste)
";
    }
}
