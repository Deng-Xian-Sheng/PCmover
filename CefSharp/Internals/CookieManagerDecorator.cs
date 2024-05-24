using System;
using System.Threading.Tasks;

namespace CefSharp.Internals
{
	// Token: 0x020000C8 RID: 200
	public class CookieManagerDecorator : ICookieManager, IDisposable
	{
		// Token: 0x060005EC RID: 1516 RVA: 0x0000994C File Offset: 0x00007B4C
		internal CookieManagerDecorator(ICookieManager manager, TaskCompletionCallback callback)
		{
			if (manager == null)
			{
				throw new ArgumentNullException("manager");
			}
			if (callback == null)
			{
				throw new ArgumentNullException("manager");
			}
			this.manager = manager;
			if (callback.Task.Status == TaskStatus.RanToCompletion)
			{
				this.managerReady = callback.Task.Result;
				return;
			}
			callback.Task.ContinueWith(delegate(Task<bool> x)
			{
				this.managerReady = x.Result;
			});
		}

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x060005ED RID: 1517 RVA: 0x000099BC File Offset: 0x00007BBC
		bool ICookieManager.IsDisposed
		{
			get
			{
				return this.manager.IsDisposed;
			}
		}

		// Token: 0x060005EE RID: 1518 RVA: 0x000099C9 File Offset: 0x00007BC9
		bool ICookieManager.DeleteCookies(string url, string name, IDeleteCookiesCallback callback)
		{
			if (this.managerReady)
			{
				return this.manager.DeleteCookies(url, name, callback);
			}
			throw new InvalidOperationException("CookieManager store is not initialized.");
		}

		// Token: 0x060005EF RID: 1519 RVA: 0x000099EE File Offset: 0x00007BEE
		void IDisposable.Dispose()
		{
			this.manager.Dispose();
		}

		// Token: 0x060005F0 RID: 1520 RVA: 0x000099FB File Offset: 0x00007BFB
		bool ICookieManager.FlushStore(ICompletionCallback callback)
		{
			if (this.managerReady)
			{
				return this.manager.FlushStore(callback);
			}
			throw new InvalidOperationException("CookieManager store is not initialized.");
		}

		// Token: 0x060005F1 RID: 1521 RVA: 0x00009A1E File Offset: 0x00007C1E
		bool ICookieManager.SetCookie(string url, Cookie cookie, ISetCookieCallback callback)
		{
			if (this.managerReady)
			{
				return this.manager.SetCookie(url, cookie, callback);
			}
			throw new InvalidOperationException("CookieManager store is not initialized.");
		}

		// Token: 0x060005F2 RID: 1522 RVA: 0x00009A43 File Offset: 0x00007C43
		bool ICookieManager.VisitAllCookies(ICookieVisitor visitor)
		{
			if (this.managerReady)
			{
				return this.manager.VisitAllCookies(visitor);
			}
			throw new InvalidOperationException("CookieManager store is not initialized.");
		}

		// Token: 0x060005F3 RID: 1523 RVA: 0x00009A66 File Offset: 0x00007C66
		bool ICookieManager.VisitUrlCookies(string url, bool includeHttpOnly, ICookieVisitor visitor)
		{
			if (this.managerReady)
			{
				return this.manager.VisitUrlCookies(url, includeHttpOnly, visitor);
			}
			throw new InvalidOperationException("CookieManager store is not initialized.");
		}

		// Token: 0x0400033F RID: 831
		private const string NotInitialziedExceptionMsg = "CookieManager store is not initialized.";

		// Token: 0x04000340 RID: 832
		private ICookieManager manager;

		// Token: 0x04000341 RID: 833
		private volatile bool managerReady;
	}
}
