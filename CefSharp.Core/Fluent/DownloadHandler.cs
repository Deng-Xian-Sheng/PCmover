using System;
using System.IO;
using CefSharp.Handler;

namespace CefSharp.Fluent
{
	// Token: 0x02000014 RID: 20
	public class DownloadHandler : DownloadHandler
	{
		// Token: 0x0600014F RID: 335 RVA: 0x000035A9 File Offset: 0x000017A9
		public static DownloadHandlerBuilder Create()
		{
			return new DownloadHandlerBuilder();
		}

		// Token: 0x06000150 RID: 336 RVA: 0x000035B0 File Offset: 0x000017B0
		public static IDownloadHandler UseFolder(string folder, OnDownloadUpdatedDelegate downloadUpdated = null)
		{
			return DownloadHandler.Create().OnBeforeDownload(delegate(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem item, IBeforeDownloadCallback callback)
			{
				try
				{
					string downloadPath = Path.Combine(folder, item.SuggestedFileName);
					callback.Continue(downloadPath, false);
				}
				finally
				{
					if (callback != null)
					{
						callback.Dispose();
					}
				}
			}).OnDownloadUpdated(downloadUpdated).Build();
		}

		// Token: 0x06000151 RID: 337 RVA: 0x000035EB File Offset: 0x000017EB
		public static IDownloadHandler AskUser(OnDownloadUpdatedDelegate downloadUpdated = null)
		{
			return DownloadHandler.Create().OnBeforeDownload(delegate(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem item, IBeforeDownloadCallback callback)
			{
				try
				{
					callback.Continue("", true);
				}
				finally
				{
					if (callback != null)
					{
						callback.Dispose();
					}
				}
			}).OnDownloadUpdated(downloadUpdated).Build();
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00003621 File Offset: 0x00001821
		internal DownloadHandler()
		{
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00003629 File Offset: 0x00001829
		internal void SetOnBeforeDownload(OnBeforeDownloadDelegate action)
		{
			this.onBeforeDownload = action;
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00003632 File Offset: 0x00001832
		internal void SetOnDownloadUpdated(OnDownloadUpdatedDelegate action)
		{
			this.onDownloadUpdated = action;
		}

		// Token: 0x06000155 RID: 341 RVA: 0x0000363B File Offset: 0x0000183B
		protected override void OnBeforeDownload(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback)
		{
			OnBeforeDownloadDelegate onBeforeDownloadDelegate = this.onBeforeDownload;
			if (onBeforeDownloadDelegate == null)
			{
				return;
			}
			onBeforeDownloadDelegate(chromiumWebBrowser, browser, downloadItem, callback);
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00003652 File Offset: 0x00001852
		protected override void OnDownloadUpdated(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
		{
			OnDownloadUpdatedDelegate onDownloadUpdatedDelegate = this.onDownloadUpdated;
			if (onDownloadUpdatedDelegate == null)
			{
				return;
			}
			onDownloadUpdatedDelegate(chromiumWebBrowser, browser, downloadItem, callback);
		}

		// Token: 0x04000010 RID: 16
		private OnBeforeDownloadDelegate onBeforeDownload;

		// Token: 0x04000011 RID: 17
		private OnDownloadUpdatedDelegate onDownloadUpdated;
	}
}
