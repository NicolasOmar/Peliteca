namespace Peliteca
{
    partial class MenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
            this.btnGender = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnDirector = new System.Windows.Forms.Button();
            this.btnPais = new System.Windows.Forms.Button();
            this.btnActor = new System.Windows.Forms.Button();
            this.btnPeli = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGender
            // 
            this.btnGender.BackColor = System.Drawing.Color.LawnGreen;
            this.btnGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGender.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnGender.Location = new System.Drawing.Point(105, 20);
            this.btnGender.Name = "btnGender";
            this.btnGender.Size = new System.Drawing.Size(75, 75);
            this.btnGender.TabIndex = 1;
            this.btnGender.Text = "Generos";
            this.btnGender.UseVisualStyleBackColor = false;
            this.btnGender.Click += new System.EventHandler(this.btnGender_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Red;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalir.Location = new System.Drawing.Point(65, 262);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 75);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnUser
            // 
            this.btnUser.BackColor = System.Drawing.Color.DarkOrange;
            this.btnUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUser.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUser.Location = new System.Drawing.Point(105, 181);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(75, 75);
            this.btnUser.TabIndex = 5;
            this.btnUser.Text = "Modificar Usuario";
            this.btnUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUser.UseVisualStyleBackColor = false;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnDirector
            // 
            this.btnDirector.BackColor = System.Drawing.Color.DarkGreen;
            this.btnDirector.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDirector.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDirector.Location = new System.Drawing.Point(24, 181);
            this.btnDirector.Name = "btnDirector";
            this.btnDirector.Size = new System.Drawing.Size(75, 75);
            this.btnDirector.TabIndex = 4;
            this.btnDirector.Text = "Directores";
            this.btnDirector.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDirector.UseVisualStyleBackColor = false;
            this.btnDirector.Click += new System.EventHandler(this.btnDirector_Click);
            // 
            // btnPais
            // 
            this.btnPais.BackColor = System.Drawing.Color.ForestGreen;
            this.btnPais.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPais.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPais.Location = new System.Drawing.Point(105, 101);
            this.btnPais.Name = "btnPais";
            this.btnPais.Size = new System.Drawing.Size(75, 75);
            this.btnPais.TabIndex = 3;
            this.btnPais.Text = "Paises";
            this.btnPais.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPais.UseVisualStyleBackColor = false;
            this.btnPais.Click += new System.EventHandler(this.btnPais_Click);
            // 
            // btnActor
            // 
            this.btnActor.BackColor = System.Drawing.Color.LimeGreen;
            this.btnActor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActor.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnActor.Location = new System.Drawing.Point(24, 101);
            this.btnActor.Name = "btnActor";
            this.btnActor.Size = new System.Drawing.Size(75, 75);
            this.btnActor.TabIndex = 2;
            this.btnActor.Text = "Actores";
            this.btnActor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnActor.UseVisualStyleBackColor = false;
            this.btnActor.Click += new System.EventHandler(this.btnActor_Click);
            // 
            // btnPeli
            // 
            this.btnPeli.BackColor = System.Drawing.Color.Lime;
            this.btnPeli.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPeli.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPeli.Location = new System.Drawing.Point(23, 20);
            this.btnPeli.Name = "btnPeli";
            this.btnPeli.Size = new System.Drawing.Size(75, 75);
            this.btnPeli.TabIndex = 0;
            this.btnPeli.Text = "Peliculas";
            this.btnPeli.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPeli.UseVisualStyleBackColor = false;
            this.btnPeli.Click += new System.EventHandler(this.btnPeli_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 357);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnUser);
            this.Controls.Add(this.btnDirector);
            this.Controls.Add(this.btnPais);
            this.Controls.Add(this.btnActor);
            this.Controls.Add(this.btnGender);
            this.Controls.Add(this.btnPeli);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuPrincipal";
            this.Text = "Principal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPeli;
        private System.Windows.Forms.Button btnGender;
        private System.Windows.Forms.Button btnActor;
        private System.Windows.Forms.Button btnPais;
        private System.Windows.Forms.Button btnDirector;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnSalir;
    }
}