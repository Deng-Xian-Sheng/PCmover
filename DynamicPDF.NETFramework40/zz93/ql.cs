using System;

namespace zz93
{
	// Token: 0x02000277 RID: 631
	internal class ql : e8
	{
		// Token: 0x06001C42 RID: 7234 RVA: 0x00123384 File Offset: 0x00122384
		internal ql(kg A_0, ij A_1)
		{
			while (!A_0.aj())
			{
				int num = A_0.al();
				if (num <= 144877216)
				{
					if (num != 3407)
					{
						if (num != 144877216)
						{
							goto IL_E9;
						}
						if (base.m() == null)
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
				else if (num != 188645405)
				{
					if (num != 545266181)
					{
						if (num != 623704577)
						{
							goto IL_E9;
						}
						base.a(A_0);
					}
					else if (base.l() == null)
					{
						base.a(A_0.am());
					}
				}
				else
				{
					base.b(A_0);
				}
				continue;
				IL_E9:
				base.c(A_0);
			}
			A_0.ax();
		}

		// Token: 0x06001C43 RID: 7235 RVA: 0x001234A0 File Offset: 0x001224A0
		internal override int cn()
		{
			return 889490394;
		}

		// Token: 0x06001C44 RID: 7236 RVA: 0x001234B8 File Offset: 0x001224B8
		internal override string co()
		{
			return "thead";
		}
	}
}
