using System;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x0200011B RID: 283
	public class SystemImageUpdatedEventArgs : ShellObjectNotificationEventArgs
	{
		// Token: 0x170007B8 RID: 1976
		// (get) Token: 0x06000C4D RID: 3149 RVA: 0x0002EFCC File Offset: 0x0002D1CC
		// (set) Token: 0x06000C4E RID: 3150 RVA: 0x0002EFE3 File Offset: 0x0002D1E3
		public int ImageIndex { get; private set; }

		// Token: 0x06000C4F RID: 3151 RVA: 0x0002EFEC File Offset: 0x0002D1EC
		internal SystemImageUpdatedEventArgs(ChangeNotifyLock notifyLock) : base(notifyLock)
		{
			this.ImageIndex = notifyLock.ImageIndex;
		}
	}
}
