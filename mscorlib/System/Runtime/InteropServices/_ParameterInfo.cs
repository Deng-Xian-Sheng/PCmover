using System;
using System.Reflection;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200090A RID: 2314
	[Guid("993634C4-E47A-32CC-BE08-85F567DC27D6")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[CLSCompliant(false)]
	[TypeLibImportClass(typeof(ParameterInfo))]
	[ComVisible(true)]
	public interface _ParameterInfo
	{
		// Token: 0x06005FD3 RID: 24531
		void GetTypeInfoCount(out uint pcTInfo);

		// Token: 0x06005FD4 RID: 24532
		void GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo);

		// Token: 0x06005FD5 RID: 24533
		void GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId);

		// Token: 0x06005FD6 RID: 24534
		void Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr);
	}
}
