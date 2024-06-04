namespace EduSoftPF
{
    partial class Login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.ptbLogoInicio = new System.Windows.Forms.PictureBox();
            this.txtPasswordInicio = new System.Windows.Forms.TextBox();
            this.txtUsuarioInicio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoginInicio = new System.Windows.Forms.Button();
            this.btnCancelInicio = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogoInicio)).BeginInit();
            this.SuspendLayout();
            // 
            // ptbLogoInicio
            // 
            this.ptbLogoInicio.Image = ((System.Drawing.Image)(resources.GetObject("ptbLogoInicio.Image")));
            this.ptbLogoInicio.Location = new System.Drawing.Point(89, 34);
            this.ptbLogoInicio.Name = "ptbLogoInicio";
            this.ptbLogoInicio.Size = new System.Drawing.Size(151, 146);
            this.ptbLogoInicio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ptbLogoInicio.TabIndex = 0;
            this.ptbLogoInicio.TabStop = false;
            // 
            // txtPasswordInicio
            // 
            this.txtPasswordInicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPasswordInicio.Location = new System.Drawing.Point(26, 282);
            this.txtPasswordInicio.Name = "txtPasswordInicio";
            this.txtPasswordInicio.PasswordChar = '*';
            this.txtPasswordInicio.Size = new System.Drawing.Size(279, 20);
            this.txtPasswordInicio.TabIndex = 1;
            this.txtPasswordInicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLimitePassword_KeyPress);
            // 
            // txtUsuarioInicio
            // 
            this.txtUsuarioInicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuarioInicio.Location = new System.Drawing.Point(26, 232);
            this.txtUsuarioInicio.Name = "txtUsuarioInicio";
            this.txtUsuarioInicio.Size = new System.Drawing.Size(279, 20);
            this.txtUsuarioInicio.TabIndex = 2;
            this.txtUsuarioInicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLimiteUsuario_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password";
            // 
            // btnLoginInicio
            // 
            this.btnLoginInicio.BackColor = System.Drawing.Color.OliveDrab;
            this.btnLoginInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginInicio.ForeColor = System.Drawing.Color.White;
            this.btnLoginInicio.Location = new System.Drawing.Point(51, 331);
            this.btnLoginInicio.Name = "btnLoginInicio";
            this.btnLoginInicio.Size = new System.Drawing.Size(109, 45);
            this.btnLoginInicio.TabIndex = 6;
            this.btnLoginInicio.Text = "Login";
            this.btnLoginInicio.UseVisualStyleBackColor = false;
            this.btnLoginInicio.Click += new System.EventHandler(this.btnLoginInicio_Click);
            // 
            // btnCancelInicio
            // 
            this.btnCancelInicio.BackColor = System.Drawing.Color.IndianRed;
            this.btnCancelInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelInicio.ForeColor = System.Drawing.Color.White;
            this.btnCancelInicio.Location = new System.Drawing.Point(166, 331);
            this.btnCancelInicio.Name = "btnCancelInicio";
            this.btnCancelInicio.Size = new System.Drawing.Size(109, 45);
            this.btnCancelInicio.TabIndex = 7;
            this.btnCancelInicio.Text = "Cancel";
            this.btnCancelInicio.UseVisualStyleBackColor = false;
            this.btnCancelInicio.Click += new System.EventHandler(this.btnCancelInicio_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(337, 403);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelInicio);
            this.Controls.Add(this.btnLoginInicio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUsuarioInicio);
            this.Controls.Add(this.txtPasswordInicio);
            this.Controls.Add(this.ptbLogoInicio);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Login";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogoInicio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbLogoInicio;
        private System.Windows.Forms.TextBox txtPasswordInicio;
        private System.Windows.Forms.TextBox txtUsuarioInicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoginInicio;
        private System.Windows.Forms.Button btnCancelInicio;
    }
}

