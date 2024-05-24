using System;

namespace zz93
{
	// Token: 0x0200040A RID: 1034
	internal class aax
	{
		// Token: 0x06002B46 RID: 11078 RVA: 0x0018F5B8 File Offset: 0x0018E5B8
		internal aax() : this(aax.b, false)
		{
		}

		// Token: 0x06002B47 RID: 11079 RVA: 0x0018F5CC File Offset: 0x0018E5CC
		internal aax(int A_0, bool A_1)
		{
			if (A_0 == aax.b)
			{
				A_0 = 6;
			}
			else if (A_0 < aax.c || A_0 > aax.a)
			{
				throw new ArgumentOutOfRangeException("lvl");
			}
			this.r = new aa3();
			this.s = new aa0(this.r);
			this.o = A_1;
			this.a(aaz.a);
			this.a(A_0);
			this.a();
		}

		// Token: 0x06002B48 RID: 11080 RVA: 0x0018F659 File Offset: 0x0018E659
		internal void a()
		{
			this.p = (this.o ? aax.i : aax.h);
			this.q = 0;
			this.r.a();
			this.s.d();
		}

		// Token: 0x06002B49 RID: 11081 RVA: 0x0018F696 File Offset: 0x0018E696
		internal void b()
		{
			this.p |= (aax.f | aax.g);
		}

		// Token: 0x06002B4A RID: 11082 RVA: 0x0018F6B4 File Offset: 0x0018E6B4
		internal void a(byte[] A_0, int A_1, int A_2)
		{
			if ((this.p & aax.g) != 0)
			{
				throw new InvalidOperationException("finish()/end() already called");
			}
			this.s.a(A_0, A_1, A_2);
		}

		// Token: 0x06002B4B RID: 11083 RVA: 0x0018F6F0 File Offset: 0x0018E6F0
		internal void a(int A_0)
		{
			if (A_0 == aax.b)
			{
				A_0 = 6;
			}
			else if (A_0 < aax.c || A_0 > aax.a)
			{
				throw new ArgumentOutOfRangeException("lvl");
			}
			if (this.n != A_0)
			{
				this.n = A_0;
				this.s.b(A_0);
			}
		}

		// Token: 0x06002B4C RID: 11084 RVA: 0x0018F75E File Offset: 0x0018E75E
		internal void a(aaz A_0)
		{
			this.s.a(A_0);
		}

		// Token: 0x06002B4D RID: 11085 RVA: 0x0018F770 File Offset: 0x0018E770
		internal int a(byte[] A_0)
		{
			return this.b(A_0, 0, A_0.Length);
		}

		// Token: 0x06002B4E RID: 11086 RVA: 0x0018F790 File Offset: 0x0018E790
		internal int b(byte[] A_0, int A_1, int A_2)
		{
			int num = A_2;
			if (this.p == aax.m)
			{
				throw new InvalidOperationException("Deflater closed");
			}
			if (this.p < aax.i)
			{
				int num2 = aax.d + 112 << 8;
				int num3 = this.n - 1 >> 1;
				if (num3 < 0 || num3 > 3)
				{
					num3 = 3;
				}
				num2 |= num3 << 6;
				if ((this.p & aax.e) != 0)
				{
					num2 |= 32;
				}
				num2 += 31 - num2 % 31;
				this.r.b(num2);
				if ((this.p & aax.e) != 0)
				{
					int num4 = this.s.f();
					this.s.e();
					this.r.b(num4 >> 16);
					this.r.b(num4 & 65535);
				}
				this.p = (aax.i | (this.p & (aax.f | aax.g)));
			}
			for (;;)
			{
				int num5 = this.r.b(A_0, A_1, A_2);
				A_1 += num5;
				this.q += num5;
				A_2 -= num5;
				if (A_2 == 0 || this.p == aax.l)
				{
					break;
				}
				if (!this.s.d((this.p & aax.f) != 0, (this.p & aax.g) != 0))
				{
					if (this.p == aax.i)
					{
						goto Block_10;
					}
					if (this.p == aax.j)
					{
						if (this.n != aax.c)
						{
							for (int i = 8 + (-this.r.b() & 7); i > 0; i -= 10)
							{
								this.r.a(2, 10);
							}
						}
						this.p = aax.i;
					}
					else if (this.p == aax.k)
					{
						this.r.c();
						if (!this.o)
						{
							int num6 = this.s.f();
							this.r.b(num6 >> 16);
							this.r.b(num6 & 65535);
						}
						this.p = aax.l;
					}
				}
			}
			return num - A_2;
			Block_10:
			return num - A_2;
		}

		// Token: 0x040013E6 RID: 5094
		internal static int a = 9;

		// Token: 0x040013E7 RID: 5095
		internal static int b = -1;

		// Token: 0x040013E8 RID: 5096
		internal static int c = 0;

		// Token: 0x040013E9 RID: 5097
		internal static int d = 8;

		// Token: 0x040013EA RID: 5098
		private static int e = 1;

		// Token: 0x040013EB RID: 5099
		private static int f = 4;

		// Token: 0x040013EC RID: 5100
		private static int g = 8;

		// Token: 0x040013ED RID: 5101
		private static int h = 0;

		// Token: 0x040013EE RID: 5102
		private static int i = 16;

		// Token: 0x040013EF RID: 5103
		private static int j = 20;

		// Token: 0x040013F0 RID: 5104
		private static int k = 28;

		// Token: 0x040013F1 RID: 5105
		private static int l = 30;

		// Token: 0x040013F2 RID: 5106
		private static int m = 127;

		// Token: 0x040013F3 RID: 5107
		private int n;

		// Token: 0x040013F4 RID: 5108
		private bool o;

		// Token: 0x040013F5 RID: 5109
		private int p;

		// Token: 0x040013F6 RID: 5110
		private int q;

		// Token: 0x040013F7 RID: 5111
		private aa3 r;

		// Token: 0x040013F8 RID: 5112
		private aa0 s;
	}
}
