using System;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
	// Token: 0x0200005F RID: 95
	public class TaskDialogTickEventArgs : EventArgs
	{
		// Token: 0x0600027C RID: 636 RVA: 0x00008F63 File Offset: 0x00007163
		public TaskDialogTickEventArgs(int ticks)
		{
			this.Ticks = ticks;
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x0600027D RID: 637 RVA: 0x00008F78 File Offset: 0x00007178
		// (set) Token: 0x0600027E RID: 638 RVA: 0x00008F8F File Offset: 0x0000718F
		public int Ticks { get; private set; }
	}
}
