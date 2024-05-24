using System;

namespace zz93
{
	// Token: 0x02000181 RID: 385
	internal class jt : d0
	{
		// Token: 0x06000D9C RID: 3484 RVA: 0x0009A0E8 File Offset: 0x000990E8
		internal jt(kg A_0, ij A_1)
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

		// Token: 0x06000D9D RID: 3485 RVA: 0x0009A1CC File Offset: 0x000991CC
		internal override int cn()
		{
			return 1717;
		}

		// Token: 0x06000D9E RID: 3486 RVA: 0x0009A1E4 File Offset: 0x000991E4
		internal override string co()
		{
			return "dt";
		}
	}
}
