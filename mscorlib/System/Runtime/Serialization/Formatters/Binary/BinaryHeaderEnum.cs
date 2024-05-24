using System;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x02000767 RID: 1895
	[Serializable]
	internal enum BinaryHeaderEnum
	{
		// Token: 0x040024DE RID: 9438
		SerializedStreamHeader,
		// Token: 0x040024DF RID: 9439
		Object,
		// Token: 0x040024E0 RID: 9440
		ObjectWithMap,
		// Token: 0x040024E1 RID: 9441
		ObjectWithMapAssemId,
		// Token: 0x040024E2 RID: 9442
		ObjectWithMapTyped,
		// Token: 0x040024E3 RID: 9443
		ObjectWithMapTypedAssemId,
		// Token: 0x040024E4 RID: 9444
		ObjectString,
		// Token: 0x040024E5 RID: 9445
		Array,
		// Token: 0x040024E6 RID: 9446
		MemberPrimitiveTyped,
		// Token: 0x040024E7 RID: 9447
		MemberReference,
		// Token: 0x040024E8 RID: 9448
		ObjectNull,
		// Token: 0x040024E9 RID: 9449
		MessageEnd,
		// Token: 0x040024EA RID: 9450
		Assembly,
		// Token: 0x040024EB RID: 9451
		ObjectNullMultiple256,
		// Token: 0x040024EC RID: 9452
		ObjectNullMultiple,
		// Token: 0x040024ED RID: 9453
		ArraySinglePrimitive,
		// Token: 0x040024EE RID: 9454
		ArraySingleObject,
		// Token: 0x040024EF RID: 9455
		ArraySingleString,
		// Token: 0x040024F0 RID: 9456
		CrossAppDomainMap,
		// Token: 0x040024F1 RID: 9457
		CrossAppDomainString,
		// Token: 0x040024F2 RID: 9458
		CrossAppDomainAssembly,
		// Token: 0x040024F3 RID: 9459
		MethodCall,
		// Token: 0x040024F4 RID: 9460
		MethodReturn
	}
}
