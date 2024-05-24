using System;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
	// Token: 0x02000057 RID: 87
	public class TaskDialogHyperlinkClickedEventArgs : EventArgs
	{
		// Token: 0x0600026C RID: 620 RVA: 0x00008D1B File Offset: 0x00006F1B
		public TaskDialogHyperlinkClickedEventArgs(string linkText)
		{
			this.LinkText = linkText;
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x0600026D RID: 621 RVA: 0x00008D30 File Offset: 0x00006F30
		// (set) Token: 0x0600026E RID: 622 RVA: 0x00008D47 File Offset: 0x00006F47
		public string LinkText { get; set; }
	}
}
