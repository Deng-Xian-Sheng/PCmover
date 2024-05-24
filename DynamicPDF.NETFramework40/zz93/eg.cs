using System;

namespace zz93
{
	// Token: 0x020000C0 RID: 192
	internal class eg : d0
	{
		// Token: 0x0600090C RID: 2316 RVA: 0x0007ABC0 File Offset: 0x00079BC0
		internal eg(kg A_0, ij A_1)
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

		// Token: 0x0600090D RID: 2317 RVA: 0x0007ACA4 File Offset: 0x00079CA4
		internal override int cn()
		{
			return 46574465;
		}

		// Token: 0x0600090E RID: 2318 RVA: 0x0007ACBC File Offset: 0x00079CBC
		internal override string co()
		{
			return "blockquote";
		}
	}
}
