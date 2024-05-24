using System;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x0200076C RID: 1900
	[Serializable]
	internal enum InternalParseTypeE
	{
		// Token: 0x0400250D RID: 9485
		Empty,
		// Token: 0x0400250E RID: 9486
		SerializedStreamHeader,
		// Token: 0x0400250F RID: 9487
		Object,
		// Token: 0x04002510 RID: 9488
		Member,
		// Token: 0x04002511 RID: 9489
		ObjectEnd,
		// Token: 0x04002512 RID: 9490
		MemberEnd,
		// Token: 0x04002513 RID: 9491
		Headers,
		// Token: 0x04002514 RID: 9492
		HeadersEnd,
		// Token: 0x04002515 RID: 9493
		SerializedStreamHeaderEnd,
		// Token: 0x04002516 RID: 9494
		Envelope,
		// Token: 0x04002517 RID: 9495
		EnvelopeEnd,
		// Token: 0x04002518 RID: 9496
		Body,
		// Token: 0x04002519 RID: 9497
		BodyEnd
	}
}
