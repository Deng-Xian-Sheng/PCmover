using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200052E RID: 1326
	internal class aiu : ait
	{
		// Token: 0x06003586 RID: 13702 RVA: 0x001D52D5 File Offset: 0x001D42D5
		internal aiu(string A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06003587 RID: 13703 RVA: 0x001D52E7 File Offset: 0x001D42E7
		internal aiu(string A_0, bool A_1)
		{
			A_0 = A_0.Trim();
			this.a = A_0;
		}

		// Token: 0x06003588 RID: 13704 RVA: 0x001D5304 File Offset: 0x001D4304
		internal override bool l4(LayoutWriter A_0)
		{
			object obj = A_0.Data.a(this.a);
			return obj is DBNull || obj == null;
		}

		// Token: 0x06003589 RID: 13705 RVA: 0x001D5338 File Offset: 0x001D4338
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return A_1.b() == null;
		}

		// Token: 0x0600358A RID: 13706 RVA: 0x001D5354 File Offset: 0x001D4354
		internal override object ma(LayoutWriter A_0)
		{
			return A_0.Data.a(this.a);
		}

		// Token: 0x0600358B RID: 13707 RVA: 0x001D5378 File Offset: 0x001D4378
		internal override object l2(LayoutWriter A_0, akk A_1)
		{
			object result;
			if (A_0.f())
			{
				result = A_1.c();
			}
			else
			{
				result = A_1.b();
			}
			return result;
		}

		// Token: 0x0600358C RID: 13708 RVA: 0x001D53A6 File Offset: 0x001D43A6
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			A_1.a(A_0.Data.a(this.a));
		}

		// Token: 0x040019A9 RID: 6569
		private new string a;
	}
}
