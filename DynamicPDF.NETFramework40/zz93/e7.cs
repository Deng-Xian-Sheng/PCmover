using System;

namespace zz93
{
	// Token: 0x020000DB RID: 219
	internal class e7 : d0
	{
		// Token: 0x060009CE RID: 2510 RVA: 0x0007FB3F File Offset: 0x0007EB3F
		internal e7()
		{
		}

		// Token: 0x060009CF RID: 2511 RVA: 0x0007FB7C File Offset: 0x0007EB7C
		internal e7(kg A_0, ij A_1)
		{
			while (!A_0.aj())
			{
				int num = A_0.al();
				if (num <= 144877216)
				{
					if (num != 3407)
					{
						if (num != 9705568)
						{
							if (num != 144877216)
							{
								goto IL_34B;
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
						else
						{
							if (this.b == -2147483648)
							{
								this.b = A_0.@as();
							}
							if (this.b == 2147483647)
							{
								this.b = 0;
							}
						}
					}
					else if (base.k() == null)
					{
						base.c(A_0.an());
					}
				}
				else if (num <= 545266181)
				{
					if (num != 188645405)
					{
						if (num != 545266181)
						{
							goto IL_34B;
						}
						if (base.l() == null)
						{
							base.a(A_0.am());
						}
					}
					else if (this.c == gs.a)
					{
						string text2 = A_0.ao().ToLower();
						if (text2 == null)
						{
							goto IL_282;
						}
						if (!(text2 == "top"))
						{
							if (!(text2 == "middle"))
							{
								if (!(text2 == "bottom"))
								{
									if (!(text2 == "baseline"))
									{
										goto IL_282;
									}
									this.c = gs.b;
								}
								else
								{
									this.c = gs.h;
								}
							}
							else
							{
								this.c = gs.g;
							}
						}
						else
						{
							this.c = gs.e;
						}
						continue;
						IL_282:
						this.c = gs.g;
					}
				}
				else if (num != 623704577)
				{
					if (num != 795562982)
					{
						goto IL_34B;
					}
					if (x5.h(m4.a(this.d), x5.c()))
					{
						string text3 = A_0.ao();
						if (text3 != null && text3.Length > 0)
						{
							this.d = new h2(A_1.g().a(text3.ToLower()));
							if (this.d.a().b() != i2.c && this.d.a().b() != i2.b)
							{
								this.d = new h2(new i4(i2.c, this.d.a().a()));
							}
						}
					}
				}
				else if (this.a == gn.e)
				{
					string text2 = A_0.ao().ToLower();
					if (text2 == null)
					{
						goto IL_1B3;
					}
					if (!(text2 == "left"))
					{
						if (!(text2 == "right"))
						{
							if (!(text2 == "center"))
							{
								if (!(text2 == "justify"))
								{
									goto IL_1B3;
								}
								this.a = gn.d;
							}
							else
							{
								this.a = gn.c;
							}
						}
						else
						{
							this.a = gn.b;
						}
					}
					else
					{
						this.a = gn.a;
					}
					continue;
					IL_1B3:
					this.a = gn.a;
				}
				continue;
				IL_34B:
				base.c(A_0);
			}
			A_0.ax();
		}

		// Token: 0x060009D0 RID: 2512 RVA: 0x0007FEF8 File Offset: 0x0007EEF8
		internal gn a()
		{
			return this.a;
		}

		// Token: 0x060009D1 RID: 2513 RVA: 0x0007FF10 File Offset: 0x0007EF10
		internal int b()
		{
			return this.b;
		}

		// Token: 0x060009D2 RID: 2514 RVA: 0x0007FF28 File Offset: 0x0007EF28
		internal gs c()
		{
			return this.c;
		}

		// Token: 0x060009D3 RID: 2515 RVA: 0x0007FF40 File Offset: 0x0007EF40
		internal h2 d()
		{
			return this.d;
		}

		// Token: 0x060009D4 RID: 2516 RVA: 0x0007FF58 File Offset: 0x0007EF58
		internal override int cn()
		{
			return 506116087;
		}

		// Token: 0x060009D5 RID: 2517 RVA: 0x0007FF70 File Offset: 0x0007EF70
		internal override string co()
		{
			return "colgroup";
		}

		// Token: 0x040004EC RID: 1260
		private gn a = gn.e;

		// Token: 0x040004ED RID: 1261
		private int b = int.MinValue;

		// Token: 0x040004EE RID: 1262
		private new gs c = gs.a;

		// Token: 0x040004EF RID: 1263
		private h2 d = new h2(new i4(i2.a, 0f));
	}
}
