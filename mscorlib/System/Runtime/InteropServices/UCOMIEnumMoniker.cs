using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200097F RID: 2431
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.IEnumMoniker instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Guid("00000102-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface UCOMIEnumMoniker
	{
		// Token: 0x06006286 RID: 25222
		[PreserveSig]
		int Next(int celt, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] [Out] UCOMIMoniker[] rgelt, out int pceltFetched);

		// Token: 0x06006287 RID: 25223
		[PreserveSig]
		int Skip(int celt);

		// Token: 0x06006288 RID: 25224
		[PreserveSig]
		int Reset();

		// Token: 0x06006289 RID: 25225
		void Clone(out UCOMIEnumMoniker ppenum);
	}
}
