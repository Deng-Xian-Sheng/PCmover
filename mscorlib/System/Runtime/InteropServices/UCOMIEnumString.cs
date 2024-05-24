using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000983 RID: 2435
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.IEnumString instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Guid("00000101-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface UCOMIEnumString
	{
		// Token: 0x06006292 RID: 25234
		[PreserveSig]
		int Next(int celt, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 0)] [Out] string[] rgelt, out int pceltFetched);

		// Token: 0x06006293 RID: 25235
		[PreserveSig]
		int Skip(int celt);

		// Token: 0x06006294 RID: 25236
		[PreserveSig]
		int Reset();

		// Token: 0x06006295 RID: 25237
		void Clone(out UCOMIEnumString ppenum);
	}
}
