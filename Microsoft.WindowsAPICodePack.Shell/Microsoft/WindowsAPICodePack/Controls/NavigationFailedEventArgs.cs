using System;
using Microsoft.WindowsAPICodePack.Shell;

namespace Microsoft.WindowsAPICodePack.Controls
{
	// Token: 0x0200002F RID: 47
	public class NavigationFailedEventArgs : EventArgs
	{
		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000216 RID: 534 RVA: 0x00009C90 File Offset: 0x00007E90
		// (set) Token: 0x06000217 RID: 535 RVA: 0x00009CA7 File Offset: 0x00007EA7
		public ShellObject FailedLocation { get; set; }
	}
}
