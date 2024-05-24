using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000922 RID: 2338
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum TypeLibTypeFlags
	{
		// Token: 0x04002A76 RID: 10870
		FAppObject = 1,
		// Token: 0x04002A77 RID: 10871
		FCanCreate = 2,
		// Token: 0x04002A78 RID: 10872
		FLicensed = 4,
		// Token: 0x04002A79 RID: 10873
		FPreDeclId = 8,
		// Token: 0x04002A7A RID: 10874
		FHidden = 16,
		// Token: 0x04002A7B RID: 10875
		FControl = 32,
		// Token: 0x04002A7C RID: 10876
		FDual = 64,
		// Token: 0x04002A7D RID: 10877
		FNonExtensible = 128,
		// Token: 0x04002A7E RID: 10878
		FOleAutomation = 256,
		// Token: 0x04002A7F RID: 10879
		FRestricted = 512,
		// Token: 0x04002A80 RID: 10880
		FAggregatable = 1024,
		// Token: 0x04002A81 RID: 10881
		FReplaceable = 2048,
		// Token: 0x04002A82 RID: 10882
		FDispatchable = 4096,
		// Token: 0x04002A83 RID: 10883
		FReverseBind = 8192
	}
}
