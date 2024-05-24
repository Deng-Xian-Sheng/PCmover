using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000551 RID: 1361
	internal class ajt : aiq
	{
		// Token: 0x06003698 RID: 13976 RVA: 0x001DAB7C File Offset: 0x001D9B7C
		internal ajt(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			A_0.p();
			if (A_0.v())
			{
				this.a = A_0.g();
			}
			else
			{
				this.a = A_0.f();
			}
			A_0.p();
			if (A_0.b() != ',')
			{
				throw new DlexParseException("Invalid Add function detected.");
			}
			A_0.a(A_0.d() + 1);
			A_0.p();
			if (A_0.v())
			{
				this.b = A_0.g();
			}
			else
			{
				this.b = A_0.f();
			}
			A_0.p();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid Add function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x06003699 RID: 13977 RVA: 0x001DAC5C File Offset: 0x001D9C5C
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0) || this.b.l4(A_0);
		}

		// Token: 0x0600369A RID: 13978 RVA: 0x001DAC8C File Offset: 0x001D9C8C
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1) || this.b.lw(A_0, A_1);
		}

		// Token: 0x0600369B RID: 13979 RVA: 0x001DACC0 File Offset: 0x001D9CC0
		internal override double l8(LayoutWriter A_0)
		{
			return Math.Pow(this.a.l8(A_0), this.b.l8(A_0));
		}

		// Token: 0x0600369C RID: 13980 RVA: 0x001DACF0 File Offset: 0x001D9CF0
		internal override double l0(LayoutWriter A_0, akk A_1)
		{
			return Math.Pow(this.a.l0(A_0, A_1), this.b.l0(A_0, A_1));
		}

		// Token: 0x0600369D RID: 13981 RVA: 0x001DAD21 File Offset: 0x001D9D21
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
			this.b.mc(A_0, A_1, A_2);
		}

		// Token: 0x0600369E RID: 13982 RVA: 0x001DAD44 File Offset: 0x001D9D44
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 3 && (A_0[A_1 + 1] == 'o' || A_0[A_1 + 1] == 'O') && (A_0[A_1 + 2] == 'w' || A_0[A_1 + 2] == 'W') && (A_0[A_1] == 'P' || A_0[A_1] == 'p');
		}

		// Token: 0x040019E9 RID: 6633
		private new ahq a;

		// Token: 0x040019EA RID: 6634
		private new ahq b;
	}
}
