using System;
using System.Diagnostics;

namespace Microsoft.WindowsAPICodePack.Dialogs.Controls
{
	// Token: 0x0200007C RID: 124
	public class CommonFileDialogButton : CommonFileDialogProminentControl
	{
		// Token: 0x0600044D RID: 1101 RVA: 0x00010AA5 File Offset: 0x0000ECA5
		public CommonFileDialogButton() : base(string.Empty)
		{
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x00010ADD File Offset: 0x0000ECDD
		public CommonFileDialogButton(string text) : base(text)
		{
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x00010B11 File Offset: 0x0000ED11
		public CommonFileDialogButton(string name, string text) : base(name, text)
		{
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x00010B44 File Offset: 0x0000ED44
		internal override void Attach(IFileDialogCustomize dialog)
		{
			Debug.Assert(dialog != null, "CommonFileDialogButton.Attach: dialog parameter can not be null");
			dialog.AddPushButton(base.Id, this.Text);
			if (base.IsProminent)
			{
				dialog.MakeProminent(base.Id);
			}
			this.SyncUnmanagedProperties();
		}

		// Token: 0x14000013 RID: 19
		// (add) Token: 0x06000451 RID: 1105 RVA: 0x00010B9C File Offset: 0x0000ED9C
		// (remove) Token: 0x06000452 RID: 1106 RVA: 0x00010BD8 File Offset: 0x0000EDD8
		public event EventHandler Click = delegate(object param0, EventArgs param1)
		{
		};

		// Token: 0x06000453 RID: 1107 RVA: 0x00010C14 File Offset: 0x0000EE14
		internal void RaiseClickEvent()
		{
			if (base.Enabled)
			{
				this.Click(this, EventArgs.Empty);
			}
		}
	}
}
