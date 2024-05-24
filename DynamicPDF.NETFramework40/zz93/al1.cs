using System;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;

namespace zz93
{
	// Token: 0x020005A6 RID: 1446
	internal class al1
	{
		// Token: 0x06003967 RID: 14695 RVA: 0x001EDE40 File Offset: 0x001ECE40
		internal al1(x5 A_0, alp A_1, bool A_2)
		{
			this.n = A_2;
			this.k = A_0;
			this.h = A_1;
		}

		// Token: 0x06003968 RID: 14696 RVA: 0x001EDEA4 File Offset: 0x001ECEA4
		internal void a(amg A_0, Report A_1, alr A_2, al2 A_3, bool A_4, bool A_5)
		{
			this.f = new amg[1];
			this.f[this.g] = A_0;
			this.h = A_1;
			this.i = A_1;
			this.j = A_2;
			this.l = A_3;
			if (A_5)
			{
				this.m = this.a(A_4);
			}
			if (((alp)A_1).a() <= 1)
			{
				if (!A_1.Detail.AutoSplit)
				{
					this.c(A_4);
				}
				else
				{
					this.b(A_4);
				}
			}
			else if (A_1.Detail.AutoSplit && ((alp)A_1).f() != akq.a)
			{
				this.h(A_4);
			}
			else
			{
				this.g(A_4);
			}
		}

		// Token: 0x06003969 RID: 14697 RVA: 0x001EDF74 File Offset: 0x001ECF74
		private void h(bool A_0)
		{
			akq akq = this.h.f();
			if (akq != akq.b)
			{
				if (akq == akq.c)
				{
					this.e(A_0);
				}
			}
			else
			{
				this.d(A_0);
			}
		}

		// Token: 0x0600396A RID: 14698 RVA: 0x001EDFB4 File Offset: 0x001ECFB4
		private void g(bool A_0)
		{
			akq akq = this.h.f();
			if (akq != akq.a)
			{
				if (akq != akq.b)
				{
					if (akq == akq.c)
					{
						this.f(A_0);
					}
				}
				else
				{
					this.a();
				}
			}
			else
			{
				this.b();
			}
		}

		// Token: 0x0600396B RID: 14699 RVA: 0x001EE004 File Offset: 0x001ED004
		private void b()
		{
			int i = 0;
			amh amh = null;
			amz amz = null;
			alz alz = new alz(this.k, this.i, this.n);
			while (i <= this.m)
			{
				if (this.f[i].e() != null)
				{
					amh amh2 = new amh(this.f[i].e(), this.h);
					if (i > 0)
					{
						this.a(ref amz, amh2);
					}
					else
					{
						amz = this.i.a(amh2, this.l);
						amz.a(true);
						this.j.Document.Pages.Add(amz);
					}
					bool flag = alz.a(amh2, ref amh);
					while (!flag)
					{
						this.a(ref amz, amh);
						amh2 = amh;
						flag = alz.a(amh2, ref amh);
					}
					i++;
				}
				else
				{
					i++;
				}
			}
			amz.b(true);
		}

		// Token: 0x0600396C RID: 14700 RVA: 0x001EE11C File Offset: 0x001ED11C
		private void f(bool A_0)
		{
			int i = 0;
			amh amh = null;
			amz amz = null;
			alz alz = new alz(this.k, this.i, this.n);
			while (i <= this.m)
			{
				if (this.f[i].e() != null)
				{
					amh amh2 = new amh(this.f[i].e(), this.h);
					if (i > 0)
					{
						this.a(ref amz, amh2);
					}
					else
					{
						amz = this.i.a(amh2, this.l);
						amz.a(true);
						this.j.Document.Pages.Add(amz);
					}
					bool flag = alz.a(amh2, ref amh, A_0);
					while (!flag)
					{
						this.a(ref amz, amh);
						amh2 = amh;
						flag = alz.a(amh2, ref amh, A_0);
					}
					i++;
				}
				else
				{
					i++;
				}
			}
			amz.b(true);
		}

		// Token: 0x0600396D RID: 14701 RVA: 0x001EE234 File Offset: 0x001ED234
		private void e(bool A_0)
		{
			int i = 0;
			amh amh = null;
			amz amz = null;
			alz alz = new alz(this.k, this.i, this.n);
			while (i <= this.m)
			{
				if (this.f[i].e() != null)
				{
					amh amh2 = new amh(this.f[i].e(), this.h);
					if (i > 0 && amz != null)
					{
						this.a(ref amz, amh2);
					}
					else
					{
						amz = this.i.a(amh2, this.l);
						amz.a(true);
						this.j.Document.Pages.Add(amz);
					}
					bool flag = alz.b(amh2, ref amh, A_0);
					while (!flag)
					{
						this.a(ref amz, amh);
						amh2 = amh;
						flag = alz.b(amh2, ref amh, A_0);
					}
					i++;
				}
				else
				{
					i++;
				}
			}
			amz.b(true);
		}

		// Token: 0x0600396E RID: 14702 RVA: 0x001EE354 File Offset: 0x001ED354
		private void d(bool A_0)
		{
			int i = 0;
			amh amh = null;
			amz amz = null;
			amh amh2 = null;
			alz alz = new alz(this.k, this.i, this.n);
			while (i <= this.m)
			{
				if (this.f[i].e() != null)
				{
					amh amh3 = new amh(this.f[i].e(), this.h);
					if (i > 0)
					{
						this.a(ref amz, amh3);
					}
					else
					{
						amz = this.i.a(amh3, this.l);
						amz.a(true);
						this.j.Document.Pages.Add(amz);
					}
					bool a_ = false;
					amh2 = this.a(amh3, this.k);
					if (amh2 != null)
					{
						a_ = true;
					}
					bool flag = alz.a(amh3, ref amh, A_0, a_);
					while (!flag)
					{
						this.a(ref amz, amh);
						amh3 = amh;
						amh2 = this.a(amh3, this.k);
						if (amh2 != null)
						{
							a_ = true;
						}
						flag = alz.a(amh3, ref amh, A_0, a_);
					}
					i++;
				}
				else
				{
					i++;
				}
			}
			if (amh2 != null && amh2.e() != null)
			{
				alz.a(ref amh2, A_0);
				if (amh2 != null)
				{
					amz.a(amh2);
				}
			}
			amz.b(true);
		}

		// Token: 0x0600396F RID: 14703 RVA: 0x001EE4EC File Offset: 0x001ED4EC
		private amh a(amh A_0, x5 A_1)
		{
			x5 a_ = x5.c();
			x5 a_2 = x5.b(A_1, this.h.a() * 2);
			amk amk = A_0.e();
			while (amk != null && x5.d(a_, a_2))
			{
				a_ = x5.f(a_, amk.d());
				amk = amk.e();
			}
			amh result;
			if (amk == null)
			{
				result = A_0.b();
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06003970 RID: 14704 RVA: 0x001EE564 File Offset: 0x001ED564
		private void a()
		{
			int i = 0;
			amh amh = null;
			amh amh2 = null;
			x5 a_ = x5.c();
			amz amz = null;
			alz alz = new alz(this.k, this.i, this.n);
			while (i <= this.m)
			{
				if (this.f[i].e() != null)
				{
					amh = new amh(this.f[i].e(), this.h);
					if (i > 0)
					{
						this.a(ref amz, amh);
					}
					else
					{
						amz = this.i.a(amh, this.l);
						amz.a(true);
						this.j.Document.Pages.Add(amz);
					}
					bool flag = alz.a(amh, ref amh2, ref a_);
					while (!flag)
					{
						a_ = x5.c();
						this.a(ref amz, amh2);
						amh = amh2;
						flag = alz.a(amh, ref amh2, ref a_);
					}
					i++;
				}
				else
				{
					i++;
				}
			}
			alz.a(amh, a_);
			amz.b(true);
		}

		// Token: 0x06003971 RID: 14705 RVA: 0x001EE69C File Offset: 0x001ED69C
		internal void a(amk A_0, x5 A_1, amk A_2, amk A_3, bool A_4)
		{
			al0 al = new al0(this.k);
			al.a(A_0, A_2, A_3, false, A_1, A_4);
		}

		// Token: 0x06003972 RID: 14706 RVA: 0x001EE6C8 File Offset: 0x001ED6C8
		private void c(bool A_0)
		{
			int i = 0;
			amg amg = null;
			alz alz = new alz(this.k, this.i, this.n);
			amz amz = this.i.a(this.f[i], this.l);
			amz.a(true);
			this.j.Document.Pages.Add(amz);
			while (i <= this.m)
			{
				if (this.f[i].e() != null)
				{
					amg amg2 = this.f[i];
					if (i > 0)
					{
						this.a(ref amz, amg2);
					}
					bool flag = alz.b(amg2, ref amg, A_0);
					while (!flag)
					{
						this.a(ref amz, amg);
						amg2 = amg;
						flag = alz.b(amg2, ref amg, A_0);
					}
					i++;
				}
				else
				{
					i++;
				}
			}
			amz.b(true);
		}

		// Token: 0x06003973 RID: 14707 RVA: 0x001EE7CC File Offset: 0x001ED7CC
		private void b(bool A_0)
		{
			int i = 0;
			amg amg = null;
			alz alz = new alz(this.k, this.i, this.n);
			amz amz = this.i.a(this.f[i], this.l);
			amz.a(true);
			this.j.Document.Pages.Add(amz);
			while (i <= this.m)
			{
				if (this.f[i].e() != null)
				{
					amg amg2 = this.f[i];
					if (i > 0)
					{
						this.a(ref amz, amg2);
					}
					bool flag = alz.a(amg2, ref amg, A_0);
					while (!flag)
					{
						this.a(ref amz, amg);
						amg2 = amg;
						flag = alz.a(amg2, ref amg, A_0);
					}
					i++;
				}
				else
				{
					i++;
				}
			}
			amz.b(true);
		}

		// Token: 0x06003974 RID: 14708 RVA: 0x001EE8D0 File Offset: 0x001ED8D0
		private void a(ref amz A_0, amg A_1)
		{
			if (A_0.a().e() == null)
			{
				A_0.a(A_1);
			}
			else
			{
				A_0 = this.i.a(A_1, this.l);
				this.j.Document.Pages.Add(A_0);
			}
		}

		// Token: 0x06003975 RID: 14709 RVA: 0x001EE930 File Offset: 0x001ED930
		private int a(bool A_0)
		{
			amk amk = this.f[this.g].e();
			amk amk2 = null;
			amg[] array = new amg[10];
			int num = -1;
			x5 x = x5.c();
			alz.a(ref array, ref num, amk, this.h);
			al0 al = new al0(this.k);
			while (amk != null)
			{
				while (amk.a(this.i))
				{
					x = amk.a(this.i, x5.c());
					amk amk3 = new ana(x);
					amk amk4 = new ana(x5.e(amk.d(), x));
					amk3.a(amk.i());
					amk4.a(amk.i());
					al.a(amk, amk3, amk4, false, x, A_0);
					amk amk5 = amk3;
					int a_;
					amk4.no(a_ = amk.nn());
					amk5.no(a_);
					if (amk3.h() != null)
					{
						if (amk2 != null)
						{
							amk2.a(amk3);
						}
						else
						{
							array[num].b(amk3);
						}
					}
					else if (amk2 != null)
					{
						amk2.a(null);
					}
					else
					{
						array[num].b(null);
					}
					if (amk4.h() != null)
					{
						amk4.a(amk.e());
						amk = amk4;
					}
					else
					{
						amk = amk.e();
					}
					if (amk == null)
					{
						break;
					}
					alz.a(ref array, ref num, amk, this.h);
					amk2 = null;
				}
				if (amk == null)
				{
					break;
				}
				amk2 = amk;
				amk = amk.e();
			}
			this.f = array;
			return num;
		}

		// Token: 0x06003976 RID: 14710 RVA: 0x001EEAF8 File Offset: 0x001EDAF8
		internal void a(amg A_0, ref amg A_1, bool A_2, SubReport A_3, bool A_4)
		{
			alz alz = new alz(this.k, this.h, this.n);
			if (A_3.Detail.AutoSplit || A_4)
			{
				alz.a(A_0, ref A_1, A_2);
			}
			else if (!A_3.Detail.AutoSplit)
			{
				alz.b(A_0, ref A_1, A_2);
			}
		}

		// Token: 0x04001B55 RID: 6997
		internal static readonly x5 a = x5.f(x5.a(), x5.a(1f));

		// Token: 0x04001B56 RID: 6998
		internal static readonly x5 b = x5.f(x5.a(), x5.a(2f));

		// Token: 0x04001B57 RID: 6999
		internal static readonly x5 c = x5.f(x5.a(), x5.a(3f));

		// Token: 0x04001B58 RID: 7000
		internal static readonly x5 d = x5.f(x5.a(), x5.a(4f));

		// Token: 0x04001B59 RID: 7001
		internal static readonly x5 e = x5.f(x5.a(), x5.a(5f));

		// Token: 0x04001B5A RID: 7002
		private amg[] f = null;

		// Token: 0x04001B5B RID: 7003
		private int g = 0;

		// Token: 0x04001B5C RID: 7004
		private alp h = null;

		// Token: 0x04001B5D RID: 7005
		private Report i = null;

		// Token: 0x04001B5E RID: 7006
		private alr j = null;

		// Token: 0x04001B5F RID: 7007
		private x5 k;

		// Token: 0x04001B60 RID: 7008
		private al2 l = null;

		// Token: 0x04001B61 RID: 7009
		private int m = 0;

		// Token: 0x04001B62 RID: 7010
		private bool n = false;
	}
}
