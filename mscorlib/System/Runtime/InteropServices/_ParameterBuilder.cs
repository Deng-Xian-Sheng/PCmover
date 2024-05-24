using System;
using System.Reflection.Emit;

namespace System.Runtime.InteropServices
{
	// Token: 0x020009BC RID: 2492
	[Guid("36329EBA-F97A-3565-BC07-0ED5C6EF19FC")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[CLSCompliant(false)]
	[TypeLibImportClass(typeof(ParameterBuilder))]
	[ComVisible(true)]
	public interface _ParameterBuilder
	{
		// Token: 0x0600638D RID: 25485
		void GetTypeInfoCount(out uint pcTInfo);

		// Token: 0x0600638E RID: 25486
		void GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo);

		// Token: 0x0600638F RID: 25487
		void GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId);

		// Token: 0x06006390 RID: 25488
		void Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr);
	}
}
