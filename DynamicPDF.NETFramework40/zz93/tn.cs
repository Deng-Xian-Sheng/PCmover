using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x020002F0 RID: 752
	internal class tn : ra
	{
		// Token: 0x06002172 RID: 8562 RVA: 0x00145C84 File Offset: 0x00144C84
		internal tn(w5 A_0)
		{
			decimal d = (int)(A_0.c() - '0');
			A_0.o();
			while (A_0.p())
			{
				d *= 10m;
				d += (int)(A_0.c() - '0');
				A_0.o();
			}
			if (A_0.c() == '.')
			{
				A_0.o();
				int num = 1;
				while (A_0.p())
				{
					d *= 10m;
					d += (int)(A_0.c() - '0');
					num *= 10;
					A_0.o();
				}
				d /= num;
			}
			this.a = d;
		}

		// Token: 0x06002173 RID: 8563 RVA: 0x00145D58 File Offset: 0x00144D58
		internal override bool eq(LayoutWriter A_0)
		{
			return false;
		}

		// Token: 0x06002174 RID: 8564 RVA: 0x00145D6C File Offset: 0x00144D6C
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return false;
		}

		// Token: 0x06002175 RID: 8565 RVA: 0x00145D80 File Offset: 0x00144D80
		internal override decimal ei(LayoutWriter A_0)
		{
			return this.a;
		}

		// Token: 0x06002176 RID: 8566 RVA: 0x00145D98 File Offset: 0x00144D98
		internal override decimal ej(LayoutWriter A_0, vi A_1)
		{
			return this.a;
		}

		// Token: 0x06002177 RID: 8567 RVA: 0x00145DB0 File Offset: 0x00144DB0
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
		}

		// Token: 0x04000EA7 RID: 3751
		private new decimal a;
	}
}
