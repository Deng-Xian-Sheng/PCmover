using System;
using System.IO;

namespace zz93
{
	// Token: 0x020003ED RID: 1005
	internal class aac : zq
	{
		// Token: 0x06002A07 RID: 10759 RVA: 0x00187363 File Offset: 0x00186363
		internal aac(byte[] A_0, int A_1, int A_2)
		{
			this.c = A_0;
			this.d = A_1;
			this.e = A_2;
		}

		// Token: 0x06002A08 RID: 10760 RVA: 0x00187384 File Offset: 0x00186384
		internal override void g7(Stream A_0)
		{
			A_0.Write(aac.a, 0, aac.a.Length);
			A_0.Write(this.c, this.d, this.e);
			A_0.Write(aac.b, 0, aac.b.Length);
		}

		// Token: 0x06002A09 RID: 10761 RVA: 0x001873D4 File Offset: 0x001863D4
		internal override int g8()
		{
			return this.e + 17;
		}

		// Token: 0x0400133E RID: 4926
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

		// Token: 0x0400133F RID: 4927
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

		// Token: 0x04001340 RID: 4928
		private byte[] c;

		// Token: 0x04001341 RID: 4929
		private int d;

		// Token: 0x04001342 RID: 4930
		private int e;
	}
}
