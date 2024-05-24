using System;

namespace System.Runtime.InteropServices.ComTypes
{
	// Token: 0x02000A45 RID: 2629
	[__DynamicallyInvokable]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct VARDESC
	{
		// Token: 0x04002DB5 RID: 11701
		[__DynamicallyInvokable]
		public int memid;

		// Token: 0x04002DB6 RID: 11702
		[__DynamicallyInvokable]
		public string lpstrSchema;

		// Token: 0x04002DB7 RID: 11703
		[__DynamicallyInvokable]
		public VARDESC.DESCUNION desc;

		// Token: 0x04002DB8 RID: 11704
		[__DynamicallyInvokable]
		public ELEMDESC elemdescVar;

		// Token: 0x04002DB9 RID: 11705
		[__DynamicallyInvokable]
		public short wVarFlags;

		// Token: 0x04002DBA RID: 11706
		[__DynamicallyInvokable]
		public VARKIND varkind;

		// Token: 0x02000CA9 RID: 3241
		[__DynamicallyInvokable]
		[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
		public struct DESCUNION
		{
			// Token: 0x04003887 RID: 14471
			[__DynamicallyInvokable]
			[FieldOffset(0)]
			public int oInst;

			// Token: 0x04003888 RID: 14472
			[FieldOffset(0)]
			public IntPtr lpvarValue;
		}
	}
}
