using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CefSharp
{
	// Token: 0x02000078 RID: 120
	public interface IRequestContext : IDisposable
	{
		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06000315 RID: 789
		bool IsDisposed { get; }

		// Token: 0x06000316 RID: 790
		bool IsSame(IRequestContext context);

		// Token: 0x06000317 RID: 791
		bool IsSharingWith(IRequestContext context);

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x06000318 RID: 792
		bool IsGlobal { get; }

		// Token: 0x06000319 RID: 793
		ICookieManager GetCookieManager(ICompletionCallback callback);

		// Token: 0x0600031A RID: 794
		bool RegisterSchemeHandlerFactory(string schemeName, string domainName, ISchemeHandlerFactory factory);

		// Token: 0x0600031B RID: 795
		bool ClearSchemeHandlerFactories();

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x0600031C RID: 796
		string CachePath { get; }

		// Token: 0x0600031D RID: 797
		bool HasPreference(string name);

		// Token: 0x0600031E RID: 798
		object GetPreference(string name);

		// Token: 0x0600031F RID: 799
		IDictionary<string, object> GetAllPreferences(bool includeDefaults);

		// Token: 0x06000320 RID: 800
		bool CanSetPreference(string name);

		// Token: 0x06000321 RID: 801
		bool SetPreference(string name, object value, out string error);

		// Token: 0x06000322 RID: 802
		void ClearCertificateExceptions(ICompletionCallback callback);

		// Token: 0x06000323 RID: 803
		void ClearHttpAuthCredentials(ICompletionCallback callback = null);

		// Token: 0x06000324 RID: 804
		void CloseAllConnections(ICompletionCallback callback);

		// Token: 0x06000325 RID: 805
		Task<ResolveCallbackResult> ResolveHostAsync(Uri origin);

		// Token: 0x06000326 RID: 806
		bool DidLoadExtension(string extensionId);

		// Token: 0x06000327 RID: 807
		IExtension GetExtension(string extensionId);

		// Token: 0x06000328 RID: 808
		bool GetExtensions(out IList<string> extensionIds);

		// Token: 0x06000329 RID: 809
		bool HasExtension(string extensionId);

		// Token: 0x0600032A RID: 810
		void LoadExtension(string rootDirectory, string manifestJson, IExtensionHandler handler);

		// Token: 0x0600032B RID: 811
		[EditorBrowsable(EditorBrowsableState.Never)]
		IRequestContext UnWrap();
	}
}
