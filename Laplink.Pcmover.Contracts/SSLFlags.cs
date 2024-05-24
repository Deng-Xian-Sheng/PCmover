using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000018 RID: 24
	[Flags]
	public enum SSLFlags
	{
		// Token: 0x0400009B RID: 155
		DisallowLaplinkCA = 1,
		// Token: 0x0400009C RID: 156
		DisallowSelfSigned = 2,
		// Token: 0x0400009D RID: 157
		EnforceCertificateName = 4,
		// Token: 0x0400009E RID: 158
		EnforceTimeValidity = 8,
		// Token: 0x0400009F RID: 159
		RequireCustomerCA = 16,
		// Token: 0x040000A0 RID: 160
		RequireClientCertificate = 32,
		// Token: 0x040000A1 RID: 161
		NetBIOSCertificateName = 64,
		// Token: 0x040000A2 RID: 162
		SecureCableConnections = 128
	}
}
