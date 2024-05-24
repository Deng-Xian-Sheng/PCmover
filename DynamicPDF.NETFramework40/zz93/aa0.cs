using System;

namespace zz93
{
	// Token: 0x0200040D RID: 1037
	internal class aa0 : aay
	{
		// Token: 0x06002B52 RID: 11090 RVA: 0x0018FB58 File Offset: 0x0018EB58
		internal aa0(aa3 A_0)
		{
			this.v = A_0;
			this.w = new aa1(A_0);
			this.x = new aaw();
			this.k = new byte[65536];
			this.c = new short[32768];
			this.d = new short[32768];
			this.h = (this.i = 1);
		}

		// Token: 0x06002B53 RID: 11091 RVA: 0x0018FBCC File Offset: 0x0018EBCC
		internal new void d()
		{
			this.w.a();
			this.x.hr();
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

		// Token: 0x06002B54 RID: 11092 RVA: 0x0018FC5C File Offset: 0x0018EC5C
		internal new void e()
		{
			this.x.hr();
		}

		// Token: 0x06002B55 RID: 11093 RVA: 0x0018FC6C File Offset: 0x0018EC6C
		internal new int f()
		{
			return (int)this.x.hq();
		}

		// Token: 0x06002B56 RID: 11094 RVA: 0x0018FC8A File Offset: 0x0018EC8A
		internal new void a(aaz A_0)
		{
			this.l = A_0;
		}

		// Token: 0x06002B57 RID: 11095 RVA: 0x0018FC94 File Offset: 0x0018EC94
		internal new void b(int A_0)
		{
			this.p = aay.w[A_0];
			this.n = aay.x[A_0];
			this.o = aay.y[A_0];
			this.m = aay.z[A_0];
			if (aay.aa[A_0] != this.q)
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
				this.q = aay.aa[A_0];
			}
		}

		// Token: 0x06002B58 RID: 11096 RVA: 0x0018FE45 File Offset: 0x0018EE45
		private new void c()
		{
			this.b = ((int)this.k[this.i] << 5 ^ (int)this.k[this.i + 1]);
		}

		// Token: 0x06002B59 RID: 11097 RVA: 0x0018FE70 File Offset: 0x0018EE70
		private new int b()
		{
			int num = (this.b << 5 ^ (int)this.k[this.i + 2]) & 32767;
			short num2 = this.d[this.i & 32767] = this.c[num];
			this.c[num] = (short)this.i;
			this.b = num;
			return (int)num2 & 65535;
		}

		// Token: 0x06002B5A RID: 11098 RVA: 0x0018FEDC File Offset: 0x0018EEDC
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

		// Token: 0x06002B5B RID: 11099 RVA: 0x0018FFC0 File Offset: 0x0018EFC0
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
				this.x.hu(this.r, this.t, num);
				this.t += num;
				this.s += num;
				this.j += num;
			}
			if (this.j >= 3)
			{
				this.c();
			}
		}

		// Token: 0x06002B5C RID: 11100 RVA: 0x001900D0 File Offset: 0x0018F0D0
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

		// Token: 0x06002B5D RID: 11101 RVA: 0x00190388 File Offset: 0x0018F388
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
				if (num >= aay.v || (this.h < 32768 && num >= 32506) || A_0)
				{
					bool flag = A_1;
					if (num > aay.v)
					{
						num = aay.v;
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

		// Token: 0x06002B5E RID: 11102 RVA: 0x00190458 File Offset: 0x0018F458
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
					if (this.j >= 3 && (num = this.b()) != 0 && this.l != aaz.c && this.i - num <= 32506 && this.a(num))
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

		// Token: 0x06002B5F RID: 11103 RVA: 0x001906B8 File Offset: 0x0018F6B8
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
						if (this.l != aaz.c && num3 != 0 && this.i - num3 <= 32506 && this.a(num3))
						{
							if (this.f <= 5 && (this.l == aaz.b || (this.f == 3 && this.i - this.e > aa0.a)))
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

		// Token: 0x06002B60 RID: 11104 RVA: 0x001909DC File Offset: 0x0018F9DC
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

		// Token: 0x06002B61 RID: 11105 RVA: 0x00190A70 File Offset: 0x0018FA70
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

		// Token: 0x04001418 RID: 5144
		private new static int a = 4096;

		// Token: 0x04001419 RID: 5145
		private new int b;

		// Token: 0x0400141A RID: 5146
		private new short[] c;

		// Token: 0x0400141B RID: 5147
		private new short[] d;

		// Token: 0x0400141C RID: 5148
		private new int e;

		// Token: 0x0400141D RID: 5149
		private new int f;

		// Token: 0x0400141E RID: 5150
		private new bool g;

		// Token: 0x0400141F RID: 5151
		private new int h;

		// Token: 0x04001420 RID: 5152
		private new int i;

		// Token: 0x04001421 RID: 5153
		private new int j;

		// Token: 0x04001422 RID: 5154
		private new byte[] k;

		// Token: 0x04001423 RID: 5155
		private new aaz l;

		// Token: 0x04001424 RID: 5156
		private new int m;

		// Token: 0x04001425 RID: 5157
		private new int n;

		// Token: 0x04001426 RID: 5158
		private new int o;

		// Token: 0x04001427 RID: 5159
		private new int p;

		// Token: 0x04001428 RID: 5160
		private new int q;

		// Token: 0x04001429 RID: 5161
		private new byte[] r;

		// Token: 0x0400142A RID: 5162
		private new int s;

		// Token: 0x0400142B RID: 5163
		private new int t;

		// Token: 0x0400142C RID: 5164
		private new int u;

		// Token: 0x0400142D RID: 5165
		private new aa3 v;

		// Token: 0x0400142E RID: 5166
		private new aa1 w;

		// Token: 0x0400142F RID: 5167
		private new aaw x;
	}
}
