using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using CefSharp.Internals;

namespace CefSharp
{
	// Token: 0x02000090 RID: 144
	public class ResourceRequestHandlerFactory : IResourceRequestHandlerFactory
	{
		// Token: 0x1700016A RID: 362
		// (get) Token: 0x0600042D RID: 1069 RVA: 0x00006A2C File Offset: 0x00004C2C
		// (set) Token: 0x0600042E RID: 1070 RVA: 0x00006A34 File Offset: 0x00004C34
		public ConcurrentDictionary<string, ResourceRequestHandlerFactoryItem> Handlers { get; private set; }

		// Token: 0x0600042F RID: 1071 RVA: 0x00006A3D File Offset: 0x00004C3D
		public ResourceRequestHandlerFactory(IEqualityComparer<string> comparer = null)
		{
			this.Handlers = new ConcurrentDictionary<string, ResourceRequestHandlerFactoryItem>(comparer ?? StringComparer.OrdinalIgnoreCase);
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x00006A5C File Offset: 0x00004C5C
		public virtual bool RegisterHandler(string url, byte[] data, string mimeType = "text/html", bool oneTimeUse = false)
		{
			Uri uri;
			if (Uri.TryCreate(url, UriKind.Absolute, out uri))
			{
				ResourceRequestHandlerFactoryItem entry = new ResourceRequestHandlerFactoryItem(data, mimeType, oneTimeUse);
				this.Handlers.AddOrUpdate(uri.AbsoluteUri, entry, (string k, ResourceRequestHandlerFactoryItem v) => entry);
				return true;
			}
			return false;
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x00006AB0 File Offset: 0x00004CB0
		public virtual bool UnregisterHandler(string url)
		{
			ResourceRequestHandlerFactoryItem resourceRequestHandlerFactoryItem;
			return this.Handlers.TryRemove(url, out resourceRequestHandlerFactoryItem);
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x06000432 RID: 1074 RVA: 0x00006ACB File Offset: 0x00004CCB
		bool IResourceRequestHandlerFactory.HasHandlers
		{
			get
			{
				return this.Handlers.Count > 0;
			}
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x00006ADC File Offset: 0x00004CDC
		IResourceRequestHandler IResourceRequestHandlerFactory.GetResourceRequestHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
		{
			return this.GetResourceRequestHandler(chromiumWebBrowser, browser, frame, request, isNavigation, isDownload, requestInitiator, ref disableDefaultHandling);
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x00006AFC File Offset: 0x00004CFC
		protected virtual IResourceRequestHandler GetResourceRequestHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
		{
			IResourceRequestHandler result;
			try
			{
				ResourceRequestHandlerFactoryItem resourceRequestHandlerFactoryItem;
				if (this.Handlers.TryGetValue(request.Url, out resourceRequestHandlerFactoryItem))
				{
					if (resourceRequestHandlerFactoryItem.OneTimeUse)
					{
						this.Handlers.TryRemove(request.Url, out resourceRequestHandlerFactoryItem);
					}
					result = new InMemoryResourceRequestHandler(resourceRequestHandlerFactoryItem.Data, resourceRequestHandlerFactoryItem.MimeType);
				}
				else
				{
					result = null;
				}
			}
			finally
			{
				request.Dispose();
			}
			return result;
		}
	}
}
