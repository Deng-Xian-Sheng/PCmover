using System;
using System.Reflection.Emit;

namespace System.Runtime.InteropServices
{
	// Token: 0x020009B8 RID: 2488
	[Guid("4E6350D1-A08B-3DEC-9A3E-C465F9AEEC0C")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[CLSCompliant(false)]
	[TypeLibImportClass(typeof(LocalBuilder))]
	[ComVisible(true)]
	public interface _LocalBuilder
	{
		// Token: 0x0600637D RID: 25469
		void GetTypeInfoCount(out uint pcTInfo);

		// Token: 0x0600637E RID: 25470
		void GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo);

		// Token: 0x0600637F RID: 25471
		void GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId);

		// Token: 0x06006380 RID: 25472
		void Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr);
	}
}
