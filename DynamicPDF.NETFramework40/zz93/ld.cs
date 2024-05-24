using System;
using System.Collections.Generic;

namespace zz93
{
	// Token: 0x020001B9 RID: 441
	internal class ld
	{
		// Token: 0x06001121 RID: 4385 RVA: 0x000C3BF0 File Offset: 0x000C2BF0
		internal bool a()
		{
			return this.h;
		}

		// Token: 0x06001122 RID: 4386 RVA: 0x000C3C08 File Offset: 0x000C2C08
		internal void a(bool A_0)
		{
			this.h = A_0;
		}

		// Token: 0x06001123 RID: 4387 RVA: 0x000C3C14 File Offset: 0x000C2C14
		internal List<li> b()
		{
			return this.a;
		}

		// Token: 0x06001124 RID: 4388 RVA: 0x000C3C2C File Offset: 0x000C2C2C
		internal List<li> c()
		{
			return this.c;
		}

		// Token: 0x06001125 RID: 4389 RVA: 0x000C3C44 File Offset: 0x000C2C44
		private x5 a(kz A_0, x5 A_1, bool A_2)
		{
			x5 a_ = x5.c();
			x5 result;
			if (x5.d(A_1, x5.f(A_0.ao(), A_0.ar())))
			{
				a_ = A_0.ar();
				if (A_2)
				{
					a_ = x5.f(a_, A_0.ao());
				}
				result = x5.f(a_, x5.a(0.0001));
			}
			else
			{
				result = x5.c();
			}
			return result;
		}

		// Token: 0x06001126 RID: 4390 RVA: 0x000C3CB4 File Offset: 0x000C2CB4
		private void a(List<li> A_0)
		{
			int num = A_0.Count - 1;
			if (A_0.Count > 1)
			{
				while (x5.c(x5.f(A_0[num - 1].a().ao(), A_0[num - 1].a().ar()), x5.f(A_0[num].a().ao(), A_0[num].a().ar())))
				{
					li value = A_0[num];
					A_0[num] = A_0[num - 1];
					A_0[num - 1] = value;
					num--;
					if (num == 0)
					{
						break;
					}
				}
			}
		}

		// Token: 0x06001127 RID: 4391 RVA: 0x000C3D84 File Offset: 0x000C2D84
		internal void a(kz A_0)
		{
			if (A_0.ct())
			{
				this.i = this.a.Count;
				this.d.Add(this.i);
				this.a.Add(new li(A_0));
			}
			else if (A_0.cu())
			{
				if (this.d.Count > 0)
				{
					int index = this.d[0];
					this.d.RemoveAt(0);
					this.a.RemoveAt(index);
					this.a.Insert(index, new li(A_0));
				}
				else
				{
					this.a.Add(new li(A_0));
				}
			}
			else
			{
				this.a.Add(new li(A_0));
			}
			switch (A_0.c5().n())
			{
			case g3.a:
				this.b.Add(new li(A_0));
				this.a(this.b);
				break;
			case g3.b:
				this.c.Add(new li(A_0));
				this.a(this.c);
				break;
			}
		}

		// Token: 0x06001128 RID: 4392 RVA: 0x000C3EC8 File Offset: 0x000C2EC8
		internal x5 a(x5 A_0, ref x5 A_1, x5 A_2)
		{
			x5 x = x5.c();
			x5 a_ = x5.c();
			x5 x2 = A_2;
			for (int i = this.e; i < this.b.Count; i++)
			{
				if (x5.b(this.b[i].a().ao(), A_0) && x5.a(x5.f(this.b[i].a().ao(), this.b[i].a().ar()), A_0))
				{
					if (x5.d(x, x5.f(this.b[i].a().an(), this.b[i].a().aq())))
					{
						x = x5.f(this.b[i].a().an(), this.b[i].a().aq());
					}
				}
				if (x5.b(x5.f(this.b[i].a().ao(), this.b[i].a().ar()), A_0))
				{
					this.e++;
				}
			}
			for (int i = this.f; i < this.c.Count; i++)
			{
				if (x5.b(this.c[i].a().ao(), A_0) && x5.a(x5.f(this.c[i].a().ao(), this.c[i].a().ar()), A_0))
				{
					if (x5.c(x2, this.c[i].a().an()))
					{
						x2 = this.c[i].a().an();
					}
				}
				if (x5.b(x5.f(this.c[i].a().ao(), this.c[i].a().ar()), A_0))
				{
					this.f++;
				}
			}
			if (x5.g(x2, A_2))
			{
				a_ = x5.e(A_2, x2);
			}
			A_1 = x5.e(x5.e(A_2, x), a_);
			return x;
		}

		// Token: 0x06001129 RID: 4393 RVA: 0x000C41C0 File Offset: 0x000C31C0
		internal x5 a(x5 A_0)
		{
			x5 x = x5.c();
			for (int i = 0; i < this.b.Count; i++)
			{
				kz kz = this.b[i].a();
				if (x5.b(kz.ao(), A_0) && x5.c(x5.f(kz.ao(), kz.ar()), A_0))
				{
					if (x5.d(x, x5.f(kz.an(), kz.aq())))
					{
						x = x5.f(kz.an(), kz.aq());
						if (kz.by() >= 1)
						{
							x = x5.e(x, kz.ax());
						}
					}
				}
			}
			return x;
		}

		// Token: 0x0600112A RID: 4394 RVA: 0x000C429C File Offset: 0x000C329C
		internal x5 a(x5 A_0, kz A_1)
		{
			x5 x = A_1.bi();
			x5 x2 = x;
			x5 result = x5.c();
			x5 x3 = A_0;
			for (int i = 0; i < this.c.Count; i++)
			{
				kz kz = this.c[i].a();
				x5 a_ = x5.a(Math.Truncate((double)(x5.b(kz.ao()) * 1000f)) / 1000.0);
				A_0 = x5.a(Math.Truncate((double)(x5.b(A_0) * 1000f)) / 1000.0);
				if (x5.b(a_, A_0) && x5.c(x5.f(kz.ao(), kz.ar()), A_0))
				{
					if (x5.c(x2, kz.an()))
					{
						x2 = kz.an();
					}
				}
				A_0 = x3;
			}
			if (x5.g(x2, x))
			{
				result = x5.e(x5.e(x, x2), x5.a(0.0001));
			}
			return result;
		}

		// Token: 0x0600112B RID: 4395 RVA: 0x000C43D0 File Offset: 0x000C33D0
		internal x5 a(x5 A_0, x5 A_1)
		{
			x5 x = A_1;
			x5 result = x5.c();
			for (int i = this.f; i < this.c.Count; i++)
			{
				kz kz = this.c[i].a();
				x5 a_ = x5.a(Math.Truncate((double)(x5.b(kz.ao()) * 1000f)) / 1000.0);
				if (x5.b(a_, A_0) && x5.a(x5.f(kz.ao(), kz.ar()), A_0))
				{
					if (x5.c(x, kz.an()))
					{
						x = kz.an();
					}
				}
			}
			if (x5.g(x, A_1))
			{
				result = x5.e(x5.e(A_1, x), x5.a(0.0001));
			}
			return result;
		}

		// Token: 0x0600112C RID: 4396 RVA: 0x000C44D8 File Offset: 0x000C34D8
		internal x5 b(x5 A_0, x5 A_1)
		{
			x5 x = x5.c();
			for (int i = this.f; i < this.c.Count; i++)
			{
				kz kz = this.c[i].a();
				x5 a_ = x5.a(Math.Truncate((double)(x5.b(kz.ao()) * 1000f)) / 1000.0);
				if (x5.b(a_, A_0) && x5.a(x5.f(kz.ao(), kz.ar()), A_0))
				{
					if (x5.c(kz.an(), x) && x5.b(kz.an(), A_1))
					{
						x = kz.an();
					}
				}
			}
			return x;
		}

		// Token: 0x0600112D RID: 4397 RVA: 0x000C45BC File Offset: 0x000C35BC
		internal x5 b(x5 A_0)
		{
			x5 x = x5.c();
			for (int i = 0; i < this.b.Count; i++)
			{
				kz kz = this.b[i].a();
				if (x5.b(kz.ao(), x5.f(A_0, x5.a(0.001))) && x5.c(x5.f(kz.ao(), kz.ar()), A_0))
				{
					if (x5.d(x, x5.f(kz.an(), kz.aq())))
					{
						x = x5.f(kz.an(), kz.aq());
					}
				}
			}
			return x;
		}

		// Token: 0x0600112E RID: 4398 RVA: 0x000C468C File Offset: 0x000C368C
		internal x5 b(x5 A_0, ref x5 A_1, x5 A_2)
		{
			x5 x = x5.c();
			x5 a_ = x5.c();
			x5 x2 = A_2;
			for (int i = this.e; i < this.b.Count; i++)
			{
				kz kz = this.b[i].a();
				if (x5.b(kz.ao(), A_0) && x5.a(x5.f(kz.ao(), kz.ar()), A_0))
				{
					if (x5.d(x, x5.f(kz.an(), kz.aq())))
					{
						x = x5.f(kz.an(), kz.aq());
					}
				}
			}
			for (int i = this.f; i < this.c.Count; i++)
			{
				kz kz = this.c[i].a();
				if (x5.b(kz.ao(), A_0) && x5.a(x5.f(kz.ao(), kz.ar()), A_0))
				{
					if (x5.c(x2, kz.an()))
					{
						x2 = kz.an();
					}
				}
			}
			if (x5.g(x2, A_2))
			{
				a_ = x5.e(A_2, x2);
			}
			A_1 = x5.e(x5.e(A_2, x), a_);
			return x;
		}

		// Token: 0x0600112F RID: 4399 RVA: 0x000C4818 File Offset: 0x000C3818
		internal x5? a(x5 A_0, x5 A_1, x5 A_2)
		{
			x5 x = x5.c();
			for (int i = this.e; i < this.b.Count; i++)
			{
				x5 a_ = this.b[i].a().ao();
				if (x5.c(a_, A_0) && x5.d(a_, x5.f(A_0, A_1)) && x5.b(this.b[i].a().an(), A_2) && x5.c(x5.f(this.b[i].a().aq(), this.b[i].a().an()), A_2))
				{
					if (x5.d(x, x5.f(this.b[i].a().ao(), this.b[i].a().ar())))
					{
						x = x5.f(this.b[i].a().ao(), this.b[i].a().ar());
					}
				}
			}
			for (int i = this.f; i < this.c.Count; i++)
			{
				x5 a_ = this.c[i].a().ao();
				if (x5.c(a_, A_0) && x5.b(a_, x5.f(A_0, A_1)) && x5.b(this.c[i].a().an(), A_2) && x5.c(x5.f(this.c[i].a().aq(), this.c[i].a().an()), A_2))
				{
					if (x5.d(x, x5.f(this.c[i].a().ao(), this.c[i].a().ar())))
					{
						x = x5.f(this.c[i].a().ao(), this.c[i].a().ar());
					}
				}
			}
			x5? result;
			if (x5.g(x, x5.c()))
			{
				result = new x5?(x);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06001130 RID: 4400 RVA: 0x000C4B04 File Offset: 0x000C3B04
		internal x5 a(x5 A_0, ref x5 A_1, x5 A_2, kz A_3)
		{
			x5 x = x5.c();
			x5 a_ = x5.c();
			x5 x2 = A_2;
			for (int i = this.e; i < this.b.Count; i++)
			{
				kz kz = this.b[i].a();
				if (x5.a(kz.ao(), A_0))
				{
					if (x5.d(x, x5.f(kz.an(), kz.aq())))
					{
						x = x5.f(kz.an(), kz.aq());
					}
				}
				if (!A_3.c3())
				{
					if (x5.b(x5.f(kz.ao(), kz.ar()), A_0))
					{
						this.e++;
					}
				}
			}
			for (int i = this.f; i < this.c.Count; i++)
			{
				kz kz = this.c[i].a();
				if (x5.a(kz.ao(), A_0) && x5.c(x2, kz.an()))
				{
					x2 = kz.an();
				}
				if (!A_3.c3())
				{
					if (x5.b(x5.f(kz.ao(), kz.ar()), A_0))
					{
						this.f++;
					}
				}
			}
			if (x5.g(x2, A_2))
			{
				a_ = x5.e(A_2, x2);
			}
			A_1 = x5.e(x5.e(A_2, x), a_);
			return x;
		}

		// Token: 0x06001131 RID: 4401 RVA: 0x000C4CD0 File Offset: 0x000C3CD0
		internal x5 a(x5 A_0, x5 A_1, ref bool A_2)
		{
			x5 x = x5.b();
			x5 x2 = x5.c();
			x5 x3 = x5.c();
			for (int i = this.b.Count - 1; i >= 0; i--)
			{
				kz kz = this.b[i].a();
				if (x5.b(kz.ao(), A_0) && x5.a(x5.f(kz.ao(), kz.ar()), A_0))
				{
					if (x5.b(A_1, x5.f(kz.an(), kz.aq())))
					{
						x = x5.f(kz.ao(), kz.ar());
						if (x5.c(x, x2) && x5.c(x, A_0))
						{
							x2 = x;
							A_2 = true;
							break;
						}
					}
				}
			}
			for (int i = this.c.Count - 1; i >= 0; i--)
			{
				kz kz = this.c[i].a();
				if (x5.b(kz.ao(), A_0) && x5.a(x5.f(kz.ao(), kz.ar()), A_0))
				{
					if (x5.b(A_1, x5.f(kz.an(), kz.aq())))
					{
						x = x5.f(kz.ao(), kz.ar());
						if (x5.c(x, x3) && x5.c(x, A_0))
						{
							x3 = x;
							A_2 = true;
							break;
						}
					}
				}
			}
			x = (x5.c(x2, x3) ? x2 : x3);
			x5 result;
			if (x5.h(x, x5.b()) || x5.h(x, x5.c()))
			{
				result = x5.f(A_0, x5.a(0.0001));
			}
			else
			{
				result = x5.f(x, x5.a(0.0001));
			}
			return result;
		}

		// Token: 0x06001132 RID: 4402 RVA: 0x000C4EFC File Offset: 0x000C3EFC
		internal x5 c(x5 A_0)
		{
			x5 x = x5.c();
			for (int i = this.e; i < this.b.Count; i++)
			{
				kz kz = this.b[i].a();
				if (x5.c(kz.ao(), A_0))
				{
					if (x5.d(x, kz.ao()))
					{
						x = kz.ao();
					}
				}
			}
			for (int i = this.f; i < this.c.Count; i++)
			{
				kz kz = this.c[i].a();
				if (x5.c(kz.ao(), A_0))
				{
					if (x5.d(x, kz.ao()))
					{
						x = kz.ao();
					}
				}
			}
			if (x5.d(A_0, x))
			{
				A_0 = x;
			}
			return A_0;
		}

		// Token: 0x06001133 RID: 4403 RVA: 0x000C5008 File Offset: 0x000C4008
		internal x5 d(x5 A_0)
		{
			x5 a_ = x5.b();
			x5 x = x5.b();
			for (int i = 0; i < this.b.Count; i++)
			{
				kz kz = this.b[i].a();
				if (x5.c(a_, x5.f(kz.ao(), kz.ar())) && x5.b(A_0, x5.f(kz.ao(), kz.ar())))
				{
					a_ = x5.f(kz.ao(), kz.ar());
				}
			}
			for (int i = 0; i < this.c.Count; i++)
			{
				kz kz = this.c[i].a();
				if (x5.c(x, x5.f(kz.ao(), kz.ar())) && x5.b(A_0, x5.f(kz.ao(), kz.ar())))
				{
					x = x5.f(kz.ao(), kz.ar());
				}
			}
			if (x5.g(x, x5.b()))
			{
				if (x5.g(a_, x5.b()) && x5.d(a_, x))
				{
					A_0 = x5.f(a_, x5.a(0.001));
				}
				else
				{
					A_0 = x5.f(x, x5.a(0.001));
				}
			}
			else if (x5.g(a_, x5.b()))
			{
				A_0 = x5.f(a_, x5.a(0.001));
			}
			return A_0;
		}

		// Token: 0x06001134 RID: 4404 RVA: 0x000C51CC File Offset: 0x000C41CC
		internal x5 a(bool A_0, bool A_1)
		{
			if (A_0 && A_1)
			{
				int count = this.b.Count;
				int count2 = this.c.Count;
				if (count >= 1 && count2 >= 1)
				{
					x5 x = x5.f(x5.f(this.b[count - 1].a().ao(), this.b[count - 1].a().ar()), x5.a(0.0001));
					x5 x2 = x5.f(x5.f(this.c[count2 - 1].a().ao(), this.c[count2 - 1].a().ar()), x5.a(0.0001));
					return x5.c(x, x2) ? x : x2;
				}
				if (count >= 1 && count2 == 0)
				{
					x5 x = x5.f(this.b[count - 1].a().ao(), this.b[count - 1].a().ar());
					return x5.f(x, x5.a(0.0001));
				}
				if (count2 >= 1 && count == 0)
				{
					x5 x2 = x5.f(this.c[count2 - 1].a().ao(), this.c[count2 - 1].a().ar());
					return x5.f(x2, x5.a(0.0001));
				}
			}
			else
			{
				if (A_0)
				{
					int count = this.b.Count;
					if (count != 0)
					{
						if (count > 1)
						{
							return x5.f(x5.f(this.b[count - 1].a().ao(), this.b[count - 1].a().ar()), x5.a(0.0001));
						}
						return x5.f(x5.f(this.b[0].a().ao(), this.b[0].a().ar()), x5.a(0.0001));
					}
				}
				if (A_1)
				{
					int count2 = this.c.Count;
					if (count2 != 0)
					{
						if (count2 > 1)
						{
							return x5.f(x5.f(this.c[count2 - 1].a().ao(), this.c[count2 - 1].a().ar()), x5.a(0.0001));
						}
						return x5.f(x5.f(this.c[0].a().ao(), this.c[0].a().ar()), x5.a(0.0001));
					}
				}
			}
			return x5.c();
		}

		// Token: 0x06001135 RID: 4405 RVA: 0x000C5580 File Offset: 0x000C4580
		internal x5 a(bool A_0, bool A_1, kz A_2, x5 A_3, bool A_4, bool A_5)
		{
			x5 x = A_2.c5().e().m();
			int count = this.b.Count;
			int count2 = this.c.Count;
			x5 x2 = x5.c();
			x5 x3 = x5.c();
			x5 x4 = x5.c();
			if (A_0 && A_1)
			{
				if (count >= 1 && count2 >= 1)
				{
					for (int i = this.b.Count - 1; i >= 0; i--)
					{
						kz kz = this.b[i].a();
						if (x5.b(kz.ao(), A_3) && x5.a(x5.f(kz.ao(), kz.ar()), A_3))
						{
							x2 = this.a(kz, A_3, A_5);
							if (x5.c(x2, x4))
							{
								x4 = x2;
							}
						}
					}
					x2 = x4;
					x4 = x5.c();
					for (int i = this.c.Count - 1; i >= 0; i--)
					{
						kz kz = this.c[i].a();
						if (x5.b(kz.ao(), A_3) && x5.a(x5.f(kz.ao(), kz.ar()), A_3))
						{
							x3 = this.a(kz, A_3, A_5);
							if (x5.c(x3, x4))
							{
								x4 = x3;
							}
						}
					}
					x3 = x4;
					x4 = x5.c();
					A_3 = (x5.c(x2, x3) ? x2 : x3);
				}
				else if (count >= 1 && count2 == 0)
				{
					for (int i = this.b.Count - 1; i >= 0; i--)
					{
						kz kz = this.b[i].a();
						if (x5.b(kz.ao(), A_3) && x5.a(x5.f(kz.ao(), kz.ar()), A_3))
						{
							x2 = this.a(kz, A_3, A_5);
							if (x5.c(x2, x4))
							{
								x4 = x2;
							}
						}
					}
					x2 = x4;
					x4 = x5.c();
				}
				else if (count2 >= 1 && count == 0)
				{
					for (int i = this.c.Count - 1; i >= 0; i--)
					{
						kz kz = this.c[i].a();
						if (x5.b(kz.ao(), A_3) && x5.a(x5.f(kz.ao(), kz.ar()), A_3))
						{
							x3 = this.a(kz, A_3, A_5);
							if (x5.c(x3, x4))
							{
								x4 = x3;
							}
						}
					}
					x3 = x4;
					x4 = x5.c();
				}
			}
			else
			{
				if (A_0)
				{
					if (count >= 1)
					{
						for (int i = this.b.Count - 1; i >= 0; i--)
						{
							kz kz = this.b[i].a();
							if (x5.b(kz.ao(), A_3) && x5.a(x5.f(kz.ao(), kz.ar()), A_3))
							{
								x2 = this.a(kz, A_3, A_5);
								if (x5.c(x2, x4))
								{
									x4 = x2;
								}
							}
						}
						x2 = x4;
						x4 = x5.c();
					}
					else
					{
						A_3 = x5.c();
					}
				}
				if (A_1)
				{
					for (int i = this.c.Count - 1; i >= 0; i--)
					{
						kz kz = this.c[i].a();
						if (x5.b(kz.ao(), A_3) && x5.a(x5.f(kz.ao(), kz.ar()), A_3))
						{
							x3 = this.a(kz, A_3, A_5);
							if (x5.c(x3, x4))
							{
								x4 = x3;
							}
						}
					}
					x3 = x4;
					x4 = x5.c();
				}
			}
			return A_3 = (x5.c(x2, x3) ? x2 : x3);
		}

		// Token: 0x06001136 RID: 4406 RVA: 0x000C5A90 File Offset: 0x000C4A90
		internal x5 d()
		{
			x5 x = x5.c();
			for (int i = this.e; i < this.b.Count; i++)
			{
				kz kz = this.b[i].a();
				if (x5.c(x5.f(kz.ao(), kz.ar()), x))
				{
					x = x5.f(kz.ao(), kz.ar());
				}
			}
			for (int i = this.f; i < this.c.Count; i++)
			{
				kz kz = this.c[i].a();
				if (x5.c(x5.f(kz.ao(), kz.ar()), x))
				{
					x = x5.f(kz.ao(), kz.ar());
				}
			}
			return x;
		}

		// Token: 0x06001137 RID: 4407 RVA: 0x000C5B88 File Offset: 0x000C4B88
		internal x5 e()
		{
			x5 x = x5.c();
			for (int i = this.e; i < this.b.Count; i++)
			{
				kz kz = this.b[i].a();
				if (x5.c(x5.f(kz.an(), kz.aq()), x))
				{
					x = x5.f(kz.an(), kz.aq());
				}
			}
			for (int i = this.f; i < this.c.Count; i++)
			{
				kz kz = this.c[i].a();
				if (x5.c(x5.f(kz.an(), kz.aq()), x))
				{
					x = x5.f(kz.an(), kz.aq());
				}
			}
			return x;
		}

		// Token: 0x06001138 RID: 4408 RVA: 0x000C5C80 File Offset: 0x000C4C80
		internal ld f()
		{
			ld ld = new ld();
			ld.d = this.d;
			using (List<int>.Enumerator enumerator = this.d.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int i = enumerator.Current;
					ld.a.Add(this.a[i]);
				}
			}
			for (int i = 0; i < ld.d.Count; i++)
			{
				ld.d[i] = i;
			}
			return ld;
		}

		// Token: 0x04000831 RID: 2097
		private List<li> a = new List<li>();

		// Token: 0x04000832 RID: 2098
		private List<li> b = new List<li>();

		// Token: 0x04000833 RID: 2099
		private List<li> c = new List<li>();

		// Token: 0x04000834 RID: 2100
		private List<int> d = new List<int>();

		// Token: 0x04000835 RID: 2101
		private int e = 0;

		// Token: 0x04000836 RID: 2102
		private int f = 0;

		// Token: 0x04000837 RID: 2103
		private x5 g = x5.c();

		// Token: 0x04000838 RID: 2104
		private bool h = false;

		// Token: 0x04000839 RID: 2105
		private int i = 0;
	}
}
