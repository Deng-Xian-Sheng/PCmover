using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000431 RID: 1073
	internal struct ManifestEnvelope
	{
		// Token: 0x040017D8 RID: 6104
		public const int MaxChunkSize = 65280;

		// Token: 0x040017D9 RID: 6105
		public ManifestEnvelope.ManifestFormats Format;

		// Token: 0x040017DA RID: 6106
		public byte MajorVersion;

		// Token: 0x040017DB RID: 6107
		public byte MinorVersion;

		// Token: 0x040017DC RID: 6108
		public byte Magic;

		// Token: 0x040017DD RID: 6109
		public ushort TotalChunks;

		// Token: 0x040017DE RID: 6110
		public ushort ChunkNumber;

		// Token: 0x02000B94 RID: 2964
		public enum ManifestFormats : byte
		{
			// Token: 0x0400351C RID: 13596
			SimpleXmlFormat = 1
		}
	}
}
