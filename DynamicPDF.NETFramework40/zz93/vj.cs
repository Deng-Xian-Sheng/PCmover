using System;

namespace zz93
{
	// Token: 0x02000335 RID: 821
	internal class vj
	{
		// Token: 0x06002365 RID: 9061 RVA: 0x001508A5 File Offset: 0x0014F8A5
		internal vj()
		{
		}

		// Token: 0x06002366 RID: 9062 RVA: 0x001508C8 File Offset: 0x0014F8C8
		internal void a(sz A_0)
		{
			if (this.b == null)
			{
				this.a = (this.b = new vj.a(A_0));
			}
			else
			{
				this.b = (this.b.b = new vj.a(A_0));
			}
			this.c += this.b.a.b();
		}

		// Token: 0x06002367 RID: 9063 RVA: 0x00150938 File Offset: 0x0014F938
		internal int a()
		{
			return this.c;
		}

		// Token: 0x06002368 RID: 9064 RVA: 0x00150950 File Offset: 0x0014F950
		internal vj.a b()
		{
			return this.a;
		}

		// Token: 0x04000F33 RID: 3891
		private vj.a a = null;

		// Token: 0x04000F34 RID: 3892
		private vj.a b = null;

		// Token: 0x04000F35 RID: 3893
		private int c = 0;

		// Token: 0x02000336 RID: 822
		internal class a
		{
			// Token: 0x06002369 RID: 9065 RVA: 0x00150968 File Offset: 0x0014F968
			internal a(sz A_0)
			{
				this.a = A_0;
				this.b = null;
			}

			// Token: 0x04000F36 RID: 3894
			internal sz a;

			// Token: 0x04000F37 RID: 3895
			internal vj.a b;
		}
	}
}
