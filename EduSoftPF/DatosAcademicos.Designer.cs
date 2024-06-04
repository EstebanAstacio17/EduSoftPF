namespace EduSoftPF
{
    partial class DatosAcademicos
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCuotaAcademica = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDetalleCuotaAcademica = new System.Windows.Forms.TextBox();
            this.btnEliminarCuota = new System.Windows.Forms.Button();
            this.dgvCuotaAcademica = new System.Windows.Forms.DataGridView();
            this.btnAgregarCuota = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDetalleCursoAcademico = new System.Windows.Forms.TextBox();
            this.txtCursoAcadamico = new System.Windows.Forms.TextBox();
            this.btnEliminarCurso = new System.Windows.Forms.Button();
            this.btnAgregarCurso = new System.Windows.Forms.Button();
            this.dgvCursoAcademica = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuotaAcademica)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursoAcademica)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCuotaAcademica);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDetalleCuotaAcademica);
            this.groupBox1.Controls.Add(this.btnEliminarCuota);
            this.groupBox1.Controls.Add(this.dgvCuotaAcademica);
            this.groupBox1.Controls.Add(this.btnAgregarCuota);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 426);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cuota Matricula";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Cuota";
            // 
            // txtCuotaAcademica
            // 
            this.txtCuotaAcademica.BackColor = System.Drawing.Color.White;
            this.txtCuotaAcademica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCuotaAcademica.Location = new System.Drawing.Point(6, 234);
            this.txtCuotaAcademica.Name = "txtCuotaAcademica";
            this.txtCuotaAcademica.Size = new System.Drawing.Size(252, 20);
            this.txtCuotaAcademica.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Detalle";
            // 
            // txtDetalleCuotaAcademica
            // 
            this.txtDetalleCuotaAcademica.BackColor = System.Drawing.Color.White;
            this.txtDetalleCuotaAcademica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetalleCuotaAcademica.Location = new System.Drawing.Point(6, 273);
            this.txtDetalleCuotaAcademica.Name = "txtDetalleCuotaAcademica";
            this.txtDetalleCuotaAcademica.Size = new System.Drawing.Size(252, 20);
            this.txtDetalleCuotaAcademica.TabIndex = 10;
            // 
            // btnEliminarCuota
            // 
            this.btnEliminarCuota.BackColor = System.Drawing.Color.Red;
            this.btnEliminarCuota.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarCuota.ForeColor = System.Drawing.Color.White;
            this.btnEliminarCuota.Location = new System.Drawing.Point(137, 309);
            this.btnEliminarCuota.Name = "btnEliminarCuota";
            this.btnEliminarCuota.Size = new System.Drawing.Size(121, 36);
            this.btnEliminarCuota.TabIndex = 9;
            this.btnEliminarCuota.Text = "Eliminar";
            this.btnEliminarCuota.UseVisualStyleBackColor = false;
            this.btnEliminarCuota.Click += new System.EventHandler(this.btnEliminarCuota_Click);
            // 
            // dgvCuotaAcademica
            // 
            this.dgvCuotaAcademica.AllowUserToAddRows = false;
            this.dgvCuotaAcademica.AllowUserToDeleteRows = false;
            this.dgvCuotaAcademica.BackgroundColor = System.Drawing.Color.White;
            this.dgvCuotaAcademica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuotaAcademica.GridColor = System.Drawing.Color.Black;
            this.dgvCuotaAcademica.Location = new System.Drawing.Point(6, 19);
            this.dgvCuotaAcademica.Name = "dgvCuotaAcademica";
            this.dgvCuotaAcademica.ReadOnly = true;
            this.dgvCuotaAcademica.RowHeadersVisible = false;
            this.dgvCuotaAcademica.RowHeadersWidth = 51;
            this.dgvCuotaAcademica.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCuotaAcademica.Size = new System.Drawing.Size(252, 192);
            this.dgvCuotaAcademica.TabIndex = 0;
            // 
            // btnAgregarCuota
            // 
            this.btnAgregarCuota.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAgregarCuota.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarCuota.ForeColor = System.Drawing.Color.White;
            this.btnAgregarCuota.Location = new System.Drawing.Point(6, 309);
            this.btnAgregarCuota.Name = "btnAgregarCuota";
            this.btnAgregarCuota.Size = new System.Drawing.Size(121, 36);
            this.btnAgregarCuota.TabIndex = 8;
            this.btnAgregarCuota.Text = "Agregar";
            this.btnAgregarCuota.UseVisualStyleBackColor = false;
            this.btnAgregarCuota.Click += new System.EventHandler(this.btnAgregarCuota_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtDetalleCursoAcademico);
            this.groupBox2.Controls.Add(this.txtCursoAcadamico);
            this.groupBox2.Controls.Add(this.btnEliminarCurso);
            this.groupBox2.Controls.Add(this.btnAgregarCurso);
            this.groupBox2.Controls.Add(this.dgvCursoAcademica);
            this.groupBox2.Location = new System.Drawing.Point(282, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(264, 426);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cursos";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Curso";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Detalle";
            // 
            // txtDetalleCursoAcademico
            // 
            this.txtDetalleCursoAcademico.BackColor = System.Drawing.Color.White;
            this.txtDetalleCursoAcademico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetalleCursoAcademico.Location = new System.Drawing.Point(6, 273);
            this.txtDetalleCursoAcademico.Name = "txtDetalleCursoAcademico";
            this.txtDetalleCursoAcademico.Size = new System.Drawing.Size(252, 20);
            this.txtDetalleCursoAcademico.TabIndex = 14;
            // 
            // txtCursoAcadamico
            // 
            this.txtCursoAcadamico.BackColor = System.Drawing.Color.White;
            this.txtCursoAcadamico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCursoAcadamico.Location = new System.Drawing.Point(6, 234);
            this.txtCursoAcadamico.Name = "txtCursoAcadamico";
            this.txtCursoAcadamico.Size = new System.Drawing.Size(252, 20);
            this.txtCursoAcadamico.TabIndex = 11;
            // 
            // btnEliminarCurso
            // 
            this.btnEliminarCurso.BackColor = System.Drawing.Color.Red;
            this.btnEliminarCurso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarCurso.ForeColor = System.Drawing.Color.White;
            this.btnEliminarCurso.Location = new System.Drawing.Point(137, 309);
            this.btnEliminarCurso.Name = "btnEliminarCurso";
            this.btnEliminarCurso.Size = new System.Drawing.Size(121, 36);
            this.btnEliminarCurso.TabIndex = 5;
            this.btnEliminarCurso.Text = "Eliminar";
            this.btnEliminarCurso.UseVisualStyleBackColor = false;
            this.btnEliminarCurso.Click += new System.EventHandler(this.btnEliminarCurso_Click);
            // 
            // btnAgregarCurso
            // 
            this.btnAgregarCurso.BackColor = System.Drawing.Color.OliveDrab;
            this.btnAgregarCurso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarCurso.ForeColor = System.Drawing.Color.White;
            this.btnAgregarCurso.Location = new System.Drawing.Point(6, 309);
            this.btnAgregarCurso.Name = "btnAgregarCurso";
            this.btnAgregarCurso.Size = new System.Drawing.Size(121, 36);
            this.btnAgregarCurso.TabIndex = 4;
            this.btnAgregarCurso.Text = "Agregar";
            this.btnAgregarCurso.UseVisualStyleBackColor = false;
            this.btnAgregarCurso.Click += new System.EventHandler(this.btnAgregarCurso_Click);
            // 
            // dgvCursoAcademica
            // 
            this.dgvCursoAcademica.AllowUserToAddRows = false;
            this.dgvCursoAcademica.AllowUserToDeleteRows = false;
            this.dgvCursoAcademica.BackgroundColor = System.Drawing.Color.White;
            this.dgvCursoAcademica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCursoAcademica.Location = new System.Drawing.Point(6, 19);
            this.dgvCursoAcademica.Name = "dgvCursoAcademica";
            this.dgvCursoAcademica.ReadOnly = true;
            this.dgvCursoAcademica.RowHeadersVisible = false;
            this.dgvCursoAcademica.RowHeadersWidth = 51;
            this.dgvCursoAcademica.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCursoAcademica.Size = new System.Drawing.Size(252, 192);
            this.dgvCursoAcademica.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.textBox3);
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Controls.Add(this.dataGridView3);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Location = new System.Drawing.Point(552, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(264, 426);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Maestros";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 293);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Maestro";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 332);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Detalle";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(143, 384);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 36);
            this.button1.TabIndex = 7;
            this.button1.Text = "Eliminar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(6, 309);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(252, 20);
            this.textBox3.TabIndex = 12;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(6, 348);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(252, 20);
            this.textBox4.TabIndex = 13;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(6, 19);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.Size = new System.Drawing.Size(252, 192);
            this.dataGridView3.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 384);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 36);
            this.button2.TabIndex = 6;
            this.button2.Text = "Agregar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // DatosAcademicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(828, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DatosAcademicos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Datos Academicos";
            this.Load += new System.EventHandler(this.DatosAcademicos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuotaAcademica)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursoAcademica)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvCuotaAcademica;
        private System.Windows.Forms.Button btnAgregarCurso;
        private System.Windows.Forms.DataGridView dgvCursoAcademica;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Button btnEliminarCuota;
        private System.Windows.Forms.Button btnAgregarCuota;
        private System.Windows.Forms.Button btnEliminarCurso;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCuotaAcademica;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDetalleCuotaAcademica;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDetalleCursoAcademico;
        private System.Windows.Forms.TextBox txtCursoAcadamico;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
    }
}