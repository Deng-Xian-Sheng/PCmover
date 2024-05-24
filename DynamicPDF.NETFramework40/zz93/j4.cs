using System;

namespace zz93
{
	// Token: 0x0200018C RID: 396
	internal abstract class j4 : d0
	{
		// Token: 0x06000DDB RID: 3547 RVA: 0x0009C4DC File Offset: 0x0009B4DC
		internal j4(kg A_0, ij A_1)
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

		// Token: 0x06000DDC RID: 3548 RVA: 0x0009C66C File Offset: 0x0009B66C
		internal ea a()
		{
			return this.a;
		}

		// Token: 0x040006F3 RID: 1779
		private ea a = ea.a;
	}
}
