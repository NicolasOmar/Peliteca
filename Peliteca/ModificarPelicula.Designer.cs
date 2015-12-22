namespace Peliteca
{
    partial class ModificarPelicula
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificarPelicula));
            this.grbPeliMod = new System.Windows.Forms.GroupBox();
            this.ptbPelicula = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDuracion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbGeneros = new System.Windows.Forms.ComboBox();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.cmbDirector = new System.Windows.Forms.ComboBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.lblGenero = new System.Windows.Forms.Label();
            this.lblAnio = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelReparto = new System.Windows.Forms.Panel();
            this.txtActor1 = new System.Windows.Forms.TextBox();
            this.txtActor2 = new System.Windows.Forms.TextBox();
            this.txtActor3 = new System.Windows.Forms.TextBox();
            this.txtActor4 = new System.Windows.Forms.TextBox();
            this.txtActor5 = new System.Windows.Forms.TextBox();
            this.txtActor6 = new System.Windows.Forms.TextBox();
            this.txtActor7 = new System.Windows.Forms.TextBox();
            this.txtActor8 = new System.Windows.Forms.TextBox();
            this.txtActor9 = new System.Windows.Forms.TextBox();
            this.panelPaises = new System.Windows.Forms.Panel();
            this.txtPais1 = new System.Windows.Forms.TextBox();
            this.txtPais2 = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnPais = new System.Windows.Forms.Button();
            this.btnDirector = new System.Windows.Forms.Button();
            this.btnGenero = new System.Windows.Forms.Button();
            this.btnActor = new System.Windows.Forms.Button();
            this.grbPeliMod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPelicula)).BeginInit();
            this.panelReparto.SuspendLayout();
            this.panelPaises.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbPeliMod
            // 
            this.grbPeliMod.BackColor = System.Drawing.Color.Gold;
            this.grbPeliMod.Controls.Add(this.ptbPelicula);
            this.grbPeliMod.Controls.Add(this.label6);
            this.grbPeliMod.Controls.Add(this.txtDuracion);
            this.grbPeliMod.Controls.Add(this.label5);
            this.grbPeliMod.Controls.Add(this.label4);
            this.grbPeliMod.Controls.Add(this.cmbGeneros);
            this.grbPeliMod.Controls.Add(this.txtAnio);
            this.grbPeliMod.Controls.Add(this.cmbDirector);
            this.grbPeliMod.Controls.Add(this.txtTitulo);
            this.grbPeliMod.Controls.Add(this.lblGenero);
            this.grbPeliMod.Controls.Add(this.lblAnio);
            this.grbPeliMod.Controls.Add(this.label3);
            this.grbPeliMod.Controls.Add(this.label2);
            this.grbPeliMod.Controls.Add(this.label1);
            this.grbPeliMod.Controls.Add(this.panelReparto);
            this.grbPeliMod.Controls.Add(this.panelPaises);
            this.grbPeliMod.Location = new System.Drawing.Point(13, 13);
            this.grbPeliMod.Name = "grbPeliMod";
            this.grbPeliMod.Size = new System.Drawing.Size(223, 659);
            this.grbPeliMod.TabIndex = 0;
            this.grbPeliMod.TabStop = false;
            this.grbPeliMod.Text = "Datos de la Pelicula";
            // 
            // ptbPelicula
            // 
            this.ptbPelicula.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ptbPelicula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbPelicula.Location = new System.Drawing.Point(6, 519);
            this.ptbPelicula.Name = "ptbPelicula";
            this.ptbPelicula.Size = new System.Drawing.Size(211, 134);
            this.ptbPelicula.TabIndex = 26;
            this.ptbPelicula.TabStop = false;
            this.ptbPelicula.Click += new System.EventHandler(this.ptbPelicula_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(122, 487);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "min.";
            // 
            // txtDuracion
            // 
            this.txtDuracion.Location = new System.Drawing.Point(69, 484);
            this.txtDuracion.Name = "txtDuracion";
            this.txtDuracion.Size = new System.Drawing.Size(47, 20);
            this.txtDuracion.TabIndex = 6;
            this.txtDuracion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDuracion_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 487);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Duración";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 351);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Paises";
            // 
            // cmbGeneros
            // 
            this.cmbGeneros.FormattingEnabled = true;
            this.cmbGeneros.Location = new System.Drawing.Point(69, 411);
            this.cmbGeneros.Name = "cmbGeneros";
            this.cmbGeneros.Size = new System.Drawing.Size(137, 21);
            this.cmbGeneros.TabIndex = 4;
            // 
            // txtAnio
            // 
            this.txtAnio.Location = new System.Drawing.Point(69, 448);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(47, 20);
            this.txtAnio.TabIndex = 5;
            this.txtAnio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAnio_KeyPress);
            // 
            // cmbDirector
            // 
            this.cmbDirector.FormattingEnabled = true;
            this.cmbDirector.Location = new System.Drawing.Point(68, 63);
            this.cmbDirector.Name = "cmbDirector";
            this.cmbDirector.Size = new System.Drawing.Size(137, 21);
            this.cmbDirector.TabIndex = 1;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(68, 28);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(137, 20);
            this.txtTitulo.TabIndex = 0;
            this.txtTitulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTitulo_KeyPress);
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Location = new System.Drawing.Point(21, 414);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(42, 13);
            this.lblGenero.TabIndex = 11;
            this.lblGenero.Text = "Genero";
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Location = new System.Drawing.Point(37, 451);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(26, 13);
            this.lblAnio.TabIndex = 12;
            this.lblAnio.Text = "Año";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Reparto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Director";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Titulo";
            // 
            // panelReparto
            // 
            this.panelReparto.Controls.Add(this.txtActor1);
            this.panelReparto.Controls.Add(this.txtActor2);
            this.panelReparto.Controls.Add(this.txtActor3);
            this.panelReparto.Controls.Add(this.txtActor4);
            this.panelReparto.Controls.Add(this.txtActor5);
            this.panelReparto.Controls.Add(this.txtActor6);
            this.panelReparto.Controls.Add(this.txtActor7);
            this.panelReparto.Controls.Add(this.txtActor8);
            this.panelReparto.Controls.Add(this.txtActor9);
            this.panelReparto.Location = new System.Drawing.Point(62, 90);
            this.panelReparto.Name = "panelReparto";
            this.panelReparto.Size = new System.Drawing.Size(155, 243);
            this.panelReparto.TabIndex = 2;
            // 
            // txtActor1
            // 
            this.txtActor1.Location = new System.Drawing.Point(7, 9);
            this.txtActor1.Name = "txtActor1";
            this.txtActor1.Size = new System.Drawing.Size(137, 20);
            this.txtActor1.TabIndex = 0;
            this.txtActor1.Click += new System.EventHandler(this.txtActor1_Click);
            this.txtActor1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtActor1_KeyPress);
            // 
            // txtActor2
            // 
            this.txtActor2.Location = new System.Drawing.Point(6, 35);
            this.txtActor2.Name = "txtActor2";
            this.txtActor2.Size = new System.Drawing.Size(137, 20);
            this.txtActor2.TabIndex = 1;
            this.txtActor2.Click += new System.EventHandler(this.txtActor2_Click);
            this.txtActor2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtActor2_KeyPress);
            // 
            // txtActor3
            // 
            this.txtActor3.Location = new System.Drawing.Point(7, 61);
            this.txtActor3.Name = "txtActor3";
            this.txtActor3.Size = new System.Drawing.Size(137, 20);
            this.txtActor3.TabIndex = 2;
            this.txtActor3.Click += new System.EventHandler(this.txtActor3_Click);
            this.txtActor3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtActor3_KeyPress);
            // 
            // txtActor4
            // 
            this.txtActor4.Location = new System.Drawing.Point(7, 87);
            this.txtActor4.Name = "txtActor4";
            this.txtActor4.Size = new System.Drawing.Size(137, 20);
            this.txtActor4.TabIndex = 3;
            this.txtActor4.Click += new System.EventHandler(this.txtActor4_Click);
            this.txtActor4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtActor4_KeyPress);
            // 
            // txtActor5
            // 
            this.txtActor5.Location = new System.Drawing.Point(7, 113);
            this.txtActor5.Name = "txtActor5";
            this.txtActor5.Size = new System.Drawing.Size(137, 20);
            this.txtActor5.TabIndex = 4;
            this.txtActor5.Click += new System.EventHandler(this.txtActor5_Click);
            this.txtActor5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtActor5_KeyPress);
            // 
            // txtActor6
            // 
            this.txtActor6.Location = new System.Drawing.Point(6, 139);
            this.txtActor6.Name = "txtActor6";
            this.txtActor6.Size = new System.Drawing.Size(137, 20);
            this.txtActor6.TabIndex = 5;
            this.txtActor6.Click += new System.EventHandler(this.txtActor6_Click);
            this.txtActor6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtActor6_KeyPress);
            // 
            // txtActor7
            // 
            this.txtActor7.Location = new System.Drawing.Point(6, 165);
            this.txtActor7.Name = "txtActor7";
            this.txtActor7.Size = new System.Drawing.Size(137, 20);
            this.txtActor7.TabIndex = 6;
            this.txtActor7.Click += new System.EventHandler(this.txtActor7_Click);
            this.txtActor7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtActor7_KeyPress);
            // 
            // txtActor8
            // 
            this.txtActor8.Location = new System.Drawing.Point(6, 191);
            this.txtActor8.Name = "txtActor8";
            this.txtActor8.Size = new System.Drawing.Size(137, 20);
            this.txtActor8.TabIndex = 7;
            this.txtActor8.Click += new System.EventHandler(this.txtActor8_Click);
            this.txtActor8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtActor8_KeyPress);
            // 
            // txtActor9
            // 
            this.txtActor9.Location = new System.Drawing.Point(5, 217);
            this.txtActor9.Name = "txtActor9";
            this.txtActor9.Size = new System.Drawing.Size(137, 20);
            this.txtActor9.TabIndex = 8;
            this.txtActor9.Click += new System.EventHandler(this.txtActor9_Click);
            this.txtActor9.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtActor9_KeyPress);
            // 
            // panelPaises
            // 
            this.panelPaises.Controls.Add(this.txtPais1);
            this.panelPaises.Controls.Add(this.txtPais2);
            this.panelPaises.Location = new System.Drawing.Point(62, 339);
            this.panelPaises.Name = "panelPaises";
            this.panelPaises.Size = new System.Drawing.Size(155, 66);
            this.panelPaises.TabIndex = 3;
            // 
            // txtPais1
            // 
            this.txtPais1.Location = new System.Drawing.Point(7, 9);
            this.txtPais1.Name = "txtPais1";
            this.txtPais1.Size = new System.Drawing.Size(137, 20);
            this.txtPais1.TabIndex = 0;
            this.txtPais1.Click += new System.EventHandler(this.txtPais1_Click);
            this.txtPais1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPais1_KeyPress);
            // 
            // txtPais2
            // 
            this.txtPais2.Location = new System.Drawing.Point(7, 35);
            this.txtPais2.Name = "txtPais2";
            this.txtPais2.Size = new System.Drawing.Size(137, 20);
            this.txtPais2.TabIndex = 1;
            this.txtPais2.Click += new System.EventHandler(this.txtPais2_Click);
            this.txtPais2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPais2_KeyPress);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Red;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelar.Location = new System.Drawing.Point(252, 91);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 75);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar Cambios";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGuardar.Location = new System.Drawing.Point(252, 10);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 75);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar Cambios";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnPais
            // 
            this.btnPais.BackColor = System.Drawing.Color.LightGreen;
            this.btnPais.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPais.Location = new System.Drawing.Point(252, 433);
            this.btnPais.Name = "btnPais";
            this.btnPais.Size = new System.Drawing.Size(75, 75);
            this.btnPais.TabIndex = 6;
            this.btnPais.Text = "Registrar Pais";
            this.btnPais.UseVisualStyleBackColor = false;
            this.btnPais.Click += new System.EventHandler(this.btnPais_Click);
            // 
            // btnDirector
            // 
            this.btnDirector.BackColor = System.Drawing.Color.GreenYellow;
            this.btnDirector.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDirector.Location = new System.Drawing.Point(252, 190);
            this.btnDirector.Name = "btnDirector";
            this.btnDirector.Size = new System.Drawing.Size(75, 75);
            this.btnDirector.TabIndex = 3;
            this.btnDirector.Text = "Registrar Director";
            this.btnDirector.UseVisualStyleBackColor = false;
            this.btnDirector.Click += new System.EventHandler(this.btnDirector_Click);
            // 
            // btnGenero
            // 
            this.btnGenero.BackColor = System.Drawing.Color.LawnGreen;
            this.btnGenero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenero.Location = new System.Drawing.Point(252, 352);
            this.btnGenero.Name = "btnGenero";
            this.btnGenero.Size = new System.Drawing.Size(75, 75);
            this.btnGenero.TabIndex = 5;
            this.btnGenero.Text = "Registrar Género";
            this.btnGenero.UseVisualStyleBackColor = false;
            this.btnGenero.Click += new System.EventHandler(this.btnGenero_Click);
            // 
            // btnActor
            // 
            this.btnActor.BackColor = System.Drawing.Color.Chartreuse;
            this.btnActor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActor.Location = new System.Drawing.Point(252, 271);
            this.btnActor.Name = "btnActor";
            this.btnActor.Size = new System.Drawing.Size(75, 75);
            this.btnActor.TabIndex = 4;
            this.btnActor.Text = "Registrar Actor/Actriz";
            this.btnActor.UseVisualStyleBackColor = false;
            this.btnActor.Click += new System.EventHandler(this.btnActor_Click);
            // 
            // ModificarPelicula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 684);
            this.Controls.Add(this.btnPais);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnDirector);
            this.Controls.Add(this.btnGenero);
            this.Controls.Add(this.btnActor);
            this.Controls.Add(this.grbPeliMod);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModificarPelicula";
            this.Text = "Modificar Pelicula";
            this.VisibleChanged += new System.EventHandler(this.ModificarPelicula_VisibleChanged);
            this.grbPeliMod.ResumeLayout(false);
            this.grbPeliMod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPelicula)).EndInit();
            this.panelReparto.ResumeLayout(false);
            this.panelReparto.PerformLayout();
            this.panelPaises.ResumeLayout(false);
            this.panelPaises.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbPeliMod;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.ComboBox cmbDirector;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.ComboBox cmbGeneros;
        private System.Windows.Forms.TextBox txtActor5;
        private System.Windows.Forms.TextBox txtActor4;
        private System.Windows.Forms.TextBox txtActor3;
        private System.Windows.Forms.TextBox txtActor2;
        private System.Windows.Forms.TextBox txtActor1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel panelReparto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPais2;
        private System.Windows.Forms.TextBox txtPais1;
        private System.Windows.Forms.Panel panelPaises;
        private System.Windows.Forms.Button btnPais;
        private System.Windows.Forms.Button btnDirector;
        private System.Windows.Forms.Button btnGenero;
        private System.Windows.Forms.Button btnActor;
        private System.Windows.Forms.TextBox txtActor6;
        private System.Windows.Forms.TextBox txtActor7;
        private System.Windows.Forms.TextBox txtActor8;
        private System.Windows.Forms.TextBox txtActor9;
        private System.Windows.Forms.TextBox txtDuracion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox ptbPelicula;
    }
}