using System;
using System.IO;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020003DA RID: 986
	internal class zt : zq, zr
	{
		// Token: 0x0600295C RID: 10588 RVA: 0x001836B6 File Offset: 0x001826B6
		internal zt(byte[] A_0, int A_1, int A_2)
		{
			this.c = A_0;
			this.d = A_1;
			this.e = A_2;
		}

		// Token: 0x0600295D RID: 10589 RVA: 0x001836E4 File Offset: 0x001826E4
		void zr.a(b3 A_0, int A_1)
		{
			this.g = A_0.j();
			this.f = A_1;
		}

		// Token: 0x0600295E RID: 10590 RVA: 0x001836FC File Offset: 0x001826FC
		internal override void g7(Stream A_0)
		{
			A_0.Write(zt.a, 0, zt.a.Length);
			this.g.Reset(this.f);
			this.g.Encrypt(A_0, this.c, this.d, this.e);
			A_0.Write(zt.b, 0, zt.b.Length);
		}

		// Token: 0x0600295F RID: 10591 RVA: 0x00183764 File Offset: 0x00182764
		internal override int g8()
		{
			int result;
			if (this.g.v() == b5.b)
			{
				int num = this.e + 16 + (16 - this.e % 16);
				result = num + 17;
			}
			else
			{
				result = this.e + 17;
			}
			return result;
		}

		// Token: 0x040012B5 RID: 4789
		private static byte[] a = new byte[]
		{
			115,
			116,
			114,
			101,
			97,
			109,
			10
		};

		// Token: 0x040012B6 RID: 4790
		private static byte[] b = new byte[]
		{
			10,
			101,
			110,
			100,
			115,
			116,
			114,
			101,
			97,
			109
		};

		// Token: 0x040012B7 RID: 4791
		private byte[] c;

		// Token: 0x040012B8 RID: 4792
		private int d;

		// Token: 0x040012B9 RID: 4793
		private int e;

		// Token: 0x040012BA RID: 4794
		private int f = -1;

		// Token: 0x040012BB RID: 4795
		private Encrypter g = null;
	}
}
