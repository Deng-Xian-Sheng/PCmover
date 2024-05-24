using System;
using System.Collections.Generic;

namespace zz93
{
	// Token: 0x02000230 RID: 560
	internal class om : d0
	{
		// Token: 0x06001A31 RID: 6705 RVA: 0x00111220 File Offset: 0x00110220
		internal om(kg A_0, ij A_1)
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
							goto IL_254;
						}
						if (this.a == ok.v)
						{
							string text = A_0.ao();
							if (text == null)
							{
								goto IL_20B;
							}
							if (anl.ri == null)
							{
								anl.ri = new Dictionary<string, int>(8)
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
							if (!anl.ri.TryGetValue(text, out num2))
							{
								goto IL_20B;
							}
							switch (num2)
							{
							case 0:
								this.a = ok.a;
								break;
							case 1:
								this.a = ok.b;
								break;
							case 2:
								this.a = ok.c;
								break;
							case 3:
								this.a = ok.d;
								break;
							case 4:
								this.a = ok.e;
								break;
							case 5:
								this.a = ok.f;
								break;
							case 6:
								this.a = ok.g;
								break;
							case 7:
								this.a = ok.h;
								break;
							default:
								goto IL_20B;
							}
							continue;
							IL_20B:
							this.a = ok.f;
						}
					}
					else if (base.k() == null)
					{
						base.c(A_0.an());
					}
				}
				else if (num != 143556695)
				{
					if (num != 144877216)
					{
						if (num != 545266181)
						{
							goto IL_254;
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
				}
				else
				{
					if (this.b == -2147483648)
					{
						this.b = A_0.@as();
					}
					if (this.b == 2147483647)
					{
						this.b = 1;
					}
				}
				continue;
				IL_254:
				base.c(A_0);
			}
			A_0.ax();
		}

		// Token: 0x06001A32 RID: 6706 RVA: 0x001114A4 File Offset: 0x001104A4
		internal ok a()
		{
			return this.a;
		}

		// Token: 0x06001A33 RID: 6707 RVA: 0x001114BC File Offset: 0x001104BC
		internal int b()
		{
			return this.b;
		}

		// Token: 0x06001A34 RID: 6708 RVA: 0x001114D4 File Offset: 0x001104D4
		internal override int cn()
		{
			return 1000;
		}

		// Token: 0x06001A35 RID: 6709 RVA: 0x001114EC File Offset: 0x001104EC
		internal override string co()
		{
			return "li";
		}

		// Token: 0x04000BEF RID: 3055
		private ok a = ok.v;

		// Token: 0x04000BF0 RID: 3056
		private int b = int.MinValue;
	}
}
