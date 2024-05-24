using System;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine
{
	// Token: 0x02000936 RID: 2358
	public class LayoutElementList
	{
		// Token: 0x06005FE9 RID: 24553 RVA: 0x0035F3B8 File Offset: 0x0035E3B8
		internal LayoutElementList(alo A_0, ali A_1)
		{
			this.a = new LayoutElement[A_1.a()];
			for (akt akt = A_1.b(); akt != null; akt = akt.u())
			{
				this.a[this.b++] = akt.mt(A_0);
			}
		}

		// Token: 0x06005FEA RID: 24554 RVA: 0x0035F464 File Offset: 0x0035E464
		public void Add(LayoutElement element)
		{
			if (this.a == null)
			{
				this.a = new LayoutElement[4];
			}
			else if (this.b == this.a.Length)
			{
				LayoutElement[] array = new LayoutElement[this.a.Length * 3];
				this.a.CopyTo(array, 0);
				this.a = array;
			}
			this.a[this.b++] = element;
		}

		// Token: 0x06005FEB RID: 24555 RVA: 0x0035F4E8 File Offset: 0x0035E4E8
		private void d()
		{
			this.f = true;
			for (int i = 0; i < this.b; i++)
			{
				if (this.a[i].n0() == 65024)
				{
					if (((SubReport)this.a[i]).o() > 1)
					{
						this.e = true;
						break;
					}
				}
			}
		}

		// Token: 0x06005FEC RID: 24556 RVA: 0x0035F558 File Offset: 0x0035E558
		private void c()
		{
			this.h = true;
			for (int i = 0; i < this.b; i++)
			{
				if (this.a[i].n0() == 65024)
				{
					this.g = true;
					break;
				}
			}
		}

		// Token: 0x06005FED RID: 24557 RVA: 0x0035F5AC File Offset: 0x0035E5AC
		private void b()
		{
			this.d = true;
			for (int i = 0; i < this.b; i++)
			{
				if (this.a[i].n0() == 61440)
				{
					this.c = true;
					break;
				}
				if (this.a[i].n0() == 65024)
				{
					if (((SubReport)this.a[i]).Detail.Elements != null && ((SubReport)this.a[i]).Detail.Elements.g())
					{
						this.c = true;
						break;
					}
				}
			}
		}

		// Token: 0x06005FEE RID: 24558 RVA: 0x0035F66C File Offset: 0x0035E66C
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

		// Token: 0x06005FEF RID: 24559 RVA: 0x0035F6A4 File Offset: 0x0035E6A4
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

		// Token: 0x06005FF0 RID: 24560 RVA: 0x0035F6DC File Offset: 0x0035E6DC
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

		// Token: 0x06005FF1 RID: 24561 RVA: 0x0035F714 File Offset: 0x0035E714
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

		// Token: 0x06005FF2 RID: 24562 RVA: 0x0035F74C File Offset: 0x0035E74C
		private void a()
		{
			this.j = true;
			for (int i = 0; i < this.b; i++)
			{
				if (this.a[i].n0() == 65024)
				{
					if (((SubReport)this.a[i]).h().e())
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

		// Token: 0x06005FF3 RID: 24563 RVA: 0x0035F7F4 File Offset: 0x0035E7F4
		internal void a(amj A_0, LayoutWriter A_1)
		{
			for (int i = 0; i < this.b; i++)
			{
				this.a[i].nt(A_0, A_1);
			}
		}

		// Token: 0x06005FF4 RID: 24564 RVA: 0x0035F82C File Offset: 0x0035E82C
		internal void a(aml A_0, LayoutWriter A_1)
		{
			for (int i = 0; i < this.b; i++)
			{
				this.a[i].nu(A_0, A_1);
			}
		}

		// Token: 0x17000A34 RID: 2612
		public LayoutElement this[int index]
		{
			get
			{
				return this.a[index];
			}
		}

		// Token: 0x17000A35 RID: 2613
		// (get) Token: 0x06005FF6 RID: 24566 RVA: 0x0035F880 File Offset: 0x0035E880
		public int Count
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x04003159 RID: 12633
		private LayoutElement[] a = null;

		// Token: 0x0400315A RID: 12634
		private int b = 0;

		// Token: 0x0400315B RID: 12635
		private bool c = false;

		// Token: 0x0400315C RID: 12636
		private bool d = false;

		// Token: 0x0400315D RID: 12637
		private bool e = false;

		// Token: 0x0400315E RID: 12638
		private bool f = false;

		// Token: 0x0400315F RID: 12639
		private bool g = false;

		// Token: 0x04003160 RID: 12640
		private bool h = false;

		// Token: 0x04003161 RID: 12641
		private bool i = false;

		// Token: 0x04003162 RID: 12642
		private bool j = false;
	}
}
