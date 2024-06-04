using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Configuration;
using System.Drawing.Drawing2D;
using TextBox = System.Windows.Forms.TextBox;

namespace EduSoftPF
{
    public partial class RegistroUsuario : Form
    {
        // Conexion a Base De Datos
        //private string connectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;

        // Asumiendo que ya tienes una conexión a la base de datos
        private SqlConnection conexion = new SqlConnection("SERVER=ASTACIO\\SQLEXPRESS; DATABASE=DBEDUSOFTPF; Integrated Security=True");

        
        public RegistroUsuario()
        {
            InitializeComponent();

            // Asociar el evento Load del formulario con el método RegistroUsuario_Load
            this.Load += RegistroUsuario_Load;

            CrearUsuario();

            TextBoxesSoloLetras();
            TextBoxesSoloNumeros();

            TextBoxesLimitados(); 

        }


        private void RegistroUsuario_Load(object sender, EventArgs e)
        {
            NoEditarComboBoxes();
 
        }

        private void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            // Validar el formato mínimo de la contraseña
            if (!ValidarFormatoContraseña(txtPasswordUsuario.Text))
            {
                MessageBox.Show("La contraseña debe tener al menos 8 caracteres, incluyendo al menos una letra mayúscula, una letra minúscula, un número y un carácter especial.", "Formato de Contraseña Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Resto del código para guardar el usuario
            GuardarUsuario();
        }

        private void btnActualizarUsuario_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiarUsuario_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnCancelarUsuario_Click(object sender, EventArgs e)
        {
            // Cierra el formulario
            this.Close();
        }

        private bool ValidarFormatoContraseña(string contraseña)
        {
            // La contraseña debe tener al menos 8 caracteres
            if (contraseña.Length < 8)
            {
                return false;
            }

            // Verificar al menos una letra mayúscula, una letra minúscula, un número y un carácter especial
            bool tieneMayuscula = false;
            bool tieneMinuscula = false;
            bool tieneNumero = false;
            bool tieneEspecial = false;

            foreach (char caracter in contraseña)
            {
                if (char.IsUpper(caracter))
                {
                    tieneMayuscula = true;
                }
                else if (char.IsLower(caracter))
                {
                    tieneMinuscula = true;
                }
                else if (char.IsDigit(caracter))
                {
                    tieneNumero = true;
                }
                else if (char.IsSymbol(caracter) || char.IsPunctuation(caracter))
                {
                    tieneEspecial = true;
                }
            }

            // La contraseña debe cumplir con todos los requisitos
            return tieneMayuscula && tieneMinuscula && tieneNumero && tieneEspecial;
        }

        private void TextBoxesLimitados()
        {
            /// Asocia el evento KeyPress de los TextBox con el método TextBoxConLimite_KeyPress
            txtNombreUsuario.KeyPress += TextBoxConLimite_KeyPress;
            txtApellidoUsuario.KeyPress += TextBoxConLimite_KeyPress;
            txtDocumentoUsuario.KeyPress += SoloNumerosConLimite13; // Nuevo método agregado
        }
        private void SoloNumerosConLimite13(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es un número, guion, backspace o flechas
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Left && e.KeyChar != (char)Keys.Right)
            {
                // Si no es un número, guion, backspace o flechas, cancela la entrada
                e.Handled = true;
            }

            // Verifica si la longitud actual del texto más el nuevo carácter excede 13 caracteres
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text.Length >= 13 && e.KeyChar != (char)Keys.Back)
            {
                // Si excede 13 caracteres y no es la tecla de retroceso, cancela la entrada
                e.Handled = true;
            }
        }
        
        private void GuardarUsuario()
        {
            try
            {
                // Verifica si todos los campos están llenos
                if (CamposLlenos())
                {
                    // Abre la conexión
                    conexion.Open();

                    // Verifica si ya existe un usuario con el mismo documento
                    string consultaDocumentoExistente = "SELECT COUNT(*) FROM Usuario WHERE DocumentoIdentidadUsuario = @DocumentoUsuario";
                    using (SqlCommand comandoDocumentoExistente = new SqlCommand(consultaDocumentoExistente, conexion))
                    {
                        comandoDocumentoExistente.Parameters.AddWithValue("@DocumentoUsuario", txtDocumentoUsuario.Text);
                        int countDocumento = (int)comandoDocumentoExistente.ExecuteScalar();

                        if (countDocumento > 0)
                        {
                            MessageBox.Show("Ya existe un usuario con el mismo documento.");
                            return; // No permite la inserción si ya existe el documento
                        }
                    }

                    // Verifica si ya existe un usuario con el mismo nombre de usuario
                    string consultaUsuarioExistente = "SELECT COUNT(*) FROM Usuario WHERE UsuarioUsuario = @UsuarioUsuario";
                    using (SqlCommand comandoUsuarioExistente = new SqlCommand(consultaUsuarioExistente, conexion))
                    {
                        comandoUsuarioExistente.Parameters.AddWithValue("@UsuarioUsuario", txtUsuarioUsuario.Text);
                        int countUsuario = (int)comandoUsuarioExistente.ExecuteScalar();

                        if (countUsuario > 0)
                        {
                            MessageBox.Show("Ya existe un usuario con el mismo nombre de usuario.");
                            return; // No permite la inserción si ya existe el nombre de usuario
                        }
                    }

                    // Prepara la consulta SQL para la inserción
                    string consulta = "INSERT INTO Usuario (NombreUsuario, ApellidoUsuario, DocumentoIdentidadUsuario, CorreoUsuario, CelularUsuario, TelefonoUsuario, SexoUsuario, PasswordUsuario, UsuarioUsuario, PermisoUsuario, EstadoUsuario) " +
                                      "VALUES (@NombreUsuario, @ApellidoUsuario, @DocumentoIdentidadUsuario, @CorreoUsuario, @CelularUsuario, @TelefonoUsuario, @SexoUsuario, @PasswordUsuario, @UsuarioUsuario, @PermisoUsuario, @EstadoUsuario)";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        // Asigna los valores de los TextBox y ComboBox a los parámetros
                        comando.Parameters.AddWithValue("@NombreUsuario", txtNombreUsuario.Text);
                        comando.Parameters.AddWithValue("@ApellidoUsuario", txtApellidoUsuario.Text);
                        comando.Parameters.AddWithValue("@DocumentoIdentidadUsuario", txtDocumentoUsuario.Text);
                        comando.Parameters.AddWithValue("@CorreoUsuario", txtCorreoUsuario.Text);
                        comando.Parameters.AddWithValue("@CelularUsuario", txtCelularUsuario.Text);
                        comando.Parameters.AddWithValue("@TelefonoUsuario", txtTelefonoUsuario.Text);
                        comando.Parameters.AddWithValue("@PasswordUsuario", txtPasswordUsuario.Text);
                        comando.Parameters.AddWithValue("@UsuarioUsuario", txtUsuarioUsuario.Text);
                        comando.Parameters.AddWithValue("@SexoUsuario", cboSexoUsuario.Text);
                        comando.Parameters.AddWithValue("@PermisoUsuario", cboPermisoUsuario.Text);
                        comando.Parameters.AddWithValue("@EstadoUsuario", cboEstadoUsuario.Text);

                        // Ejecuta la consulta
                        comando.ExecuteNonQuery();
                    }

                    MessageBox.Show("Registro guardado con éxito.");

                    // Limpia los campos después de guardar el usuario
                    LimpiarCampos();

                    // Cierra el formulario
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Por favor, complete todos los campos antes de guardar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el registro: " + ex.Message);
            }
            finally
            {
                // Cierra la conexión
                conexion.Close();
            }
        }

        private bool CamposLlenos()
        {
            // Verifica si todos los campos están llenos
            return !string.IsNullOrWhiteSpace(txtNombreUsuario.Text) &&
                   !string.IsNullOrWhiteSpace(txtApellidoUsuario.Text) &&
                   !string.IsNullOrWhiteSpace(txtDocumentoUsuario.Text) &&
                   !string.IsNullOrWhiteSpace(txtCorreoUsuario.Text) &&
                   !string.IsNullOrWhiteSpace(txtCelularUsuario.Text) &&
                   !string.IsNullOrWhiteSpace(txtTelefonoUsuario.Text) &&
                   !string.IsNullOrWhiteSpace(txtPasswordUsuario.Text) &&
                   !string.IsNullOrWhiteSpace(txtUsuarioUsuario.Text) &&
                   cboSexoUsuario.SelectedIndex != -1 &&
                   cboPermisoUsuario.SelectedIndex != -1 &&
                   cboEstadoUsuario.SelectedIndex != -1;
        }

        private void TextBoxesSoloLetras()
        {
            // Asocia el evento KeyPress de los TextBox con el método TextBox_KeyPress
            txtNombreUsuario.KeyPress += SoloLetras_KeyPress;
            txtApellidoUsuario.KeyPress += SoloLetras_KeyPress;
        }
        
        private void TextBoxesSoloNumeros()
        {
            // Asocia el evento KeyPress de los TextBox con el método TextBox_KeyPress
            txtDocumentoUsuario.KeyPress += SoloNumeros_KeyPress;
            txtCelularUsuario.KeyPress += SoloNumerosConLimite;
            txtTelefonoUsuario.KeyPress += SoloNumerosConLimite;
        }

        private void TextBoxConLimite_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la longitud actual del texto más el nuevo carácter excede 30 caracteres y no es la tecla de retroceso
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text.Length >= 30 && e.KeyChar != (char)Keys.Back)
            {
                // Si excede 30 caracteres y no es la tecla de retroceso, cancela la entrada
                e.Handled = true;
            }
        }
        
        private void SoloNumerosConLimite(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es un número o guion
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
            {
                // Si no es un número, guion o tecla de retroceso, cancela la entrada
                e.Handled = true;
            }

            // Verifica si la longitud actual del texto más el nuevo carácter excede 12 caracteres
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text.Length >= 12 && e.KeyChar != (char)Keys.Back)
            {
                // Si excede 12 caracteres y no es la tecla de retroceso, cancela la entrada
                e.Handled = true;
            }
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es un número o guion
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
            {
                // Si no es un número, guion o tecla de retroceso, cancela la entrada
                e.Handled = true;
            }
        }

        private void SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada no es una letra ni espacio ni backspace ni flechas
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Left && e.KeyChar != (char)Keys.Right)
            {
                // Si no es una letra, espacio, backspace o flechas, cancela la entrada
                e.Handled = true;
            }
        }

        private void CrearUsuario()
        {
            // Asocia el evento TextChanged de los TextBox con el método CrearUsuario
            txtNombreUsuario.TextChanged += CrearUsuarioTextChanged;
            txtApellidoUsuario.TextChanged += CrearUsuarioTextChanged;
        }

        private void NoEditarComboBoxes()
        {
            // Configurar ComboBoxes
            cboEstadoUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPermisoUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSexoUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CrearUsuarioTextChanged(object sender, EventArgs e)
        {
            // Toma los dos primeros valores del primer TextBox
            string primerValor = txtNombreUsuario.Text.Length >= 2 ? txtNombreUsuario.Text.Substring(0, 2) : txtNombreUsuario.Text;

            // Toma la primera palabra del segundo TextBox
            string primeraPalabra = txtApellidoUsuario.Text.Split(' ')[0];

            // Une los valores y muestra el resultado en el tercer TextBox
            txtUsuarioUsuario.Text = $"{primerValor}{primeraPalabra}";
        }

        private void LimpiarCampos()
        {
            // Limpia el contenido de todos los TextBox
            txtNombreUsuario.Text = string.Empty;
            txtApellidoUsuario.Text = string.Empty;
            txtDocumentoUsuario.Text = string.Empty;
            txtCorreoUsuario.Text = string.Empty;
            txtCelularUsuario.Text = string.Empty;
            txtTelefonoUsuario.Text = string.Empty;
            txtPasswordUsuario.Text = string.Empty;
            txtUsuarioUsuario.Text = string.Empty;

            // Restablece la selección de los ComboBox
            cboSexoUsuario.SelectedIndex = -1;
            cboPermisoUsuario.SelectedIndex = -1;
            cboEstadoUsuario.SelectedIndex = -1;
        }

    }
}