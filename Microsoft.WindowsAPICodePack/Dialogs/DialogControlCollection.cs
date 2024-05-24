using System;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.WindowsAPICodePack.Resources;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
	// Token: 0x0200000C RID: 12
	public sealed class DialogControlCollection<T> : Collection<T> where T : DialogControl
	{
		// Token: 0x0600002F RID: 47 RVA: 0x0000262D File Offset: 0x0000082D
		internal DialogControlCollection(IDialogControlHost host)
		{
			this.hostingDialog = host;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002640 File Offset: 0x00000840
		protected override void InsertItem(int index, T control)
		{
			if (base.Items.Contains(control))
			{
				throw new InvalidOperationException(LocalizedMessages.DialogCollectionCannotHaveDuplicateNames);
			}
			if (control.HostingDialog != null)
			{
				throw new InvalidOperationException(LocalizedMessages.DialogCollectionControlAlreadyHosted);
			}
			if (!this.hostingDialog.IsCollectionChangeAllowed())
			{
				throw new InvalidOperationException(LocalizedMessages.DialogCollectionModifyShowingDialog);
			}
			control.HostingDialog = this.hostingDialog;
			base.InsertItem(index, control);
			this.hostingDialog.ApplyCollectionChanged();
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000026D4 File Offset: 0x000008D4
		protected override void RemoveItem(int index)
		{
			if (!this.hostingDialog.IsCollectionChangeAllowed())
			{
				throw new InvalidOperationException(LocalizedMessages.DialogCollectionModifyShowingDialog);
			}
			DialogControl dialogControl = base.Items[index];
			dialogControl.HostingDialog = null;
			base.RemoveItem(index);
			this.hostingDialog.ApplyCollectionChanged();
		}

		// Token: 0x1700000A RID: 10
		public T this[string name]
		{
			get
			{
				if (string.IsNullOrEmpty(name))
				{
					throw new ArgumentException(LocalizedMessages.DialogCollectionControlNameNull, "name");
				}
				return base.Items.FirstOrDefault((T x) => x.Name == name);
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000027EC File Offset: 0x000009EC
		internal DialogControl GetControlbyId(int id)
		{
			return base.Items.FirstOrDefault((T x) => x.Id == id);
		}

		// Token: 0x040000E1 RID: 225
		private IDialogControlHost hostingDialog;
	}
}
