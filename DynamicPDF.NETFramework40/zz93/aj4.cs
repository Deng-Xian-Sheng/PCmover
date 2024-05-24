using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200055C RID: 1372
	internal class aj4 : ail
	{
		// Token: 0x060036DF RID: 14047 RVA: 0x001DC794 File Offset: 0x001DB794
		internal aj4(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			A_0.p();
			this.a = A_0.f();
			A_0.p();
			if (A_0.b() != ',')
			{
				throw new DlexParseException("Invalid SubString function detected.");
			}
			A_0.a(A_0.d() + 1);
			this.b = A_0.l();
			A_0.p();
			if (A_0.b() != ',')
			{
				throw new DlexParseException("Invalid SubString function detected.");
			}
			A_0.a(A_0.d() + 1);
			this.c = A_0.l();
			A_0.p();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid SubString function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x060036E0 RID: 14048 RVA: 0x001DC874 File Offset: 0x001DB874
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0);
		}

		// Token: 0x060036E1 RID: 14049 RVA: 0x001DC894 File Offset: 0x001DB894
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1);
		}

		// Token: 0x060036E2 RID: 14050 RVA: 0x001DC8B4 File Offset: 0x001DB8B4
		internal override string mb(LayoutWriter A_0)
		{
			string text = this.a.mb(A_0);
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

		// Token: 0x060036E3 RID: 14051 RVA: 0x001DC924 File Offset: 0x001DB924
		internal override string l3(LayoutWriter A_0, akk A_1)
		{
			string text = this.a.l3(A_0, A_1);
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

		// Token: 0x060036E4 RID: 14052 RVA: 0x001DC993 File Offset: 0x001DB993
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
		}

		// Token: 0x060036E5 RID: 14053 RVA: 0x001DC9A8 File Offset: 0x001DB9A8
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 9 && (A_0[A_1 + 1] == 'u' || A_0[A_1 + 1] == 'U') && (A_0[A_1 + 2] == 'b' || A_0[A_1 + 2] == 'B') && (A_0[A_1 + 3] == 's' || A_0[A_1 + 3] == 'S') && (A_0[A_1 + 4] == 't' || A_0[A_1 + 4] == 'T') && (A_0[A_1 + 5] == 'r' || A_0[A_1 + 5] == 'R') && (A_0[A_1 + 6] == 'i' || A_0[A_1 + 6] == 'I') && (A_0[A_1 + 7] == 'n' || A_0[A_1 + 7] == 'N') && (A_0[A_1 + 8] == 'g' || A_0[A_1 + 8] == 'G') && (A_0[A_1] == 'S' || A_0[A_1] == 's');
		}

		// Token: 0x04001A05 RID: 6661
		private new ahq a;

		// Token: 0x04001A06 RID: 6662
		private new int b;

		// Token: 0x04001A07 RID: 6663
		private new int c;
	}
}
