using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x020000B5 RID: 181
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("973510DB-7D7F-452B-8975-74A85828D354")]
	[ComImport]
	internal interface IFileDialogEvents
	{
		// Token: 0x06000323 RID: 803
		[PreserveSig]
		HRESULT OnFileOk(IFileDialog pfd);

		// Token: 0x06000324 RID: 804
		[PreserveSig]
		HRESULT OnFolderChanging(IFileDialog pfd, IShellItem psiFolder);

		// Token: 0x06000325 RID: 805
		[PreserveSig]
		HRESULT OnFolderChange(IFileDialog pfd);

		// Token: 0x06000326 RID: 806
		[PreserveSig]
		HRESULT OnSelectionChange(IFileDialog pfd);

		// Token: 0x06000327 RID: 807
		[PreserveSig]
		HRESULT OnShareViolation(IFileDialog pfd, IShellItem psi, out FDESVR pResponse);

		// Token: 0x06000328 RID: 808
		[PreserveSig]
		HRESULT OnTypeChange(IFileDialog pfd);

		// Token: 0x06000329 RID: 809
		[PreserveSig]
		HRESULT OnOverwrite(IFileDialog pfd, IShellItem psi, out FDEOR pResponse);
	}
}
