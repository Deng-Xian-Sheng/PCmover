using System;

namespace zz93
{
	// Token: 0x020003C0 RID: 960
	internal class y4
	{
		// Token: 0x0600288B RID: 10379 RVA: 0x00177558 File Offset: 0x00176558
		internal static short c(int A_0)
		{
			return (short)((int)y4.j[A_0 & 15] << 12 | (int)y4.j[A_0 >> 4 & 15] << 8 | (int)y4.j[A_0 >> 8 & 15] << 4 | (int)y4.j[A_0 >> 12]);
		}

		// Token: 0x0600288C RID: 10380 RVA: 0x001775A4 File Offset: 0x001765A4
		static y4()
		{
			int i = 0;
			while (i < 144)
			{
				y4.s[i] = y4.c(48 + i << 8);
				y4.t[i++] = 8;
			}
			while (i < 256)
			{
				y4.s[i] = y4.c(256 + i << 7);
				y4.t[i++] = 9;
			}
			while (i < 280)
			{
				y4.s[i] = y4.c(-256 + i << 9);
				y4.t[i++] = 7;
			}
			while (i < y4.b)
			{
				y4.s[i] = y4.c(-88 + i << 8);
				y4.t[i++] = 8;
			}
			y4.u = new short[y4.c];
			y4.v = new byte[y4.c];
			for (i = 0; i < y4.c; i++)
			{
				y4.u[i] = y4.c(i << 11);
				y4.v[i] = 5;
			}
		}

		// Token: 0x0600288D RID: 10381 RVA: 0x00177750 File Offset: 0x00176750
		internal y4(y6 A_0)
		{
			this.k = A_0;
			this.l = new y4.a(this, y4.b, 257, 15);
			this.m = new y4.a(this, y4.c, 1, 15);
			this.n = new y4.a(this, y4.d, 4, 7);
			this.o = new short[y4.a];
			this.p = new byte[y4.a];
		}

		// Token: 0x0600288E RID: 10382 RVA: 0x001777CC File Offset: 0x001767CC
		internal void a()
		{
			this.q = 0;
			this.r = 0;
			this.l.a();
			this.m.a();
			this.n.a();
		}

		// Token: 0x0600288F RID: 10383 RVA: 0x00177804 File Offset: 0x00176804
		private int b(int A_0)
		{
			int result;
			if (A_0 == 255)
			{
				result = 285;
			}
			else
			{
				int num = 257;
				while (A_0 >= 8)
				{
					num += 4;
					A_0 >>= 1;
				}
				result = num + A_0;
			}
			return result;
		}

		// Token: 0x06002890 RID: 10384 RVA: 0x00177850 File Offset: 0x00176850
		private int a(int A_0)
		{
			int num = 0;
			while (A_0 >= 4)
			{
				num += 2;
				A_0 >>= 1;
			}
			return num + A_0;
		}

		// Token: 0x06002891 RID: 10385 RVA: 0x00177880 File Offset: 0x00176880
		internal void d(int A_0)
		{
			this.n.b();
			this.l.b();
			this.m.b();
			this.k.a(this.l.f - 257, 5);
			this.k.a(this.m.f - 1, 5);
			this.k.a(A_0 - 4, 4);
			for (int i = 0; i < A_0; i++)
			{
				this.k.a((int)this.n.c[y4.i[i]], 3);
			}
			this.l.b(this.n);
			this.m.b(this.n);
		}

		// Token: 0x06002892 RID: 10386 RVA: 0x00177950 File Offset: 0x00176950
		internal void b()
		{
			for (int i = 0; i < this.q; i++)
			{
				int num = (int)(this.p[i] & byte.MaxValue);
				int num2 = (int)this.o[i];
				if (num2-- != 0)
				{
					int num3 = this.b(num);
					this.l.a(num3);
					int num4 = (num3 - 261) / 4;
					if (num4 > 0 && num4 <= 5)
					{
						this.k.a(num & (1 << num4) - 1, num4);
					}
					int num5 = this.a(num2);
					this.m.a(num5);
					num4 = num5 / 2 - 1;
					if (num4 > 0)
					{
						this.k.a(num2 & (1 << num4) - 1, num4);
					}
				}
				else
				{
					this.l.a(num);
				}
			}
			this.l.a(y4.h);
		}

		// Token: 0x06002893 RID: 10387 RVA: 0x00177A64 File Offset: 0x00176A64
		internal void a(byte[] A_0, int A_1, int A_2, bool A_3)
		{
			this.k.a(A_3 ? 1 : 0, 3);
			this.k.c();
			this.k.a(A_2);
			this.k.a(~A_2);
			this.k.a(A_0, A_1, A_2);
			this.a();
		}

		// Token: 0x06002894 RID: 10388 RVA: 0x00177AC8 File Offset: 0x00176AC8
		internal void b(byte[] A_0, int A_1, int A_2, bool A_3)
		{
			short[] array = this.l.a;
			int num = y4.h;
			array[num] += 1;
			this.l.c();
			this.m.c();
			this.l.a(this.n);
			this.m.a(this.n);
			this.n.c();
			int num2 = 4;
			for (int i = 18; i > num2; i--)
			{
				if (this.n.c[y4.i[i]] > 0)
				{
					num2 = i + 1;
				}
			}
			int num3 = 14 + num2 * 3 + this.n.d() + this.l.d() + this.m.d() + this.r;
			int num4 = this.r;
			for (int i = 0; i < y4.b; i++)
			{
				num4 += (int)(this.l.a[i] * (short)y4.t[i]);
			}
			for (int i = 0; i < y4.c; i++)
			{
				num4 += (int)(this.m.a[i] * (short)y4.v[i]);
			}
			if (num3 >= num4)
			{
				num3 = num4;
			}
			if (A_1 >= 0 && A_2 + 4 < num3 >> 3)
			{
				this.a(A_0, A_1, A_2, A_3);
			}
			else if (num3 == num4)
			{
				this.k.a(2 + (A_3 ? 1 : 0), 3);
				this.l.a(y4.s, y4.t);
				this.m.a(y4.u, y4.v);
				this.b();
				this.a();
			}
			else
			{
				this.k.a(4 + (A_3 ? 1 : 0), 3);
				this.d(num2);
				this.b();
				this.a();
			}
		}

		// Token: 0x06002895 RID: 10389 RVA: 0x00177CE4 File Offset: 0x00176CE4
		internal bool c()
		{
			return this.q + 16 >= y4.a;
		}

		// Token: 0x06002896 RID: 10390 RVA: 0x00177D0C File Offset: 0x00176D0C
		internal bool e(int A_0)
		{
			this.o[this.q] = 0;
			this.p[this.q++] = (byte)A_0;
			short[] array = this.l.a;
			array[A_0] += 1;
			return this.c();
		}

		// Token: 0x06002897 RID: 10391 RVA: 0x00177D6C File Offset: 0x00176D6C
		internal bool a(int A_0, int A_1)
		{
			this.o[this.q] = (short)A_0;
			this.p[this.q++] = (byte)(A_1 - 3);
			int num = this.b(A_1 - 3);
			short[] array = this.l.a;
			int num2 = num;
			array[num2] += 1;
			if (num >= 265 && num < 285)
			{
				this.r += (num - 261) / 4;
			}
			int num3 = this.a(A_0 - 1);
			short[] array2 = this.m.a;
			int num4 = num3;
			array2[num4] += 1;
			if (num3 >= 4)
			{
				this.r += num3 / 2 - 1;
			}
			return this.c();
		}

		// Token: 0x04001209 RID: 4617
		private static int a = 16384;

		// Token: 0x0400120A RID: 4618
		private static int b = 286;

		// Token: 0x0400120B RID: 4619
		private static int c = 30;

		// Token: 0x0400120C RID: 4620
		private static int d = 19;

		// Token: 0x0400120D RID: 4621
		private static int e = 16;

		// Token: 0x0400120E RID: 4622
		private static int f = 17;

		// Token: 0x0400120F RID: 4623
		private static int g = 18;

		// Token: 0x04001210 RID: 4624
		private static int h = 256;

		// Token: 0x04001211 RID: 4625
		private static int[] i = new int[]
		{
			16,
			17,
			18,
			0,
			8,
			7,
			9,
			6,
			10,
			5,
			11,
			4,
			12,
			3,
			13,
			2,
			14,
			1,
			15
		};

		// Token: 0x04001212 RID: 4626
		private static byte[] j = new byte[]
		{
			0,
			8,
			4,
			12,
			2,
			10,
			6,
			14,
			1,
			9,
			5,
			13,
			3,
			11,
			7,
			15
		};

		// Token: 0x04001213 RID: 4627
		internal y6 k;

		// Token: 0x04001214 RID: 4628
		private y4.a l;

		// Token: 0x04001215 RID: 4629
		private y4.a m;

		// Token: 0x04001216 RID: 4630
		private y4.a n;

		// Token: 0x04001217 RID: 4631
		private short[] o;

		// Token: 0x04001218 RID: 4632
		private byte[] p;

		// Token: 0x04001219 RID: 4633
		private int q;

		// Token: 0x0400121A RID: 4634
		private int r;

		// Token: 0x0400121B RID: 4635
		private static short[] s = new short[y4.b];

		// Token: 0x0400121C RID: 4636
		private static byte[] t = new byte[y4.b];

		// Token: 0x0400121D RID: 4637
		private static short[] u;

		// Token: 0x0400121E RID: 4638
		private static byte[] v;

		// Token: 0x020003C1 RID: 961
		internal class a
		{
			// Token: 0x06002898 RID: 10392 RVA: 0x00177E54 File Offset: 0x00176E54
			internal a(y4 A_0, int A_1, int A_2, int A_3)
			{
				this.h = A_0;
				this.e = A_2;
				this.g = A_3;
				this.a = new short[A_1];
				this.d = new int[A_3];
			}

			// Token: 0x06002899 RID: 10393 RVA: 0x00177E90 File Offset: 0x00176E90
			internal void a()
			{
				for (int i = 0; i < this.a.Length; i++)
				{
					this.a[i] = 0;
				}
				this.b = null;
				this.c = null;
			}

			// Token: 0x0600289A RID: 10394 RVA: 0x00177ECE File Offset: 0x00176ECE
			internal void a(int A_0)
			{
				this.h.k.a((int)this.b[A_0] & 65535, (int)this.c[A_0]);
			}

			// Token: 0x0600289B RID: 10395 RVA: 0x00177EF8 File Offset: 0x00176EF8
			internal void a(short[] A_0, byte[] A_1)
			{
				this.b = A_0;
				this.c = A_1;
			}

			// Token: 0x0600289C RID: 10396 RVA: 0x00177F0C File Offset: 0x00176F0C
			internal void b()
			{
				int[] array = new int[this.g];
				int num = 0;
				this.b = new short[this.a.Length];
				for (int i = 0; i < this.g; i++)
				{
					array[i] = num;
					num += this.d[i] << 15 - i;
				}
				for (int j = 0; j < this.f; j++)
				{
					int i = (int)this.c[j];
					if (i > 0)
					{
						this.b[j] = y4.c(array[i - 1]);
						array[i - 1] += 1 << 16 - i;
					}
				}
			}

			// Token: 0x0600289D RID: 10397 RVA: 0x00177FCC File Offset: 0x00176FCC
			private void a(int[] A_0)
			{
				this.c = new byte[this.a.Length];
				int num = A_0.Length / 2;
				int num2 = (num + 1) / 2;
				int num3 = 0;
				for (int i = 0; i < this.g; i++)
				{
					this.d[i] = 0;
				}
				int[] array = new int[num];
				array[num - 1] = 0;
				for (int i = num - 1; i >= 0; i--)
				{
					if (A_0[2 * i + 1] != -1)
					{
						int num4 = array[i] + 1;
						if (num4 > this.g)
						{
							num4 = this.g;
							num3++;
						}
						array[A_0[2 * i]] = (array[A_0[2 * i + 1]] = num4);
					}
					else
					{
						int num4 = array[i];
						this.d[num4 - 1]++;
						this.c[A_0[2 * i]] = (byte)array[i];
					}
				}
				if (num3 != 0)
				{
					int num5 = this.g - 1;
					do
					{
						while (this.d[--num5] == 0)
						{
						}
						do
						{
							this.d[num5]--;
							this.d[++num5]++;
							num3 -= 1 << this.g - 1 - num5;
						}
						while (num3 > 0 && num5 < this.g - 1);
					}
					while (num3 > 0);
					this.d[this.g - 1] += num3;
					this.d[this.g - 2] -= num3;
					int num6 = 2 * num2;
					for (int num7 = this.g; num7 != 0; num7--)
					{
						int j = this.d[num7 - 1];
						while (j > 0)
						{
							int num8 = 2 * A_0[num6++];
							if (A_0[num8 + 1] == -1)
							{
								this.c[A_0[num8]] = (byte)num7;
								j--;
							}
						}
					}
				}
			}

			// Token: 0x0600289E RID: 10398 RVA: 0x0017823C File Offset: 0x0017723C
			internal void c()
			{
				int num = this.a.Length;
				int[] array = new int[num];
				int i = 0;
				int num2 = 0;
				for (int j = 0; j < num; j++)
				{
					int num3 = (int)this.a[j];
					if (num3 != 0)
					{
						int num4 = i++;
						int num5;
						while (num4 > 0 && (int)this.a[array[num5 = (num4 - 1) / 2]] > num3)
						{
							array[num4] = array[num5];
							num4 = num5;
						}
						array[num4] = j;
						num2 = j;
					}
				}
				while (i < 2)
				{
					int num6 = (num2 < 2) ? (++num2) : 0;
					array[i++] = num6;
				}
				this.f = Math.Max(num2 + 1, this.e);
				int num7 = i;
				int[] array2 = new int[4 * i - 2];
				int[] array3 = new int[2 * i - 1];
				int num8 = num7;
				for (int k = 0; k < i; k++)
				{
					int num6 = array[k];
					array2[2 * k] = num6;
					array2[2 * k + 1] = -1;
					array3[k] = (int)this.a[num6] << 8;
					array[k] = k;
				}
				do
				{
					int num9 = array[0];
					int num10 = array[--i];
					int num5 = 0;
					int l;
					for (l = 1; l < i; l = l * 2 + 1)
					{
						if (l + 1 < i && array3[array[l]] > array3[array[l + 1]])
						{
							l++;
						}
						array[num5] = array[l];
						num5 = l;
					}
					int num11 = array3[num10];
					while ((l = num5) > 0 && array3[array[num5 = (l - 1) / 2]] > num11)
					{
						array[l] = array[num5];
					}
					array[l] = num10;
					int num12 = array[0];
					num10 = num8++;
					array2[2 * num10] = num9;
					array2[2 * num10 + 1] = num12;
					int num13 = Math.Min(array3[num9] & 255, array3[num12] & 255);
					num11 = (array3[num10] = array3[num9] + array3[num12] - num13 + 1);
					num5 = 0;
					for (l = 1; l < i; l = num5 * 2 + 1)
					{
						if (l + 1 < i && array3[array[l]] > array3[array[l + 1]])
						{
							l++;
						}
						array[num5] = array[l];
						num5 = l;
					}
					while ((l = num5) > 0 && array3[array[num5 = (l - 1) / 2]] > num11)
					{
						array[l] = array[num5];
					}
					array[l] = num10;
				}
				while (i > 1);
				if (array[0] != array2.Length / 2 - 1)
				{
					throw new Exception("Weird!");
				}
				this.a(array2);
			}

			// Token: 0x0600289F RID: 10399 RVA: 0x00178530 File Offset: 0x00177530
			internal int d()
			{
				int num = 0;
				for (int i = 0; i < this.a.Length; i++)
				{
					num += (int)(this.a[i] * (short)this.c[i]);
				}
				return num;
			}

			// Token: 0x060028A0 RID: 10400 RVA: 0x00178574 File Offset: 0x00177574
			internal void a(y4.a A_0)
			{
				int num = -1;
				int i = 0;
				while (i < this.f)
				{
					int num2 = 1;
					int num3 = (int)this.c[i];
					int num4;
					int num5;
					if (num3 == 0)
					{
						num4 = 138;
						num5 = 3;
					}
					else
					{
						num4 = 6;
						num5 = 3;
						if (num != num3)
						{
							short[] array = A_0.a;
							int num6 = num3;
							array[num6] += 1;
							num2 = 0;
						}
					}
					num = num3;
					i++;
					while (i < this.f && num == (int)this.c[i])
					{
						i++;
						if (++num2 >= num4)
						{
							break;
						}
					}
					if (num2 < num5)
					{
						short[] array2 = A_0.a;
						int num7 = num;
						array2[num7] += (short)num2;
					}
					else if (num != 0)
					{
						short[] array3 = A_0.a;
						int num8 = y4.e;
						array3[num8] += 1;
					}
					else if (num2 <= 10)
					{
						short[] array4 = A_0.a;
						int num9 = y4.f;
						array4[num9] += 1;
					}
					else
					{
						short[] array5 = A_0.a;
						int num10 = y4.g;
						array5[num10] += 1;
					}
				}
			}

			// Token: 0x060028A1 RID: 10401 RVA: 0x001786E4 File Offset: 0x001776E4
			internal void b(y4.a A_0)
			{
				int num = -1;
				int i = 0;
				while (i < this.f)
				{
					int num2 = 1;
					int num3 = (int)this.c[i];
					int num4;
					int num5;
					if (num3 == 0)
					{
						num4 = 138;
						num5 = 3;
					}
					else
					{
						num4 = 6;
						num5 = 3;
						if (num != num3)
						{
							A_0.a(num3);
							num2 = 0;
						}
					}
					num = num3;
					i++;
					while (i < this.f && num == (int)this.c[i])
					{
						i++;
						if (++num2 >= num4)
						{
							break;
						}
					}
					if (num2 < num5)
					{
						while (num2-- > 0)
						{
							A_0.a(num);
						}
					}
					else if (num != 0)
					{
						A_0.a(y4.e);
						this.h.k.a(num2 - 3, 2);
					}
					else if (num2 <= 10)
					{
						A_0.a(y4.f);
						this.h.k.a(num2 - 3, 3);
					}
					else
					{
						A_0.a(y4.g);
						this.h.k.a(num2 - 11, 7);
					}
				}
			}

			// Token: 0x0400121F RID: 4639
			internal short[] a;

			// Token: 0x04001220 RID: 4640
			internal short[] b;

			// Token: 0x04001221 RID: 4641
			internal byte[] c;

			// Token: 0x04001222 RID: 4642
			internal int[] d;

			// Token: 0x04001223 RID: 4643
			internal int e;

			// Token: 0x04001224 RID: 4644
			internal int f;

			// Token: 0x04001225 RID: 4645
			internal int g;

			// Token: 0x04001226 RID: 4646
			private y4 h;
		}
	}
}
