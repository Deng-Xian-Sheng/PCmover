using System;
using System.Collections;
using zz93;

namespace ceTe.DynamicPDF.Merger
{
	// Token: 0x020006FA RID: 1786
	public class PdfPageList : IEnumerable
	{
		// Token: 0x0600458D RID: 17805 RVA: 0x00239A80 File Offset: 0x00238A80
		internal PdfPageList(PdfDocument A_0)
		{
			this.a = A_0;
			this.a(A_0.n().i());
		}

		// Token: 0x0600458E RID: 17806 RVA: 0x00239AB4 File Offset: 0x00238AB4
		private void a(abj A_0)
		{
			abe a_ = null;
			for (abk abk = A_0.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num != 3053875)
				{
					if (num == 62872500)
					{
						this.b = new PdfPage[((abw)abk.c().h6()).kd()];
					}
				}
				else
				{
					a_ = (abe)abk.c().h6();
				}
			}
			this.a(a_, new acf(this.a, A_0, null));
		}

		// Token: 0x0600458F RID: 17807 RVA: 0x00239B4C File Offset: 0x00238B4C
		private void a(abe A_0, acf A_1)
		{
			for (int i = 0; i < A_0.a(); i++)
			{
				this.a(A_1, (ab6)A_0.a(i));
			}
		}

		// Token: 0x06004590 RID: 17808 RVA: 0x00239B88 File Offset: 0x00238B88
		private void a(acf A_0, ab6 A_1)
		{
			abj abj = (abj)A_1.h6();
			abk abk = abj.l();
			while (abk != null)
			{
				int num = abk.a().j8();
				if (num != 3053875)
				{
					if (num != 5479461)
					{
						abk = abk.d();
						continue;
					}
					abu abu = (abu)abk.c();
					if (abu.j8() == 4332005)
					{
						this.a(A_0, A_1.c());
					}
					else
					{
						this.a(abj, A_0);
					}
				}
				else
				{
					abd abd = abk.c();
					abe a_;
					if (abd.hy() == ag9.j)
					{
						a_ = (abe)abd.h6();
					}
					else
					{
						a_ = (abe)abd;
					}
					this.a(a_, new acf(this.a, abj, A_0));
				}
				return;
			}
			if (abj.l() != null)
			{
				this.a(A_0, A_1.c());
				return;
			}
		}

		// Token: 0x06004591 RID: 17809 RVA: 0x00239C9C File Offset: 0x00238C9C
		private void a(abj A_0, acf A_1)
		{
			for (abk abk = A_0.l(); abk != null; abk = abk.d())
			{
				if (abk.a().j8() == 3053875)
				{
					abe a_ = (abe)abk.c();
					this.a(a_, new acf(this.a, A_0, A_1));
					break;
				}
			}
		}

		// Token: 0x06004592 RID: 17810 RVA: 0x00239D04 File Offset: 0x00238D04
		private void a(acf A_0, int A_1)
		{
			PdfPage pdfPage = this.a.m().b((long)A_1).a(this.c, A_0);
			this.b[this.c++] = pdfPage;
		}

		// Token: 0x17000404 RID: 1028
		// (get) Token: 0x06004593 RID: 17811 RVA: 0x00239D4C File Offset: 0x00238D4C
		public int Count
		{
			get
			{
				return this.c;
			}
		}

		// Token: 0x17000405 RID: 1029
		public PdfPage this[int index]
		{
			get
			{
				return this.b[index];
			}
		}

		// Token: 0x06004595 RID: 17813 RVA: 0x00239D80 File Offset: 0x00238D80
		public IEnumerator GetEnumerator()
		{
			return this.b.GetEnumerator();
		}

		// Token: 0x0400269D RID: 9885
		private PdfDocument a;

		// Token: 0x0400269E RID: 9886
		private PdfPage[] b = null;

		// Token: 0x0400269F RID: 9887
		private int c = 0;
	}
}
