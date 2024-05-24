using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000923 RID: 2339
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum TypeLibFuncFlags
	{
		// Token: 0x04002A85 RID: 10885
		FRestricted = 1,
		// Token: 0x04002A86 RID: 10886
		FSource = 2,
		// Token: 0x04002A87 RID: 10887
		FBindable = 4,
		// Token: 0x04002A88 RID: 10888
		FRequestEdit = 8,
		// Token: 0x04002A89 RID: 10889
		FDisplayBind = 16,
		// Token: 0x04002A8A RID: 10890
		FDefaultBind = 32,
		// Token: 0x04002A8B RID: 10891
		FHidden = 64,
		// Token: 0x04002A8C RID: 10892
		FUsesGetLastError = 128,
		// Token: 0x04002A8D RID: 10893
		FDefaultCollelem = 256,
		// Token: 0x04002A8E RID: 10894
		FUiDefault = 512,
		// Token: 0x04002A8F RID: 10895
		FNonBrowsable = 1024,
		// Token: 0x04002A90 RID: 10896
		FReplaceable = 2048,
		// Token: 0x04002A91 RID: 10897
		FImmediateBind = 4096
	}
}
