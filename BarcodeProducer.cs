using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Reflection;

namespace ProgePodKartTest
{
    public class BarcodeProducer
    {
        private QRCodeGenerator qrGenerator;
        private Image printingImg;
        private Image printingFrm;

        public BarcodeProducer()
        {
            qrGenerator = new QRCodeGenerator();
        }


        public Image GenerateQRCode(string data) {
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            qrCode.SetQRCodeData(qrCodeData);
            printingImg = qrCode.GetGraphic(2);
            
            // enlarge qrcode
            //Size newSize = new Size(75,75);
            printingImg = ScaleImage(printingImg, 75);


            return printingImg;

        }


        public Image ScaleImage(Image image, int height)
        {
            double ratio = (double)height / image.Height;
            int newWidth = (int)(image.Width * ratio);
            int newHeight = (int)(image.Height * ratio);
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            image.Dispose();
            return newImage;
        }



        public Image ResizeImage(Image imgToResize, Size size)
        {
            //Get the image current width  
            int sourceWidth = imgToResize.Width;
            //Get the image current height  
            int sourceHeight = imgToResize.Height;
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            //Calulate  width with new desired size  
            nPercentW = ((float)size.Width / (float)sourceWidth);
            //Calculate height with new desired size  
            nPercentH = ((float)size.Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;
            //New Width  
            int destWidth = (int)(sourceWidth * nPercent);
            //New Height  
            int destHeight = (int)(sourceHeight * nPercent);
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // Draw image with new width and height  
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (System.Drawing.Image)b;
        }


        public bool PrintReport(Image qrImg) 
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(PrintPage);
                // Print the document.
                pd.Print();
                return true;
            }
            catch(Exception ex)
            {
            }

            return false;
        }


        public bool PrintReport(Image qrImg, string firmaAdi, string grpStokKodu)
        {
            try
            {

                #region YazdirmaFormu Alanlarini Ayarla

                var f = new YazdirmaFormu();
                f.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
                var createControl = f.GetType().GetMethod("CreateControl",
                                BindingFlags.Instance | BindingFlags.NonPublic);
                createControl.Invoke(f, new object[] { true });

                f.AlanlariSetEt(qrImg, firmaAdi, grpStokKodu);
                var bm = new Bitmap(f.Width, f.Height);
                f.DrawToBitmap(bm, new Rectangle(0, 0, bm.Width, bm.Height));
                printingFrm = bm;
                //bm.Save(@"C:\bm.bmp");

                PrintReport(bm);

                #endregion

                //PrintDocument pd = new PrintDocument();
                //pd.PrintPage += new PrintPageEventHandler(PrintPage);
                //// Print the document.
                //pd.Print();
                return true;
            }
            catch (Exception ex)
            {
            }

            return false;
        }


        private void PrintPage(object o, PrintPageEventArgs e)
        {
            System.Drawing.Image img = printingFrm;
            //img = Image.FromFile(@"C:\DEV\source\repos\Projects\Proge\ProgePodKartTest\ProgePodKartTest\img\qrSample.png");
            //e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            //e.Graphics.PageScale = 3f;
            Point loc = new Point(0, 0);
            e.Graphics.DrawImage(img, loc);
            img.Dispose();
            printingFrm.Dispose();
        }
    }
}
