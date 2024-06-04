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
    public partial class FichaDeEstudiante : Form
    {
        private SqlConnection conexion = new SqlConnection("SERVER=ASTACIO\\SQLEXPRESS; DATABASE=DBEDUSOFTPF; Integrated Security=True");

        private string idEstudiante;

        
        public FichaDeEstudiante(string idEstudiante)
        {
            InitializeComponent();

            this.idEstudiante = idEstudiante;

            // Llama a un método para cargar los datos según el ID
            CargarDatosEstudiante();

            CargarDatosActa();

            CargarDatosPadre();

            CargarDatosMadre();

            CargarDatosTutor();

            CargarDatosClinico();

            CargarDatosResponsable();

            // Establece la propiedad ReadOnly de los controles
            SetReadOnlyControls(true);

            // Deshabilita el botón "Actualizar" al cargar el formulario
            btnActualizarFicha.Enabled = false;
        }

        private void btnActualizarFicha_Click(object sender, EventArgs e)
        {
            ActualizarDatosFichaEstudiante();
        }

        private void btnPagoEstudiante_Click(object sender, EventArgs e)
        {
            VentanaDePago irApago = new VentanaDePago();
            irApago.ShowDialog();
        }
        private void btnEditarFicha_Click(object sender, EventArgs e)
        {
            // Al hacer clic en el botón "Editar", permite la edición de los controles
            SetReadOnlyControls(false);

            // Habilita el botón "Actualizar" al presionar el botón "Editar"
            btnActualizarFicha.Enabled = true;

            // Load Cuotas when the form is loaded
            CargarCuotas(); 
            CargarCursos();
        }

        private void CargarDatosEstudiante()
        {
            try
            {
                // Abre la conexión a la base de datos
                conexion.Open();

                // Consulta SQL para obtener los datos del estudiante con el ID proporcionado
                string consultaEstudiante = $"SELECT * FROM Estudiante WHERE Id_Estudiante = {idEstudiante}";
                SqlCommand cmdEstudiante = new SqlCommand(consultaEstudiante, conexion);
                SqlDataReader readerEstudiante = cmdEstudiante.ExecuteReader();

                // Verifica si hay datos y los carga en los campos correspondientes
                if (readerEstudiante.Read())
                {
                    txtPrimerNombreEstudiante.Text = readerEstudiante["PrimerNombreEstudiante"].ToString();
                    txtSegundoNombreEstudiante.Text = readerEstudiante["SegundoNombreEstudiante"].ToString();
                    txtPrimerApellidoEstudiante.Text = readerEstudiante["PrimerApellidoEstudiante"].ToString();
                    txtSegundoApellidoEstudiante.Text = readerEstudiante["SegundoApellidoEstudiante"].ToString();
                    dtpNacimientoEstudiante.Text = readerEstudiante["FechaNacimientoEstudiante"].ToString();
                    cboNacionalidadEstudiante.Text = readerEstudiante["NacionalidadEstudiante"].ToString();
                    cboSexoEstudiante.Text = readerEstudiante["SexoEstudiante"].ToString();
                    txtEdadEstudiante.Text = readerEstudiante["EdadEstudiante"].ToString();
                    cboEstadoEstudiante.Text = readerEstudiante["EstadoEstudiante"].ToString();
                    cboCursoEstudiante.Text = readerEstudiante["CursoEstudiante"].ToString();
                    cboCuotaEstudiante.Text = readerEstudiante["CuotaEstudiante"].ToString();

                }

                // Cierra el lector de datos
                readerEstudiante.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del estudiante: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cierra la conexión a la base de datos
                conexion.Close();
            }

            
        }

        private void CargarDatosActa()
        {

            try
            {
                // Abre la conexión a la base de datos
                conexion.Open();

                // Consulta SQL para obtener los datos del estudiante con el ID proporcionado
                string consultaActa = $"SELECT * FROM Acta WHERE Id_Estudiante = {idEstudiante}";
                SqlCommand cmdActa = new SqlCommand(consultaActa, conexion);
                SqlDataReader readerActa = cmdActa.ExecuteReader();

                // Verifica si hay datos y los carga en los campos correspondientes
                if (readerActa.Read())
                {
                    txtProvinciaActa.Text = readerActa["ProvinciaActa"].ToString();
                    txtMunicipioActa.Text = readerActa["MunicipioActa"].ToString();
                    txtOficialiaActa.Text = readerActa["OficialiaActa"].ToString();
                    txtLibroActa.Text = readerActa["LibroActa"].ToString();
                    txtFolioActa.Text = readerActa["FolioActa"].ToString();
                    txtNoActa.Text = readerActa["NoActa"].ToString();
                    txtAnoActa.Text = readerActa["AnoActa"].ToString();

                }

                // Cierra el lector de datos
                readerActa.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del estudiante: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cierra la conexión a la base de datos
                conexion.Close();
            }

        }

        private void CargarDatosPadre()
        {
            try
            {
                // Abre la conexión a la base de datos
                conexion.Open();

                // Consulta SQL para obtener los datos del padre con el ID proporcionado
                string consultaPadre = $"SELECT * FROM Padre WHERE Id_Estudiante = {idEstudiante}";
                SqlCommand cmdPadre = new SqlCommand(consultaPadre, conexion);
                SqlDataReader readerPadre = cmdPadre.ExecuteReader();

                // Verifica si hay datos y los carga en los campos correspondientes
                if (readerPadre.Read())
                {
                    txtNombrePadre.Text = readerPadre["NombresPadre"].ToString();
                    txtApellidoPadre.Text = readerPadre["ApellidosPadre"].ToString();
                    txtNivelPadre.Text = readerPadre["NivelAcademicoPadre"].ToString();
                    txtDireccionPadre.Text = readerPadre["DireccionPadre"].ToString();
                    txtCedulaPadre.Text = readerPadre["CedulaPadre"].ToString();
                    txtProfesionPadre.Text = readerPadre["ProfesionPadre"].ToString();
                    txtCasaPadre.Text = readerPadre["CasaPadre"].ToString();
                    txtCelularPadre.Text = readerPadre["CelularPadre"].ToString();
                    txtTrabajoPadre.Text = readerPadre["TrabajoPadre"].ToString();
                    txtCorreoPadre.Text = readerPadre["CorreoPadre"].ToString();
                }

                // Cierra el lector de datos
                readerPadre.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del padre: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cierra la conexión a la base de datos
                conexion.Close();
            }
        }

        private void CargarDatosMadre()
        {
            try
            {
                // Abre la conexión a la base de datos
                conexion.Open();

                // Consulta SQL para obtener los datos de la madre con el ID proporcionado
                string consultaMadre = $"SELECT * FROM Madre WHERE Id_Estudiante = {idEstudiante}";
                SqlCommand cmdMadre = new SqlCommand(consultaMadre, conexion);
                SqlDataReader readerMadre = cmdMadre.ExecuteReader();

                // Verifica si hay datos y los carga en los campos correspondientes
                if (readerMadre.Read())
                {
                    txtNombreMadre.Text = readerMadre["NombresMadre"].ToString();
                    txtApellidoMadre.Text = readerMadre["ApellidosMadre"].ToString();
                    txtNivelMadre.Text = readerMadre["NivelAcademicoMadre"].ToString();
                    txtDireccionMadre.Text = readerMadre["DireccionMadre"].ToString();
                    txtCedulaMadre.Text = readerMadre["CedulaMadre"].ToString();
                    txtProfesionMadre.Text = readerMadre["ProfesionMadre"].ToString();
                    txtCasaMadre.Text = readerMadre["CasaMadre"].ToString();
                    txtCelularMadre.Text = readerMadre["CelularMadre"].ToString();
                    txtTrabajoMadre.Text = readerMadre["TrabajoMadre"].ToString();
                    txtCorreoMadre.Text = readerMadre["CorreoMadre"].ToString();
                }

                // Cierra el lector de datos
                readerMadre.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos de la madre: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cierra la conexión a la base de datos
                conexion.Close();
            }
        }

        private void CargarDatosTutor()
        {
            try
            {
                // Abre la conexión a la base de datos
                conexion.Open();

                // Consulta SQL para obtener los datos del tutor con el ID proporcionado
                string consultaTutor = $"SELECT * FROM Tutor WHERE Id_Estudiante = {idEstudiante}";
                SqlCommand cmdTutor = new SqlCommand(consultaTutor, conexion);
                SqlDataReader readerTutor = cmdTutor.ExecuteReader();

                // Verifica si hay datos y los carga en los campos correspondientes
                if (readerTutor.Read())
                {
                    txtNombreTutor.Text = readerTutor["NombresTutor"].ToString();
                    txtApellidoTutor.Text = readerTutor["ApellidosTutor"].ToString();
                    txtNivelTutor.Text = readerTutor["NivelAcademicoTutor"].ToString();
                    txtDireccionTutor.Text = readerTutor["DireccionTutor"].ToString();
                    txtCedulaTutor.Text = readerTutor["CedulaTutor"].ToString();
                    txtProfesionTutor.Text = readerTutor["ProfesionTutor"].ToString();
                    txtCasaTutor.Text = readerTutor["CasaTutor"].ToString();
                    txtCelularTutor.Text = readerTutor["CelularTutor"].ToString();
                    txtTrabajoTutor.Text = readerTutor["TrabajoTutor"].ToString();
                    txtCorreoTutor.Text = readerTutor["CorreoTutor"].ToString();
                }

                // Cierra el lector de datos
                readerTutor.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del tutor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cierra la conexión a la base de datos
                conexion.Close();
            }
        }

        private void CargarDatosClinico()
        {
            try
            {
                // Abre la conexión a la base de datos
                conexion.Open();

                // Consulta SQL para obtener los datos clínicos con el ID proporcionado
                string consultaClinico = $"SELECT * FROM Clinico WHERE Id_Estudiante = {idEstudiante}";
                SqlCommand cmdClinico = new SqlCommand(consultaClinico, conexion);
                SqlDataReader readerClinico = cmdClinico.ExecuteReader();

                // Verifica si hay datos y los carga en los campos correspondientes
                if (readerClinico.Read())
                {
                    cboEnfermedad.Text = readerClinico["Enfermedad"].ToString();
                    rtbDetallarEnfermedad.Text = readerClinico["CualEnfermedad"].ToString();
                    cboAlergia.Text = readerClinico["Alergia"].ToString();
                    rtbDetallarAlergia.Text = readerClinico["CualAlergia"].ToString();
                    cboVacuna.Text = readerClinico["Vacuna"].ToString();
                    rtbDetallarVacuna.Text = readerClinico["CualVacuna"].ToString();
                }

                // Cierra el lector de datos
                readerClinico.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos clínicos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cierra la conexión a la base de datos
                conexion.Close();
            }
        }


        private void CargarDatosResponsable()
        {
            try
            {
                // Abre la conexión a la base de datos
                conexion.Open();

                // Consulta SQL para obtener los datos del responsable con el ID proporcionado
                string consultaResponsable = $"SELECT * FROM Responsable WHERE Id_Estudiante = {idEstudiante}";
                SqlCommand cmdResponsable = new SqlCommand(consultaResponsable, conexion);
                SqlDataReader readerResponsable = cmdResponsable.ExecuteReader();

                // Verifica si hay datos y los carga en los campos correspondientes
                if (readerResponsable.Read())
                {
                    txtNombreResponsable.Text = readerResponsable["NombresResponsable"].ToString();
                    txtApellidoResponsable.Text = readerResponsable["ApellidosResponsable"].ToString();
                    txtNivelResponsable.Text = readerResponsable["NivelAcademicoResponsable"].ToString();
                    txtDireccionResponsable.Text = readerResponsable["DireccionResponsable"].ToString();
                    txtCedulaResponsable.Text = readerResponsable["CedulaResponsable"].ToString();
                    txtProfesionResponsable.Text = readerResponsable["ProfesionResponsable"].ToString();
                    txtCasaResponsable.Text = readerResponsable["CasaResponsable"].ToString();
                    txtCelularResponsable.Text = readerResponsable["CelularResponsable"].ToString();
                    txtTrabajoResponsable.Text = readerResponsable["TrabajoResponsable"].ToString();
                    txtParentescoResponsable.Text = readerResponsable["ParentescoResponsable"].ToString();
                    txtCorreoResponsable.Text = readerResponsable["CorreoResponsable"].ToString();
                }

                // Cierra el lector de datos
                readerResponsable.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del responsable: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cierra la conexión a la base de datos
                conexion.Close();
            }
        }

        // Método para establecer la propiedad ReadOnly de los controles
        private void SetReadOnlyControls(bool readOnly)
        {
            // Datos del estudiante
            txtPrimerNombreEstudiante.ReadOnly = readOnly;
            txtSegundoNombreEstudiante.ReadOnly = readOnly;
            txtPrimerApellidoEstudiante.ReadOnly = readOnly;
            txtSegundoApellidoEstudiante.ReadOnly = readOnly;
            dtpNacimientoEstudiante.Enabled = !readOnly;
            cboNacionalidadEstudiante.Enabled = !readOnly;
            cboSexoEstudiante.Enabled = !readOnly;
            txtEdadEstudiante.ReadOnly = readOnly;
            cboEstadoEstudiante.Enabled = !readOnly;
            cboCursoEstudiante.Enabled = !readOnly;
            cboCuotaEstudiante.Enabled = !readOnly;  

            // Datos del acta
            txtProvinciaActa.ReadOnly = readOnly;
            txtMunicipioActa.ReadOnly = readOnly;
            txtOficialiaActa.ReadOnly = readOnly;
            txtLibroActa.ReadOnly = readOnly;
            txtFolioActa.ReadOnly = readOnly;
            txtNoActa.ReadOnly = readOnly;
            txtAnoActa.ReadOnly = readOnly;

            // Datos del padre
            txtNombrePadre.ReadOnly = readOnly;
            txtApellidoPadre.ReadOnly = readOnly;
            txtNivelPadre.ReadOnly = readOnly;
            txtDireccionPadre.ReadOnly = readOnly;
            txtCedulaPadre.ReadOnly = readOnly;
            txtProfesionPadre.ReadOnly = readOnly;
            txtCasaPadre.ReadOnly = readOnly;
            txtCelularPadre.ReadOnly = readOnly;
            txtTrabajoPadre.ReadOnly = readOnly;
            txtCorreoPadre.ReadOnly = readOnly;


            // Datos de la madre
            txtNombreMadre.ReadOnly = readOnly;
            txtApellidoMadre.ReadOnly = readOnly;
            txtNivelMadre.ReadOnly = readOnly;
            txtDireccionMadre.ReadOnly = readOnly;
            txtCedulaMadre.ReadOnly = readOnly;
            txtProfesionMadre.ReadOnly = readOnly;
            txtCasaMadre.ReadOnly = readOnly;
            txtCelularMadre.ReadOnly = readOnly;
            txtTrabajoMadre.ReadOnly = readOnly;
            txtCorreoMadre.ReadOnly = readOnly;

            // Datos del tutor
            txtNombreTutor.ReadOnly = readOnly;
            txtApellidoTutor.ReadOnly = readOnly;
            txtNivelTutor.ReadOnly = readOnly;
            txtDireccionTutor.ReadOnly = readOnly;
            txtCedulaTutor.ReadOnly = readOnly;
            txtProfesionTutor.ReadOnly = readOnly;
            txtCasaTutor.ReadOnly = readOnly;
            txtCelularTutor.ReadOnly = readOnly;
            txtTrabajoTutor.ReadOnly = readOnly;
            txtCorreoTutor.ReadOnly = readOnly;

            // Datos clínicos
            cboEnfermedad.Enabled = !readOnly;
            cboAlergia.Enabled = !readOnly;
            cboVacuna.Enabled = !readOnly;
            rtbDetallarEnfermedad.ReadOnly = readOnly;
            rtbDetallarAlergia.ReadOnly = readOnly;
            rtbDetallarVacuna.ReadOnly = readOnly;

            // Datos del responsable
            txtNombreResponsable.ReadOnly = readOnly;
            txtApellidoResponsable.ReadOnly = readOnly;
            txtNivelResponsable.ReadOnly = readOnly;
            txtDireccionResponsable.ReadOnly = readOnly;
            txtCedulaResponsable.ReadOnly = readOnly;
            txtProfesionResponsable.ReadOnly = readOnly;
            txtCasaResponsable.ReadOnly = readOnly;
            txtCelularResponsable.ReadOnly = readOnly;
            txtTrabajoResponsable.ReadOnly = readOnly;
            txtParentescoResponsable.ReadOnly = readOnly; 
            txtCorreoResponsable.ReadOnly = readOnly;
        }

        
        private void ActualizarDatosFichaEstudiante()
        {
            try
            {
                // Abre la conexión a la base de datos
                conexion.Open();

                // Iniciar la transacción
                using (SqlTransaction transaction = conexion.BeginTransaction())
                {
                    try
                    {
                        // Actualizar datos del estudiante
                        using (SqlCommand cmdEstudiante = new SqlCommand("UPDATE Estudiante SET PrimerNombreEstudiante = @PrimerNombre, SegundoNombreEstudiante = @SegundoNombre, PrimerApellidoEstudiante = @PrimerApellido, SegundoApellidoEstudiante = @SegundoApellido, FechaNacimientoEstudiante = @FechaNacimiento, NacionalidadEstudiante = @Nacionalidad, SexoEstudiante = @Sexo, EdadEstudiante = @Edad, EstadoEstudiante = @Estado, CursoEstudiante = @Curso, CuotaEstudiante = @Cuota WHERE Id_Estudiante = @IdEstudiante;", conexion, transaction))
                        {
                            cmdEstudiante.Parameters.AddWithValue("@PrimerNombre", txtPrimerNombreEstudiante.Text);
                            cmdEstudiante.Parameters.AddWithValue("@SegundoNombre", txtSegundoNombreEstudiante.Text);
                            cmdEstudiante.Parameters.AddWithValue("@PrimerApellido", txtPrimerApellidoEstudiante.Text);
                            cmdEstudiante.Parameters.AddWithValue("@SegundoApellido", txtSegundoApellidoEstudiante.Text);
                            cmdEstudiante.Parameters.AddWithValue("@FechaNacimiento", dtpNacimientoEstudiante.Value);
                            cmdEstudiante.Parameters.AddWithValue("@Nacionalidad", cboNacionalidadEstudiante.Text);
                            cmdEstudiante.Parameters.AddWithValue("@Sexo", cboSexoEstudiante.Text);
                            cmdEstudiante.Parameters.AddWithValue("@Edad", txtEdadEstudiante.Text);
                            cmdEstudiante.Parameters.AddWithValue("@Estado", cboEstadoEstudiante.Text);
                            cmdEstudiante.Parameters.AddWithValue("@Curso", cboCursoEstudiante.Text);
                            cmdEstudiante.Parameters.AddWithValue("@Cuota", cboCuotaEstudiante.Text);
                            cmdEstudiante.Parameters.AddWithValue("@IdEstudiante", idEstudiante);

                            cmdEstudiante.ExecuteNonQuery();
                        }

                        // Actualizar datos en la tabla Acta (asumiendo que Id_Acta es conocido)
                        using (SqlCommand cmdActa = new SqlCommand("UPDATE Acta SET ProvinciaActa = @ProvinciaActa, MunicipioActa = @MunicipioActa, OficialiaActa = @OficialiaActa, LibroActa = @LibroActa, FolioActa = @FolioActa, NoActa = @NoActa, AnoActa = @AnoActa WHERE Id_Estudiante = @IdEstudiante;", conexion, transaction))
                        {
                            cmdActa.Parameters.AddWithValue("@IdEstudiante", idEstudiante);
                            cmdActa.Parameters.AddWithValue("@ProvinciaActa", txtProvinciaActa.Text);
                            cmdActa.Parameters.AddWithValue("@MunicipioActa", txtMunicipioActa.Text);
                            cmdActa.Parameters.AddWithValue("@OficialiaActa", txtOficialiaActa.Text);
                            cmdActa.Parameters.AddWithValue("@LibroActa", txtLibroActa.Text);
                            cmdActa.Parameters.AddWithValue("@FolioActa", txtFolioActa.Text);
                            cmdActa.Parameters.AddWithValue("@NoActa", txtNoActa.Text);
                            cmdActa.Parameters.AddWithValue("@AnoActa", txtAnoActa.Text);

                            cmdActa.ExecuteNonQuery();
                        }

                        // Actualizar datos en la tabla Padre (asumiendo que Id_Padre es conocido)
                        using (SqlCommand cmdPadre = new SqlCommand("UPDATE Padre SET NombresPadre = @NombresPadre, ApellidosPadre = @ApellidosPadre, NivelAcademicoPadre = @NivelAcademicoPadre, DireccionPadre = @DireccionPadre, CedulaPadre = @CedulaPadre, ProfesionPadre = @ProfesionPadre, CasaPadre = @CasaPadre, CelularPadre = @CelularPadre, TrabajoPadre = @TrabajoPadre, CorreoPadre = @CorreoPadre WHERE Id_Estudiante = @IdEstudiante;", conexion, transaction))
                        {
                            cmdPadre.Parameters.AddWithValue("@IdEstudiante", idEstudiante);
                            cmdPadre.Parameters.AddWithValue("@NombresPadre", txtNombrePadre.Text);
                            cmdPadre.Parameters.AddWithValue("@ApellidosPadre", txtApellidoPadre.Text);
                            cmdPadre.Parameters.AddWithValue("@NivelAcademicoPadre", txtNivelPadre.Text);
                            cmdPadre.Parameters.AddWithValue("@DireccionPadre", txtDireccionPadre.Text);
                            cmdPadre.Parameters.AddWithValue("@CedulaPadre", txtCedulaPadre.Text);
                            cmdPadre.Parameters.AddWithValue("@ProfesionPadre", txtProfesionPadre.Text);
                            cmdPadre.Parameters.AddWithValue("@CasaPadre", txtCasaPadre.Text);
                            cmdPadre.Parameters.AddWithValue("@CelularPadre", txtCelularPadre.Text);
                            cmdPadre.Parameters.AddWithValue("@TrabajoPadre", txtTrabajoPadre.Text);
                            cmdPadre.Parameters.AddWithValue("@CorreoPadre", txtCorreoPadre.Text);

                            cmdPadre.ExecuteNonQuery();
                        }

                        // Actualizar datos en la tabla Madre (asumiendo que Id_Madre es conocido)
                        using (SqlCommand cmdMadre = new SqlCommand("UPDATE Madre SET NombresMadre = @NombresMadre, ApellidosMadre = @ApellidosMadre, NivelAcademicoMadre = @NivelAcademicoMadre, DireccionMadre = @DireccionMadre, CedulaMadre = @CedulaMadre, ProfesionMadre = @ProfesionMadre, CasaMadre = @CasaMadre, CelularMadre = @CelularMadre, TrabajoMadre = @TrabajoMadre, CorreoMadre = @CorreoMadre WHERE Id_Estudiante = @IdEstudiante;", conexion, transaction))
                        {
                            cmdMadre.Parameters.AddWithValue("@IdEstudiante", idEstudiante);
                            cmdMadre.Parameters.AddWithValue("@NombresMadre", txtNombreMadre.Text);
                            cmdMadre.Parameters.AddWithValue("@ApellidosMadre", txtApellidoMadre.Text);
                            cmdMadre.Parameters.AddWithValue("@NivelAcademicoMadre", txtNivelMadre.Text);
                            cmdMadre.Parameters.AddWithValue("@DireccionMadre", txtDireccionMadre.Text);
                            cmdMadre.Parameters.AddWithValue("@CedulaMadre", txtCedulaMadre.Text);
                            cmdMadre.Parameters.AddWithValue("@ProfesionMadre", txtProfesionMadre.Text);
                            cmdMadre.Parameters.AddWithValue("@CasaMadre", txtCasaMadre.Text);
                            cmdMadre.Parameters.AddWithValue("@CelularMadre", txtCelularMadre.Text);
                            cmdMadre.Parameters.AddWithValue("@TrabajoMadre", txtTrabajoMadre.Text);
                            cmdMadre.Parameters.AddWithValue("@CorreoMadre", txtCorreoMadre.Text);

                            cmdMadre.ExecuteNonQuery();
                        }

                        // Actualizar datos en la tabla Tutor (asumiendo que Id_Tutor es conocido)
                        using (SqlCommand cmdTutor = new SqlCommand("UPDATE Tutor SET NombresTutor = @NombresTutor, ApellidosTutor = @ApellidosTutor, NivelAcademicoTutor = @NivelAcademicoTutor, DireccionTutor = @DireccionTutor, CedulaTutor = @CedulaTutor, ProfesionTutor = @ProfesionTutor, CasaTutor = @CasaTutor, CelularTutor = @CelularTutor, TrabajoTutor = @TrabajoTutor, CorreoTutor = @CorreoTutor WHERE Id_Estudiante = @IdEstudiante;", conexion, transaction))
                        {
                            cmdTutor.Parameters.AddWithValue("@IdEstudiante", idEstudiante);
                            cmdTutor.Parameters.AddWithValue("@NombresTutor", txtNombreTutor.Text);
                            cmdTutor.Parameters.AddWithValue("@ApellidosTutor", txtApellidoTutor.Text);
                            cmdTutor.Parameters.AddWithValue("@NivelAcademicoTutor", txtNivelTutor.Text);
                            cmdTutor.Parameters.AddWithValue("@DireccionTutor", txtDireccionTutor.Text);
                            cmdTutor.Parameters.AddWithValue("@CedulaTutor", txtCedulaTutor.Text);
                            cmdTutor.Parameters.AddWithValue("@ProfesionTutor", txtProfesionTutor.Text);
                            cmdTutor.Parameters.AddWithValue("@CasaTutor", txtCasaTutor.Text);
                            cmdTutor.Parameters.AddWithValue("@CelularTutor", txtCelularTutor.Text);
                            cmdTutor.Parameters.AddWithValue("@TrabajoTutor", txtTrabajoTutor.Text);
                            cmdTutor.Parameters.AddWithValue("@CorreoTutor", txtCorreoTutor.Text);

                            cmdTutor.ExecuteNonQuery();
                        }

                        // Actualizar datos en la tabla Clinico (asumiendo que Id_Clinico es conocido)
                        using (SqlCommand cmdClinico = new SqlCommand("UPDATE Clinico SET Enfermedad = @Enfermedad, CualEnfermedad = @DetalleEnfermedad, Alergia = @Alergia, CualAlergia = @DetalleAlergia, Vacuna = @Vacuna, CualVacuna = @DetalleVacuna WHERE Id_Estudiante = @IdEstudiante;", conexion, transaction))
                        {
                            cmdClinico.Parameters.AddWithValue("@IdEstudiante", idEstudiante);
                            cmdClinico.Parameters.AddWithValue("@Enfermedad", cboEnfermedad.Text);
                            cmdClinico.Parameters.AddWithValue("@DetalleEnfermedad", rtbDetallarEnfermedad.Text);
                            cmdClinico.Parameters.AddWithValue("@Alergia", cboAlergia.Text);
                            cmdClinico.Parameters.AddWithValue("@DetalleAlergia", rtbDetallarAlergia.Text);
                            cmdClinico.Parameters.AddWithValue("@Vacuna", txtCedulaResponsable.Text);
                            cmdClinico.Parameters.AddWithValue("@DetalleVacuna", rtbDetallarVacuna.Text);

                            cmdClinico.ExecuteNonQuery();
                        }


                        // Actualizar datos en la tabla Responsable (asumiendo que Id_Responsable es conocido)
                        using (SqlCommand cmdResponsable = new SqlCommand("UPDATE Responsable SET NombresResponsable = @NombresResponsable, ApellidosResponsable = @ApellidosResponsable, NivelAcademicoResponsable = @NivelAcademicoResponsable, DireccionResponsable = @DireccionResponsable, CedulaResponsable = @CedulaResponsable, ProfesionResponsable = @ProfesionResponsable, CasaResponsable = @CasaResponsable, CelularResponsable = @CelularResponsable, TrabajoResponsable = @TrabajoResponsable, ParentescoResponsable = @ParentescoResponsable, CorreoResponsable = @CorreoResponsable WHERE Id_Estudiante = @IdEstudiante;", conexion, transaction))
                        {
                            cmdResponsable.Parameters.AddWithValue("@IdEstudiante", idEstudiante);
                            cmdResponsable.Parameters.AddWithValue("@NombresResponsable", txtNombreResponsable.Text);
                            cmdResponsable.Parameters.AddWithValue("@ApellidosResponsable", txtApellidoResponsable.Text);
                            cmdResponsable.Parameters.AddWithValue("@NivelAcademicoResponsable", txtNivelResponsable.Text);
                            cmdResponsable.Parameters.AddWithValue("@DireccionResponsable", txtDireccionResponsable.Text);
                            cmdResponsable.Parameters.AddWithValue("@CedulaResponsable", txtCedulaResponsable.Text);
                            cmdResponsable.Parameters.AddWithValue("@ProfesionResponsable", txtProfesionResponsable.Text);
                            cmdResponsable.Parameters.AddWithValue("@CasaResponsable", txtCasaResponsable.Text);
                            cmdResponsable.Parameters.AddWithValue("@CelularResponsable", txtCelularResponsable.Text);
                            cmdResponsable.Parameters.AddWithValue("@TrabajoResponsable", txtTrabajoResponsable.Text);
                            cmdResponsable.Parameters.AddWithValue("@ParentescoResponsable", txtParentescoResponsable.Text);
                            cmdResponsable.Parameters.AddWithValue("@CorreoResponsable", txtCorreoResponsable.Text);

                            cmdResponsable.ExecuteNonQuery();
                        }


                        // Confirmar la transacción
                        transaction.Commit();
                        MessageBox.Show("Datos actualizados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Establecer los controles en modo de solo lectura
                        SetReadOnlyControls(true);
                    }
                    catch (Exception ex)
                    {
                        // Deshacer la transacción en caso de error
                        transaction.Rollback();
                        MessageBox.Show($"Error al actualizar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cierra la conexión a la base de datos
                conexion.Close();
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
