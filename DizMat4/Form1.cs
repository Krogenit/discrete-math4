using DeezMat4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DizMat4
{
    public class GameRunner
    {
        private int a, b, c;
        public GameRunner(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public void runGame()
        {
            try
            {
                using (Core game = new Core(a, b, c))
                {
                    game.Run();
                }
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }
    }
    public partial class Form1 : Form
    {
        private int a, b, c;
        Thread oThread;
        public Form1()
        {
            InitializeComponent();
            //textBox1.Text = "3x-3y+1";
            //readText();
            //GameRunner gr = new GameRunner(a, b, c);
            //Thread oThread = new Thread(new ThreadStart(gr.runGame));
            //oThread.Start();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            readText();
            if (oThread != null)
                oThread.Abort();
            GameRunner gr = new GameRunner(a, b, c);
            oThread = new Thread(gr.runGame);
            oThread.Start();
            //Close();
        }
        private void random_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            a = int.Parse(toDouble(r.Next(10) - 5));
            b = int.Parse(toDouble(r.Next(10) - 5));
            c = int.Parse(toDouble(r.Next(10) - 5));
            if (oThread != null)
                oThread.Abort();
            GameRunner gr = new GameRunner(a, b, c);
            oThread = new Thread(gr.runGame);
            oThread.Start();
            //Close();
        }
        private string toDouble(int x)
        {
            if (x < 0) { return "-" + Convert.ToString(x * -1, 2); }
            else { return Convert.ToString(x, 2); }
        }

        private int toTen(string x)
        {
            if (x[0].Equals('-'))
            {
                string s1 = x.Substring(1, x.Length - 1);
                return Convert.ToInt32(s1, 2) * -1;
            }
            else
            {
                return Convert.ToInt32(x, 2);
            }
        }
        private void readText()
        {
            try
            {
                string s = textBox1.Text;
                int i = 0;
                string temp = "";
                while (!s[i].Equals('x'))
                {
                    temp += s[i];
                    i += 1;
                }
                if (i != 0)
                {
                    a = int.Parse(toDouble(int.Parse(temp)));
                }
                else
                    a = 1;
                i += 1;
                temp = "";
                while (!s[i].Equals('y'))
                {
                    temp += s[i];
                    i += 1;
                }
                if (i != 2)
                {
                    b = int.Parse(toDouble(int.Parse(temp)));
                }
                else
                {
                    if (s[i - 1].Equals('-'))
                        b = -1;
                    else
                        b = 1;
                }
                i += 1;
                temp = "";
                while (i < s.Length)
                {
                    temp += s[i];
                    i += 1;
                }
                c = int.Parse(toDouble(int.Parse(temp)));
            }
            catch (Exception ex)
            {
                textBox1.Text = "Неправильная формула";
            }
        }
    }
}
