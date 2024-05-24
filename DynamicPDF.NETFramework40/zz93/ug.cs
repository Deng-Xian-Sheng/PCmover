using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x0200030D RID: 781
	internal class ug : to
	{
		// Token: 0x0600225F RID: 8799 RVA: 0x0014AA74 File Offset: 0x00149A74
		internal ug(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			this.a = A_0.g();
			A_0.q();
			if (A_0.c() != ',')
			{
				throw new DplxParseException("Invalid Left function detected.");
			}
			A_0.a(A_0.e() + 1);
			this.b = A_0.m();
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid Left function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x06002260 RID: 8800 RVA: 0x0014AB10 File Offset: 0x00149B10
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0);
		}

		// Token: 0x06002261 RID: 8801 RVA: 0x0014AB30 File Offset: 0x00149B30
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1);
		}

		// Token: 0x06002262 RID: 8802 RVA: 0x0014AB50 File Offset: 0x00149B50
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
				result = text.Substring(0, this.b);
			}
			return result;
		}

		// Token: 0x06002263 RID: 8803 RVA: 0x0014AB94 File Offset: 0x00149B94
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
				result = text.Substring(0, this.b);
			}
			return result;
		}

		// Token: 0x06002264 RID: 8804 RVA: 0x0014ABD7 File Offset: 0x00149BD7
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
		}

		// Token: 0x06002265 RID: 8805 RVA: 0x0014ABEC File Offset: 0x00149BEC
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 4 && (A_0[A_1 + 1] == 'e' || A_0[A_1 + 1] == 'E') && (A_0[A_1 + 2] == 'f' || A_0[A_1 + 2] == 'F') && (A_0[A_1 + 3] == 't' || A_0[A_1 + 3] == 'T') && (A_0[A_1] == 'L' || A_0[A_1] == 'l');
		}

		// Token: 0x04000EDC RID: 3804
		private new q7 a;

		// Token: 0x04000EDD RID: 3805
		private new int b;
	}
}
