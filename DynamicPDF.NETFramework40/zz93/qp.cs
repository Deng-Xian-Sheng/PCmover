using System;

namespace zz93
{
	// Token: 0x0200027B RID: 635
	internal class qp : e8
	{
		// Token: 0x06001C61 RID: 7265 RVA: 0x00124588 File Offset: 0x00123588
		internal qp(kg A_0, ij A_1)
		{
			while (!A_0.aj())
			{
				int num = A_0.al();
				if (num <= 188645405)
				{
					if (num != 3407)
					{
						if (num != 144877216)
						{
							if (num != 188645405)
							{
								goto IL_11C;
							}
							base.b(A_0);
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
				else if (num != 545266181)
				{
					if (num != 623704577)
					{
						if (num != 677666251)
						{
							goto IL_11C;
						}
						if (this.a == null)
						{
							this.a = A_0.ao();
						}
					}
					else
					{
						base.a(A_0);
					}
				}
				else if (base.l() == null)
				{
					base.a(A_0.am());
				}
				continue;
				IL_11C:
				base.c(A_0);
			}
			A_0.ax();
		}

		// Token: 0x06001C62 RID: 7266 RVA: 0x001246D4 File Offset: 0x001236D4
		internal string a()
		{
			return this.a;
		}

		// Token: 0x06001C63 RID: 7267 RVA: 0x001246EC File Offset: 0x001236EC
		internal override int cn()
		{
			return 1946;
		}

		// Token: 0x06001C64 RID: 7268 RVA: 0x00124704 File Offset: 0x00123704
		internal override string co()
		{
			return "tr";
		}

		// Token: 0x04000CC2 RID: 3266
		private new string a = null;
	}
}
