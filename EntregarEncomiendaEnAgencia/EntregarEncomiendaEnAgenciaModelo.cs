// ===============================
// EntregarEncomiendaEnAgenciaModelo.cs
// ===============================

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using TUTASAPrototipo.Almacenes; // Usamos entidades y almacenes (solo lectura)

namespace TUTASAPrototipo.EntregarEncomiendaEnAgencia
{
    public class EntregarEncomiendaEnAgenciaModelo
    {
        // Inicializadas para no quedar null al salir del ctor
        public List<Destinatario> Destinatarios { get; private set; } = new();
        public List<Guia> Guias { get; private set; } = new();

        // Estado local: números de guía entregados en esta sesión (no persistente)
        private readonly HashSet<string> _guiasEntregadasLocalmente = new();

        public EntregarEncomiendaEnAgenciaModelo()
        {
            InicializarDatos();
        }

        private void InicializarDatos()
        {
            // Datos de prueba COMENTADOS: ahora se usa SOLO LECTURA desde los almacenes/JSON
            // Destinatarios = new List<Destinatario> { ... };
            // Guias = new List<Guia> { ... };
        }

        public Destinatario? BuscarDestinatarioPorDNI(string dni)
        {
            // Tomamos el primer destinatario que matchee el DNI desde las guías cargadas en almacén
            var dest = GuiaAlmacen.guias
                .Select(g => g.Destinatario)
                .FirstOrDefault(d => d.DNI.ToString() == dni);

            if (dest is null) return null;

            var resultado = new Destinatario
            {
                DNI = dest.DNI.ToString(),
                Nombre = dest.Nombre,
                Apellido = dest.Apellido
            };

            Destinatarios = new List<Destinatario> { resultado };
            return resultado;
        }

        public List<Guia> BuscarGuiasPendientes(string dni, string agenciaActual)
        {
            // Resolver la agencia por nombre -> ID para comparar contra IDAgenciaDestino en las guías
            var agencias = File.Exists(Path.Combine("Datos", "Agencias.json"))
                ? (JsonSerializer.Deserialize<List<AgenciaEntidad>>(File.ReadAllText(Path.Combine("Datos", "Agencias.json"))) ?? new List<AgenciaEntidad>())
                : new List<AgenciaEntidad>();

            var agencia = agencias.FirstOrDefault(a => string.Equals(a.Nombre, agenciaActual, StringComparison.OrdinalIgnoreCase));
            if (agencia is null)
            {
                Guias = new List<Guia>();
                return Guias;
            }

            var resultados = GuiaAlmacen.guias
                .Where(g =>
                    g.Destinatario.DNI.ToString() == dni &&
                    g.Estado == EstadoGuiaEnum.PendienteDeEntrega &&
                    g.TipoEntrega == EntregaEnum.Agencia &&
                    string.Equals(g.IDAgenciaDestino, agencia.ID, StringComparison.OrdinalIgnoreCase) &&
                    !_guiasEntregadasLocalmente.Contains(g.NumeroGuia.ToString()) // excluir entregadas en esta sesión
                )
                .Select(g => new Guia
                {
                    NumeroGuia = g.NumeroGuia.ToString(),
                    Tamanio = g.Tamano.ToString(),
                    DniDestinatario = g.Destinatario.DNI.ToString(),
                    Estado = "Pendiente de entrega",
                    Ubicacion = agencia.Nombre
                })
                .ToList();

            Guias = resultados;
            return resultados;
        }

        public bool ConfirmarEntrega(List<string> numerosDeGuia)
        {
            foreach (var numeroGuia in numerosDeGuia)
            {
                var guia = Guias.FirstOrDefault(g => g.NumeroGuia == numeroGuia);
                if (guia != null)
                {
                    guia.Estado = "Entregada";
                    guia.Ubicacion = string.Empty; // sin ubicación cuando está entregada
                }

                // registrar como entregada en esta sesión (no persistente)
                if (!string.IsNullOrWhiteSpace(numeroGuia))
                {
                    _guiasEntregadasLocalmente.Add(numeroGuia);
                }
            }
            return true;
        }
    }
}
