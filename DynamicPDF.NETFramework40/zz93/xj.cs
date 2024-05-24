using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000380 RID: 896
	internal class xj
	{
		// Token: 0x06002618 RID: 9752 RVA: 0x001630AC File Offset: 0x001620AC
		internal xj(LayoutWriter A_0, xf A_1, sx A_2)
		{
			this.a = new xi[A_2.a()];
			for (int i = 0; i < A_2.a(); i++)
			{
				this.a[i] = new xi(A_0, A_1, A_2.a(i));
			}
		}

		// Token: 0x06002619 RID: 9753 RVA: 0x00163100 File Offset: 0x00162100
		internal xi a(rs A_0, PageWriter A_1, ref int A_2)
		{
			for (int i = 0; i < this.a.Length; i++)
			{
				if (this.a[i].a().f3(A_0, A_1))
				{
					A_2 = i;
					return this.a[i];
				}
			}
			return null;
		}

		// Token: 0x0600261A RID: 9754 RVA: 0x00163158 File Offset: 0x00162158
		internal xi a(rs A_0, DocumentWriter A_1, int A_2)
		{
			for (int i = 0; i < this.a.Length; i++)
			{
				if (this.a[i].a().f5(A_0, A_1, A_2))
				{
					return this.a[i];
				}
			}
			return null;
		}

		// Token: 0x0600261B RID: 9755 RVA: 0x001631AC File Offset: 0x001621AC
		internal xi a(xs A_0, PageWriter A_1, ref int A_2)
		{
			for (int i = 0; i < this.a.Length; i++)
			{
				if (this.a[i].a().f4(A_0, A_1))
				{
					A_2 = i;
					return this.a[i];
				}
			}
			return null;
		}

		// Token: 0x0600261C RID: 9756 RVA: 0x00163204 File Offset: 0x00162204
		internal int a()
		{
			return this.a.Length;
		}

		// Token: 0x040010A9 RID: 4265
		private xi[] a;
	}
}
