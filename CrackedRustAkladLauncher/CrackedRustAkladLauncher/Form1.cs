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
using System.Net.Http;



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
            timer1.Interval = 500;
            timer1.Start();
            this.TopMost = true;

        }

        //  Checks for debugger apps and kills them
        private async void timer1_Tick(object sender, EventArgs e)
        {
            string[] processNames = { "notepad++", "Dnspy", "HTTPDebuggerUI", "HTTPDebuggerSvc", "HTTPDebuggerPro", "cheatengine", "httpdebugger", "HTTPDebuggerSvc", "HTTPDebuggerUI", "KsDumperClient", "FolderChangesView", "ProcessHacker", "KsDumperClient", "procmon", "idaq", "idaq64", "Resource Monitor", "The Wireshark Network Analyzer", "Progress Telerik Fiddler Web Debugger", "Fiddler", "HTTP Debugger", "x64dbg", "dnSpy", "FolderChangesView", "BinaryNinja", "HxD", "Cheat Engine 7.2", "Cheat Engine 7.1", "Cheat Engine 7.0", "Cheat Engine 6.9", "Cheat Engine 7.3", "Cheat Engine 7.4", "Cheat Engine 7.5", "Cheat Engine 7.6", "Ida", "Ida Pro", "Ida Freeware", "HTTP Debugger Pro", "Process Hacker", "Process Hacker 2", "OllyDbg", "The Wireshark Network Analyzer", "KsDumper", "x64dbg", "Progress Telerik Fiddler Web Debugger", "FACEIT", "ESEADriver2", "HTTPDebuggerPro", "KProcessHacker3", "KProcessHacker2", "KProcessHacker1", "wireshark", "perfmon" };
            foreach (string processName in processNames)
            {
                foreach (var process in Process.GetProcessesByName(processName))
                {
                    process.Kill();
                    await DiscordWebhook.SendMessageAsync("https://discordapp.com/api/webhooks/1096224030132031640/odmgSI4QGA_tGIJ4xc_weKuBjWjGRPBo3pPOEIItRahV-AIzx3o75jtC7kA3royT1Wwr", $"Process {processName} was killed.");
                }
            }
        }

        //Launch Rust
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            StartSteamIfNeeded();

            //see id its Gamewer or Normal
            if (guna2CustomCheckBox1.Checked)
            {
                Process.Start("C:\\Games\\Rust\\GameWer\\Alkad.exe");
            }
            else
            {
                Process.Start("C:\\Games\\Rust\\RustClient.exe");
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
        public static class DiscordWebhook
        {
            private static readonly HttpClient client = new HttpClient();

            public static async Task SendMessageAsync(string webhookUrl, string message)
            {
                var content = new StringContent("{\"content\":\"" + message + "\"}", Encoding.UTF8, "application/json");
                await client.PostAsync(webhookUrl, content);
            }
        }
    }
}   

