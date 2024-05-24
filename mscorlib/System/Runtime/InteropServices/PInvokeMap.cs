using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000952 RID: 2386
	[Serializable]
	internal enum PInvokeMap
	{
		// Token: 0x04002B60 RID: 11104
		NoMangle = 1,
		// Token: 0x04002B61 RID: 11105
		CharSetMask = 6,
		// Token: 0x04002B62 RID: 11106
		CharSetNotSpec = 0,
		// Token: 0x04002B63 RID: 11107
		CharSetAnsi = 2,
		// Token: 0x04002B64 RID: 11108
		CharSetUnicode = 4,
		// Token: 0x04002B65 RID: 11109
		CharSetAuto = 6,
		// Token: 0x04002B66 RID: 11110
		PinvokeOLE = 32,
		// Token: 0x04002B67 RID: 11111
		SupportsLastError = 64,
		// Token: 0x04002B68 RID: 11112
		BestFitMask = 48,
		// Token: 0x04002B69 RID: 11113
		BestFitEnabled = 16,
		// Token: 0x04002B6A RID: 11114
		BestFitDisabled = 32,
		// Token: 0x04002B6B RID: 11115
		BestFitUseAsm = 48,
		// Token: 0x04002B6C RID: 11116
		ThrowOnUnmappableCharMask = 12288,
		// Token: 0x04002B6D RID: 11117
		ThrowOnUnmappableCharEnabled = 4096,
		// Token: 0x04002B6E RID: 11118
		ThrowOnUnmappableCharDisabled = 8192,
		// Token: 0x04002B6F RID: 11119
		ThrowOnUnmappableCharUseAsm = 12288,
		// Token: 0x04002B70 RID: 11120
		CallConvMask = 1792,
		// Token: 0x04002B71 RID: 11121
		CallConvWinapi = 256,
		// Token: 0x04002B72 RID: 11122
		CallConvCdecl = 512,
		// Token: 0x04002B73 RID: 11123
		CallConvStdcall = 768,
		// Token: 0x04002B74 RID: 11124
		CallConvThiscall = 1024,
		// Token: 0x04002B75 RID: 11125
		CallConvFastcall = 1280
	}
}
