using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork
{
    public partial class Splash : Form
    {
        public int count = 0;
        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            tmrProg.Start();
        }

        private void tmrProg_Tick(object sender, EventArgs e)
        {
            if (count == 6)
            {
                tmrProg.Stop();
                frmLogin login = new frmLogin();
                login.Show();
                this.Close();
            }
            else
            {
                count += 1;
                if(label1.Text == "Loading")
                {
                    label1.Text = "Loading.";
                }
                else if (label1.Text == "Loading.")
                {
                    label1.Text = "Loading..";
                }
                else if (label1.Text == "Loading..")
                {
                    label1.Text = "Loading...";
                }
                else
                {
                    label1.Text = "Loading";
                }
            }
        }
    }
}
