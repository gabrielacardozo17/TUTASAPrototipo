namespace TUTASAPrototipo
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new ImponerEncomienda.ImponerEncomiendaForm());
            //Application.Run(new ConsultarEstadoGuia());
            //Application.Run(new AdmitirEncomienda.AdmitirEncomiendaForm());
            Application.Run(new ConfeccionarHojaDeRuta.ConfeccionarHojaDeRutaForm());
           // Application.Run(new EmitirFactura.EmitirFacturaForm()); 
            //Application.Run(new ActualizarHojaDeRuta());
           // Application.Run(new ConfirmarHojaDeRuta.ConfirmarHojaDeRutaForm());
            //Application.Run(new ConsultarEstado.ConsultarEstadoForm()); 
        }
    }
}