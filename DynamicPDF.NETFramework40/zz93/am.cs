using System;
using System.Collections;

namespace zz93
{
	// Token: 0x02000029 RID: 41
	internal class am
	{
		// Token: 0x0600019F RID: 415 RVA: 0x0002DC74 File Offset: 0x0002CC74
		internal am(string A_0, float A_1, float A_2)
		{
			this.i = A_0;
			this.g = A_1;
			this.f = A_2;
			int length = A_0.Length;
			if (length % 2 == 0)
			{
				this.j = A_0.ToCharArray();
			}
			else
			{
				this.j = new char[length + 1];
				this.j[0] = '0';
				Array.Copy(A_0.ToCharArray(), 0, this.j, 1, length);
			}
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x0002DD04 File Offset: 0x0002CD04
		internal char[] b()
		{
			return this.j;
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x0002DD1C File Offset: 0x0002CD1C
		internal float c()
		{
			return this.g;
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x0002DD34 File Offset: 0x0002CD34
		internal BitArray d()
		{
			this.a = new BitArray(this.a(), true);
			this.a(ref this.g);
			this.c(ref this.g);
			this.a(ref this.g);
			this.c(ref this.g);
			for (int i = 0; i < this.j.Length; i += 2)
			{
				this.a(ref this.g, (byte)(this.j[i] - '0'), (byte)(this.j[i + 1] - '0'));
			}
			this.b(ref this.g);
			this.c(ref this.g);
			this.a(ref this.g);
			return this.a;
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x0002DDFC File Offset: 0x0002CDFC
		internal float e()
		{
			return (float)this.a() * this.f;
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x0002DE1C File Offset: 0x0002CE1C
		private void a(ref float A_0, byte A_1, byte A_2)
		{
			if (A_1 > 9 || A_2 > 9)
			{
				throw new ap("Invalid Interleaved 2 of 5 character.");
			}
			int num = am.h[(int)A_1] * 2 + am.h[(int)A_2];
			for (int i = 512; i > 1; i /= 2)
			{
				if ((num & i) == i)
				{
					this.b(ref A_0);
				}
				else
				{
					this.a(ref A_0);
				}
				i /= 2;
				if ((num & i) == i)
				{
					this.d(ref A_0);
				}
				else
				{
					this.c(ref A_0);
				}
			}
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x0002DEBC File Offset: 0x0002CEBC
		private void d(ref float A_0)
		{
			A_0 += this.f * 3f;
			this.e = 3f;
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x0002DEDB File Offset: 0x0002CEDB
		private void c(ref float A_0)
		{
			A_0 += this.f;
			this.e = 1f;
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x0002DEF4 File Offset: 0x0002CEF4
		private void b(ref float A_0)
		{
			if (this.c)
			{
				for (int i = 0; i < 3; i++)
				{
					this.a[this.b] = false;
					this.b++;
				}
				A_0 += this.f * 3f;
				this.d = A_0;
				this.c = false;
			}
			else if (A_0 != this.d)
			{
				int num = 0;
				while ((float)num < this.e)
				{
					this.a[this.b] = true;
					this.b++;
					num++;
				}
				for (int i = 0; i < 3; i++)
				{
					this.a[this.b] = false;
					this.b++;
				}
				A_0 += this.f * 3f;
				this.d = A_0;
			}
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x0002E004 File Offset: 0x0002D004
		private void a(ref float A_0)
		{
			if (this.c)
			{
				this.a[this.b] = false;
				this.b++;
				A_0 += this.f;
				this.d = A_0;
				this.c = false;
			}
			else if (A_0 != this.d)
			{
				int num = 0;
				while ((float)num < this.e)
				{
					this.a[this.b] = true;
					this.b++;
					num++;
				}
				this.a[this.b] = false;
				this.b++;
				A_0 += this.f;
				this.d = A_0;
			}
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x0002E0E0 File Offset: 0x0002D0E0
		private int a()
		{
			int num = (this.i.Length + 1) / 2;
			return num * 18 + 9;
		}

		// Token: 0x04000121 RID: 289
		private BitArray a;

		// Token: 0x04000122 RID: 290
		private int b;

		// Token: 0x04000123 RID: 291
		private bool c = true;

		// Token: 0x04000124 RID: 292
		private float d;

		// Token: 0x04000125 RID: 293
		private float e;

		// Token: 0x04000126 RID: 294
		private float f = 1f;

		// Token: 0x04000127 RID: 295
		private float g;

		// Token: 0x04000128 RID: 296
		private static int[] h = new int[]
		{
			20,
			257,
			65,
			320,
			17,
			272,
			80,
			5,
			260,
			68
		};

		// Token: 0x04000129 RID: 297
		private string i;

		// Token: 0x0400012A RID: 298
		private char[] j;
	}
}
