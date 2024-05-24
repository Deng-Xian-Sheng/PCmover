using System;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Threading
{
	// Token: 0x0200053B RID: 1339
	[FriendAccessAllowed]
	[EventSource(Name = "System.Threading.SynchronizationEventSource", Guid = "EC631D38-466B-4290-9306-834971BA0217", LocalizationResources = "mscorlib")]
	internal sealed class CdsSyncEtwBCLProvider : EventSource
	{
		// Token: 0x06003ED6 RID: 16086 RVA: 0x000E9D4D File Offset: 0x000E7F4D
		private CdsSyncEtwBCLProvider()
		{
		}

		// Token: 0x06003ED7 RID: 16087 RVA: 0x000E9D55 File Offset: 0x000E7F55
		[Event(1, Level = EventLevel.Warning)]
		public void SpinLock_FastPathFailed(int ownerID)
		{
			if (base.IsEnabled(EventLevel.Warning, EventKeywords.All))
			{
				base.WriteEvent(1, ownerID);
			}
		}

		// Token: 0x06003ED8 RID: 16088 RVA: 0x000E9D6A File Offset: 0x000E7F6A
		[Event(2, Level = EventLevel.Informational)]
		public void SpinWait_NextSpinWillYield()
		{
			if (base.IsEnabled(EventLevel.Informational, EventKeywords.All))
			{
				base.WriteEvent(2);
			}
		}

		// Token: 0x06003ED9 RID: 16089 RVA: 0x000E9D80 File Offset: 0x000E7F80
		[SecuritySafeCritical]
		[Event(3, Level = EventLevel.Verbose, Version = 1)]
		public unsafe void Barrier_PhaseFinished(bool currentSense, long phaseNum)
		{
			if (base.IsEnabled(EventLevel.Verbose, EventKeywords.All))
			{
				EventSource.EventData* ptr = stackalloc EventSource.EventData[checked(unchecked((UIntPtr)2) * (UIntPtr)sizeof(EventSource.EventData))];
				int num = currentSense ? 1 : 0;
				ptr->Size = 4;
				ptr->DataPointer = (IntPtr)((void*)(&num));
				ptr[1].Size = 8;
				ptr[1].DataPointer = (IntPtr)((void*)(&phaseNum));
				base.WriteEventCore(3, 2, ptr);
			}
		}

		// Token: 0x04001A66 RID: 6758
		public static CdsSyncEtwBCLProvider Log = new CdsSyncEtwBCLProvider();

		// Token: 0x04001A67 RID: 6759
		private const EventKeywords ALL_KEYWORDS = EventKeywords.All;

		// Token: 0x04001A68 RID: 6760
		private const int SPINLOCK_FASTPATHFAILED_ID = 1;

		// Token: 0x04001A69 RID: 6761
		private const int SPINWAIT_NEXTSPINWILLYIELD_ID = 2;

		// Token: 0x04001A6A RID: 6762
		private const int BARRIER_PHASEFINISHED_ID = 3;
	}
}
