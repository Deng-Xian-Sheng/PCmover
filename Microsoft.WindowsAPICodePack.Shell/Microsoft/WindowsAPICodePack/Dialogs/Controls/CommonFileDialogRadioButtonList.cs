using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Markup;
using Microsoft.WindowsAPICodePack.Shell.Resources;

namespace Microsoft.WindowsAPICodePack.Dialogs.Controls
{
	// Token: 0x02000089 RID: 137
	[ContentProperty("Items")]
	public class CommonFileDialogRadioButtonList : CommonFileDialogControl, ICommonFileDialogIndexedControls
	{
		// Token: 0x17000169 RID: 361
		// (get) Token: 0x060004A8 RID: 1192 RVA: 0x00011C20 File Offset: 0x0000FE20
		public Collection<CommonFileDialogRadioButtonListItem> Items
		{
			get
			{
				return this.items;
			}
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x00011C3C File Offset: 0x0000FE3C
		public CommonFileDialogRadioButtonList()
		{
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x00011C8C File Offset: 0x0000FE8C
		public CommonFileDialogRadioButtonList(string name) : base(name, string.Empty)
		{
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x060004AB RID: 1195 RVA: 0x00011CE0 File Offset: 0x0000FEE0
		// (set) Token: 0x060004AC RID: 1196 RVA: 0x00011CF8 File Offset: 0x0000FEF8
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
							throw new IndexOutOfRangeException(LocalizedMessages.RadioButtonListIndexOutOfBounds);
						}
						this.selectedIndex = value;
						base.ApplyPropertyChange("SelectedIndex");
					}
				}
			}
		}

		// Token: 0x14000018 RID: 24
		// (add) Token: 0x060004AD RID: 1197 RVA: 0x00011D74 File Offset: 0x0000FF74
		// (remove) Token: 0x060004AE RID: 1198 RVA: 0x00011DB0 File Offset: 0x0000FFB0
		public event EventHandler SelectedIndexChanged = delegate(object param0, EventArgs param1)
		{
		};

		// Token: 0x060004AF RID: 1199 RVA: 0x00011DEC File Offset: 0x0000FFEC
		void ICommonFileDialogIndexedControls.RaiseSelectedIndexChangedEvent()
		{
			if (base.Enabled)
			{
				this.SelectedIndexChanged(this, EventArgs.Empty);
			}
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x00011E1C File Offset: 0x0001001C
		internal override void Attach(IFileDialogCustomize dialog)
		{
			Debug.Assert(dialog != null, "CommonFileDialogRadioButtonList.Attach: dialog parameter can not be null");
			dialog.AddRadioButtonList(base.Id);
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
				throw new IndexOutOfRangeException(LocalizedMessages.RadioButtonListIndexOutOfBounds);
			}
			this.SyncUnmanagedProperties();
		}

		// Token: 0x040002F1 RID: 753
		private Collection<CommonFileDialogRadioButtonListItem> items = new Collection<CommonFileDialogRadioButtonListItem>();

		// Token: 0x040002F2 RID: 754
		private int selectedIndex = -1;
	}
}
