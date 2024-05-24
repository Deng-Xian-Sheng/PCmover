using System;
using System.Runtime.CompilerServices;

namespace CefSharp.Internals
{
	// Token: 0x020000E6 RID: 230
	public static class PathCheck
	{
		// Token: 0x060006E7 RID: 1767 RVA: 0x0000B3B0 File Offset: 0x000095B0
		internal static int FindDriveLetter(string path)
		{
			if (path.Length >= 2 && path[1] == ':' && ((path[0] >= 'A' && path[0] <= 'Z') || (path[0] >= 'a' && path[0] <= 'z')))
			{
				return 1;
			}
			return -1;
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x0000B400 File Offset: 0x00009600
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static bool IsDirectorySeparator(char c)
		{
			return c == '\\' || c == '/';
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x0000B40E File Offset: 0x0000960E
		public static void AssertAbsolute(string path, string settingName)
		{
			if (!string.IsNullOrEmpty(path) && PathCheck.EnableAssert && !PathCheck.IsAbsolute(path))
			{
				throw new Exception(settingName + " now requires an absolute path, the path provided is non-absolute. You can use System.IO.Path.GetFullPath to obtain an absolute path. Current value:" + path);
			}
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x0000B43C File Offset: 0x0000963C
		public static bool IsAbsolute(string path)
		{
			int num = PathCheck.FindDriveLetter(path);
			if (num != -1)
			{
				return path.Length > num + 1 && PathCheck.IsDirectorySeparator(path[num + 1]);
			}
			return path.Length > 1 && PathCheck.IsDirectorySeparator(path[0]) && PathCheck.IsDirectorySeparator(path[1]);
		}

		// Token: 0x04000386 RID: 902
		internal const char DirectorySeparatorChar = '\\';

		// Token: 0x04000387 RID: 903
		internal const char AltDirectorySeparatorChar = '/';

		// Token: 0x04000388 RID: 904
		[Obsolete("This will be removed after further testing.")]
		public static bool EnableAssert = true;
	}
}
