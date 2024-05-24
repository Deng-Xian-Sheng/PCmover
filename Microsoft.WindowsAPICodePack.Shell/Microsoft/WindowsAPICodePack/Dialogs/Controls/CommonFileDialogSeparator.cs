using System;
using System.Diagnostics;

namespace Microsoft.WindowsAPICodePack.Dialogs.Controls
{
	// Token: 0x0200008C RID: 140
	public class CommonFileDialogSeparator : CommonFileDialogControl
	{
		// Token: 0x060004B7 RID: 1207 RVA: 0x00011F27 File Offset: 0x00010127
		internal override void Attach(IFileDialogCustomize dialog)
		{
			Debug.Assert(dialog != null, "CommonFileDialogSeparator.Attach: dialog parameter can not be null");
			dialog.AddSeparator(base.Id);
			this.SyncUnmanagedProperties();
		}
	}
}
