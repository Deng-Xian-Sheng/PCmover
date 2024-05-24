using System;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000119 RID: 281
	public class ShellObjectChangedEventArgs : ShellObjectNotificationEventArgs
	{
		// Token: 0x170007B6 RID: 1974
		// (get) Token: 0x06000C47 RID: 3143 RVA: 0x0002EF54 File Offset: 0x0002D154
		// (set) Token: 0x06000C48 RID: 3144 RVA: 0x0002EF6B File Offset: 0x0002D16B
		public string Path { get; private set; }

		// Token: 0x06000C49 RID: 3145 RVA: 0x0002EF74 File Offset: 0x0002D174
		internal ShellObjectChangedEventArgs(ChangeNotifyLock notifyLock) : base(notifyLock)
		{
			this.Path = notifyLock.ItemName;
		}
	}
}
