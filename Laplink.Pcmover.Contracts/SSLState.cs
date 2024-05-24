using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000083 RID: 131
	public enum SSLState
	{
		// Token: 0x04000309 RID: 777
		NoConnection,
		// Token: 0x0400030A RID: 778
		SSLInvalid,
		// Token: 0x0400030B RID: 779
		ConnectedTrusted,
		// Token: 0x0400030C RID: 780
		ConnectedUntrusted,
		// Token: 0x0400030D RID: 781
		CertificateNotYetValid,
		// Token: 0x0400030E RID: 782
		CertificateExpired,
		// Token: 0x0400030F RID: 783
		CertificateNameInvalid,
		// Token: 0x04000310 RID: 784
		CertificateInvalid,
		// Token: 0x04000311 RID: 785
		CertificateRequired,
		// Token: 0x04000312 RID: 786
		CertificateUntrusted,
		// Token: 0x04000313 RID: 787
		TimeSkew
	}
}
