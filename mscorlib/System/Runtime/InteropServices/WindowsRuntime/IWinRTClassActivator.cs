using System;
using System.Security;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x02000A11 RID: 2577
	[Guid("86ddd2d7-ad80-44f6-a12e-63698b52825d")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IWinRTClassActivator
	{
		// Token: 0x060065B2 RID: 26034
		[SecurityCritical]
		[return: MarshalAs(UnmanagedType.IInspectable)]
		object ActivateInstance([MarshalAs(UnmanagedType.HString)] string activatableClassId);

		// Token: 0x060065B3 RID: 26035
		[SecurityCritical]
		IntPtr GetActivationFactory([MarshalAs(UnmanagedType.HString)] string activatableClassId, ref Guid iid);
	}
}
