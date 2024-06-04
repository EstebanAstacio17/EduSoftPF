using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace EduSoftPF
{
    public partial class VentanaDePago : Form
    {
        private string connectionString = "SERVER=ASTACIO\\SQLEXPRESS; DATABASE=DBEDUSOFTPF; Integrated Security=True";

        private decimal totalPago = 0; // Variable para almacenar el total de pagos
        public VentanaDePago()
        {
            InitializeComponent();

            // Asocia los eventos RowsAdded y RowsRemoved al DataGridView
            dgvListaPago.RowsAdded += DgvListaPago_RowsAdded;
            dgvListaPago.RowsRemoved += DgvListaPago_RowsRemoved;
        }

        private void VentanaDePago_Load(object sender, EventArgs e)
        {
            // Load Cursos when the form is loaded
            CargarCursos();

            LlenarDataGridViewEstudiantes();

            // Ajusta el tamaño de las columnas después de establecer la fuente de datos
            AjustarTamanioColumnas();
        }

        private void btnBuscarAlumnoPago_Click(object sender, EventArgs e)
        {
            // Verificar si el TextBox tiene algún valor
            if (!string.IsNullOrEmpty(txtBuscarAlumnoPago.Text))
            {
                AccionDeBuscarMatriculaNombre();
            }

            // Verificar si el ComboBox de Curso tiene algún valor seleccionado
            if (cboCursoAlumnoPago.SelectedItem != null)
            {
                AccionDeBuscarCurso();
            }

            // Verificar si el ComboBox de Estado tiene algún valor seleccionado
            if (cboEstadoAlumnoPago.SelectedItem != null)
            {
                AccionDeBuscarEstadoEstudiante();
            }

            AjustarTamanioColumnas();
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            LimpiarCamposDeBusqueda();

            // Llena el DataGridView después de limpiar los campos y ajusta las columnas nuevamente
            LlenarDataGridViewEstudiantes();
        }

        private void btnSacarPago_Click(object sender, EventArgs e)
        {
            // Verifica si hay al menos una fila seleccionada en dgvListaPago
            if (dgvListaPago.SelectedRows.Count > 0)
            {
                // Obtén la fila seleccionada
                DataGridViewRow filaSeleccionada = dgvListaPago.SelectedRows[0];

                // Remueve la fila seleccionada del DataGridView
                dgvListaPago.Rows.Remove(filaSeleccionada);
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila para eliminar.");
            }
        }

        private void btnCancelarPago_Click(object sender, EventArgs e)
        {
            // Verifica si hay al menos una fila en el DataGridView
            if (dgvListaPago.Rows.Count > 0)
            {
                // Muestra un cuadro de diálogo de confirmación
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas cancelar el pago y limpiar la lista?", "Confirmar Cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Si el usuario confirma la acción, limpia el DataGridView
                if (resultado == DialogResult.Yes)
                {
                    dgvListaPago.Rows.Clear();
                    RecalcularTotal(); // Asegúrate de recalcular el total después de limpiar el DataGridView
                }
            }
            else
            {
                MessageBox.Show("No hay datos en la lista de pagos para cancelar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPagarAlumno_Click(object sender, EventArgs e)
        {
            // Verifica si hay al menos una fila en el DataGridView
            if (dgvListaPago.Rows.Count > 0)
            {
                // Aquí colocas el código actual del evento btnPagarAlumno_Click

                // Por ejemplo, podrías mostrar un mensaje indicando que el pago se realizó correctamente
                MessageBox.Show("Pago realizado correctamente.");

                // Luego, puedes limpiar el DataGridView y recalcular el total
                dgvListaPago.Rows.Clear();
                RecalcularTotal();
            }
            else
            {
                MessageBox.Show("No hay datos en la lista de pagos para realizar el pago.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LlenarDataGridViewEstudiantes()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();

                    // Consulta SQL para seleccionar solo las columnas necesarias
                    string consulta = "SELECT Id_Estudiante AS 'Matricula', PrimerNombreEstudiante AS 'Primer Nombre', SegundoNombreEstudiante AS 'Segundo Nombre', PrimerApellidoEstudiante AS 'Primer Apellido', SegundoApellidoEstudiante AS 'Segundo Apellido', CursoEstudiante AS 'Curso', EstadoEstudiante AS 'Estado' FROM Estudiante";

                    // Crea un SqlDataAdapter para ejecutar la consulta y llenar el DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Asigna el DataTable como fuente de datos para el DataGridView
                        dgvVerAlumnoPago.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar el DataGridView: " + ex.Message);
            }
        }

        private void AccionDeBuscarMatriculaNombre()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();

                    // Consulta SQL con filtro utilizando el valor del TextBox
                    string consulta = "SELECT Id_Estudiante AS 'Matricula', PrimerNombreEstudiante AS 'Primer Nombre', SegundoNombreEstudiante AS 'Segundo Nombre', PrimerApellidoEstudiante AS 'Primer Apellido', SegundoApellidoEstudiante AS 'Segundo Apellido', CursoEstudiante AS 'Curso', EstadoEstudiante AS 'Estado' FROM Estudiante " +
                                      "WHERE PrimerNombreEstudiante LIKE @filtro OR SegundoNombreEstudiante LIKE @filtro " +
                                      "OR PrimerApellidoEstudiante LIKE @filtro OR SegundoApellidoEstudiante LIKE @filtro " +
                                      "OR Id_Estudiante LIKE @filtro";

                    // Crea un SqlDataAdapter para ejecutar la consulta y llenar el DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion))
                    {
                        // Agrega parámetros para el filtro
                        adapter.SelectCommand.Parameters.AddWithValue("@filtro", "%" + txtBuscarAlumnoPago.Text + "%");

                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Asigna el DataTable como fuente de datos para el DataGridView
                        dgvVerAlumnoPago.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar en el DataGridView: " + ex.Message);
            }
        }

        private void AccionDeBuscarCurso()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();

                    // Consulta SQL con filtro utilizando el valor del TextBox
                    string consulta = "SELECT Id_Estudiante AS 'Matricula', PrimerNombreEstudiante AS 'Primer Nombre', SegundoNombreEstudiante AS 'Segundo Nombre', PrimerApellidoEstudiante AS 'Primer Apellido', SegundoApellidoEstudiante AS 'Segundo Apellido', CursoEstudiante AS 'Curso', EstadoEstudiante AS 'Estado' FROM Estudiante " +
                                      "WHERE CursoEstudiante LIKE @filtro ";

                    // Crea un SqlDataAdapter para ejecutar la consulta y llenar el DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion))
                    {
                        // Agrega parámetros para el filtro
                        adapter.SelectCommand.Parameters.AddWithValue("@filtro", "%" + cboCursoAlumnoPago.Text + "%");

                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Asigna el DataTable como fuente de datos para el DataGridView
                        dgvVerAlumnoPago.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar en el DataGridView: " + ex.Message);
            }
        }

        private void AccionDeBuscarEstadoEstudiante()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();

                    // Consulta SQL con filtro utilizando el valor del ComboBox
                    string consulta = "SELECT Id_Estudiante AS 'Matricula', PrimerNombreEstudiante AS 'Primer Nombre', SegundoNombreEstudiante AS 'Segundo Nombre', PrimerApellidoEstudiante AS 'Primer Apellido', SegundoApellidoEstudiante AS 'Segundo Apellido', CursoEstudiante AS 'Curso', EstadoEstudiante AS 'Estado' FROM Estudiante " +
                                      "WHERE EstadoEstudiante = @estado";

                    // Crea un SqlDataAdapter para ejecutar la consulta y llenar el DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion))
                    {
                        // Agrega parámetros para el filtro
                        string estadoSeleccionado = cboEstadoAlumnoPago.SelectedItem.ToString();
                        adapter.SelectCommand.Parameters.AddWithValue("@estado", estadoSeleccionado);

                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Asigna el DataTable como fuente de datos para el DataGridView
                        dgvVerAlumnoPago.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar en el DataGridView: " + ex.Message);
            }
        }

        private void CargarCursos()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();

                    string selectQuery = "SELECT Curso FROM Curso";
                    using (SqlCommand cmd = new SqlCommand(selectQuery, conexion))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cboCursoAlumnoPago.Items.Add(reader["Curso"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los Cursos: " + ex.Message);
            }
        }

        private void LimpiarCamposDeBusqueda()
        {
            // Limpiar el TextBox
            txtBuscarAlumnoPago.Clear();

            // Desseleccionar los ComboBox
            cboCursoAlumnoPago.SelectedIndex = -1;
            cboEstadoAlumnoPago.SelectedIndex = -1;
        }

        private void AjustarTamanioColumnas()
        {
            // Ajusta el tamaño de las columnas según tus necesidades
            dgvVerAlumnoPago.Columns["Matricula"].Width = 58;
            dgvVerAlumnoPago.Columns["Primer Nombre"].Width = 118;
            dgvVerAlumnoPago.Columns["Segundo Nombre"].Width = 118;
            dgvVerAlumnoPago.Columns["Primer Apellido"].Width = 118;
            dgvVerAlumnoPago.Columns["Segundo Apellido"].Width = 118;
            dgvVerAlumnoPago.Columns["Curso"].Width = 100;
            dgvVerAlumnoPago.Columns["Estado"].Width = 60;
        }

        private void DgvVerAlumnoPago_SelectionChanged(object sender, EventArgs e)
        {
            // Verifica si hay al menos una fila seleccionada
            if (dgvVerAlumnoPago.SelectedRows.Count > 0)
            {
                // Obtiene la fila seleccionada
                DataGridViewRow filaSeleccionada = dgvVerAlumnoPago.SelectedRows[0];

                // Actualiza los labels con la información de la fila seleccionada
                lblMatriculaSeleccionado.Text = filaSeleccionada.Cells["Matricula"].Value.ToString();

                // Combina los valores de las columnas de nombre y apellido
                string nombreCompleto = $"{filaSeleccionada.Cells["Primer Nombre"].Value} {filaSeleccionada.Cells["Segundo Nombre"].Value} {filaSeleccionada.Cells["Primer Apellido"].Value} {filaSeleccionada.Cells["Segundo Apellido"].Value}";
                lblNombreSeleccionado.Text = nombreCompleto.Trim();

                lblCursoAlumnoSeleccionado.Text = filaSeleccionada.Cells["Curso"].Value.ToString();
                lblEstadoAlumnoSeleccionado.Text = filaSeleccionada.Cells["Estado"].Value.ToString();

                // Llena el CheckListBox con las cuotas pendientes del estudiante
                LlenarCheckListBoxCuotasPendientes();
            }
            else
            {
                // Si no hay filas seleccionadas, limpia los labels y el CheckListBox
                LimpiarLabelsSeleccionados();
                LimpiarCheckListBoxCuotasPendientes();
            }
        }

        private void LlenarCheckListBoxCuotasPendientes()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();

                    // Consulta SQL para seleccionar las cuotas pendientes del estudiante
                    string consulta = "SELECT TipoCuota, ValorCuota FROM CuotaPendiente WHERE Id_Estudiante = @idEstudiante";

                    // Crea un SqlCommand para ejecutar la consulta y llenar el SqlDataReader
                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.AddWithValue("@idEstudiante", lblMatriculaSeleccionado.Text);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Limpia los elementos existentes en el CheckListBox
                            clbCuotasPendientes.Items.Clear();

                            // Agrega los tipos de cuotas pendientes al CheckListBox
                            while (reader.Read())
                            {
                                // Concatena TipoCuota y ValorCuota antes de agregar al CheckListBox
                                string itemText = $"{reader["TipoCuota"].ToString()} - {reader["ValorCuota"].ToString()}";
                                clbCuotasPendientes.Items.Add(itemText);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar el CheckListBox de Cuotas Pendientes: " + ex.Message);
            }
        }


        private void LimpiarCheckListBoxCuotasPendientes()
        {
            // Limpia los elementos del CheckListBox
            clbCuotasPendientes.Items.Clear();
        }

        private void LimpiarLabelsSeleccionados()
        {
            // Limpia los labels
            lblMatriculaSeleccionado.Text = string.Empty;
            lblNombreSeleccionado.Text = string.Empty;
            lblCursoAlumnoSeleccionado.Text = string.Empty;
            lblEstadoAlumnoSeleccionado.Text = string.Empty;
        }

        private void btnAgregarPago_Click(object sender, EventArgs e)
        {

            // Verifica si hay al menos una fila seleccionada en clbCuotasPendientes
            if (clbCuotasPendientes.CheckedItems.Count > 0)
            {
                try
                {
                    using (SqlConnection conexion = new SqlConnection(connectionString))
                    {
                        conexion.Open();

                        // Obtén el ID del estudiante desde lblMatriculaSeleccionado
                        string idEstudiante = lblMatriculaSeleccionado.Text;

                        // Obtener Estudiante desde el label
                        string nombreEstudiante = lblNombreSeleccionado.Text;

                        // Inicializa la variable para la suma de valores
                        decimal sumaValores = 0;

                        // Itera a través de los elementos seleccionados en clbCuotasPendientes
                        foreach (string item in clbCuotasPendientes.CheckedItems)
                        {
                            // Divide el texto del elemento para obtener TipoCuota y ValorCuota
                            string[] partes = item.Split('-');
                            string tipoCuota = partes[0].Trim();
                            decimal valorCuota = decimal.Parse(partes[1].Trim());

                            // Suma el ValorCuota al total
                            sumaValores += valorCuota;
                        }

                        // Verifica si ya existe una fila con la misma matrícula en el DataGridView
                        if (YaExisteMatriculaEnDataGridView(idEstudiante))
                        {
                            MessageBox.Show("La matrícula ya está agregada en el DataGridView.");
                        }
                        else
                        {
                            // Muestra la suma en el DataGridView dgvListaPago
                            MostrarSumaEnDataGridView(idEstudiante, nombreEstudiante, sumaValores);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al calcular el total: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No hay cuotas seleccionadas para calcular el total.");
            }

        }

        private void MostrarSumaEnDataGridView(string idEstudiante, string nombreEstudiante, decimal total)
        {
            // Añade una nueva fila al DataGridView con la Matricula y el Total
            dgvListaPago.Rows.Add(idEstudiante, nombreEstudiante, total);
        }

        private bool YaExisteMatriculaEnDataGridView(string matricula)
        {
            // Itera a través de las filas del DataGridView para verificar si ya existe la matrícula
            foreach (DataGridViewRow row in dgvListaPago.Rows)
            {
                if (row.Cells["ColumnMatricula"].Value != null && row.Cells["ColumnMatricula"].Value.ToString() == matricula)
                {
                    return true; // La matrícula ya existe en el DataGridView
                }
            }
            return false; // La matrícula no existe en el DataGridView
        }




        private void DgvListaPago_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // Actualiza el total cuando se agrega una fila
            RecalcularTotal();
        }

        private void DgvListaPago_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            // Actualiza el total cuando se elimina una fila
            RecalcularTotal();
        }

        private void RecalcularTotal()
        {
            totalPago = 0; // Reinicia el total antes de recalcular

            // Itera a través de las filas del DataGridView para sumar los valores de la columna "Valor Cuota"
            foreach (DataGridViewRow row in dgvListaPago.Rows)
            {
                if (row.Cells["ColumnValorCuota"].Value != null)
                {
                    decimal valorCuota = Convert.ToDecimal(row.Cells["ColumnValorCuota"].Value);
                    totalPago += valorCuota;
                }
            }

            // Muestra el total en el texto del botón de pago
            btnPagarAlumno.Text = $"Pagar RD$: {totalPago}";

            // Cambia el color del botón a verde olivo si hay al menos una fila en el DataGridView
            btnPagarAlumno.BackColor = dgvListaPago.Rows.Count > 0 ? Color.OliveDrab : DefaultBackColor;

        }

        
    }
}
