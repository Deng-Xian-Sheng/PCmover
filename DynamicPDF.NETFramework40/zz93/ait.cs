using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200052D RID: 1325
	internal abstract class ait : ahq
	{
		// Token: 0x06003579 RID: 13689 RVA: 0x001D5134 File Offset: 0x001D4134
		internal override bool l5(LayoutWriter A_0)
		{
			return ahq.a(this.ma(A_0));
		}

		// Token: 0x0600357A RID: 13690 RVA: 0x001D5154 File Offset: 0x001D4154
		internal override bool lx(LayoutWriter A_0, akk A_1)
		{
			return ahq.a(this.l2(A_0, A_1));
		}

		// Token: 0x0600357B RID: 13691 RVA: 0x001D5174 File Offset: 0x001D4174
		internal override DateTime l6(LayoutWriter A_0)
		{
			return ahq.b(this.ma(A_0));
		}

		// Token: 0x0600357C RID: 13692 RVA: 0x001D5194 File Offset: 0x001D4194
		internal override DateTime ly(LayoutWriter A_0, akk A_1)
		{
			return ahq.b(this.l2(A_0, A_1));
		}

		// Token: 0x0600357D RID: 13693 RVA: 0x001D51B4 File Offset: 0x001D41B4
		internal override decimal l7(LayoutWriter A_0)
		{
			return ahq.e(this.ma(A_0));
		}

		// Token: 0x0600357E RID: 13694 RVA: 0x001D51D4 File Offset: 0x001D41D4
		internal override decimal lz(LayoutWriter A_0, akk A_1)
		{
			return ahq.e(this.l2(A_0, A_1));
		}

		// Token: 0x0600357F RID: 13695 RVA: 0x001D51F4 File Offset: 0x001D41F4
		internal override double l8(LayoutWriter A_0)
		{
			return ahq.d(this.ma(A_0));
		}

		// Token: 0x06003580 RID: 13696 RVA: 0x001D5214 File Offset: 0x001D4214
		internal override double l0(LayoutWriter A_0, akk A_1)
		{
			return ahq.d(this.l2(A_0, A_1));
		}

		// Token: 0x06003581 RID: 13697 RVA: 0x001D5234 File Offset: 0x001D4234
		internal override int l9(LayoutWriter A_0)
		{
			return ahq.c(this.ma(A_0));
		}

		// Token: 0x06003582 RID: 13698 RVA: 0x001D5254 File Offset: 0x001D4254
		internal override int l1(LayoutWriter A_0, akk A_1)
		{
			return ahq.c(this.l2(A_0, A_1));
		}

		// Token: 0x06003583 RID: 13699 RVA: 0x001D5274 File Offset: 0x001D4274
		internal override string mb(LayoutWriter A_0)
		{
			object obj = this.ma(A_0);
			string result;
			if (obj != null)
			{
				result = obj.ToString();
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06003584 RID: 13700 RVA: 0x001D52A0 File Offset: 0x001D42A0
		internal override string l3(LayoutWriter A_0, akk A_1)
		{
			object obj = this.l2(A_0, A_1);
			string result;
			if (obj != null)
			{
				result = obj.ToString();
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
