using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;

namespace EzGoodbyeDPI
{
    public partial class Form1 : Form
    {
        ~Form1()
        {
            button2_Click(null, null);
        }
        ProcessStartInfo pinfo;
        Process process = new Process();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName.StartsWith("goodbyedpi"))
                {
                    MessageBox.Show("이미 GoodbyeDPI가 실행중입니다. 종료해주세요.");
                    return;
                }
            }
            button1.Enabled = false;
            trackBar_lv.Enabled = false;
            try
            {
                if (Environment.Is64BitOperatingSystem == true)
                {
                    pinfo = new ProcessStartInfo(Application.StartupPath + "\\x86_64\\goodbyedpi.exe", "-" + trackBar_lv.Value);

                }
                else
                {
                    pinfo = new ProcessStartInfo(Application.StartupPath + "\\x86\\goodbyedpi.exe", "-" + trackBar_lv.Value);
                }
                pinfo.CreateNoWindow = true;
                pinfo.WindowStyle = ProcessWindowStyle.Hidden;
                pinfo.UseShellExecute = false;
                pinfo.RedirectStandardOutput = true;
                process.StartInfo = pinfo;
                process.Start();
                MessageBox.Show("우회 시작중");
            }
            catch (Win32Exception ex)
            {
                button1.Enabled = true;
                trackBar_lv.Enabled = true;
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(Process p in Process.GetProcesses())
            {
                if (p.ProcessName.StartsWith("goodbyedpi"))
                {
                    p.Kill();
                }
            }
            button1.Enabled = true;
            trackBar_lv.Enabled = true;
        }
    }
}
