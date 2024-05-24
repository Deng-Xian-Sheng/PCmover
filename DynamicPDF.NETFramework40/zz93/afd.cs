using System;
using System.IO;

namespace zz93
{
	// Token: 0x020004B0 RID: 1200
	internal class afd : zq
	{
		// Token: 0x06003183 RID: 12675 RVA: 0x001BBAEC File Offset: 0x001BAAEC
		internal afd(agx A_0, int A_1)
		{
			this.a = A_0;
			this.b = A_0.ac();
			this.c = A_1;
		}

		// Token: 0x06003184 RID: 12676 RVA: 0x001BBB14 File Offset: 0x001BAB14
		internal override void g7(Stream A_0)
		{
			A_0.Write(aff.a, 0, aff.a.Length);
			this.a.a(this.b);
			this.a.a(A_0, this.c);
			A_0.Write(aff.b, 0, aff.b.Length);
		}

		// Token: 0x06003185 RID: 12677 RVA: 0x001BBB70 File Offset: 0x001BAB70
		internal override int g8()
		{
			return this.c + 17;
		}

		// Token: 0x04001717 RID: 5911
		private agx a;

		// Token: 0x04001718 RID: 5912
		private long b;

		// Token: 0x04001719 RID: 5913
		private int c;
	}
}
