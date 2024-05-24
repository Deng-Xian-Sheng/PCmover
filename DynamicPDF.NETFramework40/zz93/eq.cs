using System;

namespace zz93
{
	// Token: 0x020000CA RID: 202
	internal class eq : d0
	{
		// Token: 0x06000947 RID: 2375 RVA: 0x0007C5F4 File Offset: 0x0007B5F4
		internal eq(kg A_0, ij A_1)
		{
			while (!A_0.aj())
			{
				int num = A_0.al();
				if (num <= 143556695)
				{
					if (num != 3407)
					{
						if (num != 2235034)
						{
							if (num != 143556695)
							{
								goto IL_122;
							}
							this.c = A_0.ao();
						}
						else
						{
							this.a = A_0.ao().ToLower();
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
						if (num != 956344229)
						{
							goto IL_122;
						}
						this.b = true;
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
				continue;
				IL_122:
				base.c(A_0);
			}
			A_0.ax();
		}

		// Token: 0x06000948 RID: 2376 RVA: 0x0007C748 File Offset: 0x0007B748
		internal override int cn()
		{
			return 426354867;
		}

		// Token: 0x06000949 RID: 2377 RVA: 0x0007C760 File Offset: 0x0007B760
		internal override string co()
		{
			return "button";
		}

		// Token: 0x0600094A RID: 2378 RVA: 0x0007C778 File Offset: 0x0007B778
		internal string a()
		{
			return this.a;
		}

		// Token: 0x0600094B RID: 2379 RVA: 0x0007C790 File Offset: 0x0007B790
		internal string b()
		{
			return this.c;
		}

		// Token: 0x0600094C RID: 2380 RVA: 0x0007C7A8 File Offset: 0x0007B7A8
		internal bool c()
		{
			return this.b;
		}

		// Token: 0x040004C2 RID: 1218
		private string a = null;

		// Token: 0x040004C3 RID: 1219
		private bool b = false;

		// Token: 0x040004C4 RID: 1220
		private new string c = null;
	}
}
