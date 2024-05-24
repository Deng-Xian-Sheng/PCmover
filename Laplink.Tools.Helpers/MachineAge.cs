using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32;

namespace Laplink.Tools.Helpers
{
	// Token: 0x0200000A RID: 10
	public class MachineAge
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000057 RID: 87 RVA: 0x000031C0 File Offset: 0x000013C0
		// (set) Token: 0x06000058 RID: 88 RVA: 0x000031C8 File Offset: 0x000013C8
		public Version WindowsVersion { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000059 RID: 89 RVA: 0x000031D1 File Offset: 0x000013D1
		// (set) Token: 0x0600005A RID: 90 RVA: 0x000031D9 File Offset: 0x000013D9
		public DateTime Age { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600005B RID: 91 RVA: 0x000031E2 File Offset: 0x000013E2
		// (set) Token: 0x0600005C RID: 92 RVA: 0x000031EA File Offset: 0x000013EA
		public bool IsXpVersionOfService { get; set; }

		// Token: 0x0600005D RID: 93 RVA: 0x000031F3 File Offset: 0x000013F3
		public int CompareWindowsVersion(Version otherVer)
		{
			return MachineAge.CompareWindowsVersion(this.WindowsVersion, otherVer);
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00003204 File Offset: 0x00001404
		public static int CompareWindowsVersion(Version thisVer, Version otherVer)
		{
			if (thisVer.Major > otherVer.Major)
			{
				return 1;
			}
			if (thisVer.Major < otherVer.Major)
			{
				return -1;
			}
			if (thisVer.Minor > otherVer.Minor)
			{
				return 1;
			}
			if (thisVer.Minor < otherVer.Minor)
			{
				return -1;
			}
			if (thisVer.Major != 10)
			{
				return 0;
			}
			if (thisVer.Minor != 0)
			{
				return 0;
			}
			if (thisVer.Build > otherVer.Build)
			{
				return 1;
			}
			if (thisVer.Build < otherVer.Build)
			{
				return -1;
			}
			return 0;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00003288 File Offset: 0x00001488
		public bool IsOlderThan(MachineAge other)
		{
			bool result;
			if (this.IsXpVersionOfService)
			{
				result = true;
			}
			else
			{
				int num = this.CompareWindowsVersion(other.WindowsVersion);
				result = (num <= 0 && (num < 0 || this.Age < other.Age));
			}
			return result;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000032D1 File Offset: 0x000014D1
		public void DetermineAge()
		{
			this.Age = MachineAge.GetMyCreationTime();
		}

		// Token: 0x06000061 RID: 97 RVA: 0x000032E0 File Offset: 0x000014E0
		public static DateTime GetMyCreationTime()
		{
			DateTime dateTime = DateTime.UtcNow;
			try
			{
				foreach (DirectoryInfo directoryInfo in new DirectoryInfo((string)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\ProfileList", "ProfilesDirectory", "C:\\")).EnumerateDirectories())
				{
					if (!MachineAge.ignoreSet.Contains(directoryInfo.Name) && directoryInfo.CreationTimeUtc < dateTime)
					{
						dateTime = directoryInfo.CreationTimeUtc;
					}
				}
			}
			catch (UnauthorizedAccessException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (PathTooLongException ex2)
			{
				Console.WriteLine(ex2.Message);
			}
			return dateTime;
		}

		// Token: 0x04000018 RID: 24
		private static readonly string[] ignoreNames = new string[]
		{
			"All Users",
			"Default",
			"Default User",
			"Default.migrated",
			"DefaultAppPool",
			"Public"
		};

		// Token: 0x04000019 RID: 25
		private static readonly HashSet<string> ignoreSet = new HashSet<string>(MachineAge.ignoreNames);
	}
}
