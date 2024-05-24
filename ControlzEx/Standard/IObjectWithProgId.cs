using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x020000B2 RID: 178
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("71e806fb-8dee-46fc-bf8c-7748a8a1ae13")]
	[ComImport]
	internal interface IObjectWithProgId
	{
		// Token: 0x060002FC RID: 764
		void SetProgID([MarshalAs(UnmanagedType.LPWStr)] string pszProgID);

		// Token: 0x060002FD RID: 765
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetProgID();
	}
}
