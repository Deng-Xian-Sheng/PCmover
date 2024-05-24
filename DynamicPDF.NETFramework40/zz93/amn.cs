using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x020005BC RID: 1468
	internal class amn
	{
		// Token: 0x06003A2B RID: 14891 RVA: 0x001F3B30 File Offset: 0x001F2B30
		internal amn(LayoutWriter A_0, amj A_1, aho A_2)
		{
			this.a = new amm[A_2.a()];
			for (int i = 0; i < A_2.a(); i++)
			{
				this.a[i] = new amm(A_0, A_1, A_2.a(i));
			}
		}

		// Token: 0x06003A2C RID: 14892 RVA: 0x001F3B84 File Offset: 0x001F2B84
		internal amm a(amp A_0, PageWriter A_1, ref int A_2)
		{
			for (int i = 0; i < this.a.Length; i++)
			{
				if (this.a[i].a().ne(A_0, A_1))
				{
					A_2 = i;
					return this.a[i];
				}
			}
			return null;
		}

		// Token: 0x06003A2D RID: 14893 RVA: 0x001F3BDC File Offset: 0x001F2BDC
		internal amm a(amp A_0, DocumentWriter A_1, int A_2)
		{
			for (int i = 0; i < this.a.Length; i++)
			{
				if (this.a[i].a().ng(A_0, A_1, A_2))
				{
					return this.a[i];
				}
			}
			return null;
		}

		// Token: 0x06003A2E RID: 14894 RVA: 0x001F3C30 File Offset: 0x001F2C30
		internal amm a(am1 A_0, PageWriter A_1, ref int A_2)
		{
			for (int i = 0; i < this.a.Length; i++)
			{
				if (this.a[i].a().nf(A_0, A_1))
				{
					A_2 = i;
					return this.a[i];
				}
			}
			return null;
		}

		// Token: 0x06003A2F RID: 14895 RVA: 0x001F3C88 File Offset: 0x001F2C88
		internal int a()
		{
			return this.a.Length;
		}

		// Token: 0x04001B90 RID: 7056
		private amm[] a;
	}
}
