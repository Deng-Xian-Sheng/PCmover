using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace ControlzEx.Standard
{
	// Token: 0x020000A8 RID: 168
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("43826d1e-e718-42ee-bc55-a1e261c37bfe")]
	[ComImport]
	internal interface IShellItem
	{
		// Token: 0x060002B1 RID: 689
		[return: MarshalAs(UnmanagedType.Interface)]
		object BindToHandler(IBindCtx pbc, [In] ref Guid bhid, [In] ref Guid riid);

		// Token: 0x060002B2 RID: 690
		IShellItem GetParent();

		// Token: 0x060002B3 RID: 691
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetDisplayName(SIGDN sigdnName);

		// Token: 0x060002B4 RID: 692
		SFGAO GetAttributes(SFGAO sfgaoMask);

		// Token: 0x060002B5 RID: 693
		int Compare(IShellItem psi, SICHINT hint);
	}
}
