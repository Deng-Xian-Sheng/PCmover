using System;

namespace zz93
{
	// Token: 0x02000186 RID: 390
	internal class jy : d0
	{
		// Token: 0x06000DB8 RID: 3512 RVA: 0x0009B36C File Offset: 0x0009A36C
		internal jy(kg A_0, ij A_1)
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

		// Token: 0x06000DB9 RID: 3513 RVA: 0x0009B450 File Offset: 0x0009A450
		internal override int cn()
		{
			return 899925938;
		}

		// Token: 0x06000DBA RID: 3514 RVA: 0x0009B468 File Offset: 0x0009A468
		internal override string co()
		{
			return "fieldset";
		}
	}
}
