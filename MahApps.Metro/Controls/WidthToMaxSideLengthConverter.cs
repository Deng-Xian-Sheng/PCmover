using System;
using System.Globalization;
using System.Windows.Data;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000078 RID: 120
	[Obsolete("This class will be deleted in the next release.")]
	internal class WidthToMaxSideLengthConverter : IValueConverter
	{
		// Token: 0x0600060A RID: 1546 RVA: 0x00017CE8 File Offset: 0x00015EE8
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is double)
			{
				double num = (double)value;
				return (num <= 20.0) ? 20.0 : num;
			}
			return null;
		}

		// Token: 0x0600060B RID: 1547 RVA: 0x00017D23 File Offset: 0x00015F23
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
