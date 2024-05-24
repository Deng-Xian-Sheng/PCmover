using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000306 RID: 774
	internal class t9 : to
	{
		// Token: 0x06002221 RID: 8737 RVA: 0x001492B0 File Offset: 0x001482B0
		internal t9(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			this.a = A_0.g();
			A_0.q();
			if (A_0.c() != ',')
			{
				throw new DplxParseException("Invalid Format function detected.");
			}
			A_0.a(A_0.e() + 1);
			A_0.q();
			if (A_0.c() != '"')
			{
				throw new DplxParseException("Invalid Format function detected.");
			}
			A_0.a(A_0.e() + 1);
			int num = A_0.e();
			A_0.r();
			this.b = new string(A_0.d(), num, A_0.e() - num);
			A_0.a(A_0.e() + 1);
			A_0.q();
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid Format function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x06002222 RID: 8738 RVA: 0x001493AC File Offset: 0x001483AC
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

		// Token: 0x06002223 RID: 8739 RVA: 0x00149408 File Offset: 0x00148408
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0);
		}

		// Token: 0x06002224 RID: 8740 RVA: 0x00149428 File Offset: 0x00148428
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1);
		}

		// Token: 0x06002225 RID: 8741 RVA: 0x00149448 File Offset: 0x00148448
		internal override string eo(LayoutWriter A_0)
		{
			return this.a(A_0, this.a.es(A_0));
		}

		// Token: 0x06002226 RID: 8742 RVA: 0x00149470 File Offset: 0x00148470
		internal override string ep(LayoutWriter A_0, vi A_1)
		{
			return this.a(A_0, this.a.et(A_0, A_1));
		}

		// Token: 0x06002227 RID: 8743 RVA: 0x00149496 File Offset: 0x00148496
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
		}

		// Token: 0x06002228 RID: 8744 RVA: 0x0014949C File Offset: 0x0014849C
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 6 && (A_0[A_1 + 3] == 'm' || A_0[A_1 + 3] == 'M') && (A_0[A_1 + 4] == 'a' || A_0[A_1 + 4] == 'A') && (A_0[A_1 + 5] == 't' || A_0[A_1 + 5] == 'T') && (A_0[A_1] == 'F' || A_0[A_1] == 'f') && (A_0[A_1 + 1] == 'o' || A_0[A_1 + 1] == 'O') && (A_0[A_1 + 2] == 'r' || A_0[A_1 + 2] == 'R');
		}

		// Token: 0x04000ECB RID: 3787
		private new q7 a;

		// Token: 0x04000ECC RID: 3788
		private new string b;
	}
}
