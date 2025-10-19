namespace TUTASAPrototipo.RecepcionYDespachoLargaDistancia
{
    public class Guia
    {
        public string NumeroGuia { get; set; }
        public string Tamanio { get; set; }
        public string Destino { get; set; } // Usado solo para la lista de despacho
        public bool Procesada { get; set; } = false; // Nueva propiedad para control de estado
    }
}