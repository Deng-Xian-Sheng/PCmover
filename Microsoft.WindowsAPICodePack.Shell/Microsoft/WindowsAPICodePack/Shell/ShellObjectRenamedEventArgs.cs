using System;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x0200011A RID: 282
	public class ShellObjectRenamedEventArgs : ShellObjectChangedEventArgs
	{
		// Token: 0x170007B7 RID: 1975
		// (get) Token: 0x06000C4A RID: 3146 RVA: 0x0002EF90 File Offset: 0x0002D190
		// (set) Token: 0x06000C4B RID: 3147 RVA: 0x0002EFA7 File Offset: 0x0002D1A7
		public string NewPath { get; private set; }

		// Token: 0x06000C4C RID: 3148 RVA: 0x0002EFB0 File Offset: 0x0002D1B0
		internal ShellObjectRenamedEventArgs(ChangeNotifyLock notifyLock) : base(notifyLock)
		{
			this.NewPath = notifyLock.ItemName2;
		}
	}
}
