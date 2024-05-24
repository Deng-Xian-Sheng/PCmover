using System;

namespace zz93
{
	// Token: 0x020000BD RID: 189
	internal class ed : d0
	{
		// Token: 0x06000901 RID: 2305 RVA: 0x0007A6C4 File Offset: 0x000796C4
		internal ed(kg A_0, ij A_1)
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

		// Token: 0x06000902 RID: 2306 RVA: 0x0007A7A8 File Offset: 0x000797A8
		internal override int cn()
		{
			return 46073;
		}

		// Token: 0x06000903 RID: 2307 RVA: 0x0007A7C0 File Offset: 0x000797C0
		internal override string co()
		{
			return "big";
		}
	}
}
