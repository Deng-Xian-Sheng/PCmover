using System;

namespace zz93
{
	// Token: 0x0200027E RID: 638
	internal class qs : d0
	{
		// Token: 0x06001C71 RID: 7281 RVA: 0x00124B90 File Offset: 0x00123B90
		internal qs(kg A_0, ij A_1)
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

		// Token: 0x06001C72 RID: 7282 RVA: 0x00124C74 File Offset: 0x00123C74
		internal override int cn()
		{
			return 35;
		}

		// Token: 0x06001C73 RID: 7283 RVA: 0x00124C88 File Offset: 0x00123C88
		internal override string co()
		{
			return "u";
		}
	}
}
