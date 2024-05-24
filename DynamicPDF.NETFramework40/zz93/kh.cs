using System;

namespace zz93
{
	// Token: 0x02000199 RID: 409
	internal class kh : d0
	{
		// Token: 0x06000E64 RID: 3684 RVA: 0x000A46E1 File Offset: 0x000A36E1
		internal kh()
		{
		}

		// Token: 0x06000E65 RID: 3685 RVA: 0x000A46EC File Offset: 0x000A36EC
		internal kh(kg A_0, ij A_1)
		{
			this.a(A_0, A_1);
		}

		// Token: 0x06000E66 RID: 3686 RVA: 0x000A4700 File Offset: 0x000A3700
		internal void a(kg A_0, ij A_1)
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

		// Token: 0x06000E67 RID: 3687 RVA: 0x000A47DC File Offset: 0x000A37DC
		internal override int cn()
		{
			return 10573487;
		}

		// Token: 0x06000E68 RID: 3688 RVA: 0x000A47F4 File Offset: 0x000A37F4
		internal override string co()
		{
			return "html";
		}
	}
}
