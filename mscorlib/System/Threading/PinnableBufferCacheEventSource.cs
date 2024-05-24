using System;
using System.Diagnostics.Tracing;
using System.Security;

namespace System.Threading
{
	// Token: 0x0200050E RID: 1294
	[EventSource(Name = "Microsoft-DotNETRuntime-PinnableBufferCache")]
	internal sealed class PinnableBufferCacheEventSource : EventSource
	{
		// Token: 0x06003CD4 RID: 15572 RVA: 0x000E5B74 File Offset: 0x000E3D74
		[Event(1, Level = EventLevel.Verbose)]
		public void DebugMessage(string message)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(1, message);
			}
		}

		// Token: 0x06003CD5 RID: 15573 RVA: 0x000E5B86 File Offset: 0x000E3D86
		[Event(2, Level = EventLevel.Verbose)]
		public void DebugMessage1(string message, long value)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(2, message, value);
			}
		}

		// Token: 0x06003CD6 RID: 15574 RVA: 0x000E5B99 File Offset: 0x000E3D99
		[Event(3, Level = EventLevel.Verbose)]
		public void DebugMessage2(string message, long value1, long value2)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(3, new object[]
				{
					message,
					value1,
					value2
				});
			}
		}

		// Token: 0x06003CD7 RID: 15575 RVA: 0x000E5BC6 File Offset: 0x000E3DC6
		[Event(18, Level = EventLevel.Verbose)]
		public void DebugMessage3(string message, long value1, long value2, long value3)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(18, new object[]
				{
					message,
					value1,
					value2,
					value3
				});
			}
		}

		// Token: 0x06003CD8 RID: 15576 RVA: 0x000E5BFE File Offset: 0x000E3DFE
		[Event(4)]
		public void Create(string cacheName)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(4, cacheName);
			}
		}

		// Token: 0x06003CD9 RID: 15577 RVA: 0x000E5C10 File Offset: 0x000E3E10
		[Event(5, Level = EventLevel.Verbose)]
		public void AllocateBuffer(string cacheName, ulong objectId, int objectHash, int objectGen, int freeCountAfter)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(5, new object[]
				{
					cacheName,
					objectId,
					objectHash,
					objectGen,
					freeCountAfter
				});
			}
		}

		// Token: 0x06003CDA RID: 15578 RVA: 0x000E5C5C File Offset: 0x000E3E5C
		[Event(6)]
		public void AllocateBufferFromNotGen2(string cacheName, int notGen2CountAfter)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(6, cacheName, notGen2CountAfter);
			}
		}

		// Token: 0x06003CDB RID: 15579 RVA: 0x000E5C6F File Offset: 0x000E3E6F
		[Event(7)]
		public void AllocateBufferCreatingNewBuffers(string cacheName, int totalBuffsBefore, int objectCount)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(7, cacheName, totalBuffsBefore, objectCount);
			}
		}

		// Token: 0x06003CDC RID: 15580 RVA: 0x000E5C83 File Offset: 0x000E3E83
		[Event(8)]
		public void AllocateBufferAged(string cacheName, int agedCount)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(8, cacheName, agedCount);
			}
		}

		// Token: 0x06003CDD RID: 15581 RVA: 0x000E5C96 File Offset: 0x000E3E96
		[Event(9)]
		public void AllocateBufferFreeListEmpty(string cacheName, int notGen2CountBefore)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(9, cacheName, notGen2CountBefore);
			}
		}

		// Token: 0x06003CDE RID: 15582 RVA: 0x000E5CAA File Offset: 0x000E3EAA
		[Event(10, Level = EventLevel.Verbose)]
		public void FreeBuffer(string cacheName, ulong objectId, int objectHash, int freeCountBefore)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(10, new object[]
				{
					cacheName,
					objectId,
					objectHash,
					freeCountBefore
				});
			}
		}

		// Token: 0x06003CDF RID: 15583 RVA: 0x000E5CE2 File Offset: 0x000E3EE2
		[Event(11)]
		public void FreeBufferStillTooYoung(string cacheName, int notGen2CountBefore)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(11, cacheName, notGen2CountBefore);
			}
		}

		// Token: 0x06003CE0 RID: 15584 RVA: 0x000E5CF6 File Offset: 0x000E3EF6
		[Event(13)]
		public void TrimCheck(string cacheName, int totalBuffs, bool neededMoreThanFreeList, int deltaMSec)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(13, new object[]
				{
					cacheName,
					totalBuffs,
					neededMoreThanFreeList,
					deltaMSec
				});
			}
		}

		// Token: 0x06003CE1 RID: 15585 RVA: 0x000E5D2E File Offset: 0x000E3F2E
		[Event(14)]
		public void TrimFree(string cacheName, int totalBuffs, int freeListCount, int toBeFreed)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(14, new object[]
				{
					cacheName,
					totalBuffs,
					freeListCount,
					toBeFreed
				});
			}
		}

		// Token: 0x06003CE2 RID: 15586 RVA: 0x000E5D66 File Offset: 0x000E3F66
		[Event(15)]
		public void TrimExperiment(string cacheName, int totalBuffs, int freeListCount, int numTrimTrial)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(15, new object[]
				{
					cacheName,
					totalBuffs,
					freeListCount,
					numTrimTrial
				});
			}
		}

		// Token: 0x06003CE3 RID: 15587 RVA: 0x000E5D9E File Offset: 0x000E3F9E
		[Event(16)]
		public void TrimFreeSizeOK(string cacheName, int totalBuffs, int freeListCount)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(16, cacheName, totalBuffs, freeListCount);
			}
		}

		// Token: 0x06003CE4 RID: 15588 RVA: 0x000E5DB3 File Offset: 0x000E3FB3
		[Event(17)]
		public void TrimFlush(string cacheName, int totalBuffs, int freeListCount, int notGen2CountBefore)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(17, new object[]
				{
					cacheName,
					totalBuffs,
					freeListCount,
					notGen2CountBefore
				});
			}
		}

		// Token: 0x06003CE5 RID: 15589 RVA: 0x000E5DEB File Offset: 0x000E3FEB
		[Event(20)]
		public void AgePendingBuffersResults(string cacheName, int promotedToFreeListCount, int heldBackCount)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(20, cacheName, promotedToFreeListCount, heldBackCount);
			}
		}

		// Token: 0x06003CE6 RID: 15590 RVA: 0x000E5E00 File Offset: 0x000E4000
		[Event(21)]
		public void WalkFreeListResult(string cacheName, int freeListCount, int gen0BuffersInFreeList)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(21, cacheName, freeListCount, gen0BuffersInFreeList);
			}
		}

		// Token: 0x06003CE7 RID: 15591 RVA: 0x000E5E15 File Offset: 0x000E4015
		[Event(22)]
		public void FreeBufferNull(string cacheName, int freeCountBefore)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(22, cacheName, freeCountBefore);
			}
		}

		// Token: 0x06003CE8 RID: 15592 RVA: 0x000E5E2C File Offset: 0x000E402C
		internal static ulong AddressOf(object obj)
		{
			byte[] array = obj as byte[];
			if (array != null)
			{
				return (ulong)PinnableBufferCacheEventSource.AddressOfByteArray(array);
			}
			return 0UL;
		}

		// Token: 0x06003CE9 RID: 15593 RVA: 0x000E5E4C File Offset: 0x000E404C
		[SecuritySafeCritical]
		internal unsafe static long AddressOfByteArray(byte[] array)
		{
			if (array == null)
			{
				return 0L;
			}
			byte* ptr;
			if (array == null || array.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = &array[0];
			}
			return ptr - 2 * sizeof(void*);
		}

		// Token: 0x040019D2 RID: 6610
		public static readonly PinnableBufferCacheEventSource Log = new PinnableBufferCacheEventSource();
	}
}
