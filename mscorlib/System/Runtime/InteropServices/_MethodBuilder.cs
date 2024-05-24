using System;
using System.Reflection.Emit;

namespace System.Runtime.InteropServices
{
	// Token: 0x020009B9 RID: 2489
	[Guid("007D8A14-FDF3-363E-9A0B-FEC0618260A2")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[CLSCompliant(false)]
	[TypeLibImportClass(typeof(MethodBuilder))]
	[ComVisible(true)]
	public interface _MethodBuilder
	{
		// Token: 0x06006381 RID: 25473
		void GetTypeInfoCount(out uint pcTInfo);

		// Token: 0x06006382 RID: 25474
		void GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo);

		// Token: 0x06006383 RID: 25475
		void GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId);

		// Token: 0x06006384 RID: 25476
		void Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr);
	}
}
