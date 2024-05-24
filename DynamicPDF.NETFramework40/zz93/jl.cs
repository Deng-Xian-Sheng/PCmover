using System;

namespace zz93
{
	// Token: 0x02000179 RID: 377
	internal class jl : jk
	{
		// Token: 0x06000D7E RID: 3454 RVA: 0x00099390 File Offset: 0x00098390
		internal jl(kg A_0, ij A_1)
		{
			while (!A_0.aj())
			{
				int num = A_0.al();
				if (num <= 2235034)
				{
					if (num != 3407)
					{
						if (num != 2235034)
						{
							goto IL_140;
						}
						if (base.b() == ok.v)
						{
							string text = A_0.ao();
							if (text == null)
							{
								goto IL_133;
							}
							if (!(text == "disc"))
							{
								if (!(text == "square"))
								{
									if (!(text == "circle"))
									{
										goto IL_133;
									}
									base.a(ok.h);
								}
								else
								{
									base.a(ok.g);
								}
							}
							else
							{
								base.a(ok.f);
							}
							continue;
							IL_133:
							base.a(ok.f);
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
						goto IL_140;
					}
					if (base.l() == null)
					{
						base.a(A_0.am());
					}
				}
				else if (base.m() == null)
				{
					string text2 = A_0.au();
					if (text2 != null)
					{
						base.a(new ig(A_1.a(text2.ToCharArray(), 0, text2.Length)));
					}
				}
				continue;
				IL_140:
				A_0.at();
			}
			A_0.ax();
		}

		// Token: 0x06000D7F RID: 3455 RVA: 0x00099500 File Offset: 0x00098500
		internal override int cn()
		{
			return 2595;
		}

		// Token: 0x06000D80 RID: 3456 RVA: 0x00099518 File Offset: 0x00098518
		internal override string co()
		{
			return "ul";
		}
	}
}
