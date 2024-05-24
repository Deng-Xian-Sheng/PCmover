using System;
using System.Diagnostics;

namespace Microsoft.WindowsAPICodePack.Dialogs.Controls
{
	// Token: 0x02000086 RID: 134
	public class CommonFileDialogLabel : CommonFileDialogControl
	{
		// Token: 0x06000497 RID: 1175 RVA: 0x000119A4 File Offset: 0x0000FBA4
		public CommonFileDialogLabel()
		{
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x000119AF File Offset: 0x0000FBAF
		public CommonFileDialogLabel(string text) : base(text)
		{
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x000119BB File Offset: 0x0000FBBB
		public CommonFileDialogLabel(string name, string text) : base(name, text)
		{
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x000119C8 File Offset: 0x0000FBC8
		internal override void Attach(IFileDialogCustomize dialog)
		{
			Debug.Assert(dialog != null, "CommonFileDialog.Attach: dialog parameter can not be null");
			dialog.AddText(base.Id, this.Text);
			this.SyncUnmanagedProperties();
		}
	}
}
