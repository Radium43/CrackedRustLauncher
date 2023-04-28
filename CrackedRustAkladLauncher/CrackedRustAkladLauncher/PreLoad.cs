using Guna.UI2.WinForms;
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

namespace CrackedRustAkladLauncher
{
    public partial class PreLoad : Form
    {
        public PreLoad()
        {
            InitializeComponent();
            Task.Run(PreStart);

        }

        private void Form_Load(object sender, EventArgs e)
        {
            TopMost = true;
        }

        private void PreStart()
        {
            do
            {
                Thread.Sleep(100);
                guna2CircleProgressBar1.Value++;
            } 
            while (guna2CircleProgressBar1.Value < guna2CircleProgressBar1.Maximum);

            if (guna2CircleProgressBar1.Value == 100)
            {
                this.Hide();
                Form1 form1 = new Form1();
                form1.Show();
                
            }
        }

        private void guna2CircleProgressBar1_ValueChanged(object sender, EventArgs e)
        {
           

        }

        
    }
}
