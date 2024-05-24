using System;

namespace System.Runtime.InteropServices.ComTypes
{
	// Token: 0x02000A43 RID: 2627
	[__DynamicallyInvokable]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct ELEMDESC
	{
		// Token: 0x04002DAE RID: 11694
		[__DynamicallyInvokable]
		public TYPEDESC tdesc;

		// Token: 0x04002DAF RID: 11695
		[__DynamicallyInvokable]
		public ELEMDESC.DESCUNION desc;

		// Token: 0x02000CA8 RID: 3240
		[__DynamicallyInvokable]
		[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
		public struct DESCUNION
		{
			// Token: 0x04003885 RID: 14469
			[__DynamicallyInvokable]
			[FieldOffset(0)]
			public IDLDESC idldesc;

			// Token: 0x04003886 RID: 14470
			[__DynamicallyInvokable]
			[FieldOffset(0)]
			public PARAMDESC paramdesc;
		}
	}
}
