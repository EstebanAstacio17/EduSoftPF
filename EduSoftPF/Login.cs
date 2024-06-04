using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduSoftPF
{
    public partial class Login : Form
    {
        private SqlConnection conexion = new SqlConnection("SERVER=ASTACIO\\SQLEXPRESS; DATABASE=DBEDUSOFTPF; Integrated Security=True");
        public Login()
        {
            InitializeComponent();

            RedondearFormulario();
        }

        private void btnLoginInicio_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuarioInicio.Text;
            string password = txtPasswordInicio.Text;

            // Verificar si el usuario y la contraseña son válidos en la base de datos
            if (ValidarCredenciales(usuario, password))
            {
                // Verificar si el usuario está activo
                if (UsuarioActivo(usuario))
                {
                    // Obtener el ID del usuario
                    int idUsuario = ObtenerIdUsuario(usuario);

                    // Abrir el formulario de inicio y pasar el ID del usuario
                    Inicio formInicio = new Inicio();
                    formInicio.MostrarIdUsuario(idUsuario.ToString()); // Enviar el ID del usuario al formulario Inicio
                    this.Hide();
                    formInicio.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El usuario no está activo.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Mostrar mensaje de error según la situación
                if (!UsuarioExiste(usuario))
                {
                    MessageBox.Show("El usuario no existe.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("La contraseña es incorrecta.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int ObtenerIdUsuario(string usuario)
        {
            // Obtener el ID del usuario desde la base de datos
            string query = "SELECT ID_Usuario FROM Usuario WHERE UsuarioUsuario = @Usuario";
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                conexion.Open();
                object idUsuario = cmd.ExecuteScalar();
                conexion.Close();

                return (idUsuario != null) ? Convert.ToInt32(idUsuario) : -1;
            }
        }
        private bool UsuarioActivo(string usuario)
        {
            // Verificar si el usuario está activo en la base de datos
            string query = "SELECT EstadoUsuario FROM Usuario WHERE UsuarioUsuario = @Usuario";
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                conexion.Open();
                object estado = cmd.ExecuteScalar();
                conexion.Close();

                // Verificar si el estado es "Activo" (puedes ajustar según la estructura de tu base de datos)
                return estado != null && estado.ToString().Equals("Activo", StringComparison.OrdinalIgnoreCase);
            }
        }

        private bool UsuarioExiste(string usuario)
        {
            // Verificar si el usuario existe en la base de datos
            string query = "SELECT COUNT(*) FROM Usuario WHERE UsuarioUsuario = @Usuario";
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                conexion.Open();
                int count = (int)cmd.ExecuteScalar();
                conexion.Close();
                return count > 0;
            }
        }

        private bool ValidarCredenciales(string usuario, string password)
        {
            // Verificar si las credenciales son válidas
            string query = "SELECT COUNT(*) FROM Usuario WHERE UsuarioUsuario = @Usuario AND PasswordUsuario = @Password";
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@Password", password);
                conexion.Open();
                int count = (int)cmd.ExecuteScalar();
                conexion.Close();
                return count > 0;
            }
        }


        private void txtLimiteUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la longitud del texto es mayor o igual a 20 y si la tecla presionada no es una tecla de control.
            if (txtUsuarioInicio.Text.Length >= 20 && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                // Cancelar la tecla presionada si la longitud ya alcanzó el límite.
                e.Handled = true;
            }
        }

        private void txtLimitePassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la longitud del texto en el TextBox de contraseña es mayor o igual a 20
            // y si la tecla presionada no es una tecla de control.
            if (txtPasswordInicio.Text.Length >= 20 && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                // Cancelar la tecla presionada si la longitud ya alcanzó el límite.
                e.Handled = true;
            }
        }
        private void btnCancelInicio_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario actual
            this.Close();

            // Cerrar la aplicación completa
            Application.Exit();
        }

        private void RedondearFormulario()
        {
            int radio = 10; // Puedes ajustar el radio según tus preferencias

            // Creamos un gráfico con la forma del rectángulo redondeado
            GraphicsPath forma = new GraphicsPath();
            forma.AddArc(0, 0, radio * 2, radio * 2, 180, 90);
            forma.AddArc(this.Width - (radio * 2), 0, radio * 2, radio * 2, 270, 90);
            forma.AddArc(this.Width - (radio * 2), this.Height - (radio * 2), radio * 2, radio * 2, 0, 90);
            forma.AddArc(0, this.Height - (radio * 2), radio * 2, radio * 2, 90, 90);
            this.Region = new Region(forma);
        }

        
    }
}