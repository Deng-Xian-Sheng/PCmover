using System;

namespace zz93
{
	// Token: 0x020003C7 RID: 967
	internal class za
	{
		// Token: 0x060028C6 RID: 10438 RVA: 0x001798D4 File Offset: 0x001788D4
		internal za() : this(false)
		{
		}

		// Token: 0x060028C7 RID: 10439 RVA: 0x001798E0 File Offset: 0x001788E0
		internal za(bool A_0)
		{
			this.aa = A_0;
			this.ag = new yz();
			this.ab = new zg();
			this.ac = new ze();
			this.r = (A_0 ? 2 : 0);
		}

		// Token: 0x060028C8 RID: 10440 RVA: 0x0017992C File Offset: 0x0017892C
		private bool e()
		{
			int num = this.ab.a(16);
			bool result;
			if (num < 0)
			{
				result = false;
			}
			else
			{
				this.ab.b(16);
				num = ((num << 8 | num >> 8) & 65535);
				if (num % 31 != 0)
				{
					throw new FormatException("Header checksum illegal");
				}
				if ((num & 3840) != y0.d << 8)
				{
					throw new FormatException("Compression Method unknown");
				}
				if ((num & 32) == 0)
				{
					this.r = 2;
				}
				else
				{
					this.r = 1;
					this.t = 32;
				}
				result = true;
			}
			return result;
		}

		// Token: 0x060028C9 RID: 10441 RVA: 0x001799E0 File Offset: 0x001789E0
		private bool d()
		{
			while (this.t > 0)
			{
				int num = this.ab.a(8);
				if (num < 0)
				{
					return false;
				}
				this.ab.b(8);
				this.s = (this.s << 8 | num);
				this.t -= 8;
			}
			return false;
		}

		// Token: 0x060028CA RID: 10442 RVA: 0x00179A4C File Offset: 0x00178A4C
		private bool c()
		{
			int i = this.ac.a();
			while (i >= 258)
			{
				int num;
				switch (this.r)
				{
				case 7:
					while (((num = this.ae.a(this.ab)) & -256) == 0)
					{
						this.ac.a(num);
						if (--i < 258)
						{
							return true;
						}
					}
					if (num >= 257)
					{
						try
						{
							this.u = za.n[num - 257];
							this.t = za.o[num - 257];
						}
						catch (Exception)
						{
							throw new FormatException("Illegal rep length code");
						}
						goto IL_107;
					}
					if (num < 0)
					{
						return false;
					}
					this.af = null;
					this.ae = null;
					this.r = 2;
					return true;
				case 8:
					goto IL_107;
				case 9:
					goto IL_173;
				case 10:
					break;
				default:
					throw new FormatException();
				}
				IL_1C8:
				if (this.t > 0)
				{
					this.r = 10;
					int num2 = this.ab.a(this.t);
					if (num2 < 0)
					{
						return false;
					}
					this.ab.b(this.t);
					this.v += num2;
				}
				this.ac.b(this.u, this.v);
				i -= this.u;
				this.r = 7;
				continue;
				IL_173:
				num = this.af.a(this.ab);
				if (num < 0)
				{
					return false;
				}
				try
				{
					this.v = za.p[num];
					this.t = za.q[num];
				}
				catch (Exception)
				{
					throw new FormatException("Illegal rep dist code");
				}
				goto IL_1C8;
				IL_107:
				if (this.t > 0)
				{
					this.r = 8;
					int num2 = this.ab.a(this.t);
					if (num2 < 0)
					{
						return false;
					}
					this.ab.b(this.t);
					this.u += num2;
				}
				this.r = 9;
				goto IL_173;
			}
			return true;
		}

		// Token: 0x060028CB RID: 10443 RVA: 0x00179CE8 File Offset: 0x00178CE8
		private bool b()
		{
			while (this.t > 0)
			{
				int num = this.ab.a(8);
				if (num < 0)
				{
					return false;
				}
				this.ab.b(8);
				this.s = (this.s << 8 | num);
				this.t -= 8;
			}
			if ((int)this.ag.g1() != this.s)
			{
				throw new FormatException(string.Concat(new object[]
				{
					"Adler chksum doesn't match: ",
					(int)this.ag.g1(),
					" vs. ",
					this.s
				}));
			}
			this.r = 12;
			return false;
		}

		// Token: 0x060028CC RID: 10444 RVA: 0x00179DC0 File Offset: 0x00178DC0
		private bool a()
		{
			switch (this.r)
			{
			case 0:
				return this.e();
			case 1:
				return this.d();
			case 2:
				if (this.x)
				{
					if (this.aa)
					{
						this.r = 12;
						return false;
					}
					this.ab.c();
					this.t = 32;
					this.r = 11;
					return true;
				}
				else
				{
					int num = this.ab.a(3);
					if (num < 0)
					{
						return false;
					}
					this.ab.b(3);
					if ((num & 1) != 0)
					{
						this.x = true;
					}
					switch (num >> 1)
					{
					case 0:
						this.ab.c();
						this.r = 3;
						break;
					case 1:
						this.ae = zc.c;
						this.af = zc.d;
						this.r = 7;
						break;
					case 2:
						this.ad = new zb();
						this.r = 6;
						break;
					default:
						throw new FormatException("Unknown block type " + num);
					}
					return true;
				}
				break;
			case 3:
				if ((this.w = this.ab.a(16)) < 0)
				{
					return false;
				}
				this.ab.b(16);
				this.r = 4;
				break;
			case 4:
				break;
			case 5:
				goto IL_225;
			case 6:
				if (!this.ad.a(this.ab))
				{
					return false;
				}
				this.ae = this.ad.a();
				this.af = this.ad.b();
				this.r = 7;
				goto IL_2C2;
			case 7:
			case 8:
			case 9:
			case 10:
				goto IL_2C2;
			case 11:
				return this.b();
			case 12:
				return false;
			default:
				throw new FormatException();
			}
			int num2 = this.ab.a(16);
			if (num2 < 0)
			{
				return false;
			}
			this.ab.b(16);
			if (num2 != (this.w ^ 65535))
			{
				throw new FormatException("broken uncompressed block");
			}
			this.r = 5;
			IL_225:
			int num3 = this.ac.a(this.ab, this.w);
			this.w -= num3;
			if (this.w == 0)
			{
				this.r = 2;
				return true;
			}
			return !this.ab.d();
			IL_2C2:
			return this.c();
		}

		// Token: 0x060028CD RID: 10445 RVA: 0x0017A0A3 File Offset: 0x001790A3
		internal void a(byte[] A_0)
		{
			this.a(A_0, 0, A_0.Length);
		}

		// Token: 0x060028CE RID: 10446 RVA: 0x0017A0B2 File Offset: 0x001790B2
		internal void a(byte[] A_0, int A_1, int A_2)
		{
			this.ab.b(A_0, A_1, A_2);
			this.z += A_2;
		}

		// Token: 0x060028CF RID: 10447 RVA: 0x0017A0D4 File Offset: 0x001790D4
		internal int b(byte[] A_0)
		{
			return this.b(A_0, 0, A_0.Length);
		}

		// Token: 0x060028D0 RID: 10448 RVA: 0x0017A0F4 File Offset: 0x001790F4
		internal int b(byte[] A_0, int A_1, int A_2)
		{
			if (A_2 < 0)
			{
				throw new ArgumentOutOfRangeException("len < 0");
			}
			int result;
			if (A_2 == 0)
			{
				result = 0;
			}
			else
			{
				int num = 0;
				for (;;)
				{
					if (this.r != 11)
					{
						int num2 = this.ac.a(A_0, A_1, A_2);
						this.ag.g5(A_0, A_1, num2);
						A_1 += num2;
						num += num2;
						this.y += num2;
						A_2 -= num2;
						if (A_2 == 0)
						{
							break;
						}
					}
					if (!this.a() && (this.ac.b() <= 0 || this.r == 11))
					{
						goto Block_7;
					}
				}
				return num;
				Block_7:
				result = num;
			}
			return result;
		}

		// Token: 0x060028D1 RID: 10449 RVA: 0x0017A1C4 File Offset: 0x001791C4
		internal bool f()
		{
			return this.ab.d();
		}

		// Token: 0x060028D2 RID: 10450 RVA: 0x0017A1E4 File Offset: 0x001791E4
		internal bool g()
		{
			return this.r == 12 && this.ac.b() == 0;
		}

		// Token: 0x04001245 RID: 4677
		private const int a = 0;

		// Token: 0x04001246 RID: 4678
		private const int b = 1;

		// Token: 0x04001247 RID: 4679
		private const int c = 2;

		// Token: 0x04001248 RID: 4680
		private const int d = 3;

		// Token: 0x04001249 RID: 4681
		private const int e = 4;

		// Token: 0x0400124A RID: 4682
		private const int f = 5;

		// Token: 0x0400124B RID: 4683
		private const int g = 6;

		// Token: 0x0400124C RID: 4684
		private const int h = 7;

		// Token: 0x0400124D RID: 4685
		private const int i = 8;

		// Token: 0x0400124E RID: 4686
		private const int j = 9;

		// Token: 0x0400124F RID: 4687
		private const int k = 10;

		// Token: 0x04001250 RID: 4688
		private const int l = 11;

		// Token: 0x04001251 RID: 4689
		private const int m = 12;

		// Token: 0x04001252 RID: 4690
		private static int[] n = new int[]
		{
			3,
			4,
			5,
			6,
			7,
			8,
			9,
			10,
			11,
			13,
			15,
			17,
			19,
			23,
			27,
			31,
			35,
			43,
			51,
			59,
			67,
			83,
			99,
			115,
			131,
			163,
			195,
			227,
			258
		};

		// Token: 0x04001253 RID: 4691
		private static int[] o = new int[]
		{
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			1,
			1,
			1,
			1,
			2,
			2,
			2,
			2,
			3,
			3,
			3,
			3,
			4,
			4,
			4,
			4,
			5,
			5,
			5,
			5,
			0
		};

		// Token: 0x04001254 RID: 4692
		private static int[] p = new int[]
		{
			1,
			2,
			3,
			4,
			5,
			7,
			9,
			13,
			17,
			25,
			33,
			49,
			65,
			97,
			129,
			193,
			257,
			385,
			513,
			769,
			1025,
			1537,
			2049,
			3073,
			4097,
			6145,
			8193,
			12289,
			16385,
			24577
		};

		// Token: 0x04001255 RID: 4693
		private static int[] q = new int[]
		{
			0,
			0,
			0,
			0,
			1,
			1,
			2,
			2,
			3,
			3,
			4,
			4,
			5,
			5,
			6,
			6,
			7,
			7,
			8,
			8,
			9,
			9,
			10,
			10,
			11,
			11,
			12,
			12,
			13,
			13
		};

		// Token: 0x04001256 RID: 4694
		private int r;

		// Token: 0x04001257 RID: 4695
		private int s;

		// Token: 0x04001258 RID: 4696
		private int t;

		// Token: 0x04001259 RID: 4697
		private int u;

		// Token: 0x0400125A RID: 4698
		private int v;

		// Token: 0x0400125B RID: 4699
		private int w;

		// Token: 0x0400125C RID: 4700
		private bool x;

		// Token: 0x0400125D RID: 4701
		private int y;

		// Token: 0x0400125E RID: 4702
		private int z;

		// Token: 0x0400125F RID: 4703
		private bool aa;

		// Token: 0x04001260 RID: 4704
		private zg ab;

		// Token: 0x04001261 RID: 4705
		private ze ac;

		// Token: 0x04001262 RID: 4706
		private zb ad;

		// Token: 0x04001263 RID: 4707
		private zc ae;

		// Token: 0x04001264 RID: 4708
		private zc af;

		// Token: 0x04001265 RID: 4709
		private yz ag;
	}
}
