using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cajero
{
    public partial class ImporteGUI : Form
    {
        SQLUtilitiesClass s = new SQLUtilitiesClass();

        private String idCuenta;
        private String idReceptor;
        private String money = "";
        private int tipo;

        public ImporteGUI(int tipo,String idCuenta, String receptor)
        {
            InitializeComponent();
            this.tipo = tipo;
            this.idCuenta = idCuenta;
            this.idReceptor = receptor;
            this.titularTBox.Text = s.getTitular(this.idCuenta);
            this.entidadBox.Text = s.getEntidadB(this.idCuenta);
        }

        public ImporteGUI(int tipo, String idCuenta)
        {
            InitializeComponent();
            this.tipo = tipo;
            this.idCuenta = idCuenta;
            this.titularTBox.Text = s.getTitular(this.idCuenta);
            this.entidadBox.Text = s.getEntidadB(this.idCuenta);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        
        public void cambiarPIN(String number)
        {
            var puntos = money.Count(x => x == '.');

            String[] separar;
            
            if(money.Contains(".")) //Comprueba que el tenga un . si no lo tiene el numero cambiará sin problema
            {
                separar = money.Split('.');

                if(separar[1].Length < 2) 
                    /*
                    * En este caso si que tiene un punto y aquí 
                    * decidiremos la cantidad de decimales que tendrá el numero
                    */
                {
                    if (number == ".") //Aquí comprobamos que el parametro introducido es un punto para a continuacion...
                    {
                        if (puntos < 1) //...Comprobar que solo tiene un punto.
                        {
                            this.money += number;
                        }
                    }
                    else
                    {
                        this.money += number;
                    }
                }
            }
            else
            {
                this.money += number;
            }

            this.passTxtBox.Text = money + "€";
            
        }

        private void btnCardOnClick(object sender, EventArgs e)
        {
            String btnName = ((Button)sender).Name;

            switch(btnName)
            {
                case "btnCard1":
                    this.cambiarPIN("1");
                    break;
                case "btnCard2":
                    this.cambiarPIN("2");
                    break;
                case "btnCard3":
                    this.cambiarPIN("3");
                    break;
                case "btnCard4":
                    this.cambiarPIN("4");
                    break;
                case "btnCard5":
                    this.cambiarPIN("5");
                    break;
                case "btnCard6":
                    this.cambiarPIN("6");
                    break;
                case "btnCard7":
                    this.cambiarPIN("7");
                    break;
                case "btnCard8":
                    this.cambiarPIN("8");
                    break;
                case "btnCard9":
                    this.cambiarPIN("9");
                    break;
                case "btnCard0":
                    this.cambiarPIN("0");
                    break;
                case "btnCardDott":
                    this.cambiarPIN(".");
                    break;
                case "btnCardBORRAR":
                    this.money = "";
                    this.passTxtBox.Text = "0€";
                    break;
            }
        }
        
        private void aceptarBtn_Click(object sender, EventArgs e) 
        {
            Double cash = double.Parse(this.money, CultureInfo.GetCultureInfo("en-GB"));
            
            ConfirmarOperacionGUI coGUI = new ConfirmarOperacionGUI(this.tipo, cash, this.idCuenta, idReceptor);
            this.Hide();
            coGUI.ShowDialog();
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
    }
}
