using System;

namespace Microsoft.WindowsAPICodePack.Dialogs.Controls
{
	// Token: 0x0200008A RID: 138
	public class CommonFileDialogRadioButtonListItem
	{
		// Token: 0x1700016B RID: 363
		// (get) Token: 0x060004B3 RID: 1203 RVA: 0x00011EE4 File Offset: 0x000100E4
		// (set) Token: 0x060004B4 RID: 1204 RVA: 0x00011EFB File Offset: 0x000100FB
		public string Text { get; set; }

		// Token: 0x060004B5 RID: 1205 RVA: 0x00011F04 File Offset: 0x00010104
		public CommonFileDialogRadioButtonListItem() : this(string.Empty)
		{
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x00011F14 File Offset: 0x00010114
		public CommonFileDialogRadioButtonListItem(string text)
		{
			this.Text = text;
		}
	}
}
