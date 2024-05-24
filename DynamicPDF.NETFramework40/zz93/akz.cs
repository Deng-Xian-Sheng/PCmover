using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200057E RID: 1406
	internal class akz
	{
		// Token: 0x060037A5 RID: 14245 RVA: 0x001E09C9 File Offset: 0x001DF9C9
		internal akz()
		{
		}

		// Token: 0x060037A6 RID: 14246 RVA: 0x001E09DC File Offset: 0x001DF9DC
		internal void a(ald A_0)
		{
			while (A_0.x() != 616326873)
			{
				int num = A_0.x();
				if (num != 12720613)
				{
					if (num == 848759750)
					{
						alh alh = new alh();
						alh.a(A_0);
						this.a(alh);
						A_0.aa();
						A_0.aa();
					}
				}
				else
				{
					ak9 ak = new ak9();
					ak.b(A_0);
					this.a(ak);
				}
			}
		}

		// Token: 0x060037A7 RID: 14247 RVA: 0x001E0A5C File Offset: 0x001DFA5C
		internal void a(DocumentLayoutPartList A_0)
		{
			for (aky aky = this.a; aky != null; aky = aky.m())
			{
				aky.my(A_0);
			}
			A_0.b();
		}

		// Token: 0x060037A8 RID: 14248 RVA: 0x001E0A98 File Offset: 0x001DFA98
		internal int a()
		{
			return this.c;
		}

		// Token: 0x060037A9 RID: 14249 RVA: 0x001E0AB0 File Offset: 0x001DFAB0
		private void a(aky A_0)
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

		// Token: 0x04001A5E RID: 6750
		private aky a;

		// Token: 0x04001A5F RID: 6751
		private aky b;

		// Token: 0x04001A60 RID: 6752
		private int c = 0;
	}
}
