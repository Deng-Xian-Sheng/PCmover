using System;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
	// Token: 0x02000052 RID: 82
	public class TaskDialogButton : TaskDialogButtonBase
	{
		// Token: 0x0600025A RID: 602 RVA: 0x00008B65 File Offset: 0x00006D65
		public TaskDialogButton()
		{
		}

		// Token: 0x0600025B RID: 603 RVA: 0x00008B70 File Offset: 0x00006D70
		public TaskDialogButton(string name, string text) : base(name, text)
		{
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x0600025C RID: 604 RVA: 0x00008B80 File Offset: 0x00006D80
		// (set) Token: 0x0600025D RID: 605 RVA: 0x00008B98 File Offset: 0x00006D98
		public bool UseElevationIcon
		{
			get
			{
				return this.useElevationIcon;
			}
			set
			{
				base.CheckPropertyChangeAllowed("ShowElevationIcon");
				this.useElevationIcon = value;
				base.ApplyPropertyChange("ShowElevationIcon");
			}
		}

		// Token: 0x04000291 RID: 657
		private bool useElevationIcon;
	}
}
