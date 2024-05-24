using System;

namespace MS.WindowsAPICodePack.Internal
{
	// Token: 0x02000012 RID: 18
	internal static class CoreErrorHelper
	{
		// Token: 0x06000048 RID: 72 RVA: 0x000028DC File Offset: 0x00000ADC
		public static int HResultFromWin32(int win32ErrorCode)
		{
			if (win32ErrorCode > 0)
			{
				win32ErrorCode = ((win32ErrorCode & 65535) | 458752 | int.MinValue);
			}
			return win32ErrorCode;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00002914 File Offset: 0x00000B14
		public static bool Succeeded(int result)
		{
			return result >= 0;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002930 File Offset: 0x00000B30
		public static bool Succeeded(HResult result)
		{
			return CoreErrorHelper.Succeeded((int)result);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002948 File Offset: 0x00000B48
		public static bool Failed(HResult result)
		{
			return !CoreErrorHelper.Succeeded(result);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002964 File Offset: 0x00000B64
		public static bool Failed(int result)
		{
			return !CoreErrorHelper.Succeeded(result);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002980 File Offset: 0x00000B80
		public static bool Matches(int result, int win32ErrorCode)
		{
			return result == CoreErrorHelper.HResultFromWin32(win32ErrorCode);
		}

		// Token: 0x040000F6 RID: 246
		private const int FacilityWin32 = 7;

		// Token: 0x040000F7 RID: 247
		public const int Ignored = 0;
	}
}
