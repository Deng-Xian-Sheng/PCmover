using System;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
	// Token: 0x02000147 RID: 327
	[CoClass(typeof(FileSaveDialogRCW))]
	[Guid("84BCCD23-5FDE-4CDB-AEA4-AF64B83D78AB")]
	[ComImport]
	internal interface NativeFileSaveDialog : IFileSaveDialog, IFileDialog, IModalWindow
	{
	}
}
