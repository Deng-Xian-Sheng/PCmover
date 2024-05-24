using System;

namespace ClientEngineModule.Scr
{
	// Token: 0x02000004 RID: 4
	public class PollItem
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000005 RID: 5 RVA: 0x00002084 File Offset: 0x00000284
		// (set) Token: 0x06000006 RID: 6 RVA: 0x0000208C File Offset: 0x0000028C
		public bool Enabled { get; set; } = true;

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000007 RID: 7 RVA: 0x00002095 File Offset: 0x00000295
		// (set) Token: 0x06000008 RID: 8 RVA: 0x0000209D File Offset: 0x0000029D
		public PollItemName Name { get; set; }
	}
}
