using System;
using System.Runtime.ConstrainedExecution;
using System.Security;
using System.Security.Permissions;

namespace System.Runtime
{
	// Token: 0x02000716 RID: 1814
	[__DynamicallyInvokable]
	public static class GCSettings
	{
		// Token: 0x17000D56 RID: 3414
		// (get) Token: 0x06005125 RID: 20773 RVA: 0x0011E51C File Offset: 0x0011C71C
		// (set) Token: 0x06005126 RID: 20774 RVA: 0x0011E523 File Offset: 0x0011C723
		[__DynamicallyInvokable]
		public static GCLatencyMode LatencyMode
		{
			[SecuritySafeCritical]
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
			[__DynamicallyInvokable]
			get
			{
				return (GCLatencyMode)GC.GetGCLatencyMode();
			}
			[SecurityCritical]
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
			[__DynamicallyInvokable]
			[HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
			set
			{
				if (value < GCLatencyMode.Batch || value > GCLatencyMode.SustainedLowLatency)
				{
					throw new ArgumentOutOfRangeException(Environment.GetResourceString("ArgumentOutOfRange_Enum"));
				}
				if (GC.SetGCLatencyMode((int)value) == 1)
				{
					throw new InvalidOperationException("The NoGCRegion mode is in progress. End it and then set a different mode.");
				}
			}
		}

		// Token: 0x17000D57 RID: 3415
		// (get) Token: 0x06005127 RID: 20775 RVA: 0x0011E551 File Offset: 0x0011C751
		// (set) Token: 0x06005128 RID: 20776 RVA: 0x0011E558 File Offset: 0x0011C758
		[__DynamicallyInvokable]
		public static GCLargeObjectHeapCompactionMode LargeObjectHeapCompactionMode
		{
			[SecuritySafeCritical]
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
			[__DynamicallyInvokable]
			get
			{
				return (GCLargeObjectHeapCompactionMode)GC.GetLOHCompactionMode();
			}
			[SecurityCritical]
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
			[__DynamicallyInvokable]
			[HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
			set
			{
				if (value < GCLargeObjectHeapCompactionMode.Default || value > GCLargeObjectHeapCompactionMode.CompactOnce)
				{
					throw new ArgumentOutOfRangeException(Environment.GetResourceString("ArgumentOutOfRange_Enum"));
				}
				GC.SetLOHCompactionMode((int)value);
			}
		}

		// Token: 0x17000D58 RID: 3416
		// (get) Token: 0x06005129 RID: 20777 RVA: 0x0011E578 File Offset: 0x0011C778
		[__DynamicallyInvokable]
		public static bool IsServerGC
		{
			[SecuritySafeCritical]
			[__DynamicallyInvokable]
			get
			{
				return GC.IsServerGC();
			}
		}

		// Token: 0x02000C61 RID: 3169
		private enum SetLatencyModeStatus
		{
			// Token: 0x040037B8 RID: 14264
			Succeeded,
			// Token: 0x040037B9 RID: 14265
			NoGCInProgress
		}
	}
}
