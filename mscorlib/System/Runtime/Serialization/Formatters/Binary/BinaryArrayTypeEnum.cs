using System;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x02000769 RID: 1897
	[Serializable]
	internal enum BinaryArrayTypeEnum
	{
		// Token: 0x040024FF RID: 9471
		Single,
		// Token: 0x04002500 RID: 9472
		Jagged,
		// Token: 0x04002501 RID: 9473
		Rectangular,
		// Token: 0x04002502 RID: 9474
		SingleOffset,
		// Token: 0x04002503 RID: 9475
		JaggedOffset,
		// Token: 0x04002504 RID: 9476
		RectangularOffset
	}
}
