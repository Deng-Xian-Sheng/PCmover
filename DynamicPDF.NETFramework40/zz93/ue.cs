using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x0200030B RID: 779
	internal class ue : q8
	{
		// Token: 0x06002247 RID: 8775 RVA: 0x0014A0C0 File Offset: 0x001490C0
		internal ue(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			if (A_0.w())
			{
				this.a = A_0.h();
			}
			else
			{
				this.a = A_0.g();
			}
			A_0.q();
			if (A_0.c() != ',')
			{
				throw new DplxParseException("Invalid IIF function detected.");
			}
			A_0.a(A_0.e() + 1);
			A_0.q();
			this.b = A_0.g();
			if (A_0.c() != ',')
			{
				this.c = null;
			}
			else
			{
				A_0.a(A_0.e() + 1);
				A_0.q();
				this.c = A_0.g();
			}
			A_0.q();
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid IIF function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x06002248 RID: 8776 RVA: 0x0014A1C4 File Offset: 0x001491C4
		internal override bool eq(LayoutWriter A_0)
		{
			bool result;
			if (this.a.eq(A_0))
			{
				result = this.b.eq(A_0);
			}
			else
			{
				result = (this.c.eq(A_0) || this.c.eq(A_0));
			}
			return result;
		}

		// Token: 0x06002249 RID: 8777 RVA: 0x0014A220 File Offset: 0x00149220
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			bool result;
			if (this.a.er(A_0, A_1))
			{
				result = this.b.er(A_0, A_1);
			}
			else
			{
				result = (this.c.er(A_0, A_1) || this.c.er(A_0, A_1));
			}
			return result;
		}

		// Token: 0x0600224A RID: 8778 RVA: 0x0014A280 File Offset: 0x00149280
		internal override object es(LayoutWriter A_0)
		{
			object result;
			if (this.a.ee(A_0))
			{
				result = this.b.es(A_0);
			}
			else if (this.c == null)
			{
				result = null;
			}
			else
			{
				result = this.c.es(A_0);
			}
			return result;
		}

		// Token: 0x0600224B RID: 8779 RVA: 0x0014A2D8 File Offset: 0x001492D8
		internal override object et(LayoutWriter A_0, vi A_1)
		{
			object result;
			if (this.a.ef(A_0, A_1))
			{
				result = this.b.et(A_0, A_1);
			}
			else if (this.c == null)
			{
				result = null;
			}
			else
			{
				result = this.c.et(A_0, A_1);
			}
			return result;
		}

		// Token: 0x0600224C RID: 8780 RVA: 0x0014A333 File Offset: 0x00149333
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
			this.b.eu(A_0, A_1, A_2);
			this.c.eu(A_0, A_1, A_2);
		}

		// Token: 0x0600224D RID: 8781 RVA: 0x0014A364 File Offset: 0x00149364
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 3 && (A_0[A_1 + 1] == 'i' || A_0[A_1 + 1] == 'I') && (A_0[A_1 + 2] == 'f' || A_0[A_1 + 2] == 'F') && (A_0[A_1] == 'I' || A_0[A_1] == 'i');
		}

		// Token: 0x04000ED7 RID: 3799
		private new q7 a;

		// Token: 0x04000ED8 RID: 3800
		private new q7 b;

		// Token: 0x04000ED9 RID: 3801
		private new q7 c;
	}
}
