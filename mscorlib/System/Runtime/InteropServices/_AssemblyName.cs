using System;
using System.Reflection;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200090C RID: 2316
	[Guid("B42B6AAC-317E-34D5-9FA9-093BB4160C50")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[CLSCompliant(false)]
	[TypeLibImportClass(typeof(AssemblyName))]
	[ComVisible(true)]
	public interface _AssemblyName
	{
		// Token: 0x06005FDB RID: 24539
		void GetTypeInfoCount(out uint pcTInfo);

		// Token: 0x06005FDC RID: 24540
		void GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo);

		// Token: 0x06005FDD RID: 24541
		void GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId);

		// Token: 0x06005FDE RID: 24542
		void Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr);
	}
}
