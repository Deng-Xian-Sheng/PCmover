using System;

namespace zz93
{
	// Token: 0x02000177 RID: 375
	internal class jj : d0
	{
		// Token: 0x06000D78 RID: 3448 RVA: 0x00099244 File Offset: 0x00098244
		internal jj(kg A_0, ij A_1)
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

		// Token: 0x06000D79 RID: 3449 RVA: 0x00099328 File Offset: 0x00098328
		internal override int cn()
		{
			return 154805;
		}

		// Token: 0x06000D7A RID: 3450 RVA: 0x00099340 File Offset: 0x00098340
		internal override string co()
		{
			return "dfn";
		}
	}
}
