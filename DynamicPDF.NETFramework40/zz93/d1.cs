using System;

namespace zz93
{
	// Token: 0x020000B1 RID: 177
	internal class d1 : d0
	{
		// Token: 0x06000864 RID: 2148 RVA: 0x00075C70 File Offset: 0x00074C70
		internal d1(kg A_0, ij A_1)
		{
			while (!A_0.aj())
			{
				int num = A_0.al();
				if (num <= 144810970)
				{
					if (num != 3407)
					{
						if (num != 144810970)
						{
							goto IL_F2;
						}
						if (this.a == null)
						{
							this.a = A_0.ao();
						}
					}
					else if (base.k() == null)
					{
						base.c(A_0.an());
					}
				}
				else if (num != 144877216)
				{
					if (num != 545266181)
					{
						goto IL_F2;
					}
					if (base.l() == null)
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
				continue;
				IL_F2:
				base.c(A_0);
			}
			A_0.ax();
		}

		// Token: 0x06000865 RID: 2149 RVA: 0x00075D94 File Offset: 0x00074D94
		internal string a()
		{
			return this.a;
		}

		// Token: 0x06000866 RID: 2150 RVA: 0x00075DAC File Offset: 0x00074DAC
		internal override int cn()
		{
			return 8101441;
		}

		// Token: 0x06000867 RID: 2151 RVA: 0x00075DC4 File Offset: 0x00074DC4
		internal override string co()
		{
			return "abbr";
		}

		// Token: 0x04000484 RID: 1156
		private string a = null;
	}
}
