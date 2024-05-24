using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x020000B7 RID: 183
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("42f85136-db7e-439c-85f1-e4075d135fc8")]
	[ComImport]
	internal interface IFileDialog : IModalWindow
	{
		// Token: 0x0600032B RID: 811
		[PreserveSig]
		HRESULT Show(IntPtr parent);

		// Token: 0x0600032C RID: 812
		void SetFileTypes(uint cFileTypes, [In] ref COMDLG_FILTERSPEC rgFilterSpec);

		// Token: 0x0600032D RID: 813
		void SetFileTypeIndex(uint iFileType);

		// Token: 0x0600032E RID: 814
		uint GetFileTypeIndex();

		// Token: 0x0600032F RID: 815
		uint Advise(IFileDialogEvents pfde);

		// Token: 0x06000330 RID: 816
		void Unadvise(uint dwCookie);

		// Token: 0x06000331 RID: 817
		void SetOptions(FOS fos);

		// Token: 0x06000332 RID: 818
		FOS GetOptions();

		// Token: 0x06000333 RID: 819
		void SetDefaultFolder(IShellItem psi);

		// Token: 0x06000334 RID: 820
		void SetFolder(IShellItem psi);

		// Token: 0x06000335 RID: 821
		IShellItem GetFolder();

		// Token: 0x06000336 RID: 822
		IShellItem GetCurrentSelection();

		// Token: 0x06000337 RID: 823
		void SetFileName([MarshalAs(UnmanagedType.LPWStr)] string pszName);

		// Token: 0x06000338 RID: 824
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetFileName();

		// Token: 0x06000339 RID: 825
		void SetTitle([MarshalAs(UnmanagedType.LPWStr)] string pszTitle);

		// Token: 0x0600033A RID: 826
		void SetOkButtonLabel([MarshalAs(UnmanagedType.LPWStr)] string pszText);

		// Token: 0x0600033B RID: 827
		void SetFileNameLabel([MarshalAs(UnmanagedType.LPWStr)] string pszLabel);

		// Token: 0x0600033C RID: 828
		IShellItem GetResult();

		// Token: 0x0600033D RID: 829
		void AddPlace(IShellItem psi, FDAP alignment);

		// Token: 0x0600033E RID: 830
		void SetDefaultExtension([MarshalAs(UnmanagedType.LPWStr)] string pszDefaultExtension);

		// Token: 0x0600033F RID: 831
		void Close([MarshalAs(UnmanagedType.Error)] int hr);

		// Token: 0x06000340 RID: 832
		void SetClientGuid([In] ref Guid guid);

		// Token: 0x06000341 RID: 833
		void ClearClientData();

		// Token: 0x06000342 RID: 834
		void SetFilter([MarshalAs(UnmanagedType.Interface)] object pFilter);
	}
}
