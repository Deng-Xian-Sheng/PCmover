using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CertificateServer
{
	// Token: 0x0200000A RID: 10
	[CompilerGenerated]
	[TypeIdentifier("741EAF91-9A34-44EA-9B89-729C75272195", "CertificateServer.SSL_FLAGS")]
	public enum SSL_FLAGS
	{
		// Token: 0x0400000E RID: 14
		DefaultSSLFlags,
		// Token: 0x0400000F RID: 15
		DisallowLaplinkCA,
		// Token: 0x04000010 RID: 16
		DisallowSelfSigned,
		// Token: 0x04000011 RID: 17
		EnforceCertificateName = 4,
		// Token: 0x04000012 RID: 18
		EnforceTimeValidity = 8,
		// Token: 0x04000013 RID: 19
		RequireCustomerCA = 16,
		// Token: 0x04000014 RID: 20
		RequireClientCertificate = 32,
		// Token: 0x04000015 RID: 21
		NetBIOSCertificateName = 64,
		// Token: 0x04000016 RID: 22
		SecureCableConnections = 128
	}
}
