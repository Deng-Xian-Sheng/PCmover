using System;

namespace zz93
{
	// Token: 0x0200025D RID: 605
	internal class pv : d0
	{
		// Token: 0x06001B77 RID: 7031 RVA: 0x0011AE80 File Offset: 0x00119E80
		internal pv(kg A_0, ij A_1)
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

		// Token: 0x06001B78 RID: 7032 RVA: 0x0011AF64 File Offset: 0x00119F64
		internal override int cn()
		{
			return 137440;
		}

		// Token: 0x06001B79 RID: 7033 RVA: 0x0011AF7C File Offset: 0x00119F7C
		internal override string co()
		{
			return "sup";
		}
	}
}
