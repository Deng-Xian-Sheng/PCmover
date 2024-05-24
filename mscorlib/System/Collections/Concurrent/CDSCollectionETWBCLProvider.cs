using System;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;

namespace System.Collections.Concurrent
{
	// Token: 0x020004AC RID: 1196
	[FriendAccessAllowed]
	[EventSource(Name = "System.Collections.Concurrent.ConcurrentCollectionsEventSource", Guid = "35167F8E-49B2-4b96-AB86-435B59336B5E", LocalizationResources = "mscorlib")]
	internal sealed class CDSCollectionETWBCLProvider : EventSource
	{
		// Token: 0x06003923 RID: 14627 RVA: 0x000DAAF6 File Offset: 0x000D8CF6
		private CDSCollectionETWBCLProvider()
		{
		}

		// Token: 0x06003924 RID: 14628 RVA: 0x000DAAFE File Offset: 0x000D8CFE
		[Event(1, Level = EventLevel.Warning)]
		public void ConcurrentStack_FastPushFailed(int spinCount)
		{
			if (base.IsEnabled(EventLevel.Warning, EventKeywords.All))
			{
				base.WriteEvent(1, spinCount);
			}
		}

		// Token: 0x06003925 RID: 14629 RVA: 0x000DAB13 File Offset: 0x000D8D13
		[Event(2, Level = EventLevel.Warning)]
		public void ConcurrentStack_FastPopFailed(int spinCount)
		{
			if (base.IsEnabled(EventLevel.Warning, EventKeywords.All))
			{
				base.WriteEvent(2, spinCount);
			}
		}

		// Token: 0x06003926 RID: 14630 RVA: 0x000DAB28 File Offset: 0x000D8D28
		[Event(3, Level = EventLevel.Warning)]
		public void ConcurrentDictionary_AcquiringAllLocks(int numOfBuckets)
		{
			if (base.IsEnabled(EventLevel.Warning, EventKeywords.All))
			{
				base.WriteEvent(3, numOfBuckets);
			}
		}

		// Token: 0x06003927 RID: 14631 RVA: 0x000DAB3D File Offset: 0x000D8D3D
		[Event(4, Level = EventLevel.Verbose)]
		public void ConcurrentBag_TryTakeSteals()
		{
			if (base.IsEnabled(EventLevel.Verbose, EventKeywords.All))
			{
				base.WriteEvent(4);
			}
		}

		// Token: 0x06003928 RID: 14632 RVA: 0x000DAB51 File Offset: 0x000D8D51
		[Event(5, Level = EventLevel.Verbose)]
		public void ConcurrentBag_TryPeekSteals()
		{
			if (base.IsEnabled(EventLevel.Verbose, EventKeywords.All))
			{
				base.WriteEvent(5);
			}
		}

		// Token: 0x0400190D RID: 6413
		public static CDSCollectionETWBCLProvider Log = new CDSCollectionETWBCLProvider();

		// Token: 0x0400190E RID: 6414
		private const EventKeywords ALL_KEYWORDS = EventKeywords.All;

		// Token: 0x0400190F RID: 6415
		private const int CONCURRENTSTACK_FASTPUSHFAILED_ID = 1;

		// Token: 0x04001910 RID: 6416
		private const int CONCURRENTSTACK_FASTPOPFAILED_ID = 2;

		// Token: 0x04001911 RID: 6417
		private const int CONCURRENTDICTIONARY_ACQUIRINGALLLOCKS_ID = 3;

		// Token: 0x04001912 RID: 6418
		private const int CONCURRENTBAG_TRYTAKESTEALS_ID = 4;

		// Token: 0x04001913 RID: 6419
		private const int CONCURRENTBAG_TRYPEEKSTEALS_ID = 5;
	}
}
