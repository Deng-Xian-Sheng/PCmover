using System;
using System.Configuration;

namespace Laplink.Tools.Helpers
{
	// Token: 0x02000004 RID: 4
	public class ConfigHelper
	{
		// Token: 0x06000007 RID: 7 RVA: 0x0000217B File Offset: 0x0000037B
		public static string GetSetting(string name)
		{
			return ConfigurationManager.AppSettings[name];
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002188 File Offset: 0x00000388
		public static string GetStringSetting(string name, string defaultValue = "")
		{
			return ConfigHelper.GetSetting(name) ?? defaultValue;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002198 File Offset: 0x00000398
		public static bool GetBoolSetting(string name, bool defaultValue = false)
		{
			bool result;
			if (bool.TryParse(ConfigHelper.GetSetting(name), out result))
			{
				return result;
			}
			return defaultValue;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000021B8 File Offset: 0x000003B8
		public static int GetIntSetting(string name, int defaultValue = 0)
		{
			int result;
			if (int.TryParse(ConfigHelper.GetSetting(name), out result))
			{
				return result;
			}
			return defaultValue;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000021D8 File Offset: 0x000003D8
		public static long GetLongSetting(string name, long defaultValue = 0L)
		{
			long result;
			if (long.TryParse(ConfigHelper.GetSetting(name), out result))
			{
				return result;
			}
			return defaultValue;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000021F8 File Offset: 0x000003F8
		public static TimeSpan GetTimeSpanSetting(string name, TimeSpan defaultValue)
		{
			TimeSpan result;
			if (TimeSpan.TryParse(ConfigHelper.GetSetting(name), out result))
			{
				return result;
			}
			return defaultValue;
		}
	}
}
