using System;

namespace System.Runtime.InteropServices.ComTypes
{
	// Token: 0x02000A31 RID: 2609
	[Guid("0000010b-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[__DynamicallyInvokable]
	[ComImport]
	public interface IPersistFile
	{
		// Token: 0x06006645 RID: 26181
		[__DynamicallyInvokable]
		void GetClassID(out Guid pClassID);

		// Token: 0x06006646 RID: 26182
		[__DynamicallyInvokable]
		[PreserveSig]
		int IsDirty();

		// Token: 0x06006647 RID: 26183
		[__DynamicallyInvokable]
		void Load([MarshalAs(UnmanagedType.LPWStr)] string pszFileName, int dwMode);

		// Token: 0x06006648 RID: 26184
		[__DynamicallyInvokable]
		void Save([MarshalAs(UnmanagedType.LPWStr)] string pszFileName, [MarshalAs(UnmanagedType.Bool)] bool fRemember);

		// Token: 0x06006649 RID: 26185
		[__DynamicallyInvokable]
		void SaveCompleted([MarshalAs(UnmanagedType.LPWStr)] string pszFileName);

		// Token: 0x0600664A RID: 26186
		[__DynamicallyInvokable]
		void GetCurFile([MarshalAs(UnmanagedType.LPWStr)] out string ppszFileName);
	}
}
