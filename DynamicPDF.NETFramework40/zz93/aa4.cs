using System;

namespace zz93
{
	// Token: 0x02000412 RID: 1042
	internal class aa4
	{
		// Token: 0x06002B86 RID: 11142 RVA: 0x0019210F File Offset: 0x0019110F
		internal aa4() : this(false)
		{
		}

		// Token: 0x06002B87 RID: 11143 RVA: 0x0019211C File Offset: 0x0019111C
		internal aa4(bool A_0)
		{
			this.aa = A_0;
			this.ag = new aaw();
			this.ab = new aa8();
			this.ac = new aa7();
			this.r = (A_0 ? 2 : 0);
		}

		// Token: 0x06002B88 RID: 11144 RVA: 0x00192168 File Offset: 0x00191168
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
				if ((num & 3840) != aax.d << 8)
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

		// Token: 0x06002B89 RID: 11145 RVA: 0x0019221C File Offset: 0x0019121C
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

		// Token: 0x06002B8A RID: 11146 RVA: 0x00192288 File Offset: 0x00191288
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
							this.u = aa4.n[num - 257];
							this.t = aa4.o[num - 257];
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
					this.v = aa4.p[num];
					this.t = aa4.q[num];
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

		// Token: 0x06002B8B RID: 11147 RVA: 0x00192524 File Offset: 0x00191524
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
			if ((int)this.ag.hq() != this.s)
			{
				throw new FormatException(string.Concat(new object[]
				{
					"Adler chksum doesn't match: ",
					(int)this.ag.hq(),
					" vs. ",
					this.s
				}));
			}
			this.r = 12;
			return false;
		}

		// Token: 0x06002B8C RID: 11148 RVA: 0x001925FC File Offset: 0x001915FC
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
						this.ae = aa6.c;
						this.af = aa6.d;
						this.r = 7;
						break;
					case 2:
						this.ad = new aa5();
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

		// Token: 0x06002B8D RID: 11149 RVA: 0x001928DF File Offset: 0x001918DF
		internal void a(byte[] A_0, int A_1, int A_2)
		{
			this.ab.b(A_0, A_1, A_2);
			this.z += A_2;
		}

		// Token: 0x06002B8E RID: 11150 RVA: 0x00192900 File Offset: 0x00191900
		internal int a(byte[] A_0)
		{
			return this.b(A_0, 0, A_0.Length);
		}

		// Token: 0x06002B8F RID: 11151 RVA: 0x00192920 File Offset: 0x00191920
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
						this.ag.hu(A_0, A_1, num2);
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

		// Token: 0x04001453 RID: 5203
		private const int a = 0;

		// Token: 0x04001454 RID: 5204
		private const int b = 1;

		// Token: 0x04001455 RID: 5205
		private const int c = 2;

		// Token: 0x04001456 RID: 5206
		private const int d = 3;

		// Token: 0x04001457 RID: 5207
		private const int e = 4;

		// Token: 0x04001458 RID: 5208
		private const int f = 5;

		// Token: 0x04001459 RID: 5209
		private const int g = 6;

		// Token: 0x0400145A RID: 5210
		private const int h = 7;

		// Token: 0x0400145B RID: 5211
		private const int i = 8;

		// Token: 0x0400145C RID: 5212
		private const int j = 9;

		// Token: 0x0400145D RID: 5213
		private const int k = 10;

		// Token: 0x0400145E RID: 5214
		private const int l = 11;

		// Token: 0x0400145F RID: 5215
		private const int m = 12;

		// Token: 0x04001460 RID: 5216
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

		// Token: 0x04001461 RID: 5217
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

		// Token: 0x04001462 RID: 5218
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

		// Token: 0x04001463 RID: 5219
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

		// Token: 0x04001464 RID: 5220
		private int r;

		// Token: 0x04001465 RID: 5221
		private int s;

		// Token: 0x04001466 RID: 5222
		private int t;

		// Token: 0x04001467 RID: 5223
		private int u;

		// Token: 0x04001468 RID: 5224
		private int v;

		// Token: 0x04001469 RID: 5225
		private int w;

		// Token: 0x0400146A RID: 5226
		private bool x;

		// Token: 0x0400146B RID: 5227
		private int y;

		// Token: 0x0400146C RID: 5228
		private int z;

		// Token: 0x0400146D RID: 5229
		private bool aa;

		// Token: 0x0400146E RID: 5230
		private aa8 ab;

		// Token: 0x0400146F RID: 5231
		private aa7 ac;

		// Token: 0x04001470 RID: 5232
		private aa5 ad;

		// Token: 0x04001471 RID: 5233
		private aa6 ae;

		// Token: 0x04001472 RID: 5234
		private aa6 af;

		// Token: 0x04001473 RID: 5235
		private aaw ag;
	}
}
