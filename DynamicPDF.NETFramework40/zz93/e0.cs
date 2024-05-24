using System;

namespace zz93
{
	// Token: 0x020000D4 RID: 212
	internal class e0 : d0
	{
		// Token: 0x0600099E RID: 2462 RVA: 0x0007E8F0 File Offset: 0x0007D8F0
		internal e0(kg A_0, ij A_1)
		{
			while (!A_0.aj())
			{
				int num = A_0.al();
				if (num != 3407)
				{
					if (num != 144877216)
					{
						if (num != 545266181)
						{
							base.c(A_0);
						}
						else if (base.l() == null)
						{
							base.a(A_0.am());
						}
					}
					else if (base.m() == null)
					{
						string text = A_0.au();
						if (text != null)
						{
							base.a(new ig(A_1.a(text.ToCharArray(), 0, text.Length)));
						}
					}
				}
				else if (base.k() == null)
				{
					base.c(A_0.an());
				}
			}
			A_0.ax();
		}

		// Token: 0x0600099F RID: 2463 RVA: 0x0007E9D4 File Offset: 0x0007D9D4
		internal override int cn()
		{
			return 2204613;
		}

		// Token: 0x060009A0 RID: 2464 RVA: 0x0007E9EC File Offset: 0x0007D9EC
		internal override string co()
		{
			return "cite";
		}
	}
}
