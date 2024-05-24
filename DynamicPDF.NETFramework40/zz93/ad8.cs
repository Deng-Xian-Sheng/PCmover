using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000485 RID: 1157
	internal class ad8
	{
		// Token: 0x06002FBD RID: 12221 RVA: 0x001AFC58 File Offset: 0x001AEC58
		internal ad8(bool[] A_0)
		{
			this.g = A_0;
			this.h = new int[A_0.Length];
			ushort num = 0;
			while ((int)num < this.h.Length)
			{
				this.h[(int)num] = -1;
				num += 1;
			}
			ad8.a.CopyTo(this.f, 0);
		}

		// Token: 0x06002FBE RID: 12222 RVA: 0x001AFCDC File Offset: 0x001AECDC
		internal void a(DocumentWriter A_0)
		{
			A_0.WriteBeginObject();
			A_0.WriteDictionaryOpen();
			A_0.WriteName(ad8.i);
			A_0.WriteReference(A_0.GetObjectNumber(1));
			A_0.WriteName(ad8.j);
			A_0.WriteName(ad8.k);
			A_0.WriteName(ad8.l);
			A_0.WriteNumber(this.d);
			A_0.WriteDictionaryClose();
			int value = A_0.WriteStreamWithCompression(this.f, this.d);
			A_0.WriteEndObject();
			A_0.WriteBeginObject();
			A_0.WriteNumber(value);
			A_0.WriteEndObject();
		}

		// Token: 0x06002FBF RID: 12223 RVA: 0x001AFD7C File Offset: 0x001AED7C
		internal void a()
		{
			this.e *= 4;
			byte[] array = new byte[this.e];
			this.f.CopyTo(array, 0);
			this.f = array;
		}

		// Token: 0x06002FC0 RID: 12224 RVA: 0x001AFDBC File Offset: 0x001AEDBC
		internal void a(int A_0)
		{
			while (this.e - this.d < A_0)
			{
				this.a();
			}
		}

		// Token: 0x06002FC1 RID: 12225 RVA: 0x001AFDEC File Offset: 0x001AEDEC
		internal void b()
		{
			int num = 4 - this.d % 4;
			if (num < 4)
			{
				this.d += num;
			}
		}

		// Token: 0x06002FC2 RID: 12226 RVA: 0x001AFE1E File Offset: 0x001AEE1E
		internal void a(int A_0, int A_1)
		{
			this.a(A_0, this.d, A_1);
		}

		// Token: 0x06002FC3 RID: 12227 RVA: 0x001AFE30 File Offset: 0x001AEE30
		internal void a(int A_0, int A_1, int A_2)
		{
			int num = A_0 * 16 + 12;
			this.f[num + 8] = (byte)(A_1 >> 24);
			this.f[num + 9] = (byte)(A_1 >> 16);
			this.f[num + 10] = (byte)(A_1 >> 8);
			this.f[num + 11] = (byte)A_1;
			this.f[num + 12] = (byte)(A_2 >> 24);
			this.f[num + 13] = (byte)(A_2 >> 16);
			this.f[num + 14] = (byte)(A_2 >> 8);
			this.f[num + 15] = (byte)A_2;
		}

		// Token: 0x06002FC4 RID: 12228 RVA: 0x001AFEBD File Offset: 0x001AEEBD
		internal void b(int A_0, int A_1)
		{
			this.f[A_0] = (byte)(A_1 >> 24);
			this.f[A_0 + 1] = (byte)(A_1 >> 16);
			this.f[A_0 + 2] = (byte)(A_1 >> 8);
			this.f[A_0 + 3] = (byte)A_1;
		}

		// Token: 0x06002FC5 RID: 12229 RVA: 0x001AFEF6 File Offset: 0x001AEEF6
		internal void c(int A_0, int A_1)
		{
			this.f[A_0] = (byte)(A_1 >> 8);
			this.f[A_0 + 1] = (byte)A_1;
		}

		// Token: 0x06002FC6 RID: 12230 RVA: 0x001AFF11 File Offset: 0x001AEF11
		internal void a(byte[] A_0)
		{
			this.a(A_0.Length);
			Array.Copy(A_0, 0, this.f, this.d, A_0.Length);
			this.d += A_0.Length;
		}

		// Token: 0x06002FC7 RID: 12231 RVA: 0x001AFF45 File Offset: 0x001AEF45
		internal void a(byte[] A_0, int A_1, int A_2)
		{
			this.a(A_2);
			Array.Copy(A_0, A_1, this.f, this.d, A_2);
			this.d += A_2;
		}

		// Token: 0x06002FC8 RID: 12232 RVA: 0x001AFF73 File Offset: 0x001AEF73
		internal void b(int A_0)
		{
			this.a(A_0);
			this.d += A_0;
		}

		// Token: 0x06002FC9 RID: 12233 RVA: 0x001AFF8C File Offset: 0x001AEF8C
		internal bool[] c()
		{
			return this.g;
		}

		// Token: 0x06002FCA RID: 12234 RVA: 0x001AFFA4 File Offset: 0x001AEFA4
		internal int[] d()
		{
			return this.h;
		}

		// Token: 0x06002FCB RID: 12235 RVA: 0x001AFFBC File Offset: 0x001AEFBC
		internal int e()
		{
			return this.d;
		}

		// Token: 0x06002FCC RID: 12236 RVA: 0x001AFFD4 File Offset: 0x001AEFD4
		internal int f()
		{
			return this.c;
		}

		// Token: 0x06002FCD RID: 12237 RVA: 0x001AFFEC File Offset: 0x001AEFEC
		internal void c(int A_0)
		{
			this.c = A_0;
		}

		// Token: 0x040016BB RID: 5819
		private static byte[] a = new byte[]
		{
			0,
			1,
			0,
			0,
			0,
			11,
			0,
			128,
			0,
			3,
			0,
			16,
			104,
			101,
			97,
			100,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			104,
			104,
			101,
			97,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			104,
			109,
			116,
			120,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			99,
			118,
			116,
			32,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			102,
			112,
			103,
			109,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			109,
			97,
			120,
			112,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			112,
			114,
			101,
			112,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			103,
			108,
			121,
			102,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			108,
			111,
			99,
			97,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			110,
			97,
			109,
			101,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			99,
			109,
			97,
			112,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0
		};

		// Token: 0x040016BC RID: 5820
		private static int b = 32768;

		// Token: 0x040016BD RID: 5821
		private int c;

		// Token: 0x040016BE RID: 5822
		private int d = 188;

		// Token: 0x040016BF RID: 5823
		private int e = ad8.b;

		// Token: 0x040016C0 RID: 5824
		private byte[] f = new byte[ad8.b];

		// Token: 0x040016C1 RID: 5825
		private bool[] g;

		// Token: 0x040016C2 RID: 5826
		private int[] h;

		// Token: 0x040016C3 RID: 5827
		private static byte[] i = new byte[]
		{
			76,
			101,
			110,
			103,
			116,
			104
		};

		// Token: 0x040016C4 RID: 5828
		private static byte[] j = new byte[]
		{
			70,
			105,
			108,
			116,
			101,
			114
		};

		// Token: 0x040016C5 RID: 5829
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

		// Token: 0x040016C6 RID: 5830
		private static byte[] l = new byte[]
		{
			76,
			101,
			110,
			103,
			116,
			104,
			49
		};
	}
}
