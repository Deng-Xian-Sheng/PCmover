using System;

namespace zz93
{
	// Token: 0x0200033D RID: 829
	internal class vq
	{
		// Token: 0x0600238D RID: 9101 RVA: 0x00151790 File Offset: 0x00150790
		internal vq(wd A_0, int A_1)
		{
			do
			{
				this.a(new vp(A_0, A_1 == 1006130397));
			}
			while (A_0.x() == A_1);
		}

		// Token: 0x0600238E RID: 9102 RVA: 0x001517E0 File Offset: 0x001507E0
		internal int a()
		{
			return this.c;
		}

		// Token: 0x0600238F RID: 9103 RVA: 0x001517F8 File Offset: 0x001507F8
		internal vp b()
		{
			return this.a;
		}

		// Token: 0x06002390 RID: 9104 RVA: 0x00151810 File Offset: 0x00150810
		private void a(vp A_0)
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

		// Token: 0x04000F4E RID: 3918
		private vp a = null;

		// Token: 0x04000F4F RID: 3919
		private vp b = null;

		// Token: 0x04000F50 RID: 3920
		private int c = 0;
	}
}
