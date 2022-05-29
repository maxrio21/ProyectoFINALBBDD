using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;


namespace Cajero
{
    public partial class IntroducirCuentaTGUI : Form
    {
        private String idEmisor;
        private String idReceptor;
        public IntroducirCuentaTGUI(String idEmisor)
        {
            InitializeComponent();
            this.idEmisor = idEmisor;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void onHoverButton(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button btn = (Button)sender;
                btn.FlatAppearance.MouseOverBackColor = System.Drawing.ColorTranslator.FromHtml("#01cee8");
                btn.ForeColor = ColorTranslator.FromHtml("#fafafa");
            }
        }

        private void onLeaveButton(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button btn = (Button)sender;
                btn.ForeColor = Color.Black;
            }
        }

        private void aceptarBtn_Click(object sender, EventArgs e)
        {
            SQLUtilitiesClass sql = new SQLUtilitiesClass();
            this.idReceptor = sql.getCuentaPorIban(this.ibanBox.Text);
            Console.WriteLine(idReceptor);
            sql.getConnection().Close();

            if(idReceptor == null)
            {
                this.tarjetaLabel.Text = "La cuenta asociada no existe.";
            }
            else
            {
                if(idEmisor == idReceptor)
                {
                    this.tarjetaLabel.Text = "No puede transferirte a tu cuenta.";
                }
                else
                {
                    ImporteGUI importeGUI = new ImporteGUI(2, idEmisor, idReceptor);
                    this.Hide();
                    importeGUI.ShowDialog();
                    this.Close();
                }   
            }
        }
    }
}
