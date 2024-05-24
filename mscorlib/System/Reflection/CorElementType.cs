using System;

namespace System.Reflection
{
	// Token: 0x020005F5 RID: 1525
	[Serializable]
	internal enum CorElementType : byte
	{
		// Token: 0x04001CD9 RID: 7385
		End,
		// Token: 0x04001CDA RID: 7386
		Void,
		// Token: 0x04001CDB RID: 7387
		Boolean,
		// Token: 0x04001CDC RID: 7388
		Char,
		// Token: 0x04001CDD RID: 7389
		I1,
		// Token: 0x04001CDE RID: 7390
		U1,
		// Token: 0x04001CDF RID: 7391
		I2,
		// Token: 0x04001CE0 RID: 7392
		U2,
		// Token: 0x04001CE1 RID: 7393
		I4,
		// Token: 0x04001CE2 RID: 7394
		U4,
		// Token: 0x04001CE3 RID: 7395
		I8,
		// Token: 0x04001CE4 RID: 7396
		U8,
		// Token: 0x04001CE5 RID: 7397
		R4,
		// Token: 0x04001CE6 RID: 7398
		R8,
		// Token: 0x04001CE7 RID: 7399
		String,
		// Token: 0x04001CE8 RID: 7400
		Ptr,
		// Token: 0x04001CE9 RID: 7401
		ByRef,
		// Token: 0x04001CEA RID: 7402
		ValueType,
		// Token: 0x04001CEB RID: 7403
		Class,
		// Token: 0x04001CEC RID: 7404
		Var,
		// Token: 0x04001CED RID: 7405
		Array,
		// Token: 0x04001CEE RID: 7406
		GenericInst,
		// Token: 0x04001CEF RID: 7407
		TypedByRef,
		// Token: 0x04001CF0 RID: 7408
		I = 24,
		// Token: 0x04001CF1 RID: 7409
		U,
		// Token: 0x04001CF2 RID: 7410
		FnPtr = 27,
		// Token: 0x04001CF3 RID: 7411
		Object,
		// Token: 0x04001CF4 RID: 7412
		SzArray,
		// Token: 0x04001CF5 RID: 7413
		MVar,
		// Token: 0x04001CF6 RID: 7414
		CModReqd,
		// Token: 0x04001CF7 RID: 7415
		CModOpt,
		// Token: 0x04001CF8 RID: 7416
		Internal,
		// Token: 0x04001CF9 RID: 7417
		Max,
		// Token: 0x04001CFA RID: 7418
		Modifier = 64,
		// Token: 0x04001CFB RID: 7419
		Sentinel,
		// Token: 0x04001CFC RID: 7420
		Pinned = 69
	}
}
