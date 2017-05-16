using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Skillz.ViewModel
{
    public class SkillToImageConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Format("/Skillz;component/Images/{0}-icon.png", value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
