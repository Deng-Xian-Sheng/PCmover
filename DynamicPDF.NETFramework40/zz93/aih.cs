using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000521 RID: 1313
	internal abstract class aih : ahq
	{
		// Token: 0x0600350F RID: 13583 RVA: 0x001D3DC8 File Offset: 0x001D2DC8
		internal override DateTime l6(LayoutWriter A_0)
		{
			return ahq.b(this.l5(A_0));
		}

		// Token: 0x06003510 RID: 13584 RVA: 0x001D3DEC File Offset: 0x001D2DEC
		internal override DateTime ly(LayoutWriter A_0, akk A_1)
		{
			return ahq.b(this.lx(A_0, A_1));
		}

		// Token: 0x06003511 RID: 13585 RVA: 0x001D3E10 File Offset: 0x001D2E10
		internal override decimal l7(LayoutWriter A_0)
		{
			return ahq.e(this.l5(A_0));
		}

		// Token: 0x06003512 RID: 13586 RVA: 0x001D3E34 File Offset: 0x001D2E34
		internal override decimal lz(LayoutWriter A_0, akk A_1)
		{
			return ahq.e(this.lx(A_0, A_1));
		}

		// Token: 0x06003513 RID: 13587 RVA: 0x001D3E58 File Offset: 0x001D2E58
		internal override double l8(LayoutWriter A_0)
		{
			return ahq.d(this.l5(A_0));
		}

		// Token: 0x06003514 RID: 13588 RVA: 0x001D3E7C File Offset: 0x001D2E7C
		internal override double l0(LayoutWriter A_0, akk A_1)
		{
			return ahq.d(this.lx(A_0, A_1));
		}

		// Token: 0x06003515 RID: 13589 RVA: 0x001D3EA0 File Offset: 0x001D2EA0
		internal override int l9(LayoutWriter A_0)
		{
			return ahq.c(this.l5(A_0));
		}

		// Token: 0x06003516 RID: 13590 RVA: 0x001D3EC4 File Offset: 0x001D2EC4
		internal override int l1(LayoutWriter A_0, akk A_1)
		{
			return ahq.c(this.lx(A_0, A_1));
		}

		// Token: 0x06003517 RID: 13591 RVA: 0x001D3EE8 File Offset: 0x001D2EE8
		internal override object ma(LayoutWriter A_0)
		{
			return this.l5(A_0);
		}

		// Token: 0x06003518 RID: 13592 RVA: 0x001D3F08 File Offset: 0x001D2F08
		internal override object l2(LayoutWriter A_0, akk A_1)
		{
			return this.lx(A_0, A_1);
		}

		// Token: 0x06003519 RID: 13593 RVA: 0x001D3F28 File Offset: 0x001D2F28
		internal override string mb(LayoutWriter A_0)
		{
			return this.l5(A_0).ToString();
		}

		// Token: 0x0600351A RID: 13594 RVA: 0x001D3F4C File Offset: 0x001D2F4C
		internal override string l3(LayoutWriter A_0, akk A_1)
		{
			return this.lx(A_0, A_1).ToString();
		}
	}
}
