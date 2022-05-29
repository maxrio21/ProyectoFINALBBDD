
namespace Cajero
{
    partial class IntroducirCuentaTGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntroducirCuentaTGUI));
            this.panel1 = new System.Windows.Forms.Panel();
            this.titulo = new System.Windows.Forms.Label();
            this.salirBtn = new System.Windows.Forms.Button();
            this.aceptarBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tarjetaLabel = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ibanBox = new System.Windows.Forms.TextBox();
            this.borrarBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.panel1.Controls.Add(this.titulo);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(663, 56);
            this.panel1.TabIndex = 0;
            // 
            // titulo
            // 
            this.titulo.Font = new System.Drawing.Font("Microsoft YaHei", 16F, System.Drawing.FontStyle.Bold);
            this.titulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.titulo.Location = new System.Drawing.Point(3, 0);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(168, 56);
            this.titulo.TabIndex = 0;
            this.titulo.Text = "Bienvenido";
            this.titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // salirBtn
            // 
            this.salirBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(77)))), ((int)(((byte)(61)))));
            this.salirBtn.FlatAppearance.BorderSize = 0;
            this.salirBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.salirBtn.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salirBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.salirBtn.Location = new System.Drawing.Point(408, 229);
            this.salirBtn.Name = "salirBtn";
            this.salirBtn.Size = new System.Drawing.Size(118, 54);
            this.salirBtn.TabIndex = 1;
            this.salirBtn.Text = "SALIR";
            this.salirBtn.UseVisualStyleBackColor = false;
            this.salirBtn.Click += new System.EventHandler(this.button3_Click);
            this.salirBtn.MouseLeave += new System.EventHandler(this.onLeaveButton);
            this.salirBtn.MouseHover += new System.EventHandler(this.onHoverButton);
            // 
            // aceptarBtn
            // 
            this.aceptarBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(205)))), ((int)(((byte)(112)))));
            this.aceptarBtn.FlatAppearance.BorderSize = 0;
            this.aceptarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aceptarBtn.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptarBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.aceptarBtn.Location = new System.Drawing.Point(140, 229);
            this.aceptarBtn.Name = "aceptarBtn";
            this.aceptarBtn.Size = new System.Drawing.Size(118, 54);
            this.aceptarBtn.TabIndex = 0;
            this.aceptarBtn.Text = "ACEPTAR";
            this.aceptarBtn.UseVisualStyleBackColor = false;
            this.aceptarBtn.Click += new System.EventHandler(this.aceptarBtn_Click);
            this.aceptarBtn.MouseLeave += new System.EventHandler(this.onLeaveButton);
            this.aceptarBtn.MouseHover += new System.EventHandler(this.onHoverButton);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(454, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 74);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // tarjetaLabel
            // 
            this.tarjetaLabel.BackColor = System.Drawing.Color.Transparent;
            this.tarjetaLabel.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tarjetaLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.tarjetaLabel.Location = new System.Drawing.Point(134, 55);
            this.tarjetaLabel.Name = "tarjetaLabel";
            this.tarjetaLabel.Size = new System.Drawing.Size(314, 74);
            this.tarjetaLabel.TabIndex = 0;
            this.tarjetaLabel.Text = "Introduce la cuenta a transferir";
            this.tarjetaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(43)))));
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.salirBtn);
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.aceptarBtn);
            this.panel4.Controls.Add(this.borrarBtn);
            this.panel4.Controls.Add(this.tarjetaLabel);
            this.panel4.Location = new System.Drawing.Point(0, 56);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(663, 356);
            this.panel4.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.panel2.Controls.Add(this.ibanBox);
            this.panel2.Location = new System.Drawing.Point(140, 144);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(386, 60);
            this.panel2.TabIndex = 3;
            // 
            // ibanBox
            // 
            this.ibanBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.ibanBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ibanBox.Font = new System.Drawing.Font("Microsoft YaHei", 19F, System.Drawing.FontStyle.Bold);
            this.ibanBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ibanBox.Location = new System.Drawing.Point(0, 13);
            this.ibanBox.MaxLength = 26;
            this.ibanBox.Name = "ibanBox";
            this.ibanBox.Size = new System.Drawing.Size(386, 34);
            this.ibanBox.TabIndex = 0;
            this.ibanBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // borrarBtn
            // 
            this.borrarBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.borrarBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.borrarBtn.FlatAppearance.BorderSize = 0;
            this.borrarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.borrarBtn.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.borrarBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.borrarBtn.Location = new System.Drawing.Point(274, 229);
            this.borrarBtn.Name = "borrarBtn";
            this.borrarBtn.Size = new System.Drawing.Size(118, 54);
            this.borrarBtn.TabIndex = 1;
            this.borrarBtn.Text = "BORRAR";
            this.borrarBtn.UseVisualStyleBackColor = false;
            // 
            // IntroducirCuentaTGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 407);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Name = "IntroducirCuentaTGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button borrarBtn;
        private System.Windows.Forms.TextBox ibanBox;
        private System.Windows.Forms.Label tarjetaLabel;
        private System.Windows.Forms.Button salirBtn;
        private System.Windows.Forms.Button aceptarBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
    }
}

