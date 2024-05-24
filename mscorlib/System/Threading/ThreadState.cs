using System;
using System.Runtime.InteropServices;

namespace System.Threading
{
	// Token: 0x02000528 RID: 1320
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum ThreadState
	{
		// Token: 0x04001A1D RID: 6685
		Running = 0,
		// Token: 0x04001A1E RID: 6686
		StopRequested = 1,
		// Token: 0x04001A1F RID: 6687
		SuspendRequested = 2,
		// Token: 0x04001A20 RID: 6688
		Background = 4,
		// Token: 0x04001A21 RID: 6689
		Unstarted = 8,
		// Token: 0x04001A22 RID: 6690
		Stopped = 16,
		// Token: 0x04001A23 RID: 6691
		WaitSleepJoin = 32,
		// Token: 0x04001A24 RID: 6692
		Suspended = 64,
		// Token: 0x04001A25 RID: 6693
		AbortRequested = 128,
		// Token: 0x04001A26 RID: 6694
		Aborted = 256
	}
}
