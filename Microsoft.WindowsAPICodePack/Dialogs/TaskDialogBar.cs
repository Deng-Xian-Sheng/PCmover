using System;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
	// Token: 0x02000050 RID: 80
	public class TaskDialogBar : TaskDialogControl
	{
		// Token: 0x06000249 RID: 585 RVA: 0x00008952 File Offset: 0x00006B52
		public TaskDialogBar()
		{
		}

		// Token: 0x0600024A RID: 586 RVA: 0x0000895D File Offset: 0x00006B5D
		protected TaskDialogBar(string name) : base(name)
		{
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x0600024B RID: 587 RVA: 0x0000896C File Offset: 0x00006B6C
		// (set) Token: 0x0600024C RID: 588 RVA: 0x00008984 File Offset: 0x00006B84
		public TaskDialogProgressBarState State
		{
			get
			{
				return this.state;
			}
			set
			{
				base.CheckPropertyChangeAllowed("State");
				this.state = value;
				base.ApplyPropertyChange("State");
			}
		}

		// Token: 0x0600024D RID: 589 RVA: 0x000089A6 File Offset: 0x00006BA6
		protected internal virtual void Reset()
		{
			this.state = TaskDialogProgressBarState.Normal;
		}

		// Token: 0x0400028C RID: 652
		private TaskDialogProgressBarState state;
	}
}
