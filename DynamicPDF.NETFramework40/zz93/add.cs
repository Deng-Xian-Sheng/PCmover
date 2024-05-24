using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000466 RID: 1126
	internal class add
	{
		// Token: 0x06002EDB RID: 11995 RVA: 0x001AA720 File Offset: 0x001A9720
		internal add(bool[] A_0)
		{
			this.e = A_0;
			this.f = new int[A_0.Length];
			ushort num = 0;
			while ((int)num < this.f.Length)
			{
				this.f[(int)num] = -1;
				num += 1;
			}
		}

		// Token: 0x06002EDC RID: 11996 RVA: 0x001AA790 File Offset: 0x001A9790
		internal void a(DocumentWriter A_0)
		{
			A_0.WriteBeginObject();
			A_0.WriteDictionaryOpen();
			A_0.WriteName(add.g);
			A_0.WriteReference(A_0.GetObjectNumber(1));
			A_0.WriteName(add.h);
			A_0.WriteName(add.i);
			A_0.WriteName(add.j);
			A_0.WriteName("CIDFontType0C");
			A_0.WriteDictionaryClose();
			int value = A_0.WriteStreamWithCompression(this.d, this.d.Length);
			A_0.WriteEndObject();
			A_0.WriteBeginObject();
			A_0.WriteNumber(value);
			A_0.WriteEndObject();
		}

		// Token: 0x06002EDD RID: 11997 RVA: 0x001AA830 File Offset: 0x001A9830
		internal void a()
		{
			this.c *= 4;
			byte[] array = new byte[this.c];
			this.d.CopyTo(array, 0);
			this.d = array;
		}

		// Token: 0x06002EDE RID: 11998 RVA: 0x001AA870 File Offset: 0x001A9870
		internal void a(int A_0)
		{
			while (this.c - this.b < A_0)
			{
				this.a();
			}
		}

		// Token: 0x06002EDF RID: 11999 RVA: 0x001AA8A0 File Offset: 0x001A98A0
		internal void b(int A_0)
		{
			this.a(2);
			this.d[this.b++] = (byte)(A_0 >> 8);
			this.d[this.b++] = (byte)A_0;
		}

		// Token: 0x06002EE0 RID: 12000 RVA: 0x001AA8EC File Offset: 0x001A98EC
		internal void a(byte A_0)
		{
			this.a(1);
			this.d[this.b++] = A_0;
		}

		// Token: 0x06002EE1 RID: 12001 RVA: 0x001AA91B File Offset: 0x001A991B
		internal void a(byte[] A_0)
		{
			this.a(A_0.Length);
			Array.Copy(A_0, 0, this.d, this.b, A_0.Length);
			this.b += A_0.Length;
		}

		// Token: 0x06002EE2 RID: 12002 RVA: 0x001AA94F File Offset: 0x001A994F
		internal void a(byte[] A_0, int A_1, int A_2)
		{
			this.a(A_2);
			Array.Copy(A_0, A_1, this.d, this.b, A_2);
			this.b += A_2;
		}

		// Token: 0x06002EE3 RID: 12003 RVA: 0x001AA980 File Offset: 0x001A9980
		internal bool[] b()
		{
			return this.e;
		}

		// Token: 0x04001641 RID: 5697
		private static int a = 32768;

		// Token: 0x04001642 RID: 5698
		private int b = 0;

		// Token: 0x04001643 RID: 5699
		private int c = add.a;

		// Token: 0x04001644 RID: 5700
		private byte[] d = new byte[add.a];

		// Token: 0x04001645 RID: 5701
		private bool[] e;

		// Token: 0x04001646 RID: 5702
		private int[] f;

		// Token: 0x04001647 RID: 5703
		private static byte[] g = new byte[]
		{
			76,
			101,
			110,
			103,
			116,
			104
		};

		// Token: 0x04001648 RID: 5704
		private static byte[] h = new byte[]
		{
			70,
			105,
			108,
			116,
			101,
			114
		};

		// Token: 0x04001649 RID: 5705
		private static byte[] i = new byte[]
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

		// Token: 0x0400164A RID: 5706
		private static byte[] j = new byte[]
		{
			83,
			117,
			98,
			116,
			121,
			112,
			101
		};
	}
}
