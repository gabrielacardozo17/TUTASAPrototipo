using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TUTASAPrototipo.AdmitirEncomienda
{
    public partial class AdmitirEncomiendaForm : Form
    {
        public AdmitirEncomiendaForm()
        {
            InitializeComponent();
        }

        private void TipoEncomiendaLabel_Click(object sender, EventArgs e)
        {

        }

        private void AdmitirGuiaButton_Click(object sender, EventArgs e)
        {
            // Mostramos el MessageBox
            MessageBox.Show(
                "Se ha admitido exitosamente la encomienda",
                "Confirmación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
        }
    }
}
