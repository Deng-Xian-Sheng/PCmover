using System;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
	// Token: 0x02000145 RID: 325
	[CoClass(typeof(FileOpenDialogRCW))]
	[Guid("D57C7288-D4AD-4768-BE02-9D969532D960")]
	[ComImport]
	internal interface NativeFileOpenDialog : IFileOpenDialog, IFileDialog, IModalWindow
	{
	}
}
