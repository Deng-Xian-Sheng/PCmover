using System;

namespace zz93
{
	// Token: 0x020003BF RID: 959
	internal class y3 : y1
	{
		// Token: 0x06002879 RID: 10361 RVA: 0x001765AC File Offset: 0x001755AC
		internal y3(y6 A_0)
		{
			this.v = A_0;
			this.w = new y4(A_0);
			this.x = new yz();
			this.k = new byte[65536];
			this.c = new short[32768];
			this.d = new short[32768];
			this.h = (this.i = 1);
		}

		// Token: 0x0600287A RID: 10362 RVA: 0x00176620 File Offset: 0x00175620
		internal new void d()
		{
			this.w.a();
			this.x.g2();
			this.h = (this.i = 1);
			this.j = 0;
			this.s = 0;
			this.g = false;
			this.f = 2;
			for (int i = 0; i < 32768; i++)
			{
				this.c[i] = 0;
			}
			for (int i = 0; i < 32768; i++)
			{
				this.d[i] = 0;
			}
		}

		// Token: 0x0600287B RID: 10363 RVA: 0x001766B0 File Offset: 0x001756B0
		internal new void e()
		{
			this.x.g2();
		}

		// Token: 0x0600287C RID: 10364 RVA: 0x001766C0 File Offset: 0x001756C0
		internal new int f()
		{
			return (int)this.x.g1();
		}

		// Token: 0x0600287D RID: 10365 RVA: 0x001766DE File Offset: 0x001756DE
		internal new void a(y2 A_0)
		{
			this.l = A_0;
		}

		// Token: 0x0600287E RID: 10366 RVA: 0x001766E8 File Offset: 0x001756E8
		internal new void b(int A_0)
		{
			this.p = y1.w[A_0];
			this.n = y1.x[A_0];
			this.o = y1.y[A_0];
			this.m = y1.z[A_0];
			if (y1.aa[A_0] != this.q)
			{
				switch (this.q)
				{
				case 0:
					if (this.i > this.h)
					{
						this.w.a(this.k, this.h, this.i - this.h, false);
						this.h = this.i;
					}
					this.c();
					break;
				case 1:
					if (this.i > this.h)
					{
						this.w.b(this.k, this.h, this.i - this.h, false);
						this.h = this.i;
					}
					break;
				case 2:
					if (this.g)
					{
						this.w.e((int)(this.k[this.i - 1] & byte.MaxValue));
					}
					if (this.i > this.h)
					{
						this.w.b(this.k, this.h, this.i - this.h, false);
						this.h = this.i;
					}
					this.g = false;
					this.f = 2;
					break;
				}
				this.q = y1.aa[A_0];
			}
		}

		// Token: 0x0600287F RID: 10367 RVA: 0x00176899 File Offset: 0x00175899
		private new void c()
		{
			this.b = ((int)this.k[this.i] << 5 ^ (int)this.k[this.i + 1]);
		}

		// Token: 0x06002880 RID: 10368 RVA: 0x001768C4 File Offset: 0x001758C4
		private new int b()
		{
			int num = (this.b << 5 ^ (int)this.k[this.i + 2]) & 32767;
			short num2 = this.d[this.i & 32767] = this.c[num];
			this.c[num] = (short)this.i;
			this.b = num;
			return (int)num2 & 65535;
		}

		// Token: 0x06002881 RID: 10369 RVA: 0x00176930 File Offset: 0x00175930
		private new void a()
		{
			Array.Copy(this.k, 32768, this.k, 0, 32768);
			this.e -= 32768;
			this.i -= 32768;
			this.h -= 32768;
			for (int i = 0; i < 32768; i++)
			{
				int num = (int)this.c[i] & 65535;
				this.c[i] = (short)((num >= 32768) ? (num - 32768) : 0);
			}
			for (int i = 0; i < 32768; i++)
			{
				int num = (int)this.d[i] & 65535;
				this.d[i] = (short)((num >= 32768) ? (num - 32768) : 0);
			}
		}

		// Token: 0x06002882 RID: 10370 RVA: 0x00176A14 File Offset: 0x00175A14
		internal new void g()
		{
			if (this.i >= 65274)
			{
				this.a();
			}
			while (this.j < 262 && this.t < this.u)
			{
				int num = 65536 - this.j - this.i;
				if (num > this.u - this.t)
				{
					num = this.u - this.t;
				}
				Array.Copy(this.r, this.t, this.k, this.i + this.j, num);
				this.x.g5(this.r, this.t, num);
				this.t += num;
				this.s += num;
				this.j += num;
			}
			if (this.j >= 3)
			{
				this.c();
			}
		}

		// Token: 0x06002883 RID: 10371 RVA: 0x00176B24 File Offset: 0x00175B24
		private new bool a(int A_0)
		{
			int num = this.m;
			int num2 = this.o;
			short[] array = this.d;
			int num3 = this.i;
			int num4 = this.i + this.f;
			int num5 = Math.Max(this.f, 2);
			int num6 = Math.Max(this.i - 32506, 0);
			int num7 = this.i + 258 - 1;
			byte b = this.k[num4 - 1];
			byte b2 = this.k[num4];
			if (num5 >= this.p)
			{
				num >>= 2;
			}
			if (num2 > this.j)
			{
				num2 = this.j;
			}
			do
			{
				if (this.k[A_0 + num5] == b2 && this.k[A_0 + num5 - 1] == b && this.k[A_0] == this.k[num3] && this.k[A_0 + 1] == this.k[num3 + 1])
				{
					int num8 = A_0 + 2;
					num3 += 2;
					while (this.k[++num3] == this.k[++num8] && this.k[++num3] == this.k[++num8] && this.k[++num3] == this.k[++num8] && this.k[++num3] == this.k[++num8] && this.k[++num3] == this.k[++num8] && this.k[++num3] == this.k[++num8] && this.k[++num3] == this.k[++num8] && this.k[++num3] == this.k[++num8] && num3 < num7)
					{
					}
					if (num3 > num4)
					{
						this.e = A_0;
						num4 = num3;
						num5 = num3 - this.i;
						if (num5 >= num2)
						{
							break;
						}
						b = this.k[num4 - 1];
						b2 = this.k[num4];
					}
					num3 = this.i;
				}
			}
			while ((A_0 = ((int)array[A_0 & 32767] & 65535)) > num6 && --num != 0);
			this.f = Math.Min(num5, this.j);
			return this.f >= 3;
		}

		// Token: 0x06002884 RID: 10372 RVA: 0x00176DDC File Offset: 0x00175DDC
		private new bool c(bool A_0, bool A_1)
		{
			bool result;
			if (!A_0 && this.j == 0)
			{
				result = false;
			}
			else
			{
				this.i += this.j;
				this.j = 0;
				int num = this.i - this.h;
				if (num >= y1.v || (this.h < 32768 && num >= 32506) || A_0)
				{
					bool flag = A_1;
					if (num > y1.v)
					{
						num = y1.v;
						flag = false;
					}
					this.w.a(this.k, this.h, num, flag);
					this.h += num;
					result = !flag;
				}
				else
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06002885 RID: 10373 RVA: 0x00176EAC File Offset: 0x00175EAC
		private new bool b(bool A_0, bool A_1)
		{
			bool result;
			if (this.j < 262 && !A_0)
			{
				result = false;
			}
			else
			{
				while (this.j >= 262 || A_0)
				{
					if (this.j == 0)
					{
						this.w.b(this.k, this.h, this.i - this.h, A_1);
						this.h = this.i;
						return false;
					}
					if (this.i > 65274)
					{
						this.a();
					}
					int num;
					if (this.j >= 3 && (num = this.b()) != 0 && this.l != y2.c && this.i - num <= 32506 && this.a(num))
					{
						this.w.a(this.i - this.e, this.f);
						this.j -= this.f;
						if (this.f <= this.n && this.j >= 3)
						{
							while (--this.f > 0)
							{
								this.i++;
								this.b();
							}
							this.i++;
						}
						else
						{
							this.i += this.f;
							if (this.j >= 2)
							{
								this.c();
							}
						}
						this.f = 2;
					}
					else
					{
						this.w.e((int)(this.k[this.i] & byte.MaxValue));
						this.i++;
						this.j--;
						if (this.w.c())
						{
							bool flag = A_1 && this.j == 0;
							this.w.b(this.k, this.h, this.i - this.h, flag);
							this.h = this.i;
							return !flag;
						}
					}
				}
				result = true;
			}
			return result;
		}

		// Token: 0x06002886 RID: 10374 RVA: 0x0017710C File Offset: 0x0017610C
		private new bool a(bool A_0, bool A_1)
		{
			bool result;
			if (this.j < 262 && !A_0)
			{
				result = false;
			}
			else
			{
				while (this.j >= 262 || A_0)
				{
					if (this.j == 0)
					{
						if (this.g)
						{
							this.w.e((int)(this.k[this.i - 1] & byte.MaxValue));
						}
						this.g = false;
						this.w.b(this.k, this.h, this.i - this.h, A_1);
						this.h = this.i;
						return false;
					}
					if (this.i >= 65274)
					{
						this.a();
					}
					int num = this.e;
					int num2 = this.f;
					if (this.j >= 3)
					{
						int num3 = this.b();
						if (this.l != y2.c && num3 != 0 && this.i - num3 <= 32506 && this.a(num3))
						{
							if (this.f <= 5 && (this.l == y2.b || (this.f == 3 && this.i - this.e > y3.a)))
							{
								this.f = 2;
							}
						}
					}
					if (num2 >= 3 && this.f <= num2)
					{
						this.w.a(this.i - 1 - num, num2);
						num2 -= 2;
						do
						{
							this.i++;
							this.j--;
							if (this.j >= 3)
							{
								this.b();
							}
						}
						while (--num2 > 0);
						this.i++;
						this.j--;
						this.g = false;
						this.f = 2;
					}
					else
					{
						if (this.g)
						{
							this.w.e((int)(this.k[this.i - 1] & byte.MaxValue));
						}
						this.g = true;
						this.i++;
						this.j--;
					}
					if (this.w.c())
					{
						int num4 = this.i - this.h;
						if (this.g)
						{
							num4--;
						}
						bool flag = A_1 && this.j == 0 && !this.g;
						this.w.b(this.k, this.h, num4, flag);
						this.h += num4;
						return !flag;
					}
				}
				result = true;
			}
			return result;
		}

		// Token: 0x06002887 RID: 10375 RVA: 0x00177430 File Offset: 0x00176430
		internal new bool d(bool A_0, bool A_1)
		{
			for (;;)
			{
				this.g();
				bool a_ = A_0 && this.t == this.u;
				bool flag;
				switch (this.q)
				{
				case 0:
					flag = this.c(a_, A_1);
					goto IL_66;
				case 1:
					flag = this.b(a_, A_1);
					goto IL_66;
				case 2:
					flag = this.a(a_, A_1);
					goto IL_66;
				}
				break;
				IL_66:
				if (!this.v.d() || !flag)
				{
					return flag;
				}
			}
			throw new InvalidOperationException("unknown comprFunc");
		}

		// Token: 0x06002888 RID: 10376 RVA: 0x001774C4 File Offset: 0x001764C4
		internal new void a(byte[] A_0, int A_1, int A_2)
		{
			if (this.t < this.u)
			{
				throw new InvalidOperationException("Old input was not completely processed");
			}
			int num = A_1 + A_2;
			if (0 > A_1 || A_1 > num || num > A_0.Length)
			{
				throw new ArgumentOutOfRangeException();
			}
			this.r = A_0;
			this.t = A_1;
			this.u = num;
		}

		// Token: 0x06002889 RID: 10377 RVA: 0x0017752C File Offset: 0x0017652C
		internal new bool h()
		{
			return this.u == this.t;
		}

		// Token: 0x040011F1 RID: 4593
		private new static int a = 4096;

		// Token: 0x040011F2 RID: 4594
		private new int b;

		// Token: 0x040011F3 RID: 4595
		private new short[] c;

		// Token: 0x040011F4 RID: 4596
		private new short[] d;

		// Token: 0x040011F5 RID: 4597
		private new int e;

		// Token: 0x040011F6 RID: 4598
		private new int f;

		// Token: 0x040011F7 RID: 4599
		private new bool g;

		// Token: 0x040011F8 RID: 4600
		private new int h;

		// Token: 0x040011F9 RID: 4601
		private new int i;

		// Token: 0x040011FA RID: 4602
		private new int j;

		// Token: 0x040011FB RID: 4603
		private new byte[] k;

		// Token: 0x040011FC RID: 4604
		private new y2 l;

		// Token: 0x040011FD RID: 4605
		private new int m;

		// Token: 0x040011FE RID: 4606
		private new int n;

		// Token: 0x040011FF RID: 4607
		private new int o;

		// Token: 0x04001200 RID: 4608
		private new int p;

		// Token: 0x04001201 RID: 4609
		private new int q;

		// Token: 0x04001202 RID: 4610
		private new byte[] r;

		// Token: 0x04001203 RID: 4611
		private new int s;

		// Token: 0x04001204 RID: 4612
		private new int t;

		// Token: 0x04001205 RID: 4613
		private new int u;

		// Token: 0x04001206 RID: 4614
		private new y6 v;

		// Token: 0x04001207 RID: 4615
		private new y4 w;

		// Token: 0x04001208 RID: 4616
		private new yz x;
	}
}
