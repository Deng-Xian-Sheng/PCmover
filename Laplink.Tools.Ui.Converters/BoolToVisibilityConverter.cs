using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Laplink.Tools.Ui.Converters
{
	// Token: 0x0200000B RID: 11
	public class BoolToVisibilityConverter : VisibilityConverter, IValueConverter
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000029 RID: 41 RVA: 0x00002450 File Offset: 0x00000650
		// (set) Token: 0x0600002A RID: 42 RVA: 0x00002458 File Offset: 0x00000658
		public string StringHidden { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600002B RID: 43 RVA: 0x00002461 File Offset: 0x00000661
		// (set) Token: 0x0600002C RID: 44 RVA: 0x00002469 File Offset: 0x00000669
		public Visibility VisibilityHidden { get; set; }

		// Token: 0x0600002D RID: 45 RVA: 0x00002472 File Offset: 0x00000672
		public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return base.Convert((bool)value, parameter);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002486 File Offset: 0x00000686
		public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (Visibility)value == Visibility.Visible;
		}
	}
}
