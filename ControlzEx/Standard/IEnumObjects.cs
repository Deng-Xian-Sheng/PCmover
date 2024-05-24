using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x020000A3 RID: 163
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("2c1c7e2e-2d0e-4059-831e-1e6f82335c2e")]
	[ComImport]
	internal interface IEnumObjects
	{
		// Token: 0x06000296 RID: 662
		void Next(uint celt, [In] ref Guid riid, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 0)] [Out] object[] rgelt, out uint pceltFetched);

		// Token: 0x06000297 RID: 663
		void Skip(uint celt);

		// Token: 0x06000298 RID: 664
		void Reset();

		// Token: 0x06000299 RID: 665
		IEnumObjects Clone();
	}
}
