using System;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x02000418 RID: 1048
	internal abstract class aba
	{
		// Token: 0x06002BB3 RID: 11187 RVA: 0x00193ADA File Offset: 0x00192ADA
		internal aba(PdfDocument A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06002BB4 RID: 11188 RVA: 0x00193AEC File Offset: 0x00192AEC
		internal PdfDocument af()
		{
			return this.a;
		}

		// Token: 0x06002BB5 RID: 11189
		internal abstract void lb();

		// Token: 0x06002BB6 RID: 11190 RVA: 0x00193B04 File Offset: 0x00192B04
		internal virtual void lr()
		{
		}

		// Token: 0x06002BB7 RID: 11191
		internal abstract abd ld(ab9 A_0);

		// Token: 0x06002BB8 RID: 11192 RVA: 0x00193B0C File Offset: 0x00192B0C
		internal virtual agu lc()
		{
			return null;
		}

		// Token: 0x06002BB9 RID: 11193 RVA: 0x00193B20 File Offset: 0x00192B20
		internal virtual agx lq()
		{
			return null;
		}

		// Token: 0x04001497 RID: 5271
		private PdfDocument a;
	}
}
