using System;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
	// Token: 0x02000051 RID: 81
	public abstract class TaskDialogButtonBase : TaskDialogControl
	{
		// Token: 0x0600024E RID: 590 RVA: 0x000089B0 File Offset: 0x00006BB0
		protected TaskDialogButtonBase()
		{
		}

		// Token: 0x0600024F RID: 591 RVA: 0x000089C2 File Offset: 0x00006BC2
		protected TaskDialogButtonBase(string name, string text) : base(name)
		{
			this.text = text;
		}

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x06000250 RID: 592 RVA: 0x000089DC File Offset: 0x00006BDC
		// (remove) Token: 0x06000251 RID: 593 RVA: 0x00008A18 File Offset: 0x00006C18
		public event EventHandler Click;

		// Token: 0x06000252 RID: 594 RVA: 0x00008A54 File Offset: 0x00006C54
		internal void RaiseClickEvent()
		{
			if (this.enabled)
			{
				if (this.Click != null)
				{
					this.Click(this, EventArgs.Empty);
				}
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000253 RID: 595 RVA: 0x00008A90 File Offset: 0x00006C90
		// (set) Token: 0x06000254 RID: 596 RVA: 0x00008AA8 File Offset: 0x00006CA8
		public string Text
		{
			get
			{
				return this.text;
			}
			set
			{
				base.CheckPropertyChangeAllowed("Text");
				this.text = value;
				base.ApplyPropertyChange("Text");
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000255 RID: 597 RVA: 0x00008ACC File Offset: 0x00006CCC
		// (set) Token: 0x06000256 RID: 598 RVA: 0x00008AE4 File Offset: 0x00006CE4
		public bool Enabled
		{
			get
			{
				return this.enabled;
			}
			set
			{
				base.CheckPropertyChangeAllowed("Enabled");
				this.enabled = value;
				base.ApplyPropertyChange("Enabled");
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000257 RID: 599 RVA: 0x00008B08 File Offset: 0x00006D08
		// (set) Token: 0x06000258 RID: 600 RVA: 0x00008B20 File Offset: 0x00006D20
		public bool Default
		{
			get
			{
				return this.defaultControl;
			}
			set
			{
				base.CheckPropertyChangeAllowed("Default");
				this.defaultControl = value;
				base.ApplyPropertyChange("Default");
			}
		}

		// Token: 0x06000259 RID: 601 RVA: 0x00008B44 File Offset: 0x00006D44
		public override string ToString()
		{
			return this.text ?? string.Empty;
		}

		// Token: 0x0400028E RID: 654
		private string text;

		// Token: 0x0400028F RID: 655
		private bool enabled = true;

		// Token: 0x04000290 RID: 656
		private bool defaultControl;
	}
}
