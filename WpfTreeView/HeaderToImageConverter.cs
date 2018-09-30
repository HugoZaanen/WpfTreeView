using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WpfTreeView
{
    [ValueConversion(typeof(string), typeof(BitmapImage))]
    class HeaderToImageConverter : IValueConverter
    {
        
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();
        /// <summary>
        /// Convert a full path to a specific image type of a drive folder or file
        /// </summary>
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Get the full path
            var path = (string)value;

            //If the path is null,ignore
            if (path == null)
                return null;

            var name = DirectoryStructure.GetFileFolderName(path);

            var image = "Images/download.jpg";

            // if the name is blank we presume it's  a drive as we cannot have a blank file or folder name
            if (string.IsNullOrEmpty(name))
                image = "Images/download.jpg";
            else if(new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory))
                image = "Images/afv_icon.png";
            
            return new BitmapImage(new Uri($"pack://application:,,,/{image}"));            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
