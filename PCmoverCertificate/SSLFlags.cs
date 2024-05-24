using System;

namespace PCmoverCertificate
{
	// Token: 0x02000003 RID: 3
	[Flags]
	internal enum SSLFlags
	{
		// Token: 0x04000004 RID: 4
		None = 0,
		// Token: 0x04000005 RID: 5
		DisallowLaplinkCA = 1,
		// Token: 0x04000006 RID: 6
		DisallowSelfSigned = 2,
		// Token: 0x04000007 RID: 7
		EnforceCertificateName = 4,
		// Token: 0x04000008 RID: 8
		EnforceTimeValidity = 8,
		// Token: 0x04000009 RID: 9
		RequireCustomerCA = 16,
		// Token: 0x0400000A RID: 10
		RequireClientCertificate = 32,
		// Token: 0x0400000B RID: 11
		NetBIOSCertificateName = 64,
		// Token: 0x0400000C RID: 12
		SecureCableConnections = 128
	}
}
