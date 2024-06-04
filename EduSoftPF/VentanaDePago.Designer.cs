namespace EduSoftPF
{
    partial class VentanaDePago
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
            this.clbCuotasPendientes = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscarAlumnoPago = new System.Windows.Forms.TextBox();
            this.cboCursoAlumnoPago = new System.Windows.Forms.ComboBox();
            this.btnBuscarAlumnoPago = new System.Windows.Forms.Button();
            this.cboEstadoAlumnoPago = new System.Windows.Forms.ComboBox();
            this.lblNombreSeleccionado = new System.Windows.Forms.Label();
            this.lblCursoAlumnoSeleccionado = new System.Windows.Forms.Label();
            this.lblEstadoAlumnoSeleccionado = new System.Windows.Forms.Label();
            this.dgvVerAlumnoPago = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvListaPago = new System.Windows.Forms.DataGridView();
            this.ColumnMatricula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEstudiante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnValorCuota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregarPago = new System.Windows.Forms.Button();
            this.btnSacarPago = new System.Windows.Forms.Button();
            this.btnPagarAlumno = new System.Windows.Forms.Button();
            this.btnCancelarPago = new System.Windows.Forms.Button();
            this.btnLimpiarBusqueda = new System.Windows.Forms.Button();
            this.lblMatriculaSeleccionado = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVerAlumnoPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaPago)).BeginInit();
            this.SuspendLayout();
            // 
            // clbCuotasPendientes
            // 
            this.clbCuotasPendientes.FormattingEnabled = true;
            this.clbCuotasPendientes.Location = new System.Drawing.Point(12, 235);
            this.clbCuotasPendientes.Name = "clbCuotasPendientes";
            this.clbCuotasPendientes.Size = new System.Drawing.Size(192, 199);
            this.clbCuotasPendientes.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Busqueda";
            // 
            // txtBuscarAlumnoPago
            // 
            this.txtBuscarAlumnoPago.BackColor = System.Drawing.Color.White;
            this.txtBuscarAlumnoPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarAlumnoPago.Location = new System.Drawing.Point(82, 17);
            this.txtBuscarAlumnoPago.Name = "txtBuscarAlumnoPago";
            this.txtBuscarAlumnoPago.Size = new System.Drawing.Size(295, 20);
            this.txtBuscarAlumnoPago.TabIndex = 2;
            // 
            // cboCursoAlumnoPago
            // 
            this.cboCursoAlumnoPago.FormattingEnabled = true;
            this.cboCursoAlumnoPago.Location = new System.Drawing.Point(383, 16);
            this.cboCursoAlumnoPago.Name = "cboCursoAlumnoPago";
            this.cboCursoAlumnoPago.Size = new System.Drawing.Size(121, 21);
            this.cboCursoAlumnoPago.TabIndex = 3;
            // 
            // btnBuscarAlumnoPago
            // 
            this.btnBuscarAlumnoPago.BackColor = System.Drawing.Color.SteelBlue;
            this.btnBuscarAlumnoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarAlumnoPago.ForeColor = System.Drawing.Color.White;
            this.btnBuscarAlumnoPago.Location = new System.Drawing.Point(637, 20);
            this.btnBuscarAlumnoPago.Name = "btnBuscarAlumnoPago";
            this.btnBuscarAlumnoPago.Size = new System.Drawing.Size(85, 37);
            this.btnBuscarAlumnoPago.TabIndex = 4;
            this.btnBuscarAlumnoPago.Text = "Buscar";
            this.btnBuscarAlumnoPago.UseVisualStyleBackColor = false;
            this.btnBuscarAlumnoPago.Click += new System.EventHandler(this.btnBuscarAlumnoPago_Click);
            // 
            // cboEstadoAlumnoPago
            // 
            this.cboEstadoAlumnoPago.FormattingEnabled = true;
            this.cboEstadoAlumnoPago.Items.AddRange(new object[] {
            "Activo",
            "No Activo"});
            this.cboEstadoAlumnoPago.Location = new System.Drawing.Point(510, 17);
            this.cboEstadoAlumnoPago.Name = "cboEstadoAlumnoPago";
            this.cboEstadoAlumnoPago.Size = new System.Drawing.Size(121, 21);
            this.cboEstadoAlumnoPago.TabIndex = 5;
            // 
            // lblNombreSeleccionado
            // 
            this.lblNombreSeleccionado.AutoSize = true;
            this.lblNombreSeleccionado.Location = new System.Drawing.Point(125, 40);
            this.lblNombreSeleccionado.Name = "lblNombreSeleccionado";
            this.lblNombreSeleccionado.Size = new System.Drawing.Size(114, 13);
            this.lblNombreSeleccionado.TabIndex = 6;
            this.lblNombreSeleccionado.Text = "Nombre del Estudiante";
            // 
            // lblCursoAlumnoSeleccionado
            // 
            this.lblCursoAlumnoSeleccionado.AutoSize = true;
            this.lblCursoAlumnoSeleccionado.Location = new System.Drawing.Point(393, 40);
            this.lblCursoAlumnoSeleccionado.Name = "lblCursoAlumnoSeleccionado";
            this.lblCursoAlumnoSeleccionado.Size = new System.Drawing.Size(34, 13);
            this.lblCursoAlumnoSeleccionado.TabIndex = 7;
            this.lblCursoAlumnoSeleccionado.Text = "Curso";
            // 
            // lblEstadoAlumnoSeleccionado
            // 
            this.lblEstadoAlumnoSeleccionado.AutoSize = true;
            this.lblEstadoAlumnoSeleccionado.Location = new System.Drawing.Point(518, 41);
            this.lblEstadoAlumnoSeleccionado.Name = "lblEstadoAlumnoSeleccionado";
            this.lblEstadoAlumnoSeleccionado.Size = new System.Drawing.Size(40, 13);
            this.lblEstadoAlumnoSeleccionado.TabIndex = 8;
            this.lblEstadoAlumnoSeleccionado.Text = "Estado";
            // 
            // dgvVerAlumnoPago
            // 
            this.dgvVerAlumnoPago.AllowUserToAddRows = false;
            this.dgvVerAlumnoPago.AllowUserToDeleteRows = false;
            this.dgvVerAlumnoPago.BackgroundColor = System.Drawing.Color.White;
            this.dgvVerAlumnoPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVerAlumnoPago.Location = new System.Drawing.Point(12, 69);
            this.dgvVerAlumnoPago.Name = "dgvVerAlumnoPago";
            this.dgvVerAlumnoPago.ReadOnly = true;
            this.dgvVerAlumnoPago.RowHeadersVisible = false;
            this.dgvVerAlumnoPago.RowHeadersWidth = 51;
            this.dgvVerAlumnoPago.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVerAlumnoPago.Size = new System.Drawing.Size(801, 143);
            this.dgvVerAlumnoPago.TabIndex = 9;
            this.dgvVerAlumnoPago.SelectionChanged += new System.EventHandler(this.DgvVerAlumnoPago_SelectionChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Cuotas Pendientes";
            // 
            // dgvListaPago
            // 
            this.dgvListaPago.AllowUserToAddRows = false;
            this.dgvListaPago.AllowUserToDeleteRows = false;
            this.dgvListaPago.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaPago.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnMatricula,
            this.ColumnEstudiante,
            this.ColumnValorCuota});
            this.dgvListaPago.Location = new System.Drawing.Point(290, 235);
            this.dgvListaPago.Name = "dgvListaPago";
            this.dgvListaPago.ReadOnly = true;
            this.dgvListaPago.RowHeadersVisible = false;
            this.dgvListaPago.RowHeadersWidth = 45;
            this.dgvListaPago.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaPago.Size = new System.Drawing.Size(379, 199);
            this.dgvListaPago.TabIndex = 14;
            // 
            // ColumnMatricula
            // 
            this.ColumnMatricula.Frozen = true;
            this.ColumnMatricula.HeaderText = "Matricula";
            this.ColumnMatricula.MinimumWidth = 6;
            this.ColumnMatricula.Name = "ColumnMatricula";
            this.ColumnMatricula.ReadOnly = true;
            this.ColumnMatricula.Width = 125;
            // 
            // ColumnEstudiante
            // 
            this.ColumnEstudiante.Frozen = true;
            this.ColumnEstudiante.HeaderText = "Estudiante";
            this.ColumnEstudiante.MinimumWidth = 6;
            this.ColumnEstudiante.Name = "ColumnEstudiante";
            this.ColumnEstudiante.ReadOnly = true;
            this.ColumnEstudiante.Width = 125;
            // 
            // ColumnValorCuota
            // 
            this.ColumnValorCuota.Frozen = true;
            this.ColumnValorCuota.HeaderText = "Valor Cuota";
            this.ColumnValorCuota.MinimumWidth = 6;
            this.ColumnValorCuota.Name = "ColumnValorCuota";
            this.ColumnValorCuota.ReadOnly = true;
            this.ColumnValorCuota.Width = 125;
            // 
            // btnAgregarPago
            // 
            this.btnAgregarPago.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAgregarPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarPago.ForeColor = System.Drawing.Color.White;
            this.btnAgregarPago.Location = new System.Drawing.Point(209, 283);
            this.btnAgregarPago.Name = "btnAgregarPago";
            this.btnAgregarPago.Size = new System.Drawing.Size(75, 31);
            this.btnAgregarPago.TabIndex = 15;
            this.btnAgregarPago.Text = "Agregar";
            this.btnAgregarPago.UseVisualStyleBackColor = false;
            this.btnAgregarPago.Click += new System.EventHandler(this.btnAgregarPago_Click);
            // 
            // btnSacarPago
            // 
            this.btnSacarPago.BackColor = System.Drawing.Color.Crimson;
            this.btnSacarPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSacarPago.ForeColor = System.Drawing.Color.White;
            this.btnSacarPago.Location = new System.Drawing.Point(209, 369);
            this.btnSacarPago.Name = "btnSacarPago";
            this.btnSacarPago.Size = new System.Drawing.Size(75, 31);
            this.btnSacarPago.TabIndex = 16;
            this.btnSacarPago.Text = "Sacar";
            this.btnSacarPago.UseVisualStyleBackColor = false;
            this.btnSacarPago.Click += new System.EventHandler(this.btnSacarPago_Click);
            // 
            // btnPagarAlumno
            // 
            this.btnPagarAlumno.ForeColor = System.Drawing.Color.White;
            this.btnPagarAlumno.Location = new System.Drawing.Point(675, 328);
            this.btnPagarAlumno.Name = "btnPagarAlumno";
            this.btnPagarAlumno.Size = new System.Drawing.Size(138, 50);
            this.btnPagarAlumno.TabIndex = 17;
            this.btnPagarAlumno.Text = "Pagar";
            this.btnPagarAlumno.UseVisualStyleBackColor = true;
            this.btnPagarAlumno.Click += new System.EventHandler(this.btnPagarAlumno_Click);
            // 
            // btnCancelarPago
            // 
            this.btnCancelarPago.BackColor = System.Drawing.Color.Crimson;
            this.btnCancelarPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarPago.ForeColor = System.Drawing.Color.White;
            this.btnCancelarPago.Location = new System.Drawing.Point(675, 384);
            this.btnCancelarPago.Name = "btnCancelarPago";
            this.btnCancelarPago.Size = new System.Drawing.Size(138, 50);
            this.btnCancelarPago.TabIndex = 20;
            this.btnCancelarPago.Text = "Cancelar";
            this.btnCancelarPago.UseVisualStyleBackColor = false;
            this.btnCancelarPago.Click += new System.EventHandler(this.btnCancelarPago_Click);
            // 
            // btnLimpiarBusqueda
            // 
            this.btnLimpiarBusqueda.BackColor = System.Drawing.Color.SteelBlue;
            this.btnLimpiarBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarBusqueda.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarBusqueda.Location = new System.Drawing.Point(728, 20);
            this.btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            this.btnLimpiarBusqueda.Size = new System.Drawing.Size(85, 37);
            this.btnLimpiarBusqueda.TabIndex = 21;
            this.btnLimpiarBusqueda.Text = "Limpiar";
            this.btnLimpiarBusqueda.UseVisualStyleBackColor = false;
            this.btnLimpiarBusqueda.Click += new System.EventHandler(this.btnLimpiarBusqueda_Click);
            // 
            // lblMatriculaSeleccionado
            // 
            this.lblMatriculaSeleccionado.AutoSize = true;
            this.lblMatriculaSeleccionado.Location = new System.Drawing.Point(91, 40);
            this.lblMatriculaSeleccionado.Name = "lblMatriculaSeleccionado";
            this.lblMatriculaSeleccionado.Size = new System.Drawing.Size(28, 13);
            this.lblMatriculaSeleccionado.TabIndex = 22;
            this.lblMatriculaSeleccionado.Text = "Matr";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(107, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "-";
            // 
            // VentanaDePago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(828, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMatriculaSeleccionado);
            this.Controls.Add(this.btnLimpiarBusqueda);
            this.Controls.Add(this.btnCancelarPago);
            this.Controls.Add(this.btnPagarAlumno);
            this.Controls.Add(this.btnSacarPago);
            this.Controls.Add(this.btnAgregarPago);
            this.Controls.Add(this.dgvListaPago);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvVerAlumnoPago);
            this.Controls.Add(this.lblEstadoAlumnoSeleccionado);
            this.Controls.Add(this.lblCursoAlumnoSeleccionado);
            this.Controls.Add(this.lblNombreSeleccionado);
            this.Controls.Add(this.cboEstadoAlumnoPago);
            this.Controls.Add(this.btnBuscarAlumnoPago);
            this.Controls.Add(this.cboCursoAlumnoPago);
            this.Controls.Add(this.txtBuscarAlumnoPago);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clbCuotasPendientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VentanaDePago";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventana De Pago";
            this.Load += new System.EventHandler(this.VentanaDePago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVerAlumnoPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaPago)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbCuotasPendientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscarAlumnoPago;
        private System.Windows.Forms.ComboBox cboCursoAlumnoPago;
        private System.Windows.Forms.Button btnBuscarAlumnoPago;
        private System.Windows.Forms.ComboBox cboEstadoAlumnoPago;
        private System.Windows.Forms.Label lblNombreSeleccionado;
        private System.Windows.Forms.Label lblCursoAlumnoSeleccionado;
        private System.Windows.Forms.Label lblEstadoAlumnoSeleccionado;
        private System.Windows.Forms.DataGridView dgvVerAlumnoPago;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvListaPago;
        private System.Windows.Forms.Button btnAgregarPago;
        private System.Windows.Forms.Button btnSacarPago;
        private System.Windows.Forms.Button btnPagarAlumno;
        private System.Windows.Forms.Button btnCancelarPago;
        private System.Windows.Forms.Button btnLimpiarBusqueda;
        private System.Windows.Forms.Label lblMatriculaSeleccionado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMatricula;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEstudiante;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValorCuota;
    }
}