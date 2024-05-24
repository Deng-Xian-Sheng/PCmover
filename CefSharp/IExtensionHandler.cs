using System;

namespace CefSharp
{
	// Token: 0x02000056 RID: 86
	public interface IExtensionHandler : IDisposable
	{
		// Token: 0x06000146 RID: 326
		void OnExtensionLoadFailed(CefErrorCode errorCode);

		// Token: 0x06000147 RID: 327
		void OnExtensionLoaded(IExtension extension);

		// Token: 0x06000148 RID: 328
		void OnExtensionUnloaded(IExtension extension);

		// Token: 0x06000149 RID: 329
		bool OnBeforeBackgroundBrowser(IExtension extension, string url, IBrowserSettings settings);

		// Token: 0x0600014A RID: 330
		bool OnBeforeBrowser(IExtension extension, IBrowser browser, IBrowser activeBrowser, int index, string url, bool active, IWindowInfo windowInfo, IBrowserSettings settings);

		// Token: 0x0600014B RID: 331
		IBrowser GetActiveBrowser(IExtension extension, IBrowser browser, bool includeIncognito);

		// Token: 0x0600014C RID: 332
		bool CanAccessBrowser(IExtension extension, IBrowser browser, bool includeIncognito, IBrowser targetBrowser);

		// Token: 0x0600014D RID: 333
		bool GetExtensionResource(IExtension extension, IBrowser browser, string file, IGetExtensionResourceCallback callback);
	}
}
