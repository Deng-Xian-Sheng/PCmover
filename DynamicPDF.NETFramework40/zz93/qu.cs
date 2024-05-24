using System;

namespace zz93
{
	// Token: 0x02000280 RID: 640
	internal class qu : d0
	{
		// Token: 0x06001C7D RID: 7293 RVA: 0x00124F94 File Offset: 0x00123F94
		internal qu(kg A_0, ij A_1)
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

		// Token: 0x06001C7E RID: 7294 RVA: 0x00125078 File Offset: 0x00124078
		internal override int cn()
		{
			return 122967;
		}

		// Token: 0x06001C7F RID: 7295 RVA: 0x00125090 File Offset: 0x00124090
		internal override string co()
		{
			return "var";
		}
	}
}
