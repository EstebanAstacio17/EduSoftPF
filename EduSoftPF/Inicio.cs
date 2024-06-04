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
    public partial class Inicio : Form
    {
        // Conexion a Base De Datos
        //private string connectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;

        private SqlConnection conexion = new SqlConnection("SERVER=ASTACIO\\SQLEXPRESS; DATABASE=DBEDUSOFTPF; Integrated Security=True");

        private Timer inactividadTimer;
        private DateTime ultimaActividad;

        public Inicio()
        {
            InitializeComponent();

            // Asocia el evento Load al método Inicio_Load
            this.Load += Inicio_Load;
            ControlDeTiempo();

            // Asocia el evento FormClosed al método MainForm_FormClosed
            this.FormClosed += MainForm_FormClosed;
        }
        private void Inicio_Load(object sender, EventArgs e)
        {
            // Llena los labels con la información del usuario al cargar el formulario
            string idUsuario = lblId.Text;
            CargarInformacionUsuario(idUsuario);
        }

        // Método para recibir y mostrar el ID del usuario
        public void MostrarIdUsuario(string idUsuario)
        {
            lblId.Text = idUsuario;
        }

        private void btnRegistrarEstudiante_Click(object sender, EventArgs e)
        {
            
            RegistroDeEstudiante registroDeEstudiante = new RegistroDeEstudiante();
            registroDeEstudiante.ShowDialog();
        }

        private void btnVistaEstudiante_Click(object sender, EventArgs e)
        {
            VistaDeEstudiantes vistaDeEstudiantes = new VistaDeEstudiantes();
            vistaDeEstudiantes.ShowDialog();
        }

        private void btnControlUsuarios_Click(object sender, EventArgs e)
        {
            // Verifica si el usuario tiene el permiso de Administrador
            if (lblPermisoInicio.Text == "Administrador")
            {
                // El usuario tiene permisos de Administrador, abre el formulario
                ControlDeUsuarios irUsuarios = new ControlDeUsuarios();
                irUsuarios.ShowDialog();
            }
            else
            {
                // El usuario no tiene permisos de Administrador, muestra un mensaje
                MessageBox.Show("Solo los administradores tienen acceso a esta función.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnConfiguracionAcademica_Click(object sender, EventArgs e)
        {

            // Verifica si el usuario tiene el permiso de Administrador
            if (lblPermisoInicio.Text == "Administrador")
            {
                // El usuario tiene permisos de Administrador, abre el formulario
                DatosAcademicos configurarDatosAcademicos = new DatosAcademicos();
                configurarDatosAcademicos.ShowDialog();
            }
            else
            {
                // El usuario no tiene permisos de Administrador, muestra un mensaje
                MessageBox.Show("Solo los administradores tienen acceso a esta función.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void ControlDeTiempo()
        {
            // Inicializa el temporizador y establece el intervalo a 1 minuto (60000 milisegundos)
            inactividadTimer = new Timer();
            inactividadTimer.Interval = 60000; // 1 minuto
            inactividadTimer.Tick += InactividadTimer_Tick;

            // Asocia el evento de actividad del formulario al método Form_Activated
            this.Activated += Form_Activated;

            // Asocia el evento de cierre del formulario al método FormClosed
            this.FormClosed += MainForm_FormClosed;

            // Inicia el temporizador y registra la última actividad
            inactividadTimer.Start();
            ultimaActividad = DateTime.Now;
        }

        private void Form_Activated(object sender, EventArgs e)
        {
            // Se activa cada vez que el formulario recibe el enfoque
            ultimaActividad = DateTime.Now;
        }

        private void InactividadTimer_Tick(object sender, EventArgs e)
        {
            // Comprueba la inactividad cada vez que el temporizador avanza
            TimeSpan tiempoInactivo = DateTime.Now - ultimaActividad;

            // Si han pasado más de 5 minutos, cierra la aplicación
            if (tiempoInactivo.TotalMinutes >= 5)
            {
                // Detiene el temporizador antes de cerrar la aplicación
                inactividadTimer.Stop();

                // Cierra la aplicación
                Application.Exit();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Detiene el temporizador cuando el formulario se cierra
            inactividadTimer.Stop();

            // Cierra la aplicación cuando el formulario se cierra
            Application.Exit();
        }

        private void CargarInformacionUsuario(string idUsuario)
        {
            // Consulta la base de datos para obtener la información del usuario
            string query = "SELECT NombreUsuario, ApellidoUsuario, UsuarioUsuario, PermisoUsuario FROM Usuario WHERE Id_Usuario = @IdUsuario";
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                conexion.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                // Verifica si hay resultados antes de intentar leerlos
                if (reader.Read())
                {
                    // Actualiza los labels con la información del usuario
                    lblNombreInicio.Text = reader["NombreUsuario"].ToString();
                    lblApellidoInicio.Text = reader["ApellidoUsuario"].ToString();
                    lblUsuarioInicio.Text = reader["UsuarioUsuario"].ToString();
                    lblPermisoInicio.Text = reader["PermisoUsuario"].ToString();
                }

                conexion.Close();
            }
        }

        private void btnPagoMatricula_Click(object sender, EventArgs e)
        {
            VentanaDePago irVertanaDePago = new VentanaDePago();
            irVertanaDePago.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Reportes irReportes = new Reportes();
            irReportes.ShowDialog();
        }
    }
}
