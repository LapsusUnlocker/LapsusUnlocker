using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.IO.Ports;
using System.Windows.Forms;
using System.Runtime.InteropServices.ComTypes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml;
using System.Drawing.Text;

namespace MotoKeyPro
{
    public partial class Form1 : Form
    {

        public static string tooldir = Environment.CurrentDirectory + "\\";
        public static string datadir = tooldir + "data\\";
        public static string modeldir = tooldir + "models\\";
        public static string qbootmtk = datadir + "mtk\\qboot.exe ";
        public static string qbootqcom = datadir + "qcom\\qboot.exe";
        public static string qbootspd = datadir + "spd\\qboot.exe";
        public static string fat = datadir + "blank-flash.bat";
        public static string img = datadir + "singleimage.bin";
        public static string adb = datadir + "apk_debug, apk ";      
        public static string models;
        XmlDocument xmlDoc = new XmlDocument();
        public Form1()
        {
            InitializeComponent();
            var process = new Process();

        }

        private void modellister()
        {
            string[] lineOfContents = File.ReadAllLines(models);
            MotoMDL.Items.Clear();
            MotoMDL.Text = " ";
            SamsungMDL.Items.Clear();
            SamsungMDL.Text = " ";
            foreach (var line in lineOfContents)

            {
                string[] tokens = line.Split(',');

                MotoMDL.Items.Add(tokens[0]);
                SamsungMDL.Items.Add(tokens[0]);
            }
           
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            { 
            
            
        }
    

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MTKc.Checked)
            {
                cmd(qbootmtk, img);
            }
            if (SPDc.Checked)
            {
                cmd(qbootspd, img);
            }
            if (QCOMc.Checked)
            {
                cmd(qbootqcom, img);
            }
            
        }
        private void cmd(string cm, string arg)
        {
            runProcess("cmd.exe", "/c " + cm + " " + arg);
        }
        private void runProcess(string cmd, string args)
        {

            Process proc = new Process();
            proc.StartInfo.FileName = cmd;
            proc.StartInfo.Arguments = args;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.WorkingDirectory = datadir;
            proc.EnableRaisingEvents = true;
            proc.Start();
            proc.OutputDataReceived += Proc_OutputDataReceived;
            proc.ErrorDataReceived += Proc_OutputDataReceived;
            //proc.data
            //string ss = proc.StandardOutput.ReadToEnd();
            proc.BeginOutputReadLine();
            proc.BeginErrorReadLine();
            //  Console.WriteLine(proc.read);
            //proc.WaitForExit();
        }
        private void Proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                string data = e.Data;
                Console.WriteLine(data);
                updateConsole(data);
            }
            else
            {
                updateConsole("Operation Complete");
            }
            //  
        }
        private void updateConsole(string data)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                textBox2.Text += $"{data}{Environment.NewLine}";
                textBox2.SelectionStart = textBox2.Text.Length;
                textBox2.ScrollToCaret();

                if (data.ToLower().Contains("waiting"))
                {
                    textBox2.Text += $"{"Please Connect device.."}{Environment.NewLine}";
                    textBox2.SelectionStart = textBox2.Text.Length;
                    textBox2.ScrollToCaret();
                }
            });

        }

        private void StopBF_Click(object sender, EventArgs e)
        {
            killproc("qboot");
        }
        private void killproc(string proc)
        {

            foreach (var process in Process.GetProcessesByName(proc))
            {
                process.Kill();
            }

        }

        private void MTKc_CheckedChanged(object sender, EventArgs e)
        {
            models = modeldir + "mtk.txt";
            modellister();
        }

        private void SPDc_CheckedChanged(object sender, EventArgs e)
        {
            models = modeldir + "spd.txt";
            modellister();
        }

        private void QCOMc_CheckedChanged(object sender, EventArgs e)
        {
            models = modeldir + "qcom.txt";
            modellister();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btnClosed_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MotoMDL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void Frpc_CheckedChanged(object sender, EventArgs e)
        {
            models = modeldir + "samsung.txt";
            modellister();
        }
        XmlDocument newXmlDocument = new XmlDocument();

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        // Crear la estructura del archivo (nodos, atributos, etc.) 
        // ..
    }
}
