using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgePodKartTest
{
    public partial class Login : Form
    {
        private Process keyboardProc { get; set; }

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Left = Top = 0;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //this.ShowInTaskbar = false;
            this.ControlBox = false;
            this.MinimumSize = this.MaximumSize;
            //this.SizeGripStyle = SizeGripStyle.Hide;

            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;

        }


         //Not Draggable
        protected override void WndProc(ref Message message)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;

            switch (message.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = message.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                        return;
                    break;
            }

            base.WndProc(ref message);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtUserName.Text) && !String.IsNullOrEmpty(txtPassword.Text))
            {
                if (String.Equals(txtPassword.Text.ToUpper(), ConfigurationManager.AppSettings.Get("userloginpass").ToUpper()))
                {
                    Anasayfa home = new Anasayfa(); // Instantiate a Form3 object.
                    home.UserName = txtUserName.Text;
                    home.Show(); // Show Form3 and
                    this.Hide(); // closes the Form2 instance.
                }
                else
                {
                    MessageBox.Show("KULLANICI ADI VEYA ŞİFRESİ DOĞRU DEĞİL, LÜTFEN TEKRAR DENEYİNİZ!");
                    txtPassword.Text = "";
                }
            }
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            
            if (!String.IsNullOrEmpty(txtUserName.Text) && !String.IsNullOrEmpty(txtPassword.Text))
            {
                string admin        = ConfigurationManager.AppSettings.Get("admin").ToString();
                string adminpass    = ConfigurationManager.AppSettings.Get("adminpass").ToString();
                if (String.Equals(txtUserName.Text.ToUpper(), admin.ToUpper()) && String.Equals(txtPassword.Text.ToUpper(), adminpass.ToUpper()))
                {
                    Ayarlar home = new Ayarlar(); // Instantiate a Form3 object.
                    home.Show(); // Show Form3 and
                    this.Hide(); // closes the Form2 instance.
                }
                else
                {
                    MessageBox.Show("YÖNETİCİ KULLANICI ADI VEYA ŞİFRESİ DOĞRU DEĞİL, LÜTFEN TEKRAR DENEYİNİZ!");
                    txtPassword.Text = "";
                }

            }
        }

        private void btnKullanimTalimati_Click(object sender, EventArgs e)
        {
            KullanimTalimati kullanimTalimati = new KullanimTalimati(); // Instantiate a Form3 object.
            kullanimTalimati.Show(); // Show Form3 and
        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            //string progFiles = @"C:\Program Files\Common Files\microsoft shared\ink";
            //    string keyboardPath = Path.Combine(progFiles, "TabTip.exe");

            //    this.keyboardProc = Process.Start(keyboardPath);
            OpenTabTip();

        }

        public void OpenTabTip() {

            //RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\TabletTip\\1.7");

            //registryKey?.SetValue("KeyboardLayoutPreference", 0, RegistryValueKind.DWord);
            //registryKey?.SetValue("LastUsedModalityWasHandwriting", 1, RegistryValueKind.DWord);

            //Process.Start(@"C:\Program Files\Common Files\Microsoft Shared\ink\TabTip.exe");

        }

    }
}
