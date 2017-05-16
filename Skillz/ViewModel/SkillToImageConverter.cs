using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using Skillz.Models;

namespace Skillz.ViewModel
{
    public class SkillToImageConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var attachmentType = (SkillTypes) Enum.Parse(typeof(SkillTypes), value.ToString());

            return string.Format("/Skillz;component/Images/{0}-icon.png", attachmentType);
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
