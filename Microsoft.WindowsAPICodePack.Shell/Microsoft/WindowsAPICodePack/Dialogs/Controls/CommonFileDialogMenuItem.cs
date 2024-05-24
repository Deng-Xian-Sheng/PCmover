using System;

namespace Microsoft.WindowsAPICodePack.Dialogs.Controls
{
	// Token: 0x02000088 RID: 136
	public class CommonFileDialogMenuItem : CommonFileDialogControl
	{
		// Token: 0x060004A0 RID: 1184 RVA: 0x00011B0B File Offset: 0x0000FD0B
		public CommonFileDialogMenuItem() : base(string.Empty)
		{
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x00011B43 File Offset: 0x0000FD43
		public CommonFileDialogMenuItem(string text) : base(text)
		{
		}

		// Token: 0x14000017 RID: 23
		// (add) Token: 0x060004A2 RID: 1186 RVA: 0x00011B74 File Offset: 0x0000FD74
		// (remove) Token: 0x060004A3 RID: 1187 RVA: 0x00011BB0 File Offset: 0x0000FDB0
		public event EventHandler Click = delegate(object param0, EventArgs param1)
		{
		};

		// Token: 0x060004A4 RID: 1188 RVA: 0x00011BEC File Offset: 0x0000FDEC
		internal void RaiseClickEvent()
		{
			if (base.Enabled)
			{
				this.Click(this, EventArgs.Empty);
			}
		}

		// Token: 0x060004A5 RID: 1189 RVA: 0x00011C1B File Offset: 0x0000FE1B
		internal override void Attach(IFileDialogCustomize dialog)
		{
		}
	}
}
