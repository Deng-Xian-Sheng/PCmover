using System;
using System.Collections;

namespace zz93
{
	// Token: 0x02000017 RID: 23
	internal class u
	{
		// Token: 0x060000E6 RID: 230 RVA: 0x0002092C File Offset: 0x0001F92C
		internal u()
		{
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x000209F4 File Offset: 0x0001F9F4
		internal u(byte[] A_0)
		{
			this.ag = A_0;
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00020AC4 File Offset: 0x0001FAC4
		internal byte[] b()
		{
			return this.ag;
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00020ADC File Offset: 0x0001FADC
		internal void i(byte[] A_0)
		{
			this.ag = A_0;
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00020AE8 File Offset: 0x0001FAE8
		internal int c()
		{
			return this.z;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00020B00 File Offset: 0x0001FB00
		internal void f(int A_0)
		{
			this.z = A_0;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00020B0C File Offset: 0x0001FB0C
		internal int d()
		{
			return this.b;
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00020B24 File Offset: 0x0001FB24
		internal void g(int A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00020B30 File Offset: 0x0001FB30
		internal int e()
		{
			return this.n;
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00020B48 File Offset: 0x0001FB48
		internal void h(int A_0)
		{
			this.n = A_0;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00020B52 File Offset: 0x0001FB52
		internal void i(int A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00020B5C File Offset: 0x0001FB5C
		internal int f()
		{
			return this.a;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00020B74 File Offset: 0x0001FB74
		internal int g()
		{
			return this.l;
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00020B8C File Offset: 0x0001FB8C
		internal void j(int A_0)
		{
			this.l = A_0;
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00020B98 File Offset: 0x0001FB98
		internal int h()
		{
			return this.m;
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00020BB0 File Offset: 0x0001FBB0
		internal void k(int A_0)
		{
			this.m = A_0;
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00020BBC File Offset: 0x0001FBBC
		internal bool i()
		{
			return this.c;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00020BD4 File Offset: 0x0001FBD4
		internal void a(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00020BDE File Offset: 0x0001FBDE
		internal void b(bool A_0)
		{
			this.ac = A_0;
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00020BE8 File Offset: 0x0001FBE8
		internal bool j()
		{
			if (this.n == 0)
			{
				this.aa = new int[4];
				this.n();
				this.ad = false;
				if (this.m != 4)
				{
					this.m();
				}
				this.a(this.ag, this.f());
				if (this.z > 16)
				{
					throw new ao("Total number of symbols cannot exceed 16. Try increasing the symbol size.");
				}
				this.x = (byte[])this.y[this.n];
				this.ac = true;
				if (this.z >= 2)
				{
					if (this.m == 0 || this.m == 1 || this.m == 2)
					{
						throw new an("Structured append is not possible with Function Character " + this.m.ToString());
					}
					this.aa[0] = 233;
					this.aa[1] = this.a(this.n + 1, this.z);
				}
				if (this.z == 1 && this.f() == 9)
				{
					this.ac = false;
					this.y = new ArrayList();
					this.b = 1;
				}
				this.n++;
			}
			bool result;
			if (this.z >= 2 && this.n <= this.z)
			{
				this.x = (byte[])this.y[this.n - 1];
				result = (this.z >= 2 && this.n < this.z);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00020DC0 File Offset: 0x0001FDC0
		internal int k()
		{
			this.ad = true;
			int num2;
			int num3;
			if (this.l != 0)
			{
				int num = this.l;
				num2 = (int)this.h[num - 1];
				num3 = (int)this.f[num - 1, 0];
			}
			else
			{
				int num = 24;
				this.s = (int)this.g[num - 1, 1];
				this.t = (int)this.g[num - 1, 0];
				if (this.m != 4)
				{
					this.m();
				}
				this.ac = false;
				this.a(this.ag, this.f());
				num = this.l(this.d.a());
				num2 = (int)this.h[num - 1];
				num3 = (int)this.f[num - 1, 0];
				this.b = 1;
			}
			int num4 = num2;
			int result;
			switch (num4)
			{
			case 1:
				result = num3 + 2;
				goto IL_11A;
			case 2:
				result = num3 + 2;
				goto IL_11A;
			case 3:
				break;
			case 4:
				result = num3 + 4;
				goto IL_11A;
			default:
				if (num4 == 16)
				{
					result = num3 + 8;
					goto IL_11A;
				}
				break;
			}
			result = num3 + 12;
			IL_11A:
			this.d = new i();
			return result;
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00020EFC File Offset: 0x0001FEFC
		internal int l()
		{
			this.ad = true;
			int num2;
			int num3;
			if (this.l != 0)
			{
				int num = this.l;
				num2 = (int)this.h[num - 1];
				num3 = (int)this.f[num - 1, 1];
			}
			else
			{
				int num = 24;
				this.s = (int)this.g[num - 1, 1];
				this.t = (int)this.g[num - 1, 0];
				if (this.m != 4)
				{
					this.m();
				}
				this.ac = false;
				this.a(this.ag, this.f());
				num = this.l(this.d.a());
				num2 = (int)this.h[num - 1];
				num3 = (int)this.f[num - 1, 1];
				this.b = 1;
			}
			int num4 = num2;
			int result;
			switch (num4)
			{
			case 1:
				result = num3 + 2;
				goto IL_11A;
			case 2:
				result = num3 + 4;
				goto IL_11A;
			case 3:
				break;
			case 4:
				result = num3 + 4;
				goto IL_11A;
			default:
				if (num4 == 16)
				{
					result = num3 + 8;
					goto IL_11A;
				}
				break;
			}
			result = num3 + 12;
			IL_11A:
			this.d = new i();
			return result;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00021038 File Offset: 0x00020038
		internal BitArray j(byte[] A_0)
		{
			this.d = new i();
			byte[] array = new byte[2178];
			int num = 0;
			if (!this.ac)
			{
				if (this.h() != 4)
				{
					this.m();
				}
				this.ab = false;
				this.a(A_0, this.f());
				this.x = new byte[this.d.a()];
				Array.Copy(this.d.a, this.x, this.d.a());
			}
			if (this.g() == 0)
			{
				this.r = this.l(this.x.Length);
				this.u = (int)this.i[this.r - 1];
				this.v = (int)this.h[this.r - 1];
				this.s = (int)this.g[this.r - 1, 1];
				this.t = (int)this.g[this.r - 1, 0];
				this.w[0] = (int)this.f[this.r - 1, 0];
				this.w[1] = (int)this.f[this.r - 1, 1];
			}
			else
			{
				if (this.g() < this.l(this.x.Length))
				{
					throw new ao("Symbol size is not sufficient to draw all the data. Please increase the symbol size or manage the barcode's overflow.");
				}
				this.r = this.g();
				this.u = (int)this.i[this.r - 1];
				this.v = (int)this.h[this.r - 1];
				this.s = (int)this.g[this.r - 1, 1];
				this.t = (int)this.g[this.r - 1, 0];
				this.w[0] = (int)this.f[this.r - 1, 0];
				this.w[1] = (int)this.f[this.r - 1, 1];
			}
			if (this.ac)
			{
				num = 0;
				if (this.z > 1)
				{
					array[num] = (byte)this.aa[0];
					num++;
					array[num] = (byte)this.aa[1];
					num++;
					array[num] = (byte)this.aa[2];
					num++;
					array[num] = (byte)this.aa[3];
					num++;
				}
			}
			Array.Copy(this.x, 0, array, num, this.x.Length);
			num += this.x.Length;
			if (this.t != num)
			{
				this.a(this.t - num, ref array, ref num);
			}
			int num2 = 0;
			short[] array2 = new short[this.s + this.t + 1];
			Array.Copy(array, array2, num);
			if (this.u == 1)
			{
				short[] array3 = this.a(array2, this.t, this.s, 256, 301);
				for (int i = this.t; i < this.t + this.s; i++)
				{
					array[num] = (byte)array3[i];
					num++;
				}
			}
			else if (this.u != 10)
			{
				for (int i = 0; i < this.u; i++)
				{
					short[] array4 = new short[this.t / this.u + this.s / this.u + 1];
					int num3 = 0;
					for (int j = i; j < this.t; j += this.u)
					{
						array4[num3++] = (short)array[j];
					}
					short[] sourceArray = this.a(array4, this.t / this.u, this.s / this.u, 256, 301);
					Array.Copy(sourceArray, this.t / this.u, this.e, num2, this.s / this.u);
					num2 += this.s / this.u;
				}
				for (int k = 0; k < this.s / this.u; k++)
				{
					for (int i = k; i < this.s; i += this.s / this.u)
					{
						array[num] = (byte)this.e[i];
						num++;
					}
				}
			}
			else if (this.u == 10)
			{
				for (int i = 0; i < this.u; i++)
				{
					if (i < 8)
					{
						short[] array4 = new short[this.t / this.u + this.s / this.u + 2];
						int num3 = 0;
						for (int j = i; j < this.t; j += this.u)
						{
							array4[num3++] = (short)array[j];
						}
						short[] sourceArray = this.a(array4, this.t / this.u + 1, this.s / this.u, 256, 301);
						Array.Copy(sourceArray, this.t / this.u + 1, this.e, num2, this.s / this.u);
						num2 += this.s / this.u;
					}
					else
					{
						short[] array4 = new short[this.t / this.u + this.s / this.u + 1];
						int num3 = 0;
						for (int j = i; j < this.t; j += this.u)
						{
							array4[num3++] = (short)array[j];
						}
						short[] sourceArray = this.a(array4, this.t / this.u, this.s / this.u, 256, 301);
						Array.Copy(sourceArray, this.t / this.u, this.e, num2, this.s / this.u);
						num2 += this.s / this.u;
					}
				}
				for (int k = 0; k < this.s / this.u; k++)
				{
					for (int i = k; i < this.s; i += this.s / this.u)
					{
						array[num] = (byte)this.e[i];
						num++;
					}
				}
			}
			return this.a(this.w[0], this.w[1], array, this.v);
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00021764 File Offset: 0x00020764
		internal void a(byte[] A_0, int A_1)
		{
			switch (A_1)
			{
			case 0:
				this.b(A_0);
				break;
			case 1:
			case 2:
			case 3:
				this.h(A_0);
				break;
			case 4:
				this.g(A_0);
				break;
			case 5:
				this.f(A_0);
				break;
			case 6:
				this.e(A_0);
				break;
			case 7:
				this.c(A_0);
				break;
			case 8:
				this.d(A_0);
				break;
			case 9:
				this.a(A_0, true);
				break;
			}
		}

		// Token: 0x060000FE RID: 254 RVA: 0x000217F8 File Offset: 0x000207F8
		internal void m()
		{
			switch (this.h())
			{
			case 0:
				this.d.a(236);
				break;
			case 1:
				this.d.a(237);
				break;
			case 2:
				this.d.a(234);
				break;
			case 3:
				this.d.a(232);
				break;
			}
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00021874 File Offset: 0x00020874
		internal int a(int A_0, int A_1)
		{
			A_0--;
			A_1 = 17 - A_1;
			int num = A_0 << 4;
			return num | A_1;
		}

		// Token: 0x06000100 RID: 256 RVA: 0x0002189C File Offset: 0x0002089C
		internal void n()
		{
			if (this.g() != 0)
			{
				this.r = this.g();
				this.u = (int)this.i[this.r - 1];
				this.v = (int)this.h[this.r - 1];
				this.s = (int)this.g[this.r - 1, 1];
				this.t = (int)this.g[this.r - 1, 0];
				this.w[0] = (int)this.f[this.r - 1, 0];
				this.w[1] = (int)this.f[this.r - 1, 1];
			}
			else
			{
				this.r = 24;
				this.u = (int)this.i[this.r - 1];
				this.v = (int)this.h[this.r - 1];
				this.s = (int)this.g[this.r - 1, 1];
				this.t = (int)this.g[this.r - 1, 0];
				this.w[0] = (int)this.f[this.r - 1, 0];
				this.w[1] = (int)this.f[this.r - 1, 1];
			}
			if (this.f() != 0)
			{
				this.z++;
				this.ab = true;
			}
			this.aa[0] = 233;
			Random random = new Random();
			this.aa[2] = random.Next(1, 254);
			this.aa[3] = random.Next(1, 254);
			this.ac = true;
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00021A6C File Offset: 0x00020A6C
		internal int l(int A_0)
		{
			int i;
			for (i = 0; i < A_0; i++)
			{
				if (A_0 <= (int)this.g[i, 0])
				{
					break;
				}
			}
			return i + 1;
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00021AAC File Offset: 0x00020AAC
		private void a(int A_0, int A_1, int A_2, int A_3)
		{
			if (A_0 < 0)
			{
				A_0 += this.o;
				A_1 += 4 - (this.o + 4) % 8;
			}
			if (A_1 < 0)
			{
				A_1 += this.p;
				A_0 += 4 - (this.p + 4) % 8;
			}
			this.q[A_0 * this.p + A_1] = 10 * A_2 + A_3;
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00021B20 File Offset: 0x00020B20
		private void a(int A_0, int A_1, int A_2)
		{
			this.a(A_0 - 2, A_1 - 2, A_2, 1);
			this.a(A_0 - 2, A_1 - 1, A_2, 2);
			this.a(A_0 - 1, A_1 - 2, A_2, 3);
			this.a(A_0 - 1, A_1 - 1, A_2, 4);
			this.a(A_0 - 1, A_1, A_2, 5);
			this.a(A_0, A_1 - 2, A_2, 6);
			this.a(A_0, A_1 - 1, A_2, 7);
			this.a(A_0, A_1, A_2, 8);
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00021B9C File Offset: 0x00020B9C
		private void e(int A_0)
		{
			this.a(this.o - 1, 0, A_0, 1);
			this.a(this.o - 1, 1, A_0, 2);
			this.a(this.o - 1, 2, A_0, 3);
			this.a(0, this.p - 2, A_0, 4);
			this.a(0, this.p - 1, A_0, 5);
			this.a(1, this.p - 1, A_0, 6);
			this.a(2, this.p - 1, A_0, 7);
			this.a(3, this.p - 1, A_0, 8);
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00021C3C File Offset: 0x00020C3C
		private void d(int A_0)
		{
			this.a(this.o - 3, 0, A_0, 1);
			this.a(this.o - 2, 0, A_0, 2);
			this.a(this.o - 1, 0, A_0, 3);
			this.a(0, this.p - 4, A_0, 4);
			this.a(0, this.p - 3, A_0, 5);
			this.a(0, this.p - 2, A_0, 6);
			this.a(0, this.p - 1, A_0, 7);
			this.a(1, this.p - 1, A_0, 8);
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00021CDC File Offset: 0x00020CDC
		private void c(int A_0)
		{
			this.a(this.o - 3, 0, A_0, 1);
			this.a(this.o - 2, 0, A_0, 2);
			this.a(this.o - 1, 0, A_0, 3);
			this.a(0, this.p - 2, A_0, 4);
			this.a(0, this.p - 1, A_0, 5);
			this.a(1, this.p - 1, A_0, 6);
			this.a(2, this.p - 1, A_0, 7);
			this.a(3, this.p - 1, A_0, 8);
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00021D7C File Offset: 0x00020D7C
		private void b(int A_0)
		{
			this.a(this.o - 1, 0, A_0, 1);
			this.a(this.o - 1, this.p - 1, A_0, 2);
			this.a(0, this.p - 3, A_0, 3);
			this.a(0, this.p - 2, A_0, 4);
			this.a(0, this.p - 1, A_0, 5);
			this.a(1, this.p - 3, A_0, 6);
			this.a(1, this.p - 2, A_0, 7);
			this.a(1, this.p - 1, A_0, 8);
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00021E24 File Offset: 0x00020E24
		private void a()
		{
			int i;
			int j;
			for (i = 0; i < this.o; i++)
			{
				for (j = 0; j < this.p; j++)
				{
					this.q[i * this.p + j] = 0;
				}
			}
			int num = 1;
			i = 4;
			j = 0;
			do
			{
				if (i == this.o && j == 0)
				{
					this.e(num++);
				}
				if (i == this.o - 2 && j == 0 && this.p % 4 != 0)
				{
					this.d(num++);
				}
				if (i == this.o - 2 && j == 0 && this.p % 8 == 4)
				{
					this.c(num++);
				}
				if (i == this.o + 4 && j == 2 && this.p % 8 == 0)
				{
					this.b(num++);
				}
				do
				{
					if (i < this.o && j >= 0 && this.q[i * this.p + j] == 0)
					{
						this.a(i, j, num++);
					}
					i -= 2;
					j += 2;
				}
				while (i >= 0 && j < this.p);
				i++;
				j += 3;
				do
				{
					if (i >= 0 && j < this.p && this.q[i * this.p + j] == 0)
					{
						this.a(i, j, num++);
					}
					i += 2;
					j -= 2;
				}
				while (i < this.o && j >= 0);
				i += 3;
				j++;
			}
			while (i < this.o || j < this.p);
			if (this.q[this.o * this.p - 1] == 0)
			{
				this.q[this.o * this.p - 1] = (this.q[this.o * this.p - this.p - 2] = 1);
			}
		}

		// Token: 0x06000109 RID: 265 RVA: 0x0002206C File Offset: 0x0002106C
		private BitArray a(int A_0, int A_1, byte[] A_2, int A_3)
		{
			this.o = (this.p = 0);
			int num = 0;
			int num2 = 0;
			int num3;
			int num4;
			switch (A_3)
			{
			case 1:
				this.ae = A_0 + 2;
				this.af = A_1 + 2;
				num3 = A_0;
				num4 = A_1;
				goto IL_E4;
			case 2:
				this.ae = A_0 + 2;
				this.af = A_1 + 4;
				num3 = A_0;
				num4 = A_1 / 2;
				num2 = 2;
				goto IL_E4;
			case 3:
				break;
			case 4:
				this.ae = A_0 + 4;
				this.af = A_1 + 4;
				num3 = A_0 / 2;
				num4 = A_1 / 2;
				num2 = 2;
				goto IL_E4;
			default:
				if (A_3 == 16)
				{
					this.ae = A_0 + 8;
					this.af = A_1 + 8;
					num3 = A_0 / 4;
					num4 = A_1 / 4;
					num2 = 4;
					goto IL_E4;
				}
				break;
			}
			this.ae = A_0 + 12;
			this.af = A_1 + 12;
			num3 = A_0 / 6;
			num4 = A_1 / 6;
			num2 = 6;
			IL_E4:
			BitArray bitArray = new BitArray(this.af * this.ae, true);
			this.o = A_0;
			this.p = A_1;
			for (int i = 1; i <= this.af; i++)
			{
				if (i % 2 != 0)
				{
					bitArray[num] = false;
					num++;
				}
				else
				{
					bitArray[num] = true;
					num++;
				}
			}
			if (this.o >= 6 && (~this.o & 1) != 0 && this.p >= 6 && (~this.p & 1) != 0)
			{
				this.q = new int[this.o * this.p];
				this.a();
				int num5 = 1;
				for (int j = 0; j < this.o; j++)
				{
					int num6 = 1;
					bitArray[num] = false;
					num++;
					for (int k = 0; k < this.p; k++)
					{
						int num7 = this.q[j * this.p + k];
						if (num7 == 0)
						{
							bitArray[num] = true;
							num++;
						}
						else if (num7 == 1)
						{
							bitArray[num] = false;
							num++;
						}
						else
						{
							int num8 = num7 / 10;
							int num9 = num7 % 10;
							num9 = 8 - num9 + 1;
							num9 = (int)Math.Pow(2.0, (double)num9);
							num9 /= 2;
							if (((int)A_2[num8 - 1] & num9) != 0)
							{
								bitArray[num] = false;
								num++;
							}
							else
							{
								bitArray[num] = true;
								num++;
							}
						}
						if (this.af == this.ae)
						{
							if (num6 < num2)
							{
								if (k == num4 * num6 - 1)
								{
									if ((j + 1) % 2 == 0)
									{
										bitArray[num] = true;
										num++;
									}
									else
									{
										bitArray[num] = false;
										num++;
									}
									bitArray[num] = false;
									num++;
									num6++;
								}
							}
						}
						else if (num2 > 1)
						{
							if (k == num4 - 1)
							{
								if ((j + 1) % 2 == 0)
								{
									bitArray[num] = true;
									num++;
								}
								else
								{
									bitArray[num] = false;
									num++;
								}
								bitArray[num] = false;
								num++;
							}
						}
					}
					if ((j + 1) % 2 == 0)
					{
						bitArray[num] = true;
						num++;
					}
					else
					{
						bitArray[num] = false;
						num++;
					}
					if (this.ae == this.af)
					{
						if (num5 < num2)
						{
							if (j == num3 * num5 - 1)
							{
								for (int i = 1; i <= this.af; i++)
								{
									bitArray[num] = false;
									num++;
								}
								for (int i = 1; i <= this.af; i++)
								{
									if (i % 2 != 0)
									{
										bitArray[num] = false;
										num++;
									}
									else
									{
										bitArray[num] = true;
										num++;
									}
								}
								num5++;
							}
						}
					}
				}
				for (int i = 1; i <= this.af; i++)
				{
					bitArray[num] = false;
					num++;
				}
			}
			return bitArray;
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00022550 File Offset: 0x00021550
		private void h(byte[] A_0)
		{
			if (this.d() != 1)
			{
				this.a(this.d());
				this.g(1);
			}
			t t = new t(this.t, this.ac, this.ab, this.ad);
			t.a(this.y);
			t.b(this.z);
			this.d = t.a(A_0, this.c, this.d);
			this.y = t.f();
			this.z = t.a();
			this.g(t.b());
		}

		// Token: 0x0600010B RID: 267 RVA: 0x000225F8 File Offset: 0x000215F8
		private void g(byte[] A_0)
		{
			if (this.d() != 1)
			{
				this.a(this.d());
				this.g(1);
			}
			x x = new x(this.t, this.ac, this.ab, this.ad);
			x.a(this.y);
			x.b(this.z);
			this.d = x.a(A_0, this.c, this.d);
			this.y = x.f();
			this.z = x.a();
			this.g(x.b());
		}

		// Token: 0x0600010C RID: 268 RVA: 0x000226A0 File Offset: 0x000216A0
		private void f(byte[] A_0)
		{
			w w = new w(this.t, this.ac, this.ab, this.d(), this.ad);
			w.a(this.y);
			w.b(this.z);
			this.d = w.a(A_0, this.c, this.d);
			this.y = w.f();
			this.z = w.a();
			this.g(w.b());
		}

		// Token: 0x0600010D RID: 269 RVA: 0x0002272C File Offset: 0x0002172C
		private void e(byte[] A_0)
		{
			z z = new z(this.t, this.ac, this.ab, this.b, this.ad);
			z.a(this.y);
			z.b(this.z);
			this.d = z.a(A_0, this.c, this.d);
			this.y = z.f();
			this.z = z.a();
			this.g(z.b());
		}

		// Token: 0x0600010E RID: 270 RVA: 0x000227B8 File Offset: 0x000217B8
		private void a(byte[] A_0, bool A_1)
		{
			v v = new v(this.t, this.ac, this.ab, this.d(), this.ad);
			v.a(this.y);
			v.b(this.z);
			this.d = v.a(A_0, A_1, this.c, this.d, this.h());
			this.y = v.f();
			this.z = v.a();
			this.g(v.b());
		}

		// Token: 0x0600010F RID: 271 RVA: 0x0002284C File Offset: 0x0002184C
		private void d(byte[] A_0)
		{
			y y = new y(this.t, this.ac, this.ab, this.d(), this.ad);
			y.a(this.y);
			y.b(this.z);
			this.d = y.a(A_0, this.c, this.d);
			this.y = y.f();
			this.z = y.a();
			this.g(y.b());
		}

		// Token: 0x06000110 RID: 272 RVA: 0x000228D8 File Offset: 0x000218D8
		private void c(byte[] A_0)
		{
			s s = new s(this.t, this.ac, this.ab, this.d(), this.ad);
			s.a(this.y);
			s.b(this.z);
			this.d = s.a(A_0, this.c, this.d);
			this.y = s.f();
			this.z = s.a();
			this.g(s.b());
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00022964 File Offset: 0x00021964
		private void b(byte[] A_0)
		{
			if (A_0.Length < 4)
			{
				this.a(A_0, 1);
			}
			else
			{
				int i = 0;
				int num = 0;
				if (A_0[0] > 47 && A_0[0] < 58 && A_0[1] > 47 && A_0[1] < 58)
				{
					int num2 = (int)(A_0[0] - 48);
					num2 *= 10;
					num2 += (int)(A_0[1] - 48);
					this.d.a((byte)(num2 + 130));
					i = 2;
					num = 2;
				}
				this.g(1);
				int num3;
				if (i == 0)
				{
					num3 = A_0.Length;
				}
				else
				{
					num3 = A_0.Length - i;
				}
				if (num3 < 4)
				{
					byte[] array = new byte[num3];
					for (int j = 0; j < num3; j++)
					{
						array[j] = A_0[j + i];
					}
					this.a(array, 1);
				}
				else
				{
					int num4 = num3 % 4;
					if (num4 != 0)
					{
						num3 -= num4;
					}
					while (i < num3)
					{
						int num5 = -1;
						if (this.c)
						{
							if (A_0[i] == 126)
							{
								num5 = 0;
							}
							else if (A_0[i + 1] == 126)
							{
								num5 = 1;
							}
							else if (A_0[i + 2] == 126)
							{
								num5 = 2;
							}
							else if (A_0[i + 3] == 126)
							{
								num5 = 3;
							}
							if (num5 >= 0)
							{
								if (num5 <= 2 && A_0[i + num5 + 1] == 49)
								{
									byte[] array2 = new byte[4];
									for (int j = 0; j < 4; j++)
									{
										array2[j] = A_0[i + j];
									}
									this.a(array2, 1);
									i += 3;
									goto IL_3F8;
								}
								if (num5 >= 3 && A_0[i + num5 + 1] == 49)
								{
									byte[] array2 = new byte[5];
									for (int j = 0; j < 5; j++)
									{
										array2[j] = A_0[i + j];
									}
									this.a(array2, 1);
									int num6 = i + 5;
									int num7 = num3 - num6 + num4;
									array2 = new byte[num7];
									Array.Copy(A_0, num6, array2, 0, num7);
									this.b(array2);
									return;
								}
								if (num5 <= 3 && A_0[i + num5 + 1] == 50 && i + num5 + 7 <= A_0.Length)
								{
									byte[] array2 = new byte[num5 + 8];
									for (int j = 0; j < array2.Length; j++)
									{
										array2[j] = A_0[i + j];
									}
									this.a(array2, 1);
									int num6 = i + num5 + 8;
									int num7 = num3 - num6 + num4;
									if (num7 > 0)
									{
										array2 = new byte[num7];
										Array.Copy(A_0, num6, array2, 0, num7);
										this.b(array2);
									}
									else if (num7 == 0 && !this.ab)
									{
										short[] array3 = new short[this.d.a()];
										Array.Copy(this.d.a, 0, array3, 0, this.d.a());
										if (this.y == null)
										{
											this.y = new ArrayList();
										}
										this.y.Add(array3);
										this.z++;
									}
									return;
								}
							}
							goto IL_3B3;
						}
						goto IL_3B3;
						IL_3F8:
						i++;
						continue;
						IL_3B3:
						byte[] array4 = new byte[4];
						for (int j = 0; j < 4; j++)
						{
							array4[j] = A_0[i + j];
						}
						int a_ = this.a(array4);
						this.a(array4, a_);
						i += 3;
						goto IL_3F8;
					}
					if (num4 >= 1)
					{
						byte[] array = new byte[num4];
						for (int j = 0; j < num4; j++)
						{
							array[j] = A_0[num3 + j + num];
						}
						this.a(array, 1);
					}
				}
			}
			if (!this.ab)
			{
				byte[] array5 = new byte[this.d.a()];
				Array.Copy(this.d.a, 0, array5, 0, this.d.a());
				if (this.y == null)
				{
					this.y = new ArrayList();
				}
				this.y.Add(array5);
				this.z++;
			}
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00022E40 File Offset: 0x00021E40
		private int a(byte[] A_0)
		{
			decimal num = 0m;
			decimal num2 = 0m;
			decimal num3 = 0m;
			decimal num4 = 0m;
			decimal num5 = 0m;
			decimal num6 = 0m;
			switch (this.b)
			{
			case 1:
				num = 0m;
				num2 = 1m;
				num3 = 1m;
				num4 = 1m;
				num5 = 1m;
				num6 = 2.25m;
				break;
			case 5:
				num = 1m;
				num2 = 0m;
				num3 = 1m;
				num4 = 1m;
				num5 = 1m;
				num6 = 2.25m;
				break;
			case 6:
				num = 1m;
				num2 = 1m;
				num3 = 0m;
				num4 = 1m;
				num5 = 1m;
				num6 = 2.25m;
				break;
			case 7:
				num = 1m;
				num2 = 1m;
				num3 = 1m;
				num4 = 0m;
				num5 = 1m;
				num6 = 2.25m;
				break;
			case 8:
				num = 1m;
				num2 = 1m;
				num3 = 1m;
				num4 = 1m;
				num5 = 0m;
				num6 = 2.25m;
				break;
			case 9:
				num = 1m;
				num2 = 1m;
				num3 = 1m;
				num4 = 1m;
				num5 = 1m;
				num6 = 0m;
				break;
			}
			for (int i = 0; i < A_0.Length; i++)
			{
				num6 = ++num6;
				if (A_0[i] >= 48 && A_0[i] <= 57)
				{
					num += 0.5m;
				}
				else if (A_0[i] > 127)
				{
					num = Math.Round(num);
					num += 2m;
				}
				else
				{
					num = Math.Round(num);
					num = ++num;
				}
				if (zz93.u.j.IndexOf((char)A_0[i]) >= 0)
				{
					num2 += 0.6666666666666666666666666667m;
				}
				else if (A_0[i] > 127)
				{
					num2 += 2.6666666666666666666666666667m;
				}
				else
				{
					num2 += 1.3333333333333333333333333333m;
				}
				if (zz93.u.k.IndexOf((char)A_0[i]) >= 0)
				{
					num3 += 0.6666666666666666666666666667m;
				}
				else if (A_0[i] > 127)
				{
					num3 += 2.6666666666666666666666666667m;
				}
				else
				{
					num3 += 1.3333333333333333333333333333m;
				}
				if ((A_0[i] >= 65 && A_0[i] <= 90) || (A_0[i] >= 48 && A_0[i] <= 57) || A_0[i] == 32 || A_0[i] == 13 || A_0[i] == 42 || A_0[i] == 62)
				{
					num4 += 0.6666666666666666666666666667m;
				}
				else if (A_0[i] > 127)
				{
					num4 += 4.3333333333333333333333333333m;
				}
				else
				{
					num4 += 3.3333333333333333333333333333m;
				}
				if (A_0[i] >= 32 && A_0[i] <= 94)
				{
					num5 += 0.75m;
				}
				else if (A_0[i] > 127)
				{
					num5 += 4.25m;
				}
				else
				{
					num5 += 3.25m;
				}
			}
			num = ++num;
			int result;
			if (num <= num6 && num <= num2 && num <= num3 && num <= num5 && num < num4)
			{
				result = 1;
			}
			else
			{
				num6 = ++num6;
				if (num6 <= num && num6 < num2 && num6 < num3 && num6 < num5 && num6 < num4)
				{
					result = 9;
				}
				else
				{
					num5 = ++num5;
					if (num5 < num && num5 < num2 && num5 < num3 && num5 < num6 && num5 < num4)
					{
						result = 8;
					}
					else
					{
						num3 = ++num3;
						if (num3 < num && num3 < num2 && num3 < num6 && num3 < num5 && num3 < num4)
						{
							result = 6;
						}
						else
						{
							num4 = ++num4;
							if (num4 < num && num4 < num2 && num4 < num3 && num4 < num5 && num4 < num6)
							{
								result = 7;
							}
							else
							{
								num2 = ++num2;
								if (num2 < num && num2 < num6 && num2 < num5 && num2 < num3 && num2 <= num4)
								{
									result = 5;
								}
								else
								{
									result = 1;
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06000113 RID: 275 RVA: 0x000234A8 File Offset: 0x000224A8
		private void a(int A_0, ref byte[] A_1, ref int A_2)
		{
			if (A_0 > 0)
			{
				A_1[A_2] = 129;
				A_2++;
				for (int i = 0; i < A_0 - 1; i++)
				{
					int num = 149 * (A_2 + 1) % 253 + 1;
					int num2 = 129 + num;
					if (num2 <= 254)
					{
						A_1[A_2] = (byte)num2;
						A_2++;
					}
					else
					{
						A_1[A_2] = (byte)(num2 - 254);
						A_2++;
					}
				}
			}
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00023534 File Offset: 0x00022534
		private void a(int A_0)
		{
			switch (A_0)
			{
			case 1:
			case 2:
			case 4:
			case 9:
				this.g(1);
				break;
			case 5:
			case 6:
			case 7:
				this.d.a(254);
				this.g(1);
				break;
			case 8:
				this.d.a(124);
				this.g(1);
				break;
			}
		}

		// Token: 0x06000115 RID: 277 RVA: 0x000235B0 File Offset: 0x000225B0
		private int a(int A_0, int A_1, ref int[] A_2, ref int[] A_3, int A_4)
		{
			int result;
			if (!Convert.ToBoolean(A_0) || !Convert.ToBoolean(A_1))
			{
				result = 0;
			}
			else
			{
				result = A_3[(A_2[A_0] + A_2[A_1]) % (A_4 - 1)];
			}
			return result;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x000235F0 File Offset: 0x000225F0
		private short[] a(short[] A_0, int A_1, int A_2, int A_3, int A_4)
		{
			int[] array = new int[A_3];
			int[] array2 = new int[A_3];
			array[0] = 1 - A_3;
			array2[0] = 1;
			for (int i = 1; i < A_3; i++)
			{
				array2[i] = array2[i - 1] * 2;
				if (array2[i] >= A_3)
				{
					array2[i] ^= A_4;
				}
				array[array2[i]] = i;
			}
			int[] array3 = new int[A_2 + 1];
			for (int i = 1; i <= A_2; i++)
			{
				array3[i] = 0;
			}
			array3[0] = 1;
			for (int i = 1; i <= A_2; i++)
			{
				array3[i] = array3[i - 1];
				for (int j = i - 1; j >= 1; j--)
				{
					array3[j] = (array3[j - 1] ^ this.a(array3[j], array2[i], ref array, ref array2, A_3));
				}
				array3[0] = this.a(array3[0], array2[i], ref array, ref array2, A_3);
			}
			for (int i = A_1; i < A_1 + A_2; i++)
			{
				A_0[i] = 0;
			}
			for (int i = 0; i < A_1; i++)
			{
				int a_ = (int)(A_0[A_1] ^ A_0[i]);
				for (int j = 0; j < A_2; j++)
				{
					A_0[A_1 + j] = (short)((int)A_0[A_1 + j + 1] ^ this.a(a_, array3[A_2 - j - 1], ref array, ref array2, A_3));
				}
			}
			return A_0;
		}

		// Token: 0x0400008C RID: 140
		private int a;

		// Token: 0x0400008D RID: 141
		private int b = 1;

		// Token: 0x0400008E RID: 142
		private bool c;

		// Token: 0x0400008F RID: 143
		internal i d = new i();

		// Token: 0x04000090 RID: 144
		private short[] e = new short[620];

		// Token: 0x04000091 RID: 145
		internal byte[,] f = new byte[,]
		{
			{
				8,
				8
			},
			{
				10,
				10
			},
			{
				12,
				12
			},
			{
				14,
				14
			},
			{
				16,
				16
			},
			{
				18,
				18
			},
			{
				20,
				20
			},
			{
				22,
				22
			},
			{
				24,
				24
			},
			{
				28,
				28
			},
			{
				32,
				32
			},
			{
				36,
				36
			},
			{
				40,
				40
			},
			{
				44,
				44
			},
			{
				48,
				48
			},
			{
				56,
				56
			},
			{
				64,
				64
			},
			{
				72,
				72
			},
			{
				80,
				80
			},
			{
				88,
				88
			},
			{
				96,
				96
			},
			{
				108,
				108
			},
			{
				120,
				120
			},
			{
				132,
				132
			},
			{
				6,
				16
			},
			{
				6,
				28
			},
			{
				10,
				24
			},
			{
				10,
				32
			},
			{
				14,
				32
			},
			{
				14,
				44
			}
		};

		// Token: 0x04000092 RID: 146
		internal short[,] g = new short[,]
		{
			{
				3,
				5
			},
			{
				5,
				7
			},
			{
				8,
				10
			},
			{
				12,
				12
			},
			{
				18,
				14
			},
			{
				22,
				18
			},
			{
				30,
				20
			},
			{
				36,
				24
			},
			{
				44,
				28
			},
			{
				62,
				36
			},
			{
				86,
				42
			},
			{
				114,
				48
			},
			{
				144,
				56
			},
			{
				174,
				68
			},
			{
				204,
				84
			},
			{
				280,
				112
			},
			{
				368,
				144
			},
			{
				456,
				192
			},
			{
				576,
				224
			},
			{
				696,
				272
			},
			{
				816,
				336
			},
			{
				1050,
				408
			},
			{
				1304,
				496
			},
			{
				1558,
				620
			},
			{
				5,
				7
			},
			{
				10,
				11
			},
			{
				16,
				14
			},
			{
				22,
				18
			},
			{
				32,
				24
			},
			{
				49,
				28
			}
		};

		// Token: 0x04000093 RID: 147
		internal byte[] h = new byte[]
		{
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			4,
			4,
			4,
			4,
			4,
			4,
			16,
			16,
			16,
			16,
			16,
			16,
			36,
			36,
			36,
			1,
			2,
			1,
			2,
			2,
			2
		};

		// Token: 0x04000094 RID: 148
		internal byte[] i = new byte[]
		{
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			2,
			2,
			4,
			4,
			4,
			4,
			6,
			6,
			8,
			10,
			1,
			1,
			1,
			1,
			1,
			1
		};

		// Token: 0x04000095 RID: 149
		private static string j = " 0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

		// Token: 0x04000096 RID: 150
		private static string k = " 0123456789abcdefghijklmnopqrstuvwxyz";

		// Token: 0x04000097 RID: 151
		private int l;

		// Token: 0x04000098 RID: 152
		private int m = 4;

		// Token: 0x04000099 RID: 153
		private int n;

		// Token: 0x0400009A RID: 154
		private int o;

		// Token: 0x0400009B RID: 155
		private int p;

		// Token: 0x0400009C RID: 156
		private int[] q;

		// Token: 0x0400009D RID: 157
		private int r;

		// Token: 0x0400009E RID: 158
		private int s;

		// Token: 0x0400009F RID: 159
		private int t;

		// Token: 0x040000A0 RID: 160
		private int u = 1;

		// Token: 0x040000A1 RID: 161
		private int v = 1;

		// Token: 0x040000A2 RID: 162
		private int[] w = new int[2];

		// Token: 0x040000A3 RID: 163
		internal byte[] x;

		// Token: 0x040000A4 RID: 164
		internal ArrayList y;

		// Token: 0x040000A5 RID: 165
		private int z;

		// Token: 0x040000A6 RID: 166
		internal int[] aa = new int[0];

		// Token: 0x040000A7 RID: 167
		private bool ab;

		// Token: 0x040000A8 RID: 168
		private bool ac;

		// Token: 0x040000A9 RID: 169
		private bool ad;

		// Token: 0x040000AA RID: 170
		internal int ae;

		// Token: 0x040000AB RID: 171
		internal int af;

		// Token: 0x040000AC RID: 172
		private byte[] ag;
	}
}
