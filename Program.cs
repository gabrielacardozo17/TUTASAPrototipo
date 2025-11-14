
using System.Configuration;
using TUTASAPrototipo.Almacenes;
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
            //Application.Run(new EmitirFactura.EmitirFacturaForm());
            //Application.Run(new ConsultarEstado.ConsultarEstadoForm()); 
            //Application.Run(new ImponerEncomiendaCallCenter.ImponerEncomiendaCallCenterForm());
            //Application.Run(new ImponerEncomiendaAgencia.ImponerEncomiendaAgenciaForm());
            //Application.Run(new ImponerEncomiendaCD.ImponerEncomiendaCentroDistribucionForm());
            //Application.Run(new EntregarEncomiendaEnAgencia.EntregarEncomiendaEnAgenciaForm());
            //Application.Run(new EntregarEncomiendaCD.EntregarEncomiendaCDForm());   
            //Application.Run(new MonitoreoResultados.MonitoreoResultadosForm());
            //Application.Run(new RecepcionAgencia.RecepcionAgenciaForm1());
            //Application.Run(new RecepcionYDespachoLargaDistancia.RecepcionYDespachoLargaDistanciaForm());
            //Application.Run(new RecepcionYDespachoUltimaMillaCD.RecepcionYDespachoUltimaMillaForm());
            //Application.Run(new EstadoCuentaCorrienteCliente.EstadoCuentaCorrienteClienteForm());
            Application.Run(new LoginUsuario.LoginUsuarioForm());


            GuiaAlmacen.Grabar();
            FacturaAlmacen.Grabar();
            CuentaCorrienteAlmacen.Grabar();
        }
    }
}