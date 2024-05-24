using System;
using System.IO;

namespace zz93
{
	// Token: 0x020003EC RID: 1004
	internal class aab : zq
	{
		// Token: 0x06002A03 RID: 10755 RVA: 0x001872CA File Offset: 0x001862CA
		internal aab(bp A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06002A04 RID: 10756 RVA: 0x001872DC File Offset: 0x001862DC
		internal override void g7(Stream A_0)
		{
			A_0.Write(aab.a, 0, aab.a.Length);
			this.c.p(A_0);
			A_0.Write(aab.b, 0, aab.b.Length);
		}

		// Token: 0x06002A05 RID: 10757 RVA: 0x00187314 File Offset: 0x00186314
		internal override int g8()
		{
			return this.c.s() + 17;
		}

		// Token: 0x0400133B RID: 4923
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

		// Token: 0x0400133C RID: 4924
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

		// Token: 0x0400133D RID: 4925
		private bp c;
	}
}
