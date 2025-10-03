using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TUTASAPrototipo.ConfirmarHojaDeRuta
{
    public partial class ConfirmarHojaDeRutaForm : Form
    {
        public ConfirmarHojaDeRutaForm()
        {
            InitializeComponent();
        }

        private void ActualizarEstadoButton_Click(object sender, EventArgs e)
        {
            //mock para el mensaje
            string IdHojaRuta = "JJ56891233";


            // Mensaje 
            string mensaje = "Hoja de Ruta " + IdHojaRuta + " confirmada";

            // Mostramos el MessageBox
            MessageBox.Show(
                mensaje,
                "Confirmación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
