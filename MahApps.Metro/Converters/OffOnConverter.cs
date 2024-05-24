using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using MahApps.Metro.Controls;

namespace MahApps.Metro.Converters
{
	// Token: 0x02000017 RID: 23
	[Obsolete("This converter will be deleted in the next release.")]
	public class OffOnConverter : IValueConverter
	{
		// Token: 0x0600008B RID: 139 RVA: 0x00003638 File Offset: 0x00001838
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			ToggleSwitch toggleSwitch = (ToggleSwitch)parameter;
			if (!(toggleSwitch.IsChecked == true))
			{
				return toggleSwitch.OffLabel;
			}
			return toggleSwitch.OnLabel;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00003678 File Offset: 0x00001878
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}
	}
}
