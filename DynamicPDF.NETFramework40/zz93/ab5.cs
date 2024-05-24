using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000437 RID: 1079
	internal class ab5 : abd
	{
		// Token: 0x06002CAD RID: 11437 RVA: 0x00197EE0 File Offset: 0x00196EE0
		internal ab5(abe A_0)
		{
			this.a = (abw)A_0.a(0).h6();
			this.b = (abw)A_0.a(1).h6();
			this.c = (abw)A_0.a(2).h6();
			this.d = (abw)A_0.a(3).h6();
		}

		// Token: 0x06002CAE RID: 11438 RVA: 0x00197F54 File Offset: 0x00196F54
		internal abw b()
		{
			return this.a;
		}

		// Token: 0x06002CAF RID: 11439 RVA: 0x00197F6C File Offset: 0x00196F6C
		internal abw c()
		{
			this.a();
			return this.e;
		}

		// Token: 0x06002CB0 RID: 11440 RVA: 0x00197F8C File Offset: 0x00196F8C
		internal abw d()
		{
			this.a();
			return this.f;
		}

		// Token: 0x06002CB1 RID: 11441 RVA: 0x00197FAC File Offset: 0x00196FAC
		internal abw e()
		{
			this.a();
			return this.g;
		}

		// Token: 0x06002CB2 RID: 11442 RVA: 0x00197FCC File Offset: 0x00196FCC
		internal abw f()
		{
			this.a();
			return this.h;
		}

		// Token: 0x06002CB3 RID: 11443 RVA: 0x00197FEC File Offset: 0x00196FEC
		private void a()
		{
			if (this.e == null)
			{
				if (this.a.ke() < this.c.ke())
				{
					this.e = this.a;
					this.g = this.c;
				}
				else
				{
					this.e = this.c;
					this.g = this.a;
				}
				if (this.b.ke() < this.d.ke())
				{
					this.f = this.b;
					this.h = this.d;
				}
				else
				{
					this.f = this.d;
					this.h = this.b;
				}
			}
		}

		// Token: 0x06002CB4 RID: 11444 RVA: 0x001980BC File Offset: 0x001970BC
		internal override ag9 hy()
		{
			return ag9.f;
		}

		// Token: 0x06002CB5 RID: 11445 RVA: 0x001980D4 File Offset: 0x001970D4
		internal override void hz(DocumentWriter A_0)
		{
			if (base.p())
			{
				A_0.WriteArrayOpen();
				this.a.hz(A_0);
				this.b.hz(A_0);
				this.c.hz(A_0);
				this.d.hz(A_0);
				A_0.WriteArrayClose();
			}
		}

		// Token: 0x06002CB6 RID: 11446 RVA: 0x00198134 File Offset: 0x00197134
		internal override void h9(agx A_0, DocumentWriter A_1)
		{
			if (base.p())
			{
				A_1.WriteArrayOpen();
				this.a.h9(A_0, A_1);
				this.b.h9(A_0, A_1);
				this.c.h9(A_0, A_1);
				this.d.h9(A_0, A_1);
				A_1.WriteArrayClose();
			}
		}

		// Token: 0x040014FE RID: 5374
		private abw a;

		// Token: 0x040014FF RID: 5375
		private abw b;

		// Token: 0x04001500 RID: 5376
		private abw c;

		// Token: 0x04001501 RID: 5377
		private abw d;

		// Token: 0x04001502 RID: 5378
		private abw e;

		// Token: 0x04001503 RID: 5379
		private abw f;

		// Token: 0x04001504 RID: 5380
		private abw g;

		// Token: 0x04001505 RID: 5381
		private abw h;
	}
}
