using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x0200031B RID: 795
	internal class uu : to
	{
		// Token: 0x060022BF RID: 8895 RVA: 0x0014D0CC File Offset: 0x0014C0CC
		internal uu(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			this.a = A_0.g();
			A_0.q();
			if (A_0.c() != ',')
			{
				throw new DplxParseException("Invalid Right function detected.");
			}
			A_0.a(A_0.e() + 1);
			this.b = A_0.m();
			A_0.q();
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid Right function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x060022C0 RID: 8896 RVA: 0x0014D170 File Offset: 0x0014C170
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0);
		}

		// Token: 0x060022C1 RID: 8897 RVA: 0x0014D190 File Offset: 0x0014C190
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1);
		}

		// Token: 0x060022C2 RID: 8898 RVA: 0x0014D1B0 File Offset: 0x0014C1B0
		internal override string eo(LayoutWriter A_0)
		{
			string text = this.a.eo(A_0);
			string result;
			if (text.Length <= this.b)
			{
				result = text;
			}
			else
			{
				result = text.Substring(text.Length - this.b, this.b);
			}
			return result;
		}

		// Token: 0x060022C3 RID: 8899 RVA: 0x0014D200 File Offset: 0x0014C200
		internal override string ep(LayoutWriter A_0, vi A_1)
		{
			string text = this.a.ep(A_0, A_1);
			string result;
			if (text.Length <= this.b)
			{
				result = text;
			}
			else
			{
				result = text.Substring(text.Length - this.b, this.b);
			}
			return result;
		}

		// Token: 0x060022C4 RID: 8900 RVA: 0x0014D24F File Offset: 0x0014C24F
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
		}

		// Token: 0x060022C5 RID: 8901 RVA: 0x0014D264 File Offset: 0x0014C264
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 5 && (A_0[A_1 + 1] == 'i' || A_0[A_1 + 1] == 'I') && (A_0[A_1 + 2] == 'g' || A_0[A_1 + 2] == 'G') && (A_0[A_1 + 3] == 'h' || A_0[A_1 + 3] == 'H') && (A_0[A_1 + 4] == 't' || A_0[A_1 + 4] == 'T') && (A_0[A_1] == 'R' || A_0[A_1] == 'r');
		}

		// Token: 0x04000F00 RID: 3840
		private new q7 a;

		// Token: 0x04000F01 RID: 3841
		private new int b;
	}
}
