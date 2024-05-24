using System;

namespace zz93
{
	// Token: 0x020001A4 RID: 420
	internal class ks : d0
	{
		// Token: 0x06000EB9 RID: 3769 RVA: 0x000B0664 File Offset: 0x000AF664
		internal ks(kg A_0, ij A_1)
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

		// Token: 0x06000EBA RID: 3770 RVA: 0x000B0748 File Offset: 0x000AF748
		internal override int cn()
		{
			return 15;
		}

		// Token: 0x06000EBB RID: 3771 RVA: 0x000B075C File Offset: 0x000AF75C
		internal override string co()
		{
			return "i";
		}
	}
}
