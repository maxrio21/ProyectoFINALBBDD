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
    public partial class Ultimas10TransaccionesGUI : Form
    {
        private String idCuenta;

        public Ultimas10TransaccionesGUI(String idCuenta)
        {
            InitializeComponent();
            this.idCuenta = idCuenta;
            mostrarMovimientos();
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

        private void atrasBtn_Click(object sender, EventArgs e)
        {
            MenuPrincipalGUI mpGUI = new MenuPrincipalGUI(this.idCuenta);
            this.Hide();
            mpGUI.ShowDialog();
            this.Close();
        }

        private void salirBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        public void mostrarMovimientos()
        {
            SQLUtilitiesClass s = new SQLUtilitiesClass();

            NpgsqlDataReader reader = s.ultimosMovimientos(idCuenta);

            if(reader.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(reader);
                tablaDatos.DataSource = dt;
            }
        }

        private void salirBtn_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void atrasBtn_Click_1(object sender, EventArgs e)
        {
            MenuPrincipalGUI mpGUI = new MenuPrincipalGUI(this.idCuenta);
            this.Hide();
            mpGUI.ShowDialog();
            this.Close();
        }
    }
}
