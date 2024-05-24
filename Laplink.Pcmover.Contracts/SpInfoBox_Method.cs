using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000039 RID: 57
	[Flags]
	public enum SpInfoBox_Method
	{
		// Token: 0x04000162 RID: 354
		SIBM_NONE = 0,
		// Token: 0x04000163 RID: 355
		SIBM_POPUP = 1,
		// Token: 0x04000164 RID: 356
		SIBM_FILE = 2,
		// Token: 0x04000165 RID: 357
		SIBM_TRACE = 4,
		// Token: 0x04000166 RID: 358
		SIBM_EVENTLOG = 8,
		// Token: 0x04000167 RID: 359
		SIBM_CSV = 16,
		// Token: 0x04000168 RID: 360
		SIBM_THREAD = 32
	}
}
