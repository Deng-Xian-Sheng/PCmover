using System;
using System.Globalization;
using System.Windows.Data;

namespace Laplink.Tools.Ui.Converters
{
	// Token: 0x02000007 RID: 7
	public class NotSetConverter : IValueConverter
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000016 RID: 22 RVA: 0x0000224D File Offset: 0x0000044D
		// (set) Token: 0x06000017 RID: 23 RVA: 0x00002255 File Offset: 0x00000455
		public string NotSetValue { get; set; } = "Not Set";

		// Token: 0x06000018 RID: 24 RVA: 0x0000225E File Offset: 0x0000045E
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!string.IsNullOrWhiteSpace(value as string))
			{
				return value;
			}
			return this.NotSetValue;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002275 File Offset: 0x00000475
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(this.NotSetValue == value as string))
			{
				return value;
			}
			return null;
		}
	}
}
