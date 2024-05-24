using System;

namespace zz93
{
	// Token: 0x02000197 RID: 407
	internal class kf : d0
	{
		// Token: 0x06000E08 RID: 3592 RVA: 0x0009D90C File Offset: 0x0009C90C
		internal kf()
		{
		}

		// Token: 0x06000E09 RID: 3593 RVA: 0x0009D95C File Offset: 0x0009C95C
		internal kf(kg A_0, ij A_1)
		{
			while (!A_0.aj())
			{
				int num = A_0.al();
				if (num <= 29229583)
				{
					if (num != 3407)
					{
						if (num != 2163680)
						{
							if (num != 29229583)
							{
								goto IL_37D;
							}
							if (this.b == null)
							{
								this.b = A_0.ao();
							}
							if (this.b == null)
							{
								this.b = "noshade";
							}
						}
						else if (x5.h(m4.a(this.c), x5.c()))
						{
							string text = A_0.ao();
							if (text != null && text.Length > 0)
							{
								this.c = new h2(A_1.g().a(text.ToLower()));
								if (this.c.a().b() != i2.c && this.c.a().b() != i2.b)
								{
									this.c = new h2(new i4(i2.c, this.c.a().a()));
								}
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
					if (num != 144877216)
					{
						if (num != 545266181)
						{
							goto IL_37D;
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
				else if (num != 623704577)
				{
					if (num != 795562982)
					{
						goto IL_37D;
					}
					if (x5.h(m4.a(this.d), x5.c()))
					{
						string text = A_0.ao();
						if (text != null && text.Length > 0)
						{
							this.d = new h2(A_1.g().a(text.ToLower()));
							if (this.d.a().b() != i2.c && this.d.a().b() != i2.b)
							{
								this.d = new h2(new i4(i2.c, this.d.a().a()));
							}
						}
					}
				}
				else if (this.a == ea.a)
				{
					string text3 = A_0.ao().ToLower();
					if (text3 == null)
					{
						goto IL_1BB;
					}
					if (!(text3 == "left"))
					{
						if (!(text3 == "right"))
						{
							if (!(text3 == "center"))
							{
								if (!(text3 == "justify"))
								{
									goto IL_1BB;
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
					IL_1BB:
					this.a = ea.d;
				}
				continue;
				IL_37D:
				base.c(A_0);
			}
			A_0.ax();
		}

		// Token: 0x06000E0A RID: 3594 RVA: 0x0009DD0C File Offset: 0x0009CD0C
		internal ea a()
		{
			return this.a;
		}

		// Token: 0x06000E0B RID: 3595 RVA: 0x0009DD24 File Offset: 0x0009CD24
		internal void a(ea A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06000E0C RID: 3596 RVA: 0x0009DD30 File Offset: 0x0009CD30
		internal h2 b()
		{
			return this.c;
		}

		// Token: 0x06000E0D RID: 3597 RVA: 0x0009DD48 File Offset: 0x0009CD48
		internal h2 c()
		{
			return this.d;
		}

		// Token: 0x06000E0E RID: 3598 RVA: 0x0009DD60 File Offset: 0x0009CD60
		internal string d()
		{
			return this.b;
		}

		// Token: 0x06000E0F RID: 3599 RVA: 0x0009DD78 File Offset: 0x0009CD78
		internal override int cn()
		{
			return 1967;
		}

		// Token: 0x06000E10 RID: 3600 RVA: 0x0009DD90 File Offset: 0x0009CD90
		internal override string co()
		{
			return "hr";
		}

		// Token: 0x040006FF RID: 1791
		private ea a = ea.a;

		// Token: 0x04000700 RID: 1792
		private string b = null;

		// Token: 0x04000701 RID: 1793
		private new h2 c = new h2(new i4(i2.a, 0f));

		// Token: 0x04000702 RID: 1794
		private h2 d = new h2(new i4(i2.a, 0f));
	}
}
