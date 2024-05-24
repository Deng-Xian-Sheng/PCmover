using System;

namespace zz93
{
	// Token: 0x020001AA RID: 426
	internal class ky : d0
	{
		// Token: 0x06000EDB RID: 3803 RVA: 0x000B1250 File Offset: 0x000B0250
		internal ky(kg A_0, ij A_1)
		{
			while (!A_0.aj())
			{
				int num = A_0.al();
				if (num <= 124530)
				{
					if (num != 3407)
					{
						if (num != 124530)
						{
							goto IL_CC;
						}
					}
					else if (base.k() == null)
					{
						base.c(A_0.an());
					}
				}
				else if (num != 144877216)
				{
					if (num != 545266181)
					{
						goto IL_CC;
					}
					if (base.l() == null)
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
				continue;
				IL_CC:
				base.c(A_0);
			}
			A_0.ax();
		}

		// Token: 0x06000EDC RID: 3804 RVA: 0x000B134C File Offset: 0x000B034C
		internal override int cn()
		{
			return 673419368;
		}

		// Token: 0x06000EDD RID: 3805 RVA: 0x000B1364 File Offset: 0x000B0364
		internal override string co()
		{
			return "label";
		}
	}
}
