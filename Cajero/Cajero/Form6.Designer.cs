
namespace Cajero
{
    partial class ConsultarSaldoGUI
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.entidadTBox = new System.Windows.Forms.Label();
            this.aceptarBtn = new System.Windows.Forms.Button();
            this.salirBtn = new System.Windows.Forms.Button();
            this.atrasBtn = new System.Windows.Forms.Button();
            this.textoCuenta = new System.Windows.Forms.Label();
            this.textoImporte = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.panel1.Controls.Add(this.entidadTBox);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 56);
            this.panel1.TabIndex = 0;
            // 
            // entidadTBox
            // 
            this.entidadTBox.Font = new System.Drawing.Font("Microsoft YaHei", 16F, System.Drawing.FontStyle.Bold);
            this.entidadTBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.entidadTBox.Location = new System.Drawing.Point(0, 0);
            this.entidadTBox.Name = "entidadTBox";
            this.entidadTBox.Size = new System.Drawing.Size(147, 56);
            this.entidadTBox.TabIndex = 0;
            this.entidadTBox.Text = "ENTIDAD";
            this.entidadTBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aceptarBtn
            // 
            this.aceptarBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(205)))), ((int)(((byte)(112)))));
            this.aceptarBtn.FlatAppearance.BorderSize = 0;
            this.aceptarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aceptarBtn.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptarBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.aceptarBtn.Location = new System.Drawing.Point(207, 289);
            this.aceptarBtn.Name = "aceptarBtn";
            this.aceptarBtn.Size = new System.Drawing.Size(165, 50);
            this.aceptarBtn.TabIndex = 2;
            this.aceptarBtn.Text = "✔ ACEPTAR";
            this.aceptarBtn.UseVisualStyleBackColor = false;
            this.aceptarBtn.Click += new System.EventHandler(this.aceptarBtn_Click);
            // 
            // salirBtn
            // 
            this.salirBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(77)))), ((int)(((byte)(61)))));
            this.salirBtn.FlatAppearance.BorderSize = 0;
            this.salirBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.salirBtn.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salirBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.salirBtn.Location = new System.Drawing.Point(387, 289);
            this.salirBtn.Name = "salirBtn";
            this.salirBtn.Size = new System.Drawing.Size(165, 50);
            this.salirBtn.TabIndex = 1;
            this.salirBtn.Text = "✖ SALIR";
            this.salirBtn.UseVisualStyleBackColor = false;
            this.salirBtn.Click += new System.EventHandler(this.salirBtn_Click);
            this.salirBtn.MouseLeave += new System.EventHandler(this.onLeaveButton);
            this.salirBtn.MouseHover += new System.EventHandler(this.onHoverButton);
            // 
            // atrasBtn
            // 
            this.atrasBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.atrasBtn.FlatAppearance.BorderSize = 0;
            this.atrasBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.atrasBtn.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.atrasBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.atrasBtn.Location = new System.Drawing.Point(27, 289);
            this.atrasBtn.Name = "atrasBtn";
            this.atrasBtn.Size = new System.Drawing.Size(165, 50);
            this.atrasBtn.TabIndex = 0;
            this.atrasBtn.Text = "❮ ATRAS";
            this.atrasBtn.UseVisualStyleBackColor = false;
            this.atrasBtn.Click += new System.EventHandler(this.atrasBtn_Click);
            this.atrasBtn.MouseLeave += new System.EventHandler(this.onLeaveButton);
            this.atrasBtn.MouseHover += new System.EventHandler(this.onHoverButton);
            // 
            // textoCuenta
            // 
            this.textoCuenta.BackColor = System.Drawing.Color.Transparent;
            this.textoCuenta.Font = new System.Drawing.Font("Microsoft YaHei", 17F);
            this.textoCuenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.textoCuenta.Location = new System.Drawing.Point(0, 192);
            this.textoCuenta.Name = "textoCuenta";
            this.textoCuenta.Size = new System.Drawing.Size(584, 35);
            this.textoCuenta.TabIndex = 4;
            this.textoCuenta.Text = "Cuenta ES 034 3..";
            this.textoCuenta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textoImporte
            // 
            this.textoImporte.BackColor = System.Drawing.Color.Transparent;
            this.textoImporte.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textoImporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.textoImporte.Location = new System.Drawing.Point(0, 103);
            this.textoImporte.Name = "textoImporte";
            this.textoImporte.Size = new System.Drawing.Size(584, 79);
            this.textoImporte.TabIndex = 3;
            this.textoImporte.Text = "Saldo 20€";
            this.textoImporte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConsultarSaldoGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(582, 368);
            this.Controls.Add(this.aceptarBtn);
            this.Controls.Add(this.textoCuenta);
            this.Controls.Add(this.salirBtn);
            this.Controls.Add(this.atrasBtn);
            this.Controls.Add(this.textoImporte);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Name = "ConsultarSaldoGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label entidadTBox;
        private System.Windows.Forms.Button salirBtn;
        private System.Windows.Forms.Button atrasBtn;
        private System.Windows.Forms.Button aceptarBtn;
        private System.Windows.Forms.Label textoCuenta;
        private System.Windows.Forms.Label textoImporte;
    }
}

