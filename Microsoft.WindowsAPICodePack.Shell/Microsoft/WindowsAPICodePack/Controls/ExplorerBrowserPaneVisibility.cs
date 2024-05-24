using System;

namespace Microsoft.WindowsAPICodePack.Controls
{
	// Token: 0x02000037 RID: 55
	public class ExplorerBrowserPaneVisibility
	{
		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000236 RID: 566 RVA: 0x0000A5C8 File Offset: 0x000087C8
		// (set) Token: 0x06000237 RID: 567 RVA: 0x0000A5DF File Offset: 0x000087DF
		public PaneVisibilityState Navigation { get; set; }

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000238 RID: 568 RVA: 0x0000A5E8 File Offset: 0x000087E8
		// (set) Token: 0x06000239 RID: 569 RVA: 0x0000A5FF File Offset: 0x000087FF
		public PaneVisibilityState Commands { get; set; }

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x0600023A RID: 570 RVA: 0x0000A608 File Offset: 0x00008808
		// (set) Token: 0x0600023B RID: 571 RVA: 0x0000A61F File Offset: 0x0000881F
		public PaneVisibilityState CommandsOrganize { get; set; }

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x0600023C RID: 572 RVA: 0x0000A628 File Offset: 0x00008828
		// (set) Token: 0x0600023D RID: 573 RVA: 0x0000A63F File Offset: 0x0000883F
		public PaneVisibilityState CommandsView { get; set; }

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x0600023E RID: 574 RVA: 0x0000A648 File Offset: 0x00008848
		// (set) Token: 0x0600023F RID: 575 RVA: 0x0000A65F File Offset: 0x0000885F
		public PaneVisibilityState Details { get; set; }

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000240 RID: 576 RVA: 0x0000A668 File Offset: 0x00008868
		// (set) Token: 0x06000241 RID: 577 RVA: 0x0000A67F File Offset: 0x0000887F
		public PaneVisibilityState Preview { get; set; }

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000242 RID: 578 RVA: 0x0000A688 File Offset: 0x00008888
		// (set) Token: 0x06000243 RID: 579 RVA: 0x0000A69F File Offset: 0x0000889F
		public PaneVisibilityState Query { get; set; }

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000244 RID: 580 RVA: 0x0000A6A8 File Offset: 0x000088A8
		// (set) Token: 0x06000245 RID: 581 RVA: 0x0000A6BF File Offset: 0x000088BF
		public PaneVisibilityState AdvancedQuery { get; set; }
	}
}
