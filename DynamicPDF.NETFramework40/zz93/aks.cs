using System;

namespace zz93
{
	// Token: 0x02000577 RID: 1399
	internal class aks
	{
		// Token: 0x0600377D RID: 14205 RVA: 0x001DFBC0 File Offset: 0x001DEBC0
		internal aks(ald A_0, int A_1)
		{
			do
			{
				this.a(new akr(A_0, A_1 == 1006130397));
			}
			while (A_0.x() == A_1);
		}

		// Token: 0x0600377E RID: 14206 RVA: 0x001DFC10 File Offset: 0x001DEC10
		internal int a()
		{
			return this.c;
		}

		// Token: 0x0600377F RID: 14207 RVA: 0x001DFC28 File Offset: 0x001DEC28
		internal akr b()
		{
			return this.a;
		}

		// Token: 0x06003780 RID: 14208 RVA: 0x001DFC40 File Offset: 0x001DEC40
		private void a(akr A_0)
		{
			if (this.a == null)
			{
				this.b = A_0;
				this.a = A_0;
			}
			else
			{
				this.b.a(A_0);
				this.b = A_0;
			}
			this.c++;
		}

		// Token: 0x04001A4A RID: 6730
		private akr a = null;

		// Token: 0x04001A4B RID: 6731
		private akr b = null;

		// Token: 0x04001A4C RID: 6732
		private int c = 0;
	}
}
