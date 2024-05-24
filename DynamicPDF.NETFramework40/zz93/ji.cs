using System;

namespace zz93
{
	// Token: 0x02000176 RID: 374
	internal class ji : d0
	{
		// Token: 0x06000D75 RID: 3445 RVA: 0x00099130 File Offset: 0x00098130
		internal ji(kg A_0, ij A_1)
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

		// Token: 0x06000D76 RID: 3446 RVA: 0x00099214 File Offset: 0x00098214
		internal override int cn()
		{
			return 164405;
		}

		// Token: 0x06000D77 RID: 3447 RVA: 0x0009922C File Offset: 0x0009822C
		internal override string co()
		{
			return "del";
		}
	}
}
