using System;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000118 RID: 280
	public class ShellObjectNotificationEventArgs : EventArgs
	{
		// Token: 0x170007B4 RID: 1972
		// (get) Token: 0x06000C42 RID: 3138 RVA: 0x0002EEEC File Offset: 0x0002D0EC
		// (set) Token: 0x06000C43 RID: 3139 RVA: 0x0002EF03 File Offset: 0x0002D103
		public ShellObjectChangeTypes ChangeType { get; private set; }

		// Token: 0x170007B5 RID: 1973
		// (get) Token: 0x06000C44 RID: 3140 RVA: 0x0002EF0C File Offset: 0x0002D10C
		// (set) Token: 0x06000C45 RID: 3141 RVA: 0x0002EF23 File Offset: 0x0002D123
		public bool FromSystemInterrupt { get; private set; }

		// Token: 0x06000C46 RID: 3142 RVA: 0x0002EF2C File Offset: 0x0002D12C
		internal ShellObjectNotificationEventArgs(ChangeNotifyLock notifyLock)
		{
			this.ChangeType = notifyLock.ChangeType;
			this.FromSystemInterrupt = notifyLock.FromSystemInterrupt;
		}
	}
}
