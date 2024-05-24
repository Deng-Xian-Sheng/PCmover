using System;

namespace zz93
{
	// Token: 0x020000E0 RID: 224
	internal class fc
	{
		// Token: 0x060009E7 RID: 2535 RVA: 0x0008044A File Offset: 0x0007F44A
		internal fc(int A_0, fd A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x060009E8 RID: 2536 RVA: 0x00080464 File Offset: 0x0007F464
		internal int a()
		{
			return this.a;
		}

		// Token: 0x060009E9 RID: 2537 RVA: 0x0008047C File Offset: 0x0007F47C
		internal void a(int A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060009EA RID: 2538 RVA: 0x00080488 File Offset: 0x0007F488
		internal fd b()
		{
			return this.b;
		}

		// Token: 0x060009EB RID: 2539 RVA: 0x000804A0 File Offset: 0x0007F4A0
		internal void a(fd A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060009EC RID: 2540 RVA: 0x000804AC File Offset: 0x0007F4AC
		internal static fc a(fc[] A_0, int A_1, int A_2)
		{
			for (int i = 0; i < A_1; i++)
			{
				if (A_0[i] != null && A_0[i].a() == A_2)
				{
					return A_0[i];
				}
			}
			return null;
		}

		// Token: 0x04000503 RID: 1283
		private int a;

		// Token: 0x04000504 RID: 1284
		private fd b;
	}
}
