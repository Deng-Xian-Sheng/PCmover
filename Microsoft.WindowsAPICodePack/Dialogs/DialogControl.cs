using System;
using System.Diagnostics;
using Microsoft.WindowsAPICodePack.Resources;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
	// Token: 0x0200000B RID: 11
	public abstract class DialogControl
	{
		// Token: 0x06000022 RID: 34 RVA: 0x0000242C File Offset: 0x0000062C
		protected DialogControl()
		{
			this.Id = DialogControl.nextId;
			if (DialogControl.nextId == 2147483647)
			{
				DialogControl.nextId = 9;
			}
			else
			{
				DialogControl.nextId++;
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x0000247A File Offset: 0x0000067A
		protected DialogControl(string name) : this()
		{
			this.Name = name;
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000024 RID: 36 RVA: 0x00002490 File Offset: 0x00000690
		// (set) Token: 0x06000025 RID: 37 RVA: 0x000024A7 File Offset: 0x000006A7
		public IDialogControlHost HostingDialog { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000026 RID: 38 RVA: 0x000024B0 File Offset: 0x000006B0
		// (set) Token: 0x06000027 RID: 39 RVA: 0x000024C8 File Offset: 0x000006C8
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentException(LocalizedMessages.DialogControlNameCannotBeEmpty);
				}
				if (!string.IsNullOrEmpty(this.name))
				{
					throw new InvalidOperationException(LocalizedMessages.DialogControlsCannotBeRenamed);
				}
				this.name = value;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000028 RID: 40 RVA: 0x00002514 File Offset: 0x00000714
		// (set) Token: 0x06000029 RID: 41 RVA: 0x0000252B File Offset: 0x0000072B
		public int Id { get; private set; }

		// Token: 0x0600002A RID: 42 RVA: 0x00002534 File Offset: 0x00000734
		protected void CheckPropertyChangeAllowed(string propName)
		{
			Debug.Assert(!string.IsNullOrEmpty(propName), "Property to change was not specified");
			if (this.HostingDialog != null)
			{
				this.HostingDialog.IsControlPropertyChangeAllowed(propName, this);
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002574 File Offset: 0x00000774
		protected void ApplyPropertyChange(string propName)
		{
			Debug.Assert(!string.IsNullOrEmpty(propName), "Property changed was not specified");
			if (this.HostingDialog != null)
			{
				this.HostingDialog.ApplyControlPropertyChange(propName, this);
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000025B4 File Offset: 0x000007B4
		public override bool Equals(object obj)
		{
			DialogControl dialogControl = obj as DialogControl;
			return dialogControl != null && this.Id == dialogControl.Id;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000025E8 File Offset: 0x000007E8
		public override int GetHashCode()
		{
			int hashCode;
			if (this.Name == null)
			{
				hashCode = this.ToString().GetHashCode();
			}
			else
			{
				hashCode = this.Name.GetHashCode();
			}
			return hashCode;
		}

		// Token: 0x040000DD RID: 221
		private static int nextId = 9;

		// Token: 0x040000DE RID: 222
		private string name;
	}
}
