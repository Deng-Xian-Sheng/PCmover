using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002AD RID: 685
	[ComVisible(true)]
	public enum X509ContentType
	{
		// Token: 0x04000D86 RID: 3462
		Unknown,
		// Token: 0x04000D87 RID: 3463
		Cert,
		// Token: 0x04000D88 RID: 3464
		SerializedCert,
		// Token: 0x04000D89 RID: 3465
		Pfx,
		// Token: 0x04000D8A RID: 3466
		Pkcs12 = 3,
		// Token: 0x04000D8B RID: 3467
		SerializedStore,
		// Token: 0x04000D8C RID: 3468
		Pkcs7,
		// Token: 0x04000D8D RID: 3469
		Authenticode
	}
}
