using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TUTASAPrototipo.EmitirFactura
{
    public partial class EmitirFacturaForm : Form
    {
        public EmitirFacturaForm()
        {
            InitializeComponent();
        }

        private void EmitirFacturaButton_Click(object sender, EventArgs e)
        {
            // Mensaje simple
            MessageBox.Show(
                "Se ha generado la factura exitosamente", // Texto del mensaje
                "Confirmación",                      // Título de la ventana
                MessageBoxButtons.OK,                // Botones disponibles
                MessageBoxIcon.Information           // Icono del mensaje
            );
        }
    }
}
