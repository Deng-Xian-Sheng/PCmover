using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x0200039D RID: 925
	internal class x8 : ColorSpace
	{
		// Token: 0x0600277E RID: 10110 RVA: 0x0016B04C File Offset: 0x0016A04C
		internal x8(byte[] A_0)
		{
			this.a = A_0;
		}

		// Token: 0x0600277F RID: 10111 RVA: 0x0016B05E File Offset: 0x0016A05E
		public override void DrawName(PageWriter writer)
		{
			writer.WriteName(this.a);
		}

		// Token: 0x06002780 RID: 10112 RVA: 0x0016B06E File Offset: 0x0016A06E
		public override void DrawColorSpace(DocumentWriter writer)
		{
			writer.WriteName(this.a);
		}

		// Token: 0x04001118 RID: 4376
		private new byte[] a;
	}
}
