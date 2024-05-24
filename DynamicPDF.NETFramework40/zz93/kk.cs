using System;
using System.Collections.Generic;

namespace zz93
{
	// Token: 0x0200019C RID: 412
	internal class kk : d0
	{
		// Token: 0x06000E72 RID: 3698 RVA: 0x000ACCD8 File Offset: 0x000ABCD8
		internal kk()
		{
		}

		// Token: 0x06000E73 RID: 3699 RVA: 0x000ACD44 File Offset: 0x000ABD44
		internal kk(kg A_0, ij A_1)
		{
			while (!A_0.aj())
			{
				int num = A_0.al();
				if (num <= 144877216)
				{
					if (num <= 22432)
					{
						if (num != 3407)
						{
							if (num != 22432)
							{
								goto IL_505;
							}
							if (this.b == null)
							{
								this.b = A_0.aq();
							}
						}
						else if (base.k() == null)
						{
							base.c(A_0.an());
						}
					}
					else if (num != 109057)
					{
						if (num != 144877216)
						{
							goto IL_505;
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
					else if (this.a == null)
					{
						this.a = A_0.ao();
					}
				}
				else if (num <= 545266181)
				{
					if (num != 148235845)
					{
						if (num != 545266181)
						{
							goto IL_505;
						}
						if (base.l() == null)
						{
							base.a(A_0.am());
						}
					}
					else if (this.d == -2147483648)
					{
						string text2 = A_0.ao();
						if (text2 != null && text2.Length > 0)
						{
							int num2 = text2.IndexOfAny(new char[]
							{
								'%',
								'p'
							});
							int num3;
							if (num2 > 0)
							{
								this.d = int.Parse(text2.Substring(0, num2));
							}
							else if (int.TryParse(text2, out num3))
							{
								this.d = num3;
							}
						}
					}
				}
				else if (num != 623704577)
				{
					if (num != 791474715)
					{
						if (num != 795562982)
						{
							goto IL_505;
						}
						if (x5.h(m4.a(this.f), x5.c()))
						{
							string text2 = A_0.ao();
							if (text2 != null && text2.Length > 0)
							{
								text2 = text2.ToLower();
								this.f = new h2(A_1.g().a(text2));
								if (this.f.a().b() != i2.c && this.f.a().b() != i2.b)
								{
									this.f = new h2(new i4(i2.c, this.f.a().a()));
								}
							}
						}
					}
					else if (!this.g)
					{
						string text2 = A_0.ao();
						if (text2 != null && text2.Length > 0)
						{
							text2 = text2.ToLower();
							this.e = new h2(A_1.g().a(text2));
							if (this.e.a().b() != i2.c && this.e.a().b() != i2.b)
							{
								this.e = new h2(new i4(i2.c, this.e.a().a()));
							}
							this.g = true;
						}
					}
				}
				else if (this.c == ea.a)
				{
					string text3 = A_0.ao();
					if (text3 != null)
					{
						string text4 = text3.ToLower();
						if (text4 == null)
						{
							goto IL_2D8;
						}
						if (anl.qd == null)
						{
							anl.qd = new Dictionary<string, int>(6)
							{
								{
									"top",
									0
								},
								{
									"bottom",
									1
								},
								{
									"middle",
									2
								},
								{
									"center",
									3
								},
								{
									"left",
									4
								},
								{
									"right",
									5
								}
							};
						}
						int num4;
						if (!anl.qd.TryGetValue(text4, out num4))
						{
							goto IL_2D8;
						}
						switch (num4)
						{
						case 0:
							this.c = ea.e;
							break;
						case 1:
							this.c = ea.f;
							break;
						case 2:
							this.c = ea.d;
							break;
						case 3:
							this.c = ea.d;
							break;
						case 4:
							this.c = ea.b;
							break;
						case 5:
							this.c = ea.c;
							break;
						default:
							goto IL_2D8;
						}
						continue;
						IL_2D8:
						this.c = ea.f;
					}
				}
				continue;
				IL_505:
				base.c(A_0);
			}
			A_0.ax();
		}

		// Token: 0x06000E74 RID: 3700 RVA: 0x000AD27C File Offset: 0x000AC27C
		internal string a()
		{
			return this.a;
		}

		// Token: 0x06000E75 RID: 3701 RVA: 0x000AD294 File Offset: 0x000AC294
		internal void a(string A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06000E76 RID: 3702 RVA: 0x000AD2A0 File Offset: 0x000AC2A0
		internal string b()
		{
			return this.b;
		}

		// Token: 0x06000E77 RID: 3703 RVA: 0x000AD2B8 File Offset: 0x000AC2B8
		internal void b(string A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06000E78 RID: 3704 RVA: 0x000AD2C4 File Offset: 0x000AC2C4
		internal ea c()
		{
			return this.c;
		}

		// Token: 0x06000E79 RID: 3705 RVA: 0x000AD2DC File Offset: 0x000AC2DC
		internal int d()
		{
			return this.d;
		}

		// Token: 0x06000E7A RID: 3706 RVA: 0x000AD2F4 File Offset: 0x000AC2F4
		internal h2 e()
		{
			return this.e;
		}

		// Token: 0x06000E7B RID: 3707 RVA: 0x000AD30C File Offset: 0x000AC30C
		internal bool f()
		{
			return this.g;
		}

		// Token: 0x06000E7C RID: 3708 RVA: 0x000AD324 File Offset: 0x000AC324
		internal h2 g()
		{
			return this.f;
		}

		// Token: 0x06000E7D RID: 3709 RVA: 0x000AD33C File Offset: 0x000AC33C
		internal override int cn()
		{
			return 46415;
		}

		// Token: 0x06000E7E RID: 3710 RVA: 0x000AD354 File Offset: 0x000AC354
		internal override string co()
		{
			return "img";
		}

		// Token: 0x0400071B RID: 1819
		private string a = null;

		// Token: 0x0400071C RID: 1820
		private string b = null;

		// Token: 0x0400071D RID: 1821
		private new ea c = ea.a;

		// Token: 0x0400071E RID: 1822
		private int d = int.MinValue;

		// Token: 0x0400071F RID: 1823
		private h2 e = new h2(new i4(i2.a, 0f));

		// Token: 0x04000720 RID: 1824
		private h2 f = new h2(new i4(i2.a, 0f));

		// Token: 0x04000721 RID: 1825
		private bool g = false;
	}
}
