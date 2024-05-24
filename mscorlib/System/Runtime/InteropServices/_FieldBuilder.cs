﻿using System;
using System.Reflection.Emit;

namespace System.Runtime.InteropServices
{
	// Token: 0x020009B6 RID: 2486
	[Guid("CE1A3BF5-975E-30CC-97C9-1EF70F8F3993")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[CLSCompliant(false)]
	[TypeLibImportClass(typeof(FieldBuilder))]
	[ComVisible(true)]
	public interface _FieldBuilder
	{
		// Token: 0x06006375 RID: 25461
		void GetTypeInfoCount(out uint pcTInfo);

		// Token: 0x06006376 RID: 25462
		void GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo);

		// Token: 0x06006377 RID: 25463
		void GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId);

		// Token: 0x06006378 RID: 25464
		void Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr);
	}
}
