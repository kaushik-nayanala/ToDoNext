using System.Configuration;
using System.Data;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace MainProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

    }


    public class InvertVisibilityConverter : IValueConverter
    {
     
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility vis)
            {
                return (vis == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
            }

            if (value is bool b)
            {
                return b ? Visibility.Collapsed : Visibility.Visible;
            }

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(value, targetType, parameter, culture);
        }
    }

    public class VisualBrushScaleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length != 6) return Transform.Identity;
            double BEWt = (double)values[0];
            double BEHt = (double)values[1];

            double BIWt = (double)values[2];
            double BIHt = (double)values[3];

            double posx = (double)values[4];
            double posy = (double)values[5];

            double scalex = BIWt / BEWt;
            double scaley = BIHt / BEHt;

            double centerx = -(posx) / BEWt;
            double centery = -(posy) / BEHt;


            var group = new TransformGroup();
            
            // Apply Scale first to map the whole image to the label size
            group.Children.Add(new ScaleTransform(scalex, scaley));

            // Apply Translation to move the "window" to the correct segment
            group.Children.Add(new TranslateTransform(centerx, centery));

            return group;
            //return tg;
        }
        public object[] ConvertBack(object values, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
