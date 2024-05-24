using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MahApps.Metro.Converters
{
	// Token: 0x0200001B RID: 27
	public class ThicknessBindingConverter : IValueConverter
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x00003902 File Offset: 0x00001B02
		// (set) Token: 0x060000A1 RID: 161 RVA: 0x0000390A File Offset: 0x00001B0A
		public ThicknessSideType IgnoreThicknessSide { get; set; }

		// Token: 0x060000A2 RID: 162 RVA: 0x00003914 File Offset: 0x00001B14
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is Thickness))
			{
				return default(Thickness);
			}
			if (parameter is ThicknessSideType)
			{
				this.IgnoreThicknessSide = (ThicknessSideType)parameter;
			}
			Thickness thickness = (Thickness)value;
			switch (this.IgnoreThicknessSide)
			{
			case ThicknessSideType.Left:
				return new Thickness(0.0, thickness.Top, thickness.Right, thickness.Bottom);
			case ThicknessSideType.Top:
				return new Thickness(thickness.Left, 0.0, thickness.Right, thickness.Bottom);
			case ThicknessSideType.Right:
				return new Thickness(thickness.Left, thickness.Top, 0.0, thickness.Bottom);
			case ThicknessSideType.Bottom:
				return new Thickness(thickness.Left, thickness.Top, thickness.Right, 0.0);
			default:
				return thickness;
			}
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00003A24 File Offset: 0x00001C24
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}
	}
}
