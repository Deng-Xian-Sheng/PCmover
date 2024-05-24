using System;
using Microsoft.WindowsAPICodePack.Shell;

namespace Microsoft.WindowsAPICodePack.Controls
{
	// Token: 0x0200002D RID: 45
	public class NavigationPendingEventArgs : EventArgs
	{
		// Token: 0x17000081 RID: 129
		// (get) Token: 0x0600020E RID: 526 RVA: 0x00009C20 File Offset: 0x00007E20
		// (set) Token: 0x0600020F RID: 527 RVA: 0x00009C37 File Offset: 0x00007E37
		public ShellObject PendingLocation { get; set; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000210 RID: 528 RVA: 0x00009C40 File Offset: 0x00007E40
		// (set) Token: 0x06000211 RID: 529 RVA: 0x00009C57 File Offset: 0x00007E57
		public bool Cancel { get; set; }
	}
}
