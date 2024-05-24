using System;

namespace RestSharp.Authenticators.OAuth.Extensions
{
	// Token: 0x02000067 RID: 103
	internal static class TimeExtensions
	{
		// Token: 0x0600059B RID: 1435 RVA: 0x0000DC4C File Offset: 0x0000BE4C
		public static long ToUnixTime(this DateTime dateTime)
		{
			return (long)(dateTime - new DateTime(1970, 1, 1)).TotalSeconds;
		}
	}
}
