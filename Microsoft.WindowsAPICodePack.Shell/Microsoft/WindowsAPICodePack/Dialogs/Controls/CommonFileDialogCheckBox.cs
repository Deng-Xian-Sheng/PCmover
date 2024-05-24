using System;
using System.Diagnostics;

namespace Microsoft.WindowsAPICodePack.Dialogs.Controls
{
	// Token: 0x0200007D RID: 125
	public class CommonFileDialogCheckBox : CommonFileDialogProminentControl
	{
		// Token: 0x1700015D RID: 349
		// (get) Token: 0x06000457 RID: 1111 RVA: 0x00010C44 File Offset: 0x0000EE44
		// (set) Token: 0x06000458 RID: 1112 RVA: 0x00010C5C File Offset: 0x0000EE5C
		public bool IsChecked
		{
			get
			{
				return this.isChecked;
			}
			set
			{
				if (this.isChecked != value)
				{
					this.isChecked = value;
					base.ApplyPropertyChange("IsChecked");
				}
			}
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x00010C8F File Offset: 0x0000EE8F
		public CommonFileDialogCheckBox()
		{
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x00010CC2 File Offset: 0x0000EEC2
		public CommonFileDialogCheckBox(string text) : base(text)
		{
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x00010CF6 File Offset: 0x0000EEF6
		public CommonFileDialogCheckBox(string name, string text) : base(name, text)
		{
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x00010D2B File Offset: 0x0000EF2B
		public CommonFileDialogCheckBox(string text, bool isChecked) : base(text)
		{
			this.isChecked = isChecked;
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x00010D66 File Offset: 0x0000EF66
		public CommonFileDialogCheckBox(string name, string text, bool isChecked) : base(name, text)
		{
			this.isChecked = isChecked;
		}

		// Token: 0x14000014 RID: 20
		// (add) Token: 0x0600045E RID: 1118 RVA: 0x00010DA0 File Offset: 0x0000EFA0
		// (remove) Token: 0x0600045F RID: 1119 RVA: 0x00010DDC File Offset: 0x0000EFDC
		public event EventHandler CheckedChanged = delegate(object param0, EventArgs param1)
		{
		};

		// Token: 0x06000460 RID: 1120 RVA: 0x00010E18 File Offset: 0x0000F018
		internal void RaiseCheckedChangedEvent()
		{
			if (base.Enabled)
			{
				this.CheckedChanged(this, EventArgs.Empty);
			}
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x00010E48 File Offset: 0x0000F048
		internal override void Attach(IFileDialogCustomize dialog)
		{
			Debug.Assert(dialog != null, "CommonFileDialogCheckBox.Attach: dialog parameter can not be null");
			dialog.AddCheckButton(base.Id, this.Text, this.isChecked);
			if (base.IsProminent)
			{
				dialog.MakeProminent(base.Id);
			}
			base.ApplyPropertyChange("IsChecked");
			this.SyncUnmanagedProperties();
		}

		// Token: 0x040002DA RID: 730
		private bool isChecked;
	}
}
