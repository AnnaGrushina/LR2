
// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//Возведение в степень
        {
            int chislom, step, modul, result, b;
            try
            {
                chislom = Convert.ToInt32(textBox1.Text);
                step = Convert.ToInt32(textBox2.Text);
                modul = Convert.ToInt32(textBox3.Text);
            }
            catch
            {
                return;
            }

            result = 1;
            b = chislom % modul;

            while (step > 0)
            {
                if ((step & 1) == 1)
                {
                    result = result * b;
                    result = result % modul;
                }
                b = b * b;
                b = b % modul;
                step = step >> 1;

            }
            textBox4.Text = result.ToString();

        }

        private void button2_Click(object sender, EventArgs e)//Нахождение НОД
        {
            int first, second, temp = 0;
            try
            {
                first = Convert.ToInt32(textBox5.Text);
                second = Convert.ToInt32(textBox6.Text);
            }
            catch
            {
                return;
            }

            if (first < second) ;
            {
                temp = first;
                first = second;
                second = temp;
            }
            while (true)
            {
                temp = first % second;
                first = second;
                second = temp;

            }
            textBox7.Text = first.ToString();

        }

        private void button3_Click(object sender, EventArgs e)//Мультипликативная инверсия
        {
            int a0 = 1;
            int a1 = 0;
            int b0 = 0;
            int b1 = 1;
            int p, q;
            int temp, atemp, btemp, temp2;
            int nod = 0;
            int chislo, modul;

            if (textBox8.Text == null || textBox9.Text == null) return;

            try
            {
                chislo = Convert.ToInt32(textBox8.Text);
                modul = Convert.ToInt32(textBox9.Text);
            }
            catch
            {
                return;
            }
            temp = chislo;
            temp = temp;
            for (int i = chislo; i > 0;)
            {
                if (chislo % i == 0)
                {
                    if (modul % i == 0)
                    {
                        nod = i;
                        break;
                    }
                }
            }

            if (nod != 1)
            {
                textBox10.Text = "Не существует";
                return;
            }

            if (chislo < modul)
            {
                temp2 = chislo;
                chislo = modul;
                modul = temp2;
            }
            while (modul != 0)
            {

                p = chislo % modul;
                q = chislo / modul;

                atemp = a1;
                a1 = a0 - q * a1;
                a0 = atemp;

                btemp = b1;
                b1 = b0 - q * b1;
                b0 = btemp;
                temp2 = chislo % modul;
                chislo = modul;
                modul = temp2;
            }
            if (b0 < 0) b0 = b0 + temp;
            textBox10.Text = b0.ToString();

        }

        private void button4_Click(object sender, EventArgs e)//Тест Ферма
        {
            int chislo;
            try
            {
                chislo = Convert.ToInt32(textBox11.Text);
            }
            catch
            {
                return;
            }
            BigInteger a;

            for (int i = 0; i < 100; i++)
            {
                Random rnd = new Random();

                a = rnd.Next(1, chislo - 1);
                BigInteger x = BigInteger.ModPow(a, (chislo - 1), chislo);

                if (x != 1)
                {
                    textBox12.Text = "Число не простое";
                    return;
                }
            }
            textBox12.Text = "Число простое";
        }

        private void button5_Click(object sender, EventArgs e)//Тест Миллера-Рабина
        {
            int chislo;
            if (textBox13.Text == null) return;

            try
            {
                chislo = Convert.ToInt32(textBox13.Text);
            }
            catch
            {
                return;
            }

            if (chislo < 2)
            {
                textBox14.Text = "Число не простое";
                return;
            }
            if (chislo == 2)
            {
                textBox14.Text = "Число простое";
                return;
            }
            if (chislo % 2 == 0)
            {
                textBox14.Text = "Число не простое";
                return;
            }
            int r = 0, d = chislo - 1;
            while (d % 2 == 0)
            {
                d /= 2;
                r++;
            }

            var rand = new Random();

            for (int i = 0; i < 100; i++)
            {
                int a = rand.Next(2, (int)(chislo - 1));
                BigInteger x = BigInteger.ModPow(a, d, chislo);
                if (x == 1 || x == chislo - 1)
                    continue;
                for (int j = 0; j < r - 1; j++)
                {
                    x = BigInteger.ModPow(x, 2, chislo);
                    if (x == 1)
                    {
                        textBox14.Text = "Число не простое";
                        return;
                    }
                    if (x == chislo - 1)
                        break;
                }
                if (x != chislo - 1)
                {
                    textBox14.Text = "Число не простое";
                    return;
                }
            }
            textBox14.Text = "Число простое";
            return;
        }

        private void button6_Click(object sender, EventArgs e)//Генерация больших простых чисел
        {
            int chislo;
            int n;
            string output = null;
            if (textBox15.Text == null) return;

            try
            {
                chislo = Convert.ToInt32(textBox15.Text);
            }
            catch
            {
                return;
            }

            int i = 0;
            Random rnd = new Random();
            while (i != chislo)
            {
                StringBuilder stringBuil = new StringBuilder(9);
                
                for (int j = 0; j < stringBuil.Capacity; j++)
                {
                    stringBuil.Append(rnd.Next(0, 9));
                }

                n = Convert.ToInt32(stringBuil.ToString());
                if (isPrime(n))
                {
                    output = output + (i + 1) + ' ' + n + "\r\n";
                    i++;
                }

            }
            textBox16.Text = output;
        }

        public Boolean isPrime(int n)
        {
            if (n < 2)
            {
                //textBox4.Text = "Число не простое";
                return false;
            }
            if (n == 2)
            {
                //textBox4.Text = "Число простое";
                return true;
            }
            if (n % 2 == 0)
            {
                //textBox4.Text = "Число не простое";
                return false;
            }
            int r = 0, d = n - 1;
            while (d % 2 == 0)
            {
                d /= 2;
                r++;
            }

            var rand = new Random();

            for (int i = 0; i < 100; i++)
            {
                int a = rand.Next(2, (int)(n - 1));
                BigInteger x = BigInteger.ModPow(a, d, n);
                if (x == 1 || x == n - 1)
                    continue;
                for (int j = 0; j < r - 1; j++)
                {
                    x = BigInteger.ModPow(x, 2, n);
                    if (x == 1)
                    {
                        //textBox4.Text = "Число не простое";
                        return false;
                    }
                    if (x == n - 1)
                        break;
                }
                if (x != n - 1)
                {
                    //textBox4.Text = "Число не простое";
                    return false;
                }
            }


            return true;
        }
    }
}
