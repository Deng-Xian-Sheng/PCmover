using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace MahApps.Metro.Converters
{
	// Token: 0x02000021 RID: 33
	public class TreeViewMarginConverter : IValueConverter
	{
		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060000B7 RID: 183 RVA: 0x00003C1A File Offset: 0x00001E1A
		// (set) Token: 0x060000B8 RID: 184 RVA: 0x00003C22 File Offset: 0x00001E22
		public double Length { get; set; }

		// Token: 0x060000B9 RID: 185 RVA: 0x00003C2C File Offset: 0x00001E2C
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			TreeViewItem treeViewItem = value as TreeViewItem;
			if (treeViewItem == null)
			{
				return new Thickness(0.0);
			}
			return new Thickness(this.Length * (double)treeViewItem.GetDepth(), 0.0, 0.0, 0.0);
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00003C8A File Offset: 0x00001E8A
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}
	}
}
