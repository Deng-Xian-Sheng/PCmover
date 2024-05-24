using System;
using System.IO;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020004D8 RID: 1240
	internal class agh : bp
	{
		// Token: 0x060032A2 RID: 12962 RVA: 0x001C428F File Offset: 0x001C328F
		internal agh(agk A_0, long A_1, int A_2)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
		}

		// Token: 0x060032A3 RID: 12963 RVA: 0x001C42B0 File Offset: 0x001C32B0
		internal override bool o()
		{
			return false;
		}

		// Token: 0x060032A4 RID: 12964 RVA: 0x001C42C4 File Offset: 0x001C32C4
		internal override void p(Stream A_0)
		{
			byte[] buffer = this.a.a(this.b, this.c);
			A_0.Write(buffer, 0, this.c);
		}

		// Token: 0x060032A5 RID: 12965 RVA: 0x001C42FC File Offset: 0x001C32FC
		internal override void q(Stream A_0, Encrypter A_1)
		{
			byte[] data = this.a.a(this.b, this.c);
			A_1.Encrypt(A_0, data, 0, this.c);
		}

		// Token: 0x060032A6 RID: 12966 RVA: 0x001C4332 File Offset: 0x001C3332
		internal override void r(byte[] A_0, int A_1)
		{
			this.a.a(this.b, this.c, A_0, A_1);
		}

		// Token: 0x060032A7 RID: 12967 RVA: 0x001C4350 File Offset: 0x001C3350
		internal override int s()
		{
			return this.c;
		}

		// Token: 0x04001840 RID: 6208
		private agk a;

		// Token: 0x04001841 RID: 6209
		private long b;

		// Token: 0x04001842 RID: 6210
		private int c;
	}
}
