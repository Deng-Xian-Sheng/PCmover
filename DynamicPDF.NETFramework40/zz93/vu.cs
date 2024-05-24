using System;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x02000341 RID: 833
	internal class vu
	{
		// Token: 0x060023A5 RID: 9125 RVA: 0x00151E61 File Offset: 0x00150E61
		internal vu()
		{
		}

		// Token: 0x060023A6 RID: 9126 RVA: 0x00151E74 File Offset: 0x00150E74
		internal void a(wd A_0)
		{
			while (A_0.x() != 616326873)
			{
				int num = A_0.x();
				if (num != 12720613)
				{
					if (num == 848759750)
					{
						wi wi = new wi();
						wi.a(A_0);
						this.a(wi);
						A_0.aa();
						A_0.aa();
					}
				}
				else
				{
					v7 v = new v7();
					v.b(A_0);
					this.a(v);
				}
			}
		}

		// Token: 0x060023A7 RID: 9127 RVA: 0x00151EF4 File Offset: 0x00150EF4
		internal void a(DocumentLayoutPartList A_0)
		{
			for (vt vt = this.a; vt != null; vt = vt.m())
			{
				vt.f2(A_0);
			}
			A_0.b();
		}

		// Token: 0x060023A8 RID: 9128 RVA: 0x00151F30 File Offset: 0x00150F30
		internal int a()
		{
			return this.c;
		}

		// Token: 0x060023A9 RID: 9129 RVA: 0x00151F48 File Offset: 0x00150F48
		private void a(vt A_0)
		{
			if (this.a == null)
			{
				this.b = A_0;
				this.a = A_0;
			}
			else
			{
				this.b.a(A_0);
				this.b = A_0;
			}
			this.c++;
		}

		// Token: 0x04000F5A RID: 3930
		private vt a;

		// Token: 0x04000F5B RID: 3931
		private vt b;

		// Token: 0x04000F5C RID: 3932
		private int c = 0;
	}
}
