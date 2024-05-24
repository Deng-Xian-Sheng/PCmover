using System;

namespace zz93
{
	// Token: 0x020003C8 RID: 968
	internal class zb
	{
		// Token: 0x060028D4 RID: 10452 RVA: 0x0017A27D File Offset: 0x0017927D
		internal zb()
		{
		}

		// Token: 0x060028D5 RID: 10453 RVA: 0x0017A288 File Offset: 0x00179288
		internal bool a(zg A_0)
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
				int a_ = zb.h[this.q];
				int num = A_0.a(a_);
				if (num < 0)
				{
					goto Block_11;
				}
				A_0.b(a_);
				num += zb.g[this.q];
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
					this.i[zb.t[this.s]] = (byte)num3;
					this.s++;
				}
				this.k = new zc(this.i);
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

		// Token: 0x060028D6 RID: 10454 RVA: 0x0017A5EC File Offset: 0x001795EC
		internal zc a()
		{
			byte[] array = new byte[this.m];
			Array.Copy(this.j, 0, array, 0, this.m);
			return new zc(array);
		}

		// Token: 0x060028D7 RID: 10455 RVA: 0x0017A628 File Offset: 0x00179628
		internal zc b()
		{
			byte[] array = new byte[this.n];
			Array.Copy(this.j, this.m, array, 0, this.n);
			return new zc(array);
		}

		// Token: 0x04001266 RID: 4710
		private const int a = 0;

		// Token: 0x04001267 RID: 4711
		private const int b = 1;

		// Token: 0x04001268 RID: 4712
		private const int c = 2;

		// Token: 0x04001269 RID: 4713
		private const int d = 3;

		// Token: 0x0400126A RID: 4714
		private const int e = 4;

		// Token: 0x0400126B RID: 4715
		private const int f = 5;

		// Token: 0x0400126C RID: 4716
		private static readonly int[] g = new int[]
		{
			3,
			3,
			11
		};

		// Token: 0x0400126D RID: 4717
		private static readonly int[] h = new int[]
		{
			2,
			3,
			7
		};

		// Token: 0x0400126E RID: 4718
		private byte[] i;

		// Token: 0x0400126F RID: 4719
		private byte[] j;

		// Token: 0x04001270 RID: 4720
		private zc k;

		// Token: 0x04001271 RID: 4721
		private int l;

		// Token: 0x04001272 RID: 4722
		private int m;

		// Token: 0x04001273 RID: 4723
		private int n;

		// Token: 0x04001274 RID: 4724
		private int o;

		// Token: 0x04001275 RID: 4725
		private int p;

		// Token: 0x04001276 RID: 4726
		private int q;

		// Token: 0x04001277 RID: 4727
		private byte r;

		// Token: 0x04001278 RID: 4728
		private int s;

		// Token: 0x04001279 RID: 4729
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
