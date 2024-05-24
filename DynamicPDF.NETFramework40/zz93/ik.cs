using System;

namespace zz93
{
	// Token: 0x02000154 RID: 340
	internal class ik
	{
		// Token: 0x06000CAE RID: 3246 RVA: 0x00092BB8 File Offset: 0x00091BB8
		internal ik(fc[] A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06000CAF RID: 3247 RVA: 0x00092C2C File Offset: 0x00091C2C
		internal int b()
		{
			return this.c;
		}

		// Token: 0x06000CB0 RID: 3248 RVA: 0x00092C44 File Offset: 0x00091C44
		internal void j(int A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06000CB1 RID: 3249 RVA: 0x00092C50 File Offset: 0x00091C50
		internal ii c()
		{
			return this.a;
		}

		// Token: 0x06000CB2 RID: 3250 RVA: 0x00092C68 File Offset: 0x00091C68
		internal ik d()
		{
			return this.j;
		}

		// Token: 0x06000CB3 RID: 3251 RVA: 0x00092C80 File Offset: 0x00091C80
		internal void a(ik A_0)
		{
			this.j = A_0;
		}

		// Token: 0x06000CB4 RID: 3252 RVA: 0x00092C8C File Offset: 0x00091C8C
		internal il e()
		{
			return this.l;
		}

		// Token: 0x06000CB5 RID: 3253 RVA: 0x00092CA4 File Offset: 0x00091CA4
		internal void a(il A_0)
		{
			this.l = A_0;
		}

		// Token: 0x06000CB6 RID: 3254 RVA: 0x00092CAE File Offset: 0x00091CAE
		internal void a(bool A_0)
		{
			this.k = A_0;
		}

		// Token: 0x06000CB7 RID: 3255 RVA: 0x00092CB8 File Offset: 0x00091CB8
		internal void a(int A_0, ig A_1)
		{
			if (this.a == null)
			{
				this.a = new ii();
				this.a.a(A_1);
				this.a.a(this.c);
				this.a.b(A_0);
				this.a.a(null);
			}
			else
			{
				this.b = new ii();
				this.b.a(A_1);
				this.b.a(this.c);
				this.b.b(A_0);
				this.b.a(this.a);
				this.a = this.b;
			}
		}

		// Token: 0x06000CB8 RID: 3256 RVA: 0x00092D78 File Offset: 0x00091D78
		internal void a(int A_0, ig A_1, int A_2, int A_3)
		{
			if (this.a == null)
			{
				this.a = new ii();
				this.a.a(A_1);
				this.a.a(this.c);
				this.a.b(A_0);
				this.a.c(A_2);
				this.a.d(A_3);
				this.a.a(null);
			}
			else
			{
				this.b = new ii();
				this.b.a(A_1);
				this.b.a(this.c);
				this.b.b(A_0);
				this.b.c(A_2);
				this.b.d(A_3);
				this.b.a(this.a);
				this.a = this.b;
			}
		}

		// Token: 0x06000CB9 RID: 3257 RVA: 0x00092E6C File Offset: 0x00091E6C
		private bool i(int A_0)
		{
			for (ii ii = this.a; ii != null; ii = ii.b())
			{
				if (ii.c() == A_0)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000CBA RID: 3258 RVA: 0x00092EB0 File Offset: 0x00091EB0
		internal bool a(kz A_0)
		{
			ii ii = this.a;
			if (ii != null && ii.d() == A_0.dg())
			{
				while (ii != null)
				{
					if (ii.c() == this.c)
					{
						if (ii.a() != null)
						{
							A_0.ao(true);
							return true;
						}
					}
					ii = ii.b();
				}
			}
			A_0.ao(false);
			return false;
		}

		// Token: 0x06000CBB RID: 3259 RVA: 0x00092F38 File Offset: 0x00091F38
		internal void c(int A_0, kz A_1)
		{
			if (A_0 != 6968946)
			{
				if (A_0 != 1617181893)
				{
					if (A_0 == 1652275116)
					{
						bool flag = this.e(A_0);
						if (!flag)
						{
							flag = this.d(A_0);
						}
						A_1.@as(flag);
					}
				}
				else
				{
					bool flag = this.c(A_0);
					if (!flag)
					{
						flag = this.b(A_0);
					}
					((nv)A_1).b(flag);
				}
			}
			else
			{
				bool flag = this.c(A_0);
				if (!flag)
				{
					flag = this.b(A_0);
				}
				A_1.au(flag);
			}
		}

		// Token: 0x06000CBC RID: 3260 RVA: 0x00092FC8 File Offset: 0x00091FC8
		internal ii k(int A_0)
		{
			for (ii ii = this.a; ii != null; ii = ii.b())
			{
				if (ii.c() == A_0)
				{
					return ii;
				}
			}
			return null;
		}

		// Token: 0x06000CBD RID: 3261 RVA: 0x0009300C File Offset: 0x0009200C
		internal void l(int A_0)
		{
			if (this.i(A_0))
			{
				if (this.a.c() == A_0)
				{
					while (this.a != null && this.a.c() == A_0)
					{
						this.a = this.a.b();
					}
				}
				else
				{
					ii ii = this.k(A_0);
					ii = ii.b();
					while (ii != null && ii.c() == A_0)
					{
						ii = ii.b();
					}
					this.a.a(ii);
				}
			}
		}

		// Token: 0x06000CBE RID: 3262 RVA: 0x000930B8 File Offset: 0x000920B8
		internal fc d(int A_0, kz A_1)
		{
			this.g = null;
			fc result;
			if (this.a(A_0))
			{
				result = this.a(A_0, A_1);
			}
			else
			{
				result = this.b(A_0, A_1);
			}
			return result;
		}

		// Token: 0x06000CBF RID: 3263 RVA: 0x000930F4 File Offset: 0x000920F4
		internal ja k(int A_0, int A_1)
		{
			fc fc = this.f(A_0, A_1);
			ja result;
			if (fc != null)
			{
				ja ja = new ja();
				ja.a(((ja)fc.b()).a());
				result = ja;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000CC0 RID: 3264 RVA: 0x0009313C File Offset: 0x0009213C
		internal fc l(int A_0, int A_1)
		{
			bool flag = true;
			this.g = null;
			bool flag2 = this.d(A_0, A_1);
			fc result;
			if (this.h > 0 && flag2)
			{
				result = this.e[0];
			}
			else
			{
				flag2 = this.e(A_0, A_1);
				if (this.h > 0)
				{
					this.g = new fc(this.e[0].a(), this.e[0].b());
				}
				if (this.i > 0)
				{
					if (flag2)
					{
						return this.f[0];
					}
					if (this.g == null)
					{
						this.g = new fc(this.f[0].a(), this.f[0].b());
					}
					this.a(this.f[0], flag);
					if (this.h > 0)
					{
						this.a(this.e[0], !flag);
					}
				}
				if (this.g != null)
				{
					this.a();
				}
				result = this.g;
			}
			return result;
		}

		// Token: 0x06000CC1 RID: 3265 RVA: 0x00093278 File Offset: 0x00092278
		private fc b(int A_0, kz A_1)
		{
			ii a_ = this.a;
			int a_2 = 0;
			fc fc = this.e(A_0, this.c, ref a_);
			if (fc == null)
			{
				a_ = this.a;
				fc = this.h(A_0);
				if (fc == null)
				{
					fc = this.c(A_0, this.c, ref a_);
					if (fc == null)
					{
						fc = this.g(A_0);
						if ((fc == null && this.a(A_0, A_1.dg())) || (fc != null && fc.b().cx().g()))
						{
							fc = this.a(A_0, a_);
						}
					}
					else if (fc.b() != null && fc.b().cx() != null && fc.b().cx().g())
					{
						fc = this.c(A_0, a_2, ref a_);
						if (fc == null || fc.b().cx().g())
						{
							fc = this.g(A_0);
						}
					}
				}
			}
			else if (fc != null && fc.b().cx() != null && fc.b().cx().g())
			{
				fc fc2 = fc;
				fc = this.d(A_0, a_2, ref a_);
				if (fc == null)
				{
					fc = this.h(A_0);
					if (fc == null)
					{
						fc = this.c(A_0, a_2, ref a_);
						if (fc == null)
						{
							fc = this.g(A_0);
						}
					}
				}
				if (A_0 == 633671921)
				{
					fc = fc2;
				}
			}
			if (fc != null && fc.b() != null && fc.b().cx() != null && fc.b().cx().g())
			{
				if (A_0 != 633671921)
				{
					return null;
				}
			}
			return fc;
		}

		// Token: 0x06000CC2 RID: 3266 RVA: 0x00093490 File Offset: 0x00092490
		private fc e(int A_0, int A_1, ref ii A_2)
		{
			while (A_2 != null)
			{
				if (A_2.a() != null)
				{
					if (A_2.c() < A_1)
					{
						break;
					}
					fc[] array = A_2.a().b();
					int num = array.Length;
					if (array.Length > 0 && array[array.Length - 1].a() == 1210592242)
					{
						num = ((af7)array[array.Length - 1].b()).a();
						for (int i = num; i < array.Length; i++)
						{
							if (array[i].a() == A_0)
							{
								A_2 = A_2.b();
								return array[i];
							}
						}
					}
				}
				A_2 = A_2.b();
			}
			return null;
		}

		// Token: 0x06000CC3 RID: 3267 RVA: 0x00093580 File Offset: 0x00092580
		private fc d(int A_0, int A_1, ref ii A_2)
		{
			int num = 0;
			while (A_2 != null)
			{
				if (A_2.a() != null)
				{
					if (A_2.c() < A_1)
					{
						break;
					}
					fc[] array = A_2.a().b();
					if (array.Length > 0)
					{
						if (array[array.Length - 1].a() == 1210592242)
						{
							num = ((af7)array[array.Length - 1].b()).a();
						}
						for (int i = num; i < array.Length; i++)
						{
							if (array[i].a() == A_0)
							{
								A_2 = A_2.b();
								return array[i];
							}
						}
					}
				}
				A_2 = A_2.b();
			}
			return null;
		}

		// Token: 0x06000CC4 RID: 3268 RVA: 0x00093670 File Offset: 0x00092670
		private fc h(int A_0)
		{
			if (this.d != null && this.d.Length > 1 && this.d[this.d.Length - 1] != null && this.d[this.d.Length - 1].a() == 1210592242)
			{
				int num = ((af7)this.d[this.d.Length - 1].b()).a();
				for (int i = num; i < this.d.Length - 1; i++)
				{
					if (this.d[i].a() == A_0)
					{
						return this.d[i];
					}
				}
			}
			return null;
		}

		// Token: 0x06000CC5 RID: 3269 RVA: 0x00093738 File Offset: 0x00092738
		private fc c(int A_0, int A_1, ref ii A_2)
		{
			while (A_2 != null)
			{
				if (A_2.a() != null)
				{
					if (A_2.c() < A_1)
					{
						break;
					}
					fc[] array = A_2.a().b();
					int num = array.Length;
					if (array.Length > 0)
					{
						if (array[array.Length - 1].a() == 1210592242)
						{
							num = ((af7)array[array.Length - 1].b()).a();
						}
						for (int i = 0; i < num; i++)
						{
							if (array[i].a() == A_0)
							{
								A_2 = A_2.b();
								return array[i];
							}
						}
					}
				}
				A_2 = A_2.b();
			}
			return null;
		}

		// Token: 0x06000CC6 RID: 3270 RVA: 0x0009382C File Offset: 0x0009282C
		private fc g(int A_0)
		{
			if (this.d != null)
			{
				int num = this.d.Length;
				if (this.d.Length > 0 && this.d[this.d.Length - 1] != null && this.d[this.d.Length - 1].a() == 1210592242)
				{
					num = ((af7)this.d[this.d.Length - 1].b()).a();
				}
				for (int i = 0; i < num; i++)
				{
					if (this.d[i] != null && this.d[i].a() == A_0)
					{
						return this.d[i];
					}
				}
			}
			return null;
		}

		// Token: 0x06000CC7 RID: 3271 RVA: 0x0009390C File Offset: 0x0009290C
		private fc a(int A_0, ii A_1)
		{
			ii ii = A_1;
			int a_ = 0;
			fc fc = this.e(A_0, a_, ref ii);
			if (fc == null)
			{
				fc = this.c(A_0, a_, ref A_1);
				while (fc != null && fc.b().cx() != null && fc.b().cx().g())
				{
					fc = this.c(A_0, a_, ref A_1);
				}
				if (fc == null)
				{
					fc = this.g(A_0);
				}
			}
			return fc;
		}

		// Token: 0x06000CC8 RID: 3272 RVA: 0x00093998 File Offset: 0x00092998
		private fc a(int A_0, kz A_1)
		{
			this.h = (this.i = 0);
			ii ii = this.a;
			bool a_ = true;
			bool flag = this.b(A_0, this.c, ref ii);
			fc result;
			if (this.h > 0)
			{
				this.g = new fc(this.e[0].a(), this.e[0].b());
				if (flag)
				{
					if (!this.a(this.e[0]))
					{
						result = this.e[0];
					}
					else
					{
						fc fc = this.h(A_0);
						if (fc != null)
						{
							this.a(fc, a_);
							flag = fc.b().ct();
							if (flag && !this.a(fc))
							{
								return fc;
							}
						}
						flag = this.b(A_0, 0, ref ii);
						if (this.h > 0)
						{
							this.a(this.e[0], a_);
						}
						this.a();
						result = this.g;
					}
				}
				else
				{
					this.g = this.j(A_0, A_1.dg());
					if (this.g != null)
					{
						this.a();
					}
					result = this.g;
				}
			}
			else
			{
				this.g = this.i(A_0, A_1.dg());
				if (this.g != null)
				{
					this.a();
				}
				result = this.g;
			}
			return result;
		}

		// Token: 0x06000CC9 RID: 3273 RVA: 0x00093B30 File Offset: 0x00092B30
		private fc j(int A_0, int A_1)
		{
			ii ii = this.a;
			bool flag = true;
			ii ii2 = ii;
			this.b(A_0, 0, ref ii);
			if (this.h > 0)
			{
				this.a(this.e[0], flag);
			}
			fc fc = this.h(A_0);
			if (fc != null)
			{
				this.a(fc, flag);
				this.a(fc, !flag);
			}
			ii = this.a;
			this.a(A_0, this.c, ref ii);
			if (this.i > 0)
			{
				this.a(this.f[0], !flag);
			}
			fc = this.g(A_0);
			if (fc != null)
			{
				this.a(fc, !flag);
			}
			this.a(A_0, 0, ref ii2);
			if (this.i > 0)
			{
				this.a(this.f[0], flag);
				if (this.a(A_0, A_1))
				{
					if (this.h > 0)
					{
						this.a(this.e[0], !flag);
					}
					this.a(this.f[0], !flag);
				}
			}
			return this.g;
		}

		// Token: 0x06000CCA RID: 3274 RVA: 0x00093C80 File Offset: 0x00092C80
		private fc i(int A_0, int A_1)
		{
			ii ii = this.a;
			fc fc = this.h(A_0);
			fc result;
			if (fc != null)
			{
				this.g = new fc(fc.a(), fc.b());
				bool flag = fc.b().ct();
				if (flag)
				{
					if (!this.a(fc))
					{
						result = fc;
					}
					else
					{
						flag = this.b(A_0, 0, ref ii);
						if (this.h > 0)
						{
							this.a(this.e[0], true);
							if (flag && this.a(this.e[0]))
							{
								result = null;
							}
							else
							{
								result = this.g;
							}
						}
						else
						{
							result = null;
						}
					}
				}
				else
				{
					flag = this.b(A_0, 0, ref ii);
					if (this.h > 0)
					{
						this.a(this.e[0], true);
					}
					ii = this.a;
					flag = this.a(A_0, this.c, ref ii);
					if (this.i > 0)
					{
						this.a(this.f[0], true);
						this.a(this.f[0], false);
						if (flag && !this.a(this.f[0]))
						{
							return this.g;
						}
					}
					fc = this.g(A_0);
					if (fc != null)
					{
						this.a(fc, false);
					}
					if (this.a(A_0, A_1))
					{
						if (this.h > 0)
						{
							this.a(this.e[0], false);
						}
						flag = this.a(A_0, 0, ref ii);
						if (this.i > 0)
						{
							this.a(this.f[0], false);
						}
					}
					result = this.g;
				}
			}
			else
			{
				result = this.h(A_0, A_1);
			}
			return result;
		}

		// Token: 0x06000CCB RID: 3275 RVA: 0x00093E88 File Offset: 0x00092E88
		private fc h(int A_0, int A_1)
		{
			ii ii = this.a;
			bool flag = this.a(A_0, this.c, ref ii);
			fc result;
			if (this.i > 0)
			{
				this.g = new fc(this.f[0].a(), this.f[0].b());
				if (flag && !this.a(this.f[0]))
				{
					result = this.f[0];
				}
				else if (!this.a(this.f[0].a(), A_1))
				{
					result = this.f[0];
				}
				else
				{
					ii ii2 = ii;
					flag = this.b(A_0, 0, ref ii);
					if (this.h > 0)
					{
						this.a(this.e[0], true);
						if (this.a(A_0, A_1))
						{
							this.a(this.e[0], false);
						}
					}
					ii = ii2;
					if (ii != null)
					{
						if (A_0 != 148235845)
						{
							flag = this.a(A_0, 0, ref ii);
						}
						else
						{
							flag = this.a(A_0, this.c - 1, ref ii);
						}
					}
					if (this.i > 0)
					{
						this.a(this.f[0], true);
						if (this.a(A_0, A_1))
						{
							this.a(this.f[0], false);
						}
					}
					fc fc = this.g(A_0);
					if (fc != null)
					{
						this.a(fc, true);
						this.a(fc, false);
					}
					result = this.g;
				}
			}
			else
			{
				result = this.g(A_0, A_1);
			}
			return result;
		}

		// Token: 0x06000CCC RID: 3276 RVA: 0x00094054 File Offset: 0x00093054
		private fc g(int A_0, int A_1)
		{
			ii ii = this.a;
			fc fc = this.g(A_0);
			if (fc != null)
			{
				this.g = new fc(A_0, fc.b());
				bool flag = fc.b().ct();
				if (flag && !this.a(fc))
				{
					return fc;
				}
				flag = this.b(A_0, 0, ref ii);
				if (this.h > 0)
				{
					this.a(this.e[0], true);
				}
				ii = this.a;
				flag = this.a(A_0, 0, ref ii);
				if (this.i > 0)
				{
					this.a(this.f[0], true);
				}
			}
			if (this.a(A_0, A_1))
			{
				ii = this.a;
				bool flag = this.b(A_0, 0, ref ii);
				if (this.h > 0)
				{
					if (this.g == null)
					{
						this.g = new fc(this.e[0].a(), this.e[0].b());
					}
					else
					{
						this.a(this.e[0], false);
					}
				}
				ii = this.a;
				flag = this.a(A_0, 0, ref ii);
				if (this.i > 0)
				{
					if (this.g == null)
					{
						this.g = new fc(this.f[0].a(), this.f[0].b());
					}
					else
					{
						this.a(this.f[0], true);
						this.a(this.f[0], false);
					}
				}
			}
			return this.g;
		}

		// Token: 0x06000CCD RID: 3277 RVA: 0x00094230 File Offset: 0x00093230
		private fc f(int A_0, int A_1)
		{
			fc fc = this.c(A_0, A_1);
			if (fc == null)
			{
				fc = this.b(A_0, A_1);
			}
			fc result;
			if (fc != null && fc.b().cx() != null && fc.b().cx().g())
			{
				result = null;
			}
			else
			{
				result = fc;
			}
			return result;
		}

		// Token: 0x06000CCE RID: 3278 RVA: 0x00094294 File Offset: 0x00093294
		private bool e(int A_0, int A_1)
		{
			this.i = 0;
			bool flag = false;
			int num = this.f(A_1);
			ii ii = this.j.c();
			while (ii != null)
			{
				if (ii.a() != null)
				{
					if (ii.c() < 0)
					{
						return flag;
					}
					if (ii.f() == num)
					{
						if (A_0 != 148235845 || ii.c() == this.j.c().c())
						{
							fc[] array = ii.a().b();
							int num2 = array.Length;
							if (array.Length > 0)
							{
								if (array[array.Length - 1].a() == 1210592242)
								{
									num2 = ((af7)array[array.Length - 1].b()).a();
								}
								for (int i = 0; i < num2; i++)
								{
									if (array[i].a() == A_0)
									{
										this.f[this.i] = array[i];
										if (this.i > 0)
										{
											this.f[this.i - 1] = this.a(this.f[this.i - 1], this.f[this.i]);
										}
										else
										{
											this.i++;
										}
										flag = array[i].b().ct();
										if (flag)
										{
											ii = ii.b();
											return flag;
										}
									}
								}
							}
						}
					}
				}
				ii = ii.b();
				if (!flag)
				{
					continue;
				}
				return flag;
			}
			return flag;
		}

		// Token: 0x06000CCF RID: 3279 RVA: 0x00094494 File Offset: 0x00093494
		private bool d(int A_0, int A_1)
		{
			this.h = 0;
			bool flag = false;
			int num = this.f(A_1);
			ii ii = this.j.c();
			while (ii != null)
			{
				if (ii.a() != null)
				{
					if (ii.c() < 0)
					{
						return flag;
					}
					if (ii.f() == num)
					{
						if (A_0 != 148235845 || ii.d() == this.j.c().d())
						{
							fc[] array = ii.a().b();
							if (array.Length > 0 && array[array.Length - 1].a() == 1210592242)
							{
								int num2 = ((af7)array[array.Length - 1].b()).a();
								for (int i = num2; i < array.Length; i++)
								{
									if (array[i].a() == A_0)
									{
										this.e[this.h] = array[i];
										if (this.h > 0)
										{
											this.e[this.h - 1] = this.a(this.e[this.h - 1], this.e[this.h]);
										}
										else
										{
											this.h++;
										}
										flag = array[i].b().ct();
										if (flag)
										{
											ii = ii.b();
											return flag;
										}
									}
								}
							}
						}
					}
				}
				ii = ii.b();
				if (!flag)
				{
					continue;
				}
				return flag;
			}
			return flag;
		}

		// Token: 0x06000CD0 RID: 3280 RVA: 0x0009468C File Offset: 0x0009368C
		private fc c(int A_0, int A_1)
		{
			int num = this.f(A_1);
			for (ii ii = this.j.c(); ii != null; ii = ii.b())
			{
				if (ii.a() != null)
				{
					if (ii.c() < 0)
					{
						break;
					}
					if (ii.f() == num)
					{
						fc[] array = ii.a().b();
						if (array.Length > 0 && array[array.Length - 1].a() == 1210592242)
						{
							int num2 = ((af7)array[array.Length - 1].b()).a();
							for (int i = num2; i < array.Length; i++)
							{
								if (array[i].a() == A_0)
								{
									ii = ii.b();
									return array[i];
								}
							}
						}
					}
				}
			}
			return null;
		}

		// Token: 0x06000CD1 RID: 3281 RVA: 0x000947A4 File Offset: 0x000937A4
		private fc b(int A_0, int A_1)
		{
			int num = this.f(A_1);
			for (ii ii = this.j.c(); ii != null; ii = ii.b())
			{
				if (ii.a() != null)
				{
					if (ii.c() < 0)
					{
						break;
					}
					if (ii.f() == num)
					{
						fc[] array = ii.a().b();
						int num2 = array.Length;
						if (array.Length > 0)
						{
							if (array[array.Length - 1].a() == 1210592242)
							{
								num2 = ((af7)array[array.Length - 1].b()).a();
							}
							for (int i = 0; i < num2; i++)
							{
								if (array[i].a() == A_0)
								{
									ii = ii.b();
									return array[i];
								}
							}
						}
					}
				}
			}
			return null;
		}

		// Token: 0x06000CD2 RID: 3282 RVA: 0x000948C4 File Offset: 0x000938C4
		private int f(int A_0)
		{
			ii ii = this.j.c();
			int num = A_0;
			while (ii != null)
			{
				if (ii.a() != null)
				{
					if (ii.f() <= A_0)
					{
						int result;
						if (ii.f() == A_0)
						{
							result = A_0;
						}
						else
						{
							if (ii.f() < 0 || ii.f() >= A_0)
							{
								goto IL_87;
							}
							if (num > A_0)
							{
								result = ii.f();
							}
							else
							{
								result = -1;
							}
						}
						return result;
					}
					num = ii.f();
					IL_87:;
				}
				ii = ii.b();
			}
			return 0;
		}

		// Token: 0x06000CD3 RID: 3283 RVA: 0x00094974 File Offset: 0x00093974
		private void a()
		{
			int num = this.g.a();
			if (num <= 148235845)
			{
				if (num != 6968946)
				{
					if (num == 148235845)
					{
						fg fg = (fg)this.g.b();
						fb<fu>[] array = fg.a();
						for (int i = 0; i < array.Length; i++)
						{
							if (array[i].a() != 0 && array[i].b().g())
							{
								array[i].a(0);
							}
						}
						this.g.a(fg);
					}
				}
				else
				{
					hd hd = (hd)this.g.b();
					fb<f5>[] array2 = hd.a();
					for (int i = 0; i < array2.Length; i++)
					{
						if (array2[i].a() != 0 && array2[i].b().g())
						{
							array2[i].a(0);
						}
					}
					this.g.a(hd);
				}
			}
			else if (num != 254664735)
			{
				if (num != 265770411)
				{
					if (num == 1617181893)
					{
						fe fe = (fe)this.g.b();
						fb<fs>[] array3 = fe.a();
						for (int i = 0; i < array3.Length; i++)
						{
							if (array3[i].a() != 0 && array3[i].b().g())
							{
								array3[i].a(0);
							}
						}
						this.g.a(fe);
					}
				}
				else
				{
					hx hx = (hx)this.g.b();
					fb<ge>[] array4 = hx.a();
					for (int i = 0; i < array4.Length; i++)
					{
						if (array4[i].a() != 0 && array4[i].b().g())
						{
							array4[i].a(0);
						}
					}
					this.g.a(hx);
				}
			}
			else
			{
				hr hr = (hr)this.g.b();
				fb<f9>[] array5 = hr.a();
				for (int i = 0; i < array5.Length; i++)
				{
					if (array5[i].a() != 0 && array5[i].b().g())
					{
						array5[i].a(0);
					}
				}
				this.g.a(hr);
			}
		}

		// Token: 0x06000CD4 RID: 3284 RVA: 0x00094C54 File Offset: 0x00093C54
		private void a(fc A_0, bool A_1)
		{
			int num = A_0.a();
			if (num <= 148235845)
			{
				if (num != 6968946)
				{
					if (num == 148235845)
					{
						fg fg = (fg)this.g.b();
						this.g.a(A_1 ? fg.a((fg)A_0.b()) : fg.b((fg)A_0.b()));
					}
				}
				else
				{
					hd hd = (hd)this.g.b();
					this.g.a(A_1 ? hd.a((hd)A_0.b()) : hd.b((hd)A_0.b()));
				}
			}
			else if (num != 254664735)
			{
				if (num != 265770411)
				{
					if (num == 1617181893)
					{
						fe fe = (fe)this.g.b();
						this.g.a(A_1 ? fe.a((fe)A_0.b()) : fe.b((fe)A_0.b()));
					}
				}
				else
				{
					hx hx = (hx)this.g.b();
					this.g.a(A_1 ? hx.a((hx)A_0.b()) : hx.b((hx)A_0.b()));
				}
			}
			else
			{
				hr hr = (hr)this.g.b();
				this.g.a(A_1 ? hr.a((hr)A_0.b()) : hr.b((hr)A_0.b()));
			}
		}

		// Token: 0x06000CD5 RID: 3285 RVA: 0x00094E24 File Offset: 0x00093E24
		private bool a(fc A_0)
		{
			int num = A_0.a();
			if (num <= 148235845)
			{
				if (num == 6947816)
				{
					hq hq = (hq)A_0.b();
					return hq.b();
				}
				if (num == 6968946)
				{
					hd hd = (hd)A_0.b();
					return hd.b();
				}
				if (num == 148235845)
				{
					fg fg = (fg)A_0.b();
					return fg.c();
				}
			}
			else
			{
				if (num == 254664735)
				{
					hr hr = (hr)A_0.b();
					return hr.b();
				}
				if (num == 265770411)
				{
					hx hx = (hx)A_0.b();
					return hx.b();
				}
				if (num == 1617181893)
				{
					fe fe = (fe)A_0.b();
					return fe.b();
				}
			}
			return false;
		}

		// Token: 0x06000CD6 RID: 3286 RVA: 0x00094F14 File Offset: 0x00093F14
		private bool b(int A_0, int A_1, ref ii A_2)
		{
			this.h = 0;
			bool flag = false;
			while (A_2 != null)
			{
				if (A_2.a() != null)
				{
					if (A_2.c() < A_1)
					{
						return flag;
					}
					fc[] array = A_2.a().b();
					if (array.Length > 0 && array[array.Length - 1].a() == 1210592242)
					{
						int num = ((af7)array[array.Length - 1].b()).a();
						for (int i = num; i < array.Length; i++)
						{
							if (array[i].a() == A_0 && array[i].b() != null)
							{
								this.e[this.h] = array[i];
								if (this.h > 0)
								{
									this.e[this.h - 1] = this.a(this.e[this.h - 1], this.e[this.h]);
								}
								else
								{
									this.h++;
								}
								flag = array[i].b().ct();
								if (flag)
								{
									A_2 = A_2.b();
									return flag;
								}
							}
						}
					}
				}
				A_2 = A_2.b();
				if (!flag)
				{
					continue;
				}
				return flag;
			}
			return flag;
		}

		// Token: 0x06000CD7 RID: 3287 RVA: 0x000950B0 File Offset: 0x000940B0
		private bool a(int A_0, int A_1, ref ii A_2)
		{
			this.i = 0;
			bool flag = false;
			while (A_2 != null)
			{
				if (A_2.a() != null)
				{
					if (A_2.c() < A_1)
					{
						return flag;
					}
					fc[] array = A_2.a().b();
					int num = array.Length;
					if (array.Length > 0)
					{
						if (array[array.Length - 1].a() == 1210592242)
						{
							num = ((af7)array[array.Length - 1].b()).a();
						}
						for (int i = 0; i < num; i++)
						{
							if (array[i].a() == A_0 && array[i].b() != null)
							{
								this.f[this.i] = array[i];
								if (this.i > 0)
								{
									this.f[this.i - 1] = this.a(this.f[this.i - 1], this.f[this.i]);
								}
								else
								{
									this.i++;
								}
								flag = array[i].b().ct();
								if (flag)
								{
									A_2 = A_2.b();
									return flag;
								}
							}
						}
					}
				}
				A_2 = A_2.b();
				if (!flag)
				{
					continue;
				}
				return flag;
			}
			return flag;
		}

		// Token: 0x06000CD8 RID: 3288 RVA: 0x00095254 File Offset: 0x00094254
		private fc a(fc A_0, fc A_1)
		{
			fc fc = new fc(A_0.a(), null);
			int num = A_0.a();
			if (num <= 148235845)
			{
				if (num != 6947816)
				{
					if (num != 6968946)
					{
						if (num == 148235845)
						{
							fg fg = new fg();
							fc.a(fg.a((fg)A_0.b(), (fg)A_1.b()));
						}
					}
					else
					{
						hd hd = new hd();
						fc.a(hd.a((hd)A_0.b(), (hd)A_1.b()));
					}
				}
				else
				{
					hq hq = new hq();
					fc.a(hq.a((hq)A_0.b(), (hq)A_1.b()));
				}
			}
			else if (num != 254664735)
			{
				if (num != 265770411)
				{
					if (num == 1617181893)
					{
						fe fe = new fe();
						fc.a(fe.a((fe)A_0.b(), (fe)A_1.b()));
					}
				}
				else
				{
					hx hx = new hx();
					fc.a(hx.a((hx)A_0.b(), (hx)A_1.b()));
				}
			}
			else
			{
				hr hr = new hr();
				fc.a(hr.a((hr)A_0.b(), (hr)A_1.b()));
			}
			return fc;
		}

		// Token: 0x06000CD9 RID: 3289 RVA: 0x000953E4 File Offset: 0x000943E4
		private bool e(int A_0)
		{
			for (ii ii = this.a; ii != null; ii = ii.b())
			{
				if (ii.a() != null)
				{
					if (ii.c() < this.c)
					{
						break;
					}
					fc[] array = ii.a().b();
					if (array.Length > 0 && array[array.Length - 1].a() == 1210592242)
					{
						int num = ((af7)array[array.Length - 1].b()).a();
						for (int i = num; i < array.Length; i++)
						{
							if (array[i].a() == A_0)
							{
								if (!array[i].b().cx().g())
								{
									return true;
								}
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06000CDA RID: 3290 RVA: 0x000954E8 File Offset: 0x000944E8
		private bool d(int A_0)
		{
			for (ii ii = this.a; ii != null; ii = ii.b())
			{
				if (ii.a() != null)
				{
					if (ii.c() < this.c)
					{
						break;
					}
					fc[] array = ii.a().b();
					int num = array.Length;
					if (array.Length > 0)
					{
						if (array[array.Length - 1].a() == 1210592242)
						{
							num = ((af7)array[array.Length - 1].b()).a();
						}
						for (int i = 0; i < num; i++)
						{
							if (array[i].a() == A_0)
							{
								if (!array[i].b().cx().g())
								{
									return true;
								}
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06000CDB RID: 3291 RVA: 0x000955F0 File Offset: 0x000945F0
		private bool c(int A_0)
		{
			for (ii ii = this.a; ii != null; ii = ii.b())
			{
				if (ii.a() != null)
				{
					if (ii.c() < this.c)
					{
						break;
					}
					fc[] array = ii.a().b();
					if (array.Length > 0 && array[array.Length - 1].a() == 1210592242)
					{
						int num = ((af7)array[array.Length - 1].b()).a();
						for (int i = num; i < array.Length; i++)
						{
							if (array[i].a() == A_0)
							{
								bool flag = array[i].b().ct();
								if (A_0 != 6968946)
								{
									if (A_0 == 1617181893)
									{
										if (!((fe)array[i].b()).a(137106767, ((fe)array[i].b()).a()) && !((hd)array[i].b()).b(137106767))
										{
											return true;
										}
									}
								}
								else if (((hd)array[i].b()).a(2163680, ((hd)array[i].b()).a()) && !((hd)array[i].b()).b(2163680))
								{
									return true;
								}
								if (flag)
								{
									return false;
								}
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06000CDC RID: 3292 RVA: 0x000957D0 File Offset: 0x000947D0
		private bool b(int A_0)
		{
			for (ii ii = this.a; ii != null; ii = ii.b())
			{
				if (ii.a() != null)
				{
					if (ii.c() < this.c)
					{
						break;
					}
					fc[] array = ii.a().b();
					int num = array.Length;
					if (array.Length > 0)
					{
						if (array[array.Length - 1].a() == 1210592242)
						{
							num = ((af7)array[array.Length - 1].b()).a();
						}
						for (int i = 0; i < num; i++)
						{
							if (array[i].a() == A_0)
							{
								bool flag = array[i].b().ct();
								if (A_0 != 6968946)
								{
									if (A_0 == 1617181893)
									{
										if (!((fe)array[i].b()).a(137106767, ((fe)array[i].b()).a()) && !((hd)array[i].b()).b(137106767))
										{
											return true;
										}
									}
								}
								else if (((hd)array[i].b()).a(2163680, ((hd)array[i].b()).a()) && !((hd)array[i].b()).b(2163680))
								{
									return true;
								}
								if (flag)
								{
									return false;
								}
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06000CDD RID: 3293 RVA: 0x000959B8 File Offset: 0x000949B8
		private bool a(int A_0, int A_1)
		{
			if (A_0 <= 633671921)
			{
				if (A_0 <= 189525969)
				{
					if (A_0 != 6968946 && A_0 != 40160150 && A_0 != 189525969)
					{
						goto IL_120;
					}
				}
				else
				{
					if (A_0 == 510035525)
					{
						return A_1 != 1;
					}
					if (A_0 != 587060291 && A_0 != 633671921)
					{
						goto IL_120;
					}
				}
			}
			else if (A_0 <= 1652275116)
			{
				if (A_0 != 758075048)
				{
					if (A_0 == 1617181893)
					{
						return this.k;
					}
					if (A_0 != 1652275116)
					{
						goto IL_120;
					}
				}
			}
			else if (A_0 <= 1982853278)
			{
				if (A_0 != 1844443081 && A_0 != 1982853278)
				{
					goto IL_120;
				}
			}
			else
			{
				if (A_0 == 1982903832)
				{
					if (A_1 <= 2585)
					{
						if (A_1 != 1000 && A_1 != 2585)
						{
						}
					}
					else if (A_1 != 2595)
					{
						if (A_1 == 144937050 || A_1 == 445520207)
						{
							return false;
						}
					}
					return true;
				}
				if (A_0 != 2098498396)
				{
					goto IL_120;
				}
			}
			return true;
			IL_120:
			return false;
		}

		// Token: 0x06000CDE RID: 3294 RVA: 0x00095AEC File Offset: 0x00094AEC
		private bool a(int A_0)
		{
			if (A_0 <= 8714757)
			{
				if (A_0 != 6947816 && A_0 != 6968946 && A_0 != 8714757)
				{
					goto IL_55;
				}
			}
			else if (A_0 <= 254664735)
			{
				if (A_0 != 148235845 && A_0 != 254664735)
				{
					goto IL_55;
				}
			}
			else if (A_0 != 265770411 && A_0 != 1617181893)
			{
				goto IL_55;
			}
			return true;
			IL_55:
			return false;
		}

		// Token: 0x04000687 RID: 1671
		private ii a = null;

		// Token: 0x04000688 RID: 1672
		private ii b = null;

		// Token: 0x04000689 RID: 1673
		private int c = 0;

		// Token: 0x0400068A RID: 1674
		private fc[] d = null;

		// Token: 0x0400068B RID: 1675
		private fc[] e = new fc[2];

		// Token: 0x0400068C RID: 1676
		private fc[] f = new fc[2];

		// Token: 0x0400068D RID: 1677
		private fc g = null;

		// Token: 0x0400068E RID: 1678
		private int h = 0;

		// Token: 0x0400068F RID: 1679
		private int i = 0;

		// Token: 0x04000690 RID: 1680
		private ik j;

		// Token: 0x04000691 RID: 1681
		private bool k = false;

		// Token: 0x04000692 RID: 1682
		private il l = il.a;
	}
}
