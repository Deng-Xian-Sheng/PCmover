using System;

namespace zz93
{
	// Token: 0x02000278 RID: 632
	internal class qm : e8
	{
		// Token: 0x06001C45 RID: 7237 RVA: 0x001234D0 File Offset: 0x001224D0
		internal qm(kg A_0, ij A_1)
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
							if (!this.c)
							{
								A_0.ao();
								this.c = true;
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
						if (this.d == -2147483648)
						{
							this.d = A_0.@as();
						}
						if (this.d == 2147483647)
						{
							this.d = 0;
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
						if (x5.h(m4.a(this.e), x5.c()))
						{
							string text2 = A_0.ao();
							if (text2 != null && text2.Length > 0 && !text2.Contains("*"))
							{
								this.e = new h2(A_1.g().a(text2.ToLower()));
								if (this.e.a().b() != i2.c && this.e.a().b() != i2.b)
								{
									this.e = new h2(new i4(i2.c, this.e.a().a()));
								}
							}
						}
					}
					else if (x5.h(m4.a(this.f), x5.c()))
					{
						string text2 = A_0.ao();
						if (text2 != null && text2.Length > 0)
						{
							this.f = new h2(A_1.g().a(text2.ToLower()));
							if (this.f.a().b() != i2.c && this.f.a().b() != i2.b)
							{
								this.f = new h2(new i4(i2.c, this.f.a().a()));
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

		// Token: 0x06001C46 RID: 7238 RVA: 0x001238EC File Offset: 0x001228EC
		internal string a()
		{
			return this.a;
		}

		// Token: 0x06001C47 RID: 7239 RVA: 0x00123904 File Offset: 0x00122904
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

		// Token: 0x06001C48 RID: 7240 RVA: 0x00123934 File Offset: 0x00122934
		internal void a(int A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06001C49 RID: 7241 RVA: 0x00123940 File Offset: 0x00122940
		internal h2 c()
		{
			return this.f;
		}

		// Token: 0x06001C4A RID: 7242 RVA: 0x00123958 File Offset: 0x00122958
		internal bool d()
		{
			return this.c;
		}

		// Token: 0x06001C4B RID: 7243 RVA: 0x00123970 File Offset: 0x00122970
		internal int e()
		{
			int result;
			if (this.d == -2147483648)
			{
				result = 1;
			}
			else
			{
				result = this.d;
			}
			return result;
		}

		// Token: 0x06001C4C RID: 7244 RVA: 0x001239A0 File Offset: 0x001229A0
		internal h2 f()
		{
			return this.e;
		}

		// Token: 0x06001C4D RID: 7245 RVA: 0x001239B8 File Offset: 0x001229B8
		internal override int cn()
		{
			return 3034;
		}

		// Token: 0x06001C4E RID: 7246 RVA: 0x001239D0 File Offset: 0x001229D0
		internal override string co()
		{
			return "th";
		}

		// Token: 0x04000CB7 RID: 3255
		private new string a = null;

		// Token: 0x04000CB8 RID: 3256
		private new int b = int.MinValue;

		// Token: 0x04000CB9 RID: 3257
		private new bool c = false;

		// Token: 0x04000CBA RID: 3258
		private int d = int.MinValue;

		// Token: 0x04000CBB RID: 3259
		private h2 e = new h2(new i4(i2.a, 0f));

		// Token: 0x04000CBC RID: 3260
		private h2 f = new h2(new i4(i2.a, 0f));
	}
}
