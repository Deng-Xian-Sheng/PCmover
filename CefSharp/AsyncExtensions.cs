using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CefSharp
{
	// Token: 0x02000002 RID: 2
	public static class AsyncExtensions
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static Task<int> DeleteCookiesAsync(this ICookieManager cookieManager, string url = null, string name = null)
		{
			if (cookieManager == null)
			{
				throw new NullReferenceException("cookieManager");
			}
			if (cookieManager.IsDisposed)
			{
				throw new ObjectDisposedException("cookieManager");
			}
			TaskDeleteCookiesCallback taskDeleteCookiesCallback = new TaskDeleteCookiesCallback();
			if (cookieManager.DeleteCookies(url, name, taskDeleteCookiesCallback))
			{
				return taskDeleteCookiesCallback.Task;
			}
			return Task.FromResult<int>(-1);
		}

		// Token: 0x06000002 RID: 2 RVA: 0x0000209C File Offset: 0x0000029C
		public static Task<bool> SetCookieAsync(this ICookieManager cookieManager, string url, Cookie cookie)
		{
			if (cookieManager == null)
			{
				throw new NullReferenceException("cookieManager");
			}
			if (cookieManager.IsDisposed)
			{
				throw new ObjectDisposedException("cookieManager");
			}
			TaskSetCookieCallback taskSetCookieCallback = new TaskSetCookieCallback();
			if (cookieManager.SetCookie(url, cookie, taskSetCookieCallback))
			{
				return taskSetCookieCallback.Task;
			}
			return Task.FromResult<bool>(false);
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000020E8 File Offset: 0x000002E8
		public static Task<List<Cookie>> VisitAllCookiesAsync(this ICookieManager cookieManager)
		{
			TaskCookieVisitor taskCookieVisitor = new TaskCookieVisitor();
			if (cookieManager.VisitAllCookies(taskCookieVisitor))
			{
				return taskCookieVisitor.Task;
			}
			return Task.FromResult<List<Cookie>>(null);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002114 File Offset: 0x00000314
		public static Task<List<Cookie>> VisitUrlCookiesAsync(this ICookieManager cookieManager, string url, bool includeHttpOnly)
		{
			TaskCookieVisitor taskCookieVisitor = new TaskCookieVisitor();
			if (cookieManager.VisitUrlCookies(url, includeHttpOnly, taskCookieVisitor))
			{
				return taskCookieVisitor.Task;
			}
			return Task.FromResult<List<Cookie>>(null);
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002140 File Offset: 0x00000340
		public static Task<bool> FlushStoreAsync(this ICookieManager cookieManager)
		{
			TaskCompletionCallback taskCompletionCallback = new TaskCompletionCallback();
			if (cookieManager.FlushStore(taskCompletionCallback))
			{
				return taskCompletionCallback.Task;
			}
			return Task.FromResult<bool>(false);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000216C File Offset: 0x0000036C
		public static Task<List<NavigationEntry>> GetNavigationEntriesAsync(this IBrowserHost browserHost, bool currentOnly = false)
		{
			TaskNavigationEntryVisitor taskNavigationEntryVisitor = new TaskNavigationEntryVisitor();
			browserHost.GetNavigationEntries(taskNavigationEntryVisitor, currentOnly);
			return taskNavigationEntryVisitor.Task;
		}
	}
}
