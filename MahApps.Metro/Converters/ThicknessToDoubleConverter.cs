using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MahApps.Metro.Converters
{
	// Token: 0x0200001D RID: 29
	[ValueConversion(typeof(Thickness), typeof(double), ParameterType = typeof(ThicknessSideType))]
	public class ThicknessToDoubleConverter : IValueConverter
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060000A5 RID: 165 RVA: 0x00003A33 File Offset: 0x00001C33
		// (set) Token: 0x060000A6 RID: 166 RVA: 0x00003A3B File Offset: 0x00001C3B
		public ThicknessSideType TakeThicknessSide { get; set; }

		// Token: 0x060000A7 RID: 167 RVA: 0x00003A44 File Offset: 0x00001C44
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is Thickness))
			{
				return 0.0;
			}
			if (parameter is ThicknessSideType)
			{
				this.TakeThicknessSide = (ThicknessSideType)parameter;
			}
			Thickness thickness = (Thickness)value;
			switch (this.TakeThicknessSide)
			{
			case ThicknessSideType.Left:
				return thickness.Left;
			case ThicknessSideType.Top:
				return thickness.Top;
			case ThicknessSideType.Right:
				return thickness.Right;
			case ThicknessSideType.Bottom:
				return thickness.Bottom;
			default:
				return 0.0;
			}
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00003AE6 File Offset: 0x00001CE6
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}
	}
}
