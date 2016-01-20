using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace AutoLote.Helpers
{
    public enum Tamanos
    {        Miniatura,
        Mediana
     }
    public class GuardarImagen
    {

        public String ResizeAndSave(String filename, Stream imageBuffer,Tamanos tamano, bool makeItSquare)
        {

            int newWidth;
            int newHeight;
            Image image = Image.FromStream(imageBuffer);
            int oldWidth = image.Width;
            int oldHeight=image.Height;

            Bitmap newImage;
            String savePath;
            int maxSideSize;
            String urlImage = String.Empty;

            String serverPath = HttpContext.Current.Server.MapPath("~");
            String imagesPath = serverPath + "Content\\Imagenes\\";

            if (tamano == Tamanos.Miniatura)
            {

                urlImage += "~/Content/imagenes/Miniatura/" + filename + ".jpg";
                maxSideSize = 80;
                savePath = imagesPath + "Miniatura\\" + filename + ".jpg";

            }
            else
            {
                urlImage += "~/Content/imagenes/Mediana/" + filename + ".jpg";
                maxSideSize = 600;
                savePath = imagesPath + "Mediana\\" + filename + ".jpg";
            
            }


            if (makeItSquare)
            {
                int smallerSide = oldWidth >= oldHeight ? oldHeight : oldWidth;
                double coeficient = maxSideSize / (double)smallerSide;
                newWidth = Convert.ToInt32(coeficient * oldWidth);
                newHeight = Convert.ToInt32(coeficient * oldHeight);
                Bitmap tempImage = new Bitmap(image, newWidth, newHeight);
                int cropX = (newWidth - maxSideSize) / 2;
                int cropY = (newHeight - maxSideSize) / 2;
                newImage = new Bitmap(maxSideSize, maxSideSize);
                Graphics tempGraphic = Graphics.FromImage(newImage);
                tempGraphic.SmoothingMode = SmoothingMode.AntiAlias;
                tempGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                tempGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                tempGraphic.DrawImage(tempImage, new Rectangle(0, 0, maxSideSize, maxSideSize), cropX, cropY, maxSideSize, maxSideSize, GraphicsUnit.Pixel);


            }
            else
            {
                int maxSide = oldWidth >= oldHeight ? oldWidth : oldHeight;

                if (maxSide > maxSideSize)
                {
                    double coeficient = maxSideSize / (double)maxSide;
                    newWidth = Convert.ToInt32(coeficient * oldWidth);
                    newHeight = Convert.ToInt32(coeficient * oldHeight);
                }
                else
                {
                    newWidth = oldWidth;
                    newHeight = oldHeight;
                }
                try
                {
                    newImage = new Bitmap(image, newWidth, newHeight);
                 
                        newImage.Save(savePath, ImageFormat.Jpeg);
               
                    
                    image.Dispose();
                    newImage.Dispose();
                }
                catch (Exception ex)
                {
                    //explodes at 65567 with "A generic error occurred in GDI+."

                
                }
            
            }
            return urlImage;
        }
    }
}