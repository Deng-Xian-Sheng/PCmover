using System;

namespace zz93
{
	// Token: 0x020001C7 RID: 455
	internal class lr
	{
		// Token: 0x0600132A RID: 4906 RVA: 0x000DA744 File Offset: 0x000D9744
		internal void a(fb<fo>[] A_0)
		{
			if (A_0 != null)
			{
				int i = 0;
				while (i < A_0.Length)
				{
					int num = A_0[i].a();
					if (num <= 7021096)
					{
						if (num != 136794)
						{
							if (num == 7021096)
							{
								this.d = A_0[i].b().b();
							}
						}
						else
						{
							this.a = A_0[i].b().b();
						}
					}
					else if (num != 426354259)
					{
						if (num == 448574430)
						{
							this.b = A_0[i].b().b();
						}
					}
					else
					{
						this.c = A_0[i].b().b();
					}
					IL_B4:
					i++;
					continue;
					goto IL_B4;
				}
			}
		}

		// Token: 0x0600132B RID: 4907 RVA: 0x000DA818 File Offset: 0x000D9818
		internal x5 a()
		{
			return this.a;
		}

		// Token: 0x0600132C RID: 4908 RVA: 0x000DA830 File Offset: 0x000D9830
		internal x5 b()
		{
			return this.b;
		}

		// Token: 0x0600132D RID: 4909 RVA: 0x000DA848 File Offset: 0x000D9848
		internal x5 c()
		{
			return this.c;
		}

		// Token: 0x0600132E RID: 4910 RVA: 0x000DA860 File Offset: 0x000D9860
		internal x5 d()
		{
			return this.d;
		}

		// Token: 0x04000935 RID: 2357
		private x5 a = x5.c();

		// Token: 0x04000936 RID: 2358
		private x5 b = x5.c();

		// Token: 0x04000937 RID: 2359
		private x5 c = x5.c();

		// Token: 0x04000938 RID: 2360
		private x5 d = x5.c();
	}
}
