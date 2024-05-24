using System;
using System.Threading.Tasks;
using CefSharp.Handler;

namespace CefSharp.Internals
{
	// Token: 0x020000D2 RID: 210
	public class InitializeAsyncBrowserProcessHandler : BrowserProcessHandler
	{
		// Token: 0x0600061C RID: 1564 RVA: 0x00009BCC File Offset: 0x00007DCC
		public InitializeAsyncBrowserProcessHandler(TaskCompletionSource<bool> tcs)
		{
			this.taskCompletionSource = tcs;
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x00009BDB File Offset: 0x00007DDB
		protected override void OnContextInitialized()
		{
			base.OnContextInitialized();
			this.taskCompletionSource.TrySetResult(true);
		}

		// Token: 0x04000345 RID: 837
		private TaskCompletionSource<bool> taskCompletionSource;
	}
}
