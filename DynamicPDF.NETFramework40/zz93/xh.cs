using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x0200037E RID: 894
	internal class xh : xg
	{
		// Token: 0x0600260A RID: 9738 RVA: 0x00162CB7 File Offset: 0x00161CB7
		internal xh(x5 A_0) : base(A_0)
		{
		}

		// Token: 0x0600260B RID: 9739 RVA: 0x00162CCC File Offset: 0x00161CCC
		internal void a(ReportPart A_0, LayoutWriter A_1)
		{
			if (A_0.HasElements)
			{
				A_0.Elements.a(this, A_1);
			}
		}

		// Token: 0x0600260C RID: 9740 RVA: 0x00162CF8 File Offset: 0x00161CF8
		internal override void f9(PageWriter A_0, x5 A_1, x5 A_2)
		{
			xx xx = base.h();
			A_0.SetDimensionsShift(x5.b(A_1), x5.b(A_2), A_0.Dimensions.Body.Width, x5.b(base.d()));
			while (xx != null)
			{
				xx.a().Draw(A_0);
				xx = xx.b();
			}
			A_0.ResetDimensions();
		}

		// Token: 0x0600260D RID: 9741 RVA: 0x00162D68 File Offset: 0x00161D68
		internal override void ga(PageWriter A_0, x5 A_1)
		{
			xx xx = base.h();
			A_0.SetDimensionsShift(0f, x5.b(A_1), A_0.Dimensions.Body.Width, x5.b(base.d()));
			while (xx != null)
			{
				xx.a().Draw(A_0);
				xx = xx.b();
			}
			A_0.ResetDimensions();
		}

		// Token: 0x0600260E RID: 9742 RVA: 0x00162DD8 File Offset: 0x00161DD8
		internal override void gb(PageWriter A_0, x5 A_1, x5 A_2, x5 A_3)
		{
			xx xx = base.h();
			A_0.SetDimensionsShift(x5.b(A_1), x5.b(A_2), x5.b(A_3), x5.b(base.d()));
			while (xx != null)
			{
				xx.a().Draw(A_0);
				xx = xx.b();
			}
			A_0.ResetDimensions();
		}

		// Token: 0x0600260F RID: 9743 RVA: 0x00162E40 File Offset: 0x00161E40
		internal ws a()
		{
			if (this.a == null)
			{
				this.a = new ws();
			}
			return this.a;
		}

		// Token: 0x06002610 RID: 9744 RVA: 0x00162E73 File Offset: 0x00161E73
		internal void b()
		{
			this.a = null;
		}

		// Token: 0x06002611 RID: 9745 RVA: 0x00162E80 File Offset: 0x00161E80
		internal override int gc()
		{
			return this.b;
		}

		// Token: 0x06002612 RID: 9746 RVA: 0x00162E98 File Offset: 0x00161E98
		internal override void gd(int A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06002613 RID: 9747 RVA: 0x00162EA4 File Offset: 0x00161EA4
		internal void c()
		{
			if (this.a != null && this.a.a())
			{
				acm acm = new acm();
				this.a.a(acm);
				if (acm.b())
				{
					dv dv = acm.a();
					for (xx xx = base.h(); xx != null; xx = xx.b())
					{
						xx.a().b5(dv);
					}
					if (base.i() != null)
					{
						base.i().e();
						base.i().a(acm);
					}
					if (base.j() != null)
					{
						base.j().e();
						base.j().a(acm);
					}
					if (base.k() != null)
					{
						base.k().c();
						base.k().a(acm);
					}
					base.a(x5.f(base.d(), dv.a()));
				}
			}
		}

		// Token: 0x040010A3 RID: 4259
		private new ws a;

		// Token: 0x040010A4 RID: 4260
		private new int b = -1;
	}
}
