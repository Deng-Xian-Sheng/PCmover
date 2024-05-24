using System;

namespace CefSharp.Structs
{
	// Token: 0x020000A7 RID: 167
	public struct Range
	{
		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x06000522 RID: 1314 RVA: 0x0000820C File Offset: 0x0000640C
		// (set) Token: 0x06000523 RID: 1315 RVA: 0x00008214 File Offset: 0x00006414
		public int From { get; private set; }

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x06000524 RID: 1316 RVA: 0x0000821D File Offset: 0x0000641D
		// (set) Token: 0x06000525 RID: 1317 RVA: 0x00008225 File Offset: 0x00006425
		public int To { get; private set; }

		// Token: 0x06000526 RID: 1318 RVA: 0x0000822E File Offset: 0x0000642E
		public Range(int from, int to)
		{
			this = default(Range);
			this.From = from;
			this.To = to;
		}
	}
}
