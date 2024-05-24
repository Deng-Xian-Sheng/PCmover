using System;

namespace zz93
{
	// Token: 0x020000CE RID: 206
	internal class eu : d0
	{
		// Token: 0x0600097E RID: 2430 RVA: 0x0007DE4C File Offset: 0x0007CE4C
		internal eu(kg A_0, ij A_1)
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
							goto IL_160;
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
					if (num != 623704577)
					{
						goto IL_160;
					}
					if (this.a == ea.a)
					{
						string text2 = A_0.ao().ToLower();
						if (text2 == null)
						{
							goto IL_154;
						}
						if (!(text2 == "left"))
						{
							if (!(text2 == "right"))
							{
								if (!(text2 == "top"))
								{
									if (!(text2 == "bottom"))
									{
										goto IL_154;
									}
									this.a = ea.f;
								}
								else
								{
									this.a = ea.e;
								}
							}
							else
							{
								this.a = ea.c;
							}
						}
						else
						{
							this.a = ea.b;
						}
						continue;
						IL_154:
						this.a = ea.d;
					}
				}
				else if (base.l() == null)
				{
					base.a(A_0.am());
				}
				continue;
				IL_160:
				base.c(A_0);
			}
			A_0.ax();
		}

		// Token: 0x0600097F RID: 2431 RVA: 0x0007DFDC File Offset: 0x0007CFDC
		internal ea a()
		{
			return this.a;
		}

		// Token: 0x06000980 RID: 2432 RVA: 0x0007DFF4 File Offset: 0x0007CFF4
		internal override int cn()
		{
			return 258605815;
		}

		// Token: 0x06000981 RID: 2433 RVA: 0x0007E00C File Offset: 0x0007D00C
		internal override string co()
		{
			return "caption";
		}

		// Token: 0x040004D0 RID: 1232
		private ea a = ea.a;
	}
}
