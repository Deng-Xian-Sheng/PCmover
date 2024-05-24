using System;

namespace zz93
{
	// Token: 0x02000233 RID: 563
	internal class op : d0
	{
		// Token: 0x06001A3E RID: 6718 RVA: 0x00111CF8 File Offset: 0x00110CF8
		internal op(kg A_0, ij A_1)
		{
			while (!A_0.aj())
			{
				int num = A_0.al();
				if (num <= 144877216)
				{
					if (num <= 67814465)
					{
						if (num != 3407)
						{
							if (num != 67814465)
							{
								goto IL_4FC;
							}
							if (this.g == ga.e)
							{
								string text = A_0.ao().ToLower();
								if (text != null)
								{
									if (!(text == "left"))
									{
										if (!(text == "right"))
										{
											if (!(text == "up"))
											{
												if (text == "down")
												{
													this.g = ga.d;
												}
											}
											else
											{
												this.g = ga.c;
											}
										}
										else
										{
											this.g = ga.b;
										}
									}
									else
									{
										this.g = ga.a;
									}
								}
							}
						}
						else if (base.k() == null)
						{
							base.c(A_0.an());
						}
					}
					else if (num != 84285447)
					{
						if (num != 84285503)
						{
							if (num != 144877216)
							{
								goto IL_4FC;
							}
							if (base.m() == null)
							{
								string text2 = A_0.au();
								if (text2 != null)
								{
									base.a(new ig(A_1.a(text2.ToCharArray(), 0, text2.Length)));
								}
							}
						}
						else if (this.e.a().a() == 0f)
						{
							string text3 = A_0.ao();
							if (text3 != null && text3.Length > 0)
							{
								this.e = new h2(A_1.g().a(text3));
							}
						}
					}
					else if (this.f.a().a() == 0f)
					{
						string text3 = A_0.ao();
						if (text3 != null && text3.Length > 0)
						{
							this.f = new h2(A_1.g().a(text3));
						}
					}
				}
				else if (num <= 623704577)
				{
					if (num != 545266181)
					{
						if (num != 623704577)
						{
							goto IL_4FC;
						}
						if (this.a == ea.a)
						{
							string text = A_0.ao().ToLower();
							if (text == null)
							{
								goto IL_21F;
							}
							if (!(text == "left"))
							{
								if (!(text == "right"))
								{
									if (!(text == "center"))
									{
										if (!(text == "justify"))
										{
											goto IL_21F;
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
							IL_21F:
							this.a = ea.b;
						}
					}
					else if (base.l() == null)
					{
						base.a(A_0.am());
					}
				}
				else if (num != 677666251)
				{
					if (num != 791474715)
					{
						if (num != 795562982)
						{
							goto IL_4FC;
						}
						if (this.c.a().a() == 0f)
						{
							string text3 = A_0.ao();
							if (text3 != null && text3.Length > 0)
							{
								this.c = new h2(A_1.g().a(text3.ToLower()));
								if (this.c.a().b() != i2.c && this.c.a().b() != i2.b)
								{
									this.c = new h2(new i4(i2.c, this.c.a().a()));
								}
							}
						}
					}
					else if (this.d.a().a() == 0f)
					{
						string text3 = A_0.ao();
						if (text3 != null && text3.Length > 0)
						{
							this.d = new h2(A_1.g().a(text3.ToLower()));
							if (this.d.a().b() != i2.c)
							{
								this.d = new h2(new i4(i2.c, this.d.a().a()));
							}
						}
					}
				}
				else if (this.b == null)
				{
					this.b = A_0.ao();
				}
				continue;
				IL_4FC:
				A_0.at();
			}
			A_0.ax();
		}

		// Token: 0x06001A3F RID: 6719 RVA: 0x00112224 File Offset: 0x00111224
		internal ea a()
		{
			return this.a;
		}

		// Token: 0x06001A40 RID: 6720 RVA: 0x0011223C File Offset: 0x0011123C
		internal h2 b()
		{
			return this.c;
		}

		// Token: 0x06001A41 RID: 6721 RVA: 0x00112254 File Offset: 0x00111254
		internal h2 c()
		{
			return this.d;
		}

		// Token: 0x06001A42 RID: 6722 RVA: 0x0011226C File Offset: 0x0011126C
		internal h2 d()
		{
			return this.e;
		}

		// Token: 0x06001A43 RID: 6723 RVA: 0x00112284 File Offset: 0x00111284
		internal h2 e()
		{
			return this.f;
		}

		// Token: 0x06001A44 RID: 6724 RVA: 0x0011229C File Offset: 0x0011129C
		internal string f()
		{
			return this.b;
		}

		// Token: 0x06001A45 RID: 6725 RVA: 0x001122B4 File Offset: 0x001112B4
		internal ga g()
		{
			return this.g;
		}

		// Token: 0x06001A46 RID: 6726 RVA: 0x001122CC File Offset: 0x001112CC
		internal override int cn()
		{
			return 594666565;
		}

		// Token: 0x06001A47 RID: 6727 RVA: 0x001122E4 File Offset: 0x001112E4
		internal override string co()
		{
			return "marquee";
		}

		// Token: 0x04000BF3 RID: 3059
		private ea a = ea.a;

		// Token: 0x04000BF4 RID: 3060
		private string b = null;

		// Token: 0x04000BF5 RID: 3061
		private new h2 c = new h2(new i4(i2.a, 0f));

		// Token: 0x04000BF6 RID: 3062
		private h2 d = new h2(new i4(i2.a, 0f));

		// Token: 0x04000BF7 RID: 3063
		private h2 e = new h2(new i4(i2.a, 0f));

		// Token: 0x04000BF8 RID: 3064
		private h2 f = new h2(new i4(i2.a, 0f));

		// Token: 0x04000BF9 RID: 3065
		private ga g = ga.e;
	}
}
