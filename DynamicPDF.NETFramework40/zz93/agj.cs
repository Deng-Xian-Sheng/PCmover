using System;
using System.IO;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020004DA RID: 1242
	internal class agj : bp
	{
		// Token: 0x060032AD RID: 12973 RVA: 0x001C456F File Offset: 0x001C356F
		internal agj(agk A_0, long A_1, int A_2)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
		}

		// Token: 0x060032AE RID: 12974 RVA: 0x001C4590 File Offset: 0x001C3590
		internal override bool o()
		{
			return true;
		}

		// Token: 0x060032AF RID: 12975 RVA: 0x001C45A4 File Offset: 0x001C35A4
		internal override void p(Stream A_0)
		{
			byte[] buffer = this.a.a(this.b, this.c);
			A_0.Write(buffer, 0, this.c);
		}

		// Token: 0x060032B0 RID: 12976 RVA: 0x001C45DC File Offset: 0x001C35DC
		internal override void q(Stream A_0, Encrypter A_1)
		{
			byte[] data = this.a.a(this.b, this.c);
			A_1.Encrypt(A_0, data, 0, this.c);
		}

		// Token: 0x060032B1 RID: 12977 RVA: 0x001C4612 File Offset: 0x001C3612
		internal override void r(byte[] A_0, int A_1)
		{
			this.a.a(this.b, this.c, A_0, A_1);
		}

		// Token: 0x060032B2 RID: 12978 RVA: 0x001C4630 File Offset: 0x001C3630
		internal override int s()
		{
			return this.c;
		}

		// Token: 0x04001849 RID: 6217
		private agk a;

		// Token: 0x0400184A RID: 6218
		private long b;

		// Token: 0x0400184B RID: 6219
		private int c;
	}
}
