﻿using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x020008FF RID: 2303
	[Guid("917B14D0-2D9E-38B8-92A9-381ACF52F7C0")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[CLSCompliant(false)]
	[TypeLibImportClass(typeof(Attribute))]
	[ComVisible(true)]
	public interface _Attribute
	{
		// Token: 0x06005E55 RID: 24149
		void GetTypeInfoCount(out uint pcTInfo);

		// Token: 0x06005E56 RID: 24150
		void GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo);

		// Token: 0x06005E57 RID: 24151
		void GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId);

		// Token: 0x06005E58 RID: 24152
		void Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr);
	}
}
