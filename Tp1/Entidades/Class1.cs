using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        public static double Operar(Numero num1, Numero num2, string operador)
        {

            switch (operador)
            {
                case "+":
                    return num1 + num2;
                case "-":
                    if (operador == ValidarOperador('-'))
                    {
                        return num1 - num2;
                    }
                    return num1 + num2;
                case "*":
                    if (operador == ValidarOperador('*'))
                    {
                        return num1 * num2;
                    }
                    return num1 + num2;
                case "/":
                    if (operador == ValidarOperador('/'))
                    {
                        return num1 / num2;
                    }
                    return num1 + num2;
                default:
                    return num1 + num2;
            }
        }

        private static string ValidarOperador(char operador)
        {
            switch (operador)
            {
                case '+':
                    return "+";
                case '-':
                    return "-";
                case '*':
                    return "*";
                case '/':
                    return "/";
                default:
                    return "+";
            }
        }
    }

    public class Numero
    {
        private double numero;

        public Numero()
        {
            this.numero = 0;
        }
        public Numero(double numero)
        {
            this.numero = numero;
        }
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }

        public string SetNumero
        {
            set
            {
                double auxN = ValidarNumero(value);

                if (auxN != 0)
                {
                    numero = auxN;
                }

            }
        }
        private bool EsBinario(string binario)
        {
            for (int i = 0; i < binario.Length; i++)
            {
                if (binario.Substring(i,1) != "0" && binario.Substring(i, 1) != "1")
                {
                    return false;
                }
            }
            return true;
        }

        public string BinarioDecimal(string binario)
        {
            double j = 0;
            double acumulador = 0;            

            if (EsBinario(binario) == false)
            {
                return "Valor inválido!!";
            }
            else
            {
                for (int i = binario.Length; i > 0; i--)
                {
                    acumulador = (double)(acumulador + (double.Parse(binario.Substring(i - 1, 1)) * Math.Pow(2, j)));
                    j++;
                }
                return acumulador.ToString();
            }
        }

        public string DecimalBinario(double numero)
        {
            int aux;
            String s = "";
            if (numero < 1)
            {
                return "Error";
            }

            aux = (int)numero;


            while (aux > 0)
            {
                if (aux % 2 == 0)
                {
                    s = "0" + s;
                }
                else
                {
                    s = "1" + s;
                }
                aux = (int)(aux / 2);
            }
            return s;
        }

        public string DecimalBinario(string numero)
        {
            double n = double.Parse(numero);

            return DecimalBinario(n);
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            return n1.numero / n2.numero;
        }

        double ValidarNumero(string strNumero)
        {
            double.TryParse(strNumero, out double n);

            return n;
        }
    }
}
