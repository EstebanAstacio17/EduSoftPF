namespace EduSoftPF
{
    partial class VistaDeEstudiantes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboGradoVistaEstudiante = new System.Windows.Forms.ComboBox();
            this.cboEstadoVistaEstudiante = new System.Windows.Forms.ComboBox();
            this.txtBusquedaVistaEstudiante = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBuscarVistaEstudiante = new System.Windows.Forms.Button();
            this.dgvVistaEstudiante = new System.Windows.Forms.DataGridView();
            this.lblNombreEstudiante = new System.Windows.Forms.Label();
            this.lblGradoEstudiante = new System.Windows.Forms.Label();
            this.lblEstadoEstudiante = new System.Windows.Forms.Label();
            this.btnLimpiarVistaEstudiante = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVistaEstudiante)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(270, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Grado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(514, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Estado";
            // 
            // cboGradoVistaEstudiante
            // 
            this.cboGradoVistaEstudiante.FormattingEnabled = true;
            this.cboGradoVistaEstudiante.Location = new System.Drawing.Point(312, 39);
            this.cboGradoVistaEstudiante.Name = "cboGradoVistaEstudiante";
            this.cboGradoVistaEstudiante.Size = new System.Drawing.Size(188, 21);
            this.cboGradoVistaEstudiante.TabIndex = 2;
            // 
            // cboEstadoVistaEstudiante
            // 
            this.cboEstadoVistaEstudiante.FormattingEnabled = true;
            this.cboEstadoVistaEstudiante.Items.AddRange(new object[] {
            "Activo",
            "Retirado",
            "Todos"});
            this.cboEstadoVistaEstudiante.Location = new System.Drawing.Point(560, 39);
            this.cboEstadoVistaEstudiante.Name = "cboEstadoVistaEstudiante";
            this.cboEstadoVistaEstudiante.Size = new System.Drawing.Size(133, 21);
            this.cboEstadoVistaEstudiante.TabIndex = 3;
            // 
            // txtBusquedaVistaEstudiante
            // 
            this.txtBusquedaVistaEstudiante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBusquedaVistaEstudiante.Location = new System.Drawing.Point(24, 39);
            this.txtBusquedaVistaEstudiante.Name = "txtBusquedaVistaEstudiante";
            this.txtBusquedaVistaEstudiante.Size = new System.Drawing.Size(234, 20);
            this.txtBusquedaVistaEstudiante.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(34, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Vista De Estudiante";
            // 
            // btnBuscarVistaEstudiante
            // 
            this.btnBuscarVistaEstudiante.BackColor = System.Drawing.Color.SteelBlue;
            this.btnBuscarVistaEstudiante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarVistaEstudiante.ForeColor = System.Drawing.Color.White;
            this.btnBuscarVistaEstudiante.Location = new System.Drawing.Point(699, 29);
            this.btnBuscarVistaEstudiante.Name = "btnBuscarVistaEstudiante";
            this.btnBuscarVistaEstudiante.Size = new System.Drawing.Size(68, 50);
            this.btnBuscarVistaEstudiante.TabIndex = 6;
            this.btnBuscarVistaEstudiante.Text = "Buscar";
            this.btnBuscarVistaEstudiante.UseVisualStyleBackColor = false;
            this.btnBuscarVistaEstudiante.Click += new System.EventHandler(this.btnBuscarVistaEstudiante_Click);
            // 
            // dgvVistaEstudiante
            // 
            this.dgvVistaEstudiante.AllowUserToAddRows = false;
            this.dgvVistaEstudiante.AllowUserToDeleteRows = false;
            this.dgvVistaEstudiante.BackgroundColor = System.Drawing.Color.White;
            this.dgvVistaEstudiante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVistaEstudiante.Location = new System.Drawing.Point(12, 95);
            this.dgvVistaEstudiante.Name = "dgvVistaEstudiante";
            this.dgvVistaEstudiante.ReadOnly = true;
            this.dgvVistaEstudiante.RowHeadersVisible = false;
            this.dgvVistaEstudiante.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVistaEstudiante.Size = new System.Drawing.Size(804, 343);
            this.dgvVistaEstudiante.TabIndex = 7;
            this.dgvVistaEstudiante.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVistaEstudiante_CellDoubleClick);
            // 
            // lblNombreEstudiante
            // 
            this.lblNombreEstudiante.AutoSize = true;
            this.lblNombreEstudiante.Location = new System.Drawing.Point(24, 66);
            this.lblNombreEstudiante.Name = "lblNombreEstudiante";
            this.lblNombreEstudiante.Size = new System.Drawing.Size(166, 13);
            this.lblNombreEstudiante.TabIndex = 8;
            this.lblNombreEstudiante.Text = "Matricula - Nombre del Estudiante";
            // 
            // lblGradoEstudiante
            // 
            this.lblGradoEstudiante.AutoSize = true;
            this.lblGradoEstudiante.Location = new System.Drawing.Point(309, 66);
            this.lblGradoEstudiante.Name = "lblGradoEstudiante";
            this.lblGradoEstudiante.Size = new System.Drawing.Size(104, 13);
            this.lblGradoEstudiante.TabIndex = 9;
            this.lblGradoEstudiante.Text = "Curso del Estudiante";
            // 
            // lblEstadoEstudiante
            // 
            this.lblEstadoEstudiante.AutoSize = true;
            this.lblEstadoEstudiante.Location = new System.Drawing.Point(557, 66);
            this.lblEstadoEstudiante.Name = "lblEstadoEstudiante";
            this.lblEstadoEstudiante.Size = new System.Drawing.Size(110, 13);
            this.lblEstadoEstudiante.TabIndex = 10;
            this.lblEstadoEstudiante.Text = "Estado del Estudiante";
            // 
            // btnLimpiarVistaEstudiante
            // 
            this.btnLimpiarVistaEstudiante.BackColor = System.Drawing.Color.Crimson;
            this.btnLimpiarVistaEstudiante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarVistaEstudiante.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarVistaEstudiante.Location = new System.Drawing.Point(773, 29);
            this.btnLimpiarVistaEstudiante.Name = "btnLimpiarVistaEstudiante";
            this.btnLimpiarVistaEstudiante.Size = new System.Drawing.Size(43, 50);
            this.btnLimpiarVistaEstudiante.TabIndex = 11;
            this.btnLimpiarVistaEstudiante.Text = "X";
            this.btnLimpiarVistaEstudiante.UseVisualStyleBackColor = false;
            this.btnLimpiarVistaEstudiante.Click += new System.EventHandler(this.btnLimpiarVistaEstudiante_Click);
            // 
            // VistaDeEstudiantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(828, 450);
            this.Controls.Add(this.btnLimpiarVistaEstudiante);
            this.Controls.Add(this.lblEstadoEstudiante);
            this.Controls.Add(this.lblGradoEstudiante);
            this.Controls.Add(this.lblNombreEstudiante);
            this.Controls.Add(this.dgvVistaEstudiante);
            this.Controls.Add(this.btnBuscarVistaEstudiante);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBusquedaVistaEstudiante);
            this.Controls.Add(this.cboEstadoVistaEstudiante);
            this.Controls.Add(this.cboGradoVistaEstudiante);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VistaDeEstudiantes";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VistaDeEstudiantes";
            this.Load += new System.EventHandler(this.VistaDeEstudiantes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVistaEstudiante)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboGradoVistaEstudiante;
        private System.Windows.Forms.ComboBox cboEstadoVistaEstudiante;
        private System.Windows.Forms.TextBox txtBusquedaVistaEstudiante;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBuscarVistaEstudiante;
        private System.Windows.Forms.DataGridView dgvVistaEstudiante;
        private System.Windows.Forms.Label lblNombreEstudiante;
        private System.Windows.Forms.Label lblGradoEstudiante;
        private System.Windows.Forms.Label lblEstadoEstudiante;
        private System.Windows.Forms.Button btnLimpiarVistaEstudiante;
    }
}