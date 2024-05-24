using System;
using System.Threading;

namespace CefSharp.Internals
{
	// Token: 0x020000CE RID: 206
	public interface IBrowserRefCounter
	{
		// Token: 0x0600060A RID: 1546
		void Increment();

		// Token: 0x0600060B RID: 1547
		bool Decrement();

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x0600060C RID: 1548
		int Count { get; }

		// Token: 0x0600060D RID: 1549
		void WaitForBrowsersToClose(int timeoutInMiliseconds = 500);

		// Token: 0x0600060E RID: 1550
		void WaitForBrowsersToClose(int timeoutInMiliseconds, CancellationToken cancellationToken);
	}
}
