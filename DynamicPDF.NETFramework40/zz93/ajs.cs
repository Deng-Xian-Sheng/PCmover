using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000550 RID: 1360
	internal class ajs : ait
	{
		// Token: 0x06003692 RID: 13970 RVA: 0x001DA9B4 File Offset: 0x001D99B4
		internal ajs(ArrayList A_0)
		{
			this.b = (ahq)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
			this.a = (ahq)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x06003693 RID: 13971 RVA: 0x001DAA1C File Offset: 0x001D9A1C
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0) || this.b.l4(A_0);
		}

		// Token: 0x06003694 RID: 13972 RVA: 0x001DAA4C File Offset: 0x001D9A4C
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1) || this.b.lw(A_0, A_1);
		}

		// Token: 0x06003695 RID: 13973 RVA: 0x001DAA80 File Offset: 0x001D9A80
		internal override object ma(LayoutWriter A_0)
		{
			object obj = this.a.ma(A_0);
			object obj2 = this.b.ma(A_0);
			object result;
			if (obj is string || obj2 is string)
			{
				result = obj + obj2;
			}
			else
			{
				result = decimal.Add(ahq.e(obj), ahq.e(obj2));
			}
			return result;
		}

		// Token: 0x06003696 RID: 13974 RVA: 0x001DAAEC File Offset: 0x001D9AEC
		internal override object l2(LayoutWriter A_0, akk A_1)
		{
			object obj = this.a.l2(A_0, A_1);
			object obj2 = this.b.l2(A_0, A_1);
			object result;
			if (obj is string || obj2 is string)
			{
				result = obj + obj2;
			}
			else
			{
				result = decimal.Add(ahq.e(obj), ahq.e(obj2));
			}
			return result;
		}

		// Token: 0x06003697 RID: 13975 RVA: 0x001DAB58 File Offset: 0x001D9B58
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
			this.b.mc(A_0, A_1, A_2);
		}

		// Token: 0x040019E7 RID: 6631
		private new ahq a;

		// Token: 0x040019E8 RID: 6632
		private new ahq b;
	}
}
