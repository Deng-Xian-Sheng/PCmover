using System;

namespace Microsoft.WindowsAPICodePack.Dialogs.Controls
{
	// Token: 0x0200007A RID: 122
	public abstract class CommonFileDialogControl : DialogControl
	{
		// Token: 0x17000158 RID: 344
		// (get) Token: 0x0600043B RID: 1083 RVA: 0x000108DC File Offset: 0x0000EADC
		// (set) Token: 0x0600043C RID: 1084 RVA: 0x000108F4 File Offset: 0x0000EAF4
		public virtual string Text
		{
			get
			{
				return this.textValue;
			}
			set
			{
				if (value != this.textValue)
				{
					this.textValue = value;
					base.ApplyPropertyChange("Text");
				}
			}
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x0600043D RID: 1085 RVA: 0x0001092C File Offset: 0x0000EB2C
		// (set) Token: 0x0600043E RID: 1086 RVA: 0x00010944 File Offset: 0x0000EB44
		public bool Enabled
		{
			get
			{
				return this.enabled;
			}
			set
			{
				if (value != this.enabled)
				{
					this.enabled = value;
					base.ApplyPropertyChange("Enabled");
				}
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x0600043F RID: 1087 RVA: 0x00010978 File Offset: 0x0000EB78
		// (set) Token: 0x06000440 RID: 1088 RVA: 0x00010990 File Offset: 0x0000EB90
		public bool Visible
		{
			get
			{
				return this.visible;
			}
			set
			{
				if (value != this.visible)
				{
					this.visible = value;
					base.ApplyPropertyChange("Visible");
				}
			}
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x06000441 RID: 1089 RVA: 0x000109C4 File Offset: 0x0000EBC4
		// (set) Token: 0x06000442 RID: 1090 RVA: 0x000109DC File Offset: 0x0000EBDC
		internal bool IsAdded
		{
			get
			{
				return this.isAdded;
			}
			set
			{
				this.isAdded = value;
			}
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x000109E6 File Offset: 0x0000EBE6
		protected CommonFileDialogControl()
		{
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x000109FF File Offset: 0x0000EBFF
		protected CommonFileDialogControl(string text)
		{
			this.textValue = text;
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x00010A1F File Offset: 0x0000EC1F
		protected CommonFileDialogControl(string name, string text) : base(name)
		{
			this.textValue = text;
		}

		// Token: 0x06000446 RID: 1094
		internal abstract void Attach(IFileDialogCustomize dialog);

		// Token: 0x06000447 RID: 1095 RVA: 0x00010A40 File Offset: 0x0000EC40
		internal virtual void SyncUnmanagedProperties()
		{
			base.ApplyPropertyChange("Enabled");
			base.ApplyPropertyChange("Visible");
		}

		// Token: 0x040002D1 RID: 721
		private string textValue;

		// Token: 0x040002D2 RID: 722
		private bool enabled = true;

		// Token: 0x040002D3 RID: 723
		private bool visible = true;

		// Token: 0x040002D4 RID: 724
		private bool isAdded;
	}
}
