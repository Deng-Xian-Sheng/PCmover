using System;
using System.Globalization;
using Microsoft.WindowsAPICodePack.Resources;

namespace Microsoft.WindowsAPICodePack.ApplicationServices
{
	// Token: 0x02000006 RID: 6
	public class RecoverySettings
	{
		// Token: 0x06000016 RID: 22 RVA: 0x000022BF File Offset: 0x000004BF
		public RecoverySettings(RecoveryData data, uint interval)
		{
			this.recoveryData = data;
			this.pingInterval = interval;
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000017 RID: 23 RVA: 0x000022D8 File Offset: 0x000004D8
		public RecoveryData RecoveryData
		{
			get
			{
				return this.recoveryData;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000018 RID: 24 RVA: 0x000022F0 File Offset: 0x000004F0
		public uint PingInterval
		{
			get
			{
				return this.pingInterval;
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002308 File Offset: 0x00000508
		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, LocalizedMessages.RecoverySettingsFormatString, new object[]
			{
				this.recoveryData.Callback.Method.ToString(),
				this.recoveryData.State.ToString(),
				this.PingInterval
			});
		}

		// Token: 0x04000003 RID: 3
		private RecoveryData recoveryData;

		// Token: 0x04000004 RID: 4
		private uint pingInterval;
	}
}
