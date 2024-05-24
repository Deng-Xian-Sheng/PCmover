using System;

namespace System.Runtime.InteropServices.ComTypes
{
	// Token: 0x02000A3D RID: 2621
	[__DynamicallyInvokable]
	public struct FUNCDESC
	{
		// Token: 0x04002D8D RID: 11661
		[__DynamicallyInvokable]
		public int memid;

		// Token: 0x04002D8E RID: 11662
		public IntPtr lprgscode;

		// Token: 0x04002D8F RID: 11663
		public IntPtr lprgelemdescParam;

		// Token: 0x04002D90 RID: 11664
		[__DynamicallyInvokable]
		public FUNCKIND funckind;

		// Token: 0x04002D91 RID: 11665
		[__DynamicallyInvokable]
		public INVOKEKIND invkind;

		// Token: 0x04002D92 RID: 11666
		[__DynamicallyInvokable]
		public CALLCONV callconv;

		// Token: 0x04002D93 RID: 11667
		[__DynamicallyInvokable]
		public short cParams;

		// Token: 0x04002D94 RID: 11668
		[__DynamicallyInvokable]
		public short cParamsOpt;

		// Token: 0x04002D95 RID: 11669
		[__DynamicallyInvokable]
		public short oVft;

		// Token: 0x04002D96 RID: 11670
		[__DynamicallyInvokable]
		public short cScodes;

		// Token: 0x04002D97 RID: 11671
		[__DynamicallyInvokable]
		public ELEMDESC elemdescFunc;

		// Token: 0x04002D98 RID: 11672
		[__DynamicallyInvokable]
		public short wFuncFlags;
	}
}
