using System;
using System.ComponentModel;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
	// Token: 0x02000053 RID: 83
	public class TaskDialogClosingEventArgs : CancelEventArgs
	{
		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x0600025E RID: 606 RVA: 0x00008BBC File Offset: 0x00006DBC
		// (set) Token: 0x0600025F RID: 607 RVA: 0x00008BD4 File Offset: 0x00006DD4
		public TaskDialogResult TaskDialogResult
		{
			get
			{
				return this.taskDialogResult;
			}
			set
			{
				this.taskDialogResult = value;
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06000260 RID: 608 RVA: 0x00008BE0 File Offset: 0x00006DE0
		// (set) Token: 0x06000261 RID: 609 RVA: 0x00008BF8 File Offset: 0x00006DF8
		public string CustomButton
		{
			get
			{
				return this.customButton;
			}
			set
			{
				this.customButton = value;
			}
		}

		// Token: 0x04000292 RID: 658
		private TaskDialogResult taskDialogResult;

		// Token: 0x04000293 RID: 659
		private string customButton;
	}
}
