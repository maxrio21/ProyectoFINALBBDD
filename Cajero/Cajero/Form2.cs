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
    public partial class IntroducirTarjetaPINGUI : Form
    {
        private String tarjetaId;

        private String password = "";
        private String pin = "";
        private String pinTxt = "";

        public IntroducirTarjetaPINGUI(String password, String tarjetaId)
        {
            this.password = password;
            this.tarjetaId = tarjetaId;
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
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

        private void onPINLeaveButton(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button btn = (Button)sender;
                btn.ForeColor = System.Drawing.ColorTranslator.FromHtml("#01cee8");
                btn.BackColor = ColorTranslator.FromHtml("#ffffff");

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

        public void cambiarPIN(String number)
        {
            if(this.pin.Length < 4)
            {
                this.pin += number;
                this.pinTxt += "● ";
                

                this.passTxtBox.Text = pinTxt;
            }
        }

        public void borrarPIN()
        {
            this.pin = "";
            this.pinTxt = "";

        }

        private void btnCardOnClick(object sender, EventArgs e)
        {
            String btnName = ((Button)sender).Name;

            switch (btnName)
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
                case "btnCardBORRAR":
                    this.pin = "";
                    this.pinTxt = "";
                    this.passTxtBox.Text = "";
                    break;
            }
        }

        private void aceptarBtn_Click(object sender, EventArgs e)
        {
            if (this.pin == password)
            {
                SQLUtilitiesClass sql = new SQLUtilitiesClass();
                MenuPrincipalGUI mpGUI = new MenuPrincipalGUI(sql.getCuenta(this.tarjetaId));
                this.Hide();
                mpGUI.ShowDialog();
                this.Close();
            }
            else
            {
                this.passTxtBox.Text = "PIN incorrecto";
            }
        }
    }
}
