using System;
using System.IO;

namespace CefSharp
{
	// Token: 0x0200007F RID: 127
	public interface IUrlRequestClient
	{
		// Token: 0x06000345 RID: 837
		bool GetAuthCredentials(bool isProxy, string host, int port, string realm, string scheme, IAuthCallback callback);

		// Token: 0x06000346 RID: 838
		void OnDownloadData(IUrlRequest request, Stream data);

		// Token: 0x06000347 RID: 839
		void OnDownloadProgress(IUrlRequest request, long current, long total);

		// Token: 0x06000348 RID: 840
		void OnRequestComplete(IUrlRequest request);

		// Token: 0x06000349 RID: 841
		void OnUploadProgress(IUrlRequest request, long current, long total);
	}
}
