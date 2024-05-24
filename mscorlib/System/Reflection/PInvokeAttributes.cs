using System;

namespace System.Reflection
{
	// Token: 0x020005F7 RID: 1527
	[Flags]
	[Serializable]
	internal enum PInvokeAttributes
	{
		// Token: 0x04001D0E RID: 7438
		NoMangle = 1,
		// Token: 0x04001D0F RID: 7439
		CharSetMask = 6,
		// Token: 0x04001D10 RID: 7440
		CharSetNotSpec = 0,
		// Token: 0x04001D11 RID: 7441
		CharSetAnsi = 2,
		// Token: 0x04001D12 RID: 7442
		CharSetUnicode = 4,
		// Token: 0x04001D13 RID: 7443
		CharSetAuto = 6,
		// Token: 0x04001D14 RID: 7444
		BestFitUseAssem = 0,
		// Token: 0x04001D15 RID: 7445
		BestFitEnabled = 16,
		// Token: 0x04001D16 RID: 7446
		BestFitDisabled = 32,
		// Token: 0x04001D17 RID: 7447
		BestFitMask = 48,
		// Token: 0x04001D18 RID: 7448
		ThrowOnUnmappableCharUseAssem = 0,
		// Token: 0x04001D19 RID: 7449
		ThrowOnUnmappableCharEnabled = 4096,
		// Token: 0x04001D1A RID: 7450
		ThrowOnUnmappableCharDisabled = 8192,
		// Token: 0x04001D1B RID: 7451
		ThrowOnUnmappableCharMask = 12288,
		// Token: 0x04001D1C RID: 7452
		SupportsLastError = 64,
		// Token: 0x04001D1D RID: 7453
		CallConvMask = 1792,
		// Token: 0x04001D1E RID: 7454
		CallConvWinapi = 256,
		// Token: 0x04001D1F RID: 7455
		CallConvCdecl = 512,
		// Token: 0x04001D20 RID: 7456
		CallConvStdcall = 768,
		// Token: 0x04001D21 RID: 7457
		CallConvThiscall = 1024,
		// Token: 0x04001D22 RID: 7458
		CallConvFastcall = 1280,
		// Token: 0x04001D23 RID: 7459
		MaxValue = 65535
	}
}
