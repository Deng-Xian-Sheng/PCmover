using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000542 RID: 1346
	internal class aje : aih
	{
		// Token: 0x0600361E RID: 13854 RVA: 0x001D83EC File Offset: 0x001D73EC
		internal aje(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			A_0.p();
			this.a = A_0.f();
			A_0.p();
			if (A_0.b() != ',')
			{
				this.b = null;
			}
			else
			{
				A_0.a(A_0.d() + 1);
				A_0.p();
				this.b = A_0.f();
			}
			A_0.p();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid IsNull function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x0600361F RID: 13855 RVA: 0x001D8498 File Offset: 0x001D7498
		internal override bool l4(LayoutWriter A_0)
		{
			bool result;
			if (this.b == null)
			{
				result = this.a.l4(A_0);
			}
			else if (this.a.l4(A_0))
			{
				result = this.b.l4(A_0);
			}
			else
			{
				result = this.a.l4(A_0);
			}
			return result;
		}

		// Token: 0x06003620 RID: 13856 RVA: 0x001D84FC File Offset: 0x001D74FC
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			bool result;
			if (this.b == null)
			{
				result = this.a.lw(A_0, A_1);
			}
			else if (this.a.lw(A_0, A_1))
			{
				result = this.b.lw(A_0, A_1);
			}
			else
			{
				result = this.a.lw(A_0, A_1);
			}
			return result;
		}

		// Token: 0x06003621 RID: 13857 RVA: 0x001D8564 File Offset: 0x001D7564
		internal override bool l5(LayoutWriter A_0)
		{
			bool result;
			if (this.b == null)
			{
				result = this.a.l4(A_0);
			}
			else if (this.a.l4(A_0))
			{
				result = this.b.l5(A_0);
			}
			else
			{
				result = this.a.l5(A_0);
			}
			return result;
		}

		// Token: 0x06003622 RID: 13858 RVA: 0x001D85C8 File Offset: 0x001D75C8
		internal override decimal l7(LayoutWriter A_0)
		{
			decimal result;
			if (this.b == null)
			{
				result = base.l7(A_0);
			}
			else if (this.a.l4(A_0))
			{
				result = this.b.l7(A_0);
			}
			else
			{
				result = this.a.l7(A_0);
			}
			return result;
		}

		// Token: 0x06003623 RID: 13859 RVA: 0x001D8628 File Offset: 0x001D7628
		internal override double l8(LayoutWriter A_0)
		{
			double result;
			if (this.b == null)
			{
				result = base.l8(A_0);
			}
			else if (this.a.l4(A_0))
			{
				result = this.b.l8(A_0);
			}
			else
			{
				result = this.a.l8(A_0);
			}
			return result;
		}

		// Token: 0x06003624 RID: 13860 RVA: 0x001D8688 File Offset: 0x001D7688
		internal override int l9(LayoutWriter A_0)
		{
			int result;
			if (this.b == null)
			{
				result = base.l9(A_0);
			}
			else if (this.a.l4(A_0))
			{
				result = this.b.l9(A_0);
			}
			else
			{
				result = this.a.l9(A_0);
			}
			return result;
		}

		// Token: 0x06003625 RID: 13861 RVA: 0x001D86E8 File Offset: 0x001D76E8
		internal override object ma(LayoutWriter A_0)
		{
			object result;
			if (this.b == null)
			{
				result = base.ma(A_0);
			}
			else if (this.a.l4(A_0))
			{
				result = this.b.ma(A_0);
			}
			else
			{
				result = this.a.ma(A_0);
			}
			return result;
		}

		// Token: 0x06003626 RID: 13862 RVA: 0x001D8748 File Offset: 0x001D7748
		internal override string mb(LayoutWriter A_0)
		{
			string result;
			if (this.b == null)
			{
				result = base.mb(A_0);
			}
			else if (this.a.l4(A_0))
			{
				result = this.b.mb(A_0);
			}
			else
			{
				result = this.a.mb(A_0);
			}
			return result;
		}

		// Token: 0x06003627 RID: 13863 RVA: 0x001D87A8 File Offset: 0x001D77A8
		internal override bool lx(LayoutWriter A_0, akk A_1)
		{
			bool result;
			if (this.b == null)
			{
				result = this.a.lw(A_0, A_1);
			}
			else if (this.a.lw(A_0, A_1))
			{
				result = this.b.lx(A_0, A_1);
			}
			else
			{
				result = this.a.lx(A_0, A_1);
			}
			return result;
		}

		// Token: 0x06003628 RID: 13864 RVA: 0x001D8810 File Offset: 0x001D7810
		internal override decimal lz(LayoutWriter A_0, akk A_1)
		{
			decimal result;
			if (this.b == null)
			{
				result = base.lz(A_0, A_1);
			}
			else if (this.a.lw(A_0, A_1))
			{
				result = this.b.lz(A_0, A_1);
			}
			else
			{
				result = this.a.lz(A_0, A_1);
			}
			return result;
		}

		// Token: 0x06003629 RID: 13865 RVA: 0x001D8874 File Offset: 0x001D7874
		internal override double l0(LayoutWriter A_0, akk A_1)
		{
			double result;
			if (this.b == null)
			{
				result = base.l0(A_0, A_1);
			}
			else if (this.a.lw(A_0, A_1))
			{
				result = this.b.l0(A_0, A_1);
			}
			else
			{
				result = this.a.l0(A_0, A_1);
			}
			return result;
		}

		// Token: 0x0600362A RID: 13866 RVA: 0x001D88D8 File Offset: 0x001D78D8
		internal override int l1(LayoutWriter A_0, akk A_1)
		{
			int result;
			if (this.b == null)
			{
				result = base.l1(A_0, A_1);
			}
			else if (this.a.lw(A_0, A_1))
			{
				result = this.b.l1(A_0, A_1);
			}
			else
			{
				result = this.a.l1(A_0, A_1);
			}
			return result;
		}

		// Token: 0x0600362B RID: 13867 RVA: 0x001D893C File Offset: 0x001D793C
		internal override object l2(LayoutWriter A_0, akk A_1)
		{
			object result;
			if (this.b == null)
			{
				result = base.l2(A_0, A_1);
			}
			else if (this.a.lw(A_0, A_1))
			{
				result = this.b.l2(A_0, A_1);
			}
			else
			{
				result = this.a.l2(A_0, A_1);
			}
			return result;
		}

		// Token: 0x0600362C RID: 13868 RVA: 0x001D89A0 File Offset: 0x001D79A0
		internal override string l3(LayoutWriter A_0, akk A_1)
		{
			string result;
			if (this.b == null)
			{
				result = base.l3(A_0, A_1);
			}
			else if (this.a.lw(A_0, A_1))
			{
				result = this.b.l3(A_0, A_1);
			}
			else
			{
				result = this.a.l3(A_0, A_1);
			}
			return result;
		}

		// Token: 0x0600362D RID: 13869 RVA: 0x001D8A01 File Offset: 0x001D7A01
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
			this.b.mc(A_0, A_1, A_2);
		}

		// Token: 0x0600362E RID: 13870 RVA: 0x001D8A24 File Offset: 0x001D7A24
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 6 && (A_0[A_1 + 1] == 's' || A_0[A_1 + 1] == 'S') && (A_0[A_1 + 2] == 'n' || A_0[A_1 + 2] == 'N') && (A_0[A_1 + 3] == 'u' || A_0[A_1 + 3] == 'U') && (A_0[A_1 + 4] == 'l' || A_0[A_1 + 4] == 'L') && (A_0[A_1 + 5] == 'l' || A_0[A_1 + 5] == 'L') && (A_0[A_1] == 'I' || A_0[A_1] == 'i');
		}

		// Token: 0x040019CD RID: 6605
		private new ahq a;

		// Token: 0x040019CE RID: 6606
		private new ahq b;
	}
}
