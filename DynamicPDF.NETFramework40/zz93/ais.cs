using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200052C RID: 1324
	internal class ais : aif
	{
		// Token: 0x06003577 RID: 13687 RVA: 0x001D50DF File Offset: 0x001D40DF
		internal ais(rv A_0, akk A_1, air A_2, alq A_3) : base(A_0, A_1)
		{
			this.a = A_2;
			this.b = A_3;
		}

		// Token: 0x06003578 RID: 13688 RVA: 0x001D50FB File Offset: 0x001D40FB
		internal override void mm(LayoutWriter A_0, bool A_1)
		{
			A_0.a(A_1);
			base.b().a(this.a.a(A_0, base.c(), this.b), A_1);
			A_0.a(false);
		}

		// Token: 0x040019A7 RID: 6567
		private air a;

		// Token: 0x040019A8 RID: 6568
		private alq b;
	}
}
