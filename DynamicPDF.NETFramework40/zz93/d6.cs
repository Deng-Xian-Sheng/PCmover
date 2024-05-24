using System;

namespace zz93
{
	// Token: 0x020000B6 RID: 182
	internal class d6 : d0
	{
		// Token: 0x060008E0 RID: 2272 RVA: 0x00079B6C File Offset: 0x00078B6C
		internal d6(kg A_0, ij A_1)
		{
			while (!A_0.aj())
			{
				int num = A_0.al();
				if (num <= 144810970)
				{
					if (num != 3407)
					{
						if (num != 144810970)
						{
							goto IL_F2;
						}
						if (this.a == null)
						{
							this.a = A_0.ao();
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
						goto IL_F2;
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
				IL_F2:
				base.c(A_0);
			}
			A_0.ax();
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x00079C90 File Offset: 0x00078C90
		internal string a()
		{
			return this.a;
		}

		// Token: 0x060008E2 RID: 2274 RVA: 0x00079CA8 File Offset: 0x00078CA8
		internal override int cn()
		{
			return 627436437;
		}

		// Token: 0x060008E3 RID: 2275 RVA: 0x00079CC0 File Offset: 0x00078CC0
		internal override string co()
		{
			return "acronym";
		}

		// Token: 0x0400049C RID: 1180
		private string a = null;
	}
}
