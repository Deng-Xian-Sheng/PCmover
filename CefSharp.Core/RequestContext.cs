using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using CefSharp.Core;

namespace CefSharp
{
	// Token: 0x0200000B RID: 11
	public class RequestContext : IRequestContext, IDisposable
	{
		// Token: 0x060000DB RID: 219 RVA: 0x00002D16 File Offset: 0x00000F16
		public RequestContext()
		{
			this.requestContext = new RequestContext();
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00002D29 File Offset: 0x00000F29
		public RequestContext(IRequestContext otherRequestContext)
		{
			this.requestContext = new RequestContext(otherRequestContext);
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00002D3D File Offset: 0x00000F3D
		public RequestContext(IRequestContext otherRequestContext, IRequestContextHandler requestContextHandler)
		{
			this.requestContext = new RequestContext(otherRequestContext, requestContextHandler);
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00002D52 File Offset: 0x00000F52
		public RequestContext(IRequestContextHandler requestContextHandler)
		{
			this.requestContext = new RequestContext(requestContextHandler);
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00002D66 File Offset: 0x00000F66
		public RequestContext(RequestContextSettings settings)
		{
			this.requestContext = new RequestContext(settings.settings);
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00002D7F File Offset: 0x00000F7F
		public RequestContext(RequestContextSettings settings, IRequestContextHandler requestContextHandler)
		{
			this.requestContext = new RequestContext(settings.settings, requestContextHandler);
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00002D9C File Offset: 0x00000F9C
		public static RequestContextBuilder Configure()
		{
			return new RequestContextBuilder();
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060000E2 RID: 226 RVA: 0x00002DB0 File Offset: 0x00000FB0
		public bool IsGlobal
		{
			get
			{
				return this.requestContext.IsGlobal;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x00002DBD File Offset: 0x00000FBD
		public string CachePath
		{
			get
			{
				return this.requestContext.CachePath;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060000E4 RID: 228 RVA: 0x00002DCA File Offset: 0x00000FCA
		public bool IsDisposed
		{
			get
			{
				return this.requestContext.IsDisposed;
			}
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00002DD7 File Offset: 0x00000FD7
		public bool IsSame(IRequestContext context)
		{
			return this.requestContext.IsSame(context);
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00002DE5 File Offset: 0x00000FE5
		public bool IsSharingWith(IRequestContext context)
		{
			return this.requestContext.IsSharingWith(context);
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00002DF3 File Offset: 0x00000FF3
		public ICookieManager GetCookieManager(ICompletionCallback callback)
		{
			return this.requestContext.GetCookieManager(callback);
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00002E01 File Offset: 0x00001001
		public bool RegisterSchemeHandlerFactory(string schemeName, string domainName, ISchemeHandlerFactory factory)
		{
			return this.requestContext.RegisterSchemeHandlerFactory(schemeName, domainName, factory);
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00002E11 File Offset: 0x00001011
		public bool ClearSchemeHandlerFactories()
		{
			return this.requestContext.ClearSchemeHandlerFactories();
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00002E1E File Offset: 0x0000101E
		public bool HasPreference(string name)
		{
			return this.requestContext.HasPreference(name);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00002E2C File Offset: 0x0000102C
		public object GetPreference(string name)
		{
			return this.requestContext.GetPreference(name);
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00002E3A File Offset: 0x0000103A
		public IDictionary<string, object> GetAllPreferences(bool includeDefaults)
		{
			return this.requestContext.GetAllPreferences(includeDefaults);
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00002E48 File Offset: 0x00001048
		public bool CanSetPreference(string name)
		{
			return this.requestContext.CanSetPreference(name);
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00002E56 File Offset: 0x00001056
		public bool SetPreference(string name, object value, out string error)
		{
			return this.requestContext.SetPreference(name, value, ref error);
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00002E66 File Offset: 0x00001066
		public void ClearCertificateExceptions(ICompletionCallback callback)
		{
			this.requestContext.ClearCertificateExceptions(callback);
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00002E74 File Offset: 0x00001074
		public void ClearHttpAuthCredentials(ICompletionCallback callback = null)
		{
			this.requestContext.ClearHttpAuthCredentials(callback);
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00002E82 File Offset: 0x00001082
		public void CloseAllConnections(ICompletionCallback callback)
		{
			this.requestContext.CloseAllConnections(callback);
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00002E90 File Offset: 0x00001090
		public Task<ResolveCallbackResult> ResolveHostAsync(Uri origin)
		{
			return this.requestContext.ResolveHostAsync(origin);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00002E9E File Offset: 0x0000109E
		public bool DidLoadExtension(string extensionId)
		{
			return this.requestContext.DidLoadExtension(extensionId);
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00002EAC File Offset: 0x000010AC
		public IExtension GetExtension(string extensionId)
		{
			return this.requestContext.GetExtension(extensionId);
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00002EBA File Offset: 0x000010BA
		public bool GetExtensions(out IList<string> extensionIds)
		{
			return this.requestContext.GetExtensions(ref extensionIds);
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00002EC8 File Offset: 0x000010C8
		public bool HasExtension(string extensionId)
		{
			return this.requestContext.CanSetPreference(extensionId);
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00002ED8 File Offset: 0x000010D8
		public void LoadExtension(string rootDirectory, string manifestJson, IExtensionHandler handler)
		{
			if (Cef.CurrentlyOnThread(CefThreadIds.TID_UI))
			{
				this.requestContext.LoadExtension(rootDirectory, manifestJson, handler);
				return;
			}
			Cef.UIThreadTaskFactory.StartNew(delegate()
			{
				this.requestContext.LoadExtension(rootDirectory, manifestJson, handler);
			});
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00002F44 File Offset: 0x00001144
		public void Dispose()
		{
			this.requestContext.Dispose();
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00002F51 File Offset: 0x00001151
		[EditorBrowsable(EditorBrowsableState.Never)]
		public IRequestContext UnWrap()
		{
			return this.requestContext;
		}

		// Token: 0x04000007 RID: 7
		private RequestContext requestContext;
	}
}
