using System;

namespace CefSharp.Fluent
{
	// Token: 0x0200001C RID: 28
	public class UrlRequestClientBuilder
	{
		// Token: 0x0600017B RID: 379 RVA: 0x0000374B File Offset: 0x0000194B
		public UrlRequestClientBuilder GetAuthCredentials(GetAuthCredentialsDelegate func)
		{
			this.client.SetGetAuthCredentials(func);
			return this;
		}

		// Token: 0x0600017C RID: 380 RVA: 0x0000375A File Offset: 0x0000195A
		public UrlRequestClientBuilder OnDownloadData(OnDownloadDataDelegate action)
		{
			this.client.SetOnDownloadData(action);
			return this;
		}

		// Token: 0x0600017D RID: 381 RVA: 0x00003769 File Offset: 0x00001969
		public UrlRequestClientBuilder OnDownloadProgress(OnDownloadProgressDelegate action)
		{
			this.client.SetOnDownloadProgress(action);
			return this;
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00003778 File Offset: 0x00001978
		public UrlRequestClientBuilder OnRequestComplete(OnRequestCompleteDelegate action)
		{
			this.client.SetOnRequestComplete(action);
			return this;
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00003787 File Offset: 0x00001987
		public UrlRequestClientBuilder OnUploadProgress(OnUploadProgressDelegate action)
		{
			this.client.SetOnUploadProgress(action);
			return this;
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00003796 File Offset: 0x00001996
		public IUrlRequestClient Build()
		{
			return this.client;
		}

		// Token: 0x04000018 RID: 24
		private UrlRequestClient client = new UrlRequestClient();
	}
}
