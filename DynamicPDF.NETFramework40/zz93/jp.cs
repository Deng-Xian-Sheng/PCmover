using System;

namespace zz93
{
	// Token: 0x0200017D RID: 381
	internal class jp : d0
	{
		// Token: 0x06000D8D RID: 3469 RVA: 0x00099A44 File Offset: 0x00098A44
		internal jp(kg A_0, ij A_1)
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
								if (!(text2 == "center"))
								{
									if (!(text2 == "justify"))
									{
										goto IL_154;
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
						IL_154:
						this.a = ea.b;
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

		// Token: 0x06000D8E RID: 3470 RVA: 0x00099BD4 File Offset: 0x00098BD4
		internal ea a()
		{
			return this.a;
		}

		// Token: 0x06000D8F RID: 3471 RVA: 0x00099BEC File Offset: 0x00098BEC
		internal override int cn()
		{
			return 95221;
		}

		// Token: 0x06000D90 RID: 3472 RVA: 0x00099C04 File Offset: 0x00098C04
		internal override string co()
		{
			return "div";
		}

		// Token: 0x040006DC RID: 1756
		private ea a = ea.a;
	}
}
