using System;
using Microsoft.WindowsAPICodePack.Shell;

namespace Microsoft.WindowsAPICodePack.Controls
{
	// Token: 0x02000032 RID: 50
	internal class PendingNavigation
	{
		// Token: 0x06000231 RID: 561 RVA: 0x0000A56D File Offset: 0x0000876D
		internal PendingNavigation(ShellObject location, int index)
		{
			this.Location = location;
			this.Index = index;
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000232 RID: 562 RVA: 0x0000A588 File Offset: 0x00008788
		// (set) Token: 0x06000233 RID: 563 RVA: 0x0000A59F File Offset: 0x0000879F
		internal ShellObject Location { get; set; }

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000234 RID: 564 RVA: 0x0000A5A8 File Offset: 0x000087A8
		// (set) Token: 0x06000235 RID: 565 RVA: 0x0000A5BF File Offset: 0x000087BF
		internal int Index { get; set; }
	}
}
