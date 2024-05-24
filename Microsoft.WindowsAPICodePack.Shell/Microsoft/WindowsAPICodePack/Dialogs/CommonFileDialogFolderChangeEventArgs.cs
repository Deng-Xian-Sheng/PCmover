using System;
using System.ComponentModel;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
	// Token: 0x02000084 RID: 132
	public class CommonFileDialogFolderChangeEventArgs : CancelEventArgs
	{
		// Token: 0x0600048E RID: 1166 RVA: 0x0001184E File Offset: 0x0000FA4E
		public CommonFileDialogFolderChangeEventArgs(string folder)
		{
			this.Folder = folder;
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x0600048F RID: 1167 RVA: 0x00011864 File Offset: 0x0000FA64
		// (set) Token: 0x06000490 RID: 1168 RVA: 0x0001187B File Offset: 0x0000FA7B
		public string Folder { get; set; }
	}
}
