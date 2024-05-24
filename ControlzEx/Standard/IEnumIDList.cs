using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x020000A2 RID: 162
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("000214F2-0000-0000-C000-000000000046")]
	[ComImport]
	internal interface IEnumIDList
	{
		// Token: 0x06000292 RID: 658
		[PreserveSig]
		HRESULT Next(uint celt, out IntPtr rgelt, out int pceltFetched);

		// Token: 0x06000293 RID: 659
		[PreserveSig]
		HRESULT Skip(uint celt);

		// Token: 0x06000294 RID: 660
		void Reset();

		// Token: 0x06000295 RID: 661
		void Clone([MarshalAs(UnmanagedType.Interface)] out IEnumIDList ppenum);
	}
}
