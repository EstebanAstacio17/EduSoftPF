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
using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox;

namespace EduSoftPF
{
    public partial class RegistroDeEstudiante : Form
    {
        private SqlConnection conexion = new SqlConnection("SERVER=ASTACIO\\SQLEXPRESS; DATABASE=DBEDUSOFTPF; Integrated Security=True");
        
        
        public RegistroDeEstudiante()
        {
            InitializeComponent();
        }

        private void RegistroDeEstudiante_Load(object sender, EventArgs e)
        {
            SeleccionSeguraCbo();

            // Load Cuotas when the form is loaded
            CargarCuotas(); 
            CargarCursos();
        }

        private void btnSiguiente2_Click(object sender, EventArgs e)
        {
            // Verificar si todos los controles tienen valores
            if (TodosLosControlesTienenValores(
                txtPrimerNombreEstudiante,
                txtPrimerApellidoEstudiante,
                txtSegundoApellidoEstudiante,
                dtpNacimientoEstudiante,
                cboNacionalidadEstudiante,
                cboSexoEstudiante,
                txtEdadEstudiante,
                cboEstadoEstudiante,
                cboCuotaEstudiante,
                cboCursoEstudiante))
            {
                // Cambiar a la siguiente pestaña
                tabControlRegistroEstudiantes.SelectedTab = tabActa;
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos antes de avanzar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSiguiente3_Click(object sender, EventArgs e)
        {
            // Verificar si todos los TextBox tienen valores
            if (TodosLosTextBoxTienenValores(txtProvinciaActa, txtMunicipioActa, txtOficialiaActa, txtLibroActa, txtFolioActa, txtNoActa, txtAnoActa))
            {
                // Cambiar a la siguiente pestaña
                tabControlRegistroEstudiantes.SelectedTab = tabPadre;
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos antes de avanzar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSiguiente4_Click(object sender, EventArgs e)
        {
            tabControlRegistroEstudiantes.SelectedTab = tabMadre;
        }

        private void btnSiguiente5_Click(object sender, EventArgs e)
        {
            tabControlRegistroEstudiantes.SelectedTab = tabTutor;
        }

        private void btnSiguiente6_Click(object sender, EventArgs e)
        {
            tabControlRegistroEstudiantes.SelectedTab = tabClinico;
        }

        private void btnSiguiente7_Click(object sender, EventArgs e)
        {
            // Verificar si todos los ComboBox tienen valores
            if (TodosLosComboBoxTienenValores(cboEnfermedad, cboAlergia, cboVacuna))
            {
                // Cambiar a la siguiente pestaña
                tabControlRegistroEstudiantes.SelectedTab = tabResponsablePago;
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos antes de avanzar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAtras6_Click(object sender, EventArgs e)
        {
            tabControlRegistroEstudiantes.SelectedTab = tabClinico;
        }

        private void btnAtras5_Click(object sender, EventArgs e)
        {
            tabControlRegistroEstudiantes.SelectedTab = tabTutor;
        }

        private void btnAtras4_Click(object sender, EventArgs e)
        {
            tabControlRegistroEstudiantes.SelectedTab = tabMadre;
        }

        private void btnAtras3_Click(object sender, EventArgs e)
        {
            tabControlRegistroEstudiantes.SelectedTab = tabPadre;
        }

        private void btnAtras2_Click(object sender, EventArgs e)
        {
            tabControlRegistroEstudiantes.SelectedTab = tabActa;

        }

        private void btnAtras1_Click(object sender, EventArgs e)
        {
            tabControlRegistroEstudiantes.SelectedTab = tabEstudiante;
        }


        // Función para verificar si todos los TextBox tienen valores
        private bool TodosLosTextBoxTienenValores(params TextBox[] textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    return false;
                }
            }

            // Todos los TextBox tienen valores
            return true;
        }

        // Función para verificar si todos los controles tienen valores
        private bool TodosLosControlesTienenValores(params Control[] controles)
        {
            foreach (Control control in controles)
            {
                if (control is TextBox textBox && string.IsNullOrEmpty(textBox.Text))
                {
                    return false;
                }
                else if (control is ComboBox comboBox && comboBox.SelectedIndex == -1)
                {
                    return false;
                }
                else if (control is DateTimePicker dateTimePicker && dateTimePicker.Value == DateTimePicker.MinimumDateTime)
                {
                    return false;
                }
            }

            // Todos los controles tienen valores
            return true;
        }

        // Función para verificar si todos los ComboBox tienen valores
        private bool TodosLosComboBoxTienenValores(params ComboBox[] comboBoxes)
        {
            foreach (ComboBox comboBox in comboBoxes)
            {
                if (comboBox.SelectedIndex == -1)
                {
                    return false;
                }
            }

            // Todos los ComboBox tienen valores
            return true;
        }

        private void btnIngresarEstudiante_Click(object sender, EventArgs e)
        {
            if (CamposResponsableLlenos())
            {
                IngresoNuevoEstudiante();
                // Cerrar el formulario después de ejecutar correctamente IngresoNuevoEstudiante
                this.Close();
            }
            else
            {
                MessageBox.Show("Todos los campos del responsable deben estar llenos.", "Campo Vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            LlamarLimpiarCampos();
        }


        private void IngresoNuevoEstudiante()
        {
            // AGREGAR QUERY DE CUOTA
            try
            {
                conexion.Open();

                // Iniciar la transacción
                using (SqlTransaction transaction = conexion.BeginTransaction())
                {
                    try
                    {
                        // Insertar un nuevo estudiante
                        int idEstudiante;
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO Estudiante (PrimerNombreEstudiante, SegundoNombreEstudiante, PrimerApellidoEstudiante, SegundoApellidoEstudiante, FechaNacimientoEstudiante, NacionalidadEstudiante, SexoEstudiante, EdadEstudiante, EstadoEstudiante, CursoEstudiante, CuotaEstudiante) VALUES (@PrimerNombre, @SegundoNombre, @PrimerApellido, @SegundoApellido, @FechaNacimiento, @Nacionalidad, @Sexo, @Edad, @Estado, @Curso, @Cuota); SELECT SCOPE_IDENTITY();", conexion, transaction))
                        {
                            cmd.Parameters.AddWithValue("@PrimerNombre", txtPrimerNombreEstudiante.Text);
                            cmd.Parameters.AddWithValue("@SegundoNombre", txtSegundoNombreEstudiante.Text);
                            cmd.Parameters.AddWithValue("@PrimerApellido", txtPrimerApellidoEstudiante.Text);
                            cmd.Parameters.AddWithValue("@SegundoApellido", txtSegundoApellidoEstudiante.Text);
                            cmd.Parameters.AddWithValue("@FechaNacimiento", dtpNacimientoEstudiante.Text);
                            cmd.Parameters.AddWithValue("@Nacionalidad", cboNacionalidadEstudiante.Text);
                            cmd.Parameters.AddWithValue("@Sexo", cboSexoEstudiante.Text);
                            cmd.Parameters.AddWithValue("@Edad", txtEdadEstudiante.Text);
                            cmd.Parameters.AddWithValue("@Estado", cboEstadoEstudiante.Text);
                            cmd.Parameters.AddWithValue("@Curso", cboCursoEstudiante.Text);
                            cmd.Parameters.AddWithValue("@Cuota", cboCuotaEstudiante.Text);

                            idEstudiante = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // Insertar datos en la tabla Acta
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO Acta (Id_Estudiante, ProvinciaActa, MunicipioActa, OficialiaActa, LibroActa, FolioActa, NoActa, AnoActa) VALUES (@IdEstudiante, @ProvinciaActa, @MunicipioActa, @OficialiaActa, @LibroActa, @FolioActa, @NoActa, @AnoActa);", conexion, transaction))
                        {
                            cmd.Parameters.AddWithValue("@IdEstudiante", idEstudiante);
                            cmd.Parameters.AddWithValue("@ProvinciaActa", txtProvinciaActa.Text);
                            cmd.Parameters.AddWithValue("@MunicipioActa", txtMunicipioActa.Text);
                            cmd.Parameters.AddWithValue("@OficialiaActa", txtOficialiaActa.Text);
                            cmd.Parameters.AddWithValue("@LibroActa", txtLibroActa.Text);
                            cmd.Parameters.AddWithValue("@FolioActa", txtFolioActa.Text);
                            cmd.Parameters.AddWithValue("@NoActa", txtNoActa.Text);
                            cmd.Parameters.AddWithValue("@AnoActa", txtAnoActa.Text);

                            cmd.ExecuteNonQuery();
                        }

                        // Insertar datos en la tabla Padre
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO Padre (Id_Estudiante, NombresPadre, ApellidosPadre, NivelAcademicoPadre, DireccionPadre, CedulaPadre, ProfesionPadre, CasaPadre, CelularPadre, TrabajoPadre, CorreoPadre) VALUES (@IdEstudiante, @NombresPadre, @ApellidosPadre, @NivelAcademicoPadre, @DireccionPadre, @CedulaPadre, @ProfesionPadre, @CasaPadre, @CelularPadre, @TrabajoPadre, @CorreoPadre);", conexion, transaction))
                        {
                            cmd.Parameters.AddWithValue("@IdEstudiante", idEstudiante);
                            cmd.Parameters.AddWithValue("@NombresPadre", txtNombrePadre.Text);
                            cmd.Parameters.AddWithValue("@ApellidosPadre", txtApellidoPadre.Text);
                            cmd.Parameters.AddWithValue("@NivelAcademicoPadre", txtNivelPadre.Text);
                            cmd.Parameters.AddWithValue("@DireccionPadre", txtDireccionPadre.Text);
                            cmd.Parameters.AddWithValue("@CedulaPadre", txtCedulaPadre.Text);
                            cmd.Parameters.AddWithValue("@ProfesionPadre", txtProfesionPadre.Text);
                            cmd.Parameters.AddWithValue("@CasaPadre", txtCasaPadre.Text);
                            cmd.Parameters.AddWithValue("@CelularPadre", txtCelularPadre.Text);
                            cmd.Parameters.AddWithValue("@TrabajoPadre", txtTrabajoPadre.Text);
                            cmd.Parameters.AddWithValue("@CorreoPadre", txtCorreoPadre.Text);

                            cmd.ExecuteNonQuery();
                        }

                        // Insertar datos en la tabla Madre
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO Madre (Id_Estudiante, NombresMadre, ApellidosMadre, NivelAcademicoMadre, DireccionMadre, CedulaMadre, ProfesionMadre, CasaMadre, CelularMadre, TrabajoMadre, CorreoMadre) VALUES (@IdEstudiante, @NombresMadre, @ApellidosMadre, @NivelAcademicoMadre, @DireccionMadre, @CedulaMadre, @ProfesionMadre, @CasaMadre, @CelularMadre, @TrabajoMadre, @CorreoMadre);", conexion, transaction))
                        {
                            cmd.Parameters.AddWithValue("@IdEstudiante", idEstudiante);
                            cmd.Parameters.AddWithValue("@NombresMadre", txtNombreMadre.Text);
                            cmd.Parameters.AddWithValue("@ApellidosMadre", txtApellidoMadre.Text);
                            cmd.Parameters.AddWithValue("@NivelAcademicoMadre", txtNivelMadre.Text);
                            cmd.Parameters.AddWithValue("@DireccionMadre", txtDireccionMadre.Text);
                            cmd.Parameters.AddWithValue("@CedulaMadre", txtCedulaMadre.Text);
                            cmd.Parameters.AddWithValue("@ProfesionMadre", txtProfesionMadre.Text);
                            cmd.Parameters.AddWithValue("@CasaMadre", txtCasaMadre.Text);
                            cmd.Parameters.AddWithValue("@CelularMadre", txtCelularMadre.Text);
                            cmd.Parameters.AddWithValue("@TrabajoMadre", txtTrabajoMadre.Text);
                            cmd.Parameters.AddWithValue("@CorreoMadre", txtCorreoMadre.Text);

                            cmd.ExecuteNonQuery();
                        }

                        // Insertar datos en la tabla Tutor
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO Tutor (Id_Estudiante, NombresTutor, ApellidosTutor, NivelAcademicoTutor, DireccionTutor, CedulaTutor, ProfesionTutor, CasaTutor, CelularTutor, TrabajoTutor, CorreoTutor) VALUES (@IdEstudiante, @NombresTutor, @ApellidosTutor, @NivelAcademicoTutor, @DireccionTutor, @CedulaTutor, @ProfesionTutor, @CasaTutor, @CelularTutor, @TrabajoTutor, @CorreoTutor);", conexion, transaction))
                        {
                            cmd.Parameters.AddWithValue("@IdEstudiante", idEstudiante);
                            cmd.Parameters.AddWithValue("@NombresTutor", txtNombreTutor.Text);
                            cmd.Parameters.AddWithValue("@ApellidosTutor", txtApellidoTutor.Text);
                            cmd.Parameters.AddWithValue("@NivelAcademicoTutor", txtNivelTutor.Text);
                            cmd.Parameters.AddWithValue("@DireccionTutor", txtDireccionTutor.Text);
                            cmd.Parameters.AddWithValue("@CedulaTutor", txtCedulaTutor.Text);
                            cmd.Parameters.AddWithValue("@ProfesionTutor", txtProfesionTutor.Text);
                            cmd.Parameters.AddWithValue("@CasaTutor", txtCasaTutor.Text);
                            cmd.Parameters.AddWithValue("@CelularTutor", txtCelularTutor.Text);
                            cmd.Parameters.AddWithValue("@TrabajoTutor", txtTrabajoTutor.Text);
                            cmd.Parameters.AddWithValue("@CorreoTutor", txtCorreoTutor.Text);

                            cmd.ExecuteNonQuery();
                        }

                        // Insertar datos en la tabla Clinico
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO Clinico (Id_Estudiante, Enfermedad, CualEnfermedad, Alergia, CualAlergia, Vacuna, CualVacuna) VALUES (@IdEstudiante, @Enfermedad, @DetalleEnfermedad, @Alergia, @DetalleAlergia, @Vacuna, @DetalleVacuna);", conexion, transaction))
                        {
                            cmd.Parameters.AddWithValue("@IdEstudiante", idEstudiante);
                            cmd.Parameters.AddWithValue("@Enfermedad", cboEnfermedad.Text);
                            cmd.Parameters.AddWithValue("@DetalleEnfermedad", rtbDetallarEnfermedad.Text);
                            cmd.Parameters.AddWithValue("@Alergia", cboAlergia.Text);
                            cmd.Parameters.AddWithValue("@DetalleAlergia", rtbDetallarAlergia.Text);
                            cmd.Parameters.AddWithValue("@Vacuna", txtCedulaResponsable.Text);
                            cmd.Parameters.AddWithValue("@DetalleVacuna", rtbDetallarVacuna.Text);

                            cmd.ExecuteNonQuery();
                        }

                        // Insertar datos en la tabla Responsable
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO Responsable (Id_Estudiante, NombresResponsable, ApellidosResponsable, NivelAcademicoResponsable, DireccionResponsable, CedulaResponsable, ProfesionResponsable, CasaResponsable, CelularResponsable, TrabajoResponsable, ParentescoResponsable, CorreoResponsable) VALUES (@IdEstudiante, @NombresResponsable, @ApellidosResponsable, @NivelAcademicoResponsable, @DireccionResponsable, @CedulaResponsable, @ProfesionResponsable, @CasaResponsable, @CelularResponsable, @TrabajoResponsable, @ParentescoResponsable, @CorreoResponsable);", conexion, transaction))
                        {
                            cmd.Parameters.AddWithValue("@IdEstudiante", idEstudiante);
                            cmd.Parameters.AddWithValue("@NombresResponsable", txtNombreResponsable.Text);
                            cmd.Parameters.AddWithValue("@ApellidosResponsable", txtApellidoResponsable.Text);
                            cmd.Parameters.AddWithValue("@NivelAcademicoResponsable", txtNivelResponsable.Text);
                            cmd.Parameters.AddWithValue("@DireccionResponsable", txtDireccionResponsable.Text);
                            cmd.Parameters.AddWithValue("@CedulaResponsable", txtCedulaResponsable.Text);
                            cmd.Parameters.AddWithValue("@ProfesionResponsable", txtProfesionResponsable.Text);
                            cmd.Parameters.AddWithValue("@CasaResponsable", txtCasaResponsable.Text);
                            cmd.Parameters.AddWithValue("@CelularResponsable", txtCelularResponsable.Text);
                            cmd.Parameters.AddWithValue("@TrabajoResponsable", txtTrabajoResponsable.Text);
                            cmd.Parameters.AddWithValue("@ParentescoResponsable", txtParentescoResponsable.Text);
                            cmd.Parameters.AddWithValue("@CorreoResponsable", txtCorreoResponsable.Text);

                            cmd.ExecuteNonQuery();
                        }


                        // Confirmar la transacción
                        transaction.Commit();
                        MessageBox.Show("Datos guardados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LlamarLimpiarCampos();
                    }
                    catch (Exception ex)
                    {
                        // Deshacer la transacción en caso de error
                        transaction.Rollback();
                        MessageBox.Show($"Error al guardar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }

        }
        
        private void SeleccionSeguraCbo()
        {
            // Configura los ComboBoxes específicos
            cboNacionalidadEstudiante.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSexoEstudiante.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstadoEstudiante.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCursoEstudiante.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCuotaEstudiante.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEnfermedad.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAlergia.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVacuna.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        private bool CamposResponsableLlenos()
        {
            // Verifica si todos los campos requeridos del responsable están llenos
            if (string.IsNullOrWhiteSpace(txtNombreResponsable.Text) ||
                string.IsNullOrWhiteSpace(txtApellidoResponsable.Text) ||
                string.IsNullOrWhiteSpace(txtNivelResponsable.Text) ||
                string.IsNullOrWhiteSpace(txtDireccionResponsable.Text) ||
                string.IsNullOrWhiteSpace(txtCedulaResponsable.Text) ||
                string.IsNullOrWhiteSpace(txtProfesionResponsable.Text) ||
                string.IsNullOrWhiteSpace(txtCasaResponsable.Text) ||
                string.IsNullOrWhiteSpace(txtCelularResponsable.Text) ||
                string.IsNullOrWhiteSpace(txtTrabajoResponsable.Text) ||
                string.IsNullOrWhiteSpace(txtParentescoResponsable.Text) ||
                string.IsNullOrWhiteSpace(txtCorreoResponsable.Text))
            {
                return false; // Al menos un campo está vacío
            }

            return true; // Todos los campos están llenos
        }

        private void LlamarLimpiarCampos()
        {
            LimpiarCampos(
        txtPrimerNombreEstudiante, txtPrimerApellidoEstudiante, txtSegundoApellidoEstudiante,
        dtpNacimientoEstudiante, cboNacionalidadEstudiante, cboSexoEstudiante,
        txtEdadEstudiante, cboEstadoEstudiante, cboCursoEstudiante,cboCuotaEstudiante,
        txtProvinciaActa, txtMunicipioActa, txtOficialiaActa, txtLibroActa,
        txtFolioActa, txtNoActa, txtAnoActa,
        txtNombrePadre, txtApellidoPadre, txtNivelPadre, txtDireccionPadre,
        txtCedulaPadre, txtProfesionPadre, txtCasaPadre, txtCelularPadre,
        txtTrabajoPadre, txtCorreoPadre,
        txtNombreMadre, txtApellidoMadre, txtNivelMadre, txtDireccionMadre,
        txtCedulaMadre, txtProfesionMadre, txtCasaMadre, txtCelularMadre,
        txtTrabajoMadre, txtCorreoMadre,
        txtNombreTutor, txtApellidoTutor, txtNivelTutor, txtDireccionTutor,
        txtCedulaTutor, txtProfesionTutor, txtCasaTutor, txtCelularTutor,
        txtTrabajoTutor, txtCorreoTutor,
        cboEnfermedad, cboAlergia, cboVacuna,
        rtbDetallarEnfermedad, rtbDetallarAlergia,
        txtCedulaResponsable, rtbDetallarVacuna,
        txtNombreResponsable, txtApellidoResponsable, txtNivelResponsable,
        txtDireccionResponsable, txtCedulaResponsable, txtProfesionResponsable,
        txtCasaResponsable, txtCelularResponsable, txtTrabajoResponsable,
        txtParentescoResponsable, txtCorreoResponsable);
        }

        // Función para limpiar los campos
        private void LimpiarCampos(params Control[] controles)
        {
            foreach (Control control in controles)
            {
                if (control is TextBox textBox)
                {
                    textBox.Text = string.Empty;
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.SelectedIndex = -1;
                }
                else if (control is DateTimePicker dateTimePicker)
                {
                    dateTimePicker.Value = DateTimePicker.MinimumDateTime;
                }
                else if (control is RichTextBox richTextBox)
                {
                    richTextBox.Text = string.Empty;
                }
            }
        }

        private void CargarCuotas()
        {
            try
            {
                conexion.Open();

                string selectQuery = "SELECT Cuota FROM Cuota";
                SqlCommand cmd = new SqlCommand(selectQuery, conexion);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cboCuotaEstudiante.Items.Add(reader["Cuota"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las cuotas: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void CargarCursos()
        {
            try
            {
                conexion.Open();

                string selectQuery = "SELECT Curso FROM Curso";
                SqlCommand cmd = new SqlCommand(selectQuery, conexion);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cboCursoEstudiante.Items.Add(reader["Curso"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los Cursos: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

    }
}
