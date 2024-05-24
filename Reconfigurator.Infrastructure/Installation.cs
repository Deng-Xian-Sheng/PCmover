using System;
using Microsoft.Win32;

namespace Reconfigurator.Infrastructure
{
	// Token: 0x02000007 RID: 7
	public class Installation
	{
		// Token: 0x06000013 RID: 19 RVA: 0x000020F8 File Offset: 0x000002F8
		public static string GetInstallLocation(ref string versionString, ref ProductTypes productType, ref string lang)
		{
			string text = Installation.CheckInstallLocation(Registry.CurrentUser, "SOFTWARE\\Laplink\\PCmover\\Install", ref versionString, ref productType, ref lang);
			if (text.Length == 0)
			{
				text = Installation.CheckInstallLocation(Registry.LocalMachine, "SOFTWARE\\Laplink\\PCmover\\Install", ref versionString, ref productType, ref lang);
			}
			if (text.Length == 0)
			{
				text = Installation.CheckInstallLocation(Registry.LocalMachine, "SOFTWARE\\Wow6432Node\\Laplink\\PCmover\\Install", ref versionString, ref productType, ref lang);
			}
			return text;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002150 File Offset: 0x00000350
		private static string CheckInstallLocation(RegistryKey HKey, string RegKey, ref string versionString, ref ProductTypes productType, ref string lang)
		{
			try
			{
				RegistryKey registryKey = HKey.OpenSubKey(RegKey, false);
				if (registryKey != null)
				{
					string text = string.Empty;
					string text2 = string.Empty;
					productType = ProductTypes.eExpress;
					object value = registryKey.GetValue("InstallDirectory");
					text = ((value != null) ? value.ToString() : null);
					object value2 = registryKey.GetValue("Executable");
					text2 = ((value2 != null) ? value2.ToString() : null);
					if (text != null && text2 != null)
					{
						object value3 = registryKey.GetValue("Version");
						versionString = ((value3 != null) ? value3.ToString() : null);
						object value4 = registryKey.GetValue("Language");
						lang = ((value4 != null) ? value4.ToString() : null);
						object value5 = registryKey.GetValue("EditionID");
						string text3 = (value5 != null) ? value5.ToString() : null;
						object value6 = registryKey.GetValue("Title");
						string text4 = (value6 != null) ? value6.ToString() : null;
						if (text3 != null)
						{
							if (text3 == "0")
							{
								productType = ProductTypes.ePro;
							}
							else if (text3 == "1")
							{
								productType = ProductTypes.eEnterprise;
							}
							else if (text3 == "2")
							{
								productType = ProductTypes.eHome;
							}
							else if (text3 == "3")
							{
								productType = ProductTypes.eExpress;
							}
							else if (text3 == "4")
							{
								productType = ProductTypes.eOEMPro;
							}
							else if (text3 == "5")
							{
								productType = ProductTypes.eOEMExpress;
							}
							else if (text3 == "6")
							{
								productType = ProductTypes.eBusiness;
							}
							else if (text3 == "7")
							{
								productType = ProductTypes.eNotebook;
							}
							else if (text3 == "8")
							{
								productType = ProductTypes.eUpgradeAssistant;
							}
						}
						else if (text4 != null)
						{
							if (text4.Contains("Express"))
							{
								productType = ProductTypes.eExpress;
							}
							else if (text4.Contains("Professional"))
							{
								productType = ProductTypes.ePro;
							}
							else if (text4.Contains("Home"))
							{
								productType = ProductTypes.eHome;
							}
							else if (text4.Contains("Enterprise"))
							{
								productType = ProductTypes.eEnterprise;
							}
							else if (text4.Contains("Business"))
							{
								productType = ProductTypes.eBusiness;
							}
						}
						return text + text2;
					}
				}
			}
			finally
			{
				if (HKey != null)
				{
					((IDisposable)HKey).Dispose();
				}
			}
			return string.Empty;
		}
	}
}
