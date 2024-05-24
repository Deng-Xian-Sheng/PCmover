using System;

namespace zz93
{
	// Token: 0x02000188 RID: 392
	internal class j0 : d0
	{
		// Token: 0x06000DC9 RID: 3529 RVA: 0x0009BC94 File Offset: 0x0009AC94
		internal j0(kg A_0, ij A_1)
		{
			while (!A_0.aj())
			{
				int num = A_0.al();
				if (num <= 2163680)
				{
					if (num != 3407)
					{
						if (num != 2117746)
						{
							if (num != 2163680)
							{
								goto IL_2B8;
							}
							if (this.c == -2147483648)
							{
								string text = A_0.ao();
								if (text != null && !text.Contains("px"))
								{
									if (text.Contains("pt"))
									{
										text = text.Remove(text.Length - 2);
									}
									if (text.Contains("+"))
									{
										this.d = 1;
									}
									else if (text.Contains("-"))
									{
										this.d = 2;
									}
									if (text.Contains("."))
									{
										text = text.Substring(0, text.Length - (text.IndexOf('.') + 1));
									}
									int num2 = int.Parse(text.Trim(new char[]
									{
										'+',
										'-',
										' '
									}));
									if (num2 <= 0)
									{
										this.c = 1;
									}
									else if (num2 == 2147483647)
									{
										this.c = 3;
									}
									else if (num2 > 7)
									{
										this.c = 7;
									}
									else
									{
										this.c = num2;
									}
								}
							}
						}
						else if (this.b == null)
						{
							string text2 = A_0.ao();
							if (text2 != null && text2.Length > 0)
							{
								char[] separator = new char[]
								{
									','
								};
								this.b = text2.Split(separator);
							}
						}
					}
					else if (base.k() == null)
					{
						base.c(A_0.an());
					}
				}
				else if (num != 144877216)
				{
					if (num != 510035525)
					{
						if (num != 545266181)
						{
							goto IL_2B8;
						}
						if (base.l() == null)
						{
							base.a(A_0.am());
						}
					}
					else
					{
						this.a = A_0.ao();
					}
				}
				else if (base.m() == null)
				{
					string text3 = A_0.au();
					if (text3 != null)
					{
						base.a(new ig(A_1.a(text3.ToCharArray(), 0, text3.Length)));
					}
				}
				continue;
				IL_2B8:
				base.c(A_0);
			}
			A_0.ax();
		}

		// Token: 0x06000DCA RID: 3530 RVA: 0x0009BF80 File Offset: 0x0009AF80
		internal string a()
		{
			return this.a;
		}

		// Token: 0x06000DCB RID: 3531 RVA: 0x0009BF98 File Offset: 0x0009AF98
		internal string[] b()
		{
			return this.b;
		}

		// Token: 0x06000DCC RID: 3532 RVA: 0x0009BFB0 File Offset: 0x0009AFB0
		internal int c()
		{
			return this.c;
		}

		// Token: 0x06000DCD RID: 3533 RVA: 0x0009BFC8 File Offset: 0x0009AFC8
		internal int d()
		{
			return this.d;
		}

		// Token: 0x06000DCE RID: 3534 RVA: 0x0009BFE0 File Offset: 0x0009AFE0
		internal override int cn()
		{
			return 6968946;
		}

		// Token: 0x06000DCF RID: 3535 RVA: 0x0009BFF8 File Offset: 0x0009AFF8
		internal override string co()
		{
			return "font";
		}

		// Token: 0x040006EC RID: 1772
		private string a = null;

		// Token: 0x040006ED RID: 1773
		private string[] b = null;

		// Token: 0x040006EE RID: 1774
		private new int c = int.MinValue;

		// Token: 0x040006EF RID: 1775
		private int d = 0;
	}
}
