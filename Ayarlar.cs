using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ProgePodKartTest
{
    public partial class Ayarlar : Form
    {
        #region DBSettings
        // ConnectionString 
        // Next -> Test Connection
        // Next -> Create DB and Table
        // Next -> Sample Data Insert
        #endregion

        #region PrinterSettings
        // Display default printer in combobox. 
        // Next -> Test Connection
        // Next -> Sample Data Insert
        #endregion

        #region BarcodeSettings
        // Display firm code as dataset. 
        // Next -> Generate Barcode
        #endregion

        #region ComPortSettings
        // ComportIslemci -> List Available ports
        // ComportOlcum -> List Available ports
        // Next -> Test Connection
        // Next -> Sample Data Insert
        #endregion

        // Type Definitions
        // 

        public Ayarlar()
        {
            InitializeComponent();
        }

        private void Ayarlar_Load(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

            #region Yazıcı Ayarları

            string strDefaultPrinter = ConfigurationManager.AppSettings.Get("Printer");
            foreach (String strPrinter in PrinterSettings.InstalledPrinters)
            {
                cmbPrinter.Items.Add(strPrinter);
                if (strPrinter == strDefaultPrinter)
                {
                    cmbPrinter.SelectedIndex = cmbPrinter.Items.IndexOf(strPrinter);

                }
            }
            cmbPrinter.SelectedItem = strDefaultPrinter;
            cmbPrinter.Text = strDefaultPrinter;
            #endregion
            #region DB Ayarları 
            txtConnectionString.Text = ConfigurationManager.AppSettings.Get("ConnectionString");
            
            string str = ConfigurationManager.AppSettings.Get("IsDbGenerated");
            btnDbGenerate.Enabled = System.Convert.ToBoolean(str);
            #endregion
            #region ComPort Ayarları
            string comPortIslemci = ConfigurationManager.AppSettings.Get("ComPortArduino");
            string comPortOlcum = ConfigurationManager.AppSettings.Get("ComPortMultimetre");
            if (!SerialPort.GetPortNames().Contains(comPortIslemci))
            {
                cmbComPortIslemci.Items.Add(comPortIslemci);
            }
            if (!SerialPort.GetPortNames().Contains(comPortOlcum))
            {
                cmbComPortOlcumAleti.Items.Add(comPortOlcum);
            }
            foreach (var item in SerialPort.GetPortNames())
            {
                cmbComPortIslemci.Items.Add(item);
                cmbComPortOlcumAleti.Items.Add(item);
                if (item == comPortIslemci)
                {
                    cmbComPortIslemci.SelectedIndex = cmbComPortIslemci.Items.IndexOf(comPortIslemci);
                }
                if (item == comPortOlcum)
                {
                    cmbComPortOlcumAleti.SelectedIndex = cmbComPortOlcumAleti.Items.IndexOf(comPortOlcum);
                }
            }
            cmbComPortIslemci.SelectedItem = comPortIslemci;
            cmbComPortOlcumAleti.SelectedItem = comPortOlcum;
            cmbComPortIslemci.Text = comPortIslemci;
            cmbComPortOlcumAleti.Text = comPortOlcum;
            #endregion
            #region Barkod Degerleri Ayarlari
            txtFirmaKodu.Text = ConfigurationManager.AppSettings.Get("FirmaKodu");
            txtFirmaAdi.Text = ConfigurationManager.AppSettings.Get("FirmaAdi");
            txtUrunStokKodu.Text = ConfigurationManager.AppSettings.Get("UrunStokKodu");
            txtUrunGrupKodu.Text = ConfigurationManager.AppSettings.Get("UrunGrupKodu");
            txtUrunKodu.Text = ConfigurationManager.AppSettings.Get("UrunKodu");
            txtUretimTarihiKodu.Text = ConfigurationManager.AppSettings.Get("UretimTarihiKodu");
            txtTestTarihiKodu.Text = ConfigurationManager.AppSettings.Get("UrunTestTarihiKodu");
            #endregion
            #region Admin Info Ayarlari
            txtAdminUsername.Text = ConfigurationManager.AppSettings.Get("admin");
            txtAdminPassword.Text = ConfigurationManager.AppSettings.Get("adminpass");
            #endregion

        }

        // Not Draggable
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

        private void Ayarlar_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form frm = Application.OpenForms["Login"]; //it should works
            frm.Show();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // Ayarlar girilmis mi
            bool isValid = true;
            var groups = from controls in this.Controls.OfType<GroupBox>() select controls;

            foreach (Control control in groups)
            {
                if (control.GetType() == typeof(TextBox) || control.GetType() == typeof(ComboBox))
                {
                    if (string.IsNullOrEmpty(control.Text))
                    {
                        isValid = false;
                    }
                }
            }

            // Ayarlarda eksik var
            if (!isValid)
            {
                MessageBox.Show("Formdaki Tüm Ayarları Doldurmanız Gerekmektedir!");
            }
            // Ayarlarda eksik yok, kaydedip kapatacağız.
            else
            {
                AyarlariKaydet();
                Form frm = Application.OpenForms["Login"]; //it should works
                frm.Show();
                this.Close();
            }
        }

        

        private void AyarlariKaydet()
        {
            //Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

            //ConfigurationManager.AppSettings.Remove("ComPortArduino ")     ;
            //ConfigurationManager.AppSettings.Remove("ComPortMultimetre ")  ;
            //ConfigurationManager.AppSettings.Remove("Printer ")            ;
            //ConfigurationManager.AppSettings.Remove("ConnectionString ")   ;
            //ConfigurationManager.AppSettings.Remove("FirmaKodu")           ;
            //ConfigurationManager.AppSettings.Remove("FirmaAdi")            ;
            //ConfigurationManager.AppSettings.Remove("UretimTarihiKodu")    ;
            //ConfigurationManager.AppSettings.Remove("UrunGrupKodu")        ;
            //ConfigurationManager.AppSettings.Remove("UrunStokKodu")        ;
            //ConfigurationManager.AppSettings.Remove("UrunKodu")            ;
            //ConfigurationManager.AppSettings.Remove("UrunTestTarihiKodu ") ;
            //ConfigurationManager.AppSettings.Remove("UrunTestTarihiKodu ") ;
            //ConfigurationManager.AppSettings.Remove("admin")               ;
            //ConfigurationManager.AppSettings.Remove("adminpass");


            UpdateConfig("ComPortArduino ", cmbComPortIslemci.Text);
            UpdateConfig("ComPortMultimetre ", cmbComPortOlcumAleti.Text);
            UpdateConfig("Printer ", cmbPrinter.Text);
            UpdateConfig("ConnectionString ", txtConnectionString.Text);
            UpdateConfig("FirmaKodu", txtFirmaKodu.Text);
            UpdateConfig("FirmaAdi", txtFirmaAdi.Text);
            UpdateConfig("UretimTarihiKodu", txtUretimTarihiKodu.Text);
            UpdateConfig("UrunGrupKodu", txtUrunGrupKodu.Text);
            UpdateConfig("UrunStokKodu", txtUrunStokKodu.Text);
            UpdateConfig("UrunKodu", txtUrunKodu.Text);
            UpdateConfig("UrunTestTarihiKodu ", txtTestTarihiKodu.Text);
            UpdateConfig("UrunTestTarihiKodu ", txtTestTarihiKodu.Text);
            UpdateConfig("admin", txtAdminUsername.Text);
            UpdateConfig("adminpass", txtAdminPassword.Text);

            //config.Save(ConfigurationSaveMode.Full);
            //ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
            DbOperations.getDbInstance().ConnStr = new SqlConnection(ConfigurationManager.AppSettings.Get("ConnectionString)"));


        }

        static void UpdateConfig(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["Login"]; //it should works
            frm.Show();
            this.Close();
        }


        //public void UpdateConfigKey(string strKey, string newValue)
        //{
        //    XmlDocument xmlDoc = new XmlDocument();
        //    xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "App.config");
        //    //xmlDoc.LoadXML(ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath));


        //    if (!ConfigKeyExists(strKey))
        //    {
        //        throw new ArgumentNullException("Key", "<" + strKey + "> not find in the configuration.");
        //    }
        //    XmlNode appSettingsNode = xmlDoc.SelectSingleNode("configuration/appSettings");

        //    foreach (XmlNode childNode in appSettingsNode)
        //    {
        //        if (childNode.Attributes["key"].Value == strKey.TrimEnd(' '))
        //        {
        //            childNode.Attributes["value"].Value = newValue.TrimEnd(' ');
        //        }
        //    }
        //    xmlDoc.Save(AppDomain.CurrentDomain.BaseDirectory + "App.config");
        //    //xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        //    //MessageBox.Show("Key Upated Successfullly");
        //}
        //public bool ConfigKeyExists(string strKey)
        //{
        //    XmlDocument xmlDoc = new XmlDocument();
        //    xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "App.config");

        //    XmlNode appSettingsNode = xmlDoc.SelectSingleNode("configuration/appSettings");

        //    foreach (XmlNode childNode in appSettingsNode)
        //    {
        //        if (childNode.Attributes["key"].Value == strKey.TrimEnd(' '))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}




        private void btnDbTest_Click(object sender, EventArgs e)
        {
            // TODO
            // Get ConnectionString From Txt
            // Try Opening a Connection
            // If Db Changed, Enable Generate Button
            try
            {

                bool result = DbOperations.getDbInstance().CheckDbStatus(txtConnectionString.Text);
                if (result)
                {
                    MessageBox.Show("Veritabanı Bağlantısı Geçerli. Bilgileri Kaydetmek için 'KAYDET'e Basınız.");
                    // DbOperations.getDbInstance().ConnStr = new SqlConnection(ConfigurationManager.AppSettings.Get("ConnectionString);
                }
                else
                {
                    MessageBox.Show("Veritabanı Bağlantısı Geçerli Değil. Lütfen Bilgileri Kontrol Edin.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }

        }

        private void btnDbGenerate_Click(object sender, EventArgs e)
        {
            // TODO
            // Get ConnectionString From Txt
            // Open the Connection
            // Check if table already exists
            // If bo table --> Run the script
        }

        private void btnBarkodTest_Click(object sender, EventArgs e)
        {
            // TODO
            // Get Selected Printer From Cmb
            #region Barkod Generate
            bool result = false;

            BarcodeProducer barcode = new BarcodeProducer();
            StringBuilder builder = new StringBuilder();
            //string data = "";

            //builder.AppendLine(ConfigurationManager.AppSettings.Get("FirmaKodu").ToString() + " : " + ConfigurationManager.AppSettings.Get("FirmaAdi").ToString());
            //builder.AppendLine(ConfigurationManager.AppSettings.Get("UrunGrupKodu").ToString() + " : " + "123456789ABCDEF");
            //builder.AppendLine(ConfigurationManager.AppSettings.Get("UrunTestTarihiKodu").ToString() + " : " + DateTime.Now.ToString("dd/MM/yyyy"));
            builder.AppendLine(ConfigurationManager.AppSettings.Get("UrunStokKodu").ToString() + " : " + "FEDCBA987654321");
            builder.AppendLine(ConfigurationManager.AppSettings.Get("UrunKodu").ToString() + " : " + "1234567890");
            builder.AppendLine(ConfigurationManager.AppSettings.Get("UretimTarihiKodu").ToString() + " : " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));

            //data += prmTip.GetType().ToString();
            //data += " - BAŞARILI";
            Image qrImg = barcode.GenerateQRCode(builder.ToString());
            if (qrImg != null)
            {
                //result = barcode.PrintReport(qrImg);
                result = barcode.PrintReport(qrImg, txtFirmaAdi.Text + "-" + txtFirmaKodu.Text, "123456789ABCDEF");

            }
            #endregion

            if (result)
            {
                MessageBox.Show("Test Barkodu Yazdırıldı. Ayarları Kaydetmek için 'KAYDET'e Basınız.");
                // DbOperations.getDbInstance().ConnStr = new SqlConnection(ConfigurationManager.AppSettings.Get("ConnectionString);
            }
            else
            {
                MessageBox.Show("Test Barkodu Yazdırılamadı. Lütfen Ayarları Kontrol Edin.");
            }

            // Send Sample Barcode
        }
    }
}
