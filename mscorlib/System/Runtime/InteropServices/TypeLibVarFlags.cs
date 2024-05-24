using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000924 RID: 2340
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum TypeLibVarFlags
	{
		// Token: 0x04002A93 RID: 10899
		FReadOnly = 1,
		// Token: 0x04002A94 RID: 10900
		FSource = 2,
		// Token: 0x04002A95 RID: 10901
		FBindable = 4,
		// Token: 0x04002A96 RID: 10902
		FRequestEdit = 8,
		// Token: 0x04002A97 RID: 10903
		FDisplayBind = 16,
		// Token: 0x04002A98 RID: 10904
		FDefaultBind = 32,
		// Token: 0x04002A99 RID: 10905
		FHidden = 64,
		// Token: 0x04002A9A RID: 10906
		FRestricted = 128,
		// Token: 0x04002A9B RID: 10907
		FDefaultCollelem = 256,
		// Token: 0x04002A9C RID: 10908
		FUiDefault = 512,
		// Token: 0x04002A9D RID: 10909
		FNonBrowsable = 1024,
		// Token: 0x04002A9E RID: 10910
		FReplaceable = 2048,
		// Token: 0x04002A9F RID: 10911
		FImmediateBind = 4096
	}
}
