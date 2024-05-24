using System;

namespace zz93
{
	// Token: 0x0200040E RID: 1038
	internal class aa1
	{
		// Token: 0x06002B63 RID: 11107 RVA: 0x00190AE4 File Offset: 0x0018FAE4
		internal static short c(int A_0)
		{
			return (short)((int)aa1.j[A_0 & 15] << 12 | (int)aa1.j[A_0 >> 4 & 15] << 8 | (int)aa1.j[A_0 >> 8 & 15] << 4 | (int)aa1.j[A_0 >> 12]);
		}

		// Token: 0x06002B64 RID: 11108 RVA: 0x00190B30 File Offset: 0x0018FB30
		static aa1()
		{
			int i = 0;
			while (i < 144)
			{
				aa1.s[i] = aa1.c(48 + i << 8);
				aa1.t[i++] = 8;
			}
			while (i < 256)
			{
				aa1.s[i] = aa1.c(256 + i << 7);
				aa1.t[i++] = 9;
			}
			while (i < 280)
			{
				aa1.s[i] = aa1.c(-256 + i << 9);
				aa1.t[i++] = 7;
			}
			while (i < aa1.b)
			{
				aa1.s[i] = aa1.c(-88 + i << 8);
				aa1.t[i++] = 8;
			}
			aa1.u = new short[aa1.c];
			aa1.v = new byte[aa1.c];
			for (i = 0; i < aa1.c; i++)
			{
				aa1.u[i] = aa1.c(i << 11);
				aa1.v[i] = 5;
			}
		}

		// Token: 0x06002B65 RID: 11109 RVA: 0x00190CDC File Offset: 0x0018FCDC
		internal aa1(aa3 A_0)
		{
			this.k = A_0;
			this.l = new aa1.a(this, aa1.b, 257, 15);
			this.m = new aa1.a(this, aa1.c, 1, 15);
			this.n = new aa1.a(this, aa1.d, 4, 7);
			this.o = new short[aa1.a];
			this.p = new byte[aa1.a];
		}

		// Token: 0x06002B66 RID: 11110 RVA: 0x00190D58 File Offset: 0x0018FD58
		internal void a()
		{
			this.q = 0;
			this.r = 0;
			this.l.a();
			this.m.a();
			this.n.a();
		}

		// Token: 0x06002B67 RID: 11111 RVA: 0x00190D90 File Offset: 0x0018FD90
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

		// Token: 0x06002B68 RID: 11112 RVA: 0x00190DDC File Offset: 0x0018FDDC
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

		// Token: 0x06002B69 RID: 11113 RVA: 0x00190E0C File Offset: 0x0018FE0C
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
				this.k.a((int)this.n.c[aa1.i[i]], 3);
			}
			this.l.b(this.n);
			this.m.b(this.n);
		}

		// Token: 0x06002B6A RID: 11114 RVA: 0x00190EDC File Offset: 0x0018FEDC
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
			this.l.a(aa1.h);
		}

		// Token: 0x06002B6B RID: 11115 RVA: 0x00190FF0 File Offset: 0x0018FFF0
		internal void a(byte[] A_0, int A_1, int A_2, bool A_3)
		{
			this.k.a(A_3 ? 1 : 0, 3);
			this.k.c();
			this.k.a(A_2);
			this.k.a(~A_2);
			this.k.a(A_0, A_1, A_2);
			this.a();
		}

		// Token: 0x06002B6C RID: 11116 RVA: 0x00191054 File Offset: 0x00190054
		internal void b(byte[] A_0, int A_1, int A_2, bool A_3)
		{
			short[] array = this.l.a;
			int num = aa1.h;
			array[num] += 1;
			this.l.c();
			this.m.c();
			this.l.a(this.n);
			this.m.a(this.n);
			this.n.c();
			int num2 = 4;
			for (int i = 18; i > num2; i--)
			{
				if (this.n.c[aa1.i[i]] > 0)
				{
					num2 = i + 1;
				}
			}
			int num3 = 14 + num2 * 3 + this.n.d() + this.l.d() + this.m.d() + this.r;
			int num4 = this.r;
			for (int i = 0; i < aa1.b; i++)
			{
				num4 += (int)(this.l.a[i] * (short)aa1.t[i]);
			}
			for (int i = 0; i < aa1.c; i++)
			{
				num4 += (int)(this.m.a[i] * (short)aa1.v[i]);
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
				this.l.a(aa1.s, aa1.t);
				this.m.a(aa1.u, aa1.v);
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

		// Token: 0x06002B6D RID: 11117 RVA: 0x00191270 File Offset: 0x00190270
		internal bool c()
		{
			return this.q + 16 >= aa1.a;
		}

		// Token: 0x06002B6E RID: 11118 RVA: 0x00191298 File Offset: 0x00190298
		internal bool e(int A_0)
		{
			this.o[this.q] = 0;
			this.p[this.q++] = (byte)A_0;
			short[] array = this.l.a;
			array[A_0] += 1;
			return this.c();
		}

		// Token: 0x06002B6F RID: 11119 RVA: 0x001912F8 File Offset: 0x001902F8
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

		// Token: 0x04001430 RID: 5168
		private static int a = 16384;

		// Token: 0x04001431 RID: 5169
		private static int b = 286;

		// Token: 0x04001432 RID: 5170
		private static int c = 30;

		// Token: 0x04001433 RID: 5171
		private static int d = 19;

		// Token: 0x04001434 RID: 5172
		private static int e = 16;

		// Token: 0x04001435 RID: 5173
		private static int f = 17;

		// Token: 0x04001436 RID: 5174
		private static int g = 18;

		// Token: 0x04001437 RID: 5175
		private static int h = 256;

		// Token: 0x04001438 RID: 5176
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

		// Token: 0x04001439 RID: 5177
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

		// Token: 0x0400143A RID: 5178
		internal aa3 k;

		// Token: 0x0400143B RID: 5179
		private aa1.a l;

		// Token: 0x0400143C RID: 5180
		private aa1.a m;

		// Token: 0x0400143D RID: 5181
		private aa1.a n;

		// Token: 0x0400143E RID: 5182
		private short[] o;

		// Token: 0x0400143F RID: 5183
		private byte[] p;

		// Token: 0x04001440 RID: 5184
		private int q;

		// Token: 0x04001441 RID: 5185
		private int r;

		// Token: 0x04001442 RID: 5186
		private static short[] s = new short[aa1.b];

		// Token: 0x04001443 RID: 5187
		private static byte[] t = new byte[aa1.b];

		// Token: 0x04001444 RID: 5188
		private static short[] u;

		// Token: 0x04001445 RID: 5189
		private static byte[] v;

		// Token: 0x0200040F RID: 1039
		internal class a
		{
			// Token: 0x06002B70 RID: 11120 RVA: 0x001913E0 File Offset: 0x001903E0
			internal a(aa1 A_0, int A_1, int A_2, int A_3)
			{
				this.h = A_0;
				this.e = A_2;
				this.g = A_3;
				this.a = new short[A_1];
				this.d = new int[A_3];
			}

			// Token: 0x06002B71 RID: 11121 RVA: 0x0019141C File Offset: 0x0019041C
			internal void a()
			{
				for (int i = 0; i < this.a.Length; i++)
				{
					this.a[i] = 0;
				}
				this.b = null;
				this.c = null;
			}

			// Token: 0x06002B72 RID: 11122 RVA: 0x0019145A File Offset: 0x0019045A
			internal void a(int A_0)
			{
				this.h.k.a((int)this.b[A_0] & 65535, (int)this.c[A_0]);
			}

			// Token: 0x06002B73 RID: 11123 RVA: 0x00191484 File Offset: 0x00190484
			internal void a(short[] A_0, byte[] A_1)
			{
				this.b = A_0;
				this.c = A_1;
			}

			// Token: 0x06002B74 RID: 11124 RVA: 0x00191498 File Offset: 0x00190498
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
						this.b[j] = aa1.c(array[i - 1]);
						array[i - 1] += 1 << 16 - i;
					}
				}
			}

			// Token: 0x06002B75 RID: 11125 RVA: 0x00191558 File Offset: 0x00190558
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

			// Token: 0x06002B76 RID: 11126 RVA: 0x001917C8 File Offset: 0x001907C8
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

			// Token: 0x06002B77 RID: 11127 RVA: 0x00191ABC File Offset: 0x00190ABC
			internal int d()
			{
				int num = 0;
				for (int i = 0; i < this.a.Length; i++)
				{
					num += (int)(this.a[i] * (short)this.c[i]);
				}
				return num;
			}

			// Token: 0x06002B78 RID: 11128 RVA: 0x00191B00 File Offset: 0x00190B00
			internal void a(aa1.a A_0)
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
						int num8 = aa1.e;
						array3[num8] += 1;
					}
					else if (num2 <= 10)
					{
						short[] array4 = A_0.a;
						int num9 = aa1.f;
						array4[num9] += 1;
					}
					else
					{
						short[] array5 = A_0.a;
						int num10 = aa1.g;
						array5[num10] += 1;
					}
				}
			}

			// Token: 0x06002B79 RID: 11129 RVA: 0x00191C70 File Offset: 0x00190C70
			internal void b(aa1.a A_0)
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
						A_0.a(aa1.e);
						this.h.k.a(num2 - 3, 2);
					}
					else if (num2 <= 10)
					{
						A_0.a(aa1.f);
						this.h.k.a(num2 - 3, 3);
					}
					else
					{
						A_0.a(aa1.g);
						this.h.k.a(num2 - 11, 7);
					}
				}
			}

			// Token: 0x04001446 RID: 5190
			internal short[] a;

			// Token: 0x04001447 RID: 5191
			internal short[] b;

			// Token: 0x04001448 RID: 5192
			internal byte[] c;

			// Token: 0x04001449 RID: 5193
			internal int[] d;

			// Token: 0x0400144A RID: 5194
			internal int e;

			// Token: 0x0400144B RID: 5195
			internal int f;

			// Token: 0x0400144C RID: 5196
			internal int g;

			// Token: 0x0400144D RID: 5197
			private aa1 h;
		}
	}
}
