using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000481 RID: 1153
	internal enum TraceLoggingDataType
	{
		// Token: 0x04001868 RID: 6248
		Nil,
		// Token: 0x04001869 RID: 6249
		Utf16String,
		// Token: 0x0400186A RID: 6250
		MbcsString,
		// Token: 0x0400186B RID: 6251
		Int8,
		// Token: 0x0400186C RID: 6252
		UInt8,
		// Token: 0x0400186D RID: 6253
		Int16,
		// Token: 0x0400186E RID: 6254
		UInt16,
		// Token: 0x0400186F RID: 6255
		Int32,
		// Token: 0x04001870 RID: 6256
		UInt32,
		// Token: 0x04001871 RID: 6257
		Int64,
		// Token: 0x04001872 RID: 6258
		UInt64,
		// Token: 0x04001873 RID: 6259
		Float,
		// Token: 0x04001874 RID: 6260
		Double,
		// Token: 0x04001875 RID: 6261
		Boolean32,
		// Token: 0x04001876 RID: 6262
		Binary,
		// Token: 0x04001877 RID: 6263
		Guid,
		// Token: 0x04001878 RID: 6264
		FileTime = 17,
		// Token: 0x04001879 RID: 6265
		SystemTime,
		// Token: 0x0400187A RID: 6266
		HexInt32 = 20,
		// Token: 0x0400187B RID: 6267
		HexInt64,
		// Token: 0x0400187C RID: 6268
		CountedUtf16String,
		// Token: 0x0400187D RID: 6269
		CountedMbcsString,
		// Token: 0x0400187E RID: 6270
		Struct,
		// Token: 0x0400187F RID: 6271
		Char16 = 518,
		// Token: 0x04001880 RID: 6272
		Char8 = 516,
		// Token: 0x04001881 RID: 6273
		Boolean8 = 772,
		// Token: 0x04001882 RID: 6274
		HexInt8 = 1028,
		// Token: 0x04001883 RID: 6275
		HexInt16 = 1030,
		// Token: 0x04001884 RID: 6276
		Utf16Xml = 2817,
		// Token: 0x04001885 RID: 6277
		MbcsXml,
		// Token: 0x04001886 RID: 6278
		CountedUtf16Xml = 2838,
		// Token: 0x04001887 RID: 6279
		CountedMbcsXml,
		// Token: 0x04001888 RID: 6280
		Utf16Json = 3073,
		// Token: 0x04001889 RID: 6281
		MbcsJson,
		// Token: 0x0400188A RID: 6282
		CountedUtf16Json = 3094,
		// Token: 0x0400188B RID: 6283
		CountedMbcsJson,
		// Token: 0x0400188C RID: 6284
		HResult = 3847
	}
}
