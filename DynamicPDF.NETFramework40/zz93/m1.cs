using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001F7 RID: 503
	internal class m1 : kz
	{
		// Token: 0x06001681 RID: 5761 RVA: 0x000F63CC File Offset: 0x000F53CC
		internal m1(ij A_0)
		{
			this.j = A_0;
		}

		// Token: 0x06001682 RID: 5762 RVA: 0x000F6448 File Offset: 0x000F5448
		internal override lj db()
		{
			return this.b;
		}

		// Token: 0x06001683 RID: 5763 RVA: 0x000F6460 File Offset: 0x000F5460
		internal override void dc(lj A_0)
		{
			this.b = (n5)A_0;
		}

		// Token: 0x06001684 RID: 5764 RVA: 0x000F6470 File Offset: 0x000F5470
		internal override int dg()
		{
			return 1201;
		}

		// Token: 0x06001685 RID: 5765 RVA: 0x000F6488 File Offset: 0x000F5488
		internal char[] a()
		{
			return this.a;
		}

		// Token: 0x06001686 RID: 5766 RVA: 0x000F64A0 File Offset: 0x000F54A0
		internal void a(char[] A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06001687 RID: 5767 RVA: 0x000F64AC File Offset: 0x000F54AC
		internal ok b()
		{
			return this.e;
		}

		// Token: 0x06001688 RID: 5768 RVA: 0x000F64C4 File Offset: 0x000F54C4
		internal void a(ok A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06001689 RID: 5769 RVA: 0x000F64D0 File Offset: 0x000F54D0
		internal bool c()
		{
			return this.f;
		}

		// Token: 0x0600168A RID: 5770 RVA: 0x000F64E8 File Offset: 0x000F54E8
		internal void a(bool A_0)
		{
			this.f = A_0;
		}

		// Token: 0x0600168B RID: 5771 RVA: 0x000F64F4 File Offset: 0x000F54F4
		internal string d()
		{
			return this.g;
		}

		// Token: 0x0600168C RID: 5772 RVA: 0x000F650C File Offset: 0x000F550C
		internal void a(string A_0)
		{
			this.g = A_0;
		}

		// Token: 0x0600168D RID: 5773 RVA: 0x000F6518 File Offset: 0x000F5518
		internal string e()
		{
			return this.h;
		}

		// Token: 0x0600168E RID: 5774 RVA: 0x000F6530 File Offset: 0x000F5530
		internal void b(string A_0)
		{
			this.h = A_0;
		}

		// Token: 0x0600168F RID: 5775 RVA: 0x000F653C File Offset: 0x000F553C
		internal bool f()
		{
			return this.k;
		}

		// Token: 0x06001690 RID: 5776 RVA: 0x000F6554 File Offset: 0x000F5554
		internal void b(bool A_0)
		{
			this.k = A_0;
		}

		// Token: 0x06001691 RID: 5777 RVA: 0x000F6560 File Offset: 0x000F5560
		internal bool g()
		{
			return this.m;
		}

		// Token: 0x06001692 RID: 5778 RVA: 0x000F6578 File Offset: 0x000F5578
		internal void c(bool A_0)
		{
			this.m = A_0;
		}

		// Token: 0x06001693 RID: 5779 RVA: 0x000F6584 File Offset: 0x000F5584
		internal x5 h()
		{
			return this.l;
		}

		// Token: 0x06001694 RID: 5780 RVA: 0x000F659C File Offset: 0x000F559C
		internal void a(x5 A_0)
		{
			this.l = A_0;
		}

		// Token: 0x06001695 RID: 5781 RVA: 0x000F65A8 File Offset: 0x000F55A8
		internal override kz dj(x5 A_0, x5 A_1)
		{
			this.d = x5.b(((n5)this.db()).a().i());
			if (this.d > 12f)
			{
				this.d /= 2f;
			}
			this.c = this.j.c().a((n5)this.db(), this.j);
			if (this.g != null)
			{
				if (this.i == null)
				{
					this.i = new md(this.j, this.g, this.h);
					this.i.dj(A_0, A_1);
				}
				if (this.i.c() == null)
				{
					this.a = "●".ToCharArray();
					base.l(x5.a(this.c.e().GetTextWidth(this.a, this.d)));
					base.m(x5.a(this.c.e().GetAscender(this.d)));
				}
				else
				{
					base.l(this.i.aq());
					base.m(this.i.ar());
				}
				this.m = true;
			}
			else
			{
				ok ok = this.e;
				switch (ok)
				{
				case ok.f:
					break;
				case ok.g:
					this.a = "■".ToCharArray();
					base.l(x5.a(this.c.e().GetTextWidth(this.a, this.d)));
					base.m(x5.a(this.c.e().GetAscender(this.d)));
					this.m = true;
					goto IL_3EC;
				case ok.h:
					this.a = "○".ToCharArray();
					base.l(x5.a(this.c.e().GetTextWidth(this.a, this.d)));
					base.m(x5.a(this.c.e().GetAscender(this.d)));
					this.m = true;
					goto IL_3EC;
				case ok.i:
					goto IL_3EC;
				default:
					if (ok != ok.v)
					{
						if (this.e == ok.k)
						{
							this.c = l2.b();
						}
						else
						{
							this.c = this.j.c().a(this.b, this.j);
						}
						if (this.a != null)
						{
							this.d = x5.b(this.b.a().i());
							if (this.d == 0f)
							{
								this.d = 12f;
							}
							int num = this.a.Length;
							char[] array = new char[num + 1];
							Array.Copy(this.a, array, num);
							array[num] = '.';
							this.a = array;
							base.l(n4.a(this.a, 0, this.a.Length, 0f, 0f, this.c.e(), this.d));
							base.m(x5.a(this.c.e().GetAscender(this.d)));
						}
						this.m = true;
						goto IL_3EC;
					}
					break;
				}
				this.a = "●".ToCharArray();
				base.l(x5.a(this.c.e().GetTextWidth(this.a, this.d)));
				base.m(x5.a(this.c.e().GetAscender(this.d)));
				this.m = true;
				IL_3EC:;
			}
			return null;
		}

		// Token: 0x06001696 RID: 5782 RVA: 0x000F69A8 File Offset: 0x000F59A8
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			if (!this.f)
			{
				float num = x5.b(A_1);
				if (!this.f() && num > 0f)
				{
					num -= x5.b(x5.f(x5.a(this.l, 5), base.aq()));
				}
				num += x5.b(base.cc());
				A_0.SetTextMode();
				if (this.g != null && this.i != null && this.i.c() != null)
				{
					this.i.dk(A_0, x5.a(num), A_2);
				}
				else
				{
					switch (this.e)
					{
					case ok.f:
					case ok.g:
					case ok.h:
						if (this.c != null && this.a != null)
						{
							A_0.SetStrokeColor(this.b.j());
							A_0.SetFillColor(this.b.j());
							A_0.SetFont(this.c.e(), this.d - 3f);
							A_0.Write_Tm(num, x5.b(A_2));
							A_0.Write_Tj_(this.a, 0, this.a.Length, false);
						}
						break;
					case ok.i:
						if (this.g != null)
						{
							this.i.dk(A_0, x5.a(num), x5.e(A_2, base.ar()));
						}
						break;
					default:
						if (this.a != null)
						{
							A_0.SetFont(this.c.e(), this.d - 3f);
							A_0.SetFillColor(this.b.j());
							A_0.Write_Tm(num, x5.b(A_2));
							A_0.Write_Tj_(this.a, 0, this.a.Length, false);
						}
						break;
					}
				}
			}
		}

		// Token: 0x06001697 RID: 5783 RVA: 0x000F6BA8 File Offset: 0x000F5BA8
		internal override kz dm()
		{
			m1 m = new m1(this.j);
			m.j(this.dr());
			m.dc(this.db().du());
			m.a((lk)base.c5().du());
			m.a(this.a);
			m.a(this.e);
			m.a(this.g);
			m.b(this.h);
			return m;
		}

		// Token: 0x04000A5D RID: 2653
		private char[] a;

		// Token: 0x04000A5E RID: 2654
		private n5 b = null;

		// Token: 0x04000A5F RID: 2655
		private l2 c = null;

		// Token: 0x04000A60 RID: 2656
		private float d = 0f;

		// Token: 0x04000A61 RID: 2657
		private ok e = ok.v;

		// Token: 0x04000A62 RID: 2658
		private bool f = false;

		// Token: 0x04000A63 RID: 2659
		private string g = null;

		// Token: 0x04000A64 RID: 2660
		private string h = null;

		// Token: 0x04000A65 RID: 2661
		private md i = null;

		// Token: 0x04000A66 RID: 2662
		private ij j = null;

		// Token: 0x04000A67 RID: 2663
		private bool k = false;

		// Token: 0x04000A68 RID: 2664
		private x5 l = x5.c();

		// Token: 0x04000A69 RID: 2665
		private bool m = false;
	}
}
