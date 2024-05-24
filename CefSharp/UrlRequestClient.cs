using System;
using System.IO;

namespace CefSharp
{
	// Token: 0x02000099 RID: 153
	public class UrlRequestClient : IUrlRequestClient
	{
		// Token: 0x06000480 RID: 1152 RVA: 0x00006E67 File Offset: 0x00005067
		bool IUrlRequestClient.GetAuthCredentials(bool isProxy, string host, int port, string realm, string scheme, IAuthCallback callback)
		{
			return this.GetAuthCredentials(isProxy, host, port, realm, scheme, callback);
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x00006E78 File Offset: 0x00005078
		protected virtual bool GetAuthCredentials(bool isProxy, string host, int port, string realm, string scheme, IAuthCallback callback)
		{
			return false;
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x00006E7B File Offset: 0x0000507B
		void IUrlRequestClient.OnDownloadData(IUrlRequest request, Stream data)
		{
			this.OnDownloadData(request, data);
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x00006E85 File Offset: 0x00005085
		protected virtual void OnDownloadData(IUrlRequest request, Stream data)
		{
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x00006E87 File Offset: 0x00005087
		void IUrlRequestClient.OnDownloadProgress(IUrlRequest request, long current, long total)
		{
			this.OnDownloadProgress(request, current, total);
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x00006E92 File Offset: 0x00005092
		protected virtual void OnDownloadProgress(IUrlRequest request, long current, long total)
		{
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x00006E94 File Offset: 0x00005094
		void IUrlRequestClient.OnRequestComplete(IUrlRequest request)
		{
			this.OnRequestComplete(request);
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x00006E9D File Offset: 0x0000509D
		protected virtual void OnRequestComplete(IUrlRequest request)
		{
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x00006E9F File Offset: 0x0000509F
		void IUrlRequestClient.OnUploadProgress(IUrlRequest request, long current, long total)
		{
			this.OnUploadProgress(request, current, total);
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x00006EAA File Offset: 0x000050AA
		protected virtual void OnUploadProgress(IUrlRequest request, long current, long total)
		{
		}
	}
}
