using System;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.ReportElements;

namespace zz93
{
	// Token: 0x0200036D RID: 877
	internal class w0
	{
		// Token: 0x06002555 RID: 9557 RVA: 0x0015D348 File Offset: 0x0015C348
		internal w0(x5 A_0, xc A_1, bool A_2)
		{
			this.n = A_2;
			this.k = A_0;
			this.h = A_1;
		}

		// Token: 0x06002556 RID: 9558 RVA: 0x0015D3AC File Offset: 0x0015C3AC
		internal void a(xd A_0, Report A_1, wu A_2, w1 A_3, bool A_4, bool A_5)
		{
			this.f = new xd[1];
			this.f[this.g] = A_0;
			this.h = A_1;
			this.i = A_1;
			this.j = A_2;
			this.l = A_3;
			if (A_5)
			{
				this.m = this.a(A_4);
			}
			if (((xc)A_1).a() <= 1)
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
			else if (A_1.Detail.AutoSplit && ((xc)A_1).f() != rk.a)
			{
				this.h(A_4);
			}
			else
			{
				this.g(A_4);
			}
		}

		// Token: 0x06002557 RID: 9559 RVA: 0x0015D47C File Offset: 0x0015C47C
		private void h(bool A_0)
		{
			rk rk = this.h.f();
			if (rk != rk.b)
			{
				if (rk == rk.c)
				{
					this.e(A_0);
				}
			}
			else
			{
				this.d(A_0);
			}
		}

		// Token: 0x06002558 RID: 9560 RVA: 0x0015D4BC File Offset: 0x0015C4BC
		private void g(bool A_0)
		{
			rk rk = this.h.f();
			if (rk != rk.a)
			{
				if (rk != rk.b)
				{
					if (rk == rk.c)
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

		// Token: 0x06002559 RID: 9561 RVA: 0x0015D50C File Offset: 0x0015C50C
		private void b()
		{
			int i = 0;
			xe xe = null;
			xq xq = null;
			ro ro = new ro(this.k, this.i, this.n);
			while (i <= this.m)
			{
				if (this.f[i].e() != null)
				{
					xe xe2 = new xe(this.f[i].e(), this.h);
					if (i > 0)
					{
						this.a(ref xq, xe2);
					}
					else
					{
						xq = this.i.a(xe2, this.l);
						xq.a(true);
						this.j.Document.Pages.Add(xq);
					}
					bool flag = ro.a(xe2, ref xe);
					while (!flag)
					{
						this.a(ref xq, xe);
						xe2 = xe;
						flag = ro.a(xe2, ref xe);
					}
					i++;
				}
				else
				{
					i++;
				}
			}
			xq.b(true);
		}

		// Token: 0x0600255A RID: 9562 RVA: 0x0015D624 File Offset: 0x0015C624
		private void f(bool A_0)
		{
			int i = 0;
			xe xe = null;
			xq xq = null;
			ro ro = new ro(this.k, this.i, this.n);
			while (i <= this.m)
			{
				if (this.f[i].e() != null)
				{
					xe xe2 = new xe(this.f[i].e(), this.h);
					if (i > 0)
					{
						this.a(ref xq, xe2);
					}
					else
					{
						xq = this.i.a(xe2, this.l);
						xq.a(true);
						this.j.Document.Pages.Add(xq);
					}
					bool flag = ro.a(xe2, ref xe, A_0);
					while (!flag)
					{
						this.a(ref xq, xe);
						xe2 = xe;
						flag = ro.a(xe2, ref xe, A_0);
					}
					i++;
				}
				else
				{
					i++;
				}
			}
			xq.b(true);
		}

		// Token: 0x0600255B RID: 9563 RVA: 0x0015D73C File Offset: 0x0015C73C
		private void e(bool A_0)
		{
			int i = 0;
			xe xe = null;
			xq xq = null;
			ro ro = new ro(this.k, this.i, this.n);
			while (i <= this.m)
			{
				if (this.f[i].e() != null)
				{
					xe xe2 = new xe(this.f[i].e(), this.h);
					if (i > 0 && xq != null)
					{
						this.a(ref xq, xe2);
					}
					else
					{
						xq = this.i.a(xe2, this.l);
						xq.a(true);
						this.j.Document.Pages.Add(xq);
					}
					bool flag = ro.b(xe2, ref xe, A_0);
					while (!flag)
					{
						this.a(ref xq, xe);
						xe2 = xe;
						flag = ro.b(xe2, ref xe, A_0);
					}
					i++;
				}
				else
				{
					i++;
				}
			}
			xq.b(true);
		}

		// Token: 0x0600255C RID: 9564 RVA: 0x0015D85C File Offset: 0x0015C85C
		private void d(bool A_0)
		{
			int i = 0;
			xe xe = null;
			xq xq = null;
			xe xe2 = null;
			ro ro = new ro(this.k, this.i, this.n);
			while (i <= this.m)
			{
				if (this.f[i].e() != null)
				{
					xe xe3 = new xe(this.f[i].e(), this.h);
					if (i > 0)
					{
						this.a(ref xq, xe3);
					}
					else
					{
						xq = this.i.a(xe3, this.l);
						xq.a(true);
						this.j.Document.Pages.Add(xq);
					}
					bool a_ = false;
					xe2 = this.a(xe3, this.k);
					if (xe2 != null)
					{
						a_ = true;
					}
					bool flag = ro.a(xe3, ref xe, A_0, a_);
					while (!flag)
					{
						this.a(ref xq, xe);
						xe3 = xe;
						xe2 = this.a(xe3, this.k);
						if (xe2 != null)
						{
							a_ = true;
						}
						flag = ro.a(xe3, ref xe, A_0, a_);
					}
					i++;
				}
				else
				{
					i++;
				}
			}
			if (xe2 != null && xe2.e() != null)
			{
				ro.a(ref xe2, A_0);
				if (xe2 != null)
				{
					xq.a(xe2);
				}
			}
			xq.b(true);
		}

		// Token: 0x0600255D RID: 9565 RVA: 0x0015D9F4 File Offset: 0x0015C9F4
		private xe a(xe A_0, x5 A_1)
		{
			x5 a_ = x5.c();
			x5 a_2 = x5.b(A_1, this.h.a() * 2);
			xg xg = A_0.e();
			while (xg != null && x5.d(a_, a_2))
			{
				a_ = x5.f(a_, xg.d());
				xg = xg.e();
			}
			xe result;
			if (xg == null)
			{
				result = A_0.b();
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600255E RID: 9566 RVA: 0x0015DA6C File Offset: 0x0015CA6C
		private void a()
		{
			int i = 0;
			xe xe = null;
			xe xe2 = null;
			x5 a_ = x5.c();
			xq xq = null;
			ro ro = new ro(this.k, this.i, this.n);
			while (i <= this.m)
			{
				if (this.f[i].e() != null)
				{
					xe = new xe(this.f[i].e(), this.h);
					if (i > 0)
					{
						this.a(ref xq, xe);
					}
					else
					{
						xq = this.i.a(xe, this.l);
						xq.a(true);
						this.j.Document.Pages.Add(xq);
					}
					bool flag = ro.a(xe, ref xe2, ref a_);
					while (!flag)
					{
						a_ = x5.c();
						this.a(ref xq, xe2);
						xe = xe2;
						flag = ro.a(xe, ref xe2, ref a_);
					}
					i++;
				}
				else
				{
					i++;
				}
			}
			ro.a(xe, a_);
			xq.b(true);
		}

		// Token: 0x0600255F RID: 9567 RVA: 0x0015DBA4 File Offset: 0x0015CBA4
		internal void a(xg A_0, x5 A_1, xg A_2, xg A_3, bool A_4)
		{
			rp rp = new rp(this.k);
			rp.a(A_0, A_2, A_3, false, A_1, A_4);
		}

		// Token: 0x06002560 RID: 9568 RVA: 0x0015DBD0 File Offset: 0x0015CBD0
		private void c(bool A_0)
		{
			int i = 0;
			xd xd = null;
			ro ro = new ro(this.k, this.i, this.n);
			xq xq = this.i.a(this.f[i], this.l);
			xq.a(true);
			this.j.Document.Pages.Add(xq);
			while (i <= this.m)
			{
				if (this.f[i].e() != null)
				{
					xd xd2 = this.f[i];
					if (i > 0)
					{
						this.a(ref xq, xd2);
					}
					bool flag = ro.b(xd2, ref xd, A_0);
					while (!flag)
					{
						this.a(ref xq, xd);
						xd2 = xd;
						flag = ro.b(xd2, ref xd, A_0);
					}
					i++;
				}
				else
				{
					i++;
				}
			}
			xq.b(true);
		}

		// Token: 0x06002561 RID: 9569 RVA: 0x0015DCD4 File Offset: 0x0015CCD4
		private void b(bool A_0)
		{
			int i = 0;
			xd xd = null;
			ro ro = new ro(this.k, this.i, this.n);
			xq xq = this.i.a(this.f[i], this.l);
			xq.a(true);
			this.j.Document.Pages.Add(xq);
			while (i <= this.m)
			{
				if (this.f[i].e() != null)
				{
					xd xd2 = this.f[i];
					if (i > 0)
					{
						this.a(ref xq, xd2);
					}
					bool flag = ro.a(xd2, ref xd, A_0);
					while (!flag)
					{
						this.a(ref xq, xd);
						xd2 = xd;
						flag = ro.a(xd2, ref xd, A_0);
					}
					i++;
				}
				else
				{
					i++;
				}
			}
			xq.b(true);
		}

		// Token: 0x06002562 RID: 9570 RVA: 0x0015DDD8 File Offset: 0x0015CDD8
		private void a(ref xq A_0, xd A_1)
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

		// Token: 0x06002563 RID: 9571 RVA: 0x0015DE38 File Offset: 0x0015CE38
		private int a(bool A_0)
		{
			xg xg = this.f[this.g].e();
			xg xg2 = null;
			xd[] array = new xd[10];
			int num = -1;
			x5 x = x5.c();
			ro.a(ref array, ref num, xg, this.h);
			rp rp = new rp(this.k);
			while (xg != null)
			{
				while (xg.a(this.i))
				{
					x = xg.a(this.i, x5.c());
					xg xg3 = new xz(x);
					xg xg4 = new xz(x5.e(xg.d(), x));
					xg3.a(xg.i());
					xg4.a(xg.i());
					rp.a(xg, xg3, xg4, false, x, A_0);
					xg xg5 = xg3;
					int a_;
					xg4.gd(a_ = xg.gc());
					xg5.gd(a_);
					if (xg3.h() != null)
					{
						if (xg2 != null)
						{
							xg2.a(xg3);
						}
						else
						{
							array[num].b(xg3);
						}
					}
					else if (xg2 != null)
					{
						xg2.a(null);
					}
					else
					{
						array[num].b(null);
					}
					if (xg4.h() != null)
					{
						xg4.a(xg.e());
						xg = xg4;
					}
					else
					{
						xg = xg.e();
					}
					if (xg == null)
					{
						break;
					}
					ro.a(ref array, ref num, xg, this.h);
					xg2 = null;
				}
				if (xg == null)
				{
					break;
				}
				xg2 = xg;
				xg = xg.e();
			}
			this.f = array;
			return num;
		}

		// Token: 0x06002564 RID: 9572 RVA: 0x0015E000 File Offset: 0x0015D000
		internal void a(xd A_0, ref xd A_1, bool A_2, SubReport A_3, bool A_4)
		{
			ro ro = new ro(this.k, this.h, this.n);
			if (A_3.Detail.AutoSplit || A_4)
			{
				ro.a(A_0, ref A_1, A_2);
			}
			else if (!A_3.Detail.AutoSplit)
			{
				ro.b(A_0, ref A_1, A_2);
			}
		}

		// Token: 0x0400106C RID: 4204
		internal static readonly x5 a = x5.f(x5.a(), x5.a(1f));

		// Token: 0x0400106D RID: 4205
		internal static readonly x5 b = x5.f(x5.a(), x5.a(2f));

		// Token: 0x0400106E RID: 4206
		internal static readonly x5 c = x5.f(x5.a(), x5.a(3f));

		// Token: 0x0400106F RID: 4207
		internal static readonly x5 d = x5.f(x5.a(), x5.a(4f));

		// Token: 0x04001070 RID: 4208
		internal static readonly x5 e = x5.f(x5.a(), x5.a(5f));

		// Token: 0x04001071 RID: 4209
		private xd[] f = null;

		// Token: 0x04001072 RID: 4210
		private int g = 0;

		// Token: 0x04001073 RID: 4211
		private xc h = null;

		// Token: 0x04001074 RID: 4212
		private Report i = null;

		// Token: 0x04001075 RID: 4213
		private wu j = null;

		// Token: 0x04001076 RID: 4214
		private x5 k;

		// Token: 0x04001077 RID: 4215
		private w1 l = null;

		// Token: 0x04001078 RID: 4216
		private int m = 0;

		// Token: 0x04001079 RID: 4217
		private bool n = false;
	}
}
