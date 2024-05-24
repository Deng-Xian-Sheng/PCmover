using System;

namespace zz93
{
	// Token: 0x02000262 RID: 610
	internal class p0 : e8
	{
		// Token: 0x06001B9A RID: 7066 RVA: 0x0011D2E8 File Offset: 0x0011C2E8
		internal p0(kg A_0, ij A_1)
		{
			while (!A_0.aj())
			{
				int num = A_0.al();
				if (num <= 545266181)
				{
					if (num <= 144877216)
					{
						if (num != 3407)
						{
							if (num != 139728818)
							{
								if (num != 144877216)
								{
									goto IL_454;
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
							else if (this.g == null)
							{
								this.g = A_0.ao().ToLower();
							}
						}
						else if (base.k() == null)
						{
							base.c(A_0.an());
						}
					}
					else if (num != 148235845)
					{
						if (num != 539134174)
						{
							if (num != 545266181)
							{
								goto IL_454;
							}
							if (base.l() == null)
							{
								base.a(A_0.am());
							}
						}
						else if (this.f == null)
						{
							this.f = A_0.ao().ToLower();
						}
					}
					else
					{
						this.b = A_0.@as();
						if (this.b == 2147483647)
						{
							this.b = 1;
						}
					}
				}
				else if (num <= 795562982)
				{
					if (num != 623704577)
					{
						if (num != 677666251)
						{
							if (num != 795562982)
							{
								goto IL_454;
							}
							if (x5.h(m4.a(this.e), x5.c()))
							{
								string text2 = A_0.ao();
								if (text2 != null && text2.Length > 0)
								{
									this.e = new h2(A_1.g().a(text2));
									if (this.e.a().b() != i2.c && this.e.a().b() != i2.b)
									{
										this.e = new h2(new i4(i2.c, this.e.a().a()));
									}
								}
							}
						}
						else if (this.a == null)
						{
							this.a = A_0.ao();
						}
					}
					else
					{
						base.a(A_0);
					}
				}
				else if (num != 1617181893)
				{
					if (num != 1792680652)
					{
						if (num != 1809594508)
						{
							goto IL_454;
						}
						string text3 = A_0.ao();
						if (text3 != null && text3.Length > 0)
						{
							this.c = new h2(A_1.g().a(text3));
							if (this.c.a().b() != i2.c)
							{
								this.c = new h2(new i4(i2.c, this.c.a().a()));
							}
						}
					}
					else
					{
						if (this.d == -2147483648)
						{
							string text2 = A_0.ao();
							if (text2 != null && text2.Length > 0)
							{
								h2 h = new h2(A_1.g().a(text2));
								this.d = (int)h.a().a();
							}
						}
						if (this.d == 2147483647)
						{
							this.d = 0;
						}
					}
				}
				else if (this.h == null)
				{
					this.h = A_0.aq();
				}
				continue;
				IL_454:
				base.c(A_0);
			}
			A_0.ax();
		}

		// Token: 0x06001B9B RID: 7067 RVA: 0x0011D770 File Offset: 0x0011C770
		internal string a()
		{
			return this.a;
		}

		// Token: 0x06001B9C RID: 7068 RVA: 0x0011D788 File Offset: 0x0011C788
		internal int b()
		{
			return this.b;
		}

		// Token: 0x06001B9D RID: 7069 RVA: 0x0011D7A0 File Offset: 0x0011C7A0
		internal string c()
		{
			return this.h;
		}

		// Token: 0x06001B9E RID: 7070 RVA: 0x0011D7B8 File Offset: 0x0011C7B8
		internal h2 d()
		{
			return this.c;
		}

		// Token: 0x06001B9F RID: 7071 RVA: 0x0011D7D0 File Offset: 0x0011C7D0
		internal int e()
		{
			int result;
			if (this.d == -2147483648)
			{
				result = 2;
			}
			else
			{
				result = this.d;
			}
			return result;
		}

		// Token: 0x06001BA0 RID: 7072 RVA: 0x0011D800 File Offset: 0x0011C800
		internal string f()
		{
			return this.g;
		}

		// Token: 0x06001BA1 RID: 7073 RVA: 0x0011D818 File Offset: 0x0011C818
		internal string g()
		{
			return this.f;
		}

		// Token: 0x06001BA2 RID: 7074 RVA: 0x0011D830 File Offset: 0x0011C830
		internal h2 h()
		{
			return this.e;
		}

		// Token: 0x06001BA3 RID: 7075 RVA: 0x0011D848 File Offset: 0x0011C848
		internal override int cn()
		{
			return 144937050;
		}

		// Token: 0x06001BA4 RID: 7076 RVA: 0x0011D860 File Offset: 0x0011C860
		internal override string co()
		{
			return "table";
		}

		// Token: 0x06001BA5 RID: 7077 RVA: 0x0011D878 File Offset: 0x0011C878
		private bool a(string A_0)
		{
			A_0 = A_0.Trim();
			byte b = (byte)A_0[0];
			return b > 47 && b < 58;
		}

		// Token: 0x04000C7C RID: 3196
		private new string a = null;

		// Token: 0x04000C7D RID: 3197
		private new int b = int.MinValue;

		// Token: 0x04000C7E RID: 3198
		private new h2 c = new h2(new i4(i2.c, 1f));

		// Token: 0x04000C7F RID: 3199
		private int d = int.MinValue;

		// Token: 0x04000C80 RID: 3200
		private h2 e = new h2(new i4(i2.a, 0f));

		// Token: 0x04000C81 RID: 3201
		private string f = null;

		// Token: 0x04000C82 RID: 3202
		private string g = null;

		// Token: 0x04000C83 RID: 3203
		private string h = null;
	}
}
