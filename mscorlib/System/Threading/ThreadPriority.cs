using System;
using System.Runtime.InteropServices;

namespace System.Threading
{
	// Token: 0x02000526 RID: 1318
	[ComVisible(true)]
	[Serializable]
	public enum ThreadPriority
	{
		// Token: 0x04001A17 RID: 6679
		Lowest,
		// Token: 0x04001A18 RID: 6680
		BelowNormal,
		// Token: 0x04001A19 RID: 6681
		Normal,
		// Token: 0x04001A1A RID: 6682
		AboveNormal,
		// Token: 0x04001A1B RID: 6683
		Highest
	}
}
