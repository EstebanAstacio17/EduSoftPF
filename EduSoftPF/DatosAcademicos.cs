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

namespace EduSoftPF
{
    public partial class DatosAcademicos : Form
    {
        private SqlConnection conexion = new SqlConnection("SERVER=ASTACIO\\SQLEXPRESS; DATABASE=DBEDUSOFTPF; Integrated Security=True");

        public DatosAcademicos()
        {
            InitializeComponent();
        }

        private void DatosAcademicos_Load(object sender, EventArgs e)
        {
            CargarDatosCuota();
            CargarDatosCurso();

            // Adjust column sizes after loading data
            PersonalizarTamanioColumnas(); 
            PersonalizarTamanioColumnasCurso();
        
        }

        private void btnAgregarCuota_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                CrearCuotaNueva();
                LimpiarCampos();
                CargarDatosCuota(); // Refresh the DataGridView after adding a new record
            }
        }

        private void btnEliminarCuota_Click(object sender, EventArgs e)
        {
            EliminarCuotaSeleccionada();
            CargarDatosCuota();
        }
        private void CrearCuotaNueva()
        {
            try
            {
                conexion.Open();

                // Assuming that your table name is 'Cuota'
                string insertQuery = "INSERT INTO Cuota (Cuota, Detalle) VALUES (@cuota, @detalle)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, conexion))
                {
                    // Assuming that you have TextBox controls named txtCuotaAcademica and txtDetalleCuotaAcademica
                    cmd.Parameters.AddWithValue("@cuota", Convert.ToDecimal(txtCuotaAcademica.Text));
                    cmd.Parameters.AddWithValue("@detalle", txtDetalleCuotaAcademica.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Cuota Creada Correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la cuota: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtCuotaAcademica.Text))
            {
                MessageBox.Show("Por favor, ingrese el valor de la cuota académica.");
                return false;
            }

            if (string.IsNullOrEmpty(txtDetalleCuotaAcademica.Text))
            {
                MessageBox.Show("Por favor, ingrese el detalle de la cuota académica.");
                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            txtCuotaAcademica.Text = string.Empty;
            txtDetalleCuotaAcademica.Text = string.Empty;
        }

        private void CargarDatosCuota()
        {
            try
            {
                conexion.Open();

                // Assuming that your DataGridView is named dgvCuotaAcademica
                string selectQuery = "SELECT Cuota, Detalle FROM Cuota";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery, conexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dgvCuotaAcademica.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de la cuota: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void PersonalizarTamanioColumnas()
        {
            // Customize the column sizes as needed
            dgvCuotaAcademica.Columns["Cuota"].Width = 70;
            dgvCuotaAcademica.Columns["Detalle"].Width = 179;
        }

        private void EliminarCuotaSeleccionada()
        {
            if (dgvCuotaAcademica.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar esta cuota?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int Cuota = Convert.ToInt32(dgvCuotaAcademica.SelectedRows[0].Cells["Cuota"].Value);

                    try
                    {
                        conexion.Open();

                        string deleteQuery = "DELETE FROM Cuota WHERE Cuota = @Cuota";
                        using (SqlCommand cmd = new SqlCommand(deleteQuery, conexion))
                        {
                            cmd.Parameters.AddWithValue("@Cuota", Cuota);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Cuota eliminada correctamente");
                        //CargarDatosCuota(); // Refresh the DataGridView after deleting a record
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar la cuota: " + ex.Message);
                    }
                    finally
                    {
                        conexion.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.");
            }
        }




        // DESARROLLO DE CURSOS

        private void btnAgregarCurso_Click(object sender, EventArgs e)
        {
            if (ValidarCamposCurso())
            {
                CrearCursoNuevo();
                LimpiarCamposCursos();
                CargarDatosCurso(); // Refresh the DataGridView after adding a new record
            }
        }

        private void btnEliminarCurso_Click(object sender, EventArgs e)
        {
            EliminarCursoSeleccionado();
            CargarDatosCurso();
        }

        private void CrearCursoNuevo()
        {
            try
            {
                conexion.Open();

                // Assuming that your table name is 'Cuota'
                string insertQuery = "INSERT INTO Curso (Curso, Detalle) VALUES (@Curso, @Detalle)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, conexion))
                {
                    // Assuming that you have TextBox controls named txtCuotaAcademica and txtDetalleCuotaAcademica
                    cmd.Parameters.AddWithValue("@Curso", txtCursoAcadamico.Text);
                    cmd.Parameters.AddWithValue("@Detalle", txtDetalleCursoAcademico.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Curso Creado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el Curso: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        private bool ValidarCamposCurso()
        {
            if (string.IsNullOrEmpty(txtCursoAcadamico.Text))
            {
                MessageBox.Show("Por favor, ingrese el valor de Curso académico.");
                return false;
            }

            if (string.IsNullOrEmpty(txtDetalleCursoAcademico.Text))
            {
                MessageBox.Show("Por favor, ingrese el detalle de Curso académico.");
                return false;
            }

            return true;
        }

        private void LimpiarCamposCursos()
        {
            txtCursoAcadamico.Text = string.Empty;
            txtDetalleCursoAcademico.Text = string.Empty;
        }
        
        private void CargarDatosCurso()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection("SERVER=ASTACIO\\SQLEXPRESS; DATABASE=DBEDUSOFTPF; Integrated Security=True"))
                {
                    conexion.Open();

                    // Assuming that your DataGridView is named dgvCuotaAcademica
                    string selectQuery = "SELECT Curso, Detalle FROM Curso";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery, conexion);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dgvCursoAcademica.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de los Cursos: " + ex.Message);
            }

        }
        
        

        private void PersonalizarTamanioColumnasCurso()
        {
            // Customize the column sizes as needed
            dgvCursoAcademica.Columns["Curso"].Width = 100;
            dgvCursoAcademica.Columns["Detalle"].Width = 149;
        }
        
        private void EliminarCursoSeleccionado()
        {
            if (dgvCursoAcademica.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este Curso?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string Curso = dgvCursoAcademica.SelectedRows[0].Cells["Curso"].Value.ToString();

                    try
                    {
                        using (SqlConnection conexion = new SqlConnection("SERVER=ASTACIO\\SQLEXPRESS; DATABASE=DBEDUSOFTPF; Integrated Security=True"))
                        {
                            conexion.Open();

                            string deleteQuery = "DELETE FROM Curso WHERE Curso = @Curso";
                            using (SqlCommand cmd = new SqlCommand(deleteQuery, conexion))
                            {
                                cmd.Parameters.AddWithValue("@Curso", Curso);
                                cmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Curso eliminado correctamente");
                            CargarDatosCurso(); // Refresh the DataGridView after deleting a record
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el Curso: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.");
            }
        }
        

       

    }
}

