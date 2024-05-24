using System;
using System.Globalization;
using System.Threading;
using System.Windows.Data;
using Laplink.Pcmover.Contracts;
using WizardModule.Properties;

namespace WizardModule.Views
{
	// Token: 0x0200001F RID: 31
	public class AppTooltipConverter : IValueConverter
	{
		// Token: 0x060003FB RID: 1019 RVA: 0x00008BC8 File Offset: 0x00006DC8
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			ApplicationData applicationData = (ApplicationData)value;
			string text = Resources.SAdv_Name + " " + applicationData.Name;
			if (!string.IsNullOrWhiteSpace(applicationData.Publisher))
			{
				text = string.Concat(new string[]
				{
					text,
					Environment.NewLine,
					Resources.SAdv_Publisher,
					" ",
					applicationData.Publisher
				});
			}
			try
			{
				string @string = Resources.ResourceManager.GetString("APP_" + applicationData.Reason.ToString());
				if (!string.IsNullOrEmpty(@string))
				{
					text = string.Concat(new string[]
					{
						text,
						Environment.NewLine,
						Resources.SAdv_Message,
						" ",
						@string
					});
				}
				else if (!string.IsNullOrEmpty(applicationData.Message) && Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName.ToLower() == "en")
				{
					text = string.Concat(new string[]
					{
						text,
						Environment.NewLine,
						Resources.SAdv_Message,
						" ",
						applicationData.Message
					});
				}
			}
			catch
			{
			}
			return text;
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x00008A8C File Offset: 0x00006C8C
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return string.Empty;
		}
	}
}
