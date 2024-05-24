using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x020000C8 RID: 200
	[CompilerGenerated]
	[TypeIdentifier("014D1DE2-7A0B-457C-8B9C-A20AD2BF0977", "PcmComLib.SSL_STATE")]
	public enum SSL_STATE
	{
		// Token: 0x04000195 RID: 405
		NoConnection,
		// Token: 0x04000196 RID: 406
		SSLInvalid,
		// Token: 0x04000197 RID: 407
		ConnectedTrusted,
		// Token: 0x04000198 RID: 408
		ConnectedUntrusted,
		// Token: 0x04000199 RID: 409
		CertificateNotYetValid,
		// Token: 0x0400019A RID: 410
		CertificateExpired,
		// Token: 0x0400019B RID: 411
		CertificateNameInvalid,
		// Token: 0x0400019C RID: 412
		CertificateInvalid,
		// Token: 0x0400019D RID: 413
		CertificateRequired,
		// Token: 0x0400019E RID: 414
		CertificateUntrusted,
		// Token: 0x0400019F RID: 415
		TimeSkew
	}
}
