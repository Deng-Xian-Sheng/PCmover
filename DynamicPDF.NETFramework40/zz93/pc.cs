using System;

namespace zz93
{
	// Token: 0x0200024A RID: 586
	internal class pc : d0
	{
		// Token: 0x06001AD5 RID: 6869 RVA: 0x00116D64 File Offset: 0x00115D64
		internal pc(kg A_0, ij A_1)
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

		// Token: 0x06001AD6 RID: 6870 RVA: 0x00116E48 File Offset: 0x00115E48
		internal override int cn()
		{
			return 28;
		}

		// Token: 0x06001AD7 RID: 6871 RVA: 0x00116E5C File Offset: 0x00115E5C
		internal override string co()
		{
			return "q";
		}
	}
}
