using System;
using System.Threading;

namespace CefSharp.Internals
{
	// Token: 0x020000E4 RID: 228
	public class NoOpBrowserRefCounter : IBrowserRefCounter
	{
		// Token: 0x17000216 RID: 534
		// (get) Token: 0x060006DF RID: 1759 RVA: 0x0000B32D File Offset: 0x0000952D
		int IBrowserRefCounter.Count
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x060006E0 RID: 1760 RVA: 0x0000B330 File Offset: 0x00009530
		bool IBrowserRefCounter.Decrement()
		{
			return false;
		}

		// Token: 0x060006E1 RID: 1761 RVA: 0x0000B333 File Offset: 0x00009533
		void IBrowserRefCounter.Increment()
		{
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x0000B335 File Offset: 0x00009535
		void IBrowserRefCounter.WaitForBrowsersToClose(int timeoutInMiliseconds)
		{
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x0000B337 File Offset: 0x00009537
		void IBrowserRefCounter.WaitForBrowsersToClose(int timeoutInMiliseconds, CancellationToken cancellationToken)
		{
		}
	}
}
