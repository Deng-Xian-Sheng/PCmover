using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200052B RID: 1323
	internal class air
	{
		// Token: 0x0600356A RID: 13674 RVA: 0x001D49BC File Offset: 0x001D39BC
		internal air(string A_0)
		{
			this.a = 0;
			this.b = new al5(A_0.ToCharArray(), 0, A_0.Length);
			this.a();
		}

		// Token: 0x0600356B RID: 13675 RVA: 0x001D4A0A File Offset: 0x001D3A0A
		internal air(ald A_0, char[] A_1, int A_2, int A_3)
		{
			this.a = A_2;
			this.b = new al5(A_0, A_1, A_2, A_3);
			this.a();
		}

		// Token: 0x0600356C RID: 13676 RVA: 0x001D4A48 File Offset: 0x001D3A48
		private void a()
		{
			int num = 0;
			int num2 = this.b.d();
			while (this.b.t())
			{
				if (this.b.b() == '#')
				{
					if (this.b())
					{
						break;
					}
				}
				else
				{
					al5 al = this.b;
					al.a(al.d() + 1);
				}
			}
			if (this.b.d() > num2)
			{
				this.c.a(new al4(num2, this.b.d() - num2));
			}
			if (!this.b.u())
			{
				al5 al2 = this.b;
				al2.a(al2.d() + 1);
				this.b.p();
				if (this.b.b(true))
				{
					this.c.a(this.a(ref num, this.b.c(true)));
				}
				else if (this.b.o())
				{
					this.c.a(this.b.h());
				}
				else
				{
					this.c.a(this.a(ref num, this.b.f()));
				}
				this.b.p();
				al5 al3 = this.b;
				al3.a(al3.d() + 1);
				num2 = this.b.d();
				while (this.b.t())
				{
					if (this.b.b() == '#')
					{
						if (this.b())
						{
							if (this.b.d() > num2)
							{
								this.c.a(new al4(num2, this.b.d() - num2));
							}
							al5 al4 = this.b;
							al4.a(al4.d() + 1);
							this.b.p();
							if (this.b.b(true))
							{
								this.c.a(this.a(ref num, this.b.c(true)));
							}
							else if (this.b.o())
							{
								this.c.a(this.b.h());
							}
							else
							{
								this.c.a(this.a(ref num, this.b.f()));
							}
							this.b.p();
							al5 al5 = this.b;
							al5.a(al5.d() + 1);
							num2 = this.b.d();
						}
					}
					else
					{
						al5 al6 = this.b;
						al6.a(al6.d() + 1);
					}
				}
				if (this.b.d() > num2)
				{
					this.c.a(new al4(num2, this.b.d() - num2));
				}
				this.d = this.b.e();
			}
		}

		// Token: 0x0600356D RID: 13677 RVA: 0x001D4D80 File Offset: 0x001D3D80
		internal ahp a(ref int A_0, ahq A_1)
		{
			ahp result;
			if (this.b.e() != null && this.b.e().b() > A_0)
			{
				al6 al = new al6(A_1);
				A_0 = this.b.e().b();
				result = al;
			}
			else
			{
				result = A_1;
			}
			return result;
		}

		// Token: 0x0600356E RID: 13678 RVA: 0x001D4DE0 File Offset: 0x001D3DE0
		internal bool b()
		{
			int num = this.b.d();
			bool flag = num == 0;
			bool result;
			if (this.b.c(num + 1) == '#')
			{
				al5 al = this.b;
				al.a(al.d() + 1);
				al5 al2 = this.b;
				al2.a(al2.d() + 1);
				result = false;
			}
			else if (num + 7 > this.b.w())
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

		// Token: 0x0600356F RID: 13679 RVA: 0x001D4F8C File Offset: 0x001D3F8C
		internal al3 c()
		{
			return this.c;
		}

		// Token: 0x06003570 RID: 13680 RVA: 0x001D4FA4 File Offset: 0x001D3FA4
		internal bool d()
		{
			return this.d != null && this.d.b() != 0;
		}

		// Token: 0x06003571 RID: 13681 RVA: 0x001D4FD4 File Offset: 0x001D3FD4
		internal ahs e()
		{
			return this.d;
		}

		// Token: 0x06003572 RID: 13682 RVA: 0x001D4FEC File Offset: 0x001D3FEC
		internal string a(LayoutWriter A_0)
		{
			return new string(this.b(A_0));
		}

		// Token: 0x06003573 RID: 13683 RVA: 0x001D500C File Offset: 0x001D400C
		internal char[] b(LayoutWriter A_0)
		{
			char[] result;
			if (this.c.a() == 0)
			{
				result = new char[0];
			}
			else
			{
				alq alq = new alq(this.c.a());
				this.c.a(A_0, alq, this.b.c());
				result = alq.a();
			}
			return result;
		}

		// Token: 0x06003574 RID: 13684 RVA: 0x001D506C File Offset: 0x001D406C
		internal void a(LayoutWriter A_0, alq A_1)
		{
			this.c.b(A_0, A_1, this.b.c());
		}

		// Token: 0x06003575 RID: 13685 RVA: 0x001D5088 File Offset: 0x001D4088
		internal char[] a(LayoutWriter A_0, akk A_1, alq A_2)
		{
			this.c.a(A_0, A_1, A_2, this.b.c());
			return A_2.a();
		}

		// Token: 0x06003576 RID: 13686 RVA: 0x001D50BC File Offset: 0x001D40BC
		internal string f()
		{
			return this.b.b(this.a);
		}

		// Token: 0x040019A3 RID: 6563
		private int a;

		// Token: 0x040019A4 RID: 6564
		private al5 b;

		// Token: 0x040019A5 RID: 6565
		private al3 c = new al3();

		// Token: 0x040019A6 RID: 6566
		private ahs d = null;
	}
}
