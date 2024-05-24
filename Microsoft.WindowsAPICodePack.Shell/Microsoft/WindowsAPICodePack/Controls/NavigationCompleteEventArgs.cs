using System;
using Microsoft.WindowsAPICodePack.Shell;

namespace Microsoft.WindowsAPICodePack.Controls
{
	// Token: 0x0200002E RID: 46
	public class NavigationCompleteEventArgs : EventArgs
	{
		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000213 RID: 531 RVA: 0x00009C68 File Offset: 0x00007E68
		// (set) Token: 0x06000214 RID: 532 RVA: 0x00009C7F File Offset: 0x00007E7F
		public ShellObject NewLocation { get; set; }
	}
}
