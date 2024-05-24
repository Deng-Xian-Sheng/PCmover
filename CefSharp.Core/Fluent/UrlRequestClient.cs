using System;
using System.IO;

namespace CefSharp.Fluent
{
	// Token: 0x0200001B RID: 27
	public class UrlRequestClient : UrlRequestClient
	{
		// Token: 0x0600016F RID: 367 RVA: 0x000036A2 File Offset: 0x000018A2
		public static UrlRequestClientBuilder Create()
		{
			return new UrlRequestClientBuilder();
		}

		// Token: 0x06000170 RID: 368 RVA: 0x000036A9 File Offset: 0x000018A9
		internal UrlRequestClient()
		{
		}

		// Token: 0x06000171 RID: 369 RVA: 0x000036B1 File Offset: 0x000018B1
		internal void SetGetAuthCredentials(GetAuthCredentialsDelegate func)
		{
			this.getAuthCredentials = func;
		}

		// Token: 0x06000172 RID: 370 RVA: 0x000036BA File Offset: 0x000018BA
		internal void SetOnDownloadData(OnDownloadDataDelegate action)
		{
			this.onDownloadData = action;
		}

		// Token: 0x06000173 RID: 371 RVA: 0x000036C3 File Offset: 0x000018C3
		internal void SetOnDownloadProgress(OnDownloadProgressDelegate action)
		{
			this.onDownloadProgress = action;
		}

		// Token: 0x06000174 RID: 372 RVA: 0x000036CC File Offset: 0x000018CC
		internal void SetOnRequestComplete(OnRequestCompleteDelegate action)
		{
			this.onRequestComplete = action;
		}

		// Token: 0x06000175 RID: 373 RVA: 0x000036D5 File Offset: 0x000018D5
		internal void SetOnUploadProgress(OnUploadProgressDelegate action)
		{
			this.onUploadProgress = action;
		}

		// Token: 0x06000176 RID: 374 RVA: 0x000036DE File Offset: 0x000018DE
		protected override bool GetAuthCredentials(bool isProxy, string host, int port, string realm, string scheme, IAuthCallback callback)
		{
			GetAuthCredentialsDelegate getAuthCredentialsDelegate = this.getAuthCredentials;
			return getAuthCredentialsDelegate != null && getAuthCredentialsDelegate(isProxy, host, port, realm, scheme, callback);
		}

		// Token: 0x06000177 RID: 375 RVA: 0x000036FA File Offset: 0x000018FA
		protected override void OnDownloadData(IUrlRequest request, Stream data)
		{
			OnDownloadDataDelegate onDownloadDataDelegate = this.onDownloadData;
			if (onDownloadDataDelegate == null)
			{
				return;
			}
			onDownloadDataDelegate(request, data);
		}

		// Token: 0x06000178 RID: 376 RVA: 0x0000370E File Offset: 0x0000190E
		protected override void OnDownloadProgress(IUrlRequest request, long current, long total)
		{
			OnDownloadProgressDelegate onDownloadProgressDelegate = this.onDownloadProgress;
			if (onDownloadProgressDelegate == null)
			{
				return;
			}
			onDownloadProgressDelegate(request, current, total);
		}

		// Token: 0x06000179 RID: 377 RVA: 0x00003723 File Offset: 0x00001923
		protected override void OnRequestComplete(IUrlRequest request)
		{
			OnRequestCompleteDelegate onRequestCompleteDelegate = this.onRequestComplete;
			if (onRequestCompleteDelegate == null)
			{
				return;
			}
			onRequestCompleteDelegate(request);
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00003736 File Offset: 0x00001936
		protected override void OnUploadProgress(IUrlRequest request, long current, long total)
		{
			OnUploadProgressDelegate onUploadProgressDelegate = this.onUploadProgress;
			if (onUploadProgressDelegate == null)
			{
				return;
			}
			onUploadProgressDelegate(request, current, total);
		}

		// Token: 0x04000013 RID: 19
		private GetAuthCredentialsDelegate getAuthCredentials;

		// Token: 0x04000014 RID: 20
		private OnDownloadDataDelegate onDownloadData;

		// Token: 0x04000015 RID: 21
		private OnDownloadProgressDelegate onDownloadProgress;

		// Token: 0x04000016 RID: 22
		private OnRequestCompleteDelegate onRequestComplete;

		// Token: 0x04000017 RID: 23
		private OnUploadProgressDelegate onUploadProgress;
	}
}
