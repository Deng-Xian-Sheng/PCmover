using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Html;

namespace zz93
{
	// Token: 0x020001B6 RID: 438
	internal class la : k0
	{
		// Token: 0x060010EA RID: 4330 RVA: 0x000C2248 File Offset: 0x000C1248
		internal la()
		{
		}

		// Token: 0x060010EB RID: 4331 RVA: 0x000C226C File Offset: 0x000C126C
		internal la(string A_0, HtmlArea A_1)
		{
			this.b = A_0;
			this.f = A_1;
		}

		// Token: 0x060010EC RID: 4332 RVA: 0x000C22A0 File Offset: 0x000C12A0
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x060010ED RID: 4333 RVA: 0x000C22B8 File Offset: 0x000C12B8
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x060010EE RID: 4334 RVA: 0x000C22C8 File Offset: 0x000C12C8
		internal string a()
		{
			return this.d;
		}

		// Token: 0x060010EF RID: 4335 RVA: 0x000C22E0 File Offset: 0x000C12E0
		internal void a(string A_0)
		{
			this.d = A_0;
		}

		// Token: 0x060010F0 RID: 4336 RVA: 0x000C22EC File Offset: 0x000C12EC
		internal string b()
		{
			return this.b;
		}

		// Token: 0x060010F1 RID: 4337 RVA: 0x000C2304 File Offset: 0x000C1304
		internal void b(string A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060010F2 RID: 4338 RVA: 0x000C2310 File Offset: 0x000C1310
		internal override int dg()
		{
			return 1;
		}

		// Token: 0x060010F3 RID: 4339 RVA: 0x000C2324 File Offset: 0x000C1324
		internal override bool de()
		{
			return true;
		}

		// Token: 0x060010F4 RID: 4340 RVA: 0x000C2338 File Offset: 0x000C1338
		internal override k0 dd()
		{
			la la = new la();
			la.ab(base.ci());
			la.aa(base.ch());
			return la;
		}

		// Token: 0x060010F5 RID: 4341 RVA: 0x000C236C File Offset: 0x000C136C
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x060010F6 RID: 4342 RVA: 0x000C238B File Offset: 0x000C138B
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x060010F7 RID: 4343 RVA: 0x000C2398 File Offset: 0x000C1398
		internal override kz dj(x5 A_0, x5 A_1)
		{
			la result = (la)base.f(A_0, A_1);
			int num = this.dg();
			if (num == 1)
			{
				if (this.d != null)
				{
					if (base.z() != null && base.z().h().Contains(this.d))
					{
						if (((k5)base.z().h()[this.d]).c() == null)
						{
							((k5)base.z().h()[this.d]).a(base.an());
							((k5)base.z().h()[this.d]).b(base.ao());
							((k5)base.z().h()[this.d]).a(base.z());
						}
					}
				}
			}
			return result;
		}

		// Token: 0x060010F8 RID: 4344 RVA: 0x000C24B0 File Offset: 0x000C14B0
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.d(A_0, A_1, A_2);
			int num = this.dg();
			if (num == 1)
			{
				A_1 = x5.f(A_1, base.an());
				if (this.b != null)
				{
					if (this.b.StartsWith("#"))
					{
						if (base.z() == null)
						{
							this.e = new l7(this.b, this.f);
						}
						else
						{
							this.e = new l7(this.b, base.z());
						}
						this.e.a(A_0, x5.b(A_1), x5.b(A_2), this);
					}
					else
					{
						this.c = new ma(this.b);
						this.c.a(A_0, x5.b(A_1), x5.b(A_2), this);
					}
				}
			}
		}

		// Token: 0x060010F9 RID: 4345 RVA: 0x000C25A8 File Offset: 0x000C15A8
		internal override kz dm()
		{
			la la = new la(this.b, this.f);
			la.j(this.dr());
			la.dc(this.db().du());
			la.a((lk)base.c5().du());
			la.a(base.z());
			la.a(this.d);
			la.b(this.b);
			if (base.n() != null)
			{
				la.c(base.n().p());
			}
			return la;
		}

		// Token: 0x04000822 RID: 2082
		private new n5 a = new n5();

		// Token: 0x04000823 RID: 2083
		private new string b;

		// Token: 0x04000824 RID: 2084
		private new ma c = null;

		// Token: 0x04000825 RID: 2085
		private new string d;

		// Token: 0x04000826 RID: 2086
		private new l7 e = null;

		// Token: 0x04000827 RID: 2087
		private new HtmlArea f;
	}
}
