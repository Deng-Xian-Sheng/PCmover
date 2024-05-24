using System;

namespace System.Runtime.InteropServices.ComTypes
{
	// Token: 0x02000A40 RID: 2624
	[Flags]
	[__DynamicallyInvokable]
	[Serializable]
	public enum PARAMFLAG : short
	{
		// Token: 0x04002DA2 RID: 11682
		[__DynamicallyInvokable]
		PARAMFLAG_NONE = 0,
		// Token: 0x04002DA3 RID: 11683
		[__DynamicallyInvokable]
		PARAMFLAG_FIN = 1,
		// Token: 0x04002DA4 RID: 11684
		[__DynamicallyInvokable]
		PARAMFLAG_FOUT = 2,
		// Token: 0x04002DA5 RID: 11685
		[__DynamicallyInvokable]
		PARAMFLAG_FLCID = 4,
		// Token: 0x04002DA6 RID: 11686
		[__DynamicallyInvokable]
		PARAMFLAG_FRETVAL = 8,
		// Token: 0x04002DA7 RID: 11687
		[__DynamicallyInvokable]
		PARAMFLAG_FOPT = 16,
		// Token: 0x04002DA8 RID: 11688
		[__DynamicallyInvokable]
		PARAMFLAG_FHASDEFAULT = 32,
		// Token: 0x04002DA9 RID: 11689
		[__DynamicallyInvokable]
		PARAMFLAG_FHASCUSTDATA = 64
	}
}
