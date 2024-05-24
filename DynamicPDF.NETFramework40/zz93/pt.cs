using System;

namespace zz93
{
	// Token: 0x0200025B RID: 603
	internal class pt : d0
	{
		// Token: 0x06001B6A RID: 7018 RVA: 0x0011AA50 File Offset: 0x00119A50
		internal pt(kg A_0, ij A_1)
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

		// Token: 0x06001B6B RID: 7019 RVA: 0x0011AB34 File Offset: 0x00119B34
		internal override int cn()
		{
			return 235744;
		}

		// Token: 0x06001B6C RID: 7020 RVA: 0x0011AB4C File Offset: 0x00119B4C
		internal override string co()
		{
			return "sub";
		}
	}
}
