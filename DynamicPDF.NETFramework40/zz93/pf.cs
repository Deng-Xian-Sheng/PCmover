using System;

namespace zz93
{
	// Token: 0x0200024D RID: 589
	internal class pf : d0
	{
		// Token: 0x06001AEB RID: 6891 RVA: 0x00117420 File Offset: 0x00116420
		internal pf(kg A_0, ij A_1)
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

		// Token: 0x06001AEC RID: 6892 RVA: 0x00117504 File Offset: 0x00116504
		internal override int cn()
		{
			return 8736864;
		}

		// Token: 0x06001AED RID: 6893 RVA: 0x0011751C File Offset: 0x0011651C
		internal override string co()
		{
			return "samp";
		}
	}
}
