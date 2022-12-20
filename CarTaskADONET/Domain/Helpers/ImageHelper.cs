using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace CarTaskADONET.Domain.Helpers
{
    public class ImageHelper
    {
        public ImageSource StringToImageSource(string source)
        {
            try
            {
                if (!source.Contains("https://"))
                    source = "https://" + source;

                var imgUrl = new Uri(source);
                var imageData = new WebClient().DownloadData(imgUrl);
                return ByteImageConverter.ByteToImage(imageData);
            }
            catch (Exception)
            {
                return null;
            }

        }

        //public string GetImagePath(byte[] buffer, int counter)
        //{
        //    ImageConverter ic = new ImageConverter();
        //    var data = ic.ConvertFrom(buffer);

        //    System.Drawing.Image img = data as System.Drawing.Image;
        //    if (img != null)
        //    {
        //        Bitmap bitmap1 = new Bitmap(img);

        //        var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Images");
        //        Directory.CreateDirectory(path);
        //        bitmap1.Save($@"{path}\image{counter}.png");
        //        var imagepath = $@"{path}\image{counter}.png";
        //        return imagepath;
        //    }
        //    else
        //    {
        //        return String.Empty;
        //    }

        //}
        //public byte[] GetBytesOfImage(string path)
        //{
        //    var image = new Bitmap(path);
        //    ImageConverter imageconverter = new ImageConverter();
        //    var imagebytes = ((byte[])imageconverter.ConvertTo(image, typeof(byte[])));
        //    return imagebytes;
        //}

    }

    public class ByteImageConverter
    {
        public static ImageSource ByteToImage(byte[] imageData)
        {
            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(imageData);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();

            ImageSource imgSrc = biImg as ImageSource;

            return imgSrc;
        }
    }
}
