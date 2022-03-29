
namespace ProgePodKartTest
{
    partial class Ayarlar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpVeritabani = new System.Windows.Forms.GroupBox();
            this.btnDbGenerate = new System.Windows.Forms.Button();
            this.btnDbTest = new System.Windows.Forms.Button();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.lblConnectionString = new System.Windows.Forms.Label();
            this.grpPrinter = new System.Windows.Forms.GroupBox();
            this.cmbPrinter = new System.Windows.Forms.ComboBox();
            this.btnBarkodTest = new System.Windows.Forms.Button();
            this.lblPrinter = new System.Windows.Forms.Label();
            this.grpComPort = new System.Windows.Forms.GroupBox();
            this.cmbComPortOlcumAleti = new System.Windows.Forms.ComboBox();
            this.lblComPortOlcumCihazi = new System.Windows.Forms.Label();
            this.cmbComPortIslemci = new System.Windows.Forms.ComboBox();
            this.lblComPortIslemci = new System.Windows.Forms.Label();
            this.grpBarkod = new System.Windows.Forms.GroupBox();
            this.txtFirmaAdi = new System.Windows.Forms.TextBox();
            this.lblFirmaAdi = new System.Windows.Forms.Label();
            this.txtTestTarihiKodu = new System.Windows.Forms.TextBox();
            this.lblTestTarihiKodu = new System.Windows.Forms.Label();
            this.txtUretimTarihiKodu = new System.Windows.Forms.TextBox();
            this.lblUretimTarihiKodu = new System.Windows.Forms.Label();
            this.txtUrunKodu = new System.Windows.Forms.TextBox();
            this.txtUrunGrupKodu = new System.Windows.Forms.TextBox();
            this.lblUrunKodu = new System.Windows.Forms.Label();
            this.lblUrunGrupKodu = new System.Windows.Forms.Label();
            this.txtUrunStokKodu = new System.Windows.Forms.TextBox();
            this.txtFirmaKodu = new System.Windows.Forms.TextBox();
            this.lblUrunStokKodu = new System.Windows.Forms.Label();
            this.lblFirmaKodu = new System.Windows.Forms.Label();
            this.btnIptal = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.grpAdminInfo = new System.Windows.Forms.GroupBox();
            this.txtAdminPassword = new System.Windows.Forms.TextBox();
            this.lblAdminPassword = new System.Windows.Forms.Label();
            this.txtAdminUsername = new System.Windows.Forms.TextBox();
            this.lblAdminUsername = new System.Windows.Forms.Label();
            this.grpVeritabani.SuspendLayout();
            this.grpPrinter.SuspendLayout();
            this.grpComPort.SuspendLayout();
            this.grpBarkod.SuspendLayout();
            this.grpAdminInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpVeritabani
            // 
            this.grpVeritabani.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpVeritabani.Controls.Add(this.btnDbGenerate);
            this.grpVeritabani.Controls.Add(this.btnDbTest);
            this.grpVeritabani.Controls.Add(this.txtConnectionString);
            this.grpVeritabani.Controls.Add(this.lblConnectionString);
            this.grpVeritabani.Location = new System.Drawing.Point(12, 12);
            this.grpVeritabani.Name = "grpVeritabani";
            this.grpVeritabani.Size = new System.Drawing.Size(1154, 157);
            this.grpVeritabani.TabIndex = 0;
            this.grpVeritabani.TabStop = false;
            this.grpVeritabani.Text = "Veritabanı Ayarları";
            // 
            // btnDbGenerate
            // 
            this.btnDbGenerate.Enabled = false;
            this.btnDbGenerate.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDbGenerate.Location = new System.Drawing.Point(29, 95);
            this.btnDbGenerate.Name = "btnDbGenerate";
            this.btnDbGenerate.Size = new System.Drawing.Size(543, 56);
            this.btnDbGenerate.TabIndex = 3;
            this.btnDbGenerate.Text = "VERİTABANI BİLEŞENLERİNİ OLUŞTUR";
            this.btnDbGenerate.UseVisualStyleBackColor = true;
            this.btnDbGenerate.Visible = false;
            this.btnDbGenerate.Click += new System.EventHandler(this.btnDbGenerate_Click);
            // 
            // btnDbTest
            // 
            this.btnDbTest.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDbTest.Location = new System.Drawing.Point(605, 95);
            this.btnDbTest.Name = "btnDbTest";
            this.btnDbTest.Size = new System.Drawing.Size(543, 56);
            this.btnDbTest.TabIndex = 2;
            this.btnDbTest.Text = "BAĞLANTIYI TEST ET";
            this.btnDbTest.UseVisualStyleBackColor = true;
            this.btnDbTest.Click += new System.EventHandler(this.btnDbTest_Click);
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtConnectionString.Location = new System.Drawing.Point(245, 47);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(903, 34);
            this.txtConnectionString.TabIndex = 1;
            // 
            // lblConnectionString
            // 
            this.lblConnectionString.AutoSize = true;
            this.lblConnectionString.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblConnectionString.Location = new System.Drawing.Point(17, 44);
            this.lblConnectionString.Name = "lblConnectionString";
            this.lblConnectionString.Size = new System.Drawing.Size(208, 37);
            this.lblConnectionString.TabIndex = 0;
            this.lblConnectionString.Text = "Bağlantı Adresi :";
            // 
            // grpPrinter
            // 
            this.grpPrinter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpPrinter.Controls.Add(this.cmbPrinter);
            this.grpPrinter.Controls.Add(this.btnBarkodTest);
            this.grpPrinter.Controls.Add(this.lblPrinter);
            this.grpPrinter.Location = new System.Drawing.Point(12, 340);
            this.grpPrinter.Name = "grpPrinter";
            this.grpPrinter.Size = new System.Drawing.Size(572, 166);
            this.grpPrinter.TabIndex = 1;
            this.grpPrinter.TabStop = false;
            this.grpPrinter.Text = "Yazıcı Ayarları";
            // 
            // cmbPrinter
            // 
            this.cmbPrinter.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbPrinter.FormattingEnabled = true;
            this.cmbPrinter.Location = new System.Drawing.Point(245, 41);
            this.cmbPrinter.Name = "cmbPrinter";
            this.cmbPrinter.Size = new System.Drawing.Size(321, 45);
            this.cmbPrinter.TabIndex = 4;
            // 
            // btnBarkodTest
            // 
            this.btnBarkodTest.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBarkodTest.Location = new System.Drawing.Point(23, 92);
            this.btnBarkodTest.Name = "btnBarkodTest";
            this.btnBarkodTest.Size = new System.Drawing.Size(543, 56);
            this.btnBarkodTest.TabIndex = 2;
            this.btnBarkodTest.Text = "ÖRNEK BARKOD YAZDIR";
            this.btnBarkodTest.UseVisualStyleBackColor = true;
            this.btnBarkodTest.Click += new System.EventHandler(this.btnBarkodTest_Click);
            // 
            // lblPrinter
            // 
            this.lblPrinter.AutoSize = true;
            this.lblPrinter.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPrinter.Location = new System.Drawing.Point(17, 44);
            this.lblPrinter.Name = "lblPrinter";
            this.lblPrinter.Size = new System.Drawing.Size(228, 37);
            this.lblPrinter.TabIndex = 0;
            this.lblPrinter.Text = "Varsayılan Yazıcı : ";
            // 
            // grpComPort
            // 
            this.grpComPort.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpComPort.Controls.Add(this.cmbComPortOlcumAleti);
            this.grpComPort.Controls.Add(this.lblComPortOlcumCihazi);
            this.grpComPort.Controls.Add(this.cmbComPortIslemci);
            this.grpComPort.Controls.Add(this.lblComPortIslemci);
            this.grpComPort.Location = new System.Drawing.Point(16, 512);
            this.grpComPort.Name = "grpComPort";
            this.grpComPort.Size = new System.Drawing.Size(572, 143);
            this.grpComPort.TabIndex = 2;
            this.grpComPort.TabStop = false;
            this.grpComPort.Text = "Com Port Ayarları";
            // 
            // cmbComPortOlcumAleti
            // 
            this.cmbComPortOlcumAleti.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbComPortOlcumAleti.FormattingEnabled = true;
            this.cmbComPortOlcumAleti.Location = new System.Drawing.Point(300, 81);
            this.cmbComPortOlcumAleti.Name = "cmbComPortOlcumAleti";
            this.cmbComPortOlcumAleti.Size = new System.Drawing.Size(266, 45);
            this.cmbComPortOlcumAleti.TabIndex = 6;
            // 
            // lblComPortOlcumCihazi
            // 
            this.lblComPortOlcumCihazi.AutoSize = true;
            this.lblComPortOlcumCihazi.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblComPortOlcumCihazi.Location = new System.Drawing.Point(17, 84);
            this.lblComPortOlcumCihazi.Name = "lblComPortOlcumCihazi";
            this.lblComPortOlcumCihazi.Size = new System.Drawing.Size(290, 37);
            this.lblComPortOlcumCihazi.TabIndex = 5;
            this.lblComPortOlcumCihazi.Text = "Ölçüm Aleti Bağlantısı :";
            // 
            // cmbComPortIslemci
            // 
            this.cmbComPortIslemci.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbComPortIslemci.FormattingEnabled = true;
            this.cmbComPortIslemci.Location = new System.Drawing.Point(300, 30);
            this.cmbComPortIslemci.Name = "cmbComPortIslemci";
            this.cmbComPortIslemci.Size = new System.Drawing.Size(266, 45);
            this.cmbComPortIslemci.TabIndex = 4;
            // 
            // lblComPortIslemci
            // 
            this.lblComPortIslemci.AutoSize = true;
            this.lblComPortIslemci.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblComPortIslemci.Location = new System.Drawing.Point(17, 33);
            this.lblComPortIslemci.Name = "lblComPortIslemci";
            this.lblComPortIslemci.Size = new System.Drawing.Size(233, 37);
            this.lblComPortIslemci.TabIndex = 0;
            this.lblComPortIslemci.Text = "İşlemci Bağlantısı :";
            // 
            // grpBarkod
            // 
            this.grpBarkod.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpBarkod.Controls.Add(this.txtFirmaAdi);
            this.grpBarkod.Controls.Add(this.lblFirmaAdi);
            this.grpBarkod.Controls.Add(this.txtTestTarihiKodu);
            this.grpBarkod.Controls.Add(this.lblTestTarihiKodu);
            this.grpBarkod.Controls.Add(this.txtUretimTarihiKodu);
            this.grpBarkod.Controls.Add(this.lblUretimTarihiKodu);
            this.grpBarkod.Controls.Add(this.txtUrunKodu);
            this.grpBarkod.Controls.Add(this.txtUrunGrupKodu);
            this.grpBarkod.Controls.Add(this.lblUrunKodu);
            this.grpBarkod.Controls.Add(this.lblUrunGrupKodu);
            this.grpBarkod.Controls.Add(this.txtUrunStokKodu);
            this.grpBarkod.Controls.Add(this.txtFirmaKodu);
            this.grpBarkod.Controls.Add(this.lblUrunStokKodu);
            this.grpBarkod.Controls.Add(this.lblFirmaKodu);
            this.grpBarkod.Location = new System.Drawing.Point(594, 185);
            this.grpBarkod.Name = "grpBarkod";
            this.grpBarkod.Size = new System.Drawing.Size(572, 470);
            this.grpBarkod.TabIndex = 7;
            this.grpBarkod.TabStop = false;
            this.grpBarkod.Text = "Barkod Ayarları";
            // 
            // txtFirmaAdi
            // 
            this.txtFirmaAdi.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFirmaAdi.Location = new System.Drawing.Point(310, 109);
            this.txtFirmaAdi.Name = "txtFirmaAdi";
            this.txtFirmaAdi.Size = new System.Drawing.Size(256, 43);
            this.txtFirmaAdi.TabIndex = 22;
            // 
            // lblFirmaAdi
            // 
            this.lblFirmaAdi.AutoSize = true;
            this.lblFirmaAdi.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFirmaAdi.Location = new System.Drawing.Point(17, 112);
            this.lblFirmaAdi.Name = "lblFirmaAdi";
            this.lblFirmaAdi.Size = new System.Drawing.Size(143, 37);
            this.lblFirmaAdi.TabIndex = 21;
            this.lblFirmaAdi.Text = "Firma Adı :";
            // 
            // txtTestTarihiKodu
            // 
            this.txtTestTarihiKodu.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTestTarihiKodu.Location = new System.Drawing.Point(310, 358);
            this.txtTestTarihiKodu.Name = "txtTestTarihiKodu";
            this.txtTestTarihiKodu.Size = new System.Drawing.Size(256, 43);
            this.txtTestTarihiKodu.TabIndex = 20;
            // 
            // lblTestTarihiKodu
            // 
            this.lblTestTarihiKodu.AutoSize = true;
            this.lblTestTarihiKodu.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTestTarihiKodu.Location = new System.Drawing.Point(17, 361);
            this.lblTestTarihiKodu.Name = "lblTestTarihiKodu";
            this.lblTestTarihiKodu.Size = new System.Drawing.Size(214, 37);
            this.lblTestTarihiKodu.TabIndex = 19;
            this.lblTestTarihiKodu.Text = "Test Tarihi Kodu :";
            // 
            // txtUretimTarihiKodu
            // 
            this.txtUretimTarihiKodu.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUretimTarihiKodu.Location = new System.Drawing.Point(310, 309);
            this.txtUretimTarihiKodu.Name = "txtUretimTarihiKodu";
            this.txtUretimTarihiKodu.Size = new System.Drawing.Size(256, 43);
            this.txtUretimTarihiKodu.TabIndex = 18;
            // 
            // lblUretimTarihiKodu
            // 
            this.lblUretimTarihiKodu.AutoSize = true;
            this.lblUretimTarihiKodu.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUretimTarihiKodu.Location = new System.Drawing.Point(17, 312);
            this.lblUretimTarihiKodu.Name = "lblUretimTarihiKodu";
            this.lblUretimTarihiKodu.Size = new System.Drawing.Size(250, 37);
            this.lblUretimTarihiKodu.TabIndex = 17;
            this.lblUretimTarihiKodu.Text = "Üretim Tarihi Kodu :";
            // 
            // txtUrunKodu
            // 
            this.txtUrunKodu.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUrunKodu.Location = new System.Drawing.Point(310, 258);
            this.txtUrunKodu.Name = "txtUrunKodu";
            this.txtUrunKodu.Size = new System.Drawing.Size(256, 43);
            this.txtUrunKodu.TabIndex = 16;
            // 
            // txtUrunGrupKodu
            // 
            this.txtUrunGrupKodu.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUrunGrupKodu.Location = new System.Drawing.Point(310, 209);
            this.txtUrunGrupKodu.Name = "txtUrunGrupKodu";
            this.txtUrunGrupKodu.Size = new System.Drawing.Size(256, 43);
            this.txtUrunGrupKodu.TabIndex = 15;
            // 
            // lblUrunKodu
            // 
            this.lblUrunKodu.AutoSize = true;
            this.lblUrunKodu.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUrunKodu.Location = new System.Drawing.Point(17, 261);
            this.lblUrunKodu.Name = "lblUrunKodu";
            this.lblUrunKodu.Size = new System.Drawing.Size(157, 37);
            this.lblUrunKodu.TabIndex = 14;
            this.lblUrunKodu.Text = "Ürün Kodu :";
            // 
            // lblUrunGrupKodu
            // 
            this.lblUrunGrupKodu.AutoSize = true;
            this.lblUrunGrupKodu.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUrunGrupKodu.Location = new System.Drawing.Point(17, 212);
            this.lblUrunGrupKodu.Name = "lblUrunGrupKodu";
            this.lblUrunGrupKodu.Size = new System.Drawing.Size(223, 37);
            this.lblUrunGrupKodu.TabIndex = 13;
            this.lblUrunGrupKodu.Text = "Ürün Grup Kodu :";
            // 
            // txtUrunStokKodu
            // 
            this.txtUrunStokKodu.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUrunStokKodu.Location = new System.Drawing.Point(310, 158);
            this.txtUrunStokKodu.Name = "txtUrunStokKodu";
            this.txtUrunStokKodu.Size = new System.Drawing.Size(256, 43);
            this.txtUrunStokKodu.TabIndex = 12;
            // 
            // txtFirmaKodu
            // 
            this.txtFirmaKodu.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFirmaKodu.Location = new System.Drawing.Point(310, 60);
            this.txtFirmaKodu.Name = "txtFirmaKodu";
            this.txtFirmaKodu.Size = new System.Drawing.Size(256, 43);
            this.txtFirmaKodu.TabIndex = 11;
            // 
            // lblUrunStokKodu
            // 
            this.lblUrunStokKodu.AutoSize = true;
            this.lblUrunStokKodu.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUrunStokKodu.Location = new System.Drawing.Point(17, 161);
            this.lblUrunStokKodu.Name = "lblUrunStokKodu";
            this.lblUrunStokKodu.Size = new System.Drawing.Size(215, 37);
            this.lblUrunStokKodu.TabIndex = 5;
            this.lblUrunStokKodu.Text = "Ürün Stok Kodu :";
            // 
            // lblFirmaKodu
            // 
            this.lblFirmaKodu.AutoSize = true;
            this.lblFirmaKodu.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFirmaKodu.Location = new System.Drawing.Point(17, 63);
            this.lblFirmaKodu.Name = "lblFirmaKodu";
            this.lblFirmaKodu.Size = new System.Drawing.Size(165, 37);
            this.lblFirmaKodu.TabIndex = 0;
            this.lblFirmaKodu.Text = "Firma Kodu :";
            // 
            // btnIptal
            // 
            this.btnIptal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnIptal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnIptal.Location = new System.Drawing.Point(904, 677);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(256, 74);
            this.btnIptal.TabIndex = 9;
            this.btnIptal.Text = "İPTAL";
            this.btnIptal.UseVisualStyleBackColor = true;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnKaydet.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnKaydet.Location = new System.Drawing.Point(617, 677);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(256, 74);
            this.btnKaydet.TabIndex = 8;
            this.btnKaydet.Text = "KAYDET";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // grpAdminInfo
            // 
            this.grpAdminInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpAdminInfo.Controls.Add(this.txtAdminPassword);
            this.grpAdminInfo.Controls.Add(this.lblAdminPassword);
            this.grpAdminInfo.Controls.Add(this.txtAdminUsername);
            this.grpAdminInfo.Controls.Add(this.lblAdminUsername);
            this.grpAdminInfo.Location = new System.Drawing.Point(12, 185);
            this.grpAdminInfo.Name = "grpAdminInfo";
            this.grpAdminInfo.Size = new System.Drawing.Size(572, 149);
            this.grpAdminInfo.TabIndex = 4;
            this.grpAdminInfo.TabStop = false;
            this.grpAdminInfo.Text = "Yönetici Ayarları";
            // 
            // txtAdminPassword
            // 
            this.txtAdminPassword.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAdminPassword.Location = new System.Drawing.Point(245, 80);
            this.txtAdminPassword.Name = "txtAdminPassword";
            this.txtAdminPassword.Size = new System.Drawing.Size(321, 43);
            this.txtAdminPassword.TabIndex = 3;
            // 
            // lblAdminPassword
            // 
            this.lblAdminPassword.AutoSize = true;
            this.lblAdminPassword.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAdminPassword.Location = new System.Drawing.Point(17, 83);
            this.lblAdminPassword.Name = "lblAdminPassword";
            this.lblAdminPassword.Size = new System.Drawing.Size(200, 37);
            this.lblAdminPassword.TabIndex = 2;
            this.lblAdminPassword.Text = "Yönetici Şifresi :";
            // 
            // txtAdminUsername
            // 
            this.txtAdminUsername.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAdminUsername.Location = new System.Drawing.Point(245, 31);
            this.txtAdminUsername.Name = "txtAdminUsername";
            this.txtAdminUsername.Size = new System.Drawing.Size(321, 43);
            this.txtAdminUsername.TabIndex = 1;
            // 
            // lblAdminUsername
            // 
            this.lblAdminUsername.AutoSize = true;
            this.lblAdminUsername.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAdminUsername.Location = new System.Drawing.Point(17, 34);
            this.lblAdminUsername.Name = "lblAdminUsername";
            this.lblAdminUsername.Size = new System.Drawing.Size(170, 37);
            this.lblAdminUsername.TabIndex = 0;
            this.lblAdminUsername.Text = "Yönetici Adı :";
            // 
            // Ayarlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 763);
            this.Controls.Add(this.grpAdminInfo);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.grpBarkod);
            this.Controls.Add(this.grpComPort);
            this.Controls.Add(this.grpPrinter);
            this.Controls.Add(this.grpVeritabani);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Ayarlar";
            this.ShowIcon = false;
            this.Text = "Ayarlar";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Ayarlar_FormClosing);
            this.Load += new System.EventHandler(this.Ayarlar_Load);
            this.grpVeritabani.ResumeLayout(false);
            this.grpVeritabani.PerformLayout();
            this.grpPrinter.ResumeLayout(false);
            this.grpPrinter.PerformLayout();
            this.grpComPort.ResumeLayout(false);
            this.grpComPort.PerformLayout();
            this.grpBarkod.ResumeLayout(false);
            this.grpBarkod.PerformLayout();
            this.grpAdminInfo.ResumeLayout(false);
            this.grpAdminInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpVeritabani;
        private System.Windows.Forms.Button btnDbGenerate;
        private System.Windows.Forms.Button btnDbTest;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Label lblConnectionString;
        private System.Windows.Forms.GroupBox grpPrinter;
        private System.Windows.Forms.Button btnBarkodTest;
        private System.Windows.Forms.Label lblPrinter;
        private System.Windows.Forms.ComboBox cmbPrinter;
        private System.Windows.Forms.GroupBox grpComPort;
        private System.Windows.Forms.ComboBox cmbComPortIslemci;
        private System.Windows.Forms.Label lblComPortIslemci;
        private System.Windows.Forms.ComboBox cmbComPortOlcumAleti;
        private System.Windows.Forms.Label lblComPortOlcumCihazi;
        private System.Windows.Forms.GroupBox grpBarkod;
        private System.Windows.Forms.Label lblUrunStokKodu;
        private System.Windows.Forms.Label lblFirmaKodu;
        private System.Windows.Forms.Button btnIptal;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.TextBox txtUrunKodu;
        private System.Windows.Forms.TextBox txtUrunGrupKodu;
        private System.Windows.Forms.Label lblUrunKodu;
        private System.Windows.Forms.Label lblUrunGrupKodu;
        private System.Windows.Forms.TextBox txtUrunStokKodu;
        private System.Windows.Forms.TextBox txtFirmaKodu;
        private System.Windows.Forms.TextBox txtUretimTarihiKodu;
        private System.Windows.Forms.Label lblUretimTarihiKodu;
        private System.Windows.Forms.TextBox txtTestTarihiKodu;
        private System.Windows.Forms.Label lblTestTarihiKodu;
        private System.Windows.Forms.GroupBox grpAdminInfo;
        private System.Windows.Forms.TextBox txtAdminPassword;
        private System.Windows.Forms.Label lblAdminPassword;
        private System.Windows.Forms.TextBox txtAdminUsername;
        private System.Windows.Forms.Label lblAdminUsername;
        private System.Windows.Forms.TextBox txtFirmaAdi;
        private System.Windows.Forms.Label lblFirmaAdi;
    }
}