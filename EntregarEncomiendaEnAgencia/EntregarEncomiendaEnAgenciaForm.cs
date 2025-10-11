﻿// ===============================
// EntregarEncomiendaEnAgenciaForm.cs
// Pantalla: Entrega de encomiendas en Agencia
// Flujo: igual a CD pero filtrando por Agencia actual y estado "Pendiente de entrega"
// ===============================

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TUTASAPrototipo.EntregarEncomiendaEnAgencia
{
    public partial class EntregarEncomiendaEnAgenciaForm : Form
    {
        private EntregarEncomiendaEnAgenciaModelo modelo;

        public EntregarEncomiendaEnAgenciaForm()
        {
            InitializeComponent();
            modelo = new EntregarEncomiendaEnAgenciaModelo();
        }

        // Reemplazar este método en EntregarEncomiendaEnAgenciaForm.cs
        private void EntregarEncomiendaEnAgenciaForm_Load(object sender, EventArgs e)
        {
            UsuarioResult.Text = "f.martinez";
            AgenciaResult.Text = "Ag. CABA Flores"; // antes: "Ag. 1011"
            NombreDestinatarioResult.Text = "";
            ApellidoDestinatarioResult.Text = "";
        }


        // -------------------------------------------------------------------------
        // MANEJADORES DE EVENTOS
        // -------------------------------------------------------------------------

        private void BuscarDestinararioButton_Click(object sender, EventArgs e)
        {
            // Limpiar resultados anteriores
            LimpiarCampos();

            // Validación N0: Campo requerido
            if (string.IsNullOrWhiteSpace(DNIDestinatarioTextBox.Text))
            {
                MessageBox.Show("Debe ingresar un número de DNI.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validación N1: Formato (numérico)
            if (!long.TryParse(DNIDestinatarioTextBox.Text, out _))
            {
                MessageBox.Show("El DNI debe ser un valor numérico.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener datos del modelo
            string dniBuscado = DNIDestinatarioTextBox.Text;
            var destinatario = modelo.BuscarDestinatarioPorDNI(dniBuscado);

            if (destinatario == null)
            {
                MessageBox.Show("No se encontró un destinatario con el DNI ingresado.", "Búsqueda sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Mostrar datos del destinatario (labels de resultado)
            // CORRECCIÓN FINAL Y DEFINITIVA: Usando los nombres de control que existen en tu diseñador.
            NombreDestinatarioResult.Text = destinatario.Nombre;
            ApellidoDestinatarioResult.Text = destinatario.Apellido;

            // Buscar y mostrar guías pendientes en la Agencia actual
            CargarGuiasPendientes(destinatario.DNI);
        }

        private void ConfirmarEntregaButton_Click(object sender, EventArgs e)
        {
            // Validación N2: Consistencia (debe haber guías para entregar)
            // CORREGIDO: Usando el nombre correcto del ListView: GuiasARecepcionarAgenciaListView
            if (GuiasARecepcionarAgenciaListView.Items.Count == 0)
            {
                MessageBox.Show("Debe ingresar un número de DNI.", "Operación no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Recopilar los números de guía a entregar
            var guiasParaEntregar = new List<string>();
            foreach (ListViewItem item in GuiasARecepcionarAgenciaListView.Items)
            {
                guiasParaEntregar.Add(item.SubItems[0].Text);
            }

            // Confirmar entrega en el modelo
            bool exito = modelo.ConfirmarEntrega(guiasParaEntregar);

            if (exito)
            {
                MessageBox.Show("La entrega se ha registrado correctamente.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormularioCompleto();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al registrar la entrega.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            // Cierra la pantalla (regreso al menú o flujo anterior)
            this.Close();
        }

        private void CargarGuiasPendientes(string dni)
        {
            // Toma la agencia de la sesión (label superior)
            string agenciaActual = AgenciaResult.Text;

            // Busca guías "Pendiente de entrega" en la agencia actual
            var guias = modelo.BuscarGuiasPendientes(dni, agenciaActual);

            if (guias.Count == 0)
            {
                MessageBox.Show("El destinatario no tiene encomiendas pendientes de entrega en esta agencia.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpieza adicional (igual que en CD)
                NombreDestinatarioResult.Text = "";
                ApellidoDestinatarioResult.Text = "";
                GuiasARecepcionarAgenciaListView.Items.Clear();

                // Dejar el foco en el DNI para intentar otra búsqueda
                DNIDestinatarioTextBox.Select();
                DNIDestinatarioTextBox.Focus();
                return;
            }

            // Carga de filas en el ListView (Nro de guía + Tamaño)
            foreach (var guia in guias)
            {
                ListViewItem item = new ListViewItem(guia.NumeroGuia);
                item.SubItems.Add(guia.Tamanio.ToString());
                GuiasARecepcionarAgenciaListView.Items.Add(item);
            }
        }


        private void LimpiarCampos()
        {
            // CORREGIDO: Usando los nombres de control correctos que existen en tu diseñador.
            NombreDestinatarioResult.Text = "";
            ApellidoDestinatarioResult.Text = "";
            GuiasARecepcionarAgenciaListView.Items.Clear();
        }

        private void LimpiarFormularioCompleto()
        {
            // Limpia toda la pantalla para permitir una nueva operación
            DNIDestinatarioTextBox.Clear();
            LimpiarCampos();
        }
    }
}
