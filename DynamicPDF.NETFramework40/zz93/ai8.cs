using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200053C RID: 1340
	internal class ai8 : ail
	{
		// Token: 0x060035F1 RID: 13809 RVA: 0x001D72E8 File Offset: 0x001D62E8
		internal ai8(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			A_0.p();
			this.a = A_0.f();
			A_0.p();
			if (A_0.b() != ',')
			{
				throw new DlexParseException("Invalid Format function detected.");
			}
			A_0.a(A_0.d() + 1);
			A_0.p();
			if (A_0.b() != '"')
			{
				throw new DlexParseException("Invalid Format function detected.");
			}
			A_0.a(A_0.d() + 1);
			int num = A_0.d();
			A_0.q();
			this.b = new string(A_0.c(), num, A_0.d() - num);
			A_0.a(A_0.d() + 1);
			A_0.p();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid Format function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x060035F2 RID: 13810 RVA: 0x001D73E4 File Offset: 0x001D63E4
		private string a(LayoutWriter A_0, object A_1)
		{
			string result;
			if (A_1 != null)
			{
				if (A_1 is IFormattable)
				{
					IFormattable formattable = (IFormattable)A_1;
					result = formattable.ToString(this.b, A_0.DocumentLayout.FormatProvider);
				}
				else
				{
					result = A_1.ToString();
				}
			}
			else
			{
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x060035F3 RID: 13811 RVA: 0x001D7440 File Offset: 0x001D6440
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0);
		}

		// Token: 0x060035F4 RID: 13812 RVA: 0x001D7460 File Offset: 0x001D6460
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1);
		}

		// Token: 0x060035F5 RID: 13813 RVA: 0x001D7480 File Offset: 0x001D6480
		internal override string mb(LayoutWriter A_0)
		{
			return this.a(A_0, this.a.ma(A_0));
		}

		// Token: 0x060035F6 RID: 13814 RVA: 0x001D74A8 File Offset: 0x001D64A8
		internal override string l3(LayoutWriter A_0, akk A_1)
		{
			return this.a(A_0, this.a.l2(A_0, A_1));
		}

		// Token: 0x060035F7 RID: 13815 RVA: 0x001D74CE File Offset: 0x001D64CE
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
		}

		// Token: 0x060035F8 RID: 13816 RVA: 0x001D74D4 File Offset: 0x001D64D4
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 6 && (A_0[A_1 + 3] == 'm' || A_0[A_1 + 3] == 'M') && (A_0[A_1 + 4] == 'a' || A_0[A_1 + 4] == 'A') && (A_0[A_1 + 5] == 't' || A_0[A_1 + 5] == 'T') && (A_0[A_1] == 'F' || A_0[A_1] == 'f') && (A_0[A_1 + 1] == 'o' || A_0[A_1 + 1] == 'O') && (A_0[A_1 + 2] == 'r' || A_0[A_1 + 2] == 'R');
		}

		// Token: 0x040019BE RID: 6590
		private new ahq a;

		// Token: 0x040019BF RID: 6591
		private new string b;
	}
}
