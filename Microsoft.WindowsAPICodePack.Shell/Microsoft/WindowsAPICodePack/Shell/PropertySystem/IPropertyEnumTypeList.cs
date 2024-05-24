using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
	// Token: 0x020000A1 RID: 161
	[Guid("A99400F4-3D84-4557-94BA-1242FB2CC9A6")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IPropertyEnumTypeList
	{
		// Token: 0x06000548 RID: 1352
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetCount(out uint pctypes);

		// Token: 0x06000549 RID: 1353
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetAt([In] uint itype, [In] ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out IPropertyEnumType ppv);

		// Token: 0x0600054A RID: 1354
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetConditionAt([In] uint index, [In] ref Guid riid, out IntPtr ppv);

		// Token: 0x0600054B RID: 1355
		[MethodImpl(MethodImplOptions.InternalCall)]
		void FindMatchingIndex([In] PropVariant propvarCmp, out uint pnIndex);
	}
}
