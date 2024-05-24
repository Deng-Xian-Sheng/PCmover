using System;

namespace System.Reflection
{
	// Token: 0x020005D7 RID: 1495
	[Serializable]
	internal enum CustomAttributeEncoding
	{
		// Token: 0x04001C60 RID: 7264
		Undefined,
		// Token: 0x04001C61 RID: 7265
		Boolean = 2,
		// Token: 0x04001C62 RID: 7266
		Char,
		// Token: 0x04001C63 RID: 7267
		SByte,
		// Token: 0x04001C64 RID: 7268
		Byte,
		// Token: 0x04001C65 RID: 7269
		Int16,
		// Token: 0x04001C66 RID: 7270
		UInt16,
		// Token: 0x04001C67 RID: 7271
		Int32,
		// Token: 0x04001C68 RID: 7272
		UInt32,
		// Token: 0x04001C69 RID: 7273
		Int64,
		// Token: 0x04001C6A RID: 7274
		UInt64,
		// Token: 0x04001C6B RID: 7275
		Float,
		// Token: 0x04001C6C RID: 7276
		Double,
		// Token: 0x04001C6D RID: 7277
		String,
		// Token: 0x04001C6E RID: 7278
		Array = 29,
		// Token: 0x04001C6F RID: 7279
		Type = 80,
		// Token: 0x04001C70 RID: 7280
		Object,
		// Token: 0x04001C71 RID: 7281
		Field = 83,
		// Token: 0x04001C72 RID: 7282
		Property,
		// Token: 0x04001C73 RID: 7283
		Enum
	}
}
