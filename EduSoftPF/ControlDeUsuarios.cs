using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSoftPF
{
    public partial class ControlDeUsuarios : Form
    {
        private SqlConnection conexion = new SqlConnection("SERVER=ASTACIO\\SQLEXPRESS; DATABASE=DBEDUSOFTPF; Integrated Security=True");

        public ControlDeUsuarios()
        {
            InitializeComponent();

        }
        private void ControlDeUsuarios_Load(object sender, EventArgs e)
        {
            // Llama al método para cargar datos al cargar el formulario
            CargarDatosUsuarios();

            // Ajusta el tamaño de las columnas a un tamaño personalizado
            AjustarTamanioColumnas();
        }

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            RegistroUsuario irRegistroUsuario = new RegistroUsuario();
            irRegistroUsuario.ShowDialog();

            // actualiza el DataGridView
            CargarDatosUsuarios();
        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            // Mostrar un mensaje indicando que se requiere intervención del administrador
            MessageBox.Show("Se requiere intervención del Super Administrador para realizar esta acción.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            // Solicitar código de autorización
            string codigoAutorizacion = Prompt.ShowDialog("Ingrese el código de autorización:", "Código de Autorización");

            // Verificar el código de autorización
            if (codigoAutorizacion == "3518")
            {
                // Verificar si hay una fila seleccionada
                if (dgvVerUsuario.SelectedRows.Count > 0)
                {
                    // Obtener el valor de la columna 'ID' de la fila seleccionada
                    int idUsuario = Convert.ToInt32(dgvVerUsuario.SelectedRows[0].Cells["ID"].Value);

                    // Llamar al método para actualizar el estado del usuario a 'NoActivo'
                    ActualizarEstadoUsuario(idUsuario, "NoActivo");

                    // Actualizar el DataGridView
                    CargarDatosUsuarios();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una fila antes de hacer clic en Eliminar.");
                }
            }
            else
            {
                MessageBox.Show("Código de autorización incorrecto. Acción cancelada.");
            }
        }

        // Cuadro de diálogo personalizado para la entrada del código de autorización
        public class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 300,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen,
                    MaximizeBox = false, // Deshabilita el botón de maximizar
                    MinimizeBox = false  // Deshabilita el botón de minimizar
                };

                Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
                TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 200, UseSystemPasswordChar = true };
                Button confirmation = new Button() { Text = "Aceptar", Left = 150, Width = 100, Top = 70, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };

                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }
        }




        // Método para cargar datos en el DataGridView
        private void CargarDatosUsuarios()
        {
            try
            {
                // Abre la conexión
                conexion.Open();

                // Consulta SQL para obtener campos específicos de la tabla Usuario
                string consulta = "SELECT ID_Usuario AS 'ID', NombreUsuario AS 'Nombre', ApellidoUsuario AS 'Apellido', CorreoUsuario AS 'Correo', CelularUsuario AS 'Celular', UsuarioUsuario AS 'Usuario', PermisoUsuario AS 'Permiso', EstadoUsuario AS 'Estado' FROM Usuario";

                // Crea un adaptador de datos y un conjunto de datos
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
                DataSet dataSet = new DataSet();

                // Llena el conjunto de datos con los datos de la tabla
                adaptador.Fill(dataSet, "Usuario");

                // Asigna el conjunto de datos como origen de datos del DataGridView
                dgvVerUsuario.DataSource = dataSet.Tables["Usuario"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
            finally
            {
                // Cierra la conexión
                conexion.Close();
            }
        }

        // Método para ajustar el tamaño de las columnas a un tamaño personalizado
        private void AjustarTamanioColumnas()
        {
            // Establece el tamaño personalizado de cada columna
            dgvVerUsuario.Columns["ID"].Width = 40;
            dgvVerUsuario.Columns["Nombre"].Width = 120;
            dgvVerUsuario.Columns["Apellido"].Width = 120;
            dgvVerUsuario.Columns["Correo"].Width = 191;
            dgvVerUsuario.Columns["Celular"].Width = 90;
            dgvVerUsuario.Columns["Usuario"].Width = 100;
            dgvVerUsuario.Columns["Permiso"].Width = 80;
            dgvVerUsuario.Columns["Estado"].Width = 60;
        }

        // Método para actualizar el estado del usuario
        private void ActualizarEstadoUsuario(int idUsuario, string nuevoEstado)
        {
            try
            {
                // Abre la conexión
                conexion.Open();

                // Consulta SQL para actualizar el estado del usuario
                string consulta = $"UPDATE Usuario SET EstadoUsuario = '{nuevoEstado}' WHERE ID_Usuario = {idUsuario}";

                // Crea un comando SQL
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    // Ejecuta la consulta
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el estado del usuario: " + ex.Message);
            }
            finally
            {
                // Cierra la conexión
                conexion.Close();
            }
        }

        
    }
}
