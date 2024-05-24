using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000556 RID: 1366
	internal class ajy : ail
	{
		// Token: 0x060036B5 RID: 14005 RVA: 0x001DBC90 File Offset: 0x001DAC90
		internal ajy(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			A_0.p();
			this.a = A_0.f();
			A_0.p();
			if (A_0.b() != ',')
			{
				throw new DlexParseException("Invalid Right function detected.");
			}
			A_0.a(A_0.d() + 1);
			this.b = A_0.l();
			A_0.p();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid Right function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x060036B6 RID: 14006 RVA: 0x001DBD34 File Offset: 0x001DAD34
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0);
		}

		// Token: 0x060036B7 RID: 14007 RVA: 0x001DBD54 File Offset: 0x001DAD54
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1);
		}

		// Token: 0x060036B8 RID: 14008 RVA: 0x001DBD74 File Offset: 0x001DAD74
		internal override string mb(LayoutWriter A_0)
		{
			string text = this.a.mb(A_0);
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

		// Token: 0x060036B9 RID: 14009 RVA: 0x001DBDC4 File Offset: 0x001DADC4
		internal override string l3(LayoutWriter A_0, akk A_1)
		{
			string text = this.a.l3(A_0, A_1);
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

		// Token: 0x060036BA RID: 14010 RVA: 0x001DBE13 File Offset: 0x001DAE13
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
		}

		// Token: 0x060036BB RID: 14011 RVA: 0x001DBE28 File Offset: 0x001DAE28
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 5 && (A_0[A_1 + 1] == 'i' || A_0[A_1 + 1] == 'I') && (A_0[A_1 + 2] == 'g' || A_0[A_1 + 2] == 'G') && (A_0[A_1 + 3] == 'h' || A_0[A_1 + 3] == 'H') && (A_0[A_1 + 4] == 't' || A_0[A_1 + 4] == 'T') && (A_0[A_1] == 'R' || A_0[A_1] == 'r');
		}

		// Token: 0x040019FC RID: 6652
		private new ahq a;

		// Token: 0x040019FD RID: 6653
		private new int b;
	}
}
