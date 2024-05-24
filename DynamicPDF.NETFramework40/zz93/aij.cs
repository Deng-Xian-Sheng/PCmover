using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000523 RID: 1315
	internal abstract class aij : ahq
	{
		// Token: 0x0600351F RID: 13599 RVA: 0x001D3FE8 File Offset: 0x001D2FE8
		internal override bool l5(LayoutWriter A_0)
		{
			return ahq.a(this.l7(A_0));
		}

		// Token: 0x06003520 RID: 13600 RVA: 0x001D400C File Offset: 0x001D300C
		internal override bool lx(LayoutWriter A_0, akk A_1)
		{
			return ahq.a(this.lz(A_0, A_1));
		}

		// Token: 0x06003521 RID: 13601 RVA: 0x001D4030 File Offset: 0x001D3030
		internal override DateTime l6(LayoutWriter A_0)
		{
			return ahq.b(this.l7(A_0));
		}

		// Token: 0x06003522 RID: 13602 RVA: 0x001D4054 File Offset: 0x001D3054
		internal override DateTime ly(LayoutWriter A_0, akk A_1)
		{
			return ahq.b(this.lz(A_0, A_1));
		}

		// Token: 0x06003523 RID: 13603 RVA: 0x001D4078 File Offset: 0x001D3078
		internal override double l8(LayoutWriter A_0)
		{
			return ahq.d(this.l7(A_0));
		}

		// Token: 0x06003524 RID: 13604 RVA: 0x001D409C File Offset: 0x001D309C
		internal override double l0(LayoutWriter A_0, akk A_1)
		{
			return ahq.d(this.lz(A_0, A_1));
		}

		// Token: 0x06003525 RID: 13605 RVA: 0x001D40C0 File Offset: 0x001D30C0
		internal override int l9(LayoutWriter A_0)
		{
			return ahq.c(this.l7(A_0));
		}

		// Token: 0x06003526 RID: 13606 RVA: 0x001D40E4 File Offset: 0x001D30E4
		internal override int l1(LayoutWriter A_0, akk A_1)
		{
			return ahq.c(this.lz(A_0, A_1));
		}

		// Token: 0x06003527 RID: 13607 RVA: 0x001D4108 File Offset: 0x001D3108
		internal override object ma(LayoutWriter A_0)
		{
			return this.l7(A_0);
		}

		// Token: 0x06003528 RID: 13608 RVA: 0x001D4128 File Offset: 0x001D3128
		internal override object l2(LayoutWriter A_0, akk A_1)
		{
			return this.lz(A_0, A_1);
		}

		// Token: 0x06003529 RID: 13609 RVA: 0x001D4148 File Offset: 0x001D3148
		internal override string mb(LayoutWriter A_0)
		{
			return this.l7(A_0).ToString();
		}

		// Token: 0x0600352A RID: 13610 RVA: 0x001D416C File Offset: 0x001D316C
		internal override string l3(LayoutWriter A_0, akk A_1)
		{
			return this.lz(A_0, A_1).ToString();
		}
	}
}
