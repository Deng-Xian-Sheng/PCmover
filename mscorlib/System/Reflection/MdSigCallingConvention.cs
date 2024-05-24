using System;

namespace System.Reflection
{
	// Token: 0x020005F6 RID: 1526
	[Flags]
	[Serializable]
	internal enum MdSigCallingConvention : byte
	{
		// Token: 0x04001CFE RID: 7422
		CallConvMask = 15,
		// Token: 0x04001CFF RID: 7423
		Default = 0,
		// Token: 0x04001D00 RID: 7424
		C = 1,
		// Token: 0x04001D01 RID: 7425
		StdCall = 2,
		// Token: 0x04001D02 RID: 7426
		ThisCall = 3,
		// Token: 0x04001D03 RID: 7427
		FastCall = 4,
		// Token: 0x04001D04 RID: 7428
		Vararg = 5,
		// Token: 0x04001D05 RID: 7429
		Field = 6,
		// Token: 0x04001D06 RID: 7430
		LocalSig = 7,
		// Token: 0x04001D07 RID: 7431
		Property = 8,
		// Token: 0x04001D08 RID: 7432
		Unmgd = 9,
		// Token: 0x04001D09 RID: 7433
		GenericInst = 10,
		// Token: 0x04001D0A RID: 7434
		Generic = 16,
		// Token: 0x04001D0B RID: 7435
		HasThis = 32,
		// Token: 0x04001D0C RID: 7436
		ExplicitThis = 64
	}
}
