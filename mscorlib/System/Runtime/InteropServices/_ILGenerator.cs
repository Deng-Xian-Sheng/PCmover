using System;
using System.Reflection.Emit;

namespace System.Runtime.InteropServices
{
	// Token: 0x020009B7 RID: 2487
	[Guid("A4924B27-6E3B-37F7-9B83-A4501955E6A7")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[CLSCompliant(false)]
	[TypeLibImportClass(typeof(ILGenerator))]
	[ComVisible(true)]
	public interface _ILGenerator
	{
		// Token: 0x06006379 RID: 25465
		void GetTypeInfoCount(out uint pcTInfo);

		// Token: 0x0600637A RID: 25466
		void GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo);

		// Token: 0x0600637B RID: 25467
		void GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId);

		// Token: 0x0600637C RID: 25468
		void Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr);
	}
}
