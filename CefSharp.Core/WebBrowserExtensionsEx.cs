using System;
using System.IO;
using System.Threading.Tasks;
using CefSharp.Fluent;
using CefSharp.Internals;

namespace CefSharp
{
	// Token: 0x0200000F RID: 15
	public static class WebBrowserExtensionsEx
	{
		// Token: 0x0600011B RID: 283 RVA: 0x00003268 File Offset: 0x00001468
		public static Task<NavigationEntry> GetVisibleNavigationEntryAsync(this IChromiumWebBrowserBase browser)
		{
			IBrowserHost host = browser.GetBrowserHost();
			if (host == null)
			{
				return Task.FromResult<NavigationEntry>(null);
			}
			if (Cef.CurrentlyOnThread(CefThreadIds.TID_UI))
			{
				NavigationEntry visibleNavigationEntry = host.GetVisibleNavigationEntry();
				return Task.FromResult<NavigationEntry>(visibleNavigationEntry);
			}
			TaskCompletionSource<NavigationEntry> tcs = new TaskCompletionSource<NavigationEntry>();
			Cef.UIThreadTaskFactory.StartNew(delegate()
			{
				NavigationEntry visibleNavigationEntry2 = host.GetVisibleNavigationEntry();
				tcs.TrySetResultAsync(visibleNavigationEntry2);
			});
			return tcs.Task;
		}

		// Token: 0x0600011C RID: 284 RVA: 0x000032E0 File Offset: 0x000014E0
		public static void DownloadUrl(this IFrame frame, string url, Action<IUrlRequest, Stream> completeHandler)
		{
			if (!frame.IsValid)
			{
				throw new Exception("Frame is invalid, unable to continue.");
			}
			Cef.UIThreadTaskFactory.StartNew(delegate()
			{
				IRequest request = frame.CreateRequest(false);
				request.Method = "GET";
				request.Url = url;
				MemoryStream memoryStream = new MemoryStream();
				IUrlRequestClient client = UrlRequestClient.Create().OnDownloadData(delegate(IUrlRequest req, Stream stream)
				{
					stream.CopyTo(memoryStream);
				}).OnRequestComplete(delegate(IUrlRequest req)
				{
					memoryStream.Position = 0L;
					Action<IUrlRequest, Stream> completeHandler2 = completeHandler;
					if (completeHandler2 == null)
					{
						return;
					}
					completeHandler2(req, memoryStream);
				}).Build();
				IUrlRequest urlRequest = frame.CreateUrlRequest(request, client);
			});
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00003338 File Offset: 0x00001538
		public static Task<byte[]> DownloadUrlAsync(this IFrame frame, string url)
		{
			if (!frame.IsValid)
			{
				throw new Exception("Frame is invalid, unable to continue.");
			}
			TaskCompletionSource<byte[]> taskCompletionSource = new TaskCompletionSource<byte[]>();
			Cef.UIThreadTaskFactory.StartNew(delegate()
			{
				IRequest request = frame.CreateRequest(false);
				request.Method = "GET";
				request.Url = url;
				MemoryStream memoryStream = new MemoryStream();
				IUrlRequestClient client = UrlRequestClient.Create().OnDownloadData(delegate(IUrlRequest req, Stream stream)
				{
					stream.CopyTo(memoryStream);
				}).OnRequestComplete(delegate(IUrlRequest req)
				{
					if (req.RequestStatus == UrlRequestStatus.Success)
					{
						taskCompletionSource.TrySetResultAsync(memoryStream.ToArray());
						return;
					}
					taskCompletionSource.TrySetExceptionAsync(new Exception("RequestStatus:" + req.RequestStatus.ToString() + ";StatusCode:" + req.Response.StatusCode.ToString()));
				}).Build();
				IUrlRequest urlRequest = frame.CreateUrlRequest(request, client);
			});
			return taskCompletionSource.Task;
		}
	}
}
