using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x02000433 RID: 1075
	internal class ab1 : c8
	{
		// Token: 0x06002C93 RID: 11411 RVA: 0x001974F0 File Offset: 0x001964F0
		internal ab1(PdfPage A_0) : base(A_0.a())
		{
			this.a = A_0;
		}

		// Token: 0x06002C94 RID: 11412 RVA: 0x00197508 File Offset: 0x00196508
		internal override PdfPage h8()
		{
			return this.a;
		}

		// Token: 0x06002C95 RID: 11413 RVA: 0x00197520 File Offset: 0x00196520
		internal override void bv(DocumentWriter A_0)
		{
			A_0.a(this.a);
		}

		// Token: 0x06002C96 RID: 11414 RVA: 0x00197530 File Offset: 0x00196530
		internal override void bw(DocumentWriter A_0)
		{
			A_0.a(this.a);
		}

		// Token: 0x040014F2 RID: 5362
		private PdfPage a;
	}
}
