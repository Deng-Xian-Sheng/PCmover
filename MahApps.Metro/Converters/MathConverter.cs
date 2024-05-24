using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace MahApps.Metro.Converters
{
	// Token: 0x02000010 RID: 16
	public sealed class MathConverter : IValueConverter, IMultiValueConverter
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600005F RID: 95 RVA: 0x00003297 File Offset: 0x00001497
		// (set) Token: 0x06000060 RID: 96 RVA: 0x0000329F File Offset: 0x0000149F
		public MathOperation Operation { get; set; }

		// Token: 0x06000061 RID: 97 RVA: 0x000032A8 File Offset: 0x000014A8
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return MathConverter.DoConvert(value, parameter, this.Operation);
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000032B7 File Offset: 0x000014B7
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			if (values == null || values.Length < 2)
			{
				return Binding.DoNothing;
			}
			return MathConverter.DoConvert(values[0], values[1], this.Operation);
		}

		// Token: 0x06000063 RID: 99 RVA: 0x000032D9 File Offset: 0x000014D9
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x000032E0 File Offset: 0x000014E0
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			return (from t in targetTypes
			select Binding.DoNothing).ToArray<object>();
		}

		// Token: 0x06000065 RID: 101 RVA: 0x0000330C File Offset: 0x0000150C
		private static object DoConvert(object firstValue, object secondValue, MathOperation operation)
		{
			if (firstValue == null || secondValue == null || firstValue == DependencyProperty.UnsetValue || secondValue == DependencyProperty.UnsetValue || firstValue == DBNull.Value || secondValue == DBNull.Value)
			{
				return Binding.DoNothing;
			}
			object result;
			try
			{
				double valueOrDefault = (firstValue as double?).GetValueOrDefault(System.Convert.ToDouble(firstValue, CultureInfo.InvariantCulture));
				double valueOrDefault2 = (secondValue as double?).GetValueOrDefault(System.Convert.ToDouble(secondValue, CultureInfo.InvariantCulture));
				switch (operation)
				{
				case MathOperation.Add:
					result = valueOrDefault + valueOrDefault2;
					break;
				case MathOperation.Subtract:
					result = valueOrDefault - valueOrDefault2;
					break;
				case MathOperation.Multiply:
					result = valueOrDefault * valueOrDefault2;
					break;
				case MathOperation.Divide:
					result = valueOrDefault / valueOrDefault2;
					break;
				default:
					result = Binding.DoNothing;
					break;
				}
			}
			catch (Exception)
			{
				result = Binding.DoNothing;
			}
			return result;
		}
	}
}
