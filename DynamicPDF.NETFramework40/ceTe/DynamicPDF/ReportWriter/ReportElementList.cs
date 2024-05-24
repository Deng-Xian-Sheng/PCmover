using System;
using ceTe.DynamicPDF.ReportWriter.IO;
using ceTe.DynamicPDF.ReportWriter.ReportElements;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter
{
	// Token: 0x0200082A RID: 2090
	public class ReportElementList
	{
		// Token: 0x06005459 RID: 21593 RVA: 0x00294AC4 File Offset: 0x00293AC4
		internal ReportElementList(rm A_0, wj A_1)
		{
			this.a = new ReportElement[A_1.a()];
			for (vr vr = A_1.b(); vr != null; vr = vr.u())
			{
				this.a[this.b++] = vr.fz(A_0);
			}
		}

		// Token: 0x0600545A RID: 21594 RVA: 0x00294B70 File Offset: 0x00293B70
		public void Add(ReportElement element)
		{
			if (this.a == null)
			{
				this.a = new ReportElement[4];
			}
			else if (this.b == this.a.Length)
			{
				ReportElement[] array = new ReportElement[this.a.Length * 3];
				this.a.CopyTo(array, 0);
				this.a = array;
			}
			this.a[this.b++] = element;
		}

		// Token: 0x0600545B RID: 21595 RVA: 0x00294BF4 File Offset: 0x00293BF4
		private void d()
		{
			this.f = true;
			for (int i = 0; i < this.b; i++)
			{
				if (this.a[i].fk() == 65024)
				{
					if (((SubReport)this.a[i]).m() > 1)
					{
						this.e = true;
						break;
					}
				}
			}
		}

		// Token: 0x0600545C RID: 21596 RVA: 0x00294C64 File Offset: 0x00293C64
		private void c()
		{
			this.h = true;
			for (int i = 0; i < this.b; i++)
			{
				if (this.a[i].fk() == 65024)
				{
					this.g = true;
					break;
				}
			}
		}

		// Token: 0x0600545D RID: 21597 RVA: 0x00294CB8 File Offset: 0x00293CB8
		private void b()
		{
			this.d = true;
			for (int i = 0; i < this.b; i++)
			{
				if (this.a[i].fk() == 61440)
				{
					this.c = true;
					break;
				}
				if (this.a[i].fk() == 65024)
				{
					if (((SubReport)this.a[i]).Detail.Elements != null && ((SubReport)this.a[i]).Detail.Elements.g())
					{
						this.c = true;
						break;
					}
				}
			}
		}

		// Token: 0x0600545E RID: 21598 RVA: 0x00294D78 File Offset: 0x00293D78
		internal bool e()
		{
			bool result;
			if (this.h)
			{
				result = this.g;
			}
			else
			{
				this.c();
				result = this.g;
			}
			return result;
		}

		// Token: 0x0600545F RID: 21599 RVA: 0x00294DB0 File Offset: 0x00293DB0
		internal bool f()
		{
			bool result;
			if (this.f)
			{
				result = this.e;
			}
			else
			{
				this.d();
				result = this.e;
			}
			return result;
		}

		// Token: 0x06005460 RID: 21600 RVA: 0x00294DE8 File Offset: 0x00293DE8
		internal bool g()
		{
			bool result;
			if (this.d)
			{
				result = this.c;
			}
			else
			{
				this.b();
				result = this.c;
			}
			return result;
		}

		// Token: 0x06005461 RID: 21601 RVA: 0x00294E20 File Offset: 0x00293E20
		internal bool h()
		{
			bool result;
			if (this.j)
			{
				result = this.i;
			}
			else
			{
				this.a();
				result = this.i;
			}
			return result;
		}

		// Token: 0x06005462 RID: 21602 RVA: 0x00294E58 File Offset: 0x00293E58
		private void a()
		{
			this.j = true;
			for (int i = 0; i < this.b; i++)
			{
				if (this.a[i].fk() == 65024)
				{
					if (((SubReport)this.a[i]).f().e())
					{
						this.i = true;
						break;
					}
					this.i = ((SubReport)this.a[i]).Detail.Elements.h();
					if (this.i)
					{
						break;
					}
				}
			}
		}

		// Token: 0x06005463 RID: 21603 RVA: 0x00294F00 File Offset: 0x00293F00
		internal void a(xf A_0, LayoutWriter A_1)
		{
			for (int i = 0; i < this.b; i++)
			{
				this.a[i].fi(A_0, A_1);
			}
		}

		// Token: 0x06005464 RID: 21604 RVA: 0x00294F38 File Offset: 0x00293F38
		internal void a(xh A_0, LayoutWriter A_1)
		{
			for (int i = 0; i < this.b; i++)
			{
				this.a[i].gi(A_0, A_1);
			}
		}

		// Token: 0x170007C2 RID: 1986
		public ReportElement this[int index]
		{
			get
			{
				return this.a[index];
			}
		}

		// Token: 0x170007C3 RID: 1987
		// (get) Token: 0x06005466 RID: 21606 RVA: 0x00294F8C File Offset: 0x00293F8C
		public int Count
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x04002D27 RID: 11559
		private ReportElement[] a = null;

		// Token: 0x04002D28 RID: 11560
		private int b = 0;

		// Token: 0x04002D29 RID: 11561
		private bool c = false;

		// Token: 0x04002D2A RID: 11562
		private bool d = false;

		// Token: 0x04002D2B RID: 11563
		private bool e = false;

		// Token: 0x04002D2C RID: 11564
		private bool f = false;

		// Token: 0x04002D2D RID: 11565
		private bool g = false;

		// Token: 0x04002D2E RID: 11566
		private bool h = false;

		// Token: 0x04002D2F RID: 11567
		private bool i = false;

		// Token: 0x04002D30 RID: 11568
		private bool j = false;
	}
}
