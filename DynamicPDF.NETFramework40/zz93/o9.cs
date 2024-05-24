using System;

namespace zz93
{
	// Token: 0x02000247 RID: 583
	internal class o9 : d0
	{
		// Token: 0x06001AC3 RID: 6851 RVA: 0x00116844 File Offset: 0x00115844
		internal o9(kg A_0, ij A_1)
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

		// Token: 0x06001AC4 RID: 6852 RVA: 0x00116928 File Offset: 0x00115928
		internal override int cn()
		{
			return 34721;
		}

		// Token: 0x06001AC5 RID: 6853 RVA: 0x00116940 File Offset: 0x00115940
		internal override string co()
		{
			return "pre";
		}
	}
}
