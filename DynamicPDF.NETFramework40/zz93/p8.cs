using System;

namespace zz93
{
	// Token: 0x0200026A RID: 618
	internal class p8 : e8
	{
		// Token: 0x06001BDC RID: 7132 RVA: 0x0011F710 File Offset: 0x0011E710
		internal p8(kg A_0, ij A_1)
		{
			while (!A_0.aj())
			{
				int num = A_0.al();
				if (num <= 545266181)
				{
					if (num <= 24798759)
					{
						if (num != 3407)
						{
							if (num != 24798759)
							{
								goto IL_3E9;
							}
							if (!this.d)
							{
								A_0.ao();
								this.d = true;
							}
						}
						else if (base.k() == null)
						{
							base.c(A_0.an());
						}
					}
					else if (num != 144877216)
					{
						if (num != 188645405)
						{
							if (num != 545266181)
							{
								goto IL_3E9;
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
					else if (base.m() == null)
					{
						string text = A_0.au();
						if (text != null)
						{
							base.a(new ig(A_1.a(text.ToCharArray(), 0, text.Length)));
						}
					}
				}
				else if (num <= 623704577)
				{
					if (num != 562197724)
					{
						if (num != 562205895)
						{
							if (num != 623704577)
							{
								goto IL_3E9;
							}
							base.a(A_0);
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
					else
					{
						if (this.e == -2147483648)
						{
							this.e = A_0.@as();
						}
						if (this.e == 2147483647)
						{
							this.e = 0;
						}
					}
				}
				else if (num != 677666251)
				{
					if (num != 791474715)
					{
						if (num != 795562982)
						{
							goto IL_3E9;
						}
						if (x5.h(m4.a(this.f), x5.c()))
						{
							string text2 = A_0.ao();
							if (text2 != null && text2.Length > 0 && !text2.Contains("*"))
							{
								this.f = new h2(A_1.g().a(text2.ToLower()));
								if (this.f.a().b() != i2.c && this.f.a().b() != i2.b)
								{
									this.f = new h2(new i4(i2.c, this.f.a().a()));
								}
							}
						}
					}
					else if (x5.h(m4.a(this.c), x5.c()))
					{
						string text2 = A_0.ao();
						if (text2 != null && text2.Length > 0)
						{
							this.c = new h2(A_1.g().a(text2.ToLower()));
							if (this.c.a().b() != i2.c && this.c.a().b() != i2.b)
							{
								this.c = new h2(new i4(i2.c, this.c.a().a()));
							}
						}
					}
				}
				else if (this.a == null)
				{
					this.a = A_0.ao();
				}
				continue;
				IL_3E9:
				base.c(A_0);
			}
			A_0.ax();
		}

		// Token: 0x06001BDD RID: 7133 RVA: 0x0011FB2C File Offset: 0x0011EB2C
		internal string a()
		{
			return this.a;
		}

		// Token: 0x06001BDE RID: 7134 RVA: 0x0011FB44 File Offset: 0x0011EB44
		internal int b()
		{
			int result;
			if (this.b == -2147483648)
			{
				result = 1;
			}
			else
			{
				result = this.b;
			}
			return result;
		}

		// Token: 0x06001BDF RID: 7135 RVA: 0x0011FB74 File Offset: 0x0011EB74
		internal void a(int A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06001BE0 RID: 7136 RVA: 0x0011FB80 File Offset: 0x0011EB80
		internal h2 c()
		{
			return this.c;
		}

		// Token: 0x06001BE1 RID: 7137 RVA: 0x0011FB98 File Offset: 0x0011EB98
		internal bool d()
		{
			return this.d;
		}

		// Token: 0x06001BE2 RID: 7138 RVA: 0x0011FBB0 File Offset: 0x0011EBB0
		internal int e()
		{
			int result;
			if (this.e == -2147483648)
			{
				result = 1;
			}
			else
			{
				result = this.e;
			}
			return result;
		}

		// Token: 0x06001BE3 RID: 7139 RVA: 0x0011FBE0 File Offset: 0x0011EBE0
		internal h2 f()
		{
			return this.f;
		}

		// Token: 0x06001BE4 RID: 7140 RVA: 0x0011FBF8 File Offset: 0x0011EBF8
		internal override int cn()
		{
			return 3418;
		}

		// Token: 0x06001BE5 RID: 7141 RVA: 0x0011FC10 File Offset: 0x0011EC10
		internal override string co()
		{
			return "td";
		}

		// Token: 0x04000C92 RID: 3218
		private new string a = null;

		// Token: 0x04000C93 RID: 3219
		private new int b = int.MinValue;

		// Token: 0x04000C94 RID: 3220
		private new h2 c = new h2(new i4(i2.a, 0f));

		// Token: 0x04000C95 RID: 3221
		private bool d = false;

		// Token: 0x04000C96 RID: 3222
		private int e = int.MinValue;

		// Token: 0x04000C97 RID: 3223
		private h2 f = new h2(new i4(i2.a, 0f));
	}
}
