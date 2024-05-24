using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000167 RID: 359
	[Guid("43826D1E-E718-42EE-BC55-A1E261C37BFE")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IShellItem
	{
		// Token: 0x06000E44 RID: 3652
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult BindToHandler([In] IntPtr pbc, [In] ref Guid bhid, [In] ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out IShellFolder ppv);

		// Token: 0x06000E45 RID: 3653
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetParent([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

		// Token: 0x06000E46 RID: 3654
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetDisplayName([In] ShellNativeMethods.ShellItemDesignNameOptions sigdnName, out IntPtr ppszName);

		// Token: 0x06000E47 RID: 3655
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetAttributes([In] ShellNativeMethods.ShellFileGetAttributesOptions sfgaoMask, out ShellNativeMethods.ShellFileGetAttributesOptions psfgaoAttribs);

		// Token: 0x06000E48 RID: 3656
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult Compare([MarshalAs(UnmanagedType.Interface)] [In] IShellItem psi, [In] SICHINTF hint, out int piOrder);
	}
}
