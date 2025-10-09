using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TUTASAPrototipo.MonitoreoResultados
{
    public partial class MonitoreoResultadosForm : Form
    {
        private readonly MonitoreoResultadosModelo Modelo = new(); // accedemos al modelo
        public MonitoreoResultadosForm()
        {
            InitializeComponent();
        }

        private void BuscarResultadosxPeriodoButton_Click(object sender, EventArgs e)
        {
            //limpio la lista
            ResultadosxEmpresaListView.Items.Clear();

            // Tomo el mes y año seleccionados
            int año = PeriodoDateTimePicker.Value.Year;
            int mes = PeriodoDateTimePicker.Value.Month;


            //antes de enviarlo al modelo, valido si el periodo seleccionado es correcto
            if (PeriodoDateTimePicker.Value > DateTime.Now)
            {
                MessageBox.Show("El período seleccionado no es válido (futuro).",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }


            // Se los envío al modelo para obtener los datos
            var resultados = Modelo.ObtenerResultados(año, mes);
            bool hayResultados = resultados.Any(resultados => resultados.Costo > 0 || resultados.Venta > 0); //verifico que existan datos > 0, si todos son 0 entonces no hay datos para el periodo seleccionado

            if (!hayResultados)
            {
                MessageBox.Show(
                    "No se encontraron resultados para el período seleccionado.",
                    "Sin resultados",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                 );
                return;
            }

            // Muestro el resultado obtenido en el ListView, si existen datos para el periodo
            foreach (var r in resultados)
            {
                var item = new ListViewItem(r.Empresa);
                item.SubItems.Add(r.Costo.ToString("N2"));
                item.SubItems.Add(r.Venta.ToString("N2"));
                item.SubItems.Add(r.Resultado.ToString("N2"));
                ResultadosxEmpresaListView.Items.Add(item);
            }



        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MonitoreoResultadosForm_Load(object sender, EventArgs e)
        {

        }
    }

}
