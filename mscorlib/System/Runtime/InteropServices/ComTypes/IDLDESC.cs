using System;

namespace System.Runtime.InteropServices.ComTypes
{
	// Token: 0x02000A3F RID: 2623
	[__DynamicallyInvokable]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct IDLDESC
	{
		// Token: 0x04002D9F RID: 11679
		public IntPtr dwReserved;

		// Token: 0x04002DA0 RID: 11680
		[__DynamicallyInvokable]
		public IDLFLAG wIDLFlags;
	}
}
