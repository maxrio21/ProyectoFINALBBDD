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
    public partial class IntroducirTarjetaGUI : Form
    {
        public IntroducirTarjetaGUI()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aceptarBtn_Click(object sender, EventArgs e)
        {
            SQLUtilitiesClass sql = new SQLUtilitiesClass();
            String password = sql.getPassword(this.tarjetaBox.Text);
            sql.getConnection().Close();

            if(password == null)
            {
                this.tarjetaLbl.Text = "Lectura incorrecta.";
            }
            else
            {
                IntroducirTarjetaPINGUI itPINGUI = new IntroducirTarjetaPINGUI(password, tarjetaBox.Text);
                this.Hide();
                itPINGUI.ShowDialog();
                this.Close();
            }
        }

        private void tarjetaBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
