using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;

namespace zz93
{
	// Token: 0x020005B6 RID: 1462
	internal class amh : amg
	{
		// Token: 0x060039F1 RID: 14833 RVA: 0x001F22D9 File Offset: 0x001F12D9
		internal amh(amk A_0, alp A_1) : base(A_0, A_1)
		{
			this.a = A_1;
		}

		// Token: 0x060039F2 RID: 14834 RVA: 0x001F2308 File Offset: 0x001F1308
		internal amg a()
		{
			return this.c;
		}

		// Token: 0x060039F3 RID: 14835 RVA: 0x001F2320 File Offset: 0x001F1320
		internal void a(amg A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060039F4 RID: 14836 RVA: 0x001F232A File Offset: 0x001F132A
		internal void a(ami[] A_0)
		{
			this.d = A_0;
		}

		// Token: 0x060039F5 RID: 14837 RVA: 0x001F2334 File Offset: 0x001F1334
		internal override x5 nh(PageWriter A_0, x5 A_1)
		{
			x5 result;
			if (this.a.f() == akq.a)
			{
				result = this.b(A_0, A_1);
			}
			else
			{
				result = this.a(A_0, A_1);
			}
			return result;
		}

		// Token: 0x060039F6 RID: 14838 RVA: 0x001F2374 File Offset: 0x001F1374
		internal override x5 ni(PageWriter A_0, x5 A_1, x5 A_2)
		{
			this.b = A_1;
			x5 result;
			if (this.a.f() == akq.a)
			{
				result = this.b(A_0, A_2);
			}
			else
			{
				result = this.a(A_0, A_2);
			}
			return result;
		}

		// Token: 0x060039F7 RID: 14839 RVA: 0x001F23BC File Offset: 0x001F13BC
		private x5 b(PageWriter A_0, x5 A_1)
		{
			amk amk = base.e();
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
			while (amk != null)
			{
				x5 a_3 = x5.a();
				int i = 0;
				x5 x2 = this.b;
				while (i < this.a.a())
				{
					if (amk != null)
					{
						amk.nm(A_0, x2, A_1, x);
						if (x5.d(a_3, amk.d()))
						{
							a_3 = amk.d();
						}
						amk = amk.e();
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

		// Token: 0x060039F8 RID: 14840 RVA: 0x001F2558 File Offset: 0x001F1558
		private x5 a(PageWriter A_0, x5 A_1)
		{
			x5 x = A_1;
			x5 x2 = this.b;
			amk amk = base.e();
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
						if (amk != null)
						{
							amk.nm(A_0, x2, x4, x3);
							x4 = x5.f(x4, x5.f(amk.d(), a_2));
							amk = amk.e();
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

		// Token: 0x060039F9 RID: 14841 RVA: 0x001F2700 File Offset: 0x001F1700
		internal override amg nj(bool A_0)
		{
			amh amh = this.b();
			if (this.d != null)
			{
				amh.d = new ami[this.d.Length];
				for (int i = 0; i < this.d.Length; i++)
				{
					if (this.d[i] != null)
					{
						amh.d[i] = new ami(this.d[i].a());
					}
				}
			}
			return amh;
		}

		// Token: 0x060039FA RID: 14842 RVA: 0x001F2780 File Offset: 0x001F1780
		internal amh b()
		{
			amh result;
			if (base.e() != null)
			{
				amk a_ = base.e().f();
				amh amh = new amh(a_, this.a);
				for (amk amk = base.e().e(); amk != null; amk = amk.e())
				{
					a_ = amk.f();
					amh.a(a_);
				}
				if (this.a() != null)
				{
					amh.a(this.a().f());
				}
				result = amh;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060039FB RID: 14843 RVA: 0x001F2814 File Offset: 0x001F1814
		internal static amh a(amk A_0, amh A_1, alp A_2)
		{
			amk a_ = A_0.f();
			amh amh = new amh(a_, A_2);
			amk amk = A_1.e();
			while (amk.nn() <= A_0.nn())
			{
				amk = amk.e();
				if (amk == null)
				{
					return amh;
				}
			}
			while (amk != null)
			{
				amh.a(amk.f());
				amk = amk.e();
			}
			return amh;
		}

		// Token: 0x060039FC RID: 14844 RVA: 0x001F2898 File Offset: 0x001F1898
		internal static amh a(amk A_0, alp A_1)
		{
			amh result;
			if (A_0 != null)
			{
				amk amk = A_0.f();
				amh amh = new amh(amk, A_1);
				for (amk = A_0.e(); amk != null; amk = amk.e())
				{
					amh.a(amk.f());
				}
				result = amh;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060039FD RID: 14845 RVA: 0x001F28F4 File Offset: 0x001F18F4
		internal void a(amh[] A_0)
		{
			if (A_0.Length > 0)
			{
				base.b(A_0[0].e());
				amk amk = base.e();
				for (int i = 0; i < A_0.Length - 1; i++)
				{
					while (amk.e() != null)
					{
						amk = amk.e();
					}
					if (A_0[i + 1] != null && A_0[i + 1].e() != null)
					{
						amk.a(A_0[i + 1].e());
					}
				}
			}
		}

		// Token: 0x060039FE RID: 14846 RVA: 0x001F2988 File Offset: 0x001F1988
		internal x5 c()
		{
			x5 x = x5.c();
			if (this.a.f() == akq.a)
			{
				amk amk = base.e();
				x5 a_ = this.a.c();
				while (amk != null)
				{
					x5 a_2 = x5.a();
					for (int i = 0; i < this.a.a(); i++)
					{
						if (amk != null)
						{
							if (x5.d(a_2, amk.d()))
							{
								a_2 = amk.d();
							}
							amk = amk.e();
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
				amk amk = base.e();
				x5 a_ = this.a.c();
				for (int j = 0; j < this.d.Length; j++)
				{
					x5 x2 = x5.c();
					if (this.d[j] != null)
					{
						for (int k = 0; k < this.d[j].a(); k++)
						{
							if (amk != null)
							{
								x2 = x5.f(x2, x5.f(amk.d(), a_));
								amk = amk.e();
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

		// Token: 0x060039FF RID: 14847 RVA: 0x001F2B24 File Offset: 0x001F1B24
		internal x5 d()
		{
			x5 x = x5.c();
			if (this.a.f() == akq.a)
			{
				amk amk = base.e();
				x5 a_ = this.a.c();
				while (amk != null)
				{
					x5 a_2 = x5.a();
					for (int i = 0; i < this.a.a(); i++)
					{
						if (amk != null)
						{
							if (x5.d(a_2, amk.d()))
							{
								a_2 = amk.d();
							}
							amk = amk.e();
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
				amk amk = base.e();
				x5 a_ = this.a.c();
				for (int j = 0; j < this.d.Length; j++)
				{
					x5 x2 = x5.c();
					if (this.d[j] != null)
					{
						for (int k = 0; k < this.d[j].a(); k++)
						{
							if (amk != null)
							{
								if (amk.ns() && k == this.d[j].a() - 1)
								{
									x2 = x5.f(x2, x5.f(amk.g(), a_));
								}
								else
								{
									x2 = x5.f(x2, x5.f(amk.d(), a_));
								}
								amk = amk.e();
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

		// Token: 0x04001B7D RID: 7037
		private new alp a;

		// Token: 0x04001B7E RID: 7038
		private x5 b = x5.c();

		// Token: 0x04001B7F RID: 7039
		private amg c = null;

		// Token: 0x04001B80 RID: 7040
		private ami[] d = null;
	}
}
