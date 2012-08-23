using System;
using System.Globalization;
using System.Windows.Data;

namespace VictoriaMessenger.Converters
{
	public class TimeConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (parameter != null)
			{
				var formatterString = parameter.ToString();
				if (!string.IsNullOrEmpty(formatterString))
				{
					return string.Format(culture, string.Format("{{0:{0}}}", formatterString), value);
				}
			}

			return (value ?? string.Empty).ToString();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}