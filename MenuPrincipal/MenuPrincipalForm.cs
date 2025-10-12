using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TUTASAPrototipo.ConsultarEstado;
using TUTASAPrototipo.EmitirFactura;
using TUTASAPrototipo.EntregarEncomiendaCD;
using TUTASAPrototipo.EntregarEncomiendaEnAgencia;
using TUTASAPrototipo.EstadoCuentaCorrienteCliente;
using TUTASAPrototipo.ImponerEncomiendaAgencia;
using TUTASAPrototipo.ImponerEncomiendaCallCenter;
using TUTASAPrototipo.ImponerEncomiendaCD;
using TUTASAPrototipo.MonitoreoResultados;
using TUTASAPrototipo.RecepcionYDespachoAgencia;
using TUTASAPrototipo.RecepcionYDespachoLargaDistancia;
using TUTASAPrototipo.RecepcionYDespachoUltimaMillaCD;

namespace TUTASAPrototipo.MenuPrincipal
{
    public partial class MenuPrincipalForm : Form
    {

        public MenuPrincipalForm()
        {
            InitializeComponent();
        }



        private void MenuPrincipalForm_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ImposicionCallCenterButton_Click(object sender, EventArgs e)
        {
            using (var ImposicionCallCenter = new ImponerEncomiendaCallCenterForm())
            {
                ImposicionCallCenter.ShowDialog();
            }
        }
        

        private void CallCenterGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void AdministracionYFinanzasGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void AgenciaGroupBox_Enter(object sender, EventArgs e)
        {

        }



        private void ImposicionAgenciaButton_Click(object sender, EventArgs e)
        {
            using (var ImposicionAgencia = new ImponerEncomiendaAgenciaForm())
            {
                ImposicionAgencia.ShowDialog();
            }
        }

        private void RecepcionAgenciaButton_Click(object sender, EventArgs e)
        {
            using (var RecepcionAgencia = new RecepcionYDespachoAgenciaForm1())
            {
                RecepcionAgencia.ShowDialog();
            }
        }

        private void EntregarEncomiendaAgenciaButton_Click(object sender, EventArgs e)
        {
            using (var EntregaAgencia = new EntregarEncomiendaEnAgenciaForm())
            {
                EntregaAgencia.ShowDialog();
            }
        }

        private void ImposicionEncomiendasCDButton_Click(object sender, EventArgs e)
        {
            using (var ImposicionCD = new ImponerEncomiendaCentroDistribucionForm())
            {
                ImposicionCD.ShowDialog();
            }
        }

        private void RecepcionYDespachoUMButton_Click(object sender, EventArgs e)
        {
            using (var RecepcionDespachoUM = new RecepcionYDespachoUltimaMillaForm())
            {
                RecepcionDespachoUM.ShowDialog();
            }

        }

        private void RecepcionYDespachoLargaDistanciaButton_Click(object sender, EventArgs e)
        {
            using (var RecepcionDespachoLargaDistancia = new RecepcionYDespachoLargaDistanciaForm())
            {
                RecepcionDespachoLargaDistancia.ShowDialog();
            }
        }

        private void EntregaEncomiendasCDButton_Click(object sender, EventArgs e)
        {
            using (var EntregaEncomiendasCD = new EntregarEncomiendaCDForm())
            {
                EntregaEncomiendasCD.ShowDialog();
            }
        }

        private void ConsultarEstadoButton_Click(object sender, EventArgs e)
        {
            using (var ConsultarEstado = new ConsultarEstadoForm())
            {
                ConsultarEstado.ShowDialog();
            }
        }

        private void EmitirFacturaButton_Click(object sender, EventArgs e)
        {
            using (var EmitirFactura = new EmitirFacturaForm())
            {
                EmitirFactura.ShowDialog();
            }
        }

        private void ConsultarEstadoCCButton_Click(object sender, EventArgs e)

        {
            using (var EstadoCuentaCorriente = new EstadoCuentaCorrienteClienteForm())
            {
                EstadoCuentaCorriente.ShowDialog();
            }
        }

        private void MonitorearResultadosButton_Click(object sender, EventArgs e)
        {
            using (var MonitoreoForm = new MonitoreoResultadosForm())
            {
                MonitoreoForm.ShowDialog();
            }
        }

        private void ConsultarEstadoCallCenter_Click(object sender, EventArgs e)
        {
            using (var ConsultarEstado = new ConsultarEstadoForm())
            {
                ConsultarEstado.ShowDialog();
            }
        }
    }
    
}
