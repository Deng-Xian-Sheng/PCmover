using System;
using System.Threading;
using System.Threading.Tasks;

namespace CefSharp.Internals.Tasks
{
	// Token: 0x020000F5 RID: 245
	public class SyncContextTaskCompletionSource<TResult> : TaskCompletionSource<TResult>
	{
		// Token: 0x1700021F RID: 543
		// (get) Token: 0x06000733 RID: 1843 RVA: 0x0000C0D0 File Offset: 0x0000A2D0
		// (set) Token: 0x06000734 RID: 1844 RVA: 0x0000C0D8 File Offset: 0x0000A2D8
		public SynchronizationContext SyncContext { get; set; }
	}
}
