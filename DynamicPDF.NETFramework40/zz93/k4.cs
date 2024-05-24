using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Html;

namespace zz93
{
	// Token: 0x020001B0 RID: 432
	internal class k4 : k0
	{
		// Token: 0x06001082 RID: 4226 RVA: 0x000BF5B1 File Offset: 0x000BE5B1
		internal k4()
		{
		}

		// Token: 0x06001083 RID: 4227 RVA: 0x000BF5E8 File Offset: 0x000BE5E8
		internal k4(string A_0, HtmlArea A_1)
		{
			this.b = A_0;
			this.f = A_1;
		}

		// Token: 0x06001084 RID: 4228 RVA: 0x000BF638 File Offset: 0x000BE638
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x06001085 RID: 4229 RVA: 0x000BF650 File Offset: 0x000BE650
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x06001086 RID: 4230 RVA: 0x000BF660 File Offset: 0x000BE660
		internal x5 a()
		{
			return this.h;
		}

		// Token: 0x06001087 RID: 4231 RVA: 0x000BF678 File Offset: 0x000BE678
		internal void a(x5 A_0)
		{
			this.h = A_0;
		}

		// Token: 0x06001088 RID: 4232 RVA: 0x000BF684 File Offset: 0x000BE684
		internal string b()
		{
			return this.b;
		}

		// Token: 0x06001089 RID: 4233 RVA: 0x000BF69C File Offset: 0x000BE69C
		internal void a(string A_0)
		{
			this.b = A_0;
		}

		// Token: 0x0600108A RID: 4234 RVA: 0x000BF6A8 File Offset: 0x000BE6A8
		internal override k0 dd()
		{
			k4 k = new k4();
			k.b = this.b;
			k.ab(base.ci());
			k.aa(base.ch());
			return k;
		}

		// Token: 0x0600108B RID: 4235 RVA: 0x000BF6E8 File Offset: 0x000BE6E8
		internal string c()
		{
			return this.d;
		}

		// Token: 0x0600108C RID: 4236 RVA: 0x000BF700 File Offset: 0x000BE700
		internal void b(string A_0)
		{
			this.d = A_0;
		}

		// Token: 0x0600108D RID: 4237 RVA: 0x000BF70C File Offset: 0x000BE70C
		internal override bool de()
		{
			return this.g;
		}

		// Token: 0x0600108E RID: 4238 RVA: 0x000BF724 File Offset: 0x000BE724
		internal override void df(bool A_0)
		{
			this.g = A_0;
		}

		// Token: 0x0600108F RID: 4239 RVA: 0x000BF730 File Offset: 0x000BE730
		internal override int dg()
		{
			return 1;
		}

		// Token: 0x06001090 RID: 4240 RVA: 0x000BF744 File Offset: 0x000BE744
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x06001091 RID: 4241 RVA: 0x000BF763 File Offset: 0x000BE763
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x06001092 RID: 4242 RVA: 0x000BF770 File Offset: 0x000BE770
		internal override kz dj(x5 A_0, x5 A_1)
		{
			kz result = base.c(A_0, A_1);
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
			return result;
		}

		// Token: 0x06001093 RID: 4243 RVA: 0x000BF870 File Offset: 0x000BE870
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			x5 a_ = base.cc();
			base.c(A_0, A_1, A_2);
			if (base.n() != null)
			{
				mu mu = base.n().c();
				if (mu != null && mu.a() != null)
				{
					ms ms = mu.a();
					if (ms.l() != null)
					{
						mr mr = ms.l().a();
						if (mr.b() != null)
						{
							kz kz = mr.b();
							int num = kz.dg();
							switch (num)
							{
							case 100:
							case 101:
							case 102:
								this.h = kz.aq();
								A_2 = x5.f(A_2, x5.e(kz.a7(), base.ar()));
								A_1 = x5.f(A_1, a_);
								break;
							default:
								if (num != 46415)
								{
									this.h = kz.aq();
									A_2 = x5.f(A_2, x5.e(kz.a7(), base.ar()));
									if (x5.h(base.ar(), x5.c()))
									{
										base.m(kz.ar());
									}
								}
								else
								{
									this.h = kz.aq();
								}
								break;
							}
						}
					}
				}
			}
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
					if (this.f != null && this.f.c() != null)
					{
						Uri uri = n9.a(this.f.c().OriginalString, this.b);
						if (uri != null)
						{
							this.b = uri.OriginalString;
						}
					}
					this.c = new ma(this.b);
					this.c.a(A_0, x5.b(A_1), x5.b(A_2), this);
				}
			}
			a_ = x5.c();
		}

		// Token: 0x06001094 RID: 4244 RVA: 0x000BFAFC File Offset: 0x000BEAFC
		internal override kz dl()
		{
			return base.am();
		}

		// Token: 0x06001095 RID: 4245 RVA: 0x000BFB14 File Offset: 0x000BEB14
		internal override kz dm()
		{
			k4 k = new k4();
			k.j(this.dr());
			k.dc(this.db().du());
			k.a((lk)base.c5().du());
			k.a(this.f);
			k.a(this.b);
			k.b(this.d);
			k.df(this.g);
			k.a(base.d8());
			k.ap(this.c3());
			k.ai(base.cu());
			k.ah(base.ct());
			if (base.n() != null)
			{
				if (base.o() != null)
				{
					k.d(base.o().p());
				}
				k.c(base.n().p());
			}
			return k;
		}

		// Token: 0x040007FB RID: 2043
		private new n5 a = new n5();

		// Token: 0x040007FC RID: 2044
		private new string b;

		// Token: 0x040007FD RID: 2045
		private new ma c = null;

		// Token: 0x040007FE RID: 2046
		private new string d;

		// Token: 0x040007FF RID: 2047
		private new l7 e = null;

		// Token: 0x04000800 RID: 2048
		private new HtmlArea f;

		// Token: 0x04000801 RID: 2049
		private bool g = false;

		// Token: 0x04000802 RID: 2050
		private x5 h = x5.c();
	}
}
