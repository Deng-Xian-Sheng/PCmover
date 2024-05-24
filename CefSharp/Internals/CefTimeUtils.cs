using System;

namespace CefSharp.Internals
{
	// Token: 0x020000C4 RID: 196
	public static class CefTimeUtils
	{
		// Token: 0x060005DF RID: 1503 RVA: 0x00009718 File Offset: 0x00007918
		public static DateTime ConvertCefTimeToDateTime(double epoch)
		{
			if (epoch == 0.0)
			{
				return DateTime.MinValue;
			}
			return new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(epoch).ToLocalTime();
		}
	}
}
