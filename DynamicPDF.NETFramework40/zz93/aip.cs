using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000529 RID: 1321
	internal abstract class aip : ahq
	{
		// Token: 0x06003550 RID: 13648 RVA: 0x001D4654 File Offset: 0x001D3654
		internal override bool l5(LayoutWriter A_0)
		{
			return ahq.a(this.l6(A_0));
		}

		// Token: 0x06003551 RID: 13649 RVA: 0x001D4678 File Offset: 0x001D3678
		internal override bool lx(LayoutWriter A_0, akk A_1)
		{
			return ahq.a(this.ly(A_0, A_1));
		}

		// Token: 0x06003552 RID: 13650 RVA: 0x001D469C File Offset: 0x001D369C
		internal override decimal l7(LayoutWriter A_0)
		{
			return ahq.e(this.l6(A_0));
		}

		// Token: 0x06003553 RID: 13651 RVA: 0x001D46C0 File Offset: 0x001D36C0
		internal override decimal lz(LayoutWriter A_0, akk A_1)
		{
			return ahq.e(this.ly(A_0, A_1));
		}

		// Token: 0x06003554 RID: 13652 RVA: 0x001D46E4 File Offset: 0x001D36E4
		internal override double l8(LayoutWriter A_0)
		{
			return ahq.d(this.l6(A_0));
		}

		// Token: 0x06003555 RID: 13653 RVA: 0x001D4708 File Offset: 0x001D3708
		internal override double l0(LayoutWriter A_0, akk A_1)
		{
			return ahq.d(this.ly(A_0, A_1));
		}

		// Token: 0x06003556 RID: 13654 RVA: 0x001D472C File Offset: 0x001D372C
		internal override int l9(LayoutWriter A_0)
		{
			return ahq.c(this.l6(A_0));
		}

		// Token: 0x06003557 RID: 13655 RVA: 0x001D4750 File Offset: 0x001D3750
		internal override int l1(LayoutWriter A_0, akk A_1)
		{
			return ahq.c(this.ly(A_0, A_1));
		}

		// Token: 0x06003558 RID: 13656 RVA: 0x001D4774 File Offset: 0x001D3774
		internal override object ma(LayoutWriter A_0)
		{
			return this.l6(A_0);
		}

		// Token: 0x06003559 RID: 13657 RVA: 0x001D4794 File Offset: 0x001D3794
		internal override object l2(LayoutWriter A_0, akk A_1)
		{
			return this.ly(A_0, A_1);
		}

		// Token: 0x0600355A RID: 13658 RVA: 0x001D47B4 File Offset: 0x001D37B4
		internal override string mb(LayoutWriter A_0)
		{
			return this.l6(A_0).ToString();
		}

		// Token: 0x0600355B RID: 13659 RVA: 0x001D47DC File Offset: 0x001D37DC
		internal override string l3(LayoutWriter A_0, akk A_1)
		{
			return this.ly(A_0, A_1).ToString();
		}
	}
}
