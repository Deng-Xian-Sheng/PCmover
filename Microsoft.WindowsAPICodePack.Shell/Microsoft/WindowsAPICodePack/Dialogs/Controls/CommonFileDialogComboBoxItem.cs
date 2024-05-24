using System;

namespace Microsoft.WindowsAPICodePack.Dialogs.Controls
{
	// Token: 0x02000080 RID: 128
	public class CommonFileDialogComboBoxItem
	{
		// Token: 0x17000161 RID: 353
		// (get) Token: 0x06000477 RID: 1143 RVA: 0x0001118C File Offset: 0x0000F38C
		// (set) Token: 0x06000478 RID: 1144 RVA: 0x000111A4 File Offset: 0x0000F3A4
		public string Text
		{
			get
			{
				return this.text;
			}
			set
			{
				this.text = value;
			}
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x000111AE File Offset: 0x0000F3AE
		public CommonFileDialogComboBoxItem()
		{
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x000111C4 File Offset: 0x0000F3C4
		public CommonFileDialogComboBoxItem(string text)
		{
			this.text = text;
		}

		// Token: 0x040002E6 RID: 742
		private string text = string.Empty;
	}
}
