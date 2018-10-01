using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WpfTreeView
{
    [ValueConversion(typeof(DirectoryItemType), typeof(BitmapImage))]
    class HeaderToImageConverter : IValueConverter
    {
        
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();
        /// <summary>
        /// Convert a full path to a specific image type of a drive folder or file
        /// </summary>
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            var name = DirectoryStructure.GetFileFolderName(path);

            
            //by default, we presume an image
            var image = "Images/download.jpg";

            switch((DirectoryItemType)value)
            {
                case DirectoryItemType.Drive:
                    image = "Image/drive.png";
                    break;
                case DirectoryItemType.Folder:
                    image = "Image/download.jpg";
                    break;
            }

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
