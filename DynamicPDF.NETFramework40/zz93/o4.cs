using System;

namespace zz93
{
	// Token: 0x02000242 RID: 578
	internal class o4 : d0
	{
		// Token: 0x06001AAA RID: 6826 RVA: 0x001157AC File Offset: 0x001147AC
		internal o4(kg A_0, ij A_1)
		{
			while (!A_0.aj())
			{
				int num = A_0.al();
				if (num <= 143556695)
				{
					if (num != 3407)
					{
						if (num != 86255124)
						{
							if (num != 143556695)
							{
								goto IL_158;
							}
							if (this.b == null)
							{
								this.b = A_0.ao();
							}
						}
						else
						{
							this.c = true;
						}
					}
					else if (base.k() == null)
					{
						base.c(A_0.an());
					}
				}
				else if (num <= 545266181)
				{
					if (num != 144877216)
					{
						if (num != 545266181)
						{
							goto IL_158;
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
				}
				else if (num != 673419368)
				{
					if (num != 956344229)
					{
						goto IL_158;
					}
					this.a = true;
				}
				else
				{
					this.d = A_0.ao();
				}
				continue;
				IL_158:
				base.c(A_0);
			}
			A_0.ax();
		}

		// Token: 0x06001AAB RID: 6827 RVA: 0x00115934 File Offset: 0x00114934
		internal override int cn()
		{
			return 423471123;
		}

		// Token: 0x06001AAC RID: 6828 RVA: 0x0011594C File Offset: 0x0011494C
		internal override string co()
		{
			return "option";
		}

		// Token: 0x06001AAD RID: 6829 RVA: 0x00115964 File Offset: 0x00114964
		internal bool a()
		{
			return this.a;
		}

		// Token: 0x06001AAE RID: 6830 RVA: 0x0011597C File Offset: 0x0011497C
		internal string b()
		{
			return this.b;
		}

		// Token: 0x06001AAF RID: 6831 RVA: 0x00115994 File Offset: 0x00114994
		internal bool c()
		{
			return this.c;
		}

		// Token: 0x06001AB0 RID: 6832 RVA: 0x001159AC File Offset: 0x001149AC
		internal string d()
		{
			return this.d;
		}

		// Token: 0x04000C22 RID: 3106
		private bool a = false;

		// Token: 0x04000C23 RID: 3107
		private string b = null;

		// Token: 0x04000C24 RID: 3108
		private new bool c = false;

		// Token: 0x04000C25 RID: 3109
		private string d = null;
	}
}
