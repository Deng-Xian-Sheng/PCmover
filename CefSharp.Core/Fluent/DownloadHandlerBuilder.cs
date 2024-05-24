using System;

namespace CefSharp.Fluent
{
	// Token: 0x02000015 RID: 21
	public class DownloadHandlerBuilder
	{
		// Token: 0x06000157 RID: 343 RVA: 0x00003669 File Offset: 0x00001869
		public DownloadHandlerBuilder OnBeforeDownload(OnBeforeDownloadDelegate action)
		{
			this.handler.SetOnBeforeDownload(action);
			return this;
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00003678 File Offset: 0x00001878
		public DownloadHandlerBuilder OnDownloadUpdated(OnDownloadUpdatedDelegate action)
		{
			this.handler.SetOnDownloadUpdated(action);
			return this;
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00003687 File Offset: 0x00001887
		public IDownloadHandler Build()
		{
			return this.handler;
		}

		// Token: 0x04000012 RID: 18
		private readonly DownloadHandler handler = new DownloadHandler();
	}
}
