using System;

namespace System.Runtime.InteropServices.ComTypes
{
	// Token: 0x02000A29 RID: 2601
	[__DynamicallyInvokable]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CONNECTDATA
	{
		// Token: 0x04002D42 RID: 11586
		[__DynamicallyInvokable]
		[MarshalAs(UnmanagedType.Interface)]
		public object pUnk;

		// Token: 0x04002D43 RID: 11587
		[__DynamicallyInvokable]
		public int dwCookie;
	}
}
