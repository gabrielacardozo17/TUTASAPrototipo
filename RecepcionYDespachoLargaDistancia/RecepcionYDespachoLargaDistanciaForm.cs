using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TUTASAPrototipo.RecepcionYDespachoLargaDistancia
{
    public partial class RecepcionYDespachoLargaDistanciaForm : Form
    {
        // *** Declaración del Modelo (Sintaxis Estándar del Equipo) ***
        private readonly RecepcionYDespachoLargaDistanciaModelo _modelo = new();

        public RecepcionYDespachoLargaDistanciaForm()
        {
            InitializeComponent();
            // Los métodos ya no necesitan re-configurar las columnas
            // si ya están definidas en el Designer.cs, pero se mantienen 
            // para asegurar la estructura mínima si faltara algo en el Designer.
            ConfigurarListViews();
            LimpiarPantalla();

            // Asignación de eventos de los botones (necesario para que funcionen)
            BuscarServicioButton.Click += BuscarButton_Click;
            ConfirmarRecepcionYDespachoButton.Click += ConfirmarButton_Click;
            CancelarButton.Click += SalirButton_Click;
        }

        // *** Inicialización y Configuración de Controles ***
        private void ConfigurarListViews()
        {
            // Se asume que las columnas (columnHeader1, columnHeader2, etc.) ya están declaradas
            // y configuradas en el Designer. Se ajusta la vista por seguridad.
            GuiaxServicioRecibidaListView.View = View.Details;
            GuiasADespacharxServicioListView.View = View.Details;
        }

        private void LimpiarPantalla()
        {
            // Se usa NumServicioTextBox, que es el nombre correcto según el Designer.cs
            NumServicioTextBox.Clear();
            GuiaxServicioRecibidaListView.Items.Clear();
            GuiasADespacharxServicioListView.Items.Clear();
        }

        // *** Manejo de Eventos y Lógica de Interfaz ***

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            // Se usa NumServicioTextBox, que es el nombre correcto
            string nroServicio = NumServicioTextBox.Text.Trim();

            // Nivel 0 (Validación de campo requerido)
            if (string.IsNullOrWhiteSpace(nroServicio))
            {
                MessageBox.Show("Debe ingresar el número de servicio primero.", "Validación N0", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LimpiarPantalla();
                return;
            }

            // Nivel 1 y 2 (Validación de formato numérico y longitud 7-8)
            if (!Regex.IsMatch(nroServicio, @"^\d{7,8}$"))
            {
                MessageBox.Show("Debe ingresar un número que contenga entre 7 y 8 caracteres y ser numérico.", "Validación N1-N2", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LimpiarPantalla();
                return;
            }

            // Nivel 3 (Validación de existencia del servicio - Delegada al Modelo)
            if (!_modelo.ExisteServicio(nroServicio))
            {
                MessageBox.Show("No existe ese servicio. Vuelva a intentarlo.", "Error de Búsqueda N3", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarPantalla();
                return;
            }

            // Si las validaciones son correctas, busca y muestra los datos
            MostrarResultados(nroServicio);
        }

        private void MostrarResultados(string nroServicio)
        {
            // Limpia resultados anteriores
            GuiaxServicioRecibidaListView.Items.Clear();
            GuiasADespacharxServicioListView.Items.Clear();

            // Llama al modelo para obtener los datos
            var resultados = _modelo.BuscarGuiasPorServicio(nroServicio);

            // Carga el ListView de guías a recibir
            foreach (var enc in resultados.aRecibir)
            {
                var item = new ListViewItem(enc.NroGuia);
                item.SubItems.Add(enc.Tamano);
                GuiaxServicioRecibidaListView.Items.Add(item);
            }

            // Carga el ListView de guías a despachar
            foreach (var enc in resultados.aDespachar)
            {
                var item = new ListViewItem(enc.NroGuia);
                item.SubItems.Add(enc.Tamano);
                item.SubItems.Add(enc.Destino);
                GuiasADespacharxServicioListView.Items.Add(item);
            }

            if (resultados.aRecibir.Count == 0 && resultados.aDespachar.Count == 0)
            {
                MessageBox.Show($"No hay encomiendas asignadas al servicio {nroServicio} para recibir o despachar en este momento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ConfirmarButton_Click(object sender, EventArgs e)
        {
            // Se usa NumServicioTextBox, que es el nombre correcto
            string nroServicio = NumServicioTextBox.Text.Trim();

            // Nivel 0 (Validación de campo requerido antes de confirmar) - Excepción 11.2 del CU
            if (string.IsNullOrWhiteSpace(nroServicio))
            {
                MessageBox.Show("Debe ingresar el número de servicio primero.", "Validación N0", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Nivel 3/4: Validación de existencia de guías en pantalla (Mejora de diseño)
            if (GuiaxServicioRecibidaListView.Items.Count == 0 && GuiasADespacharxServicioListView.Items.Count == 0)
            {
                MessageBox.Show("No hay guías cargadas para recibir ni para despachar. Por favor, realice la búsqueda primero.", "Validación N3", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Llama al modelo para confirmar la operación (Nivel 4)
            _modelo.ConfirmarOperacion(nroServicio);

            // Mensaje de éxito
            MessageBox.Show($"Operación de Recepción/Despacho para el servicio {nroServicio} finalizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpia la pantalla para una nueva operación
            LimpiarPantalla();
        }

        private void SalirButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NumServicioTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
