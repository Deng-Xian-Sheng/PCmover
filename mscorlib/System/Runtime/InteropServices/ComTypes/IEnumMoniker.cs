using System;

namespace System.Runtime.InteropServices.ComTypes
{
	// Token: 0x02000A28 RID: 2600
	[Guid("00000102-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[__DynamicallyInvokable]
	[ComImport]
	public interface IEnumMoniker
	{
		// Token: 0x06006619 RID: 26137
		[PreserveSig]
		int Next(int celt, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] [Out] IMoniker[] rgelt, IntPtr pceltFetched);

		// Token: 0x0600661A RID: 26138
		[__DynamicallyInvokable]
		[PreserveSig]
		int Skip(int celt);

		// Token: 0x0600661B RID: 26139
		[__DynamicallyInvokable]
		void Reset();

		// Token: 0x0600661C RID: 26140
		[__DynamicallyInvokable]
		void Clone(out IEnumMoniker ppenum);
	}
}
