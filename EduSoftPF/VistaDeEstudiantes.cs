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
    public partial class VistaDeEstudiantes : Form
    {
        private SqlConnection conexion = new SqlConnection("SERVER=ASTACIO\\SQLEXPRESS; DATABASE=DBEDUSOFTPF; Integrated Security=True");

        private DataTable dataTableEstudiantes; // Declara un DataTable a nivel de clase

        public VistaDeEstudiantes()
        {
            InitializeComponent();

            // Asigna el evento Load para inicializar los ComboBox
            this.Load += VistaDeEstudiantes_Load;

            btnLimpiarVistaEstudiante.Click += btnLimpiarVistaEstudiante_Click;

        }

        private void VistaDeEstudiantes_Load(object sender, EventArgs e)
        {
            CargarDatosEstudiantes();
            CargarGradosEnComboBox(); // Nueva función para cargar datos al ComboBox


            AjustarTamanioColumnas();

            NoEditarCBO();

            LabelsVacios();

        }

        private void btnBuscarVistaEstudiante_Click(object sender, EventArgs e)
        {
            LlamarBusqueda();
        }

        private void btnLimpiarVistaEstudiante_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }

        private void CargarDatosEstudiantes()
        {
            try
            {
                conexion.Open();

                // Consulta SQL para obtener los datos necesarios de la tabla Estudiante
                string consulta = "SELECT Id_Estudiante AS 'Matricula', PrimerNombreEstudiante AS 'Primer Nombre', SegundoNombreEstudiante AS 'Segundo Nombre', PrimerApellidoEstudiante AS 'Primer Apellido', SegundoApellidoEstudiante AS 'Segundo Apellido', CursoEstudiante AS 'Grado', EstadoEstudiante AS 'Estado' FROM Estudiante";

                using (SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion))
                {
                    dataTableEstudiantes = new DataTable(); // Inicializa el DataTable
                    adapter.Fill(dataTableEstudiantes);

                    // Asigna el DataTable como origen de datos para el DataGridView
                    dgvVistaEstudiante.DataSource = dataTableEstudiantes;
                }

                // Agregar el evento SelectionChanged al DataGridView
                dgvVistaEstudiante.SelectionChanged += dgvVistaEstudiante_SelectionChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }

        }

        private void AjustarTamanioColumnas()
        {
            // Establece el tamaño personalizado de cada columna
            dgvVistaEstudiante.Columns["Matricula"].Width = 60;
            dgvVistaEstudiante.Columns["Primer Nombre"].Width = 120;
            dgvVistaEstudiante.Columns["Segundo Nombre"].Width = 120;
            dgvVistaEstudiante.Columns["Primer Apellido"].Width = 120;
            dgvVistaEstudiante.Columns["Segundo Apellido"].Width = 120;
            dgvVistaEstudiante.Columns["Grado"].Width = 90;
            dgvVistaEstudiante.Columns["Estado"].Width = 70;
        }
       
        private void dgvVistaEstudiante_SelectionChanged(object sender, EventArgs e)
        {
            // Verificar si hay al menos una fila seleccionada
            if (dgvVistaEstudiante.SelectedRows.Count > 0)
            {
                // Obtener los valores de las celdas seleccionadas
                string primerNombre = dgvVistaEstudiante.SelectedRows[0].Cells["Primer Nombre"].Value.ToString();
                string segundoNombre = dgvVistaEstudiante.SelectedRows[0].Cells["Segundo Nombre"].Value.ToString();
                string primerApellido = dgvVistaEstudiante.SelectedRows[0].Cells["Primer Apellido"].Value.ToString();
                string segundoApellido = dgvVistaEstudiante.SelectedRows[0].Cells["Segundo Apellido"].Value.ToString();
                string grado = dgvVistaEstudiante.SelectedRows[0].Cells["Grado"].Value.ToString();
                string estado = dgvVistaEstudiante.SelectedRows[0].Cells["Estado"].Value.ToString();

                // Actualizar los Labels con la información
                lblNombreEstudiante.Text = $"{primerNombre} {segundoNombre} {primerApellido} {segundoApellido}";
                lblGradoEstudiante.Text = $"Grado: {grado}";
                lblEstadoEstudiante.Text = $"Estado: {estado}";
            }
        }

        private void NoEditarCBO()
        {
            // Asigna el evento para impedir la edición en los ComboBox
            cboGradoVistaEstudiante.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstadoVistaEstudiante.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LabelsVacios()
        {
            // Limpia los labels al cargar el formulario
            lblNombreEstudiante.Text = string.Empty;
            lblGradoEstudiante.Text = string.Empty;
            lblEstadoEstudiante.Text = string.Empty;
        }

        
        private void LlamarBusqueda()
        {

            if (string.IsNullOrEmpty(txtBusquedaVistaEstudiante.Text) && cboGradoVistaEstudiante.SelectedItem == null)
            {
                // Si tanto el cuadro de búsqueda como el ComboBox están vacíos,
                // filtra por el valor seleccionado en el ComboBox de Estado (cboEstadoVistaEstudiante)
                if (cboEstadoVistaEstudiante.SelectedItem != null)
                {
                    string estadoFiltrar = cboEstadoVistaEstudiante.SelectedItem.ToString();
                    DataView dv = new DataView(dataTableEstudiantes);

                    if (estadoFiltrar == "Activo")
                    {
                        // Filtra solo los estudiantes con EstadoEstudiante igual a "Activo"
                        dv.RowFilter = "[Estado] = 'Activo'";
                    }
                    else if (estadoFiltrar == "Retirado")
                    {
                        // Filtra solo los estudiantes con EstadoEstudiante diferente de "Activo"
                        dv.RowFilter = "[Estado] <> 'Activo'";
                    }

                    // Actualiza el origen de datos del DataGridView con las filas filtradas
                    dgvVistaEstudiante.DataSource = dv.ToTable();
                }
                else
                {
                    // Si cboEstadoVistaEstudiante también está vacío, muestra todos los registros
                    dgvVistaEstudiante.DataSource = dataTableEstudiantes;
                }
            }
            else
            {
                // Realiza la búsqueda combinada por Primer Nombre, Segundo Nombre, Primer Apellido,
                // Segundo Apellido, Grado, y Estado utilizando el valor de txtBusquedaVistaEstudiante
                DataView dv = new DataView(dataTableEstudiantes);
                dv.RowFilter = $"[Primer Nombre] LIKE '%{txtBusquedaVistaEstudiante.Text}%' OR [Segundo Nombre] LIKE '%{txtBusquedaVistaEstudiante.Text}%' OR [Primer Apellido] LIKE '%{txtBusquedaVistaEstudiante.Text}%' OR [Segundo Apellido] LIKE '%{txtBusquedaVistaEstudiante.Text}%' OR [Grado] LIKE '%{txtBusquedaVistaEstudiante.Text}%' OR [Estado] LIKE '%{txtBusquedaVistaEstudiante.Text}%'";

                // Actualiza el origen de datos del DataGridView con las filas filtradas
                dgvVistaEstudiante.DataSource = dv.ToTable();
            }
        }

        private void dgvVistaEstudiante_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtiene el valor de la columna "Matricula" (ID)
                string idEstudiante = dgvVistaEstudiante.Rows[e.RowIndex].Cells["Matricula"].Value.ToString();

                // Abre el formulario de Registro de Estudiantes
                FichaDeEstudiante registroForm = new FichaDeEstudiante(idEstudiante);
                registroForm.ShowDialog();
            }
        }

        private void CargarGradosEnComboBox()
        {
            try
            {
                conexion.Open();

                // Consulta SQL para obtener los datos necesarios de la tabla Curso
                string consulta = "SELECT DISTINCT Curso FROM Curso";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Limpiar items existentes en el ComboBox
                        cboGradoVistaEstudiante.Items.Clear();

                        // Agregar los grados al ComboBox
                        while (reader.Read())
                        {
                            cboGradoVistaEstudiante.Items.Add(reader["Curso"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los grados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void LimpiarFiltros()
        {
            txtBusquedaVistaEstudiante.Text = string.Empty;
            cboGradoVistaEstudiante.SelectedIndex = -1;
            cboEstadoVistaEstudiante.SelectedIndex = -1;

            // Restaurar el DataGridView con todos los datos
            dgvVistaEstudiante.DataSource = dataTableEstudiantes;

            // Limpiar las etiquetas
            LabelsVacios();
        }

    }
}