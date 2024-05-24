using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace MahApps.Metro.Converters
{
	// Token: 0x02000019 RID: 25
	public sealed class ResizeModeMinMaxButtonVisibilityConverter : IMultiValueConverter
	{
		// Token: 0x06000094 RID: 148 RVA: 0x000036E9 File Offset: 0x000018E9
		private ResizeModeMinMaxButtonVisibilityConverter()
		{
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000095 RID: 149 RVA: 0x000036F1 File Offset: 0x000018F1
		public static ResizeModeMinMaxButtonVisibilityConverter Instance
		{
			get
			{
				ResizeModeMinMaxButtonVisibilityConverter result;
				if ((result = ResizeModeMinMaxButtonVisibilityConverter._instance) == null)
				{
					result = (ResizeModeMinMaxButtonVisibilityConverter._instance = new ResizeModeMinMaxButtonVisibilityConverter());
				}
				return result;
			}
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00003708 File Offset: 0x00001908
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			string text = parameter as string;
			if (values == null || string.IsNullOrEmpty(text))
			{
				return Visibility.Visible;
			}
			bool flag = values.Length != 0 && (bool)values[0];
			bool flag2 = values.Length > 1 && (bool)values[1];
			ResizeMode resizeMode = (values.Length > 2) ? ((ResizeMode)values[2]) : ResizeMode.CanResize;
			if (text == "CLOSE")
			{
				return (flag2 || !flag) ? Visibility.Collapsed : Visibility.Visible;
			}
			switch (resizeMode)
			{
			case ResizeMode.NoResize:
				return Visibility.Collapsed;
			case ResizeMode.CanMinimize:
				if (text == "MIN")
				{
					return (flag2 || !flag) ? Visibility.Collapsed : Visibility.Visible;
				}
				return Visibility.Collapsed;
			}
			return (flag2 || !flag) ? Visibility.Collapsed : Visibility.Visible;
		}

		// Token: 0x06000097 RID: 151 RVA: 0x000037D7 File Offset: 0x000019D7
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			return (from t in targetTypes
			select DependencyProperty.UnsetValue).ToArray<object>();
		}

		// Token: 0x0400001F RID: 31
		private static ResizeModeMinMaxButtonVisibilityConverter _instance;
	}
}
