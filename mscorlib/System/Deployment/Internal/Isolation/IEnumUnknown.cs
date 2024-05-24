using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x02000671 RID: 1649
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("00000100-0000-0000-C000-000000000046")]
	[ComImport]
	internal interface IEnumUnknown
	{
		// Token: 0x06004F20 RID: 20256
		[PreserveSig]
		int Next(uint celt, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] [Out] object[] rgelt, ref uint celtFetched);

		// Token: 0x06004F21 RID: 20257
		[PreserveSig]
		int Skip(uint celt);

		// Token: 0x06004F22 RID: 20258
		[PreserveSig]
		int Reset();

		// Token: 0x06004F23 RID: 20259
		[PreserveSig]
		int Clone(out IEnumUnknown enumUnknown);
	}
}
