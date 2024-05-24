using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x02000435 RID: 1077
	internal class ab3
	{
		// Token: 0x06002C9C RID: 11420 RVA: 0x001978D4 File Offset: 0x001968D4
		internal ab3(abj A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06002C9D RID: 11421 RVA: 0x00197930 File Offset: 0x00196930
		private abj a(aba A_0)
		{
			abj result = null;
			abk abk = this.a.l();
			while (abk != null)
			{
				int num = abk.a().j8();
				if (num <= 3825204)
				{
					if (num <= 6)
					{
						switch (num)
						{
						case 1:
							this.e = (abj)abk.c().h6();
							abk.a(false);
							break;
						case 2:
							goto IL_21E;
						case 3:
							this.d = (abe)abk.c().h6();
							abk.a(false);
							break;
						default:
							if (num != 6)
							{
								goto IL_21E;
							}
							this.h = (TextStyle)((abw)abk.c().h6()).kd();
							abk.a(false);
							break;
						}
					}
					else if (num != 1203444)
					{
						if (num != 3284212)
						{
							if (num != 3825204)
							{
								goto IL_21E;
							}
							result = (abj)abk.c().h6();
							abk.a(false);
						}
						else
						{
							abk.a(false);
						}
					}
					else
					{
						this.f = abk.c().h6();
						abk.a(false);
					}
				}
				else if (num <= 62872500)
				{
					if (num != 4401526)
					{
						if (num != 62872500)
						{
							goto IL_21E;
						}
						if (((abw)abk.c().h6()).kd() > 0)
						{
							this.i = true;
						}
						abk.a(false);
					}
					else
					{
						abk.a(false);
					}
				}
				else if (num != 111619316)
				{
					if (num != 277293402)
					{
						if (num != 346508069)
						{
							goto IL_21E;
						}
						this.g = (ab7)abk.c().h6();
						abk.a(false);
					}
					else
					{
						abk.a(false);
					}
				}
				else
				{
					abj abj = (abj)abk.c().h6();
					if (abj != null)
					{
						this.b = new ab3(abj);
						this.b.b(A_0);
						abk.a(false);
					}
				}
				IL_227:
				abk = abk.d();
				continue;
				IL_21E:
				this.j = true;
				goto IL_227;
			}
			return result;
		}

		// Token: 0x06002C9E RID: 11422 RVA: 0x00197B84 File Offset: 0x00196B84
		internal void b(aba A_0)
		{
			abj abj = this.a(A_0);
			ab3 ab = this;
			while (abj != null)
			{
				ab.a(new ab3(abj));
				abj = ab.g().a(A_0);
				ab = ab.g();
			}
		}

		// Token: 0x06002C9F RID: 11423 RVA: 0x00197BCC File Offset: 0x00196BCC
		internal void a(DocumentWriter A_0)
		{
			if (this.j)
			{
				this.a.b(A_0);
			}
		}

		// Token: 0x06002CA0 RID: 11424 RVA: 0x00197BF4 File Offset: 0x00196BF4
		internal TextStyle b()
		{
			return this.h;
		}

		// Token: 0x06002CA1 RID: 11425 RVA: 0x00197C0C File Offset: 0x00196C0C
		internal bool c()
		{
			return this.i;
		}

		// Token: 0x06002CA2 RID: 11426 RVA: 0x00197C24 File Offset: 0x00196C24
		internal ab7 d()
		{
			return this.g;
		}

		// Token: 0x06002CA3 RID: 11427 RVA: 0x00197C3C File Offset: 0x00196C3C
		internal abe e()
		{
			return this.d;
		}

		// Token: 0x06002CA4 RID: 11428 RVA: 0x00197C54 File Offset: 0x00196C54
		internal ab3 f()
		{
			return this.b;
		}

		// Token: 0x06002CA5 RID: 11429 RVA: 0x00197C6C File Offset: 0x00196C6C
		internal ab3 g()
		{
			return this.c;
		}

		// Token: 0x06002CA6 RID: 11430 RVA: 0x00197C84 File Offset: 0x00196C84
		internal void a(ab3 A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06002CA7 RID: 11431 RVA: 0x00197C90 File Offset: 0x00196C90
		internal RgbColor h()
		{
			RgbColor result;
			if (this.d == null)
			{
				result = null;
			}
			else
			{
				result = new RgbColor(((abw)this.d.a(0)).ke(), ((abw)this.d.a(1)).ke(), ((abw)this.d.a(2)).ke());
			}
			return result;
		}

		// Token: 0x06002CA8 RID: 11432 RVA: 0x00197D00 File Offset: 0x00196D00
		internal ceTe.DynamicPDF.Action i()
		{
			ceTe.DynamicPDF.Action result;
			if (this.e != null)
			{
				result = new ImportedAction(this.e);
			}
			else if (this.f != null)
			{
				result = new ImportedDestination(this.f);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06002CA9 RID: 11433 RVA: 0x00197D4C File Offset: 0x00196D4C
		internal abd j()
		{
			abd result;
			if (this.e != null)
			{
				result = this.a();
			}
			else if (this.f != null)
			{
				result = this.f;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06002CAA RID: 11434 RVA: 0x00197D90 File Offset: 0x00196D90
		private abd a()
		{
			abd result = null;
			for (abk abk = this.e.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num != 4)
				{
					if (num == 19)
					{
						abu abu = (abu)abk.c();
						if (abu.j8() != 2028847)
						{
							return null;
						}
					}
				}
				else
				{
					result = abk.c();
				}
			}
			return result;
		}

		// Token: 0x040014F3 RID: 5363
		private abj a;

		// Token: 0x040014F4 RID: 5364
		private ab3 b = null;

		// Token: 0x040014F5 RID: 5365
		private ab3 c = null;

		// Token: 0x040014F6 RID: 5366
		private abe d = null;

		// Token: 0x040014F7 RID: 5367
		private abj e = null;

		// Token: 0x040014F8 RID: 5368
		private abd f = null;

		// Token: 0x040014F9 RID: 5369
		private ab7 g = null;

		// Token: 0x040014FA RID: 5370
		private TextStyle h = TextStyle.Regular;

		// Token: 0x040014FB RID: 5371
		private bool i = false;

		// Token: 0x040014FC RID: 5372
		private bool j = false;
	}
}
