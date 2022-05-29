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
    public partial class ConfirmarOperacionGUI : Form
    {
        private SQLUtilitiesClass s = new SQLUtilitiesClass();
        private String idCuenta;
        private String receptor;
        private int tipo;
        private double dinero;

        public ConfirmarOperacionGUI(int tipo, double dinero, String idCuenta)
        {
            InitializeComponent();
            this.idCuenta = idCuenta;
            this.tipo = tipo;
            this.dinero = dinero;
            this.establecerOperacion();
        }

        public ConfirmarOperacionGUI(int tipo, double dinero, String idCuenta, String receptor)
        {
            InitializeComponent();
            this.idCuenta = idCuenta;
            this.receptor = receptor;
            this.tipo = tipo;
            this.dinero = dinero;
            this.establecerOperacion();
        }
     
        private void aceptarBtn_Click(object sender, EventArgs e)
        {
            s.realizarOperacion(this.idCuenta, this.receptor, this.dinero, this.tipo);
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

        private void textoCuenta_Click(object sender, EventArgs e)
        {

        }

        private void establecerOperacion()
        {
            switch(this.tipo)
            {
                case 0:
                    this.textoImporte.Text = "¿Deseas retirar " + this.dinero +"€ de tu cuenta?";
                    this.textoCuenta.Text = s.getIbanPorCuenta(this.receptor);
                    break;
                case 1:
                    this.textoImporte.Text = "¿Deseas ingresar " + this.dinero + "€ a tu cuenta?";
                    this.textoCuenta.Text = s.getIbanPorCuenta(this.receptor);
                    break;
                case 2:
                    this.textoImporte.Text = "¿Deseas transferir " + this.dinero + "€ de tu cuenta?";
                    this.textoCuenta.Text = s.getIbanPorCuenta(this.receptor);
                    break;
            }
        }

        private void textoCuenta_Click_1(object sender, EventArgs e)
        {

        }
    }
}
