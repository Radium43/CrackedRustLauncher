using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace CrackedRustAkladLauncher
{
    public partial class Form1 : Form
    {
        //InitializeComponent
        public Form1()
        {
            InitializeComponent();
        }

        //Always on Top and Starts the Timer
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            this.TopMost = true;
        }

        //Refreshes The Aplication
        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        //Launch Rust
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            StartSteamIfNeeded();

            //see id its Gamewer or Normal
            if (guna2CustomCheckBox1.Checked)
            {
                Process.Start("C:\\Games\\Rust\\aklad.exe");
            }
            else
            {
                Process.Start("C:\\Games\\Rust\\Rustclient.exe");
            }
        }

        //Exits the Aplication
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //check if Steam is Running if Not starts it
        private void StartSteamIfNeeded()
        {
            // Check if steam.exe is running
            var steamProcesses = Process.GetProcessesByName("steam");
            if (steamProcesses.Length == 0)
            {
                // If steam.exe is not running, start it
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string steamPath = Path.Combine(appDataPath, "Microsoft\\Windows\\Start Menu\\Programs\\Steam\\Steam");
                Process.Start(steamPath);
            }
        }
        //Minimizes the Window
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        
        //if RustClient is Running Then Close The Launcher
        private void CheckRustClientAndExitIfNeeded()
        {
            // Check if Rustclient.exe is running
            var rustClientProcesses = Process.GetProcessesByName("Rustclient");
            if (rustClientProcesses.Length > 0)
            {
                // If Rustclient.exe is running, exit the application
                Application.Exit();
            }
        }



       

    }
}
