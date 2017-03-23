using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Newthon
{
    public partial class Form1 : Form
    {
        Double[] arrayX = new Double[5];
        Double[] arrayD = new Double[5];
        Double[] arrayResultados = new Double[3];
        Double x = 0;
        byte contador = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                arrayX[0] = Double.Parse(textBox1.Text);
                arrayX[1] = Double.Parse(textBox2.Text);
                arrayX[2] = Double.Parse(textBox3.Text);
                arrayX[3] = Double.Parse(textBox4.Text);
                arrayX[4] = Double.Parse(textBox5.Text);
                x = Double.Parse(textBox13.Text);

                arrayD[0] = Double.Parse(textBox7.Text);
                arrayD[1] = Double.Parse(textBox8.Text);
                arrayD[2] = Double.Parse(textBox9.Text);
                arrayD[3] = Double.Parse(textBox10.Text);
                arrayD[4] = Double.Parse(textBox11.Text);

                contador = 0;
                if (arrayX[0] != 0)
                {
                    contador += 1;
                }
                if (arrayX[1] != 0)
                {
                    contador += 1;
                }
                if (arrayX[2] != 0)
                {
                    contador += 1;
                }
                if (arrayX[3] != 0)
                {
                    contador += 1;
                }
                if (arrayX[4] != 0)
                {
                    contador += 1;
                }
                string aux1 = textBox1.Text;
               
                
                double auxiliar = 0;
                switch (contador)
                {
                    case 2:
                        auxiliar = lineal(x);
                        textBox14.Text = auxiliar.ToString();
                        break;
                    case 3:
                        lineal(x);
                        auxiliar = cuadratica(x);
                        textBox14.Text = auxiliar.ToString();
                        break;

                    case 4:
                        lineal(x);
                        cuadratica(x);
                        auxiliar = newton4(x);
                        textBox14.Text = auxiliar.ToString();
                        break;

                    case 5:
                        lineal(x);
                        cuadratica(x);
                        newton4(x);
                        auxiliar = newton5(x);
                        textBox14.Text = auxiliar.ToString();
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Llena todas las casillas con numeros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private double lineal(double x)
        {
            double resultado = 0;
            resultado = arrayD[0] + (((arrayD[1] - arrayD[0]) / (arrayX[1] - arrayX[0])) * (x - arrayX[0]));
            arrayResultados[0] = resultado;
            return resultado;
        }

        private double cuadratica(double x)
        {
            double resultado;
            resultado = arrayResultados[0] + (((((arrayD[2] - arrayD[1]) / (arrayX[2] - arrayX[1])) - ((arrayD[1] - arrayD[0]) / (arrayX[1] - arrayX[0]))) / (arrayX[2] - arrayX[0])) * ((x - arrayX[1]) * (x - arrayX[0])));
            arrayResultados[1] = resultado;
            return resultado;
        }

        private double newton4(double x)
        {
            double resultado, d123, d012, auxiliar1;
            d123 = (((arrayD[3] - arrayD[2]) / (arrayX[3] - arrayX[2])) - ((arrayD[2] - arrayD[1]) / (arrayX[2] - arrayX[1]))) / (arrayX[3] - arrayX[1]);
            d012 = (((arrayD[2] - arrayD[1]) / (arrayX[2] - arrayX[1])) - ((arrayD[1] - arrayD[0]) / (arrayX[1] - arrayX[0]))) / (arrayX[2] - arrayX[0]);
            auxiliar1 = ((x - arrayX[0]) * (x - arrayX[1]) * (x - arrayX[2]));
            resultado = arrayResultados[1] + ((d123 - d012) / (arrayX[3] - arrayX[0])) * auxiliar1;
            arrayResultados[2] = resultado;
            return resultado;
        }

        private double newton5(double x)
        {
            double resultado, d23, d12, d123, d10, d012, d0123, auxiliar1, auxiliar2;
            d23 = (arrayD[3] - arrayD[2]) / (arrayX[3] - arrayX[2]);
            d12 = (arrayD[2] - arrayD[1]) / (arrayX[2] - arrayX[1]);
            d123 = (d23 - d12) / (arrayX[3] - arrayX[1]);
            d10 = (arrayD[1] - arrayD[0]) / (arrayX[1] - arrayX[0]);
            d012 = (d12 - d10) / (arrayX[2] - arrayX[0]);
            d0123 = (d123 - d012) / (arrayX[3] - arrayX[0]);
            double d234, d34, d1234;
            d34 = (arrayD[4] - arrayD[3]) / (arrayX[4] - arrayX[3]);
            d234 = (d34 - d23) / (arrayX[4] - arrayX[2]);
            d123 = (d23 - d12) / (arrayX[3] - arrayX[1]);
            d1234 = (d234 - d123) / (arrayX[4] - arrayX[1]);
            auxiliar1 = (d1234 - d0123) / (arrayX[4] - arrayX[0]);
            auxiliar2 = (x - arrayX[0]) * (x - arrayX[1]) * (x - arrayX[2]) * (x - arrayX[3]);
            resultado = arrayResultados[2] + (auxiliar1 * auxiliar2);
            return resultado;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
        }

    }
}
