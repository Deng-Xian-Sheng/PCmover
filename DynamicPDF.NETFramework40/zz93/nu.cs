using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000214 RID: 532
	internal class nu : k0
	{
		// Token: 0x06001872 RID: 6258 RVA: 0x00103288 File Offset: 0x00102288
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x06001873 RID: 6259 RVA: 0x001032A0 File Offset: 0x001022A0
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x06001874 RID: 6260 RVA: 0x001032B0 File Offset: 0x001022B0
		internal override nw dv()
		{
			return this.b;
		}

		// Token: 0x06001875 RID: 6261 RVA: 0x001032C8 File Offset: 0x001022C8
		internal override void dw(nw A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06001876 RID: 6262 RVA: 0x001032D2 File Offset: 0x001022D2
		internal void a(x5 A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001877 RID: 6263 RVA: 0x001032DC File Offset: 0x001022DC
		internal void b(x5 A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06001878 RID: 6264 RVA: 0x001032E8 File Offset: 0x001022E8
		internal int a()
		{
			return this.e;
		}

		// Token: 0x06001879 RID: 6265 RVA: 0x00103300 File Offset: 0x00102300
		internal void a(int A_0)
		{
			this.e = A_0;
		}

		// Token: 0x0600187A RID: 6266 RVA: 0x0010330C File Offset: 0x0010230C
		internal int b()
		{
			return this.f;
		}

		// Token: 0x0600187B RID: 6267 RVA: 0x00103324 File Offset: 0x00102324
		internal void b(int A_0)
		{
			this.f = A_0;
		}

		// Token: 0x0600187C RID: 6268 RVA: 0x00103330 File Offset: 0x00102330
		internal override int dg()
		{
			return 165445;
		}

		// Token: 0x0600187D RID: 6269 RVA: 0x00103348 File Offset: 0x00102348
		private void a(PageWriter A_0, x5 A_1, x5 A_2)
		{
			x5 x = this.d;
			x5 x2 = this.c;
			if (this.b.h() == il.b)
			{
				if (base.c5().c().o() != ft.a)
				{
					x = x5.e(x, base.c5().c().n());
					A_1 = x5.f(A_1, base.c5().c().n());
				}
				if (base.c5().c().s() != ft.a)
				{
					x = x5.e(x, base.c5().c().r());
				}
				if (base.c5().c().g() != ft.a)
				{
					x2 = x5.e(x2, base.c5().c().f());
					A_2 = x5.f(A_2, base.c5().c().f());
				}
				if (base.c5().c().k() != ft.a)
				{
					x2 = x5.e(x2, base.c5().c().r());
				}
			}
			if (base.w() != null)
			{
				base.w().a(base.c5(), A_0, A_1, A_2, x, x2);
			}
		}

		// Token: 0x0600187E RID: 6270 RVA: 0x00103490 File Offset: 0x00102490
		internal override kz dj(x5 A_0, x5 A_1)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		// Token: 0x0600187F RID: 6271 RVA: 0x0010349D File Offset: 0x0010249D
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			this.a(A_0, A_1, A_2);
		}

		// Token: 0x06001880 RID: 6272 RVA: 0x001034AC File Offset: 0x001024AC
		internal override kz dm()
		{
			nu nu = new nu();
			nu.j(this.dr());
			nu.dc(this.db().du());
			nu.a((lk)base.c5().du());
			nu.dw((nw)this.dv().du());
			nu.f = this.f;
			nu.a(this.e);
			nu.b(this.d);
			nu.a(this.c);
			return nu;
		}

		// Token: 0x04000AEC RID: 2796
		private new n5 a = new n5();

		// Token: 0x04000AED RID: 2797
		private new nw b = new nw();

		// Token: 0x04000AEE RID: 2798
		private new x5 c = x5.c();

		// Token: 0x04000AEF RID: 2799
		private new x5 d = x5.c();

		// Token: 0x04000AF0 RID: 2800
		private new int e = 0;

		// Token: 0x04000AF1 RID: 2801
		private new int f = 0;
	}
}
