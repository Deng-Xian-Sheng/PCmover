using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CefSharp.Internals;

namespace CefSharp
{
	// Token: 0x0200009D RID: 157
	public class TaskCookieVisitor : ICookieVisitor, IDisposable
	{
		// Token: 0x0600048E RID: 1166 RVA: 0x00006EB4 File Offset: 0x000050B4
		public TaskCookieVisitor()
		{
			this.taskCompletionSource = new TaskCompletionSource<List<Cookie>>();
			this.list = new List<Cookie>();
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x00006ED2 File Offset: 0x000050D2
		bool ICookieVisitor.Visit(Cookie cookie, int count, int total, ref bool deleteCookie)
		{
			this.list.Add(cookie);
			if (count == total - 1)
			{
				this.taskCompletionSource.TrySetResultAsync(this.list);
			}
			return true;
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x00006EF8 File Offset: 0x000050F8
		void IDisposable.Dispose()
		{
			if (this.list != null && this.list.Count == 0)
			{
				this.taskCompletionSource.TrySetResultAsync(this.list);
			}
			this.list = null;
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x06000491 RID: 1169 RVA: 0x00006F27 File Offset: 0x00005127
		public Task<List<Cookie>> Task
		{
			get
			{
				return this.taskCompletionSource.Task;
			}
		}

		// Token: 0x040002D4 RID: 724
		private readonly TaskCompletionSource<List<Cookie>> taskCompletionSource;

		// Token: 0x040002D5 RID: 725
		private List<Cookie> list;
	}
}
