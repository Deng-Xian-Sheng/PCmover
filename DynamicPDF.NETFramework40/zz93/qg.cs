using System;

namespace zz93
{
	// Token: 0x02000272 RID: 626
	internal class qg : e8
	{
		// Token: 0x06001C24 RID: 7204 RVA: 0x00121C38 File Offset: 0x00120C38
		internal qg(kg A_0, ij A_1)
		{
			while (!A_0.aj())
			{
				int num = A_0.al();
				if (num <= 144877216)
				{
					if (num != 3407)
					{
						if (num != 144877216)
						{
							goto IL_E9;
						}
						if (base.m() == null)
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
				else if (num != 188645405)
				{
					if (num != 545266181)
					{
						if (num != 623704577)
						{
							goto IL_E9;
						}
						base.a(A_0);
					}
					else if (base.l() == null)
					{
						base.a(A_0.am());
					}
				}
				else
				{
					base.b(A_0);
				}
				continue;
				IL_E9:
				base.c(A_0);
			}
			A_0.ax();
		}

		// Token: 0x06001C25 RID: 7205 RVA: 0x00121D54 File Offset: 0x00120D54
		internal override int cn()
		{
			return 442866842;
		}

		// Token: 0x06001C26 RID: 7206 RVA: 0x00121D6C File Offset: 0x00120D6C
		internal override string co()
		{
			return "tfoot";
		}
	}
}
