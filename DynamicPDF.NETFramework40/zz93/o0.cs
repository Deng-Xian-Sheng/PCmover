using System;

namespace zz93
{
	// Token: 0x0200023E RID: 574
	internal class o0 : d0
	{
		// Token: 0x06001A90 RID: 6800 RVA: 0x00114A04 File Offset: 0x00113A04
		internal o0(kg A_0, ij A_1)
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
							goto IL_FD;
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
				else if (num != 545266181)
				{
					if (num != 673419368)
					{
						if (num != 956344229)
						{
							goto IL_FD;
						}
						this.a = true;
					}
					else
					{
						this.b = A_0.ao();
					}
				}
				else if (base.l() == null)
				{
					base.a(A_0.am());
				}
				continue;
				IL_FD:
				base.c(A_0);
			}
			A_0.ax();
		}

		// Token: 0x06001A91 RID: 6801 RVA: 0x00114B34 File Offset: 0x00113B34
		internal override int cn()
		{
			return 506042859;
		}

		// Token: 0x06001A92 RID: 6802 RVA: 0x00114B4C File Offset: 0x00113B4C
		internal override string co()
		{
			return "option";
		}

		// Token: 0x06001A93 RID: 6803 RVA: 0x00114B64 File Offset: 0x00113B64
		internal bool a()
		{
			return this.a;
		}

		// Token: 0x06001A94 RID: 6804 RVA: 0x00114B7C File Offset: 0x00113B7C
		internal string b()
		{
			return this.b;
		}

		// Token: 0x04000C18 RID: 3096
		private bool a = false;

		// Token: 0x04000C19 RID: 3097
		private string b = null;
	}
}
