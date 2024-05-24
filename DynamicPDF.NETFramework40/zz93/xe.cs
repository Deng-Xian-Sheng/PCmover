using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.ReportElements;

namespace zz93
{
	// Token: 0x0200037B RID: 891
	internal class xe : xd
	{
		// Token: 0x060025E0 RID: 9696 RVA: 0x00161B15 File Offset: 0x00160B15
		internal xe(xg A_0, xc A_1) : base(A_0, A_1)
		{
			this.a = A_1;
		}

		// Token: 0x060025E1 RID: 9697 RVA: 0x00161B44 File Offset: 0x00160B44
		internal xd a()
		{
			return this.c;
		}

		// Token: 0x060025E2 RID: 9698 RVA: 0x00161B5C File Offset: 0x00160B5C
		internal void a(xd A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060025E3 RID: 9699 RVA: 0x00161B66 File Offset: 0x00160B66
		internal void a(rr[] A_0)
		{
			this.d = A_0;
		}

		// Token: 0x060025E4 RID: 9700 RVA: 0x00161B70 File Offset: 0x00160B70
		internal override x5 f6(PageWriter A_0, x5 A_1)
		{
			x5 result;
			if (this.a.f() == rk.a)
			{
				result = this.b(A_0, A_1);
			}
			else
			{
				result = this.a(A_0, A_1);
			}
			return result;
		}

		// Token: 0x060025E5 RID: 9701 RVA: 0x00161BB0 File Offset: 0x00160BB0
		internal override x5 f7(PageWriter A_0, x5 A_1, x5 A_2)
		{
			this.b = A_1;
			x5 result;
			if (this.a.f() == rk.a)
			{
				result = this.b(A_0, A_2);
			}
			else
			{
				result = this.a(A_0, A_2);
			}
			return result;
		}

		// Token: 0x060025E6 RID: 9702 RVA: 0x00161BF8 File Offset: 0x00160BF8
		private x5 b(PageWriter A_0, x5 A_1)
		{
			xg xg = base.e();
			x5 x = x5.c();
			if (this.a is Report)
			{
				x = x5.a((A_0.Dimensions.Body.Width - (float)((this.a.a() - 1) * (int)x5.b(this.a.b()))) / (float)this.a.a());
			}
			else
			{
				x = x5.a((((SubReport)this.a).Width - (float)((this.a.a() - 1) * (int)x5.b(this.a.b()))) / (float)this.a.a());
			}
			x5 a_ = this.a.b();
			x5 a_2 = this.a.c();
			while (xg != null)
			{
				x5 a_3 = x5.a();
				int i = 0;
				x5 x2 = this.b;
				while (i < this.a.a())
				{
					if (xg != null)
					{
						xg.gb(A_0, x2, A_1, x);
						if (x5.d(a_3, xg.d()))
						{
							a_3 = xg.d();
						}
						xg = xg.e();
						x2 = x5.f(x2, x5.f(x, a_));
					}
					i++;
				}
				if (x5.g(a_3, x5.a()))
				{
					A_1 = x5.f(A_1, x5.f(a_3, a_2));
				}
			}
			return A_1;
		}

		// Token: 0x060025E7 RID: 9703 RVA: 0x00161D94 File Offset: 0x00160D94
		private x5 a(PageWriter A_0, x5 A_1)
		{
			x5 x = A_1;
			x5 x2 = this.b;
			xg xg = base.e();
			x5 x3 = x5.c();
			if (this.a is Report)
			{
				x3 = x5.a((A_0.Dimensions.Body.Width - (float)((this.a.a() - 1) * (int)x5.b(this.a.b()))) / (float)this.a.a());
			}
			else
			{
				x3 = x5.a((((SubReport)this.a).Width - (float)((this.a.a() - 1) * (int)x5.b(this.a.b()))) / (float)this.a.a());
			}
			x5 a_ = this.a.b();
			x5 a_2 = this.a.c();
			for (int i = 0; i < this.d.Length; i++)
			{
				x5 x4 = A_1;
				if (this.d[i] != null)
				{
					for (int j = 0; j < this.d[i].a(); j++)
					{
						if (xg != null)
						{
							xg.gb(A_0, x2, x4, x3);
							x4 = x5.f(x4, x5.f(xg.d(), a_2));
							xg = xg.e();
						}
					}
					x2 = x5.f(x2, x5.f(x3, a_));
					if (x5.c(x4, x))
					{
						x = x4;
					}
				}
			}
			return x;
		}

		// Token: 0x060025E8 RID: 9704 RVA: 0x00161F3C File Offset: 0x00160F3C
		internal override xd f8(bool A_0)
		{
			xe xe = this.b();
			if (this.d != null)
			{
				xe.d = new rr[this.d.Length];
				for (int i = 0; i < this.d.Length; i++)
				{
					if (this.d[i] != null)
					{
						xe.d[i] = new rr(this.d[i].a());
					}
				}
			}
			return xe;
		}

		// Token: 0x060025E9 RID: 9705 RVA: 0x00161FBC File Offset: 0x00160FBC
		internal xe b()
		{
			xe result;
			if (base.e() != null)
			{
				xg a_ = base.e().f();
				xe xe = new xe(a_, this.a);
				for (xg xg = base.e().e(); xg != null; xg = xg.e())
				{
					a_ = xg.f();
					xe.a(a_);
				}
				if (this.a() != null)
				{
					xe.a(this.a().f());
				}
				result = xe;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060025EA RID: 9706 RVA: 0x00162050 File Offset: 0x00161050
		internal static xe a(xg A_0, xe A_1, xc A_2)
		{
			xg a_ = A_0.f();
			xe xe = new xe(a_, A_2);
			xg xg = A_1.e();
			while (xg.gc() <= A_0.gc())
			{
				xg = xg.e();
				if (xg == null)
				{
					return xe;
				}
			}
			while (xg != null)
			{
				xe.a(xg.f());
				xg = xg.e();
			}
			return xe;
		}

		// Token: 0x060025EB RID: 9707 RVA: 0x001620D4 File Offset: 0x001610D4
		internal static xe a(xg A_0, xc A_1)
		{
			xe result;
			if (A_0 != null)
			{
				xg xg = A_0.f();
				xe xe = new xe(xg, A_1);
				for (xg = A_0.e(); xg != null; xg = xg.e())
				{
					xe.a(xg.f());
				}
				result = xe;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060025EC RID: 9708 RVA: 0x00162130 File Offset: 0x00161130
		internal void a(xe[] A_0)
		{
			if (A_0.Length > 0)
			{
				base.b(A_0[0].e());
				xg xg = base.e();
				for (int i = 0; i < A_0.Length - 1; i++)
				{
					while (xg.e() != null)
					{
						xg = xg.e();
					}
					if (A_0[i + 1] != null && A_0[i + 1].e() != null)
					{
						xg.a(A_0[i + 1].e());
					}
				}
			}
		}

		// Token: 0x060025ED RID: 9709 RVA: 0x001621C4 File Offset: 0x001611C4
		internal x5 c()
		{
			x5 x = x5.c();
			if (this.a.f() == rk.a)
			{
				xg xg = base.e();
				x5 a_ = this.a.c();
				while (xg != null)
				{
					x5 a_2 = x5.a();
					for (int i = 0; i < this.a.a(); i++)
					{
						if (xg != null)
						{
							if (x5.d(a_2, xg.d()))
							{
								a_2 = xg.d();
							}
							xg = xg.e();
						}
					}
					if (x5.g(x, x5.a()))
					{
						x = x5.f(x, x5.f(a_2, a_));
					}
				}
			}
			else
			{
				xg xg = base.e();
				x5 a_ = this.a.c();
				for (int j = 0; j < this.d.Length; j++)
				{
					x5 x2 = x5.c();
					if (this.d[j] != null)
					{
						for (int k = 0; k < this.d[j].a(); k++)
						{
							if (xg != null)
							{
								x2 = x5.f(x2, x5.f(xg.d(), a_));
								xg = xg.e();
							}
						}
						if (x5.c(x2, x))
						{
							x = x2;
						}
					}
				}
			}
			return x;
		}

		// Token: 0x060025EE RID: 9710 RVA: 0x00162360 File Offset: 0x00161360
		internal x5 d()
		{
			x5 x = x5.c();
			if (this.a.f() == rk.a)
			{
				xg xg = base.e();
				x5 a_ = this.a.c();
				while (xg != null)
				{
					x5 a_2 = x5.a();
					for (int i = 0; i < this.a.a(); i++)
					{
						if (xg != null)
						{
							if (x5.d(a_2, xg.d()))
							{
								a_2 = xg.d();
							}
							xg = xg.e();
						}
					}
					if (x5.g(x, x5.a()))
					{
						x = x5.f(x, x5.f(a_2, a_));
					}
				}
			}
			else
			{
				xg xg = base.e();
				x5 a_ = this.a.c();
				for (int j = 0; j < this.d.Length; j++)
				{
					x5 x2 = x5.c();
					if (this.d[j] != null)
					{
						for (int k = 0; k < this.d[j].a(); k++)
						{
							if (xg != null)
							{
								if (xg.gh() && k == this.d[j].a() - 1)
								{
									x2 = x5.f(x2, x5.f(xg.g(), a_));
								}
								else
								{
									x2 = x5.f(x2, x5.f(xg.d(), a_));
								}
								xg = xg.e();
							}
						}
						if (x5.c(x2, x))
						{
							x = x2;
						}
					}
				}
			}
			return x;
		}

		// Token: 0x04001097 RID: 4247
		private new xc a;

		// Token: 0x04001098 RID: 4248
		private x5 b = x5.c();

		// Token: 0x04001099 RID: 4249
		private xd c = null;

		// Token: 0x0400109A RID: 4250
		private rr[] d = null;
	}
}
