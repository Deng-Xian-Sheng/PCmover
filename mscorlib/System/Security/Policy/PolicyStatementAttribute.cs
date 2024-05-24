using System;
using System.Runtime.InteropServices;

namespace System.Security.Policy
{
	// Token: 0x02000367 RID: 871
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum PolicyStatementAttribute
	{
		// Token: 0x0400118A RID: 4490
		Nothing = 0,
		// Token: 0x0400118B RID: 4491
		Exclusive = 1,
		// Token: 0x0400118C RID: 4492
		LevelFinal = 2,
		// Token: 0x0400118D RID: 4493
		All = 3
	}
}
