using System;

namespace zz93
{
	// Token: 0x020000C6 RID: 198
	internal class em : d0
	{
		// Token: 0x06000933 RID: 2355 RVA: 0x0007B9AD File Offset: 0x0007A9AD
		internal em(int A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06000934 RID: 2356 RVA: 0x0007B9CC File Offset: 0x0007A9CC
		internal em(kg A_0, ij A_1)
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

		// Token: 0x06000935 RID: 2357 RVA: 0x0007BABC File Offset: 0x0007AABC
		internal override int cn()
		{
			return this.a;
		}

		// Token: 0x06000936 RID: 2358 RVA: 0x0007BAD4 File Offset: 0x0007AAD4
		internal override string co()
		{
			return "br";
		}

		// Token: 0x040004BE RID: 1214
		private int a = 1977;
	}
}
