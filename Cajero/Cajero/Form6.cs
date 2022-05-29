using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cajero
{
    public partial class ConsultarSaldoGUI : Form
    {
        SQLUtilitiesClass s = new SQLUtilitiesClass();

        private String idCuenta;
        private int tipo;

        public ConsultarSaldoGUI(String idCuenta)
        {
            InitializeComponent();
            this.idCuenta = idCuenta;
            this.textoImporte.Text = "Saldo actual: " + s.obtenerSaldo(this.idCuenta) + "€";
            this.textoCuenta.Text = s.getIbanPorCuenta(this.idCuenta);
            this.entidadTBox.Text = s.getEntidadB(this.idCuenta);

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
            MenuPrincipalGUI mpGUI = new MenuPrincipalGUI(this.idCuenta);
            this.Hide();
            mpGUI.ShowDialog();
            this.Close();
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

        public void establecerOperacion(int tipo)
        {
            switch(tipo)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
        }

    }
}
