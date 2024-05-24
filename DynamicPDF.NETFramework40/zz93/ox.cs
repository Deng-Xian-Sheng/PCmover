using System;
using System.Collections.Generic;

namespace zz93
{
	// Token: 0x0200023B RID: 571
	internal class ox : jk
	{
		// Token: 0x06001A74 RID: 6772 RVA: 0x001137E8 File Offset: 0x001127E8
		internal ox(kg A_0, ij A_1)
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
							goto IL_255;
						}
						if (base.b() == ok.v)
						{
							string text = A_0.ao();
							if (text == null)
							{
								goto IL_20B;
							}
							if (anl.rk == null)
							{
								anl.rk = new Dictionary<string, int>(8)
								{
									{
										"A",
										0
									},
									{
										"a",
										1
									},
									{
										"I",
										2
									},
									{
										"i",
										3
									},
									{
										"1",
										4
									},
									{
										"disc",
										5
									},
									{
										"square",
										6
									},
									{
										"circle",
										7
									}
								};
							}
							int num2;
							if (!anl.rk.TryGetValue(text, out num2))
							{
								goto IL_20B;
							}
							switch (num2)
							{
							case 0:
								base.a(ok.a);
								break;
							case 1:
								base.a(ok.b);
								break;
							case 2:
								base.a(ok.c);
								break;
							case 3:
								base.a(ok.d);
								break;
							case 4:
								base.a(ok.e);
								break;
							case 5:
								base.a(ok.f);
								break;
							case 6:
								base.a(ok.g);
								break;
							case 7:
								base.a(ok.h);
								break;
							default:
								goto IL_20B;
							}
							continue;
							IL_20B:
							base.a(ok.e);
						}
					}
					else if (base.k() == null)
					{
						base.c(A_0.an());
					}
				}
				else if (num != 144877216)
				{
					if (num != 444077728)
					{
						if (num != 545266181)
						{
							goto IL_255;
						}
						if (base.l() == null)
						{
							base.a(A_0.am());
						}
					}
					else
					{
						if (this.a == -2147483648)
						{
							this.a = A_0.@as();
						}
						if (this.a() == 2147483647)
						{
							this.a = 1;
						}
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
				IL_255:
				A_0.at();
			}
			A_0.ax();
		}

		// Token: 0x06001A75 RID: 6773 RVA: 0x00113A6C File Offset: 0x00112A6C
		internal int a()
		{
			return this.a;
		}

		// Token: 0x06001A76 RID: 6774 RVA: 0x00113A84 File Offset: 0x00112A84
		internal override int cn()
		{
			return 2585;
		}

		// Token: 0x06001A77 RID: 6775 RVA: 0x00113A9C File Offset: 0x00112A9C
		internal override string co()
		{
			return "ol";
		}

		// Token: 0x04000C0F RID: 3087
		private int a = int.MinValue;
	}
}
