using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Markup;
using Microsoft.WindowsAPICodePack.Shell.Resources;

namespace Microsoft.WindowsAPICodePack.Dialogs.Controls
{
	// Token: 0x0200007F RID: 127
	[ContentProperty("Items")]
	public class CommonFileDialogComboBox : CommonFileDialogProminentControl, ICommonFileDialogIndexedControls
	{
		// Token: 0x1700015F RID: 351
		// (get) Token: 0x0600046C RID: 1132 RVA: 0x00010EB0 File Offset: 0x0000F0B0
		public Collection<CommonFileDialogComboBoxItem> Items
		{
			get
			{
				return this.items;
			}
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x00010ECC File Offset: 0x0000F0CC
		public CommonFileDialogComboBox()
		{
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x00010F1C File Offset: 0x0000F11C
		public CommonFileDialogComboBox(string name) : base(name, string.Empty)
		{
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x0600046F RID: 1135 RVA: 0x00010F70 File Offset: 0x0000F170
		// (set) Token: 0x06000470 RID: 1136 RVA: 0x00010F88 File Offset: 0x0000F188
		public int SelectedIndex
		{
			get
			{
				return this.selectedIndex;
			}
			set
			{
				if (this.selectedIndex != value)
				{
					if (base.HostingDialog == null)
					{
						this.selectedIndex = value;
					}
					else
					{
						if (value < 0 || value >= this.items.Count)
						{
							throw new IndexOutOfRangeException(LocalizedMessages.ComboBoxIndexOutsideBounds);
						}
						this.selectedIndex = value;
						base.ApplyPropertyChange("SelectedIndex");
					}
				}
			}
		}

		// Token: 0x14000016 RID: 22
		// (add) Token: 0x06000471 RID: 1137 RVA: 0x00011004 File Offset: 0x0000F204
		// (remove) Token: 0x06000472 RID: 1138 RVA: 0x00011040 File Offset: 0x0000F240
		public event EventHandler SelectedIndexChanged = delegate(object param0, EventArgs param1)
		{
		};

		// Token: 0x06000473 RID: 1139 RVA: 0x0001107C File Offset: 0x0000F27C
		void ICommonFileDialogIndexedControls.RaiseSelectedIndexChangedEvent()
		{
			if (base.Enabled)
			{
				this.SelectedIndexChanged(this, EventArgs.Empty);
			}
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x000110AC File Offset: 0x0000F2AC
		internal override void Attach(IFileDialogCustomize dialog)
		{
			Debug.Assert(dialog != null, "CommonFileDialogComboBox.Attach: dialog parameter can not be null");
			dialog.AddComboBox(base.Id);
			for (int i = 0; i < this.items.Count; i++)
			{
				dialog.AddControlItem(base.Id, i, this.items[i].Text);
			}
			if (this.selectedIndex >= 0 && this.selectedIndex < this.items.Count)
			{
				dialog.SetSelectedControlItem(base.Id, this.selectedIndex);
			}
			else if (this.selectedIndex != -1)
			{
				throw new IndexOutOfRangeException(LocalizedMessages.ComboBoxIndexOutsideBounds);
			}
			if (base.IsProminent)
			{
				dialog.MakeProminent(base.Id);
			}
			this.SyncUnmanagedProperties();
		}

		// Token: 0x040002E1 RID: 737
		private readonly Collection<CommonFileDialogComboBoxItem> items = new Collection<CommonFileDialogComboBoxItem>();

		// Token: 0x040002E2 RID: 738
		private int selectedIndex = -1;
	}
}
