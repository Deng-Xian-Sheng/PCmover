using System;
using System.Security.Cryptography.X509Certificates;

namespace CefSharp
{
	// Token: 0x0200007D RID: 125
	public interface ISslInfo
	{
		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000340 RID: 832
		CertStatus CertStatus { get; }

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06000341 RID: 833
		X509Certificate2 X509Certificate { get; }
	}
}
