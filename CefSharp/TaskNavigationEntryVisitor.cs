using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CefSharp.Internals;

namespace CefSharp
{
	// Token: 0x0200009E RID: 158
	public class TaskNavigationEntryVisitor : INavigationEntryVisitor, IDisposable
	{
		// Token: 0x06000492 RID: 1170 RVA: 0x00006F34 File Offset: 0x00005134
		public TaskNavigationEntryVisitor()
		{
			this.taskCompletionSource = new TaskCompletionSource<List<NavigationEntry>>();
			this.list = new List<NavigationEntry>();
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x00006F52 File Offset: 0x00005152
		bool INavigationEntryVisitor.Visit(NavigationEntry entry, bool current, int index, int total)
		{
			this.list.Add(entry);
			return true;
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x00006F61 File Offset: 0x00005161
		void IDisposable.Dispose()
		{
			if (this.list != null)
			{
				this.taskCompletionSource.TrySetResultAsync(this.list);
			}
			this.list = null;
			this.taskCompletionSource = null;
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x06000495 RID: 1173 RVA: 0x00006F8A File Offset: 0x0000518A
		public Task<List<NavigationEntry>> Task
		{
			get
			{
				return this.taskCompletionSource.Task;
			}
		}

		// Token: 0x040002D6 RID: 726
		private TaskCompletionSource<List<NavigationEntry>> taskCompletionSource;

		// Token: 0x040002D7 RID: 727
		private List<NavigationEntry> list;
	}
}
