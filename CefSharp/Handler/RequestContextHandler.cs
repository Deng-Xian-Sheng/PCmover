using System;
using System.Collections.Generic;

namespace CefSharp.Handler
{
	// Token: 0x02000107 RID: 263
	public class RequestContextHandler : IRequestContextHandler
	{
		// Token: 0x060007C9 RID: 1993 RVA: 0x0000C633 File Offset: 0x0000A833
		public RequestContextHandler OnInitialize(Action<IRequestContext> onContextInitialziedAction)
		{
			this.onContextInitialziedAction = onContextInitialziedAction;
			return this;
		}

		// Token: 0x060007CA RID: 1994 RVA: 0x0000C63D File Offset: 0x0000A83D
		public RequestContextHandler SetPreferenceOnContextInitialized(string name, object value)
		{
			if (this.requestContextInitialized)
			{
				throw new Exception("RequestContext has already been initialized, ");
			}
			this.preferences.Add(new KeyValuePair<string, object>(name, value));
			return this;
		}

		// Token: 0x060007CB RID: 1995 RVA: 0x0000C665 File Offset: 0x0000A865
		public RequestContextHandler SetProxyOnContextInitialized(string host, int? port = null)
		{
			return this.SetProxyOnContextInitialized(null, host, port);
		}

		// Token: 0x060007CC RID: 1996 RVA: 0x0000C670 File Offset: 0x0000A870
		public RequestContextHandler SetProxyOnContextInitialized(string scheme, string host, int? port)
		{
			if (this.requestContextInitialized)
			{
				throw new Exception("RequestContext has already been initialized, ");
			}
			IDictionary<string, object> proxyDictionary = RequestContextExtensions.GetProxyDictionary(scheme, host, port);
			this.preferences.Add(new KeyValuePair<string, object>("proxy", proxyDictionary));
			return this;
		}

		// Token: 0x060007CD RID: 1997 RVA: 0x0000C6B0 File Offset: 0x0000A8B0
		IResourceRequestHandler IRequestContextHandler.GetResourceRequestHandler(IBrowser browser, IFrame frame, IRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
		{
			return this.GetResourceRequestHandler(browser, frame, request, isNavigation, isDownload, requestInitiator, ref disableDefaultHandling);
		}

		// Token: 0x060007CE RID: 1998 RVA: 0x0000C6C3 File Offset: 0x0000A8C3
		protected virtual IResourceRequestHandler GetResourceRequestHandler(IBrowser browser, IFrame frame, IRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
		{
			return null;
		}

		// Token: 0x060007CF RID: 1999 RVA: 0x0000C6C8 File Offset: 0x0000A8C8
		void IRequestContextHandler.OnRequestContextInitialized(IRequestContext requestContext)
		{
			this.requestContextInitialized = true;
			foreach (KeyValuePair<string, object> keyValuePair in this.preferences)
			{
				string text;
				requestContext.SetPreference(keyValuePair.Key, keyValuePair.Value, out text);
			}
			Action<IRequestContext> action = this.onContextInitialziedAction;
			if (action != null)
			{
				action(requestContext);
			}
			this.OnRequestContextInitialized(requestContext);
		}

		// Token: 0x060007D0 RID: 2000 RVA: 0x0000C748 File Offset: 0x0000A948
		protected virtual void OnRequestContextInitialized(IRequestContext requestContext)
		{
		}

		// Token: 0x040003A4 RID: 932
		private readonly IList<KeyValuePair<string, object>> preferences = new List<KeyValuePair<string, object>>();

		// Token: 0x040003A5 RID: 933
		private bool requestContextInitialized;

		// Token: 0x040003A6 RID: 934
		private Action<IRequestContext> onContextInitialziedAction;
	}
}
