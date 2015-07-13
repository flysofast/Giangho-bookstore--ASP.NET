using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QlSach.Class
{
    public partial class CaptchaVal : System.Web.UI.Page
    {
        public static string randomStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            randomStr = "";
            Bitmap objBMP = new Bitmap(600, 200);
            Graphics objGraphics = System.Drawing.Graphics.FromImage(objBMP);
            objGraphics.Clear(Color.OrangeRed);
            objGraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            Font objFont = new Font("Arial", 100, FontStyle.Bold);
         
            int x;
            Random autoRand = new Random();
            for (x = 0; x < 6; x++)
            {
               
                randomStr += (char)autoRand.Next(97, 122);
            }

            objGraphics.RotateTransform(-4);
            objGraphics.ScaleTransform(0.8F, 1.5F);
            objGraphics.DrawString(randomStr, objFont, Brushes.White,-10,-10);
            Response.ContentType = "image/GIF";
            objBMP.Save(Response.OutputStream, ImageFormat.Gif);
            objFont.Dispose();
            objGraphics.Dispose();
            objBMP.Dispose();
        }
    }
}