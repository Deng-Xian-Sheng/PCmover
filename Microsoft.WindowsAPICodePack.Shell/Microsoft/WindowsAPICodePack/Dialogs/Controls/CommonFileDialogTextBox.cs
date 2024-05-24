using System;
using System.Diagnostics;

namespace Microsoft.WindowsAPICodePack.Dialogs.Controls
{
	// Token: 0x0200008E RID: 142
	public class CommonFileDialogTextBox : CommonFileDialogControl
	{
		// Token: 0x060004BC RID: 1212 RVA: 0x0001200C File Offset: 0x0001020C
		public CommonFileDialogTextBox() : base(string.Empty)
		{
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x0001201C File Offset: 0x0001021C
		public CommonFileDialogTextBox(string text) : base(text)
		{
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x00012028 File Offset: 0x00010228
		public CommonFileDialogTextBox(string name, string text) : base(name, text)
		{
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x060004BF RID: 1215 RVA: 0x00012038 File Offset: 0x00010238
		// (set) Token: 0x060004C0 RID: 1216 RVA: 0x0001204F File Offset: 0x0001024F
		internal bool Closed { get; set; }

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x060004C1 RID: 1217 RVA: 0x00012058 File Offset: 0x00010258
		// (set) Token: 0x060004C2 RID: 1218 RVA: 0x00012084 File Offset: 0x00010284
		public override string Text
		{
			get
			{
				if (!this.Closed)
				{
					this.SyncValue();
				}
				return base.Text;
			}
			set
			{
				if (this.customizedDialog != null)
				{
					this.customizedDialog.SetEditBoxText(base.Id, value);
				}
				base.Text = value;
			}
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x000120BC File Offset: 0x000102BC
		internal override void Attach(IFileDialogCustomize dialog)
		{
			Debug.Assert(dialog != null, "CommonFileDialogTextBox.Attach: dialog parameter can not be null");
			dialog.AddEditBox(base.Id, this.Text);
			this.customizedDialog = dialog;
			this.SyncUnmanagedProperties();
			this.Closed = false;
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x000120FC File Offset: 0x000102FC
		internal void SyncValue()
		{
			if (this.customizedDialog != null)
			{
				string text;
				this.customizedDialog.GetEditBoxText(base.Id, out text);
				base.Text = text;
			}
		}

		// Token: 0x040002FE RID: 766
		private IFileDialogCustomize customizedDialog;
	}
}
