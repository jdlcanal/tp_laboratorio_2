using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
            this.txtNumero1.TabIndex = 0;
            this.cmbOperador.TabIndex = 1;
            this.txtNumero2.TabIndex = 2;
            this.btnOperar.TabIndex = 3;
            this.btnLimpiar.TabIndex = 4;
            this.btnCerrar.TabIndex = 5;
            this.btnConvertirABinario.TabIndex = 6;
            this.btnConvertirADecimal.TabIndex = 7;
            this.cmbOperador.Items.AddRange(new String[] { "+", "-", "*", "/" });
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtNumero1.Text) || string.IsNullOrEmpty(this.txtNumero2.Text) || string.IsNullOrEmpty(this.cmbOperador.Text))
            {
                MessageBox.Show("Error!! Ingresar los datos, por favor!", "ATENCIÓN!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                lblResultado.Text = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult rta = MessageBox.Show("¿Seguro que desea salir?", "Atención!",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (rta == DialogResult.Yes)
            {
                MessageBox.Show("Adios!!","Saliendo",MessageBoxButtons.OK,MessageBoxIcon.Information);

                this.Dispose();
            }
        }
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtNumero1.Text) || string.IsNullOrEmpty(this.txtNumero2.Text) || string.IsNullOrEmpty(this.cmbOperador.Text))
            {
                MessageBox.Show("Error!! Ingresar los datos, por favor!", "ATENCIÓN!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Numero resultado = new Numero(this.lblResultado.Text);

                this.lblResultado.Text = resultado.DecimalBinario(this.lblResultado.Text);
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtNumero1.Text) || string.IsNullOrEmpty(this.txtNumero2.Text) || string.IsNullOrEmpty(this.cmbOperador.Text))
            {
                MessageBox.Show("Error!! Ingresar los datos, por favor!", "ATENCIÓN!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Numero resultado = new Numero(this.lblResultado.Text);

                this.lblResultado.Text = resultado.BinarioDecimal(this.lblResultado.Text);
            }
        }

        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.cmbOperador.SelectedIndex=0;
            this.txtNumero2.Text = "";
            this.lblResultado.Text = "";
        }
        
        public static double Operar(string numero1, string numero2, string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);

            return Calculadora.Operar(num1, num2, operador);
        }
    }
}
