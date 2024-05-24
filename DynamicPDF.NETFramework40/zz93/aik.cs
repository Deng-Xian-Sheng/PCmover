using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000524 RID: 1316
	internal class aik : aij
	{
		// Token: 0x0600352C RID: 13612 RVA: 0x001D4198 File Offset: 0x001D3198
		internal aik(al5 A_0)
		{
			decimal d = (int)(A_0.b() - '0');
			A_0.n();
			while (A_0.o())
			{
				d *= 10m;
				d += (int)(A_0.b() - '0');
				A_0.n();
			}
			if (A_0.b() == '.')
			{
				A_0.n();
				int num = 1;
				while (A_0.o())
				{
					d *= 10m;
					d += (int)(A_0.b() - '0');
					num *= 10;
					A_0.n();
				}
				d /= num;
			}
			this.a = d;
		}

		// Token: 0x0600352D RID: 13613 RVA: 0x001D426C File Offset: 0x001D326C
		internal override bool l4(LayoutWriter A_0)
		{
			return false;
		}

		// Token: 0x0600352E RID: 13614 RVA: 0x001D4280 File Offset: 0x001D3280
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return false;
		}

		// Token: 0x0600352F RID: 13615 RVA: 0x001D4294 File Offset: 0x001D3294
		internal override decimal l7(LayoutWriter A_0)
		{
			return this.a;
		}

		// Token: 0x06003530 RID: 13616 RVA: 0x001D42AC File Offset: 0x001D32AC
		internal override decimal lz(LayoutWriter A_0, akk A_1)
		{
			return this.a;
		}

		// Token: 0x06003531 RID: 13617 RVA: 0x001D42C4 File Offset: 0x001D32C4
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
		}

		// Token: 0x0400199C RID: 6556
		private new decimal a;
	}
}
