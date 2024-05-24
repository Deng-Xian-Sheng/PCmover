using System;
using System.IO;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000057 RID: 87
	internal class bv : bp
	{
		// Token: 0x060002E8 RID: 744 RVA: 0x0003F6A4 File Offset: 0x0003E6A4
		internal bv(bp A_0, bp A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x0003F6C0 File Offset: 0x0003E6C0
		internal override bool o()
		{
			return false;
		}

		// Token: 0x060002EA RID: 746 RVA: 0x0003F6D3 File Offset: 0x0003E6D3
		internal override void p(Stream A_0)
		{
			this.a.p(A_0);
			this.b.p(A_0);
		}

		// Token: 0x060002EB RID: 747 RVA: 0x0003F6F0 File Offset: 0x0003E6F0
		internal override void q(Stream A_0, Encrypter A_1)
		{
			if (A_1 is bz || A_1 is b0)
			{
				byte[] array = new byte[this.s()];
				this.r(array, 0);
				A_1.Encrypt(A_0, array, 0, array.Length);
			}
			else
			{
				this.a.q(A_0, A_1);
				this.b.q(A_0, A_1);
			}
		}

		// Token: 0x060002EC RID: 748 RVA: 0x0003F75E File Offset: 0x0003E75E
		internal override void r(byte[] A_0, int A_1)
		{
			this.a.r(A_0, A_1);
			this.b.r(A_0, A_1 + this.a.s());
		}

		// Token: 0x060002ED RID: 749 RVA: 0x0003F78C File Offset: 0x0003E78C
		internal override int s()
		{
			return this.a.s() + this.b.s();
		}

		// Token: 0x04000201 RID: 513
		private bp a;

		// Token: 0x04000202 RID: 514
		private bp b;
	}
}
