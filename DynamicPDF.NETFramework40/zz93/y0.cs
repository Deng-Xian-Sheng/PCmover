using System;
using System.IO;

namespace zz93
{
	// Token: 0x020003BC RID: 956
	internal class y0
	{
		// Token: 0x06002868 RID: 10344 RVA: 0x00175C80 File Offset: 0x00174C80
		internal y0() : this(y0.b, false)
		{
		}

		// Token: 0x06002869 RID: 10345 RVA: 0x00175C91 File Offset: 0x00174C91
		internal y0(int A_0) : this(A_0, false)
		{
		}

		// Token: 0x0600286A RID: 10346 RVA: 0x00175CA0 File Offset: 0x00174CA0
		internal y0(int A_0, bool A_1)
		{
			if (A_0 == y0.b)
			{
				A_0 = 6;
			}
			else if (A_0 < y0.c || A_0 > y0.a)
			{
				throw new ArgumentOutOfRangeException("lvl");
			}
			this.r = new y6();
			this.s = new y3(this.r);
			this.o = A_1;
			this.a(y2.a);
			this.a(A_0);
			this.a();
		}

		// Token: 0x0600286B RID: 10347 RVA: 0x00175D2D File Offset: 0x00174D2D
		internal void a()
		{
			this.p = (this.o ? y0.i : y0.h);
			this.q = 0;
			this.r.a();
			this.s.d();
		}

		// Token: 0x0600286C RID: 10348 RVA: 0x00175D6A File Offset: 0x00174D6A
		internal void b()
		{
			this.p |= (y0.f | y0.g);
		}

		// Token: 0x0600286D RID: 10349 RVA: 0x00175D88 File Offset: 0x00174D88
		internal bool c()
		{
			return this.p == y0.l && this.r.d();
		}

		// Token: 0x0600286E RID: 10350 RVA: 0x00175DB8 File Offset: 0x00174DB8
		internal bool d()
		{
			return this.s.h();
		}

		// Token: 0x0600286F RID: 10351 RVA: 0x00175DD8 File Offset: 0x00174DD8
		internal void b(byte[] A_0, int A_1, int A_2)
		{
			if ((this.p & y0.g) != 0)
			{
				throw new InvalidOperationException("finish()/end() already called");
			}
			this.s.a(A_0, A_1, A_2);
		}

		// Token: 0x06002870 RID: 10352 RVA: 0x00175E14 File Offset: 0x00174E14
		internal void a(int A_0)
		{
			if (A_0 == y0.b)
			{
				A_0 = 6;
			}
			else if (A_0 < y0.c || A_0 > y0.a)
			{
				throw new ArgumentOutOfRangeException("lvl");
			}
			if (this.n != A_0)
			{
				this.n = A_0;
				this.s.b(A_0);
			}
		}

		// Token: 0x06002871 RID: 10353 RVA: 0x00175E82 File Offset: 0x00174E82
		internal void a(y2 A_0)
		{
			this.s.a(A_0);
		}

		// Token: 0x06002872 RID: 10354 RVA: 0x00175E94 File Offset: 0x00174E94
		internal static byte[] a(byte[] A_0, int A_1, int A_2)
		{
			y0 y = new y0();
			y.b(A_0, A_1, A_2);
			y.b();
			byte[] array = new byte[(int)((float)A_2 * 1.002f + 12f)];
			int num = y.a(array);
			A_0 = new byte[num];
			Array.Copy(array, 0, A_0, 0, num);
			return A_0;
		}

		// Token: 0x06002873 RID: 10355 RVA: 0x00175EF0 File Offset: 0x00174EF0
		internal int a(byte[] A_0)
		{
			return this.c(A_0, 0, A_0.Length);
		}

		// Token: 0x06002874 RID: 10356 RVA: 0x00175F10 File Offset: 0x00174F10
		internal int c(byte[] A_0, int A_1, int A_2)
		{
			int num = A_2;
			if (this.p == y0.m)
			{
				throw new InvalidOperationException("Deflater closed");
			}
			if (this.p < y0.i)
			{
				int num2 = y0.d + 112 << 8;
				int num3 = this.n - 1 >> 1;
				if (num3 < 0 || num3 > 3)
				{
					num3 = 3;
				}
				num2 |= num3 << 6;
				if ((this.p & y0.e) != 0)
				{
					num2 |= 32;
				}
				num2 += 31 - num2 % 31;
				this.r.b(num2);
				if ((this.p & y0.e) != 0)
				{
					int num4 = this.s.f();
					this.s.e();
					this.r.b(num4 >> 16);
					this.r.b(num4 & 65535);
				}
				this.p = (y0.i | (this.p & (y0.f | y0.g)));
			}
			for (;;)
			{
				int num5 = this.r.b(A_0, A_1, A_2);
				A_1 += num5;
				this.q += num5;
				A_2 -= num5;
				if (A_2 == 0 || this.p == y0.l)
				{
					break;
				}
				if (!this.s.d((this.p & y0.f) != 0, (this.p & y0.g) != 0))
				{
					if (this.p == y0.i)
					{
						goto Block_10;
					}
					if (this.p == y0.j)
					{
						if (this.n != y0.c)
						{
							for (int i = 8 + (-this.r.b() & 7); i > 0; i -= 10)
							{
								this.r.a(2, 10);
							}
						}
						this.p = y0.i;
					}
					else if (this.p == y0.k)
					{
						this.r.c();
						if (!this.o)
						{
							int num6 = this.s.f();
							this.r.b(num6 >> 16);
							this.r.b(num6 & 65535);
						}
						this.p = y0.l;
					}
				}
			}
			return num - A_2;
			Block_10:
			return num - A_2;
		}

		// Token: 0x06002875 RID: 10357 RVA: 0x001761D8 File Offset: 0x001751D8
		internal int a(Stream A_0)
		{
			int num = 0;
			int num2 = int.MaxValue;
			int num3 = num2;
			if (this.p == y0.m)
			{
				throw new InvalidOperationException("Deflater closed");
			}
			if (this.p < y0.i)
			{
				int num4 = y0.d + 112 << 8;
				int num5 = this.n - 1 >> 1;
				if (num5 < 0 || num5 > 3)
				{
					num5 = 3;
				}
				num4 |= num5 << 6;
				if ((this.p & y0.e) != 0)
				{
					num4 |= 32;
				}
				num4 += 31 - num4 % 31;
				this.r.b(num4);
				if ((this.p & y0.e) != 0)
				{
					int num6 = this.s.f();
					this.s.e();
					this.r.b(num6 >> 16);
					this.r.b(num6 & 65535);
				}
				this.p = (y0.i | (this.p & (y0.f | y0.g)));
			}
			for (;;)
			{
				int num7 = this.r.a(A_0, num2);
				num += num7;
				this.q += num7;
				num2 -= num7;
				if (num2 == 0 || this.p == y0.l)
				{
					break;
				}
				if (!this.s.d((this.p & y0.f) != 0, (this.p & y0.g) != 0))
				{
					if (this.p == y0.i)
					{
						goto Block_10;
					}
					if (this.p == y0.j)
					{
						if (this.n != y0.c)
						{
							for (int i = 8 + (-this.r.b() & 7); i > 0; i -= 10)
							{
								this.r.a(2, 10);
							}
						}
						this.p = y0.i;
					}
					else if (this.p == y0.k)
					{
						this.r.c();
						if (!this.o)
						{
							int num8 = this.s.f();
							this.r.b(num8 >> 16);
							this.r.b(num8 & 65535);
						}
						this.p = y0.l;
					}
				}
			}
			return num3 - num2;
			Block_10:
			return num3 - num2;
		}

		// Token: 0x040011BF RID: 4543
		internal static int a = 9;

		// Token: 0x040011C0 RID: 4544
		internal static int b = -1;

		// Token: 0x040011C1 RID: 4545
		internal static int c = 0;

		// Token: 0x040011C2 RID: 4546
		internal static int d = 8;

		// Token: 0x040011C3 RID: 4547
		private static int e = 1;

		// Token: 0x040011C4 RID: 4548
		private static int f = 4;

		// Token: 0x040011C5 RID: 4549
		private static int g = 8;

		// Token: 0x040011C6 RID: 4550
		private static int h = 0;

		// Token: 0x040011C7 RID: 4551
		private static int i = 16;

		// Token: 0x040011C8 RID: 4552
		private static int j = 20;

		// Token: 0x040011C9 RID: 4553
		private static int k = 28;

		// Token: 0x040011CA RID: 4554
		private static int l = 30;

		// Token: 0x040011CB RID: 4555
		private static int m = 127;

		// Token: 0x040011CC RID: 4556
		private int n;

		// Token: 0x040011CD RID: 4557
		private bool o;

		// Token: 0x040011CE RID: 4558
		private int p;

		// Token: 0x040011CF RID: 4559
		private int q;

		// Token: 0x040011D0 RID: 4560
		private y6 r;

		// Token: 0x040011D1 RID: 4561
		private y3 s;
	}
}
