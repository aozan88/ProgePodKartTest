
namespace ProgePodKartTest
{
    partial class YazdirmaFormu
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
            this.lblGrupStkKod = new System.Windows.Forms.Label();
            this.lblTestTarihi = new System.Windows.Forms.Label();
            this.picQrcode = new System.Windows.Forms.PictureBox();
            this.lblFirmaKodu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picQrcode)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGrupStkKod
            // 
            this.lblGrupStkKod.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGrupStkKod.Font = new System.Drawing.Font("Gill Sans MT Condensed", 1.9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Millimeter);
            this.lblGrupStkKod.ForeColor = System.Drawing.Color.Black;
            this.lblGrupStkKod.Location = new System.Drawing.Point(90, 36);
            this.lblGrupStkKod.MaximumSize = new System.Drawing.Size(124, 32);
            this.lblGrupStkKod.MinimumSize = new System.Drawing.Size(124, 32);
            this.lblGrupStkKod.Name = "lblGrupStkKod";
            this.lblGrupStkKod.Size = new System.Drawing.Size(124, 32);
            this.lblGrupStkKod.TabIndex = 0;
            this.lblGrupStkKod.Text = "GrupStokKodu";
            // 
            // lblTestTarihi
            // 
            this.lblTestTarihi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTestTarihi.Font = new System.Drawing.Font("Gill Sans MT Condensed", 1.9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Millimeter);
            this.lblTestTarihi.ForeColor = System.Drawing.Color.Black;
            this.lblTestTarihi.Location = new System.Drawing.Point(90, 68);
            this.lblTestTarihi.MaximumSize = new System.Drawing.Size(124, 32);
            this.lblTestTarihi.MinimumSize = new System.Drawing.Size(124, 32);
            this.lblTestTarihi.Name = "lblTestTarihi";
            this.lblTestTarihi.Size = new System.Drawing.Size(124, 32);
            this.lblTestTarihi.TabIndex = 2;
            this.lblTestTarihi.Text = "Bugün";
            // 
            // picQrcode
            // 
            this.picQrcode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picQrcode.Location = new System.Drawing.Point(0, 0);
            this.picQrcode.MaximumSize = new System.Drawing.Size(88, 88);
            this.picQrcode.MinimumSize = new System.Drawing.Size(88, 88);
            this.picQrcode.Name = "picQrcode";
            this.picQrcode.Size = new System.Drawing.Size(88, 88);
            this.picQrcode.TabIndex = 3;
            this.picQrcode.TabStop = false;
            // 
            // lblFirmaKodu
            // 
            this.lblFirmaKodu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFirmaKodu.Font = new System.Drawing.Font("Gill Sans MT Condensed", 2.3F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Millimeter);
            this.lblFirmaKodu.ForeColor = System.Drawing.Color.Black;
            this.lblFirmaKodu.Location = new System.Drawing.Point(90, 4);
            this.lblFirmaKodu.MaximumSize = new System.Drawing.Size(124, 32);
            this.lblFirmaKodu.MinimumSize = new System.Drawing.Size(124, 32);
            this.lblFirmaKodu.Name = "lblFirmaKodu";
            this.lblFirmaKodu.Size = new System.Drawing.Size(124, 32);
            this.lblFirmaKodu.TabIndex = 1;
            this.lblFirmaKodu.Text = "Proge. 18028";
            // 
            // YazdirmaFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(218, 108);
            this.Controls.Add(this.picQrcode);
            this.Controls.Add(this.lblTestTarihi);
            this.Controls.Add(this.lblFirmaKodu);
            this.Controls.Add(this.lblGrupStkKod);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(218, 108);
            this.MinimumSize = new System.Drawing.Size(218, 108);
            this.Name = "YazdirmaFormu";
            this.Opacity = 0D;
            this.Text = "YazdirmaFormu";
            ((System.ComponentModel.ISupportInitialize)(this.picQrcode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblGrupStkKod;
        private System.Windows.Forms.Label lblTestTarihi;
        private System.Windows.Forms.PictureBox picQrcode;
        private System.Windows.Forms.Label lblFirmaKodu;
    }
}