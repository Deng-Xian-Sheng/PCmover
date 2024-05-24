using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x0200030C RID: 780
	internal class uf : rc
	{
		// Token: 0x0600224E RID: 8782 RVA: 0x0014A3B4 File Offset: 0x001493B4
		internal uf(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			this.a = A_0.g();
			A_0.q();
			if (A_0.c() != ',')
			{
				this.b = null;
			}
			else
			{
				A_0.a(A_0.e() + 1);
				A_0.q();
				this.b = A_0.g();
			}
			A_0.q();
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid IsNull function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x0600224F RID: 8783 RVA: 0x0014A460 File Offset: 0x00149460
		internal override bool eq(LayoutWriter A_0)
		{
			bool result;
			if (this.b == null)
			{
				result = this.a.eq(A_0);
			}
			else if (this.a.eq(A_0))
			{
				result = this.b.eq(A_0);
			}
			else
			{
				result = this.a.eq(A_0);
			}
			return result;
		}

		// Token: 0x06002250 RID: 8784 RVA: 0x0014A4C4 File Offset: 0x001494C4
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			bool result;
			if (this.b == null)
			{
				result = this.a.er(A_0, A_1);
			}
			else if (this.a.er(A_0, A_1))
			{
				result = this.b.er(A_0, A_1);
			}
			else
			{
				result = this.a.er(A_0, A_1);
			}
			return result;
		}

		// Token: 0x06002251 RID: 8785 RVA: 0x0014A52C File Offset: 0x0014952C
		internal override bool ee(LayoutWriter A_0)
		{
			bool result;
			if (this.b == null)
			{
				result = this.a.eq(A_0);
			}
			else if (this.a.eq(A_0))
			{
				result = this.b.ee(A_0);
			}
			else
			{
				result = this.a.ee(A_0);
			}
			return result;
		}

		// Token: 0x06002252 RID: 8786 RVA: 0x0014A590 File Offset: 0x00149590
		internal override decimal ei(LayoutWriter A_0)
		{
			decimal result;
			if (this.b == null)
			{
				result = base.ei(A_0);
			}
			else if (this.a.eq(A_0))
			{
				result = this.b.ei(A_0);
			}
			else
			{
				result = this.a.ei(A_0);
			}
			return result;
		}

		// Token: 0x06002253 RID: 8787 RVA: 0x0014A5F0 File Offset: 0x001495F0
		internal override double ek(LayoutWriter A_0)
		{
			double result;
			if (this.b == null)
			{
				result = base.ek(A_0);
			}
			else if (this.a.eq(A_0))
			{
				result = this.b.ek(A_0);
			}
			else
			{
				result = this.a.ek(A_0);
			}
			return result;
		}

		// Token: 0x06002254 RID: 8788 RVA: 0x0014A650 File Offset: 0x00149650
		internal override int em(LayoutWriter A_0)
		{
			int result;
			if (this.b == null)
			{
				result = base.em(A_0);
			}
			else if (this.a.eq(A_0))
			{
				result = this.b.em(A_0);
			}
			else
			{
				result = this.a.em(A_0);
			}
			return result;
		}

		// Token: 0x06002255 RID: 8789 RVA: 0x0014A6B0 File Offset: 0x001496B0
		internal override object es(LayoutWriter A_0)
		{
			object result;
			if (this.b == null)
			{
				result = base.es(A_0);
			}
			else if (this.a.eq(A_0))
			{
				result = this.b.es(A_0);
			}
			else
			{
				result = this.a.es(A_0);
			}
			return result;
		}

		// Token: 0x06002256 RID: 8790 RVA: 0x0014A710 File Offset: 0x00149710
		internal override string eo(LayoutWriter A_0)
		{
			string result;
			if (this.b == null)
			{
				result = base.eo(A_0);
			}
			else if (this.a.eq(A_0))
			{
				result = this.b.eo(A_0);
			}
			else
			{
				result = this.a.eo(A_0);
			}
			return result;
		}

		// Token: 0x06002257 RID: 8791 RVA: 0x0014A770 File Offset: 0x00149770
		internal override bool ef(LayoutWriter A_0, vi A_1)
		{
			bool result;
			if (this.b == null)
			{
				result = this.a.er(A_0, A_1);
			}
			else if (this.a.er(A_0, A_1))
			{
				result = this.b.ef(A_0, A_1);
			}
			else
			{
				result = this.a.ef(A_0, A_1);
			}
			return result;
		}

		// Token: 0x06002258 RID: 8792 RVA: 0x0014A7D8 File Offset: 0x001497D8
		internal override decimal ej(LayoutWriter A_0, vi A_1)
		{
			decimal result;
			if (this.b == null)
			{
				result = base.ej(A_0, A_1);
			}
			else if (this.a.er(A_0, A_1))
			{
				result = this.b.ej(A_0, A_1);
			}
			else
			{
				result = this.a.ej(A_0, A_1);
			}
			return result;
		}

		// Token: 0x06002259 RID: 8793 RVA: 0x0014A83C File Offset: 0x0014983C
		internal override double el(LayoutWriter A_0, vi A_1)
		{
			double result;
			if (this.b == null)
			{
				result = base.el(A_0, A_1);
			}
			else if (this.a.er(A_0, A_1))
			{
				result = this.b.el(A_0, A_1);
			}
			else
			{
				result = this.a.el(A_0, A_1);
			}
			return result;
		}

		// Token: 0x0600225A RID: 8794 RVA: 0x0014A8A0 File Offset: 0x001498A0
		internal override int en(LayoutWriter A_0, vi A_1)
		{
			int result;
			if (this.b == null)
			{
				result = base.en(A_0, A_1);
			}
			else if (this.a.er(A_0, A_1))
			{
				result = this.b.en(A_0, A_1);
			}
			else
			{
				result = this.a.en(A_0, A_1);
			}
			return result;
		}

		// Token: 0x0600225B RID: 8795 RVA: 0x0014A904 File Offset: 0x00149904
		internal override object et(LayoutWriter A_0, vi A_1)
		{
			object result;
			if (this.b == null)
			{
				result = base.et(A_0, A_1);
			}
			else if (this.a.er(A_0, A_1))
			{
				result = this.b.et(A_0, A_1);
			}
			else
			{
				result = this.a.et(A_0, A_1);
			}
			return result;
		}

		// Token: 0x0600225C RID: 8796 RVA: 0x0014A968 File Offset: 0x00149968
		internal override string ep(LayoutWriter A_0, vi A_1)
		{
			string result;
			if (this.b == null)
			{
				result = base.ep(A_0, A_1);
			}
			else if (this.a.er(A_0, A_1))
			{
				result = this.b.ep(A_0, A_1);
			}
			else
			{
				result = this.a.ep(A_0, A_1);
			}
			return result;
		}

		// Token: 0x0600225D RID: 8797 RVA: 0x0014A9C9 File Offset: 0x001499C9
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
			this.b.eu(A_0, A_1, A_2);
		}

		// Token: 0x0600225E RID: 8798 RVA: 0x0014A9EC File Offset: 0x001499EC
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 6 && (A_0[A_1 + 1] == 's' || A_0[A_1 + 1] == 'S') && (A_0[A_1 + 2] == 'n' || A_0[A_1 + 2] == 'N') && (A_0[A_1 + 3] == 'u' || A_0[A_1 + 3] == 'U') && (A_0[A_1 + 4] == 'l' || A_0[A_1 + 4] == 'L') && (A_0[A_1 + 5] == 'l' || A_0[A_1 + 5] == 'L') && (A_0[A_1] == 'I' || A_0[A_1] == 'i');
		}

		// Token: 0x04000EDA RID: 3802
		private new q7 a;

		// Token: 0x04000EDB RID: 3803
		private new q7 b;
	}
}
