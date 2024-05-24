using System;
using System.Reflection.Emit;

namespace System.Runtime.InteropServices
{
	// Token: 0x020009B1 RID: 2481
	[Guid("BEBB2505-8B54-3443-AEAD-142A16DD9CC7")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[CLSCompliant(false)]
	[TypeLibImportClass(typeof(AssemblyBuilder))]
	[ComVisible(true)]
	public interface _AssemblyBuilder
	{
		// Token: 0x06006361 RID: 25441
		void GetTypeInfoCount(out uint pcTInfo);

		// Token: 0x06006362 RID: 25442
		void GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo);

		// Token: 0x06006363 RID: 25443
		void GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId);

		// Token: 0x06006364 RID: 25444
		void Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr);
	}
}
