using System;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x02000768 RID: 1896
	[Serializable]
	internal enum BinaryTypeEnum
	{
		// Token: 0x040024F6 RID: 9462
		Primitive,
		// Token: 0x040024F7 RID: 9463
		String,
		// Token: 0x040024F8 RID: 9464
		Object,
		// Token: 0x040024F9 RID: 9465
		ObjectUrt,
		// Token: 0x040024FA RID: 9466
		ObjectUser,
		// Token: 0x040024FB RID: 9467
		ObjectArray,
		// Token: 0x040024FC RID: 9468
		StringArray,
		// Token: 0x040024FD RID: 9469
		PrimitiveArray
	}
}
