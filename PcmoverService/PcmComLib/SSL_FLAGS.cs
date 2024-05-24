using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x020000C7 RID: 199
	[CompilerGenerated]
	[TypeIdentifier("014D1DE2-7A0B-457C-8B9C-A20AD2BF0977", "PcmComLib.SSL_FLAGS")]
	public enum SSL_FLAGS
	{
		// Token: 0x0400018B RID: 395
		DefaultSSLFlags,
		// Token: 0x0400018C RID: 396
		DisallowLaplinkCA,
		// Token: 0x0400018D RID: 397
		DisallowSelfSigned,
		// Token: 0x0400018E RID: 398
		EnforceCertificateName = 4,
		// Token: 0x0400018F RID: 399
		EnforceTimeValidity = 8,
		// Token: 0x04000190 RID: 400
		RequireCustomerCA = 16,
		// Token: 0x04000191 RID: 401
		RequireClientCertificate = 32,
		// Token: 0x04000192 RID: 402
		NetBIOSCertificateName = 64,
		// Token: 0x04000193 RID: 403
		SecureCableConnections = 128
	}
}
