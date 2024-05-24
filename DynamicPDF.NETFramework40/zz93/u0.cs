using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000321 RID: 801
	internal class u0 : to
	{
		// Token: 0x060022E9 RID: 8937 RVA: 0x0014DBD0 File Offset: 0x0014CBD0
		internal u0(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			this.a = A_0.g();
			A_0.q();
			if (A_0.c() != ',')
			{
				throw new DplxParseException("Invalid SubString function detected.");
			}
			A_0.a(A_0.e() + 1);
			this.b = A_0.m();
			A_0.q();
			if (A_0.c() != ',')
			{
				throw new DplxParseException("Invalid SubString function detected.");
			}
			A_0.a(A_0.e() + 1);
			this.c = A_0.m();
			A_0.q();
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid SubString function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x060022EA RID: 8938 RVA: 0x0014DCB0 File Offset: 0x0014CCB0
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0);
		}

		// Token: 0x060022EB RID: 8939 RVA: 0x0014DCD0 File Offset: 0x0014CCD0
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1);
		}

		// Token: 0x060022EC RID: 8940 RVA: 0x0014DCF0 File Offset: 0x0014CCF0
		internal override string eo(LayoutWriter A_0)
		{
			string text = this.a.eo(A_0);
			string result;
			if (text.Length <= this.c && text.Length > this.b && text.Length >= this.b + this.c)
			{
				result = text;
			}
			else
			{
				result = text.Substring(this.b, this.c);
			}
			return result;
		}

		// Token: 0x060022ED RID: 8941 RVA: 0x0014DD60 File Offset: 0x0014CD60
		internal override string ep(LayoutWriter A_0, vi A_1)
		{
			string text = this.a.ep(A_0, A_1);
			string result;
			if (text.Length <= this.c && text.Length > this.b && text.Length >= this.b + this.c)
			{
				result = text;
			}
			else
			{
				result = text.Substring(this.b, this.c);
			}
			return result;
		}

		// Token: 0x060022EE RID: 8942 RVA: 0x0014DDCF File Offset: 0x0014CDCF
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
		}

		// Token: 0x060022EF RID: 8943 RVA: 0x0014DDE4 File Offset: 0x0014CDE4
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 9 && (A_0[A_1 + 1] == 'u' || A_0[A_1 + 1] == 'U') && (A_0[A_1 + 2] == 'b' || A_0[A_1 + 2] == 'B') && (A_0[A_1 + 3] == 's' || A_0[A_1 + 3] == 'S') && (A_0[A_1 + 4] == 't' || A_0[A_1 + 4] == 'T') && (A_0[A_1 + 5] == 'r' || A_0[A_1 + 5] == 'R') && (A_0[A_1 + 6] == 'i' || A_0[A_1 + 6] == 'I') && (A_0[A_1 + 7] == 'n' || A_0[A_1 + 7] == 'N') && (A_0[A_1 + 8] == 'g' || A_0[A_1 + 8] == 'G') && (A_0[A_1] == 'S' || A_0[A_1] == 's');
		}

		// Token: 0x04000F09 RID: 3849
		private new q7 a;

		// Token: 0x04000F0A RID: 3850
		private new int b;

		// Token: 0x04000F0B RID: 3851
		private new int c;
	}
}
