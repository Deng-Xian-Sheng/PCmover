using System;

namespace zz93
{
	// Token: 0x02000249 RID: 585
	internal class pb : d0
	{
		// Token: 0x06001AD1 RID: 6865 RVA: 0x00116B84 File Offset: 0x00115B84
		internal pb(kg A_0, ij A_1)
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
							goto IL_16C;
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
						goto IL_16C;
					}
					string text2 = A_0.ao();
					if (this.a == ea.a && text2 != null)
					{
						string text3 = text2.ToLower();
						if (text3 == null)
						{
							goto IL_160;
						}
						if (!(text3 == "left"))
						{
							if (!(text3 == "right"))
							{
								if (!(text3 == "center"))
								{
									if (!(text3 == "justify"))
									{
										goto IL_160;
									}
									this.a = ea.g;
								}
								else
								{
									this.a = ea.d;
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
						IL_160:
						this.a = ea.b;
					}
				}
				else if (base.l() == null)
				{
					base.a(A_0.am());
				}
				continue;
				IL_16C:
				base.c(A_0);
			}
			A_0.ax();
		}

		// Token: 0x06001AD2 RID: 6866 RVA: 0x00116D20 File Offset: 0x00115D20
		internal override int cn()
		{
			return 33;
		}

		// Token: 0x06001AD3 RID: 6867 RVA: 0x00116D34 File Offset: 0x00115D34
		internal ea a()
		{
			return this.a;
		}

		// Token: 0x06001AD4 RID: 6868 RVA: 0x00116D4C File Offset: 0x00115D4C
		internal override string co()
		{
			return "p";
		}

		// Token: 0x04000C31 RID: 3121
		private ea a = ea.a;
	}
}
