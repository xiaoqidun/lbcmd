using System;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Windows.Forms;

namespace xiaoqidun_lbcmd
{
    public partial class xiaoqidun_lbcmd : Form
    {
        public string bash = @"C:\Windows\System32\bash.exe";
        public string lbcmd = @"Directory\Background\shell\lbcmd";
        public string lbcmd_icon = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\lxss\bash.ico";
        public xiaoqidun_lbcmd()
        {
            InitializeComponent();
        }

        private void xiaoqidun_lbcmd_Load(object sender, EventArgs e)
        {
            Activate();
            TopMost = true;
            if (!File.Exists(bash))
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var key_exists = Registry.ClassesRoot.OpenSubKey(lbcmd);
            if (key_exists == null)
            {
                var key = Registry.ClassesRoot.CreateSubKey(lbcmd);
                key.SetValue(null, "在此处打开子系统命令窗口");
                key.SetValue("icon", lbcmd_icon);
                key.Close();
                var key_command = Registry.ClassesRoot.CreateSubKey(lbcmd + @"\command");
                key_command.SetValue(null, bash);
                key_command.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var key_exists = Registry.ClassesRoot.OpenSubKey(lbcmd);
            if (key_exists != null)
            {
                Registry.ClassesRoot.DeleteSubKeyTree(lbcmd, false);
            }
        }

        private void 爱特网络ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://aite.xyz/");
        }
    }
}
