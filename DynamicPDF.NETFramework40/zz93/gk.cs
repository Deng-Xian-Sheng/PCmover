using System;

namespace zz93
{
	// Token: 0x0200010C RID: 268
	internal abstract class gk
	{
		// Token: 0x06000B15 RID: 2837 RVA: 0x00089C78 File Offset: 0x00088C78
		internal static void a(gi A_0, ig[] A_1)
		{
			int num = 0;
			while (A_0.ad() && num != -1)
			{
				num = A_0.z();
				int num2 = A_0.aa();
				if (num != -1 && num2 > 0)
				{
					int a_ = num2 - num;
					foreach (ig ig in A_1)
					{
						ig.a(new ic(A_0.n(), num, a_));
					}
				}
			}
		}
	}
}
