using System;
using System.Globalization;
using Microsoft.WindowsAPICodePack.Resources;

namespace Microsoft.WindowsAPICodePack.ApplicationServices
{
	// Token: 0x02000008 RID: 8
	public class RestartSettings
	{
		// Token: 0x0600001A RID: 26 RVA: 0x0000236A File Offset: 0x0000056A
		public RestartSettings(string command, RestartRestrictions restrictions)
		{
			this.command = command;
			this.restrictions = restrictions;
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600001B RID: 27 RVA: 0x00002384 File Offset: 0x00000584
		public string Command
		{
			get
			{
				return this.command;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600001C RID: 28 RVA: 0x0000239C File Offset: 0x0000059C
		public RestartRestrictions Restrictions
		{
			get
			{
				return this.restrictions;
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000023B4 File Offset: 0x000005B4
		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, LocalizedMessages.RestartSettingsFormatString, new object[]
			{
				this.command,
				this.restrictions.ToString()
			});
		}

		// Token: 0x0400000B RID: 11
		private string command;

		// Token: 0x0400000C RID: 12
		private RestartRestrictions restrictions;
	}
}
