using System;
using System.Collections.Generic;
using System.Text;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x0200021D RID: 541
	internal class n3 : kz
	{
		// Token: 0x06001929 RID: 6441 RVA: 0x00108874 File Offset: 0x00107874
		internal n3()
		{
		}

		// Token: 0x0600192A RID: 6442 RVA: 0x0010892C File Offset: 0x0010792C
		internal n3(char[] A_0, int A_1, int A_2, ij A_3)
		{
			this.l = A_3;
			this.a = A_0;
			this.b = A_1;
			this.d = A_1;
			this.c = A_2;
			base.h(A_2);
			if (A_0[A_1] == ' ')
			{
				base.r(true);
			}
			if (A_2 == 1 && A_0.Length == 1)
			{
				base.s(true);
			}
			else if (A_1 + A_2 < A_0.Length)
			{
				if (A_0[A_1 + A_2] == ' ' || A_0[A_1 + A_2] == '\n' || A_0[A_1 + A_2] == '\r')
				{
					base.s(true);
				}
			}
			if (A_3.k())
			{
				int num = -1;
				for (int i = this.b; i < this.b + this.c; i++)
				{
					if (A_0[i] == '%' && A_0[i + 1] == '%')
					{
						if (num < 0)
						{
							num = i;
							i++;
						}
						else
						{
							int a_ = i - num + 2;
							this.a(num, a_);
							i++;
							num = -1;
						}
					}
				}
			}
		}

		// Token: 0x0600192B RID: 6443 RVA: 0x00108B18 File Offset: 0x00107B18
		private void a(int A_0, int A_1)
		{
			if (this.z == null)
			{
				this.z = new List<m9>();
			}
			char[] array = new char[A_1];
			Array.Copy(this.a, A_0, array, 0, array.Length);
			ahl a_ = new ahl(array, 0, ' ');
			m9 m = new m9();
			m.a(A_0);
			m.b(A_1);
			m.a(a_);
			this.z.Add(m);
		}

		// Token: 0x0600192C RID: 6444 RVA: 0x00108B94 File Offset: 0x00107B94
		internal override lj db()
		{
			return this.i;
		}

		// Token: 0x0600192D RID: 6445 RVA: 0x00108BAC File Offset: 0x00107BAC
		internal override void dc(lj A_0)
		{
			this.i = (n5)A_0;
			this.k = this.l.c().a(this.i, this.l);
			if (this.k != null && !this.k.e().jo())
			{
				this.k = this.l.c().a();
			}
		}

		// Token: 0x0600192E RID: 6446 RVA: 0x00108C20 File Offset: 0x00107C20
		internal bool c()
		{
			return this.j;
		}

		// Token: 0x0600192F RID: 6447 RVA: 0x00108C38 File Offset: 0x00107C38
		internal void a(bool A_0)
		{
			this.j = A_0;
		}

		// Token: 0x06001930 RID: 6448 RVA: 0x00108C44 File Offset: 0x00107C44
		internal char[] d()
		{
			return this.a;
		}

		// Token: 0x06001931 RID: 6449 RVA: 0x00108C5C File Offset: 0x00107C5C
		internal void a(char[] A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06001932 RID: 6450 RVA: 0x00108C68 File Offset: 0x00107C68
		internal bool e()
		{
			return this.n;
		}

		// Token: 0x06001933 RID: 6451 RVA: 0x00108C80 File Offset: 0x00107C80
		internal void b(bool A_0)
		{
			this.n = A_0;
		}

		// Token: 0x06001934 RID: 6452 RVA: 0x00108C8C File Offset: 0x00107C8C
		internal int f()
		{
			return this.b;
		}

		// Token: 0x06001935 RID: 6453 RVA: 0x00108CA4 File Offset: 0x00107CA4
		internal int g()
		{
			return this.b + this.c;
		}

		// Token: 0x06001936 RID: 6454 RVA: 0x00108CC3 File Offset: 0x00107CC3
		internal void b(int A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001937 RID: 6455 RVA: 0x00108CD0 File Offset: 0x00107CD0
		internal int h()
		{
			return this.d;
		}

		// Token: 0x06001938 RID: 6456 RVA: 0x00108CE8 File Offset: 0x00107CE8
		internal void c(int A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06001939 RID: 6457 RVA: 0x00108CF4 File Offset: 0x00107CF4
		internal x5 i()
		{
			return x5.a(this.g);
		}

		// Token: 0x0600193A RID: 6458 RVA: 0x00108D12 File Offset: 0x00107D12
		internal void a(x5 A_0)
		{
			this.g = x5.b(A_0);
		}

		// Token: 0x0600193B RID: 6459 RVA: 0x00108D24 File Offset: 0x00107D24
		internal l2 j()
		{
			return this.k;
		}

		// Token: 0x0600193C RID: 6460 RVA: 0x00108D3C File Offset: 0x00107D3C
		internal void a(l2 A_0)
		{
			this.k = A_0;
			if (this.dr().dg() != 445520207)
			{
				if (this.k != null && !this.k.e().jo())
				{
					this.k = this.l.c().a();
				}
			}
		}

		// Token: 0x0600193D RID: 6461 RVA: 0x00108DA4 File Offset: 0x00107DA4
		internal bool k()
		{
			return this.u;
		}

		// Token: 0x0600193E RID: 6462 RVA: 0x00108DBC File Offset: 0x00107DBC
		internal void c(bool A_0)
		{
			this.u = A_0;
		}

		// Token: 0x0600193F RID: 6463 RVA: 0x00108DC8 File Offset: 0x00107DC8
		internal x5 l()
		{
			x5 x = this.i.a().i();
			if (x5.h(x, x5.c()) && this.i.a().d())
			{
				this.i.a().a(x5.a(12f));
				x = x5.a(12f);
			}
			return x;
		}

		// Token: 0x06001940 RID: 6464 RVA: 0x00108E3C File Offset: 0x00107E3C
		internal x5 m()
		{
			return this.i.p().Value;
		}

		// Token: 0x06001941 RID: 6465 RVA: 0x00108E64 File Offset: 0x00107E64
		internal bool n()
		{
			return this.e;
		}

		// Token: 0x06001942 RID: 6466 RVA: 0x00108E7C File Offset: 0x00107E7C
		internal void d(bool A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06001943 RID: 6467 RVA: 0x00108E88 File Offset: 0x00107E88
		internal bool o()
		{
			return this.o;
		}

		// Token: 0x06001944 RID: 6468 RVA: 0x00108EA0 File Offset: 0x00107EA0
		internal void e(bool A_0)
		{
			this.o = A_0;
		}

		// Token: 0x06001945 RID: 6469 RVA: 0x00108EAC File Offset: 0x00107EAC
		internal bool p()
		{
			return this.p;
		}

		// Token: 0x06001946 RID: 6470 RVA: 0x00108EC4 File Offset: 0x00107EC4
		internal void f(bool A_0)
		{
			this.p = A_0;
		}

		// Token: 0x06001947 RID: 6471 RVA: 0x00108ED0 File Offset: 0x00107ED0
		internal ij q()
		{
			return this.l;
		}

		// Token: 0x06001948 RID: 6472 RVA: 0x00108EE8 File Offset: 0x00107EE8
		internal void a(ij A_0)
		{
			this.l = A_0;
		}

		// Token: 0x06001949 RID: 6473 RVA: 0x00108EF4 File Offset: 0x00107EF4
		internal agd[] r()
		{
			return this.q;
		}

		// Token: 0x0600194A RID: 6474 RVA: 0x00108F0C File Offset: 0x00107F0C
		internal void a(agd[] A_0)
		{
			this.q = A_0;
		}

		// Token: 0x0600194B RID: 6475 RVA: 0x00108F18 File Offset: 0x00107F18
		internal int s()
		{
			return this.s;
		}

		// Token: 0x0600194C RID: 6476 RVA: 0x00108F30 File Offset: 0x00107F30
		internal void d(int A_0)
		{
			this.s = A_0;
		}

		// Token: 0x0600194D RID: 6477 RVA: 0x00108F3C File Offset: 0x00107F3C
		internal int t()
		{
			return this.t;
		}

		// Token: 0x0600194E RID: 6478 RVA: 0x00108F54 File Offset: 0x00107F54
		internal void e(int A_0)
		{
			this.t = A_0;
		}

		// Token: 0x0600194F RID: 6479 RVA: 0x00108F60 File Offset: 0x00107F60
		internal afr u()
		{
			return this.aa;
		}

		// Token: 0x06001950 RID: 6480 RVA: 0x00108F78 File Offset: 0x00107F78
		internal void a(afr A_0)
		{
			this.aa = A_0;
		}

		// Token: 0x06001951 RID: 6481 RVA: 0x00108F84 File Offset: 0x00107F84
		internal override int dg()
		{
			return 100;
		}

		// Token: 0x06001952 RID: 6482 RVA: 0x00108F98 File Offset: 0x00107F98
		internal bool v()
		{
			return this.v;
		}

		// Token: 0x06001953 RID: 6483 RVA: 0x00108FB0 File Offset: 0x00107FB0
		internal void g(bool A_0)
		{
			this.v = A_0;
		}

		// Token: 0x06001954 RID: 6484 RVA: 0x00108FBC File Offset: 0x00107FBC
		internal bool w()
		{
			return this.x;
		}

		// Token: 0x06001955 RID: 6485 RVA: 0x00108FD4 File Offset: 0x00107FD4
		internal void h(bool A_0)
		{
			this.x = A_0;
		}

		// Token: 0x06001956 RID: 6486 RVA: 0x00108FE0 File Offset: 0x00107FE0
		internal int x()
		{
			return this.y;
		}

		// Token: 0x06001957 RID: 6487 RVA: 0x00108FF8 File Offset: 0x00107FF8
		internal void f(int A_0)
		{
			this.y = A_0;
		}

		// Token: 0x06001958 RID: 6488 RVA: 0x00109004 File Offset: 0x00108004
		private void a(PageWriter A_0, float A_1, float A_2)
		{
			float num = A_2;
			bool flag = false;
			for (int i = 0; i < this.i.m().Length; i++)
			{
				switch (this.i.m()[i])
				{
				case gx.b:
					A_2 += this.h * 0.2f;
					flag = true;
					break;
				case gx.c:
					A_2 -= this.g + this.h * 0.1f;
					flag = true;
					break;
				case gx.d:
					A_2 -= this.g / 2.5f;
					A_2 += this.h * 0.1f;
					flag = true;
					break;
				}
				if (flag)
				{
					A_0.SetGraphicsMode();
					A_0.SetLineWidth(this.h * 0.05f);
					A_0.SetLineCap(LineCap.Butt);
					A_0.SetStrokeColor(this.i.j());
					A_0.Write_m_(A_1, A_2);
					A_0.Write_l_(A_1 + x5.b(base.aq()), A_2);
					A_0.Write_S();
				}
				A_2 = num;
				flag = false;
			}
		}

		// Token: 0x06001959 RID: 6489 RVA: 0x00109120 File Offset: 0x00108120
		private void b()
		{
			int i = this.d;
			int num = this.d + base.ba();
			i1 i2 = this.i.s();
			while (i < num)
			{
				char c = this.a[i];
				if (c != ' ')
				{
					switch (i2)
					{
					case i1.b:
						if (i == this.d)
						{
							this.a[i] = char.ToUpper(this.a[i]);
						}
						break;
					case i1.c:
						this.a[i] = char.ToUpper(this.a[i]);
						break;
					case i1.d:
						this.a[i] = char.ToLower(this.a[i]);
						break;
					}
				}
				else if (i + 1 < num)
				{
					if (i2 == i1.b && this.a[i + 1] != ' ')
					{
						this.a[i + 1] = char.ToUpper(this.a[i + 1]);
					}
				}
				i++;
			}
		}

		// Token: 0x0600195A RID: 6490 RVA: 0x00109238 File Offset: 0x00108238
		private int a(int A_0)
		{
			int num = 0;
			int i = this.d;
			int num2 = this.d + base.ba();
			while (i < num2)
			{
				char c = this.a[i];
				if (c != '\t')
				{
					i++;
					num++;
				}
				else
				{
					int j = i;
					int num3;
					if (num < 8)
					{
						num3 = 8 - num;
					}
					else
					{
						num3 = num % 8;
						num3 = 8 - num3;
					}
					char[] array = new char[i + num3];
					Array.Copy(this.a, array, j);
					while (j < array.Length)
					{
						array[j] = ' ';
						j++;
					}
					A_0 += num3 - 1;
					num2 += num3 - 1;
					int num4 = this.a.Length - i;
					char[] array2 = new char[num4 - 1];
					int sourceIndex = i + 1;
					Array.Copy(this.a, sourceIndex, array2, 0, num4 - 1);
					this.a = new char[array.Length + array2.Length];
					Array.Copy(array, 0, this.a, 0, array.Length);
					Array.Copy(array2, 0, this.a, array.Length, array2.Length);
					num = 0;
					i = j;
				}
			}
			return A_0;
		}

		// Token: 0x0600195B RID: 6491 RVA: 0x00109378 File Offset: 0x00108378
		private l2 a(uint A_0)
		{
			if (A_0 == age.c)
			{
				A_0 = age.t;
			}
			l2 result;
			if (this.x)
			{
				result = this.l.c().b();
			}
			else if (r8.g.ContainsKey(A_0))
			{
				List<string> list = r8.g[A_0];
				if (list != null && list.Count > 1)
				{
					string a_ = list[0];
					result = this.l.c().a(a_, this.i, this.l);
				}
				else
				{
					result = this.l.c().a();
				}
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600195C RID: 6492 RVA: 0x0010943A File Offset: 0x0010843A
		internal override void di()
		{
			this.dh();
		}

		// Token: 0x0600195D RID: 6493 RVA: 0x00109444 File Offset: 0x00108444
		internal override x5 dh()
		{
			if (x5.h(this.dp(), x5.c()))
			{
				float num = x5.b(this.i.k().Value);
				float num2 = x5.b(this.i.f().Value);
				x5 a_ = x5.c();
				float num3 = 0f;
				float num4 = 0f;
				float num5 = 0f;
				float num6 = 0f;
				this.h = x5.b(this.l());
				int num7 = 0;
				if (this.u)
				{
					if (this.z == null)
					{
						this.a();
					}
					else
					{
						StringBuilder stringBuilder = new StringBuilder();
						int num8 = this.b;
						for (int i = 0; i < this.z.Count; i++)
						{
							stringBuilder.Append(this.a, num8, this.z[i].a() - num8);
							stringBuilder.Append(new char[]
							{
								'0'
							}, 0, 1);
							num8 = this.z[i].a() + this.z[i].b();
							if (i + 1 == this.z.Count)
							{
								stringBuilder.Append(this.a, num8, this.b + this.c - num8);
							}
						}
						char[] array = this.a;
						int num9 = this.d;
						int a_2 = base.ba();
						this.a = stringBuilder.ToString().ToCharArray();
						this.d = 0;
						base.h(this.a.Length);
						this.a();
						this.a = array;
						this.d = num9;
						base.h(a_2);
					}
				}
				int num10 = this.d;
				int num11 = 0;
				gu gu = ((n5)this.db()).c();
				int num12 = 0;
				bool flag = false;
				float num13 = 0f;
				for (int i = 0; i < this.aa.b().Length; i++)
				{
					agd agd = this.aa.b()[i];
					if (agd != null)
					{
						l2 l = this.aa.c()[i];
						int num14 = this.aa.e()[i];
						if (!this.u)
						{
							this.s = num14;
							num14 = ((num14 < agd.a()) ? num14 : 0);
							num12 = num14;
						}
						do
						{
							char c = agd.b(agd.a(num14).a());
							if (num14 == 0 && num5 == 0f && n4.a(c))
							{
								base.k(num14);
							}
							if (num14 == agd.a() - 1 && n4.a(c))
							{
								base.k(num14);
							}
							if (c != ' ')
							{
								if (!flag)
								{
									if (num12 - this.s > 0 && num12 < agd.a())
									{
										num3 += (float)((int)l.e().jf(agd.a(num14)) + agd.a(num14).e());
									}
									else
									{
										num3 = (float)l.e().jf(agd.a(num14));
									}
								}
								else if (num12 < agd.a() - 1)
								{
									num3 += (float)((int)l.e().jf(agd.a(num14)) + agd.a(num14).e());
								}
								else
								{
									num3 = (float)l.e().jf(agd.a(num14));
								}
								num4 += num2;
								num11++;
							}
							else
							{
								num3 = num3 * this.h / 1000f;
								num4 += num3;
								float num15 = (float)l.e().jf(agd.a(num14)) * this.h / 1000f;
								if (num10 == this.d)
								{
									base.aq(x5.a(num4));
									num13 = num4;
								}
								else
								{
									num13 = num4;
									this.y = num11;
								}
								if (x5.d(a_, x5.a(num4)))
								{
									a_ = x5.a(num4);
									this.q(num11);
									if (num11 + 1 < agd.a())
									{
										base.s(true);
										base.t(false);
									}
								}
								num7++;
								num10 += num12 + 1;
								num5 += num4 + num15;
								num5 += num + num2;
								num6 += num4 + num15 + num + num2;
								num3 = 0f;
								num4 = 0f;
								num11 = 0;
							}
							num12++;
							num14++;
						}
						while (num14 < agd.a());
						if (num3 > 0f)
						{
							num3 = num3 * this.h / 1000f;
							num4 += num3;
							num5 += num4;
							num6 += num4;
							if (num10 == this.d)
							{
								base.aq(x5.a(num4));
								num13 = num4;
							}
							else
							{
								num13 = num4;
								this.y = num11;
							}
							if (x5.d(a_, x5.a(num4)))
							{
								a_ = x5.a(num4);
								this.q(num12);
								if (num12 + 1 < agd.a())
								{
									base.t(false);
								}
							}
							base.s(false);
							num7++;
						}
						base.ar(x5.a(num13));
						base.i(num7);
						num12 = 0;
						this.aa.a(num6, i);
						num6 = 0f;
						num4 = 0f;
						num13 = 0f;
						num7 = 0;
					}
				}
				this.a7(x5.a(num5));
				this.a8(a_);
			}
			return this.dp();
		}

		// Token: 0x0600195E RID: 6494 RVA: 0x00109AE8 File Offset: 0x00108AE8
		internal override kz dj(x5 A_0, x5 A_1)
		{
			float num = x5.b(this.i.k().Value);
			float num2 = x5.b(this.i.f().Value);
			base.af(x5.a(num2));
			base.ag(x5.a(num));
			this.h = x5.b(this.l());
			if (this.h == 0f)
			{
				this.h = 12f;
			}
			this.f = this.k.e().GetDefaultLeading(this.h);
			base.ac(x5.a(this.f));
			x5? x = this.i.n().a();
			bool a_ = false;
			if (this.d < this.a.Length && this.a[this.d] == ' ' && this.dr().by() == 1 && base.by() == 1)
			{
				if (!this.j)
				{
					if (base.ba() > 1)
					{
						this.d++;
						base.h(base.ba() - 1);
					}
				}
			}
			if (this.i.r() == gn.b || this.c3())
			{
				if (this.d < base.ba())
				{
					if (this.a.Length > this.d + base.ba() && this.a[this.d + base.ba()] == ' ')
					{
						if (!this.j)
						{
							base.h(base.ba() - 1);
						}
					}
				}
			}
			if (this.aa == null)
			{
				this.a();
			}
			bool flag;
			if (this.ds() != null)
			{
				x5? x2 = this.ds();
				x5 a_2 = x5.c();
				flag = (x2 == null || !x5.h(x2.GetValueOrDefault(), a_2));
			}
			else
			{
				flag = true;
			}
			if (!flag)
			{
				this.a(new x5?(x5.a(1f)));
			}
			if (x == null && this.h < 11f && !this.g(this.dr().dg()))
			{
				base.ac(x5.a(this.k.e().GetDefaultLeading(this.h)));
				this.g = this.k.e().GetBaseLine(this.h, x5.b(base.a7()));
				base.m(n4.a(this.k.e(), this.h, this.ds(), this.i.n().c()));
			}
			else
			{
				this.g = this.k.e().GetBaseLine(this.h, this.f);
				base.m(n4.a(this.k.e(), x5.b(this.l()), this.ds(), this.i.n().c()));
			}
			x5 a_3 = x5.c();
			if (x5.h(this.dn(), x5.c()))
			{
				this.di();
			}
			a_3 = this.dn();
			kz result;
			if (this.o())
			{
				result = this.a(A_0, A_1, x);
			}
			else
			{
				if (!this.n)
				{
					base.ad(base.ar());
					base.ae(this.l());
					base.w(x5.a(this.k.e().GetAscender(this.h)));
					base.x(x5.d(x5.a(this.k.e().GetDescender(this.h))));
					this.dr().w(base.a1());
					this.dr().x(base.a2());
					base.y(base.a1());
					base.z(base.a2());
					base.aa(x5.a(this.k.e().GetLineGap(this.h)));
					if (base.bt())
					{
						this.dr().ao(x5.a((float)this.k.e().jn() * this.h / 1000f));
						this.dr().ap(x5.a((float)this.k.e().jn() * x5.b(this.dr().dr().a9()) / 1000f));
					}
					else if (base.bu())
					{
						this.dr().an(x5.a((float)this.k.e().jm() * x5.b(this.dr().dr().a9()) / 1000f));
					}
					if (this.ds() != null)
					{
						if (this.i.n().c() != mw.d)
						{
							this.i.n().b(x);
						}
						else
						{
							this.i.n().b(new x5?(x5.a(this.h * x5.b(x.Value))));
						}
					}
					else
					{
						this.i.n().b(new x5?(x5.f(x5.f(base.a3(), base.a4()), base.a5())));
					}
					if (!this.j)
					{
						x5 x3 = x5.c();
						x5 a_4 = x5.c();
						if (x5.c(a_3, x5.f(A_0, x5.a(0.001))) && x5.b(base.ar(), A_1))
						{
							for (int i = 0; i < this.aa.b().Length; i++)
							{
								agd agd = this.aa.b()[i];
								if (agd != null)
								{
									l2 l = this.aa.c()[i];
									x3 = x5.a(this.aa.d()[i]);
									if (x5.c(x3, x5.f(A_0, x5.a(0.001))) && x5.b(base.ar(), A_1))
									{
										kz kz = n4.a(this, null, A_0, this.j, ref a_, i);
										if (kz != null)
										{
											base.an(a_);
											return kz;
										}
										base.an(a_);
										if (this.cx())
										{
											base.l(a_3);
										}
										this.t = this.q.Length;
										return null;
									}
									else if (x5.c(base.ar(), A_1))
									{
										this.am(false);
										this.dr().am(false);
										base.an(a_);
										return this;
									}
								}
								a_4 = x5.f(a_4, x3);
								A_0 = x5.e(A_0, x3);
							}
							base.l(a_4);
						}
						else
						{
							if (this.v)
							{
								for (int i = 0; i < this.aa.b().Length; i++)
								{
									agd agd = this.aa.b()[i];
									if (agd != null)
									{
										l2 l = this.aa.c()[i];
										x3 = x5.a(this.aa.d()[i]);
										if (i == this.aa.d().Length - 1)
										{
											kz kz = n4.a(this, null, A_0, this.j, ref a_, i);
											if (kz != null)
											{
												base.an(a_);
												return kz;
											}
											base.an(a_);
											this.t = this.q.Length;
											return null;
										}
									}
								}
							}
							if (x5.c(base.ar(), A_1))
							{
								this.am(false);
								this.dr().am(false);
								base.an(a_);
								return this;
							}
							base.l(a_3);
							this.t = this.q.Length;
						}
					}
					else
					{
						if (x5.c(base.ar(), A_1))
						{
							this.am(false);
							this.dr().am(false);
							base.an(a_);
							return this;
						}
						base.l(a_3);
						this.t = this.q.Length;
					}
				}
				else
				{
					base.l(a_3);
				}
				result = null;
			}
			return result;
		}

		// Token: 0x0600195F RID: 6495 RVA: 0x0010A490 File Offset: 0x00109490
		internal override kz dl()
		{
			x5 x = x5.c();
			for (int i = 0; i < this.aa.b().Length; i++)
			{
				agd agd = this.aa.b()[i];
				if (agd != null)
				{
					l2 l = this.aa.c()[i];
					x = x5.a(this.aa.d()[i]);
					int num = this.aa.f()[i];
					kz result;
					if (num > 1)
					{
						this.aa.f()[i] = num - this.y;
						base.l(x5.e(base.aq(), base.b3()));
						nn nn = new nn(this, true, i, num - this.y);
						base.an(true);
						result = nn;
					}
					else
					{
						base.an(false);
						result = this;
					}
					return result;
				}
			}
			return null;
		}

		// Token: 0x06001960 RID: 6496 RVA: 0x0010A598 File Offset: 0x00109598
		private void a()
		{
			if (!this.w)
			{
				this.w = true;
				if (this.i.s() != i1.a)
				{
					this.b();
				}
				if (this.d < this.a.Length && this.a[this.d] == ' ')
				{
					if ((this.dr().by() == 1 && base.by() == 1) || base.bp())
					{
						if (!this.j)
						{
							if (base.ba() > 1)
							{
								this.d++;
								base.h(base.ba() - 1);
							}
						}
					}
				}
				if (this.i.r() == gn.b || this.c3())
				{
					if (this.d < this.a.Length)
					{
						if (this.a[this.d + base.ba() - 1] == ' ')
						{
							if (!this.j)
							{
								base.h(base.ba() - 1);
							}
						}
					}
				}
				base.h(this.a(base.ba()));
				if (!this.i.a().b())
				{
					agd a_ = ((r5)this.k.e().Encoder).a(this.a, this.d, this.d + base.ba(), true);
					this.a(a_, this.k);
				}
				else
				{
					int i = this.d;
					int num = base.ba();
					while (i < this.d + base.ba())
					{
						l2 l = this.a(age.a(this.a[i]).Key);
						if (l == null)
						{
							l = this.k;
						}
						int num2 = 0;
						this.a(l, i, num, ref num2);
						if (num2 <= i)
						{
							break;
						}
						num -= num2 - i;
						i = num2;
					}
				}
			}
		}

		// Token: 0x06001961 RID: 6497 RVA: 0x0010A7F8 File Offset: 0x001097F8
		private void a(l2 A_0, int A_1, int A_2, ref int A_3)
		{
			agd a_ = ((r5)A_0.e().Encoder).a(this.a, A_1, A_2, ref A_3);
			this.a(a_, A_0);
		}

		// Token: 0x06001962 RID: 6498 RVA: 0x0010A830 File Offset: 0x00109830
		private void a(agd A_0, l2 A_1)
		{
			if (this.aa == null)
			{
				this.aa = new afr(A_0, A_1);
			}
			else
			{
				this.aa.a(A_0, A_1);
			}
			if (A_0.b() != null && A_0.b().Count > 0)
			{
				foreach (agf agf in A_0.b())
				{
					A_0.a(agf.a(), agf.b() - agf.a() + 1);
				}
			}
		}

		// Token: 0x06001963 RID: 6499 RVA: 0x0010A8F4 File Offset: 0x001098F4
		internal kz a(x5 A_0, x5 A_1, x5? A_2)
		{
			base.ad(base.ar());
			base.ae(this.l());
			base.w(x5.a(this.k.e().GetAscender(this.h)));
			base.x(x5.d(x5.a(this.k.e().GetDescender(this.h))));
			this.dr().w(base.a1());
			this.dr().x(base.a2());
			base.y(base.a1());
			base.z(base.a2());
			base.aa(x5.a(this.k.e().GetLineGap(this.h)));
			if (this.ds() != null)
			{
				if (this.i.n().c() != mw.d)
				{
					this.i.n().b(A_2);
				}
				else
				{
					this.i.n().b(new x5?(x5.a(this.h * x5.b(A_2.Value))));
				}
			}
			else
			{
				this.i.n().b(new x5?(x5.f(x5.f(base.a3(), base.a4()), base.a5())));
			}
			return this.a(A_0, A_1);
		}

		// Token: 0x06001964 RID: 6500 RVA: 0x0010AA7C File Offset: 0x00109A7C
		internal x5 y()
		{
			return this.m;
		}

		// Token: 0x06001965 RID: 6501 RVA: 0x0010AA94 File Offset: 0x00109A94
		internal void b(x5 A_0)
		{
			this.m = A_0;
		}

		// Token: 0x06001966 RID: 6502 RVA: 0x0010AAA0 File Offset: 0x00109AA0
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			if (this.z == null)
			{
				this.a(A_0, A_1, A_2);
			}
			else
			{
				StringBuilder stringBuilder = new StringBuilder();
				int num = this.b;
				for (int i = 0; i < this.z.Count; i++)
				{
					stringBuilder.Append(this.a, num, this.z[i].a() - num);
					int charCount = 0;
					char[] value;
					if (this.z[i].c().a())
					{
						int a_ = A_0.DocumentWriter.z();
						value = this.z[i].c().a(A_0.DocumentWriter.CurrentSection, ref charCount, A_0.PageNumber, A_0.Document.Pages.Count, A_0.SectionPageNumber, a_);
					}
					else
					{
						value = this.z[i].c().a(A_0.DocumentWriter.CurrentSection, ref charCount, A_0.PageNumber, A_0.Document.Pages.Count, A_0.SectionPageNumber);
					}
					stringBuilder.Append(value, 0, charCount);
					num = this.z[i].a() + this.z[i].b();
					if (i + 1 == this.z.Count)
					{
						stringBuilder.Append(this.a, num, this.b + this.c - num);
					}
				}
				char[] array = this.a;
				int num2 = this.d;
				int a_2 = base.ba();
				this.a = stringBuilder.ToString().ToCharArray();
				this.d = 0;
				base.h(this.a.Length);
				this.aa = null;
				this.w = false;
				this.a();
				x5 a_3 = x5.e(n4.a(this.a, this.d, base.ba(), x5.b(this.i.k().Value), x5.b(this.i.f().Value), this.k.e(), x5.b(this.l())), x5.a(0.001f));
				if (x5.c(a_3, base.aq()))
				{
					switch (this.i.r())
					{
					case gn.b:
						base.au(x5.e(base.cc(), x5.e(a_3, base.aq())));
						break;
					case gn.c:
						base.au(x5.e(base.cc(), x5.a(x5.e(a_3, base.aq()), 2)));
						break;
					}
				}
				this.a(A_0, A_1, A_2);
				this.a = array;
				this.d = num2;
				base.h(a_2);
			}
		}

		// Token: 0x06001967 RID: 6503 RVA: 0x0010ADB0 File Offset: 0x00109DB0
		private void a(PageWriter A_0, x5 A_1, x5 A_2)
		{
			if (A_0.Dimensions.GetPdfY(x5.b(A_2)) * 100f < 100000000f)
			{
				A_1 = x5.f(A_1, base.cc());
				A_1 = x5.f(A_1, base.an());
				if (!this.c3())
				{
					A_1 = x5.f(A_1, this.dc());
				}
				float a_ = x5.b(base.be());
				float characterSpacing = x5.b(base.bd());
				this.h = x5.b(this.l());
				for (int i = 0; i < this.aa.b().Length; i++)
				{
					agd agd = this.aa.b()[i];
					if (agd != null)
					{
						l2 l = this.aa.c()[i];
						int a_2 = this.aa.e()[i];
						int num = this.aa.f()[i];
						A_0.SetTextMode();
						if (A_0.DocumentWriter.ah().ContainsKey(l.d()))
						{
							l = A_0.DocumentWriter.ah()[l.d()];
						}
						else
						{
							A_0.DocumentWriter.ah().Add(l.d(), l);
						}
						A_0.Write_Tf(l.e(), this.h);
						A_0.Write_Tm(x5.b(A_1), x5.b(A_2));
						A_0.SetCharacterSpacing(characterSpacing);
						A_0.SetFillColor(this.i.j());
						if (num > 0)
						{
							A_0.a(agd, a_2, num, false, a_);
							if (this.i.m().Length >= 1)
							{
								this.a(A_0, x5.b(A_1), x5.b(A_2));
							}
						}
						A_1 = x5.f(A_1, x5.a(this.aa.d()[i]));
					}
				}
			}
			base.au(x5.c());
		}

		// Token: 0x06001968 RID: 6504 RVA: 0x0010AFE0 File Offset: 0x00109FE0
		internal kz a(x5 A_0, x5 A_1)
		{
			if (!this.j)
			{
				base.an(false);
				if ((this.dr().c5().v() != null && x5.c(this.dr().c5().v().Value, A_1)) || (this.dr().c5().v() == null && x5.c(base.ar(), A_1)))
				{
					this.am(false);
					return this;
				}
				if (base.c5().am() == null && this.dr().c5().am() != null)
				{
					base.l(this.dr().c5().am().Value);
					if (x5.c(this.dr().c5().am().Value, A_0) && x5.c(base.ar(), A_1))
					{
						this.am(false);
						return this;
					}
					base.i(n4.a(this.a, this.d, base.ba()));
				}
				else
				{
					base.l(base.c5().am().Value);
					if (x5.c(base.c5().am().Value, A_0) && x5.c(base.ar(), A_1))
					{
						this.am(false);
						return this;
					}
					base.i(n4.a(this.a, this.d, base.ba()));
				}
			}
			else
			{
				base.l(this.dr().c5().am().Value);
			}
			return null;
		}

		// Token: 0x06001969 RID: 6505 RVA: 0x0010B1E8 File Offset: 0x0010A1E8
		internal override kz dm()
		{
			n3 n = new n3(this.a, this.d, base.ba(), this.l);
			n.j(this.dr());
			n.a(this.l);
			n.dc(this.i.du());
			return n;
		}

		// Token: 0x0600196A RID: 6506 RVA: 0x0010B248 File Offset: 0x0010A248
		internal bool g(int A_0)
		{
			if (A_0 <= 423471123)
			{
				if (A_0 != 23684646 && A_0 != 86147604 && A_0 != 423471123)
				{
					goto IL_55;
				}
			}
			else if (A_0 <= 445520207)
			{
				if (A_0 != 426354867 && A_0 != 445520207)
				{
					goto IL_55;
				}
			}
			else if (A_0 != 506042859 && A_0 != 673419368)
			{
				goto IL_55;
			}
			return true;
			IL_55:
			return false;
		}

		// Token: 0x04000B7A RID: 2938
		private char[] a;

		// Token: 0x04000B7B RID: 2939
		private int b;

		// Token: 0x04000B7C RID: 2940
		private int c;

		// Token: 0x04000B7D RID: 2941
		private int d;

		// Token: 0x04000B7E RID: 2942
		private bool e = false;

		// Token: 0x04000B7F RID: 2943
		private float f;

		// Token: 0x04000B80 RID: 2944
		private float g;

		// Token: 0x04000B81 RID: 2945
		private float h;

		// Token: 0x04000B82 RID: 2946
		private n5 i = new n5();

		// Token: 0x04000B83 RID: 2947
		private bool j = false;

		// Token: 0x04000B84 RID: 2948
		private l2 k = l2.c();

		// Token: 0x04000B85 RID: 2949
		private ij l = null;

		// Token: 0x04000B86 RID: 2950
		private x5 m = x5.c();

		// Token: 0x04000B87 RID: 2951
		private bool n = false;

		// Token: 0x04000B88 RID: 2952
		private bool o = false;

		// Token: 0x04000B89 RID: 2953
		private bool p = false;

		// Token: 0x04000B8A RID: 2954
		private agd[] q = new agd[2];

		// Token: 0x04000B8B RID: 2955
		private new Font[] r = new Font[2];

		// Token: 0x04000B8C RID: 2956
		private int s = 0;

		// Token: 0x04000B8D RID: 2957
		private int t = 0;

		// Token: 0x04000B8E RID: 2958
		private bool u = true;

		// Token: 0x04000B8F RID: 2959
		private bool v = false;

		// Token: 0x04000B90 RID: 2960
		private bool w = false;

		// Token: 0x04000B91 RID: 2961
		private bool x = false;

		// Token: 0x04000B92 RID: 2962
		private int y = 0;

		// Token: 0x04000B93 RID: 2963
		private List<m9> z = null;

		// Token: 0x04000B94 RID: 2964
		private afr aa = null;
	}
}
