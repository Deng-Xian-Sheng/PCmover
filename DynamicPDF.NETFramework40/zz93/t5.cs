using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000302 RID: 770
	internal class t5 : t4
	{
		// Token: 0x06002203 RID: 8707 RVA: 0x00148AAC File Offset: 0x00147AAC
		internal t5(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			this.a = A_0.g();
			A_0.q();
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid Day function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x06002204 RID: 8708 RVA: 0x00148B14 File Offset: 0x00147B14
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0);
		}

		// Token: 0x06002205 RID: 8709 RVA: 0x00148B34 File Offset: 0x00147B34
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1);
		}

		// Token: 0x06002206 RID: 8710 RVA: 0x00148B54 File Offset: 0x00147B54
		internal override int em(LayoutWriter A_0)
		{
			return this.a.eg(A_0).Day;
		}

		// Token: 0x06002207 RID: 8711 RVA: 0x00148B7C File Offset: 0x00147B7C
		internal override int en(LayoutWriter A_0, vi A_1)
		{
			return this.a.eh(A_0, A_1).Day;
		}

		// Token: 0x06002208 RID: 8712 RVA: 0x00148BA3 File Offset: 0x00147BA3
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
		}

		// Token: 0x06002209 RID: 8713 RVA: 0x00148BB8 File Offset: 0x00147BB8
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 3 && (A_0[A_1 + 1] == 'a' || A_0[A_1 + 1] == 'A') && (A_0[A_1 + 2] == 'y' || A_0[A_1 + 2] == 'Y') && (A_0[A_1] == 'D' || A_0[A_1] == 'd');
		}

		// Token: 0x04000EC5 RID: 3781
		private new q7 a;
	}
}
