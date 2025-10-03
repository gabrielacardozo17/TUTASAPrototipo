using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TUTASAPrototipo.ImponerEncomienda
{
    public partial class ImponerEncomiendaForm : Form
    {
        public ImponerEncomiendaForm()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void ConfirmarButton_Click(object sender, EventArgs e)
        {
            //mock numeros de guía
            List<string> numerosGuia = new List<string> { "123456", "234567", "345678" };

            // Mensaje con cada número de guía en un renglón
            string mensaje = "Datos de imposición guardados correctamente\n"
                            + "Los números de guías generados son: \n" //habria de ver si este mensaje puede cambiar si es 1 guía o +1 guía
                             + string.Join("\n", numerosGuia);

            // Mostramos el MessageBox
            MessageBox.Show(
                mensaje,
                "Confirmación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
        }
    }
}
