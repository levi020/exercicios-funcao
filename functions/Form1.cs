using System;
using MathNet.Numerics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;

namespace functions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int x = 0;
        int y = 1;

        //Hipotenusa
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                lblR.Text = "Resultado: ";
                double l1 = Convert.ToDouble(txbL1.Text);
                double l2 = Convert.ToDouble(txbL2.Text);
                if (l1 == l2)
                {
                    return;
                }
                else
                {
                    double resposta = Hipotenusa(l1, l2);
                    lblR.Text += resposta.ToString("f2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                txbL1.Text = string.Empty;
                txbL2.Text = string.Empty;
            }
        }
        private double Hipotenusa(double n1, double n2)
        {
            return Math.Sqrt((n1 * n1) + (n2 * n2));
        }
        //verifica se é triangulo
        private void btnVerificar_Click(object sender, EventArgs e)
        {
            try
            {
                lblRe1.Text = "Resultado: ";
                double x = Convert.ToDouble(txbLado.Text);
                double y = Convert.ToDouble(txbLado2.Text);
                double z = Convert.ToDouble(txbLado3.Text);
                if (x == 0 || y == 0 || z == 0)
                {
                    return;
                }
                else
                {
                    bool resposta2 = Verificar(x, y, z);
                    if (resposta2 == true)
                    {
                        lblRe1.Text += "É triangulo";
                    }
                    else
                    {
                        lblRe1.Text += "Não é triangulo";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                txbLado.Text = string.Empty;
                txbLado2.Text = string.Empty;
                txbLado3.Text = string.Empty;
            }
        }
        private bool Verificar(double x, double y, double z)
        {
            if ((x + y) > z && (x + z) > y && (z + y) > x)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Bhaskara
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                lblRe2.Text = "Resultado: ";
                double a = Convert.ToDouble(txbA.Text);
                double b = Convert.ToDouble(txbB.Text);
                double c = Convert.ToDouble(txbC.Text);

                double delta = Delta(a, b, c);
                if (delta < 0)
                {
                    lblRe2.Text += "Não se é possível achar x1 e x2, pois o delta é menor que zero: " + delta.ToString();
                }
                else
                {
                    double rx1 = X1(delta, a, b, c);
                    double rx2 = X2(delta, a, b, c);

                    lblRe2.Text += "Delta: " + delta.ToString("f2") + ", e o valor de x1 è: " + rx1.ToString("f2") + ", e x2 é: " + rx2.ToString("f2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                txbA.Text = string.Empty;
                txbB.Text = string.Empty;
                txbC.Text = string.Empty;
            }
        }
        private double Delta(double x, double y, double z)
        {

            return (y * y) - 4 * x * z;
        }
        private double X1(double delta, double a, double b, double c)
        {
            b = -b;
            return (b + Math.Sqrt(delta)) / (2 * a);
        }
        private double X2(double delta, double a, double b, double c)
        {
            b = -b;
            return (b - Math.Sqrt(delta)) / (2 * a);
        }
        //nome inverso
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                lblRe3.Text = "Resultado: ";
                string name = txbName.Text;
                if (name == "")
                {
                    return;
                }
                else
                {
                    string resposta = Inverte(name);
                    lblRe3.Text += resposta;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                txbName.Text = string.Empty;
            }
        }
        private string Inverte(string nome)
        {
            char[] chars = nome.ToCharArray();
            Array.Reverse(chars);

            return new string(chars);
        }
        //jogo
        private void btnGera_Click(object sender, EventArgs e)
        {
            try
            {
                lblRe4.Text = "Resultado: ";
                int numEscolhido = Convert.ToInt32(txbNum.Text);
                if (numEscolhido <= 0 || numEscolhido > 10)
                {
                    return;
                }
                else
                {
                    int numGerado = Random();
                    if (numEscolhido == numGerado)
                    {
                        lblRe4.Text += "Parabéns você conguiu acertar, o numero gerado foi: " + numGerado.ToString() + ", e o numero escolhido foi: " + numEscolhido.ToString();

                    }
                    else
                    {
                        lblRe4.Text += "Você erou, o numero gerado foi: " + numGerado.ToString() + ", e o escolhido foi: " + numEscolhido.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                txbNum.Text = string.Empty;
            }
        }
        private int Random()
        {
            Random rand = new Random();
            return rand.Next(1, 10);
        }
        //moeda
        private void btnLanca_Click(object sender, EventArgs e)
        {
            try
            {
                lblPorcentagemCara.Text = string.Empty;
                lblPorcentagemCoroa.Text = string.Empty;
                lblVezes.Text = string.Empty;
                int num = Convert.ToInt32(txbVezesLancar.Text);
                if (num == 0 && num < 0)
                {
                    return;
                }
                else
                {
                    Num(num);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                txbNum.Text = string.Empty;
            }
        }
        private string moeda()
        {
            Random rand = new Random();
            int result = rand.Next(0, 1);
            if (result == 0)
            {
                return "cara";
            }
            else
            {
                return "coroa";
            }
        }
        private void Num(int vezes)
        {
            int cara = 0;
            int coroa = 0;
            for (int i = 0; i <= vezes; i++)
            {
                string result = moeda();
                if (result == "cara")
                {
                    cara++;
                }
                if (result == "coroa")
                {
                    coroa++;
                }
            }
            double porcetagemCara = (double)cara / vezes * 100;
            double porcetagemCoroa = (double)coroa / vezes * 100;
            lblPorcentagemCara.Text = $"Porcentagem de vezes que caiu cara: {porcetagemCara:F2}%";
            lblPorcentagemCoroa.Text = $"Porcentagem de vezes que caiu coroa: {porcetagemCoroa:F2}%";
            lblVezes.Text = $"Vezes que foi lançado: {vezes}%";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblPorcentagemCara.Text = string.Empty;
            lblPorcentagemCoroa.Text = string.Empty;
            lblVezes.Text = string.Empty;
            lblResultParImpar.Text = string.Empty;
            lblResult4.Text = string.Empty;
            ltbResult.Items.Clear();
            lblResult5.Text = string.Empty;
            lblResult6.Text = string.Empty;
            lblResult7.Text = string.Empty;
            lblResult8.Text = string.Empty;
            lblResult9.Text = string.Empty;
            lblResult11.Text = string.Empty;
            lblResposta12.Text = string.Empty;
            lblVar1.Text = x.ToString();
            lblVar2.Text = y.ToString();
        }
        //jogo de par e impar
        private void btnGerarNum_Click(object sender, EventArgs e)
        {
            try
            {
                lblResultParImpar.Text = string.Empty;
                int num = Convert.ToInt32(txbNumJogo.Text);
                if (txbNumJogo.Text == "")
                {
                    num = 1;
                }
                else if (Convert.ToInt32(txbNumJogo.Text) <= 0 || Convert.ToInt32(txbNumJogo.Text) > 10)
                {
                    return;
                }
                else
                {
                    int random = Gera();
                    bool desc = ParImpar(num, random);
                    int result = random + num;
                    if (rdbImpar.Checked)
                    {
                        if (desc == true)
                        {
                            lblResultParImpar.Text = "Você perdeu, o numero somado foi " + result + ", sendo um número par.";
                        }
                        else
                        {
                            lblResultParImpar.Text = "Você ganhou, o numero somado foi " + result + ", sendo um número impar.";

                        }
                    }
                    if (rdbPar.Checked)
                    {
                        if (desc == true)
                        {
                            lblResultParImpar.Text = "Você ganhou, o numero somado foi " + result + ", sendo um número par.";
                        }
                        else
                        {
                            lblResultParImpar.Text = "Você perdeu, o numero somado foi " + result + ", sendo um número impar.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                txbNumJogo.Text = string.Empty;
            }
        }
        private int Gera()
        {
            Random rnd = new Random();
            return rnd.Next(0, 11);
        }
        private bool ParImpar(int x, int numrandom)
        {
            int result = x + numrandom;

            if (result % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //pedra papel tesouro
        private void btnAAAA_Click(object sender, EventArgs e)
        {
            try
            {
                lblResult4.Text = string.Empty;
                int desc = Convert.ToInt32(cbbJoken.SelectedIndex);
                int result = random2();
                if (desc == 0)
                {
                    if (result == 0)
                    {
                        lblResult4.Text = "Empate, ambos escoleream pedra";
                    }
                    if (result == 1)
                    {
                        lblResult4.Text = "Você perdeu, o computador gerou papel";
                    }
                    if (result == 2)
                    {
                        lblResult4.Text = "Você ganhou o computador escolheu tesoura";
                    }
                }
                if (desc == 1)
                {
                    if (result == 0)
                    {
                        lblResult4.Text = "Você ganhou o computador escolheu pedra";
                    }
                    if (result == 1)
                    {
                        lblResult4.Text = "Empate, ambos escoleream papel";

                    }
                    if (result == 2)
                    {
                        lblResult4.Text = "Você perdeu, o computador gerou tesoura";
                    }
                }
                if (desc == 2)
                {
                    if (result == 0)
                    {
                        lblResult4.Text = "Você perdeu, o computador gerou pedra";
                    }
                    if (result == 1)
                    {
                        lblResult4.Text = "Você ganhou o computador escolheu papel";
                    }
                    if (result == 2)
                    {
                        lblResult4.Text = "Empate, ambos escoleream tesoura";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }
        private int random2()
        {
            Random rnd = new Random();
            return rnd.Next(0, 3);
        }

        private void btnCalculo_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(txbNum1.Text);
                int y = Convert.ToInt32(txbNum2.Text);
                calcular(x, y);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                txbNum1.Text = string.Empty;
                txbNum2.Text = string.Empty;
            }
        }
        private void calcular(int x, int y)
        {
            int result = x + y;
            ltbResult.Items.Add(result.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(txbPrimo.Text);
                bool par = Verificar(x);
                if (par == true)
                {
                    lblResult5.Text = "é par";
                }
                else
                {
                    lblResult5.Text = "é impar";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                txbPrimo.Text = string.Empty;
            }
        }
        private bool Verificar(int x)
        {
            if (x % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(txbFatorial.Text);
                int f = Fatorial(x);
                lblResult6.Text = f.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }
        private int Fatorial(int x)
        {

            int resultado = 1;
            while (x != 1)
            {
                resultado = resultado * x;
                x = x - 1;
            }
            return resultado;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                lblResult7.Text = string.Empty;
                double x = double.Parse(txbNumC1.Text);
                double y = double.Parse(txbNumC2.Text);
                double z = double.Parse(txbNumC3.Text);
                Comparar(x, y, z);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                txbNumC1.Text = string.Empty;
                txbNumC2.Text = string.Empty;
                txbNumC3.Text = string.Empty;
            }
        }
        private void Comparar(double x, double y, double z)
        {
            if (x > z && x > y)
            {
                lblResult7.Text = x + " è o maior";
            }
            else if (y > z && y > x)
            {
                lblResult7.Text = y + " è o maior";
            }
            else if (z > x && z > y)
            {
                lblResult7.Text = z + " è o maior";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                lblResult8.Text = string.Empty;
                double x = double.Parse(txbCal1.Text);
                string opera = txbCal2.Text;
                double y = double.Parse(txbCal3.Text);
                Calculadora(x, opera, y);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                txbCal1.Text = string.Empty;
                txbCal2.Text = string.Empty;
                txbCal3.Text = string.Empty;
            }
        }
        private void Calculadora(double x, string opera, double y)
        {
            if (opera == "+")
            {
                double result = x + y;
                lblResult8.Text = x + " + " + y + " = " + result.ToString();
            }
            else if (opera == "-")
            {
                double result = x - y;
                lblResult8.Text = x + " - " + y + " = " + result.ToString();
            }
            else if (opera == "/")
            {
                double result = x / y;
                lblResult8.Text = x + " / " + y + " = " + result.ToString();
            }
            else if (opera == "*" || opera == "x")
            {
                double result = x * y;
                lblResult8.Text = x + " * " + y + " = " + result.ToString();
            }
            else
            {
                lblResult8.Text = "Nenhum operador valido";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                lblResult9.Text = string.Empty;
                string vogal = txbVogal.Text;
                Conta(vogal, out int vog, out int con);
                lblResult9.Text = "a frase: "+ vogal + $" tem {vog} vogais e {con} consoantes" +
                    $"";
            }
            catch (Exception ex)
            {

            }
            finally
            { 
                txbVogal.Text = string.Empty;
            }
        }
        private void Conta(string str, out int vog, out int con)
        {
            vog = 0;
            con = 0;

            foreach (char ch in str.ToLower())
            {
                if (char.IsLetter(ch))
                {
                    if ("aeiou".Contains(ch))
                    {
                        vog++;
                    }
                    else
                    {
                        con++;
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string frase = txbReverse.Text;
                string reversa = InverteString(frase);
                lblResult10.Text = reversa;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            { 
                txbReverse.Text = string.Empty;
            }
        }
        private string InverteString(string frase)
        {
            char[] chars = frase.ToCharArray();
            Array.Reverse(chars);

            return new string(chars);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            troca();
        }
        public void troca()
        {
            int intermediara = x;
            x = y;
            y = intermediara;
            lblVar1.Text = x.ToString();
            lblVar2.Text = y.ToString();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            x = int.Parse(txbValue1.Text);
            lblVar1.Text = x.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            y = int.Parse(txbValue2.Text);
            lblVar2.Text = y.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                lblResult11.Text = string.Empty;
                int x = int.Parse(txbBase.Text);
                int y = int.Parse(txbExpoente.Text);
                if (x == 0 || y < 0)
                {
                    return;
                }
                else
                {
                    expoente(x,y);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                txbBase.Text = string.Empty;
                txbExpoente.Text = string.Empty;
            }
        }
        private void expoente(int bas, int expoente)
        {
            double result = Math.Pow(bas , expoente);
            lblResult11.Text = result.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                lblResposta12.Text = string.Empty;
                int a = int.Parse(textBox1.Text);
                int b = int.Parse(textBox2.Text);
                int c = int.Parse(textBox3.Text);
                int d = int.Parse(textBox4.Text);
                int f = int.Parse(textBox5.Text);

                int[] array = { a, b, c, d, f };
                int result = SomarArray(array);
                lblResposta12.Text += result.ToString();
            }
            catch
            {

            }
            finally
            {
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
                textBox5.Text = string.Empty;
            }
        }
        private int SomarArray(int[] array)
        {
            int soma = 0;
            foreach (int num in array)
            {
                soma += num;
            }
            return soma;
        }
    }
}
