using System;
using ceTe.DynamicPDF.PageElements.Html;

namespace zz93
{
	// Token: 0x020000BB RID: 187
	internal class eb : d0
	{
		// Token: 0x060008EF RID: 2287 RVA: 0x0007A16F File Offset: 0x0007916F
		internal eb()
		{
		}

		// Token: 0x060008F0 RID: 2288 RVA: 0x0007A188 File Offset: 0x00079188
		internal eb(kg A_0, ij A_1)
		{
			while (!A_0.aj())
			{
				int num = A_0.al();
				if (num <= 2183269)
				{
					if (num != 3407)
					{
						if (num != 2183269)
						{
							goto IL_186;
						}
						if (this.b == null)
						{
							this.b = A_0.ao();
							this.b = "#" + this.b;
							k5 value = new k5();
							if (!A_0.y().h().Contains(this.b))
							{
								A_0.y().h().Add(this.b, value);
							}
						}
						else
						{
							A_0.at();
						}
					}
					else if (base.k() == null)
					{
						base.c(A_0.an());
					}
				}
				else if (num != 13141935)
				{
					if (num != 144877216)
					{
						if (num != 545266181)
						{
							goto IL_186;
						}
						if (base.l() == null)
						{
							base.a(A_0.am());
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
				else if (this.a == null)
				{
					this.a = A_0.ao();
				}
				continue;
				IL_186:
				base.c(A_0);
			}
			A_0.ax();
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x0007A340 File Offset: 0x00079340
		internal HtmlArea a()
		{
			return this.c;
		}

		// Token: 0x060008F2 RID: 2290 RVA: 0x0007A358 File Offset: 0x00079358
		internal void a(HtmlArea A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060008F3 RID: 2291 RVA: 0x0007A364 File Offset: 0x00079364
		internal string b()
		{
			return this.a;
		}

		// Token: 0x060008F4 RID: 2292 RVA: 0x0007A37C File Offset: 0x0007937C
		internal string c()
		{
			return this.b;
		}

		// Token: 0x060008F5 RID: 2293 RVA: 0x0007A394 File Offset: 0x00079394
		internal override int cn()
		{
			return 1;
		}

		// Token: 0x060008F6 RID: 2294 RVA: 0x0007A3A8 File Offset: 0x000793A8
		internal override string co()
		{
			return "a";
		}

		// Token: 0x040004A8 RID: 1192
		private string a = null;

		// Token: 0x040004A9 RID: 1193
		private string b = null;

		// Token: 0x040004AA RID: 1194
		private new HtmlArea c;
	}
}
