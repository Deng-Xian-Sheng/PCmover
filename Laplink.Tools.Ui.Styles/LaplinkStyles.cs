using System;
using System.Management;
using System.Windows;

namespace Laplink.Tools.Ui.Styles
{
	// Token: 0x02000002 RID: 2
	public static class LaplinkStyles
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static void InitResources()
		{
			Version osversion = LaplinkStyles.GetOSVersion();
			if ((osversion.Major == 10 && osversion.Build >= 21996) || osversion.Major > 10)
			{
				string uriString = "pack://application:,,,/Laplink.Tools.Ui.Styles;component/Win11.xaml";
				ResourceDictionary resourceDictionary = new ResourceDictionary
				{
					Source = new Uri(uriString, UriKind.Absolute)
				};
				foreach (object key in resourceDictionary.Keys)
				{
					Application.Current.Resources[key] = resourceDictionary[key];
				}
			}
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020FC File Offset: 0x000002FC
		private static Version GetOSVersion()
		{
			try
			{
				string text = string.Empty;
				using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT Version FROM Win32_OperatingSystem"))
				{
					using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator())
					{
						if (enumerator.MoveNext())
						{
							text = ((ManagementObject)enumerator.Current)["Version"].ToString();
						}
					}
				}
				if (!string.IsNullOrEmpty(text))
				{
					return new Version(text);
				}
			}
			catch
			{
			}
			return new Version("0.0.0.0");
		}
	}
}
