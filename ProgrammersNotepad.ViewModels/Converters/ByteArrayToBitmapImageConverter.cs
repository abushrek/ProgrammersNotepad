using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace ProgrammersNotepad.ViewModels.Converters
{
    public class ByteArrayToBitmapImageConverter : IValueConverter
    {
        public static BitmapImage ConvertByteArrayToBitMapImage(byte[] imageByteArray)
        {
            BitmapImage image = new BitmapImage();
            MemoryStream stream = new MemoryStream(imageByteArray);
            stream.Seek(0, SeekOrigin.Begin);
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();
            return image;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is byte[] imageByteArray) 
                return ConvertByteArrayToBitMapImage(imageByteArray);
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}