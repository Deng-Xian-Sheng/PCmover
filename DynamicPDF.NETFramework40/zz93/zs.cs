using System;
using System.IO;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020003D9 RID: 985
	internal class zs : zq, zr
	{
		// Token: 0x06002957 RID: 10583 RVA: 0x00183593 File Offset: 0x00182593
		internal zs(bp A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06002958 RID: 10584 RVA: 0x001835B3 File Offset: 0x001825B3
		void zr.a(b3 A_0, int A_1)
		{
			this.e = A_0.j();
			this.d = A_1;
		}

		// Token: 0x06002959 RID: 10585 RVA: 0x001835CC File Offset: 0x001825CC
		internal override void g7(Stream A_0)
		{
			A_0.Write(zs.a, 0, zs.a.Length);
			this.e.Reset(this.d);
			this.c.q(A_0, this.e);
			A_0.Write(zs.b, 0, zs.b.Length);
		}

		// Token: 0x0600295A RID: 10586 RVA: 0x00183628 File Offset: 0x00182628
		internal override int g8()
		{
			int result;
			if (this.e.v() == b5.b)
			{
				int num = this.c.s() + 16 + (16 - this.c.s() % 16);
				result = num + 17;
			}
			else
			{
				result = this.c.s() + 17;
			}
			return result;
		}

		// Token: 0x040012B0 RID: 4784
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

		// Token: 0x040012B1 RID: 4785
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

		// Token: 0x040012B2 RID: 4786
		private bp c;

		// Token: 0x040012B3 RID: 4787
		private int d = -1;

		// Token: 0x040012B4 RID: 4788
		private Encrypter e = null;
	}
}
