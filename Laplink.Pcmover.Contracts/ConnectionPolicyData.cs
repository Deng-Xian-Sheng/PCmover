using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200001A RID: 26
	public class ConnectionPolicyData
	{
		// Token: 0x06000093 RID: 147 RVA: 0x0000296C File Offset: 0x00000B6C
		public ConnectionPolicyData()
		{
			this.EnabledMethods = ConnectionPolicyMethods.All;
			this.File = new FileConnectionPolicyData();
			this.Network = new NetworkConnectionPolicyData();
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000094 RID: 148 RVA: 0x00002992 File Offset: 0x00000B92
		// (set) Token: 0x06000095 RID: 149 RVA: 0x0000299A File Offset: 0x00000B9A
		public ConnectionPolicyMethods EnabledMethods { get; set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000096 RID: 150 RVA: 0x000029A3 File Offset: 0x00000BA3
		// (set) Token: 0x06000097 RID: 151 RVA: 0x000029AB File Offset: 0x00000BAB
		public FileConnectionPolicyData File { get; set; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000098 RID: 152 RVA: 0x000029B4 File Offset: 0x00000BB4
		// (set) Token: 0x06000099 RID: 153 RVA: 0x000029BC File Offset: 0x00000BBC
		public NetworkConnectionPolicyData Network { get; set; }
	}
}
