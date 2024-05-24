using System;
using System.Threading;

namespace CefSharp.Internals
{
	// Token: 0x020000C1 RID: 193
	public class BrowserRefCounter : IBrowserRefCounter
	{
		// Token: 0x060005C9 RID: 1481 RVA: 0x000093FC File Offset: 0x000075FC
		void IBrowserRefCounter.Increment()
		{
			int num = Interlocked.Increment(ref this.count);
			if (num > 0)
			{
				this.manualResetEvent.Reset();
			}
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x00009424 File Offset: 0x00007624
		bool IBrowserRefCounter.Decrement()
		{
			int num = Interlocked.Decrement(ref this.count);
			if (num == 0)
			{
				this.manualResetEvent.Set();
				return true;
			}
			if (num < 0)
			{
				Interlocked.Exchange(ref this.count, 0);
				this.manualResetEvent.Set();
			}
			return false;
		}

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x060005CB RID: 1483 RVA: 0x0000946C File Offset: 0x0000766C
		int IBrowserRefCounter.Count
		{
			get
			{
				int num = this.count;
				if (num >= 0)
				{
					return num;
				}
				return 0;
			}
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x00009489 File Offset: 0x00007689
		void IBrowserRefCounter.WaitForBrowsersToClose(int timeoutInMiliseconds)
		{
			if (!this.manualResetEvent.IsSet)
			{
				this.manualResetEvent.Wait(timeoutInMiliseconds);
			}
		}

		// Token: 0x060005CD RID: 1485 RVA: 0x000094A5 File Offset: 0x000076A5
		void IBrowserRefCounter.WaitForBrowsersToClose(int timeoutInMiliseconds, CancellationToken cancellationToken)
		{
			if (!this.manualResetEvent.IsSet)
			{
				this.manualResetEvent.Wait(timeoutInMiliseconds, cancellationToken);
			}
		}

		// Token: 0x0400032D RID: 813
		private volatile int count;

		// Token: 0x0400032E RID: 814
		private ManualResetEventSlim manualResetEvent = new ManualResetEventSlim();

		// Token: 0x0400032F RID: 815
		public static IBrowserRefCounter Instance = new NoOpBrowserRefCounter();
	}
}
