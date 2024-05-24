using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Markup;

namespace Microsoft.WindowsAPICodePack.Dialogs.Controls
{
	// Token: 0x02000085 RID: 133
	[ContentProperty("Items")]
	public class CommonFileDialogGroupBox : CommonFileDialogProminentControl
	{
		// Token: 0x17000167 RID: 359
		// (get) Token: 0x06000491 RID: 1169 RVA: 0x00011884 File Offset: 0x0000FA84
		public Collection<DialogControl> Items
		{
			get
			{
				return this.items;
			}
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x0001189C File Offset: 0x0000FA9C
		public CommonFileDialogGroupBox() : base(string.Empty)
		{
			this.Initialize();
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x000118B3 File Offset: 0x0000FAB3
		public CommonFileDialogGroupBox(string text) : base(text)
		{
			this.Initialize();
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x000118C6 File Offset: 0x0000FAC6
		public CommonFileDialogGroupBox(string name, string text) : base(name, text)
		{
			this.Initialize();
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x000118DA File Offset: 0x0000FADA
		private void Initialize()
		{
			this.items = new Collection<DialogControl>();
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x000118E8 File Offset: 0x0000FAE8
		internal override void Attach(IFileDialogCustomize dialog)
		{
			Debug.Assert(dialog != null, "CommonFileDialogGroupBox.Attach: dialog parameter can not be null");
			dialog.StartVisualGroup(base.Id, this.Text);
			foreach (DialogControl dialogControl in this.items)
			{
				CommonFileDialogControl commonFileDialogControl = (CommonFileDialogControl)dialogControl;
				commonFileDialogControl.HostingDialog = base.HostingDialog;
				commonFileDialogControl.Attach(dialog);
			}
			dialog.EndVisualGroup();
			if (base.IsProminent)
			{
				dialog.MakeProminent(base.Id);
			}
			this.SyncUnmanagedProperties();
		}

		// Token: 0x040002EC RID: 748
		private Collection<DialogControl> items;
	}
}
