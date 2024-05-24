using System;
using System.Collections.Generic;
using Laplink.Tools.Helpers;
using Microsoft.Win32;

namespace MainUI
{
	// Token: 0x02000006 RID: 6
	public class RegSettings
	{
		// Token: 0x06000047 RID: 71 RVA: 0x0000286D File Offset: 0x00000A6D
		public RegSettings(LlTraceSource ts)
		{
			this.ts = ts;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x0000287C File Offset: 0x00000A7C
		public string GetRegString(string keyValue)
		{
			string result = string.Empty;
			using (RegistryKey currentUser = Registry.CurrentUser)
			{
				RegistryKey registryKey = currentUser.OpenSubKey("Software\\Wow6432Node\\Laplink\\Reconfigurator", false);
				if (registryKey == null)
				{
					registryKey = currentUser.OpenSubKey("Software\\Laplink\\Reconfigurator", false);
				}
				if (registryKey != null)
				{
					object value = registryKey.GetValue(keyValue);
					result = ((value != null) ? value.ToString() : null);
					registryKey.Close();
				}
			}
			return result;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x000028EC File Offset: 0x00000AEC
		public void SetRegString(string keyValue, string value)
		{
			try
			{
				using (RegistryKey currentUser = Registry.CurrentUser)
				{
					RegistryKey registryKey = currentUser.CreateSubKey("Software\\Wow6432Node\\Laplink\\Reconfigurator");
					if (registryKey == null)
					{
						registryKey = currentUser.CreateSubKey("Software\\Laplink\\Reconfigurator");
					}
					if (registryKey != null)
					{
						registryKey.SetValue(keyValue, value);
						registryKey.Close();
					}
				}
			}
			catch (Exception ex)
			{
				LlTraceSource llTraceSource = this.ts;
				if (llTraceSource != null)
				{
					llTraceSource.TraceVerbose(string.Concat(new string[]
					{
						"Error saving registry - Key:",
						keyValue,
						"  Value:",
						value,
						"   Error: ",
						ex.Message
					}));
				}
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000029A0 File Offset: 0x00000BA0
		public List<string> GetRegArray(string keyValue)
		{
			using (RegistryKey currentUser = Registry.CurrentUser)
			{
				RegistryKey registryKey = currentUser.OpenSubKey("Software\\Wow6432Node\\Laplink\\Reconfigurator", false);
				if (registryKey == null)
				{
					registryKey = currentUser.OpenSubKey("Software\\Laplink\\Reconfigurator", false);
				}
				if (registryKey != null)
				{
					object value = registryKey.GetValue(keyValue);
					if (value != null)
					{
						return new List<string>(value as string[]);
					}
				}
			}
			return new List<string>();
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002A10 File Offset: 0x00000C10
		public void SetRegArray(string keyValue, List<string> list)
		{
			using (RegistryKey currentUser = Registry.CurrentUser)
			{
				RegistryKey registryKey = currentUser.CreateSubKey("Software\\Wow6432Node\\Laplink\\Reconfigurator");
				if (registryKey == null)
				{
					registryKey = currentUser.CreateSubKey("Software\\Laplink\\Reconfigurator");
				}
				if (registryKey != null)
				{
					registryKey.SetValue(keyValue, list.ToArray());
				}
			}
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002A6C File Offset: 0x00000C6C
		public List<string> AddRegArray(string keyValue, string value)
		{
			using (RegistryKey currentUser = Registry.CurrentUser)
			{
				RegistryKey registryKey = currentUser.OpenSubKey("Software\\Wow6432Node\\Laplink\\Reconfigurator", false);
				if (registryKey == null)
				{
					registryKey = currentUser.OpenSubKey("Software\\Laplink\\Reconfigurator", false);
				}
				if (registryKey != null)
				{
					List<string> list = new List<string>(registryKey.GetValue(keyValue) as string[]);
					list.Add(value);
					registryKey.SetValue(keyValue, list.ToArray());
					return list;
				}
			}
			return new List<string>();
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600004D RID: 77 RVA: 0x00002AEC File Offset: 0x00000CEC
		// (set) Token: 0x0600004E RID: 78 RVA: 0x00002AF9 File Offset: 0x00000CF9
		public string Source
		{
			get
			{
				return this.GetRegString("Source");
			}
			set
			{
				this.SetRegString("Source", value);
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00002B07 File Offset: 0x00000D07
		// (set) Token: 0x06000050 RID: 80 RVA: 0x00002B14 File Offset: 0x00000D14
		public string Destination
		{
			get
			{
				return this.GetRegString("Destination");
			}
			set
			{
				this.SetRegString("Destination", value);
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00002B22 File Offset: 0x00000D22
		// (set) Token: 0x06000052 RID: 82 RVA: 0x00002B2F File Offset: 0x00000D2F
		public string SourceDrive
		{
			get
			{
				return this.GetRegString("SourceDrive");
			}
			set
			{
				this.SetRegString("SourceDrive", value);
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000053 RID: 83 RVA: 0x00002B3D File Offset: 0x00000D3D
		// (set) Token: 0x06000054 RID: 84 RVA: 0x00002B4A File Offset: 0x00000D4A
		public string DestinationDrive
		{
			get
			{
				return this.GetRegString("DestinationDrive");
			}
			set
			{
				this.SetRegString("DestinationDrive", value);
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000055 RID: 85 RVA: 0x00002B58 File Offset: 0x00000D58
		// (set) Token: 0x06000056 RID: 86 RVA: 0x00002B65 File Offset: 0x00000D65
		public string FirstName
		{
			get
			{
				return this.GetRegString("FirstName");
			}
			set
			{
				this.SetRegString("DestinationDrive", value);
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00002B73 File Offset: 0x00000D73
		// (set) Token: 0x06000058 RID: 88 RVA: 0x00002B80 File Offset: 0x00000D80
		public string LastName
		{
			get
			{
				return this.GetRegString("LastName");
			}
			set
			{
				this.SetRegString("LastName", value);
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00002B8E File Offset: 0x00000D8E
		// (set) Token: 0x0600005A RID: 90 RVA: 0x00002B9B File Offset: 0x00000D9B
		public string Email
		{
			get
			{
				return this.GetRegString("Email");
			}
			set
			{
				this.SetRegString("Email", value);
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600005B RID: 91 RVA: 0x00002BA9 File Offset: 0x00000DA9
		// (set) Token: 0x0600005C RID: 92 RVA: 0x00002BB6 File Offset: 0x00000DB6
		public string RegVerificationCode
		{
			get
			{
				return this.GetRegString("RegVerificationCode");
			}
			set
			{
				this.SetRegString("RegVerificationCode", value);
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600005D RID: 93 RVA: 0x00002BC4 File Offset: 0x00000DC4
		// (set) Token: 0x0600005E RID: 94 RVA: 0x00002BD1 File Offset: 0x00000DD1
		public List<string> Folders
		{
			get
			{
				return this.GetRegArray("Folders");
			}
			set
			{
				this.SetRegArray("Folders", value);
			}
		}

		// Token: 0x04000019 RID: 25
		private const string WowKeyString = "Software\\Wow6432Node\\Laplink\\Reconfigurator";

		// Token: 0x0400001A RID: 26
		private const string RegKeyString = "Software\\Laplink\\Reconfigurator";

		// Token: 0x0400001B RID: 27
		private readonly LlTraceSource ts;
	}
}
