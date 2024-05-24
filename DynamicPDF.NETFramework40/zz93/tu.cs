using System;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x020002F7 RID: 759
	internal class tu
	{
		// Token: 0x060021AF RID: 8623 RVA: 0x00146D24 File Offset: 0x00145D24
		internal tu(string A_0)
		{
			this.a = 0;
			this.b = new w5(A_0.ToCharArray(), 0, A_0.Length);
			this.a();
		}

		// Token: 0x060021B0 RID: 8624 RVA: 0x00146D72 File Offset: 0x00145D72
		internal tu(wd A_0, char[] A_1, int A_2, int A_3)
		{
			this.a = A_2;
			this.b = new w5(A_0, A_1, A_2, A_3);
			this.a();
		}

		// Token: 0x060021B1 RID: 8625 RVA: 0x00146DB0 File Offset: 0x00145DB0
		private void a()
		{
			int num = 0;
			int num2 = this.b.e();
			while (this.b.u())
			{
				if (this.b.c() == '#')
				{
					if (this.b())
					{
						break;
					}
				}
				else
				{
					w5 w = this.b;
					w.a(w.e() + 1);
				}
			}
			if (this.b.e() > num2)
			{
				this.c.a(new w4(num2, this.b.e() - num2));
			}
			if (!this.b.v())
			{
				w5 w2 = this.b;
				w2.a(w2.e() + 1);
				this.b.q();
				if (this.b.b(true))
				{
					this.c.a(this.a(ref num, this.b.c(true)));
				}
				else if (this.b.p())
				{
					this.c.a(this.b.i());
				}
				else
				{
					this.c.a(this.a(ref num, this.b.g()));
				}
				this.b.q();
				w5 w3 = this.b;
				w3.a(w3.e() + 1);
				num2 = this.b.e();
				while (this.b.u())
				{
					if (this.b.c() == '#')
					{
						if (this.b())
						{
							if (this.b.e() > num2)
							{
								this.c.a(new w4(num2, this.b.e() - num2));
							}
							w5 w4 = this.b;
							w4.a(w4.e() + 1);
							this.b.q();
							if (this.b.b(true))
							{
								this.c.a(this.a(ref num, this.b.c(true)));
							}
							else if (this.b.p())
							{
								this.c.a(this.b.i());
							}
							else
							{
								this.c.a(this.a(ref num, this.b.g()));
							}
							this.b.q();
							w5 w5 = this.b;
							w5.a(w5.e() + 1);
							num2 = this.b.e();
						}
					}
					else
					{
						w5 w6 = this.b;
						w6.a(w6.e() + 1);
					}
				}
				if (this.b.e() > num2)
				{
					this.c.a(new w4(num2, this.b.e() - num2));
				}
				this.d = this.b.f();
			}
		}

		// Token: 0x060021B2 RID: 8626 RVA: 0x001470E8 File Offset: 0x001460E8
		internal q6 a(ref int A_0, q7 A_1)
		{
			q6 result;
			if (this.b.f() != null && this.b.f().b() > A_0)
			{
				rq rq = new rq(A_1);
				A_0 = this.b.f().b();
				result = rq;
			}
			else
			{
				result = A_1;
			}
			return result;
		}

		// Token: 0x060021B3 RID: 8627 RVA: 0x00147148 File Offset: 0x00146148
		internal bool b()
		{
			int num = this.b.e();
			bool flag = num == 0;
			bool result;
			if (this.b.c(num + 1) == '#')
			{
				w5 w = this.b;
				w.a(w.e() + 1);
				w5 w2 = this.b;
				w2.a(w2.e() + 1);
				result = false;
			}
			else if (num + 7 > this.b.x())
			{
				result = true;
			}
			else if ((!flag && this.b.c(num - 1) == '"' && this.b.c(num + 7) == '"') || (!flag && this.b.c(num - 1) == '\'' && this.b.c(num + 7) == '\''))
			{
				num++;
				while (this.b.c(num) != '"' || this.b.c(num) != '\'')
				{
					if ((this.b.c(num) < '0' || this.b.c(num) > '9') && (this.b.c(num) < 'A' || this.b.c(num) > 'F') && (this.b.c(num) < 'a' || this.b.c(num) > 'f'))
					{
						break;
					}
					num++;
				}
				this.b.a(num);
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x060021B4 RID: 8628 RVA: 0x001472F4 File Offset: 0x001462F4
		internal w2 c()
		{
			return this.c;
		}

		// Token: 0x060021B5 RID: 8629 RVA: 0x0014730C File Offset: 0x0014630C
		internal bool d()
		{
			return this.d != null && this.d.b() != 0;
		}

		// Token: 0x060021B6 RID: 8630 RVA: 0x0014733C File Offset: 0x0014633C
		internal sz e()
		{
			return this.d;
		}

		// Token: 0x060021B7 RID: 8631 RVA: 0x00147354 File Offset: 0x00146354
		internal string a(LayoutWriter A_0)
		{
			return new string(this.b(A_0));
		}

		// Token: 0x060021B8 RID: 8632 RVA: 0x00147374 File Offset: 0x00146374
		internal char[] b(LayoutWriter A_0)
		{
			char[] result;
			if (this.c.a() == 0)
			{
				result = new char[0];
			}
			else
			{
				wt wt = new wt(this.c.a());
				this.c.a(A_0, wt, this.b.d());
				result = wt.a();
			}
			return result;
		}

		// Token: 0x060021B9 RID: 8633 RVA: 0x001473D4 File Offset: 0x001463D4
		internal void a(LayoutWriter A_0, wt A_1)
		{
			this.c.b(A_0, A_1, this.b.d());
		}

		// Token: 0x060021BA RID: 8634 RVA: 0x001473F0 File Offset: 0x001463F0
		internal char[] a(LayoutWriter A_0, vi A_1, wt A_2)
		{
			this.c.a(A_0, A_1, A_2, this.b.d());
			return A_2.a();
		}

		// Token: 0x060021BB RID: 8635 RVA: 0x00147424 File Offset: 0x00146424
		internal string f()
		{
			return this.b.b(this.a);
		}

		// Token: 0x04000EB1 RID: 3761
		private int a;

		// Token: 0x04000EB2 RID: 3762
		private w5 b;

		// Token: 0x04000EB3 RID: 3763
		private w2 c = new w2();

		// Token: 0x04000EB4 RID: 3764
		private sz d = null;
	}
}
