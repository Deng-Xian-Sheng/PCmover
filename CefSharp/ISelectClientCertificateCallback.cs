using System;
using System.Security.Cryptography.X509Certificates;

namespace CefSharp
{
	// Token: 0x02000012 RID: 18
	public interface ISelectClientCertificateCallback : IDisposable
	{
		// Token: 0x06000037 RID: 55
		void Select(X509Certificate2 selectedCert);

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000038 RID: 56
		bool IsDisposed { get; }
	}
}
