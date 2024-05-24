using System;
using System.Reflection.Emit;

namespace System.Runtime.InteropServices
{
	// Token: 0x020009B5 RID: 2485
	[Guid("AADABA99-895D-3D65-9760-B1F12621FAE8")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[CLSCompliant(false)]
	[TypeLibImportClass(typeof(EventBuilder))]
	[ComVisible(true)]
	public interface _EventBuilder
	{
		// Token: 0x06006371 RID: 25457
		void GetTypeInfoCount(out uint pcTInfo);

		// Token: 0x06006372 RID: 25458
		void GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo);

		// Token: 0x06006373 RID: 25459
		void GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId);

		// Token: 0x06006374 RID: 25460
		void Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr);
	}
}
