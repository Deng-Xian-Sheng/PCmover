using System;

namespace zz93
{
	// Token: 0x02000267 RID: 615
	internal class p5 : e8
	{
		// Token: 0x06001BCC RID: 7116 RVA: 0x0011E8B4 File Offset: 0x0011D8B4
		internal p5(kg A_0, ij A_1)
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

		// Token: 0x06001BCD RID: 7117 RVA: 0x0011E9D0 File Offset: 0x0011D9D0
		internal override int cn()
		{
			return 718642778;
		}

		// Token: 0x06001BCE RID: 7118 RVA: 0x0011E9E8 File Offset: 0x0011D9E8
		internal override string co()
		{
			return "tbody";
		}
	}
}
