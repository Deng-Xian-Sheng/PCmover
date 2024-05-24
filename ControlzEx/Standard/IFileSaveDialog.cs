using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x020000B9 RID: 185
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("84bccd23-5fde-4cdb-aea4-af64b83d78ab")]
	[ComImport]
	internal interface IFileSaveDialog : IFileDialog, IModalWindow
	{
		// Token: 0x0600035D RID: 861
		[PreserveSig]
		HRESULT Show(IntPtr parent);

		// Token: 0x0600035E RID: 862
		void SetFileTypes(uint cFileTypes, [In] ref COMDLG_FILTERSPEC rgFilterSpec);

		// Token: 0x0600035F RID: 863
		void SetFileTypeIndex(uint iFileType);

		// Token: 0x06000360 RID: 864
		uint GetFileTypeIndex();

		// Token: 0x06000361 RID: 865
		uint Advise(IFileDialogEvents pfde);

		// Token: 0x06000362 RID: 866
		void Unadvise(uint dwCookie);

		// Token: 0x06000363 RID: 867
		void SetOptions(FOS fos);

		// Token: 0x06000364 RID: 868
		FOS GetOptions();

		// Token: 0x06000365 RID: 869
		void SetDefaultFolder(IShellItem psi);

		// Token: 0x06000366 RID: 870
		void SetFolder(IShellItem psi);

		// Token: 0x06000367 RID: 871
		IShellItem GetFolder();

		// Token: 0x06000368 RID: 872
		IShellItem GetCurrentSelection();

		// Token: 0x06000369 RID: 873
		void SetFileName([MarshalAs(UnmanagedType.LPWStr)] string pszName);

		// Token: 0x0600036A RID: 874
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetFileName();

		// Token: 0x0600036B RID: 875
		void SetTitle([MarshalAs(UnmanagedType.LPWStr)] string pszTitle);

		// Token: 0x0600036C RID: 876
		void SetOkButtonLabel([MarshalAs(UnmanagedType.LPWStr)] string pszText);

		// Token: 0x0600036D RID: 877
		void SetFileNameLabel([MarshalAs(UnmanagedType.LPWStr)] string pszLabel);

		// Token: 0x0600036E RID: 878
		IShellItem GetResult();

		// Token: 0x0600036F RID: 879
		void AddPlace(IShellItem psi, FDAP fdcp);

		// Token: 0x06000370 RID: 880
		void SetDefaultExtension([MarshalAs(UnmanagedType.LPWStr)] string pszDefaultExtension);

		// Token: 0x06000371 RID: 881
		void Close([MarshalAs(UnmanagedType.Error)] int hr);

		// Token: 0x06000372 RID: 882
		void SetClientGuid([In] ref Guid guid);

		// Token: 0x06000373 RID: 883
		void ClearClientData();

		// Token: 0x06000374 RID: 884
		void SetFilter([MarshalAs(UnmanagedType.Interface)] object pFilter);

		// Token: 0x06000375 RID: 885
		void SetSaveAsItem(IShellItem psi);

		// Token: 0x06000376 RID: 886
		void SetProperties([MarshalAs(UnmanagedType.Interface)] [In] object pStore);

		// Token: 0x06000377 RID: 887
		void SetCollectedProperties([MarshalAs(UnmanagedType.Interface)] [In] object pList, [In] int fAppendDefault);

		// Token: 0x06000378 RID: 888
		[return: MarshalAs(UnmanagedType.Interface)]
		object GetProperties();

		// Token: 0x06000379 RID: 889
		void ApplyProperties(IShellItem psi, [MarshalAs(UnmanagedType.Interface)] object pStore, [In] ref IntPtr hwnd, [MarshalAs(UnmanagedType.Interface)] object pSink);
	}
}
