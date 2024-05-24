using System;

namespace CefSharp.Internals
{
	// Token: 0x020000C9 RID: 201
	public static class DateTimeUtils
	{
		// Token: 0x060005F5 RID: 1525 RVA: 0x00009A9C File Offset: 0x00007C9C
		public static DateTime FromCefTime(int year, int month, int day, int hour, int minute, int second, int millisecond)
		{
			DateTime result;
			try
			{
				result = new DateTime(year, month, day, hour, minute, second, millisecond);
			}
			catch (Exception)
			{
				result = DateTime.MinValue;
			}
			return result;
		}

		// Token: 0x060005F6 RID: 1526 RVA: 0x00009AD8 File Offset: 0x00007CD8
		public static double ToCefTime(DateTime dateTime)
		{
			return (dateTime - DateTimeUtils.FirstOfTheFirstNineteenSeventy).TotalSeconds;
		}

		// Token: 0x04000342 RID: 834
		private static DateTime FirstOfTheFirstNineteenSeventy = new DateTime(1970, 1, 1, 0, 0, 0);
	}
}
