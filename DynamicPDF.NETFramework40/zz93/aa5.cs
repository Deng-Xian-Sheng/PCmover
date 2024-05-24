using System;

namespace zz93
{
	// Token: 0x02000413 RID: 1043
	internal class aa5
	{
		// Token: 0x06002B91 RID: 11153 RVA: 0x00192A59 File Offset: 0x00191A59
		internal aa5()
		{
		}

		// Token: 0x06002B92 RID: 11154 RVA: 0x00192A64 File Offset: 0x00191A64
		internal bool a(aa8 A_0)
		{
			for (;;)
			{
				for (;;)
				{
					switch (this.l)
					{
					case 0:
						goto IL_33;
					case 1:
						goto IL_7E;
					case 2:
						goto IL_E9;
					case 3:
						goto IL_144;
					case 4:
						goto IL_1CD;
					case 5:
						goto IL_28D;
					}
				}
				IL_28D:
				int a_ = aa5.h[this.q];
				int num = A_0.a(a_);
				if (num < 0)
				{
					goto Block_11;
				}
				A_0.b(a_);
				num += aa5.g[this.q];
				if (this.s + num > this.p)
				{
					goto Block_12;
				}
				while (num-- > 0)
				{
					this.j[this.s++] = this.r;
				}
				if (this.s == this.p)
				{
					goto Block_14;
				}
				this.l = 4;
				continue;
				IL_1CD:
				int num2;
				while (((num2 = this.k.a(A_0)) & -16) == 0)
				{
					this.j[this.s++] = (this.r = (byte)num2);
					if (this.s == this.p)
					{
						goto Block_6;
					}
				}
				if (num2 < 0)
				{
					goto Block_8;
				}
				if (num2 >= 17)
				{
					this.r = 0;
				}
				else if (this.s == 0)
				{
					goto Block_10;
				}
				this.q = num2 - 16;
				this.l = 5;
				goto IL_28D;
				IL_144:
				while (this.s < this.o)
				{
					int num3 = A_0.a(3);
					if (num3 < 0)
					{
						goto Block_4;
					}
					A_0.b(3);
					this.i[aa5.t[this.s]] = (byte)num3;
					this.s++;
				}
				this.k = new aa6(this.i);
				this.i = null;
				this.s = 0;
				this.l = 4;
				goto IL_1CD;
				IL_E9:
				this.o = A_0.a(4);
				if (this.o < 0)
				{
					goto Block_3;
				}
				this.o += 4;
				A_0.b(4);
				this.i = new byte[19];
				this.s = 0;
				this.l = 3;
				goto IL_144;
				IL_7E:
				this.n = A_0.a(5);
				if (this.n < 0)
				{
					goto Block_2;
				}
				this.n++;
				A_0.b(5);
				this.p = this.m + this.n;
				this.j = new byte[this.p];
				this.l = 2;
				goto IL_E9;
				IL_33:
				this.m = A_0.a(5);
				if (this.m < 0)
				{
					break;
				}
				this.m += 257;
				A_0.b(5);
				this.l = 1;
				goto IL_7E;
			}
			return false;
			Block_2:
			return false;
			Block_3:
			return false;
			Block_4:
			return false;
			Block_6:
			return true;
			Block_8:
			return false;
			Block_10:
			throw new Exception();
			Block_11:
			return false;
			Block_12:
			throw new Exception();
			Block_14:
			return true;
		}

		// Token: 0x06002B93 RID: 11155 RVA: 0x00192DC8 File Offset: 0x00191DC8
		internal aa6 a()
		{
			byte[] array = new byte[this.m];
			Array.Copy(this.j, 0, array, 0, this.m);
			return new aa6(array);
		}

		// Token: 0x06002B94 RID: 11156 RVA: 0x00192E04 File Offset: 0x00191E04
		internal aa6 b()
		{
			byte[] array = new byte[this.n];
			Array.Copy(this.j, this.m, array, 0, this.n);
			return new aa6(array);
		}

		// Token: 0x04001474 RID: 5236
		private const int a = 0;

		// Token: 0x04001475 RID: 5237
		private const int b = 1;

		// Token: 0x04001476 RID: 5238
		private const int c = 2;

		// Token: 0x04001477 RID: 5239
		private const int d = 3;

		// Token: 0x04001478 RID: 5240
		private const int e = 4;

		// Token: 0x04001479 RID: 5241
		private const int f = 5;

		// Token: 0x0400147A RID: 5242
		private static readonly int[] g = new int[]
		{
			3,
			3,
			11
		};

		// Token: 0x0400147B RID: 5243
		private static readonly int[] h = new int[]
		{
			2,
			3,
			7
		};

		// Token: 0x0400147C RID: 5244
		private byte[] i;

		// Token: 0x0400147D RID: 5245
		private byte[] j;

		// Token: 0x0400147E RID: 5246
		private aa6 k;

		// Token: 0x0400147F RID: 5247
		private int l;

		// Token: 0x04001480 RID: 5248
		private int m;

		// Token: 0x04001481 RID: 5249
		private int n;

		// Token: 0x04001482 RID: 5250
		private int o;

		// Token: 0x04001483 RID: 5251
		private int p;

		// Token: 0x04001484 RID: 5252
		private int q;

		// Token: 0x04001485 RID: 5253
		private byte r;

		// Token: 0x04001486 RID: 5254
		private int s;

		// Token: 0x04001487 RID: 5255
		private static readonly int[] t = new int[]
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
	}
}
