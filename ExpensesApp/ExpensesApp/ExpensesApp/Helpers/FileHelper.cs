using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExpensesApp.Helpers
{
    public class FileHelper
    {
        public static string ImageSourceToBase64(ImageSource imageSource)
        {
            string result = null;
            if (imageSource == null) return result;
            StreamImageSource streamImageSource = (StreamImageSource)imageSource;
            System.Threading.CancellationToken cancellationToken = System.Threading.CancellationToken.None;
            Task<Stream> task = streamImageSource.Stream(cancellationToken);
            Stream stream = task.Result;

            byte[] arrayByte;
            using(MemoryStream memoryStream=new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                arrayByte = memoryStream.ToArray();
                result = Convert.ToBase64String(arrayByte);
            }
            return result;
        }
    }
}
