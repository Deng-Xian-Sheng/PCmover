using System;
using System.IO;

namespace zz93
{
	// Token: 0x02000465 RID: 1125
	internal class adc
	{
		// Token: 0x06002EC9 RID: 11977 RVA: 0x001A9354 File Offset: 0x001A8354
		internal adc(Stream A_0, byte[] A_1, int A_2)
		{
			BinaryReader a_ = new BinaryReader(A_0);
			A_2 += 8;
			this.v = ((int)A_1[A_2++] << 24 | (int)A_1[A_2++] << 16 | (int)A_1[A_2++] << 8 | (int)A_1[A_2++]);
			this.e(a_);
		}

		// Token: 0x06002ECA RID: 11978 RVA: 0x001A93E4 File Offset: 0x001A83E4
		internal void a(add A_0, bool A_1)
		{
			if (A_1)
			{
				if (this.h)
				{
					adg adg = new adg(A_0, this.k, this.l, this.m, this.n, this.p, this.q, this.r, this.s, this.t, this.u);
					adg.d();
				}
				else
				{
					adt adt = new adt(this.m.b().Length / (int)this.m.c(), this.m.d().Length);
					ads a_ = this.a(adt);
					ads a_2 = this.b();
					adk a_3 = new adk(10);
					adg adg = new adg(A_0, this.k, a_, adt.a(), this.n, this.p, a_3, this.r, a_2, this.t, this.u);
					adg.d();
				}
			}
			else
			{
				A_0.a(adc.a());
				this.k.a(A_0);
				this.l.a(A_0);
				this.m.a(A_0);
				this.n.a(A_0);
				if (this.o != null)
				{
					A_0.a(this.o);
				}
				this.p.a(A_0);
				if (this.q != null)
				{
					this.q.a(A_0);
				}
				this.r.a(A_0);
				if (this.s != null)
				{
					this.s.a(A_0);
				}
				for (int i = 0; i < this.t.Length; i++)
				{
					for (int j = 0; j < this.t[i].Length; j++)
					{
						A_0.a(this.t[i][j]);
					}
				}
				for (int i = 0; i < this.u.Length; i++)
				{
					if (this.u[i] != null)
					{
						this.u[i].a(A_0);
					}
				}
			}
		}

		// Token: 0x06002ECB RID: 11979 RVA: 0x001A9630 File Offset: 0x001A8630
		internal static void a(ref int A_0, byte[] A_1, adj A_2)
		{
			A_2.a();
			while (A_2.b() < 0)
			{
				byte b = A_1[A_0++];
				if (b == 29)
				{
					int num = (int)A_1[A_0++] << 24 | (int)A_1[A_0++] << 16 | (int)A_1[A_0++] << 8 | (int)A_1[A_0++];
					int[] array = A_2.c();
					byte b2;
					A_2.a((b2 = A_2.d()) + 1);
					array[(int)b2] = num;
				}
				else if (b == 28)
				{
					int num = (int)A_1[A_0++] << 8 | (int)A_1[A_0++];
					int[] array2 = A_2.c();
					byte b2;
					A_2.a((b2 = A_2.d()) + 1);
					array2[(int)b2] = num;
				}
				else if (b >= 32 && b <= 246)
				{
					int num = (int)(b - 139);
					int[] array3 = A_2.c();
					byte b2;
					A_2.a((b2 = A_2.d()) + 1);
					array3[(int)b2] = num;
				}
				else if (b >= 247 && b <= 250)
				{
					byte b3 = A_1[A_0++];
					int num = (int)(b - 247) * 256 + (int)b3 + 108;
					int[] array4 = A_2.c();
					byte b2;
					A_2.a((b2 = A_2.d()) + 1);
					array4[(int)b2] = num;
				}
				else if (b >= 251 && b <= 254)
				{
					byte b3 = A_1[A_0++];
					int num = (int)(-(int)(b - 251)) * 256 - (int)b3 - 108;
					int[] array5 = A_2.c();
					byte b2;
					A_2.a((b2 = A_2.d()) + 1);
					array5[(int)b2] = num;
				}
				else if (b == 30)
				{
					bool flag = false;
					while (!flag)
					{
						byte b4 = A_1[A_0++];
						flag = adc.a((byte)(b4 >> 4 & 15));
						flag = adc.a(b4 & 15);
					}
					int[] array6 = A_2.c();
					byte b2;
					A_2.a((b2 = A_2.d()) + 1);
					array6[(int)b2] = -1;
				}
				else if (b <= 21)
				{
					if (b != 12)
					{
						A_2.a((int)b);
					}
					else
					{
						A_2.a((int)b << 8 | (int)A_1[A_0++]);
					}
				}
			}
		}

		// Token: 0x06002ECC RID: 11980 RVA: 0x001A98D4 File Offset: 0x001A88D4
		private static bool a(byte A_0)
		{
			switch (A_0)
			{
			case 10:
				return false;
			case 11:
				return false;
			case 12:
				return false;
			case 14:
				return false;
			case 15:
				return true;
			}
			return A_0 < 0 || A_0 > 9;
		}

		// Token: 0x06002ECD RID: 11981 RVA: 0x001A993C File Offset: 0x001A893C
		private void e(BinaryReader A_0)
		{
			A_0.BaseStream.Position = (long)this.v;
			if (A_0.ReadByte() != 1 || A_0.ReadByte() != 0)
			{
				throw new Exception("CFF Format of the font is not recogonized");
			}
			byte b = A_0.ReadByte();
			A_0.BaseStream.Position = (long)(this.v + (int)b);
			this.k = new ads(A_0);
			this.l = new ads(A_0);
			this.m = new ads(A_0);
			this.n = new ads(A_0);
			if (this.l.a() > 0)
			{
				this.c();
			}
			if (this.e > 0)
			{
				A_0.BaseStream.Position = (long)(this.v + this.e);
				this.r = new ads(A_0);
			}
			if (this.d > 0 && this.c > 0)
			{
				A_0.BaseStream.Position = (long)(this.v + this.d);
				this.o = new byte[this.c - this.d];
				A_0.Read(this.o, 0, this.o.Length);
			}
			if (this.c > 0)
			{
				this.a(A_0);
			}
			if (this.h)
			{
				if (this.j > 0)
				{
					this.b(A_0);
				}
				if (this.i > 0)
				{
					A_0.BaseStream.Position = (long)(this.v + this.i);
					this.s = new ads(A_0);
				}
			}
			this.c(A_0);
			this.d(A_0);
		}

		// Token: 0x06002ECE RID: 11982 RVA: 0x001A9B14 File Offset: 0x001A8B14
		private void d(BinaryReader A_0)
		{
			this.u = new ads[this.t.Length];
			adj adj = new adj();
			for (int i = 0; i < this.t.Length; i++)
			{
				if (this.t[i] != null)
				{
					int j = 0;
					int num = this.t[i].Length;
					while (j < num)
					{
						adc.a(ref j, this.t[i], adj);
						int num2 = adj.b();
						if (num2 == 19)
						{
							A_0.BaseStream.Position = (long)(this.v + this.g[i] + adj.c()[0]);
							this.u[i] = new ads(A_0);
						}
					}
				}
			}
		}

		// Token: 0x06002ECF RID: 11983 RVA: 0x001A9BE0 File Offset: 0x001A8BE0
		private void c(BinaryReader A_0)
		{
			if (this.h)
			{
				this.t = new byte[(int)this.s.a()][];
				this.g = new int[(int)this.s.a()];
				this.f = new int[(int)this.s.a()];
				adj adj = new adj();
				for (int i = 0; i < (int)this.s.a(); i++)
				{
					int j = this.s.a(i);
					int num = this.s.a(i + 1);
					while (j < num)
					{
						adc.a(ref j, this.s.d(), adj);
						int num2 = adj.b();
						if (num2 == 18)
						{
							this.g[i] = adj.c()[1];
							this.f[i] = adj.c()[0];
							A_0.BaseStream.Position = (long)(this.v + this.g[i]);
							this.t[i] = A_0.ReadBytes(this.f[i]);
						}
					}
				}
			}
			else if (this.f[0] > 0 && this.g[0] > 0)
			{
				this.t = new byte[1][];
				A_0.BaseStream.Position = (long)(this.v + this.g[0]);
				this.t[0] = A_0.ReadBytes(this.f[0]);
			}
		}

		// Token: 0x06002ED0 RID: 11984 RVA: 0x001A9D7C File Offset: 0x001A8D7C
		private void b(BinaryReader A_0)
		{
			A_0.BaseStream.Position = (long)(this.v + this.j);
			byte b = A_0.ReadByte();
			this.q = new adk(b);
			byte b2 = b;
			if (b2 != 0)
			{
				if (b2 != 3)
				{
					throw new Exception("FDSelect format not defined");
				}
				this.q.a((ushort)((int)A_0.ReadByte() << 8 | (int)A_0.ReadByte()));
				this.q.a(new adl[(int)this.q.c()]);
				for (int i = 0; i < (int)this.q.c(); i++)
				{
					this.q.f()[i] = new adl((ushort)((int)A_0.ReadByte() << 8 | (int)A_0.ReadByte()), A_0.ReadByte());
				}
				this.q.b((ushort)((int)A_0.ReadByte() << 8 | (int)A_0.ReadByte()));
			}
			else
			{
				this.q.a(new byte[(int)this.r.a()]);
				for (int i = 0; i < (int)this.r.a(); i++)
				{
					this.q.e()[i] = A_0.ReadByte();
				}
			}
		}

		// Token: 0x06002ED1 RID: 11985 RVA: 0x001A9EBC File Offset: 0x001A8EBC
		private void a(BinaryReader A_0)
		{
			A_0.BaseStream.Position = (long)(this.v + this.c);
			byte a_ = A_0.ReadByte();
			int i = (int)(this.r.a() - 1);
			this.p = new ade(a_);
			switch (a_)
			{
			case 0:
				i = 0;
				this.p.a(new ushort[(int)(this.r.a() - 1)]);
				while (i < this.p.d().Length)
				{
					this.p.d()[i++] = (ushort)((int)A_0.ReadByte() << 8 | (int)A_0.ReadByte());
				}
				break;
			case 1:
				while (i > 0 && this.p.c() < (int)this.r.a())
				{
					ushort a_2 = (ushort)((int)A_0.ReadByte() << 8 | (int)A_0.ReadByte());
					ushort num = (ushort)A_0.ReadByte();
					this.p.a(new adf(a_2, num));
					i -= (int)(num + 1);
				}
				break;
			case 2:
				while (i > 0 && this.p.c() < (int)this.r.a())
				{
					ushort a_2 = (ushort)((int)A_0.ReadByte() << 8 | (int)A_0.ReadByte());
					ushort num = (ushort)((int)A_0.ReadByte() << 8 | (int)A_0.ReadByte());
					this.p.a(new adf(a_2, num));
					i -= (int)(num + 1);
				}
				break;
			default:
				throw new Exception("Charset format not define");
			}
		}

		// Token: 0x06002ED2 RID: 11986 RVA: 0x001AA054 File Offset: 0x001A9054
		private void c()
		{
			int i = 0;
			int num = this.l.a(1);
			adj adj = new adj();
			while (i < num)
			{
				adc.a(ref i, this.l.d(), adj);
				int num2 = adj.b();
				if (num2 <= 18)
				{
					if (num2 != 5)
					{
						switch (num2)
						{
						case 15:
							this.c = adj.c()[0];
							break;
						case 16:
							this.d = adj.c()[0];
							break;
						case 17:
							this.e = adj.c()[0];
							break;
						case 18:
							this.f[0] = adj.c()[0];
							this.g[0] = adj.c()[1];
							break;
						}
					}
					else
					{
						this.w[0] = adj.c()[0];
						this.w[1] = adj.c()[1];
						this.w[2] = adj.c()[2];
						this.w[3] = adj.c()[3];
					}
				}
				else if (num2 != 3102)
				{
					switch (num2)
					{
					case 3108:
						this.i = adj.c()[0];
						break;
					case 3109:
						this.j = adj.c()[0];
						break;
					}
				}
				else
				{
					this.h = true;
				}
			}
		}

		// Token: 0x06002ED3 RID: 11987 RVA: 0x001AA1B0 File Offset: 0x001A91B0
		private ads b()
		{
			MemoryStream memoryStream = new MemoryStream();
			ads ads = new ads();
			ads.a(1);
			ads.a(1);
			ads.a(new byte[2]);
			ads.a(0, (int)memoryStream.Position + 1);
			this.a(0, memoryStream);
			this.a(0, memoryStream);
			memoryStream.WriteByte(18);
			ads.a((int)ads.a(), (int)memoryStream.Position + 1);
			ads.b(new byte[memoryStream.Position]);
			memoryStream.Position = 0L;
			memoryStream.Read(ads.d(), 0, ads.d().Length);
			return ads;
		}

		// Token: 0x06002ED4 RID: 11988 RVA: 0x001AA260 File Offset: 0x001A9260
		private ads a(adt A_0)
		{
			MemoryStream memoryStream = new MemoryStream();
			A_0.a("Adobe");
			A_0.a("Identity");
			this.a(391, memoryStream);
			this.a(392, memoryStream);
			this.a(0, memoryStream);
			memoryStream.WriteByte(12);
			memoryStream.WriteByte(30);
			this.a(0, memoryStream);
			memoryStream.WriteByte(12);
			memoryStream.WriteByte(36);
			this.a(0, memoryStream);
			memoryStream.WriteByte(12);
			memoryStream.WriteByte(37);
			int i = 0;
			int num = this.l.a(1);
			adj adj = new adj();
			while (i < num)
			{
				int num2 = i;
				adc.a(ref i, this.l.d(), adj);
				int num3 = adj.b();
				if (num3 <= 16)
				{
					switch (num3)
					{
					case 0:
						this.a(A_0, memoryStream, adj.c()[0], 0);
						break;
					case 1:
						this.a(A_0, memoryStream, adj.c()[0], 1);
						break;
					case 2:
						this.a(A_0, memoryStream, adj.c()[0], 2);
						break;
					case 3:
						this.a(A_0, memoryStream, adj.c()[0], 3);
						break;
					case 4:
						this.a(A_0, memoryStream, adj.c()[0], 4);
						break;
					default:
						if (num3 != 16)
						{
							goto IL_1E0;
						}
						break;
					}
				}
				else if (num3 != 3072)
				{
					switch (num3)
					{
					case 3093:
					case 3102:
					case 3103:
					case 3104:
					case 3105:
					case 3106:
					case 3107:
					case 3108:
					case 3109:
					case 3110:
						break;
					case 3094:
					case 3095:
					case 3096:
					case 3097:
					case 3098:
					case 3099:
					case 3100:
					case 3101:
						goto IL_1E0;
					default:
						goto IL_1E0;
					}
				}
				else
				{
					this.a(A_0, memoryStream, adj.c()[0], 12, 0);
				}
				continue;
				IL_1E0:
				memoryStream.Write(this.l.d(), num2, i - num2);
			}
			ads ads = new ads();
			ads.a(1);
			if (memoryStream.Position < 255L)
			{
				ads.a(1);
			}
			else if (memoryStream.Position < 65535L)
			{
				ads.a(2);
			}
			else if (memoryStream.Position < 1048575L)
			{
				ads.a(3);
			}
			else
			{
				ads.a(4);
			}
			ads.a(new byte[(int)((ads.a() + 1) * (ushort)ads.c())]);
			ads.a(0, 1);
			ads.a(1, (int)memoryStream.Position);
			ads.b(new byte[memoryStream.Position]);
			memoryStream.Position = 0L;
			memoryStream.Read(ads.d(), 0, ads.d().Length);
			return ads;
		}

		// Token: 0x06002ED5 RID: 11989 RVA: 0x001AA568 File Offset: 0x001A9568
		private void a(adt A_0, MemoryStream A_1, int A_2, byte A_3)
		{
			if (A_2 >= 391)
			{
				A_2 -= 391;
				this.a(391 + A_0.b(), A_1);
				A_1.WriteByte(A_3);
				A_0.a(this.m.d(), this.m.a(A_2), this.m.a(A_2 + 1) - this.m.a(A_2));
			}
			else
			{
				this.a(A_2, A_1);
				A_1.WriteByte(A_3);
			}
		}

		// Token: 0x06002ED6 RID: 11990 RVA: 0x001AA5FC File Offset: 0x001A95FC
		private void a(adt A_0, MemoryStream A_1, int A_2, byte A_3, byte A_4)
		{
			if (A_2 >= 391)
			{
				A_2 -= 391;
				this.a(391 + A_0.b(), A_1);
				A_1.WriteByte(A_3);
				A_1.WriteByte(A_4);
				A_0.a(this.m.d(), this.m.a(A_2), this.m.a(A_2 + 1) - this.m.a(A_2));
			}
			else
			{
				this.a(A_2, A_1);
				A_1.WriteByte(A_3);
				A_1.WriteByte(A_4);
			}
		}

		// Token: 0x06002ED7 RID: 11991 RVA: 0x001AA69F File Offset: 0x001A969F
		private void a(int A_0, MemoryStream A_1)
		{
			A_1.WriteByte(29);
			A_1.WriteByte((byte)(A_0 >> 24));
			A_1.WriteByte((byte)(A_0 >> 16));
			A_1.WriteByte((byte)(A_0 >> 8));
			A_1.WriteByte((byte)A_0);
		}

		// Token: 0x06002ED8 RID: 11992 RVA: 0x001AA6D8 File Offset: 0x001A96D8
		internal bool d()
		{
			return this.h;
		}

		// Token: 0x06002ED9 RID: 11993 RVA: 0x001AA6F0 File Offset: 0x001A96F0
		internal static byte[] a()
		{
			return adc.b;
		}

		// Token: 0x0400162A RID: 5674
		private const int a = 391;

		// Token: 0x0400162B RID: 5675
		private static byte[] b = new byte[]
		{
			1,
			0,
			4,
			2
		};

		// Token: 0x0400162C RID: 5676
		private int c;

		// Token: 0x0400162D RID: 5677
		private int d;

		// Token: 0x0400162E RID: 5678
		private int e;

		// Token: 0x0400162F RID: 5679
		private int[] f = new int[1];

		// Token: 0x04001630 RID: 5680
		private int[] g = new int[1];

		// Token: 0x04001631 RID: 5681
		private bool h = false;

		// Token: 0x04001632 RID: 5682
		private int i;

		// Token: 0x04001633 RID: 5683
		private int j;

		// Token: 0x04001634 RID: 5684
		private ads k;

		// Token: 0x04001635 RID: 5685
		private ads l;

		// Token: 0x04001636 RID: 5686
		private ads m;

		// Token: 0x04001637 RID: 5687
		private ads n;

		// Token: 0x04001638 RID: 5688
		private byte[] o = null;

		// Token: 0x04001639 RID: 5689
		private ade p;

		// Token: 0x0400163A RID: 5690
		private adk q;

		// Token: 0x0400163B RID: 5691
		private ads r;

		// Token: 0x0400163C RID: 5692
		private ads s;

		// Token: 0x0400163D RID: 5693
		private byte[][] t;

		// Token: 0x0400163E RID: 5694
		private ads[] u;

		// Token: 0x0400163F RID: 5695
		private int v;

		// Token: 0x04001640 RID: 5696
		internal int[] w = new int[4];
	}
}
