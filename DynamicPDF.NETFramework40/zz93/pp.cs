using System;

namespace zz93
{
	// Token: 0x02000257 RID: 599
	internal class pp : d0
	{
		// Token: 0x06001B50 RID: 6992 RVA: 0x0011A1F8 File Offset: 0x001191F8
		internal pp(kg A_0, ij A_1)
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

		// Token: 0x06001B51 RID: 6993 RVA: 0x0011A2DC File Offset: 0x001192DC
		internal override int cn()
		{
			return 306046640;
		}

		// Token: 0x06001B52 RID: 6994 RVA: 0x0011A2F4 File Offset: 0x001192F4
		internal override string co()
		{
			return "strike";
		}
	}
}
