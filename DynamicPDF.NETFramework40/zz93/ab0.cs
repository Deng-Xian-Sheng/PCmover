using System;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x02000432 RID: 1074
	internal class ab0
	{
		// Token: 0x06002C8A RID: 11402 RVA: 0x0019713D File Offset: 0x0019613D
		internal ab0(abj A_0)
		{
			this.a(A_0);
		}

		// Token: 0x06002C8B RID: 11403 RVA: 0x00197160 File Offset: 0x00196160
		private void a(int A_0)
		{
			if (this.a == null)
			{
				this.a = new abz[A_0];
			}
			else
			{
				abz[] array = this.a;
				this.a = new abz[this.b + A_0];
				array.CopyTo(this.a, 0);
			}
		}

		// Token: 0x06002C8C RID: 11404 RVA: 0x001971B8 File Offset: 0x001961B8
		private void a(abz A_0)
		{
			this.a[this.b++] = A_0;
		}

		// Token: 0x06002C8D RID: 11405 RVA: 0x001971E0 File Offset: 0x001961E0
		internal void a(MergeDocument A_0, int A_1, int A_2)
		{
			int num = A_1 - 1;
			int num2 = A_1 + A_2;
			int num3 = 0;
			int count = A_0.Pages.Count;
			while (num3 < this.b && this.a[num3].a() < num)
			{
				num3++;
			}
			while (num3 < this.b && this.a[num3].a() <= num2)
			{
				if (A_0.Sections.a() != null && num + count == A_0.Sections.a().PageIndex && this.a[num3].a() == A_0.Sections.a().PageIndex)
				{
					this.a[num3].a(A_0.Sections.a(), count);
				}
				else
				{
					A_0.Sections.a(num3 + count, this.a[num3].a(count));
				}
				num3++;
			}
		}

		// Token: 0x06002C8E RID: 11406 RVA: 0x001972EC File Offset: 0x001962EC
		private void a(abj A_0)
		{
			abk abk = A_0.l();
			while (abk != null)
			{
				if (abk.a().j8() == 3890035)
				{
					abd abd = abk.c().h6();
					if (abd != null)
					{
						this.b((abe)abd);
						break;
					}
					break;
				}
				else
				{
					if (abk.a().j8() == 3053875)
					{
						this.c((abe)abk.c().h6());
						break;
					}
					abk = abk.d();
				}
			}
		}

		// Token: 0x06002C8F RID: 11407 RVA: 0x00197390 File Offset: 0x00196390
		private void c(abe A_0)
		{
			for (int i = 0; i < A_0.a(); i++)
			{
				this.a((abj)A_0.a(i).h6());
			}
		}

		// Token: 0x06002C90 RID: 11408 RVA: 0x001973CC File Offset: 0x001963CC
		private void b(abe A_0)
		{
			if (this.a != null)
			{
				this.a(A_0);
			}
			else if (A_0.a() % 2 == 0)
			{
				this.a(A_0.a() / 2);
				int i = 0;
				while (i < A_0.a())
				{
					abw a_ = (abw)A_0.a(i++);
					abj abj = (abj)A_0.a(i++).h6();
					if (abj != null)
					{
						this.a(new abz(a_, abj));
					}
				}
			}
		}

		// Token: 0x06002C91 RID: 11409 RVA: 0x00197468 File Offset: 0x00196468
		private void a(abe A_0)
		{
			this.a(A_0.a() / 2);
			int i = 0;
			while (i < A_0.a())
			{
				abw a_ = (abw)A_0.a(i++);
				abj abj = (abj)A_0.a(i++).h6();
				if (abj != null)
				{
					this.a(new abz(a_, abj));
				}
			}
		}

		// Token: 0x06002C92 RID: 11410 RVA: 0x001974D8 File Offset: 0x001964D8
		internal abz[] a()
		{
			return this.a;
		}

		// Token: 0x040014F0 RID: 5360
		private abz[] a = null;

		// Token: 0x040014F1 RID: 5361
		private int b = 0;
	}
}
