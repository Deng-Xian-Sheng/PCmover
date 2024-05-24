using System;

namespace zz93
{
	// Token: 0x02000255 RID: 597
	internal class pn : d0
	{
		// Token: 0x06001B41 RID: 6977 RVA: 0x00119D54 File Offset: 0x00118D54
		internal pn()
		{
		}

		// Token: 0x06001B42 RID: 6978 RVA: 0x00119D60 File Offset: 0x00118D60
		internal pn(kg A_0, ij A_1)
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

		// Token: 0x06001B43 RID: 6979 RVA: 0x00119E44 File Offset: 0x00118E44
		internal override int cn()
		{
			return 9705568;
		}

		// Token: 0x06001B44 RID: 6980 RVA: 0x00119E5C File Offset: 0x00118E5C
		internal override string co()
		{
			return "span";
		}
	}
}
