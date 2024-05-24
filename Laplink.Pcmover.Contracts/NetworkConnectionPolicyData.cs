using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000019 RID: 25
	public class NetworkConnectionPolicyData
	{
		// Token: 0x0600008C RID: 140 RVA: 0x0000292A File Offset: 0x00000B2A
		public NetworkConnectionPolicyData()
		{
			this.SslFlags = SSLFlags.EnforceTimeValidity;
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x0600008D RID: 141 RVA: 0x00002939 File Offset: 0x00000B39
		// (set) Token: 0x0600008E RID: 142 RVA: 0x00002941 File Offset: 0x00000B41
		public SSLFlags SslFlags { get; set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x0600008F RID: 143 RVA: 0x0000294A File Offset: 0x00000B4A
		// (set) Token: 0x06000090 RID: 144 RVA: 0x00002952 File Offset: 0x00000B52
		public string Target { get; set; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000091 RID: 145 RVA: 0x0000295B File Offset: 0x00000B5B
		// (set) Token: 0x06000092 RID: 146 RVA: 0x00002963 File Offset: 0x00000B63
		public bool? IsMachineOld { get; set; }
	}
}
