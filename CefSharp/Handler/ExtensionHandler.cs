using System;

namespace CefSharp.Handler
{
	// Token: 0x020000FF RID: 255
	public class ExtensionHandler : IExtensionHandler, IDisposable
	{
		// Token: 0x06000781 RID: 1921 RVA: 0x0000C32F File Offset: 0x0000A52F
		void IExtensionHandler.OnExtensionLoadFailed(CefErrorCode errorCode)
		{
			this.OnExtensionLoadFailed(errorCode);
		}

		// Token: 0x06000782 RID: 1922 RVA: 0x0000C338 File Offset: 0x0000A538
		protected virtual void OnExtensionLoadFailed(CefErrorCode errorCode)
		{
		}

		// Token: 0x06000783 RID: 1923 RVA: 0x0000C33A File Offset: 0x0000A53A
		void IExtensionHandler.OnExtensionLoaded(IExtension extension)
		{
			this.OnExtensionLoaded(extension);
		}

		// Token: 0x06000784 RID: 1924 RVA: 0x0000C343 File Offset: 0x0000A543
		protected virtual void OnExtensionLoaded(IExtension extension)
		{
		}

		// Token: 0x06000785 RID: 1925 RVA: 0x0000C345 File Offset: 0x0000A545
		void IExtensionHandler.OnExtensionUnloaded(IExtension extension)
		{
			this.OnExtensionUnloaded(extension);
		}

		// Token: 0x06000786 RID: 1926 RVA: 0x0000C34E File Offset: 0x0000A54E
		protected virtual void OnExtensionUnloaded(IExtension extension)
		{
		}

		// Token: 0x06000787 RID: 1927 RVA: 0x0000C350 File Offset: 0x0000A550
		bool IExtensionHandler.OnBeforeBackgroundBrowser(IExtension extension, string url, IBrowserSettings settings)
		{
			return this.OnBeforeBackgroundBrowser(extension, url, settings);
		}

		// Token: 0x06000788 RID: 1928 RVA: 0x0000C35B File Offset: 0x0000A55B
		protected virtual bool OnBeforeBackgroundBrowser(IExtension extension, string url, IBrowserSettings settings)
		{
			return false;
		}

		// Token: 0x06000789 RID: 1929 RVA: 0x0000C360 File Offset: 0x0000A560
		bool IExtensionHandler.OnBeforeBrowser(IExtension extension, IBrowser browser, IBrowser activeBrowser, int index, string url, bool active, IWindowInfo windowInfo, IBrowserSettings settings)
		{
			return this.OnBeforeBrowser(extension, browser, activeBrowser, index, url, active, windowInfo, settings);
		}

		// Token: 0x0600078A RID: 1930 RVA: 0x0000C380 File Offset: 0x0000A580
		protected virtual bool OnBeforeBrowser(IExtension extension, IBrowser browser, IBrowser activeBrowser, int index, string url, bool active, IWindowInfo windowInfo, IBrowserSettings settings)
		{
			return false;
		}

		// Token: 0x0600078B RID: 1931 RVA: 0x0000C383 File Offset: 0x0000A583
		IBrowser IExtensionHandler.GetActiveBrowser(IExtension extension, IBrowser browser, bool includeIncognito)
		{
			return this.GetActiveBrowser(extension, browser, includeIncognito);
		}

		// Token: 0x0600078C RID: 1932 RVA: 0x0000C38E File Offset: 0x0000A58E
		protected virtual IBrowser GetActiveBrowser(IExtension extension, IBrowser browser, bool includeIncognito)
		{
			return null;
		}

		// Token: 0x0600078D RID: 1933 RVA: 0x0000C391 File Offset: 0x0000A591
		bool IExtensionHandler.CanAccessBrowser(IExtension extension, IBrowser browser, bool includeIncognito, IBrowser targetBrowser)
		{
			return this.CanAccessBrowser(extension, browser, includeIncognito, targetBrowser);
		}

		// Token: 0x0600078E RID: 1934 RVA: 0x0000C39E File Offset: 0x0000A59E
		protected virtual bool CanAccessBrowser(IExtension extension, IBrowser browser, bool includeIncognito, IBrowser targetBrowser)
		{
			return false;
		}

		// Token: 0x0600078F RID: 1935 RVA: 0x0000C3A1 File Offset: 0x0000A5A1
		bool IExtensionHandler.GetExtensionResource(IExtension extension, IBrowser browser, string file, IGetExtensionResourceCallback callback)
		{
			return this.GetExtensionResource(extension, browser, file, callback);
		}

		// Token: 0x06000790 RID: 1936 RVA: 0x0000C3AE File Offset: 0x0000A5AE
		protected virtual bool GetExtensionResource(IExtension extension, IBrowser browser, string file, IGetExtensionResourceCallback callback)
		{
			return false;
		}

		// Token: 0x17000222 RID: 546
		// (get) Token: 0x06000791 RID: 1937 RVA: 0x0000C3B1 File Offset: 0x0000A5B1
		public bool IsDisposed
		{
			get
			{
				return this.isDisposed;
			}
		}

		// Token: 0x06000792 RID: 1938 RVA: 0x0000C3B9 File Offset: 0x0000A5B9
		protected virtual void Dispose(bool disposing)
		{
			this.isDisposed = true;
		}

		// Token: 0x06000793 RID: 1939 RVA: 0x0000C3C2 File Offset: 0x0000A5C2
		void IDisposable.Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x040003A2 RID: 930
		private bool isDisposed;
	}
}
