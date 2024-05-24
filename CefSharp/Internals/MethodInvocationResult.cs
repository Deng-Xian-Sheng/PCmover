using System;
using CefSharp.JavascriptBinding;

namespace CefSharp.Internals
{
	// Token: 0x020000DF RID: 223
	public sealed class MethodInvocationResult
	{
		// Token: 0x1700020D RID: 525
		// (get) Token: 0x060006BF RID: 1727 RVA: 0x0000AFEA File Offset: 0x000091EA
		// (set) Token: 0x060006C0 RID: 1728 RVA: 0x0000AFF2 File Offset: 0x000091F2
		public int BrowserId { get; set; }

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x060006C1 RID: 1729 RVA: 0x0000AFFB File Offset: 0x000091FB
		// (set) Token: 0x060006C2 RID: 1730 RVA: 0x0000B003 File Offset: 0x00009203
		public long? CallbackId { get; set; }

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x060006C3 RID: 1731 RVA: 0x0000B00C File Offset: 0x0000920C
		// (set) Token: 0x060006C4 RID: 1732 RVA: 0x0000B014 File Offset: 0x00009214
		public long FrameId { get; set; }

		// Token: 0x17000210 RID: 528
		// (get) Token: 0x060006C5 RID: 1733 RVA: 0x0000B01D File Offset: 0x0000921D
		// (set) Token: 0x060006C6 RID: 1734 RVA: 0x0000B025 File Offset: 0x00009225
		public string Message { get; set; }

		// Token: 0x17000211 RID: 529
		// (get) Token: 0x060006C7 RID: 1735 RVA: 0x0000B02E File Offset: 0x0000922E
		// (set) Token: 0x060006C8 RID: 1736 RVA: 0x0000B036 File Offset: 0x00009236
		public bool Success { get; set; }

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x060006C9 RID: 1737 RVA: 0x0000B03F File Offset: 0x0000923F
		// (set) Token: 0x060006CA RID: 1738 RVA: 0x0000B047 File Offset: 0x00009247
		public object Result { get; set; }

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x060006CB RID: 1739 RVA: 0x0000B050 File Offset: 0x00009250
		// (set) Token: 0x060006CC RID: 1740 RVA: 0x0000B058 File Offset: 0x00009258
		public IJavascriptNameConverter NameConverter { get; set; }
	}
}
