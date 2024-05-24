using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000988 RID: 2440
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.IPersistFile instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Guid("0000010b-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface UCOMIPersistFile
	{
		// Token: 0x060062B2 RID: 25266
		void GetClassID(out Guid pClassID);

		// Token: 0x060062B3 RID: 25267
		[PreserveSig]
		int IsDirty();

		// Token: 0x060062B4 RID: 25268
		void Load([MarshalAs(UnmanagedType.LPWStr)] string pszFileName, int dwMode);

		// Token: 0x060062B5 RID: 25269
		void Save([MarshalAs(UnmanagedType.LPWStr)] string pszFileName, [MarshalAs(UnmanagedType.Bool)] bool fRemember);

		// Token: 0x060062B6 RID: 25270
		void SaveCompleted([MarshalAs(UnmanagedType.LPWStr)] string pszFileName);

		// Token: 0x060062B7 RID: 25271
		void GetCurFile([MarshalAs(UnmanagedType.LPWStr)] out string ppszFileName);
	}
}
