using System;
using System.Threading.Tasks;
using CefSharp.Internals;

namespace CefSharp
{
	// Token: 0x0200009F RID: 159
	public class TaskStringVisitor : IStringVisitor, IDisposable
	{
		// Token: 0x06000496 RID: 1174 RVA: 0x00006F97 File Offset: 0x00005197
		public TaskStringVisitor()
		{
			this.taskCompletionSource = new TaskCompletionSource<string>();
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x00006FAA File Offset: 0x000051AA
		void IStringVisitor.Visit(string str)
		{
			this.taskCompletionSource.TrySetResultAsync(str);
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x06000498 RID: 1176 RVA: 0x00006FB8 File Offset: 0x000051B8
		public Task<string> Task
		{
			get
			{
				return this.taskCompletionSource.Task;
			}
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x00006FC5 File Offset: 0x000051C5
		void IDisposable.Dispose()
		{
		}

		// Token: 0x040002D8 RID: 728
		private readonly TaskCompletionSource<string> taskCompletionSource;
	}
}
