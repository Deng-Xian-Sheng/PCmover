using System;

namespace System.Runtime.InteropServices.ComTypes
{
	// Token: 0x02000A2C RID: 2604
	[Guid("00000101-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[__DynamicallyInvokable]
	[ComImport]
	public interface IEnumString
	{
		// Token: 0x06006625 RID: 26149
		[PreserveSig]
		int Next(int celt, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 0)] [Out] string[] rgelt, IntPtr pceltFetched);

		// Token: 0x06006626 RID: 26150
		[__DynamicallyInvokable]
		[PreserveSig]
		int Skip(int celt);

		// Token: 0x06006627 RID: 26151
		[__DynamicallyInvokable]
		void Reset();

		// Token: 0x06006628 RID: 26152
		[__DynamicallyInvokable]
		void Clone(out IEnumString ppenum);
	}
}
