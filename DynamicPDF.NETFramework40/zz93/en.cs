using System;

namespace zz93
{
	// Token: 0x020000C7 RID: 199
	internal class en : d0
	{
		// Token: 0x06000937 RID: 2359 RVA: 0x0007BAEC File Offset: 0x0007AAEC
		internal en(kg A_0, ij A_1)
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

		// Token: 0x06000938 RID: 2360 RVA: 0x0007BBD0 File Offset: 0x0007ABD0
		internal override int cn()
		{
			return 57;
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x0007BBE4 File Offset: 0x0007ABE4
		internal override string co()
		{
			return "b";
		}
	}
}
