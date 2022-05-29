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
    public partial class MenuPrincipalGUI : Form
    {
        SQLUtilitiesClass s = new SQLUtilitiesClass();

        String idCuenta;


        public MenuPrincipalGUI(String idCuenta)
        {
            InitializeComponent();
            this.idCuenta = idCuenta;
            this.titularTBox.Text = s.getTitular(this.idCuenta);
            this.entidadBox.Text = s.getEntidadB(this.idCuenta);   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {
             ImporteGUI importeGUI = new ImporteGUI(0,this.idCuenta, this.idCuenta);
             this.Hide();
             importeGUI.ShowDialog();
             this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            ImporteGUI importeGUI = new ImporteGUI(1, this.idCuenta, this.idCuenta);
            this.Hide();
            importeGUI.ShowDialog();
            this.Close();
        }

        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            Ultimas10TransaccionesGUI importeGUI = new Ultimas10TransaccionesGUI(this.idCuenta);
            this.Hide();
            importeGUI.ShowDialog();
            this.Close();
        }

        private void btnTransferencia_Click(object sender, EventArgs e)
        {
            IntroducirCuentaTGUI transferGUI = new IntroducirCuentaTGUI(this.idCuenta);
            this.Hide();
            transferGUI.ShowDialog();
            this.Close();
        }

        private void btnSaldo_Click(object sender, EventArgs e)
        {
            ConsultarSaldoGUI copGUI = new ConsultarSaldoGUI(this.idCuenta);
            this.Hide();
            copGUI.ShowDialog();
            this.Close();
        }
    }
}
