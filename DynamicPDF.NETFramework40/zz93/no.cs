using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x0200020E RID: 526
	internal class no : k0
	{
		// Token: 0x06001816 RID: 6166 RVA: 0x00100ED4 File Offset: 0x000FFED4
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x06001817 RID: 6167 RVA: 0x00100EEC File Offset: 0x000FFEEC
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x06001818 RID: 6168 RVA: 0x00100EFC File Offset: 0x000FFEFC
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x06001819 RID: 6169 RVA: 0x00100F14 File Offset: 0x000FFF14
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x0600181A RID: 6170 RVA: 0x00100F20 File Offset: 0x000FFF20
		internal override int dg()
		{
			return 306046640;
		}

		// Token: 0x0600181B RID: 6171 RVA: 0x00100F38 File Offset: 0x000FFF38
		internal override k0 dd()
		{
			return new no();
		}

		// Token: 0x0600181C RID: 6172 RVA: 0x00100F50 File Offset: 0x000FFF50
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x0600181D RID: 6173 RVA: 0x00100F6F File Offset: 0x000FFF6F
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x0600181E RID: 6174 RVA: 0x00100F7C File Offset: 0x000FFF7C
		internal override kz dj(x5 A_0, x5 A_1)
		{
			return base.c(A_0, A_1);
		}

		// Token: 0x0600181F RID: 6175 RVA: 0x00100F96 File Offset: 0x000FFF96
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c(A_0, A_1, A_2);
		}

		// Token: 0x06001820 RID: 6176 RVA: 0x00100FA4 File Offset: 0x000FFFA4
		internal override kz dl()
		{
			return base.am();
		}

		// Token: 0x06001821 RID: 6177 RVA: 0x00100FBC File Offset: 0x000FFFBC
		internal override kz dm()
		{
			no no = new no();
			no.j(this.dr());
			no.dc(this.db().du());
			no.a((lk)base.c5().du());
			no.df(this.b);
			if (base.n() != null)
			{
				no.c(base.n().p());
			}
			return no;
		}

		// Token: 0x04000ADB RID: 2779
		private new n5 a = new n5();

		// Token: 0x04000ADC RID: 2780
		private new bool b = false;
	}
}
