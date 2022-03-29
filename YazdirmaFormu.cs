using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgePodKartTest
{
    public partial class YazdirmaFormu : Form
    {
        public YazdirmaFormu()
        {
            InitializeComponent();
        }
        public void AlanlariSetEt(Image qrCode, string firmaAdi, string grupKodu)
        {
            //Size newSize = new Size(88, 88);
            //var imageSize = qrCode.Size;
            //var fitSize = picQrcode.ClientSize;
            //picQrcode.SizeMode = imageSize.Width > fitSize.Width || imageSize.Height > fitSize.Height ?
            //    PictureBoxSizeMode.Zoom : PictureBoxSizeMode.CenterImage;

            lblFirmaKodu.Text = firmaAdi;
            lblGrupStkKod.Text = grupKodu;
            lblTestTarihi.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            //SizeLabelFont(lblFirmaKodu);
            SizeLabelFont(lblGrupStkKod);
            //SizeLabelFont(lblTestTarihi);

            picQrcode.Image = qrCode;
        }

        // Copy this text into the Label using
        // the biggest font that will fit.
        private void SizeLabelFont(Label lbl)
        {
            // Only bother if there's text.
            string txt = lbl.Text;
            if (txt.Length > 0)
            {
                int best_size = 100;

                // See how much room we have, allowing a bit
                // for the Label's internal margin.
                int wid = lbl.DisplayRectangle.Width;
                int hgt = lbl.DisplayRectangle.Height;

                // Make a Graphics object to measure the text.
                using (Graphics gr = lbl.CreateGraphics())
                {
                    for (int i = 1; i <= 100; i++)
                    {
                        using (Font test_font =
                            new Font(lbl.Font.FontFamily, i))
                        {
                            // See how much space the text would
                            // need, specifying a maximum width.
                            SizeF text_size =
                                gr.MeasureString(txt, test_font);
                            if ((text_size.Width > wid) ||
                                (text_size.Height > hgt))
                            {
                                best_size = i - 4;
                                break;
                            }
                        }
                    }
                }

                // Use that font size.
                lbl.Font = new Font(lbl.Font.FontFamily, best_size);
            }
        }
    }
}
