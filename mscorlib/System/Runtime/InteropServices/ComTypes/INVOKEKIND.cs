using System;

namespace System.Runtime.InteropServices.ComTypes
{
	// Token: 0x02000A49 RID: 2633
	[Flags]
	[__DynamicallyInvokable]
	[Serializable]
	public enum INVOKEKIND
	{
		// Token: 0x04002DCF RID: 11727
		[__DynamicallyInvokable]
		INVOKE_FUNC = 1,
		// Token: 0x04002DD0 RID: 11728
		[__DynamicallyInvokable]
		INVOKE_PROPERTYGET = 2,
		// Token: 0x04002DD1 RID: 11729
		[__DynamicallyInvokable]
		INVOKE_PROPERTYPUT = 4,
		// Token: 0x04002DD2 RID: 11730
		[__DynamicallyInvokable]
		INVOKE_PROPERTYPUTREF = 8
	}
}
