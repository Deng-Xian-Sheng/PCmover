using System;
using System.Globalization;
using System.Resources;
using System.Windows.Data;
using WizardModule.Properties;

namespace WizardModule.Views
{
	// Token: 0x0200001A RID: 26
	public sealed class EnumToStringConverter : IValueConverter
	{
		// Token: 0x060003EC RID: 1004 RVA: 0x00008993 File Offset: 0x00006B93
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return null;
			}
			return Resources.ResourceManager.GetString("ENUM_" + value.ToString());
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x000089B4 File Offset: 0x00006BB4
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string a = (string)value;
			ResourceManager resourceManager = Resources.ResourceManager;
			foreach (object obj in Enum.GetValues(targetType))
			{
				string name = "ENUM_" + obj.ToString();
				if (a == resourceManager.GetString(name))
				{
					return obj;
				}
			}
			throw new ArgumentException(null, "value");
		}
	}
}
