﻿using System;
using System.Reflection.Emit;

namespace System.Runtime.InteropServices
{
	// Token: 0x020009B2 RID: 2482
	[Guid("ED3E4384-D7E2-3FA7-8FFD-8940D330519A")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[CLSCompliant(false)]
	[TypeLibImportClass(typeof(ConstructorBuilder))]
	[ComVisible(true)]
	public interface _ConstructorBuilder
	{
		// Token: 0x06006365 RID: 25445
		void GetTypeInfoCount(out uint pcTInfo);

		// Token: 0x06006366 RID: 25446
		void GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo);

		// Token: 0x06006367 RID: 25447
		void GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId);

		// Token: 0x06006368 RID: 25448
		void Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr);
	}
}
