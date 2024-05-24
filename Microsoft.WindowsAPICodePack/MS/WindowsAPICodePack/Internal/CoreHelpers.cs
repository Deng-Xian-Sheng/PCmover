using System;
using System.Globalization;
using System.Text;
using Microsoft.WindowsAPICodePack.Resources;

namespace MS.WindowsAPICodePack.Internal
{
	// Token: 0x02000013 RID: 19
	public static class CoreHelpers
	{
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600004E RID: 78 RVA: 0x0000299C File Offset: 0x00000B9C
		public static bool RunningOnXP
		{
			get
			{
				return Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 5;
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000029D4 File Offset: 0x00000BD4
		public static void ThrowIfNotXP()
		{
			if (!CoreHelpers.RunningOnXP)
			{
				throw new PlatformNotSupportedException(LocalizedMessages.CoreHelpersRunningOnXp);
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000050 RID: 80 RVA: 0x000029F8 File Offset: 0x00000BF8
		public static bool RunningOnVista
		{
			get
			{
				return Environment.OSVersion.Version.Major >= 6;
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00002A20 File Offset: 0x00000C20
		public static void ThrowIfNotVista()
		{
			if (!CoreHelpers.RunningOnVista)
			{
				throw new PlatformNotSupportedException(LocalizedMessages.CoreHelpersRunningOnVista);
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000052 RID: 82 RVA: 0x00002A44 File Offset: 0x00000C44
		public static bool RunningOnWin7
		{
			get
			{
				return Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.CompareTo(new Version(6, 1)) >= 0;
			}
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002A84 File Offset: 0x00000C84
		public static void ThrowIfNotWin7()
		{
			if (!CoreHelpers.RunningOnWin7)
			{
				throw new PlatformNotSupportedException(LocalizedMessages.CoreHelpersRunningOn7);
			}
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002AA8 File Offset: 0x00000CA8
		public static string GetStringResource(string resourceId)
		{
			string result;
			if (string.IsNullOrEmpty(resourceId))
			{
				result = string.Empty;
			}
			else
			{
				resourceId = resourceId.Replace("shell32,dll", "shell32.dll");
				string[] array = resourceId.Split(new char[]
				{
					','
				});
				string text = array[0];
				text = text.Replace("@", string.Empty);
				text = Environment.ExpandEnvironmentVariables(text);
				IntPtr instanceHandle = CoreNativeMethods.LoadLibrary(text);
				array[1] = array[1].Replace("-", string.Empty);
				int id = int.Parse(array[1], CultureInfo.InvariantCulture);
				StringBuilder stringBuilder = new StringBuilder(255);
				result = ((CoreNativeMethods.LoadString(instanceHandle, id, stringBuilder, 255) != 0) ? stringBuilder.ToString() : null);
			}
			return result;
		}
	}
}
