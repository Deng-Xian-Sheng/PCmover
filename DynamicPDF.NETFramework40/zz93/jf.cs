using System;

namespace zz93
{
	// Token: 0x02000173 RID: 371
	internal class jf : d0
	{
		// Token: 0x06000D64 RID: 3428 RVA: 0x00098A10 File Offset: 0x00097A10
		internal jf(kg A_0, ij A_1)
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

		// Token: 0x06000D65 RID: 3429 RVA: 0x00098AF4 File Offset: 0x00097AF4
		internal override int cn()
		{
			return 3445;
		}

		// Token: 0x06000D66 RID: 3430 RVA: 0x00098B0C File Offset: 0x00097B0C
		internal override string co()
		{
			return "dd";
		}
	}
}
