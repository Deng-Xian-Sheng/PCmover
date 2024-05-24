using System;
using System.Globalization;
using System.Windows.Data;

namespace Laplink.Tools.Ui.Converters
{
	// Token: 0x02000008 RID: 8
	public class FileSizeConverter : IValueConverter
	{
		// Token: 0x0600001B RID: 27 RVA: 0x000022A0 File Offset: 0x000004A0
		public static string ToString(ulong bytes)
		{
			int num = (bytes == 0UL) ? 0 : ((int)Math.Log(bytes, 1024.0));
			if (num == 0)
			{
				return string.Format("{0} bytes", bytes);
			}
			double num2 = Math.Round(bytes / Math.Pow(1024.0, (double)num), 1);
			return string.Format("{0:n1} {1}", num2, FileSizeConverter._sizeSuffixes[num]);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000230C File Offset: 0x0000050C
		public static string ToString(double dblBytes)
		{
			return FileSizeConverter.ToString(System.Convert.ToUInt64(Math.Abs(dblBytes)));
		}

		// Token: 0x0600001D RID: 29 RVA: 0x0000231E File Offset: 0x0000051E
		public static string ToString(long lngBytes)
		{
			return FileSizeConverter.ToString((ulong)Math.Abs(lngBytes));
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000232B File Offset: 0x0000052B
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return FileSizeConverter.ToString(System.Convert.ToUInt64(value));
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002338 File Offset: 0x00000538
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		// Token: 0x04000005 RID: 5
		private static string[] _sizeSuffixes = new string[]
		{
			"bytes",
			"KB",
			"MB",
			"GB",
			"TB",
			"PB",
			"EB"
		};
	}
}
