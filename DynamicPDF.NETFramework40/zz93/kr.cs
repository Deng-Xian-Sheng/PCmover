using System;

namespace zz93
{
	// Token: 0x020001A3 RID: 419
	internal class kr : d0
	{
		// Token: 0x06000EB6 RID: 3766 RVA: 0x000B0550 File Offset: 0x000AF550
		internal kr(kg A_0, ij A_1)
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

		// Token: 0x06000EB7 RID: 3767 RVA: 0x000B0634 File Offset: 0x000AF634
		internal override int cn()
		{
			return 133455;
		}

		// Token: 0x06000EB8 RID: 3768 RVA: 0x000B064C File Offset: 0x000AF64C
		internal override string co()
		{
			return "ins";
		}
	}
}
