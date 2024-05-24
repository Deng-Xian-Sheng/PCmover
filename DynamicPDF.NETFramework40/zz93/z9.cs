using System;
using System.IO;

namespace zz93
{
	// Token: 0x020003EA RID: 1002
	internal class z9 : zq
	{
		// Token: 0x060029FA RID: 10746 RVA: 0x00186E60 File Offset: 0x00185E60
		internal z9(zz A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060029FB RID: 10747 RVA: 0x00186E72 File Offset: 0x00185E72
		internal override void g7(Stream A_0)
		{
			this.b.b(A_0);
			A_0.Write(z9.a, 0, z9.a.Length);
		}

		// Token: 0x060029FC RID: 10748 RVA: 0x00186E98 File Offset: 0x00185E98
		internal zz a()
		{
			return this.b;
		}

		// Token: 0x060029FD RID: 10749 RVA: 0x00186EB0 File Offset: 0x00185EB0
		internal override int g8()
		{
			return this.b.e() + 4;
		}

		// Token: 0x04001332 RID: 4914
		private static byte[] a = new byte[]
		{
			32,
			48,
			32,
			82
		};

		// Token: 0x04001333 RID: 4915
		private zz b;
	}
}
