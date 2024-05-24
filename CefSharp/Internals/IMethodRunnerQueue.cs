using System;

namespace CefSharp.Internals
{
	// Token: 0x020000D1 RID: 209
	public interface IMethodRunnerQueue : IDisposable
	{
		// Token: 0x1400000D RID: 13
		// (add) Token: 0x06000619 RID: 1561
		// (remove) Token: 0x0600061A RID: 1562
		event EventHandler<MethodInvocationCompleteArgs> MethodInvocationComplete;

		// Token: 0x0600061B RID: 1563
		void Enqueue(MethodInvocation methodInvocation);
	}
}
