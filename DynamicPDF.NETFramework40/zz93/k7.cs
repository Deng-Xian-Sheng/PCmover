using System;

namespace zz93
{
	// Token: 0x020001B3 RID: 435
	internal class k7 : k6
	{
		// Token: 0x060010AB RID: 4267 RVA: 0x000BFDBC File Offset: 0x000BEDBC
		internal k7(kz[][] A_0, bool A_1)
		{
			this.g = A_0;
			this.i = A_1;
		}

		// Token: 0x060010AC RID: 4268 RVA: 0x000BFE24 File Offset: 0x000BEE24
		private void a(x5 A_0, int A_1)
		{
			x5 x = x5.c();
			for (int i = 0; i < this.c.Length; i++)
			{
				x = x5.f(x, this.c[i]);
			}
			if (x5.d(x, A_0))
			{
				if (A_1 == base.g() || this.f == base.g())
				{
					this.b(x, A_0);
				}
				else if (A_1 == base.g() - 1 && this.f == 0)
				{
					for (int i = 0; i < this.c.Length; i++)
					{
						if (x5.h(this.d[i], x5.c()) && x5.h(this.e[i], x5.c()))
						{
							x5[] array = this.c;
							int num = i;
							array[num] = x5.f(array[num], x5.e(A_0, x));
						}
					}
				}
				else
				{
					this.a(x, A_0);
				}
			}
		}

		// Token: 0x060010AD RID: 4269 RVA: 0x000BFF60 File Offset: 0x000BEF60
		private void b(x5 A_0, x5 A_1)
		{
			x5 a_ = x5.e(A_1, A_0);
			for (int i = 0; i < this.c.Length; i++)
			{
				float num;
				if (this.e != null && x5.g(this.e[i], x5.c()))
				{
					num = x5.b(this.e[i]) * (100f / x5.b(A_0));
				}
				else
				{
					num = x5.b(this.c[i]) * (100f / x5.b(A_0));
				}
				x5[] array = this.c;
				int num2 = i;
				array[num2] = x5.f(array[num2], x5.a(x5.b(a_) * (num / 100f)));
			}
		}

		// Token: 0x060010AE RID: 4270 RVA: 0x000C0048 File Offset: 0x000BF048
		private void a(x5 A_0, x5 A_1)
		{
			for (int i = 0; i < this.c.Length; i++)
			{
				if (x5.g(this.d[i], x5.c()))
				{
					this.c[i] = this.d[i];
				}
			}
			x5 a_ = x5.c();
			for (int i = 0; i < this.c.Length; i++)
			{
				if (x5.h(this.d[i], x5.c()) && x5.h(this.e[i], x5.c()))
				{
					a_ = x5.f(a_, this.c[i]);
				}
			}
			x5 a_2 = x5.e(A_1, A_0);
			if (x5.g(a_, x5.c()))
			{
				for (int i = 0; i < this.c.Length; i++)
				{
					if (x5.h(this.d[i], x5.c()) && x5.h(this.e[i], x5.c()))
					{
						float num = x5.b(this.c[i]) * (100f / x5.b(a_));
						x5[] array = this.c;
						int num2 = i;
						array[num2] = x5.f(array[num2], x5.a(x5.b(a_2) * (num / 100f)));
					}
				}
			}
		}

		// Token: 0x060010AF RID: 4271 RVA: 0x000C0218 File Offset: 0x000BF218
		private int d(x5 A_0)
		{
			this.b(A_0);
			if (this.i)
			{
				this.a();
			}
			x5[] a_ = this.c();
			x5[] a_2 = this.b();
			this.c = new x5[base.g()];
			int num = this.d();
			int num2 = num;
			if (num2 != 0)
			{
				this.a(A_0, a_);
			}
			else
			{
				this.a(A_0, a_, a_2);
			}
			return num;
		}

		// Token: 0x060010B0 RID: 4272 RVA: 0x000C0294 File Offset: 0x000BF294
		private void a(x5 A_0, x5[] A_1, x5[] A_2)
		{
			x5 x = this.a(A_1);
			x5 a_ = this.a(A_2);
			this.h = a_;
			if (x5.a(x, A_0))
			{
				for (int i = 0; i < this.c.Length; i++)
				{
					this.c[i] = this.a[i];
				}
			}
			else if (x5.b(a_, A_0))
			{
				for (int i = 0; i < this.c.Length; i++)
				{
					this.c[i] = x5.f(this.b[i], x5.a(0.0001));
				}
			}
			else if (x5.c(a_, A_0) && x5.d(x, A_0))
			{
				float num = x5.b(x5.e(A_0, x));
				float num2 = x5.b(x5.e(a_, x));
				for (int i = 0; i < this.a.Length; i++)
				{
					float num3 = x5.b(x5.e(this.b[i], this.a[i]));
					this.c[i] = x5.f(x5.a(x5.b(this.a[i]) + num3 * (num / num2)), x5.a(0.0001));
				}
			}
		}

		// Token: 0x060010B1 RID: 4273 RVA: 0x000C044C File Offset: 0x000BF44C
		private void a(x5 A_0, x5[] A_1)
		{
			x5 a_ = this.a(A_1);
			x5[] array = this.e();
			this.h = this.b(array);
			x5[] array2 = this.f();
			x5 x = this.c(array2);
			if (x5.a(a_, A_0))
			{
				for (int i = 0; i < this.c.Length; i++)
				{
					this.c[i] = this.a[i];
				}
			}
			else if (x5.b(this.h, A_0))
			{
				for (int i = 0; i < this.c.Length; i++)
				{
					if (x5.g(array[i], x5.c()))
					{
						this.c[i] = array[i];
					}
					else
					{
						this.c[i] = this.b[i];
					}
				}
			}
			else if (x5.c(this.h, A_0) && x5.b(x, A_0))
			{
				float num = x5.b(x5.e(A_0, x));
				float num2 = x5.b(x5.e(this.h, x));
				for (int i = 0; i < this.a.Length; i++)
				{
					float num3 = x5.b(x5.e(array[i], array2[i]));
					this.c[i] = x5.a(x5.b(array2[i]) + num3 * (num / num2));
				}
			}
			else if (x5.a(this.h, x) && x5.c(x, A_0))
			{
				this.c(A_0);
			}
		}

		// Token: 0x060010B2 RID: 4274 RVA: 0x000C0674 File Offset: 0x000BF674
		private void c(x5 A_0)
		{
			x5[] array = new x5[this.c.Length];
			x5 a_ = x5.c();
			int num = 0;
			for (int i = 0; i < base.g(); i++)
			{
				x5 x = this.a(i);
				if (x5.c(x, array[i]))
				{
					array[i] = x;
				}
			}
			if (this.e != null)
			{
				for (int i = 0; i < base.g(); i++)
				{
					if (x5.d(array[i], this.e[i]))
					{
						array[i] = this.e[i];
					}
				}
			}
			for (int j = 0; j < array.Length; j++)
			{
				if (x5.a(array[j], base.h()[j]) && x5.g(base.h()[j], x5.c()))
				{
					this.c[j] = array[j];
					num++;
				}
				else
				{
					a_ = x5.f(a_, base.h()[j]);
				}
				A_0 = x5.e(A_0, array[j]);
			}
			if (num < this.c.Length)
			{
				for (int j = 0; j < this.c.Length; j++)
				{
					if (x5.h(this.c[j], x5.c()))
					{
						float num2 = x5.b(base.h()[j]) * (100f / x5.b(a_));
						this.c[j] = x5.f(array[j], x5.a(x5.b(A_0) * (num2 / 100f)));
					}
				}
			}
		}

		// Token: 0x060010B3 RID: 4275 RVA: 0x000C08E8 File Offset: 0x000BF8E8
		private x5 c(x5[] A_0)
		{
			x5 x = x5.c();
			for (int i = 0; i < A_0.Length; i++)
			{
				x = x5.f(x, A_0[i]);
			}
			return x;
		}

		// Token: 0x060010B4 RID: 4276 RVA: 0x000C0928 File Offset: 0x000BF928
		private x5[] f()
		{
			x5[] array = new x5[base.g()];
			for (int i = 0; i < this.a.Length; i++)
			{
				if (this.e != null && x5.g(this.e[i], x5.c()))
				{
					array[i] = this.e[i];
				}
				else if (x5.g(this.d[i], x5.c()) && x5.c(this.d[i], this.a[i]))
				{
					array[i] = this.d[i];
				}
				else
				{
					array[i] = this.a[i];
				}
			}
			return array;
		}

		// Token: 0x060010B5 RID: 4277 RVA: 0x000C0A44 File Offset: 0x000BFA44
		private x5 b(x5[] A_0)
		{
			x5 x = x5.c();
			for (int i = 0; i < A_0.Length; i++)
			{
				x = x5.f(x, A_0[i]);
			}
			return x;
		}

		// Token: 0x060010B6 RID: 4278 RVA: 0x000C0A84 File Offset: 0x000BFA84
		private x5[] e()
		{
			x5[] array = new x5[base.g()];
			for (int i = 0; i < this.b.Length; i++)
			{
				if (this.e != null && x5.g(this.e[i], x5.c()))
				{
					if (x5.c(this.e[i], this.b[i]))
					{
						array[i] = this.e[i];
					}
					else
					{
						array[i] = this.b[i];
					}
				}
				else if (x5.g(this.d[i], x5.c()))
				{
					array[i] = this.d[i];
				}
				else
				{
					array[i] = this.b[i];
				}
			}
			return array;
		}

		// Token: 0x060010B7 RID: 4279 RVA: 0x000C0BBC File Offset: 0x000BFBBC
		private int d()
		{
			int num = 0;
			for (int i = 0; i < this.d.Length; i++)
			{
				if (x5.g(this.d[i], x5.c()) || (this.e != null && x5.g(this.e[i], x5.c())))
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x060010B8 RID: 4280 RVA: 0x000C0C40 File Offset: 0x000BFC40
		private void b(x5 A_0)
		{
			this.a = new x5[base.g()];
			this.b = new x5[base.g()];
			this.d = new x5[base.g()];
			for (int i = 0; i < base.g(); i++)
			{
				this.a[i] = this.a(i);
				this.b[i] = this.c(i);
				this.d[i] = this.b(i);
			}
			if (base.i() != null)
			{
				this.a(A_0);
				for (int j = 0; j < base.g(); j++)
				{
					if (x5.d(this.a[j], this.e[j]))
					{
						this.a[j] = this.e[j];
					}
				}
			}
		}

		// Token: 0x060010B9 RID: 4281 RVA: 0x000C0D60 File Offset: 0x000BFD60
		private x5[] c()
		{
			x5[] array = new x5[this.g.Length];
			for (int i = 0; i < this.g.Length; i++)
			{
				if (this.g[i] != null)
				{
					for (int j = 0; j < this.g[i].Length; j++)
					{
						x5[] array2 = array;
						int num = i;
						array2[num] = x5.f(array2[num], this.a[j]);
					}
				}
			}
			return array;
		}

		// Token: 0x060010BA RID: 4282 RVA: 0x000C0DF4 File Offset: 0x000BFDF4
		private x5[] b()
		{
			x5[] array = new x5[this.g.Length];
			for (int i = 0; i < this.g.Length; i++)
			{
				if (this.g[i] != null)
				{
					for (int j = 0; j < this.g[i].Length; j++)
					{
						x5[] array2 = array;
						int num = i;
						array2[num] = x5.f(array2[num], this.b[j]);
					}
				}
			}
			return array;
		}

		// Token: 0x060010BB RID: 4283 RVA: 0x000C0E88 File Offset: 0x000BFE88
		private x5 a(x5[] A_0)
		{
			x5 x = x5.c();
			for (int i = 0; i < A_0.Length; i++)
			{
				if (x5.d(x, A_0[i]))
				{
					x = A_0[i];
				}
			}
			return x;
		}

		// Token: 0x060010BC RID: 4284 RVA: 0x000C0EDC File Offset: 0x000BFEDC
		private x5 c(int A_0)
		{
			x5 x = x5.c();
			for (int i = 0; i < this.g.Length; i++)
			{
				if (this.g[i] != null)
				{
					if (A_0 < this.g[i].Length && this.g[i][A_0] != null)
					{
						if (((n5)this.g[i][A_0].db()).y() == 1)
						{
							if (x5.c(this.g[i][A_0].dn(), x))
							{
								x = this.g[i][A_0].dn();
							}
						}
					}
				}
			}
			return x;
		}

		// Token: 0x060010BD RID: 4285 RVA: 0x000C0F9C File Offset: 0x000BFF9C
		private x5 b(int A_0)
		{
			x5 x = x5.c();
			for (int i = 0; i < this.g.Length; i++)
			{
				if (this.g[i] != null)
				{
					if (A_0 < this.g[i].Length && this.g[i][A_0] != null)
					{
						if (((n5)this.g[i][A_0].db()).y() == 1)
						{
							if (x5.a(this.g[i][A_0].dp(), x))
							{
								x = this.g[i][A_0].dp();
								if (x5.g(base.h()[A_0], x5.c()))
								{
									if (x5.d(x, base.h()[A_0]))
									{
										x = base.h()[A_0];
									}
								}
								else
								{
									x = x5.c();
								}
							}
						}
					}
				}
			}
			return x;
		}

		// Token: 0x060010BE RID: 4286 RVA: 0x000C10C4 File Offset: 0x000C00C4
		private x5 a(int A_0)
		{
			x5 x = x5.c();
			for (int i = 0; i < this.g.Length; i++)
			{
				if (this.g[i] != null)
				{
					if (A_0 < this.g[i].Length && this.g[i][A_0] != null)
					{
						if (((n5)this.g[i][A_0].db()).y() == 1)
						{
							int num = ((n5)this.g[i][A_0].db()).y();
							if (num == 1 || (num != base.g() && i == 0))
							{
								if (x5.c(this.g[i][A_0].dp(), x))
								{
									x = this.g[i][A_0].dp();
								}
							}
						}
					}
				}
			}
			return x;
		}

		// Token: 0x060010BF RID: 4287 RVA: 0x000C11D4 File Offset: 0x000C01D4
		private void a(x5 A_0)
		{
			this.e = new x5[base.g()];
			x5 x = x5.c();
			for (int i = 0; i < base.g(); i++)
			{
				if (base.i()[i] == null)
				{
					x = x5.f(x, this.a[i]);
				}
			}
			x5 x2 = x5.e(A_0, x);
			x5 a_ = x5.c();
			int num = 0;
			int num2 = -1;
			for (int i = 0; i < base.g(); i++)
			{
				if (base.i()[i] != null)
				{
					this.e[i] = x5.a(x5.b(base.i()[i].c()) * (x5.b(A_0) / 100f));
					a_ = x5.f(a_, this.e[i]);
					num++;
					num2 = i;
				}
			}
			this.f = num;
			if (x5.c(x5.f(a_, x), A_0))
			{
				if (num == 1)
				{
					this.e[num2] = x2;
				}
				else
				{
					num2 = 1;
					for (int i = 0; i < base.g(); i++)
					{
						if (base.i()[i] != null)
						{
							if (num2 == num)
							{
								this.e[i] = x2;
							}
							else
							{
								this.e[i] = x5.a(x5.b(base.i()[i].c()) * (x5.b(x2) / 100f));
							}
							x2 = x5.e(x2, this.e[i]);
							num2++;
						}
					}
				}
			}
		}

		// Token: 0x060010C0 RID: 4288 RVA: 0x000C13D4 File Offset: 0x000C03D4
		private void a()
		{
			for (int i = 0; i < this.g.Length; i++)
			{
				if (this.g[i] != null)
				{
					int j = 0;
					while (j < base.g())
					{
						kz kz = this.g[i][j];
						if (kz != null)
						{
							int num = ((n5)kz.db()).y();
							if (num > 1)
							{
								int num2 = 0;
								int num3 = j;
								while (num3 < j + num && num3 < this.d.Length)
								{
									if (x5.g(this.d[num3], x5.c()))
									{
										num2++;
									}
									num3++;
								}
								this.a(kz, num, j, num2);
								j += num;
							}
							else
							{
								j++;
							}
						}
						else
						{
							j++;
						}
					}
				}
			}
		}

		// Token: 0x060010C1 RID: 4289 RVA: 0x000C14E4 File Offset: 0x000C04E4
		private void a(kz A_0, int A_1, int A_2, int A_3)
		{
			x5 x = A_0.dp();
			x5 x2 = A_0.dn();
			x5 x3 = x5.c();
			x5 x4 = x5.c();
			int a_ = A_1;
			bool a_2 = true;
			if (A_3 != A_1)
			{
				a_ = A_1 - A_3;
				if (A_3 != 0)
				{
					a_2 = false;
				}
			}
			int num = A_2;
			while (num < A_2 + A_1 && num < this.a.Length)
			{
				x3 = x5.f(x3, this.a[num]);
				x4 = x5.f(x4, this.b[num]);
				num++;
			}
			if (x5.d(x3, x))
			{
				x5 a_3 = x5.e(x, x3);
				x5 a_4 = x5.a(a_3, a_);
				this.b(a_2, a_4, A_1, A_2);
			}
			if (x5.d(x4, x2))
			{
				x5 a_3 = x5.e(x2, x4);
				x5 a_4 = x5.a(a_3, a_);
				this.a(a_2, a_4, A_1, A_2);
			}
		}

		// Token: 0x060010C2 RID: 4290 RVA: 0x000C15F8 File Offset: 0x000C05F8
		private void b(bool A_0, x5 A_1, int A_2, int A_3)
		{
			switch (A_0)
			{
			case false:
				for (int i = A_3; i < A_3 + A_2; i++)
				{
					if (x5.h(this.d[i], x5.c()))
					{
						x5[] array = this.a;
						int num = i;
						array[num] = x5.f(array[num], A_1);
					}
				}
				break;
			case true:
				for (int i = A_3; i < A_3 + A_2; i++)
				{
					if (base.i()[i] == null)
					{
						x5[] array2 = this.a;
						int num2 = i;
						array2[num2] = x5.f(array2[num2], A_1);
					}
				}
				break;
			}
		}

		// Token: 0x060010C3 RID: 4291 RVA: 0x000C16BC File Offset: 0x000C06BC
		private void a(bool A_0, x5 A_1, int A_2, int A_3)
		{
			switch (A_0)
			{
			case false:
				for (int i = A_3; i < A_3 + A_2; i++)
				{
					if (x5.h(this.d[i], x5.c()))
					{
						x5[] array = this.b;
						int num = i;
						array[num] = x5.f(array[num], A_1);
					}
				}
				break;
			case true:
				for (int i = A_3; i < A_3 + A_2; i++)
				{
					if (base.i()[i] == null)
					{
						x5[] array2 = this.b;
						int num2 = i;
						array2[num2] = x5.f(array2[num2], A_1);
					}
				}
				break;
			}
		}

		// Token: 0x060010C4 RID: 4292 RVA: 0x000C1780 File Offset: 0x000C0780
		internal override x5[] dn()
		{
			x5 x = x5.c();
			if (base.j() == null)
			{
				x = base.l();
				x = x5.e(x, base.k());
			}
			else
			{
				x = base.j().Value;
			}
			int a_ = this.d(x);
			x5 a_2 = x5.c();
			foreach (x5 a_3 in this.c)
			{
				a_2 = x5.f(a_2, a_3);
			}
			if (base.j() != null || (x5.g(this.h, x5.c()) && x5.d(this.h, x) && x5.d(a_2, this.h)))
			{
				this.a(x, a_);
			}
			return this.c;
		}

		// Token: 0x0400080C RID: 2060
		private x5[] a = null;

		// Token: 0x0400080D RID: 2061
		private x5[] b = null;

		// Token: 0x0400080E RID: 2062
		private x5[] c = null;

		// Token: 0x0400080F RID: 2063
		private x5[] d = null;

		// Token: 0x04000810 RID: 2064
		private x5[] e = null;

		// Token: 0x04000811 RID: 2065
		private int f = 0;

		// Token: 0x04000812 RID: 2066
		private kz[][] g = null;

		// Token: 0x04000813 RID: 2067
		private x5 h = x5.c();

		// Token: 0x04000814 RID: 2068
		private bool i = false;
	}
}
