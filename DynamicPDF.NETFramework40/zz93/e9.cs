using System;

namespace zz93
{
	// Token: 0x020000DD RID: 221
	internal class e9 : e8
	{
		// Token: 0x060009DD RID: 2525 RVA: 0x00080128 File Offset: 0x0007F128
		internal e9(kg A_0, ij A_1)
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
								goto IL_239;
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
							if (this.a == -2147483648)
							{
								this.a = A_0.@as();
							}
							if (this.a == 2147483647)
							{
								this.a = 0;
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
							goto IL_239;
						}
						if (base.l() == null)
						{
							base.a(A_0.am());
						}
					}
					else
					{
						base.b(A_0);
					}
				}
				else if (num != 623704577)
				{
					if (num != 795562982)
					{
						goto IL_239;
					}
					if (x5.h(m4.a(this.b), x5.c()))
					{
						string text2 = A_0.ao();
						if (text2 != null && text2.Length > 0)
						{
							this.b = new h2(A_1.g().a(text2.ToLower()));
							if (this.b.a().b() != i2.c && this.b.a().b() != i2.b)
							{
								this.b = new h2(new i4(i2.c, this.b.a().a()));
							}
						}
					}
				}
				else
				{
					base.a(A_0);
				}
				continue;
				IL_239:
				base.c(A_0);
			}
			A_0.ax();
		}

		// Token: 0x060009DE RID: 2526 RVA: 0x00080394 File Offset: 0x0007F394
		internal int a()
		{
			return this.a;
		}

		// Token: 0x060009DF RID: 2527 RVA: 0x000803AC File Offset: 0x0007F3AC
		internal h2 b()
		{
			return this.b;
		}

		// Token: 0x060009E0 RID: 2528 RVA: 0x000803C4 File Offset: 0x0007F3C4
		internal override int cn()
		{
			return 165445;
		}

		// Token: 0x060009E1 RID: 2529 RVA: 0x000803DC File Offset: 0x0007F3DC
		internal override string co()
		{
			return "col";
		}

		// Token: 0x040004F2 RID: 1266
		private new int a = int.MinValue;

		// Token: 0x040004F3 RID: 1267
		private new h2 b = new h2(new i4(i2.a, 0f));
	}
}
