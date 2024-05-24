using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000312 RID: 786
	internal class ul : t4
	{
		// Token: 0x06002284 RID: 8836 RVA: 0x0014B444 File Offset: 0x0014A444
		internal ul(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			this.a = A_0.g();
			A_0.q();
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid Month function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x06002285 RID: 8837 RVA: 0x0014B4AC File Offset: 0x0014A4AC
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0);
		}

		// Token: 0x06002286 RID: 8838 RVA: 0x0014B4CC File Offset: 0x0014A4CC
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1);
		}

		// Token: 0x06002287 RID: 8839 RVA: 0x0014B4EC File Offset: 0x0014A4EC
		internal override int em(LayoutWriter A_0)
		{
			return this.a.eg(A_0).Month;
		}

		// Token: 0x06002288 RID: 8840 RVA: 0x0014B514 File Offset: 0x0014A514
		internal override int en(LayoutWriter A_0, vi A_1)
		{
			return this.a.eh(A_0, A_1).Month;
		}

		// Token: 0x06002289 RID: 8841 RVA: 0x0014B53B File Offset: 0x0014A53B
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
		}

		// Token: 0x0600228A RID: 8842 RVA: 0x0014B550 File Offset: 0x0014A550
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 5 && (A_0[A_1 + 1] == 'o' || A_0[A_1 + 1] == 'O') && (A_0[A_1 + 2] == 'n' || A_0[A_1 + 2] == 'N') && (A_0[A_1 + 3] == 't' || A_0[A_1 + 3] == 'T') && (A_0[A_1 + 4] == 'h' || A_0[A_1 + 4] == 'H') && (A_0[A_1] == 'M' || A_0[A_1] == 'm');
		}

		// Token: 0x04000EE4 RID: 3812
		private new q7 a;
	}
}
