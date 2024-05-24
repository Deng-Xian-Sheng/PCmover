using System;
using System.Threading;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000900 RID: 2304
	[Guid("C281C7F1-4AA9-3517-961A-463CFED57E75")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[CLSCompliant(false)]
	[TypeLibImportClass(typeof(Thread))]
	[ComVisible(true)]
	public interface _Thread
	{
		// Token: 0x06005E59 RID: 24153
		void GetTypeInfoCount(out uint pcTInfo);

		// Token: 0x06005E5A RID: 24154
		void GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo);

		// Token: 0x06005E5B RID: 24155
		void GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId);

		// Token: 0x06005E5C RID: 24156
		void Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr);
	}
}
