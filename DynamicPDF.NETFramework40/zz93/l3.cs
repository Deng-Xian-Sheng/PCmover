using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001D3 RID: 467
	internal class l3 : k0
	{
		// Token: 0x060013D2 RID: 5074 RVA: 0x000DEBE8 File Offset: 0x000DDBE8
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x060013D3 RID: 5075 RVA: 0x000DEC00 File Offset: 0x000DDC00
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x060013D4 RID: 5076 RVA: 0x000DEC10 File Offset: 0x000DDC10
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x060013D5 RID: 5077 RVA: 0x000DEC28 File Offset: 0x000DDC28
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060013D6 RID: 5078 RVA: 0x000DEC34 File Offset: 0x000DDC34
		internal override int dg()
		{
			return 6968946;
		}

		// Token: 0x060013D7 RID: 5079 RVA: 0x000DEC4C File Offset: 0x000DDC4C
		internal override k0 dd()
		{
			return new l3();
		}

		// Token: 0x060013D8 RID: 5080 RVA: 0x000DEC64 File Offset: 0x000DDC64
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x060013D9 RID: 5081 RVA: 0x000DEC83 File Offset: 0x000DDC83
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x060013DA RID: 5082 RVA: 0x000DEC90 File Offset: 0x000DDC90
		internal override kz dj(x5 A_0, x5 A_1)
		{
			return base.c(A_0, A_1);
		}

		// Token: 0x060013DB RID: 5083 RVA: 0x000DECAA File Offset: 0x000DDCAA
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c(A_0, A_1, A_2);
		}

		// Token: 0x060013DC RID: 5084 RVA: 0x000DECB8 File Offset: 0x000DDCB8
		internal override kz dl()
		{
			return base.am();
		}

		// Token: 0x060013DD RID: 5085 RVA: 0x000DECD0 File Offset: 0x000DDCD0
		internal override kz dm()
		{
			l3 l = new l3();
			l.j(this.dr());
			l.dc(this.db().du());
			l.a((lk)base.c5().du());
			l.df(this.b);
			if (base.n() != null)
			{
				l.c(base.n().p());
			}
			return l;
		}

		// Token: 0x04000958 RID: 2392
		private new n5 a = new n5();

		// Token: 0x04000959 RID: 2393
		private new bool b = false;
	}
}
