using System;

namespace zz93
{
	// Token: 0x0200018B RID: 395
	internal class j3 : d0
	{
		// Token: 0x06000DD8 RID: 3544 RVA: 0x0009C3C8 File Offset: 0x0009B3C8
		internal j3(kg A_0, ij A_1)
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

		// Token: 0x06000DD9 RID: 3545 RVA: 0x0009C4AC File Offset: 0x0009B4AC
		internal override int cn()
		{
			return 5629554;
		}

		// Token: 0x06000DDA RID: 3546 RVA: 0x0009C4C4 File Offset: 0x0009B4C4
		internal override string co()
		{
			return "form";
		}
	}
}
