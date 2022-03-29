using System.Windows.Forms;
using System.IO.Ports;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Drawing;
using System.Threading.Tasks;
using System.Text;
using System.Management;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Configuration;

namespace ProgePodKartTest
{
    public partial class Anasayfa : Form
    {
        #region Variables
        public string UserName { get; set; }
        List<string> portNames = new List<string>();
        private SerialPort ComPort_Multimetre = new SerialPort();
        private SerialPort ComPort_Arduino = new SerialPort();
        private ITip selectedTip;
        private int productCount = 0;
        private int fireCount = 0;
        private bool urunDurum = true;
        private int FireDurumu = 0;

        ToolTip tt = new ToolTip();

        public  int STATE { get; set; }
        public  decimal INCOMINGVALUE { get; set; } 
        public  string VALTYPE { get; set; }


        private ProcedureStateForControls FormState = ProcedureStateForControls.LoggedIn;
        private BarkodData barkodData;
        #endregion

        public Anasayfa()
        {
            InitializeComponent();
            barkodData = new BarkodData();
        }

        #region FormKontrolIslemleri
        private void Anasayfa_Load(object sender, System.EventArgs e)
        {
            // Formun Genel Baslangic Ayarlari
            Left = Top = 0;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ShowInTaskbar = false;
            this.ControlBox = false;
            this.MinimumSize = this.MaximumSize;
            this.SizeGripStyle = SizeGripStyle.Hide;

            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;
            //



            EnableControls();
            UpdateFormControls(sender, e);
            updatePorts();
            CheckForIllegalCrossThreadCalls = false;
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

        private void Anasayfa_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ComPort_Multimetre.IsOpen) ComPort_Multimetre.Close();  //close the port if open when exiting the application.
            if (ComPort_Arduino.IsOpen) ComPort_Arduino.Close();  //close the port if open when exiting the application.
            Form frm = Application.OpenForms["Login"]; //it should works
            frm.Show();

        }

        private void btnEmergency_Click(object sender, EventArgs e)
        {
            try
            {
                disconnect();
                FormState = ProcedureStateForControls.BarcodeInfoTaken;
                connect();
                UpdateFormControls(sender, e);
            }
            catch (Exception ex)
            {
                //this.BeginInvoke(new LineReceivedEvent(LineReceived), ex.StackTrace);
            }


        }
        #endregion

        #region Form Kontrolleri Guncelleme

        private void UpdateFormControls(object sender, EventArgs e)
        {
            switch (FormState)
            {
                case ProcedureStateForControls.LoggedIn:
                    // Giriş yapınca açılır
                    // Barkod Ayarı sıfırlanınca açılır
                    FormStatusLoggedIn(sender, e);
                    break;
                case ProcedureStateForControls.BarcodeInfoTaken:
                    // Barkod Bilgisi alınınca açılır
                    // Tip Değiştirilmek istendiğinde açılır
                    FormStatusBarcodeInfoTaken(sender, e);
                    break;
                case ProcedureStateForControls.BarcodeInfoToUpdate:
                    // Barkod Bilgisi alınınca açılır
                    // Tip Değiştirilmek istendiğinde açılır
                    FormStatusBarcodeInfoToUpdate(sender, e);
                    break;
                case ProcedureStateForControls.TypeChosen:
                    FormStatusTypeChosen(sender, e);
                    break;
                case ProcedureStateForControls.TypeToUpdate:
                    FormStatusTypeToUpdate(sender, e);
                    break;
                default:
                    break;
            }
        }

        private void FormStatusLoggedIn(object sender, EventArgs e) {
            
            // Barcode Text Controls
            foreach (Control item in groupTexts.Controls)
            {
                //item.Enabled = false;
                item.Enabled = true;
                if (item.TabIndex == 0)
                    item.Focus();
            }

            // Barcode Text Controls
            foreach (Control item in groupBtns.Controls)
            {
                if(item.Text.Contains("İPTAL")) item.Text = item.Text.Replace(" - İPTAL", "");
                item.Enabled = false;
            }
            btnSetValues.Text = "BARKOD VERİLERİ AYARLA";
            // Disable Other Controls 
            rtxtDataArea.Enabled = false;
            groupBtns.Enabled = false;
            lblWarning.Visible = false;
            lblWarning.Text = "";

            //Enabled Controls : 
            btnSetValues.Enabled = true;
            btnBacktoLogin.Enabled = true;
            btnEmergency.Enabled = true;
            btnShutdown.Enabled = true;
            pBoxLogo.BorderStyle = BorderStyle.None;

        }
        private void FormStatusBarcodeInfoTaken(object sender, EventArgs e) 
        {  
            foreach (Control item in groupTexts.Controls.OfType<MaskedTextBox>())
            {
                item.Enabled = false;
            }
            groupBtns.Enabled = true;
            foreach (Control item in groupBtns.Controls.OfType<Button>())
            {
                item.Enabled = true;
            }
            btnSetValues.Text = "BARKOD VERİLERİ TEKRAR AYARLA";
            btnSetValues.Enabled = true;
            //groupTexts.Enabled = false;
            lblWarning.Text = "BARKOD VERİLERİ AYARLANDI";
            lblWarning.Visible = false;
            rtxtDataArea.Enabled = false;

            //Enabled Controls : 
            btnBacktoLogin.Enabled = true;
            btnEmergency.Enabled = true;
            btnShutdown.Enabled = true;
            rtxtDataArea.Enabled = false;

        }
        private void FormStatusBarcodeInfoToUpdate(object sender, EventArgs e) 
        {

            // Barcode Text Controls
            foreach (Control item in groupTexts.Controls.OfType<MaskedTextBox>())
            {
                item.Text= "";
                item.Enabled = true;
                if (item.TabIndex == 0)
                    item.Focus();
            }
            btnSetValues.Text = "BARKOD VERİLERİ AYARLA";

            // Barcode Text Controls
            foreach (Control item in groupBtns.Controls)
                item.Enabled = false;

            // Disable Other Controls 
            rtxtDataArea.Enabled = false;
            groupBtns.Enabled = false;
            lblWarning.Visible = false;
            lblWarning.Text = "";

            //Enabled Controls : 
            btnSetValues.Enabled = true;
            btnBacktoLogin.Enabled = true;
            btnEmergency.Enabled = true;
            btnShutdown.Enabled = true;
            ComPort_Arduino.DataReceived -= MMDataReceived;

        }
        private void FormStatusTypeChosen(object sender, EventArgs e) {
            foreach (Control item in groupBtns.Controls.OfType<Button>())
            {
                item.Enabled = false;
                if (item == sender)
                {
                    item.Enabled = true;
                    item.Text += " - İPTAL";
                    item.BackColor = Color.MediumAquamarine;
                }
            }
            btnSetValues.Text = "BARKOD VERİLERİ AYARLA";
            btnEmergency.Enabled = true;
            btnShutdown.Enabled = true;
            btnSetValues.Enabled = false;
            rtxtDataArea.Enabled = true;
            rtxtDataArea.Text = "";
            btnBacktoLogin.Enabled = false;
        }
        private void FormStatusTypeToUpdate(object sender, EventArgs e) {
            foreach (Control item in groupBtns.Controls.OfType<Button>())
            {
                item.Enabled = true;
                item.BackColor = Color.LightCyan;
                if (item == sender)
                {
                    item.Enabled = true;
                    item.Text = item.Text.Replace( " - İPTAL","");
                }
            }
            btnSetValues.Enabled = true;
            rtxtDataArea.Enabled = false;
            rtxtDataArea.Text = "";
            btnBacktoLogin.Enabled = true;
        }

        #endregion

        #region Serial Port Operations
        private void updatePorts()
        {
            // Retrieve the list of all COM ports on your Computer
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                portNames.Add(port);
            }
        }
        private void connect()
        {
            bool error = false;
            try
            {
                ComPort_Arduino.DtrEnable = true;
                productCount = 0;
                fireCount = 0;
                //Open Port
                if (!ComPort_Arduino.IsOpen)
                {
                    ComPort_Arduino.PortName = ConfigurationManager.AppSettings.Get("ComPortArduino");
                    ComPort_Arduino.BaudRate = 115200;
                    ComPort_Arduino.Open();
                    ComPort_Arduino.DataReceived += ArduinoDataReceived;
                    //sendData(selectedTip.sendDataCode.ToString());          
                }

                if (!ComPort_Multimetre.IsOpen)
                {
                    //Open Port
                    ComPort_Multimetre.PortName = ConfigurationManager.AppSettings.Get("comPortMultiMetre");
                    ComPort_Multimetre.BaudRate = 9600;
                    ComPort_Multimetre.Open();
                    //ComPort_Multimetre.DataReceived += MMDataReceived;

                }
            }
            catch (UnauthorizedAccessException e) {
                error = true; }
            catch (System.IO.IOException e) {
                error = true; }
            catch (ArgumentException e) {
                error = true; }
            string message = "";
            if (ComPort_Arduino.IsOpen)
            {
                //btnBaglan.Enabled = false;
                message = "Makine Bağlantısı Sağlandı!";
            }
            if (ComPort_Multimetre.IsOpen)
            {
                //btnBaglan.Enabled = false;
                message += "MM Bağlantı Sağlandı!";
            }
            else
            {
                message = "-!- MAKİNE BAĞLI DEĞİL. MAKİNE BAĞLANTILARINI KONTROL EDİN -!-";
                MessageBox.Show(message);
            }
        }
        // Call this function to close the port.
        private void disconnect()
        {
            ComPort_Arduino.DataReceived -= ArduinoDataReceived;
            if (ComPort_Multimetre.IsOpen)  ComPort_Multimetre.Close();
            if (ComPort_Arduino.IsOpen)  ComPort_Arduino.Close();
            //btnBaslat.Text = "BAGLAN";
            
        }

        private void sendData(string prmData)
        {
            bool error = false;
            try
            {
                // Convert the user's string of hex digits (example: E1 FF 1B) to a byte array
                //this.BeginInvoke(new LineReceivedEvent(LineReceived), "Data Gönderildi : " + prmData);
                // Send the binary data out the port
                //ComPort_Arduino.Write(data, 0, data.Length);
                int value = Convert.ToInt32(prmData);
                //int value = Convert.ToInt32(txtSendData.Text);

                byte[] data = BitConverter.GetBytes(value);
                ComPort_Arduino.Write(data, 0, data.Length - 1);
                // Show the hex digits on in the terminal window
                rtxtDataArea.ForeColor = Color.Blue;   //write Hex data in Blue
            }
            catch (FormatException) { error = true; }

            // Inform the user if the hex string was not properly formatted
            catch (ArgumentException) { error = true; }

            //if (error) MessageBox.Show(this, "Not properly formatted hex string: " + txtSendData.Text + "\n" + "example: E1 FF 1B", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            //invokeRequired required compares the thread ID of the calling thread to the thread of the creating thread.
            // if these threads are different, it returns true
            if (this.rtxtDataArea.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                rtxtDataArea.ForeColor = Color.Blue;   //write Hex data in Blue
                this.rtxtDataArea.AppendText(text);
            }
        }
        private void ArduinoDataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                var serialPort = (SerialPort)sender;
                string line = serialPort.ReadLine();
                if (!line.Equals(""))
                {
                    //ComPort_Multimetre.DataReceived -= MMDataReceived;
                    #region String Parse & Olcum

                    this.BeginInvoke(new LineReceivedEvent(LineReceived), line);

                    if (line.Contains("TATIL"))
                    {
                        if (line.Contains("OKU"))
                        {

                            urunDurum = true;
                            SetStateAsync(0);
                            sendData(selectedTip.sendDataCode.ToString());
                            ComPort_Multimetre.DataReceived += MMDataReceived;
                            FireDurumu = 0;
                        }
                    }
                    else if (line.Contains("POZ"))
                    {
                        var prms = line.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (prms.Any())
                        {
                            int state = (line.Contains("0")) ? 0 : 
                                (line.Contains("MAX")) ? 5 : Convert.ToInt32(prms[3]);

                            //string valueAB = nameof(ValueType.AB);
                            //string valueBC = nameof(ValueType.BC);
                            //valueType = (prms[4] == "AB") ? ValueType.AB : ValueType.BC;
   
                            //VALTYPE = (prms[4] == "AB") ? "AB": "BC";
                            string vl = SetValueTypeAsync(prms[4]).Result;
                            int result = SetStateAsync(state).Result;
                        }
                    }
                    else if (urunDurum && line.Contains("TAMAMLANDI"))
                    {
                        SurecSonlandir();
                    }
                    #endregion
                }

            }
            catch (Exception ex)
            {
                //this.BeginInvoke(new LineReceivedEvent(LineReceived), "İşlemci Okuma hatası\n");
                //this.BeginInvoke(new LineReceivedEvent(LineReceived), ex.StackTrace);
            }
        }

        public  async Task<string> SetValueTypeAsync(string prm )
        {
            VALTYPE = prm.TrimEnd('\r');
            return VALTYPE;
        }
        public  async Task<int> SetStateAsync(int prm)
        {
            STATE = prm;
            return STATE;
        }
        public  async Task<decimal> SetIncomingValueAsync(decimal prm)
        {
            INCOMINGVALUE = prm;
            return INCOMINGVALUE;
        }

        private void MMDataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                var serialPort = (SerialPort)sender;
                string line = serialPort.ReadLine();
                if (!string.IsNullOrEmpty(line))
                {
                    if (!line.Contains("Over Load"))
                    {
                        this.BeginInvoke(new LineReceivedEvent(LineReceived), line);
                        var sentence = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        
                        if (sentence.Any())
                        {
                            decimal val = Convert.ToDecimal(sentence[0].Replace(".", ","));
                            decimal incoming = (sentence[1] == "Ohm") ? val : val * 1000;
                            decimal res =  SetIncomingValueAsync(incoming).Result;
                            bool result = DegerKontrolEt();
                            //bool result = DegerKontrolEt(state, valueType, incomingValue);

                            if (!result)
                            {
                                //this.BeginInvoke(new LineReceivedEvent(LineReceived), "Result False" + "\n");
                                //this.BeginInvoke(new LineReceivedEvent(LineReceived), "\n SON'dan Hemen Once VALTYPE : " + VALTYPE + " - incoming : " + INCOMINGVALUE.ToString() + " - position :" + STATE.ToString() + "\n");
                                //this.BeginInvoke(new LineReceivedEvent(LineReceived), "\n SON'dan Hemen Once Line: " + line + "\n");

                                urunDurum = false;
                                FireDurumu++;
                                SurecSonlandir();
                                //sendData(selectedTip.sendDataCode.ToString());
                            }
                        }
                    }
                }
            
            }
            catch (Exception ex)
            {
                //this.BeginInvoke(new LineReceivedEvent(LineReceived), "Ölçüm Cihazı Okuma hatası\n");
                //this.BeginInvoke(new LineReceivedEvent(LineReceived), ex.StackTrace);

            }

        }
        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            // set the current caret position to the end
            rtxtDataArea.SelectionStart = rtxtDataArea.Text.Length;
            // rt it automatically
            rtxtDataArea.ScrollToCaret();
        }

        private delegate void LineReceivedEvent(string line);
        private void LineReceived(string line)
        {
            rtxtDataArea.AppendText(line);
        }

        private bool DegerKontrolEt()
        //private bool DegerKontrolEt(int position, ValueType prmValueType, decimal incomingValue)
        {
            //this.BeginInvoke(new LineReceivedEvent(LineReceived), "DegerKontrol Fonksiyonu\n");
           
            if (VALTYPE == "AB")
            {
                if (!(selectedTip is Tip2 || selectedTip is Tip4))
                {
                    if (INCOMINGVALUE >= selectedTip.values.altPozAB[STATE] && INCOMINGVALUE <= selectedTip.values.ustPozAB[STATE])
                    {
                        return true;
                    }
                }
            }
            else
            {
                if (INCOMINGVALUE >= selectedTip.values.altPozBC[STATE] && INCOMINGVALUE <= selectedTip.values.ustPozBC[STATE])
                {
                    return true;
                }
                // Hata Bitis
            }
            return false;
        }

        public void SurecSonlandir() {

            string line = "";
            try
            {
                ComPort_Multimetre.DataReceived -= MMDataReceived;
                //ComPort_Arduino.DataReceived -= ArduinoDataReceived;

                if (urunDurum)
                {
                    if(STATE == 5)
                    {
                        line = "Ürün Testi Başarıyla Gerçekleştirildi.";
                        productCount++;
                        BarkodYazdir(selectedTip, urunDurum);
                    }
                }
                else
                {
                    // Fire 
                    this.BeginInvoke(new LineReceivedEvent(LineReceived), "Fire Bilgisi Gönderildi \n");
                    fireCount++;
                    if (FireDurumu == 1)
                    {
                        line = "!- Ürün Testi BAŞARISIZ !";

                        disconnect();
                        Thread.Sleep(1000);
                        connect();
                        //sendData(selectedTip.sendDataCode.ToString());
                        Thread.Sleep(1000);
                        sendData("7");

                    }
                }

                DateTime date = DateTime.ParseExact(mTextUretimTarihi.Text, "dd/MM/yyyy", null);
                date = Convert.ToDateTime(mTextUretimTarihi.Text);
                DateTime testdate = Convert.ToDateTime(DateTime.Now.ToString());

                bool opStatus = DbOperations.getDbInstance().InsertData(
                    //Properties.Settings.Default.FirmaAdi.ToString()
                    ConfigurationManager.AppSettings.Get("FirmaAdi"),
                    mTextUrunStokKodu.Text,
                    mTextUrunGrupKod.Text,
                    mTextUrunKodu.Text,
                    date,
                    urunDurum,
                    selectedTip.GetType().Name,
                    selectedTip.GetType().Name,
                    UserName,
                    testdate
                    );

                string opResult = opStatus ? "Verilerin Veritabanına Yazdırılması İşlemi Başarıyla Gerçekleşti.\n" : "Veritabanına Yazma İşlemi Başarısız, Lütfen Ayarları Kontrol Edin\n";                
            }
            catch (Exception ex)
            {
                //this.BeginInvoke(new LineReceivedEvent(LineReceived), "Surec Sonlanma hatası : " + ex.StackTrace);
            }
        }

        public void BarkodYazdir(ITip prmTip, bool productState) {
            
            this.BeginInvoke(new LineReceivedEvent(LineReceived),"Barkod Yazdırılıyor\n");
            
            BarcodeProducer barcode = new BarcodeProducer();
            StringBuilder builder = new StringBuilder();
            //string data = "";
            //builder.Append( ConfigurationManager.AppSettings.Get("FirmaKodu") + " : " + ConfigurationManager.AppSettings.Get("FirmaAdi"));
            //builder.Append( ConfigurationManager.AppSettings.Get("UrunGrupKodu") + " : "      + mTextUrunGrupKod.Text);
            //builder.Append( ConfigurationManager.AppSettings.Get("UrunTestTarihiKodu") + " : "+ DateTime.Now.ToString("dd/MM/yyyy"));
            builder.Append( ConfigurationManager.AppSettings.Get("UrunStokKodu") + " : "      + mTextUrunStokKodu.Text + " \n ");
            builder.Append( ConfigurationManager.AppSettings.Get("UrunKodu") + " : "          + mTextUrunKodu.Text + " \n ");
            builder.Append( ConfigurationManager.AppSettings.Get("UretimTarihiKodu") + " : "  + mTextUretimTarihi.Text);

            //data += prmTip.GetType().ToString();
            //data += " - BAŞARILI";
            Image qrImg = barcode.GenerateQRCode(builder.ToString());
            if (qrImg!=null)
            {
                //barcode.PrintReport(qrImg);
                barcode.PrintReport(qrImg, ConfigurationManager.AppSettings.Get("FirmaAdi") + "-" + ConfigurationManager.AppSettings.Get("FirmaKodu"), mTextUrunGrupKod.Text);
            }
            
            this.BeginInvoke(new LineReceivedEvent(LineReceived),"Barkod Yazdırıldı\n");
        }

        #endregion

        #region Tip Secimi
        private void btnTip_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text.Contains("İPTAL"))
            {
                disconnect();
                FormState = ProcedureStateForControls.TypeToUpdate;
                UpdateFormControls(sender, e);
                FormState = ProcedureStateForControls.BarcodeInfoToUpdate;
                UpdateFormControls(sender, e);
            }
            else
            {
                switch (((Button)sender).Name)
                {
                    case ("btnTip1"):
                        //disconnect();
                        selectedTip = new Tip1();
                        FormState = ProcedureStateForControls.TypeChosen; 
                        UpdateFormControls(sender, e);
                        connect();
                        break;
                    case ("btnTip2"): 
                        //disconnect();
                        selectedTip = new Tip2();
                        FormState = ProcedureStateForControls.TypeChosen; 
                        UpdateFormControls(sender, e);
                        connect();
                        break;                
                    case ("btnTip4"): 
                        //disconnect();
                        selectedTip = new Tip4();
                        FormState = ProcedureStateForControls.TypeChosen; 
                        UpdateFormControls(sender, e);
                        connect();
                        break;
                    case ("btnTip11"):
                        //disconnect();
                        selectedTip = new Tip11();
                        FormState = ProcedureStateForControls.TypeChosen; 
                        UpdateFormControls(sender, e);
                        connect();
                        break; 
                    case ("btnTip3"): 
                    case ("btnTip12"):                
                    case ("btnTip13"):
                    case ("btnTip21"):
                    case ("btnTip31"):
                    default:
                        //MessageBox.Show("BU TİPE AİT TANIMLAMA BULUNMAMAKTADIR, LÜTFEN TANIMLAMA YAPTIKTAN SONRA DENEYİNİZ!");
                        break;
                }
                
            }
        }

        private void EnableControls()
        {
            foreach (Button c in this.Controls.OfType<Button>())
            {
                c.Enabled = false;
            }
            foreach (Control item in this.Controls)
            {
                if(item.TabIndex == 0)
                    item.Focus();
            }
        }

        #endregion

        #region Yazıcı ve Kapanis Islemleri

        private void btnBacktoLogin_Click(object sender, EventArgs e)
        {
            mTextUretimTarihi.CausesValidation = false;
            if (ComPort_Multimetre.IsOpen) ComPort_Multimetre.Close();  //close the port if open when exiting the application.
            if (ComPort_Arduino.IsOpen) ComPort_Arduino.Close();  //close the port if open when exiting the application.
            Form frm = Application.OpenForms["Login"]; //it should works
            frm.Show();
            this.Close();
        }

        #endregion

        #region Barkod Bilgileri Alma

        private void groupTextControls_KeyDown(object sender, KeyEventArgs e)
        {
            MaskedTextBox masked = ((MaskedTextBox)sender);

            if (masked.MaskFull && (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab))
                {
                    foreach (Control item in groupTexts.Controls.OfType<MaskedTextBox>())
                    {
                        //item.Enabled = false;
                        if (item.TabIndex == masked.TabIndex + 1)
                        {
                            item.Enabled = true;
                            item.Focus();
                        }
                    }
                }
            }

        private void btnSetValues_Click(object sender, EventArgs e)
        {
            // textlerde bos olan var - uyari cikar
            if (groupTexts.Controls.OfType<MaskedTextBox>().Any(q => q.MaskedTextProvider.AvailableEditPositionCount != 0))
            {
                //UpdateFormControls(sender, e);
                foreach (Control item in groupTexts.Controls.OfType<MaskedTextBox>())
                {
                    item.Text = "";
                    if (item.TabIndex == 0)
                    {
                        item.Enabled = true;
                        item.Focus();
                    }
                }
                lblWarning.Visible = true;
                lblWarning.Text = lblWarning.Text = "LÜTFEN BARKOD VERİLERİNİ EKSİKSİZ GİRİNİZ"; 
                lblWarning.Enabled = true;
                //MessageBox.Show("LÜTFEN BARKOD VERİLERİNİ EKSİKSİZ GİRİNİZ");
            }
            else
            {
                // textlerde bos olan yok  - standart prosedur
                if (FormState == ProcedureStateForControls.BarcodeInfoTaken)
                {
                    FormState = ProcedureStateForControls.BarcodeInfoToUpdate;
                    UpdateFormControls(sender, e);
                }
                else
                {
                    FormState = ProcedureStateForControls.BarcodeInfoTaken;
                    UpdateFormControls(sender, e);
                }
            }
        }

        #endregion

        #region Emergency & Shutdown
        private void btnShutdown_Click(object sender, EventArgs e)
        {

            string message = "Bu işlemi onaylarsanız bilgisayar kapanıp açılacaktır. İşleme Devam Etmek İstiyor Musunuz?";
            string title = "BİLGİSAYAR KAPATILACAK !";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                //ExitWindowsEx(0,0);
                Process.Start("shutdown.exe", "-s -t 00");
            }
            else
            {
                // Do something  
            }


            //Shutdown();

            // Alternatif : 

            // Sleep Test 
            //LockWorkStation();


        }

        //[DllImport("user32")]
        //public static extern void LockWorkStation();
        
        [DllImport("user32")]
        public static extern void ExitWindowsEx(GraphicsUnit uFlags, uint dwReason);

        #endregion

        private void mTextUretimTarihi_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DateTime date;
            
            if (!DateTime.TryParse(mTextUretimTarihi.Text, out date))
            {
                tt = new ToolTip();
                tt.InitialDelay = 0;
                tt.IsBalloon = false;
                //tt.Show("Geçersiz Tarih Girdiniz, Lütfen Düzeltin", mTextUretimTarihi);
                tt.Show("Geçersiz Tarih Girdiniz, Lütfen Düzeltin", mTextUretimTarihi, 0);



                //lblWarning.Text = ;
                //MessageBox.Show("Geçersiz Tarih Girdiniz, Lütfen Düzeltin");
                mTextUretimTarihi.Text = "";
                mTextUretimTarihi.Focus();
            }
            else
            {
                tt.Dispose();
            }

        }

        private void mTextUretimTarihi_Leave(object sender, EventArgs e)
        {
            tt.Dispose();
        }
    }
}
