using System;

namespace Microsoft.WindowsAPICodePack.Dialogs.Controls
{
	// Token: 0x0200007E RID: 126
	internal interface ICommonFileDialogIndexedControls
	{
		// Token: 0x1700015E RID: 350
		// (get) Token: 0x06000467 RID: 1127
		// (set) Token: 0x06000468 RID: 1128
		int SelectedIndex { get; set; }

		// Token: 0x14000015 RID: 21
		// (add) Token: 0x06000469 RID: 1129
		// (remove) Token: 0x0600046A RID: 1130
		event EventHandler SelectedIndexChanged;

		// Token: 0x0600046B RID: 1131
		void RaiseSelectedIndexChangedEvent();
	}
}
