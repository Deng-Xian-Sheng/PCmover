using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x020000B8 RID: 184
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("d57c7288-d4ad-4768-be02-9d969532d960")]
	[ComImport]
	internal interface IFileOpenDialog : IFileDialog, IModalWindow
	{
		// Token: 0x06000343 RID: 835
		[PreserveSig]
		HRESULT Show(IntPtr parent);

		// Token: 0x06000344 RID: 836
		void SetFileTypes(uint cFileTypes, [In] ref COMDLG_FILTERSPEC rgFilterSpec);

		// Token: 0x06000345 RID: 837
		void SetFileTypeIndex(uint iFileType);

		// Token: 0x06000346 RID: 838
		uint GetFileTypeIndex();

		// Token: 0x06000347 RID: 839
		uint Advise(IFileDialogEvents pfde);

		// Token: 0x06000348 RID: 840
		void Unadvise(uint dwCookie);

		// Token: 0x06000349 RID: 841
		void SetOptions(FOS fos);

		// Token: 0x0600034A RID: 842
		FOS GetOptions();

		// Token: 0x0600034B RID: 843
		void SetDefaultFolder(IShellItem psi);

		// Token: 0x0600034C RID: 844
		void SetFolder(IShellItem psi);

		// Token: 0x0600034D RID: 845
		IShellItem GetFolder();

		// Token: 0x0600034E RID: 846
		IShellItem GetCurrentSelection();

		// Token: 0x0600034F RID: 847
		void SetFileName([MarshalAs(UnmanagedType.LPWStr)] string pszName);

		// Token: 0x06000350 RID: 848
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetFileName();

		// Token: 0x06000351 RID: 849
		void SetTitle([MarshalAs(UnmanagedType.LPWStr)] string pszTitle);

		// Token: 0x06000352 RID: 850
		void SetOkButtonLabel([MarshalAs(UnmanagedType.LPWStr)] string pszText);

		// Token: 0x06000353 RID: 851
		void SetFileNameLabel([MarshalAs(UnmanagedType.LPWStr)] string pszLabel);

		// Token: 0x06000354 RID: 852
		IShellItem GetResult();

		// Token: 0x06000355 RID: 853
		void AddPlace(IShellItem psi, FDAP fdcp);

		// Token: 0x06000356 RID: 854
		void SetDefaultExtension([MarshalAs(UnmanagedType.LPWStr)] string pszDefaultExtension);

		// Token: 0x06000357 RID: 855
		void Close([MarshalAs(UnmanagedType.Error)] int hr);

		// Token: 0x06000358 RID: 856
		void SetClientGuid([In] ref Guid guid);

		// Token: 0x06000359 RID: 857
		void ClearClientData();

		// Token: 0x0600035A RID: 858
		void SetFilter([MarshalAs(UnmanagedType.Interface)] object pFilter);

		// Token: 0x0600035B RID: 859
		IShellItemArray GetResults();

		// Token: 0x0600035C RID: 860
		IShellItemArray GetSelectedItems();
	}
}
