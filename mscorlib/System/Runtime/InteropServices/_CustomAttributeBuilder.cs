using System;
using System.Reflection.Emit;

namespace System.Runtime.InteropServices
{
	// Token: 0x020009B3 RID: 2483
	[Guid("BE9ACCE8-AAFF-3B91-81AE-8211663F5CAD")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[CLSCompliant(false)]
	[TypeLibImportClass(typeof(CustomAttributeBuilder))]
	[ComVisible(true)]
	public interface _CustomAttributeBuilder
	{
		// Token: 0x06006369 RID: 25449
		void GetTypeInfoCount(out uint pcTInfo);

		// Token: 0x0600636A RID: 25450
		void GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo);

		// Token: 0x0600636B RID: 25451
		void GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId);

		// Token: 0x0600636C RID: 25452
		void Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr);
	}
}
