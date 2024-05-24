using System;
using System.Threading.Tasks;

namespace CefSharp
{
	// Token: 0x0200000C RID: 12
	public interface IJavascriptCallback : IDisposable
	{
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000025 RID: 37
		long Id { get; }

		// Token: 0x06000026 RID: 38
		Task<JavascriptResponse> ExecuteAsync(params object[] parms);

		// Token: 0x06000027 RID: 39
		Task<JavascriptResponse> ExecuteWithTimeoutAsync(TimeSpan? timeout, params object[] parms);

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000028 RID: 40
		bool CanExecute { get; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000029 RID: 41
		bool IsDisposed { get; }
	}
}
