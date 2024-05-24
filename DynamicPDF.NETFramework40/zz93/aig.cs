using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000520 RID: 1312
	internal class aig
	{
		// Token: 0x0600350C RID: 13580 RVA: 0x001D3D2C File Offset: 0x001D2D2C
		internal aig()
		{
		}

		// Token: 0x0600350D RID: 13581 RVA: 0x001D3D48 File Offset: 0x001D2D48
		internal void a(aif A_0)
		{
			if (this.b == null)
			{
				this.b = A_0;
				this.a = A_0;
			}
			else
			{
				this.b.a(A_0);
				this.b = A_0;
			}
		}

		// Token: 0x0600350E RID: 13582 RVA: 0x001D3D94 File Offset: 0x001D2D94
		internal void a(LayoutWriter A_0, bool A_1)
		{
			for (aif aif = this.a; aif != null; aif = aif.a())
			{
				aif.mm(A_0, A_1);
			}
		}

		// Token: 0x04001999 RID: 6553
		private aif a = null;

		// Token: 0x0400199A RID: 6554
		private aif b = null;
	}
}
