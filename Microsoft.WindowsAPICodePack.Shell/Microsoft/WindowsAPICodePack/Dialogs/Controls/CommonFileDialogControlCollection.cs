using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.WindowsAPICodePack.Shell.Resources;

namespace Microsoft.WindowsAPICodePack.Dialogs.Controls
{
	// Token: 0x02000081 RID: 129
	public sealed class CommonFileDialogControlCollection<T> : Collection<T> where T : DialogControl
	{
		// Token: 0x0600047B RID: 1147 RVA: 0x000111E1 File Offset: 0x0000F3E1
		internal CommonFileDialogControlCollection(IDialogControlHost host)
		{
			this.hostingDialog = host;
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x000111F4 File Offset: 0x0000F3F4
		protected override void InsertItem(int index, T control)
		{
			if (base.Items.Contains(control))
			{
				throw new InvalidOperationException(LocalizedMessages.DialogControlCollectionMoreThanOneControl);
			}
			if (control.HostingDialog != null)
			{
				throw new InvalidOperationException(LocalizedMessages.DialogControlCollectionRemoveControlFirst);
			}
			if (!this.hostingDialog.IsCollectionChangeAllowed())
			{
				throw new InvalidOperationException(LocalizedMessages.DialogControlCollectionModifyingControls);
			}
			if (control is CommonFileDialogMenuItem)
			{
				throw new InvalidOperationException(LocalizedMessages.DialogControlCollectionMenuItemControlsCannotBeAdded);
			}
			control.HostingDialog = this.hostingDialog;
			base.InsertItem(index, control);
			this.hostingDialog.ApplyCollectionChanged();
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x000112A6 File Offset: 0x0000F4A6
		protected override void RemoveItem(int index)
		{
			throw new NotSupportedException(LocalizedMessages.DialogControlCollectionCannotRemoveControls);
		}

		// Token: 0x17000162 RID: 354
		public T this[string name]
		{
			get
			{
				if (string.IsNullOrEmpty(name))
				{
					throw new ArgumentException(LocalizedMessages.DialogControlCollectionEmptyName, "name");
				}
				foreach (T t in base.Items)
				{
					if (t.Name == name)
					{
						return t;
					}
					CommonFileDialogGroupBox commonFileDialogGroupBox;
					if ((commonFileDialogGroupBox = (t as CommonFileDialogGroupBox)) != null)
					{
						foreach (DialogControl dialogControl in commonFileDialogGroupBox.Items)
						{
							T result = (T)((object)dialogControl);
							if (result.Name == name)
							{
								return result;
							}
						}
					}
				}
				return default(T);
			}
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x000113F4 File Offset: 0x0000F5F4
		internal DialogControl GetControlbyId(int id)
		{
			return this.GetSubControlbyId(base.Items.Cast<DialogControl>(), id);
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x00011418 File Offset: 0x0000F618
		internal DialogControl GetSubControlbyId(IEnumerable<DialogControl> controlCollection, int id)
		{
			DialogControl result;
			if (controlCollection == null)
			{
				result = null;
			}
			else
			{
				foreach (DialogControl dialogControl in controlCollection)
				{
					if (dialogControl.Id == id)
					{
						return dialogControl;
					}
					CommonFileDialogGroupBox commonFileDialogGroupBox = dialogControl as CommonFileDialogGroupBox;
					if (commonFileDialogGroupBox != null)
					{
						DialogControl subControlbyId = this.GetSubControlbyId(commonFileDialogGroupBox.Items, id);
						if (subControlbyId != null)
						{
							return subControlbyId;
						}
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x040002E7 RID: 743
		private IDialogControlHost hostingDialog;
	}
}
