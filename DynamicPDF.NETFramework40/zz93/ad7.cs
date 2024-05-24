using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000484 RID: 1156
	internal class ad7
	{
		// Token: 0x06002FAC RID: 12204 RVA: 0x001AF7AE File Offset: 0x001AE7AE
		internal ad7(bool[] A_0)
		{
			this.h = A_0;
		}

		// Token: 0x06002FAD RID: 12205 RVA: 0x001AF7EC File Offset: 0x001AE7EC
		internal byte[] b()
		{
			return this.e;
		}

		// Token: 0x06002FAE RID: 12206 RVA: 0x001AF804 File Offset: 0x001AE804
		internal int c()
		{
			return this.d;
		}

		// Token: 0x06002FAF RID: 12207 RVA: 0x001AF81C File Offset: 0x001AE81C
		internal void a(int A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06002FB0 RID: 12208 RVA: 0x001AF828 File Offset: 0x001AE828
		internal int d()
		{
			return this.f;
		}

		// Token: 0x06002FB1 RID: 12209 RVA: 0x001AF840 File Offset: 0x001AE840
		internal void b(int A_0)
		{
			this.f = A_0;
		}

		// Token: 0x06002FB2 RID: 12210 RVA: 0x001AF84C File Offset: 0x001AE84C
		internal virtual void k3(char[] A_0)
		{
			this.a(ad7.a);
			char c = '\u0001';
			while ((int)c < this.h.Length)
			{
				if (this.h[(int)c])
				{
					this.a(c, A_0[(int)c]);
				}
				c += '\u0001';
			}
			this.e();
			this.a(ad7.b);
		}

		// Token: 0x06002FB3 RID: 12211 RVA: 0x001AF8B0 File Offset: 0x001AE8B0
		internal void e()
		{
			int num = this.d;
			this.a(ad7.c, num);
			num /= 10;
			if (num != 0)
			{
				this.a(ad7.c - 1, num);
				num /= 10;
				if (num != 0)
				{
					this.a(ad7.c - 2, num);
					num /= 10;
					if (num != 0)
					{
						this.a(ad7.c - 3, num);
						num /= 10;
						if (num != 0)
						{
							this.a(ad7.c - 4, num);
						}
					}
				}
			}
		}

		// Token: 0x06002FB4 RID: 12212 RVA: 0x001AF956 File Offset: 0x001AE956
		private void a(int A_0, int A_1)
		{
			A_1 %= 10;
			this.e[A_0] = (byte)(48 + A_1);
		}

		// Token: 0x06002FB5 RID: 12213 RVA: 0x001AF96C File Offset: 0x001AE96C
		internal void a(char A_0, char A_1)
		{
			this.d++;
			this.d(14);
			this.a(A_0);
			this.e[this.f++] = 32;
			this.a(A_1);
			this.e[this.f++] = 10;
		}

		// Token: 0x06002FB6 RID: 12214 RVA: 0x001AF9D8 File Offset: 0x001AE9D8
		internal void a(char A_0)
		{
			this.e[this.f++] = 60;
			this.c((int)(A_0 >> 12));
			this.c((int)(A_0 >> 8));
			this.c((int)(A_0 >> 4));
			this.c((int)A_0);
			this.e[this.f++] = 62;
		}

		// Token: 0x06002FB7 RID: 12215 RVA: 0x001AFA44 File Offset: 0x001AEA44
		internal void c(int A_0)
		{
			A_0 &= 15;
			if (A_0 < 10)
			{
				this.e[this.f++] = (byte)(48 + A_0);
			}
			else
			{
				this.e[this.f++] = (byte)(55 + A_0);
			}
		}

		// Token: 0x06002FB8 RID: 12216 RVA: 0x001AFAA0 File Offset: 0x001AEAA0
		internal void a(DocumentWriter A_0)
		{
			A_0.WriteBeginObject();
			A_0.WriteDictionaryOpen();
			A_0.WriteName(ad7.i);
			A_0.WriteReference(A_0.GetObjectNumber(1));
			A_0.WriteName(ad7.j);
			A_0.WriteName(ad7.k);
			A_0.WriteDictionaryClose();
			int value = A_0.WriteStreamWithCompression(this.e, this.f);
			A_0.WriteEndObject();
			A_0.WriteBeginObject();
			A_0.WriteNumber(value);
			A_0.WriteEndObject();
		}

		// Token: 0x06002FB9 RID: 12217 RVA: 0x001AFB28 File Offset: 0x001AEB28
		private void a()
		{
			this.g *= 4;
			byte[] array = new byte[this.g];
			this.e.CopyTo(array, 0);
			this.e = array;
		}

		// Token: 0x06002FBA RID: 12218 RVA: 0x001AFB68 File Offset: 0x001AEB68
		internal void d(int A_0)
		{
			while (this.g - this.f < A_0)
			{
				this.a();
			}
		}

		// Token: 0x06002FBB RID: 12219 RVA: 0x001AFB95 File Offset: 0x001AEB95
		internal void a(byte[] A_0)
		{
			this.d(A_0.Length);
			Array.Copy(A_0, 0, this.e, this.f, A_0.Length);
			this.f += A_0.Length;
		}

		// Token: 0x040016B0 RID: 5808
		internal static byte[] a = new byte[]
		{
			47,
			67,
			73,
			68,
			73,
			110,
			105,
			116,
			32,
			47,
			80,
			114,
			111,
			99,
			83,
			101,
			116,
			32,
			102,
			105,
			110,
			100,
			114,
			101,
			115,
			111,
			117,
			114,
			99,
			101,
			32,
			98,
			101,
			103,
			105,
			110,
			10,
			49,
			50,
			32,
			100,
			105,
			99,
			116,
			32,
			98,
			101,
			103,
			105,
			110,
			10,
			98,
			101,
			103,
			105,
			110,
			99,
			109,
			97,
			112,
			10,
			47,
			67,
			73,
			68,
			83,
			121,
			115,
			116,
			101,
			109,
			73,
			110,
			102,
			111,
			32,
			60,
			60,
			32,
			47,
			82,
			101,
			103,
			105,
			115,
			116,
			114,
			121,
			32,
			40,
			65,
			100,
			111,
			98,
			101,
			41,
			32,
			47,
			79,
			114,
			100,
			101,
			114,
			105,
			110,
			103,
			32,
			40,
			85,
			67,
			83,
			41,
			32,
			47,
			83,
			117,
			112,
			112,
			108,
			101,
			109,
			101,
			110,
			116,
			32,
			48,
			32,
			62,
			62,
			32,
			100,
			101,
			102,
			10,
			47,
			67,
			77,
			97,
			112,
			78,
			97,
			109,
			101,
			32,
			47,
			65,
			100,
			111,
			98,
			101,
			45,
			73,
			100,
			101,
			110,
			116,
			105,
			116,
			121,
			45,
			85,
			67,
			83,
			32,
			100,
			101,
			102,
			10,
			47,
			67,
			77,
			97,
			112,
			84,
			121,
			112,
			101,
			32,
			50,
			32,
			100,
			101,
			102,
			10,
			49,
			32,
			98,
			101,
			103,
			105,
			110,
			99,
			111,
			100,
			101,
			115,
			112,
			97,
			99,
			101,
			114,
			97,
			110,
			103,
			101,
			10,
			60,
			48,
			48,
			48,
			48,
			62,
			32,
			60,
			70,
			70,
			70,
			70,
			62,
			10,
			101,
			110,
			100,
			99,
			111,
			100,
			101,
			115,
			112,
			97,
			99,
			101,
			114,
			97,
			110,
			103,
			101,
			10,
			48,
			48,
			48,
			48,
			48,
			32,
			98,
			101,
			103,
			105,
			110,
			98,
			102,
			99,
			104,
			97,
			114,
			10
		};

		// Token: 0x040016B1 RID: 5809
		internal static byte[] b = new byte[]
		{
			101,
			110,
			100,
			98,
			102,
			99,
			104,
			97,
			114,
			10,
			101,
			110,
			100,
			99,
			109,
			97,
			112,
			32,
			67,
			77,
			97,
			112,
			78,
			97,
			109,
			101,
			32,
			99,
			117,
			114,
			114,
			101,
			110,
			116,
			100,
			105,
			99,
			116,
			32,
			47,
			67,
			77,
			97,
			112,
			32,
			100,
			101,
			102,
			105,
			110,
			101,
			114,
			101,
			115,
			111,
			117,
			114,
			99,
			101,
			32,
			112,
			111,
			112,
			32,
			101,
			110,
			100,
			32,
			101,
			110,
			100
		};

		// Token: 0x040016B2 RID: 5810
		private static int c = 242;

		// Token: 0x040016B3 RID: 5811
		private int d = 0;

		// Token: 0x040016B4 RID: 5812
		private byte[] e = new byte[2048];

		// Token: 0x040016B5 RID: 5813
		private int f = 0;

		// Token: 0x040016B6 RID: 5814
		private int g = 2048;

		// Token: 0x040016B7 RID: 5815
		private bool[] h;

		// Token: 0x040016B8 RID: 5816
		private static byte[] i = new byte[]
		{
			76,
			101,
			110,
			103,
			116,
			104
		};

		// Token: 0x040016B9 RID: 5817
		private static byte[] j = new byte[]
		{
			70,
			105,
			108,
			116,
			101,
			114
		};

		// Token: 0x040016BA RID: 5818
		private static byte[] k = new byte[]
		{
			70,
			108,
			97,
			116,
			101,
			68,
			101,
			99,
			111,
			100,
			101
		};
	}
}
