using System;
using System.IO;

namespace zz93
{
	// Token: 0x020003A4 RID: 932
	internal abstract class ye
	{
		// Token: 0x060027A8 RID: 10152 RVA: 0x0016BA78 File Offset: 0x0016AA78
		protected ye(Stream A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060027A9 RID: 10153
		internal abstract ushort gt(uint A_0);

		// Token: 0x060027AA RID: 10154
		internal abstract uint gu(uint A_0);

		// Token: 0x060027AB RID: 10155
		internal abstract ushort gv(byte[] A_0, uint A_1);

		// Token: 0x060027AC RID: 10156
		internal abstract uint gw(byte[] A_0, uint A_1);

		// Token: 0x060027AD RID: 10157 RVA: 0x0016BA8C File Offset: 0x0016AA8C
		protected void a(uint A_0)
		{
			if (this.a().Position != (long)((ulong)A_0))
			{
				this.a().Seek((long)((ulong)A_0), SeekOrigin.Begin);
			}
		}

		// Token: 0x060027AE RID: 10158 RVA: 0x0016BABC File Offset: 0x0016AABC
		internal byte[] a(uint A_0, uint A_1)
		{
			return this.a(A_0, (int)A_1);
		}

		// Token: 0x060027AF RID: 10159 RVA: 0x0016BAD8 File Offset: 0x0016AAD8
		internal byte[] a(uint A_0, int A_1)
		{
			this.a(A_0);
			byte[] array = new byte[A_1];
			this.a.Read(array, 0, A_1);
			return array;
		}

		// Token: 0x060027B0 RID: 10160 RVA: 0x0016BB09 File Offset: 0x0016AB09
		internal void a(uint A_0, byte[] A_1, int A_2, int A_3)
		{
			this.a(A_0);
			this.a.Read(A_1, A_2, A_3);
		}

		// Token: 0x060027B1 RID: 10161 RVA: 0x0016BB24 File Offset: 0x0016AB24
		internal Stream a()
		{
			return this.a;
		}

		// Token: 0x0400112B RID: 4395
		private Stream a;
	}
}
