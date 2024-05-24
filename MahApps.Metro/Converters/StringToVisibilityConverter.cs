using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace MahApps.Metro.Converters
{
	// Token: 0x0200001A RID: 26
	[ValueConversion(typeof(string), typeof(Visibility))]
	[MarkupExtensionReturnType(typeof(StringToVisibilityConverter))]
	public class StringToVisibilityConverter : MarkupExtension, IValueConverter
	{
		// Token: 0x06000098 RID: 152 RVA: 0x00003803 File Offset: 0x00001A03
		public StringToVisibilityConverter()
		{
			this.FalseEquivalent = Visibility.Collapsed;
			this.OppositeStringValue = false;
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000099 RID: 153 RVA: 0x00003819 File Offset: 0x00001A19
		// (set) Token: 0x0600009A RID: 154 RVA: 0x00003821 File Offset: 0x00001A21
		public Visibility FalseEquivalent { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600009B RID: 155 RVA: 0x0000382A File Offset: 0x00001A2A
		// (set) Token: 0x0600009C RID: 156 RVA: 0x00003832 File Offset: 0x00001A32
		public bool OppositeStringValue { get; set; }

		// Token: 0x0600009D RID: 157 RVA: 0x0000383B File Offset: 0x00001A3B
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return new StringToVisibilityConverter
			{
				FalseEquivalent = this.FalseEquivalent,
				OppositeStringValue = this.OppositeStringValue
			};
		}

		// Token: 0x0600009E RID: 158 RVA: 0x0000385C File Offset: 0x00001A5C
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if ((value != null && !(value is string)) || !(targetType == typeof(Visibility)))
			{
				return value;
			}
			if (this.OppositeStringValue)
			{
				return string.IsNullOrEmpty((string)value) ? Visibility.Visible : this.FalseEquivalent;
			}
			return string.IsNullOrEmpty((string)value) ? this.FalseEquivalent : Visibility.Visible;
		}

		// Token: 0x0600009F RID: 159 RVA: 0x000038C7 File Offset: 0x00001AC7
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is Visibility))
			{
				return value;
			}
			if (this.OppositeStringValue)
			{
				if ((Visibility)value != Visibility.Visible)
				{
					return "visible";
				}
				return string.Empty;
			}
			else
			{
				if ((Visibility)value != Visibility.Visible)
				{
					return string.Empty;
				}
				return "visible";
			}
		}
	}
}
