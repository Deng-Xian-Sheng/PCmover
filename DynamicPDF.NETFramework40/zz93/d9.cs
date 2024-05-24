using System;

namespace zz93
{
	// Token: 0x020000B9 RID: 185
	internal class d9 : d0
	{
		// Token: 0x060008EC RID: 2284 RVA: 0x0007A05C File Offset: 0x0007905C
		internal d9(kg A_0, ij A_1)
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

		// Token: 0x060008ED RID: 2285 RVA: 0x0007A140 File Offset: 0x00079140
		internal override int cn()
		{
			return 142298369;
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x0007A158 File Offset: 0x00079158
		internal override string co()
		{
			return "address";
		}
	}
}
