using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Markup;

namespace Microsoft.WindowsAPICodePack.Dialogs.Controls
{
	// Token: 0x02000087 RID: 135
	[ContentProperty("Items")]
	public class CommonFileDialogMenu : CommonFileDialogProminentControl
	{
		// Token: 0x17000168 RID: 360
		// (get) Token: 0x0600049B RID: 1179 RVA: 0x000119F8 File Offset: 0x0000FBF8
		public Collection<CommonFileDialogMenuItem> Items
		{
			get
			{
				return this.items;
			}
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x00011A10 File Offset: 0x0000FC10
		public CommonFileDialogMenu()
		{
		}

		// Token: 0x0600049D RID: 1181 RVA: 0x00011A26 File Offset: 0x0000FC26
		public CommonFileDialogMenu(string text) : base(text)
		{
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x00011A3D File Offset: 0x0000FC3D
		public CommonFileDialogMenu(string name, string text) : base(name, text)
		{
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x00011A58 File Offset: 0x0000FC58
		internal override void Attach(IFileDialogCustomize dialog)
		{
			Debug.Assert(dialog != null, "CommonFileDialogMenu.Attach: dialog parameter can not be null");
			dialog.AddMenu(base.Id, this.Text);
			foreach (CommonFileDialogMenuItem commonFileDialogMenuItem in this.items)
			{
				dialog.AddControlItem(base.Id, commonFileDialogMenuItem.Id, commonFileDialogMenuItem.Text);
			}
			if (base.IsProminent)
			{
				dialog.MakeProminent(base.Id);
			}
			this.SyncUnmanagedProperties();
		}

		// Token: 0x040002ED RID: 749
		private Collection<CommonFileDialogMenuItem> items = new Collection<CommonFileDialogMenuItem>();
	}
}
