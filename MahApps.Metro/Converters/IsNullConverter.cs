using System;
using System.Globalization;
using System.Windows.Data;

namespace MahApps.Metro.Converters
{
	// Token: 0x0200000C RID: 12
	public sealed class IsNullConverter : IValueConverter
	{
		// Token: 0x0600004F RID: 79 RVA: 0x000031E1 File Offset: 0x000013E1
		private IsNullConverter()
		{
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000050 RID: 80 RVA: 0x000031E9 File Offset: 0x000013E9
		public static IsNullConverter Instance
		{
			get
			{
				IsNullConverter result;
				if ((result = IsNullConverter._instance) == null)
				{
					result = (IsNullConverter._instance = new IsNullConverter());
				}
				return result;
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000031FF File Offset: 0x000013FF
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value == null;
		}

		// Token: 0x06000052 RID: 82 RVA: 0x0000320A File Offset: 0x0000140A
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}

		// Token: 0x0400000E RID: 14
		private static IsNullConverter _instance;
	}
}
