using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000014 RID: 20
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("B63EA76D-1F85-456F-A19C-48159EFA858B")]
	[ComImport]
	internal interface IShellItemArray
	{
		// Token: 0x060000A4 RID: 164
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult BindToHandler([MarshalAs(UnmanagedType.Interface)] [In] IntPtr pbc, [In] ref Guid rbhid, [In] ref Guid riid, out IntPtr ppvOut);

		// Token: 0x060000A5 RID: 165
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetPropertyStore([In] int Flags, [In] ref Guid riid, out IntPtr ppv);

		// Token: 0x060000A6 RID: 166
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetPropertyDescriptionList([In] ref PropertyKey keyType, [In] ref Guid riid, out IntPtr ppv);

		// Token: 0x060000A7 RID: 167
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetAttributes([In] ShellNativeMethods.ShellItemAttributeOptions dwAttribFlags, [In] ShellNativeMethods.ShellFileGetAttributesOptions sfgaoMask, out ShellNativeMethods.ShellFileGetAttributesOptions psfgaoAttribs);

		// Token: 0x060000A8 RID: 168
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetCount(out uint pdwNumItems);

		// Token: 0x060000A9 RID: 169
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetItemAt([In] uint dwIndex, [MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

		// Token: 0x060000AA RID: 170
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult EnumItems([MarshalAs(UnmanagedType.Interface)] out IntPtr ppenumShellItems);
	}
}
