using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.PageElements;

namespace zz93
{
	// Token: 0x020005BA RID: 1466
	internal class aml : amk
	{
		// Token: 0x06003A1D RID: 14877 RVA: 0x001F361F File Offset: 0x001F261F
		internal aml(x5 A_0) : base(A_0)
		{
		}

		// Token: 0x06003A1E RID: 14878 RVA: 0x001F3634 File Offset: 0x001F2634
		internal void a(ReportPart A_0, LayoutWriter A_1)
		{
			if (A_0.HasElements)
			{
				A_0.Elements.a(this, A_1);
			}
		}

		// Token: 0x06003A1F RID: 14879 RVA: 0x001F3660 File Offset: 0x001F2660
		internal override void nk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			am6 am = base.h();
			A_0.SetDimensionsShift(x5.b(A_1), x5.b(A_2), A_0.Dimensions.Body.Width, x5.b(base.d()));
			while (am != null)
			{
				if (am.a() is ContentArea)
				{
					((ContentArea)am.a()).a(true);
				}
				if (!(am.a() is Image) && !(am.a() is FormattedTextArea))
				{
					A_0.RequireLicense(am.a().RequiredLicenseLevel);
				}
				am.a().Draw(A_0);
				am = am.b();
			}
			A_0.ResetDimensions();
		}

		// Token: 0x06003A20 RID: 14880 RVA: 0x001F3730 File Offset: 0x001F2730
		internal override void nl(PageWriter A_0, x5 A_1)
		{
			am6 am = base.h();
			A_0.SetDimensionsShift(0f, x5.b(A_1), A_0.Dimensions.Body.Width, x5.b(base.d()));
			while (am != null)
			{
				if (am.a() is ContentArea)
				{
					((ContentArea)am.a()).a(true);
				}
				if (!(am.a() is Image) && !(am.a() is FormattedTextArea))
				{
					A_0.RequireLicense(am.a().RequiredLicenseLevel);
				}
				am.a().Draw(A_0);
				am = am.b();
			}
			A_0.ResetDimensions();
		}

		// Token: 0x06003A21 RID: 14881 RVA: 0x001F37FC File Offset: 0x001F27FC
		internal override void nm(PageWriter A_0, x5 A_1, x5 A_2, x5 A_3)
		{
			am6 am = base.h();
			A_0.SetDimensionsShift(x5.b(A_1), x5.b(A_2), x5.b(A_3), x5.b(base.d()));
			while (am != null)
			{
				if (am.a() is ContentArea)
				{
					((ContentArea)am.a()).a(true);
				}
				if (!(am.a() is Image) && !(am.a() is FormattedTextArea))
				{
					A_0.RequireLicense(am.a().RequiredLicenseLevel);
				}
				am.a().Draw(A_0);
				am = am.b();
			}
			A_0.ResetDimensions();
		}

		// Token: 0x06003A22 RID: 14882 RVA: 0x001F38C4 File Offset: 0x001F28C4
		internal aln a()
		{
			if (this.a == null)
			{
				this.a = new aln();
			}
			return this.a;
		}

		// Token: 0x06003A23 RID: 14883 RVA: 0x001F38F7 File Offset: 0x001F28F7
		internal void b()
		{
			this.a = null;
		}

		// Token: 0x06003A24 RID: 14884 RVA: 0x001F3904 File Offset: 0x001F2904
		internal override int nn()
		{
			return this.b;
		}

		// Token: 0x06003A25 RID: 14885 RVA: 0x001F391C File Offset: 0x001F291C
		internal override void no(int A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06003A26 RID: 14886 RVA: 0x001F3928 File Offset: 0x001F2928
		internal void c()
		{
			if (this.a != null && this.a.a())
			{
				acm acm = new acm();
				this.a.a(acm);
				if (acm.b())
				{
					dv dv = acm.a();
					for (am6 am = base.h(); am != null; am = am.b())
					{
						am.a().b5(dv);
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

		// Token: 0x04001B8A RID: 7050
		private new aln a;

		// Token: 0x04001B8B RID: 7051
		private new int b = -1;
	}
}
