using System;

namespace zz93
{
	// Token: 0x020000D6 RID: 214
	internal class e2 : d0
	{
		// Token: 0x060009AB RID: 2475 RVA: 0x0007ED18 File Offset: 0x0007DD18
		internal e2(kg A_0, ij A_1)
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

		// Token: 0x060009AC RID: 2476 RVA: 0x0007EDFC File Offset: 0x0007DDFC
		internal override int cn()
		{
			return 2315845;
		}

		// Token: 0x060009AD RID: 2477 RVA: 0x0007EE14 File Offset: 0x0007DE14
		internal override string co()
		{
			return "code";
		}
	}
}
