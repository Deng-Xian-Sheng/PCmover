using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements;

namespace zz93
{
	// Token: 0x020005B8 RID: 1464
	internal class amj
	{
		// Token: 0x06003A02 RID: 14850 RVA: 0x001F2D34 File Offset: 0x001F1D34
		internal amj()
		{
		}

		// Token: 0x06003A03 RID: 14851 RVA: 0x001F2D48 File Offset: 0x001F1D48
		internal am6 h()
		{
			return this.a;
		}

		// Token: 0x06003A04 RID: 14852 RVA: 0x001F2D60 File Offset: 0x001F1D60
		internal void a(am6 A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06003A05 RID: 14853 RVA: 0x001F2D6C File Offset: 0x001F1D6C
		internal ane i()
		{
			return this.c;
		}

		// Token: 0x06003A06 RID: 14854 RVA: 0x001F2D84 File Offset: 0x001F1D84
		internal void a(ane A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06003A07 RID: 14855 RVA: 0x001F2D90 File Offset: 0x001F1D90
		internal ane j()
		{
			return this.d;
		}

		// Token: 0x06003A08 RID: 14856 RVA: 0x001F2DA8 File Offset: 0x001F1DA8
		internal void b(ane A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06003A09 RID: 14857 RVA: 0x001F2DB4 File Offset: 0x001F1DB4
		internal anc k()
		{
			return this.e;
		}

		// Token: 0x06003A0A RID: 14858 RVA: 0x001F2DCC File Offset: 0x001F1DCC
		internal void a(anc A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06003A0B RID: 14859 RVA: 0x001F2DD8 File Offset: 0x001F1DD8
		internal bool a(alp A_0)
		{
			bool result;
			if (this.c != null && this.c.b())
			{
				result = true;
			}
			else
			{
				if (A_0.e().e())
				{
					for (am6 am = this.a; am != null; am = am.b())
					{
						if (am.a().cb() == 239)
						{
							am1 am2 = (am1)am.a();
							for (amk amk = am2.e().e(); amk != null; amk = amk.e())
							{
								if (amk.a(am2.f()))
								{
									return true;
								}
							}
						}
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06003A0C RID: 14860 RVA: 0x001F2EB4 File Offset: 0x001F1EB4
		internal x5 a(alp A_0, x5 A_1)
		{
			x5 x = x5.b();
			if (this.c != null && this.c.b())
			{
				x = x5.f(this.c.c(), A_1);
			}
			if (A_0.e().e())
			{
				am6 am = this.a;
				x5 x2 = x5.b();
				x5 x3 = x5.b();
				am1 am2 = null;
				amk amk = null;
				while (am != null)
				{
					if (am.a().cb() == 239)
					{
						am1 am3 = (am1)am.a();
						amk amk2 = am3.e().e();
						x5 x4 = x5.a(am3.f().Header.Height + am3.f().Footer.Height);
						while (amk2 != null)
						{
							if (amk2.a(am3.f()))
							{
								x3 = x5.f(x5.f(amk2.a(am3.f(), am3.b7()), x4), A_1);
								break;
							}
							x4 = x5.f(x4, amk2.d());
							amk2 = amk2.e();
						}
						if (x5.d(x3, x2))
						{
							x2 = x3;
							if (amk != null)
							{
								amk.i().d();
							}
							amk = amk2;
							am2 = am3;
						}
					}
					am = am.b();
				}
				if (x5.d(x2, x))
				{
					if (this.c != null && x5.g(x, x5.b()))
					{
						this.c.d();
					}
					am2.a(true);
					x = x2;
				}
				else if (amk != null)
				{
					amk.c.d();
				}
			}
			return x;
		}

		// Token: 0x06003A0D RID: 14861 RVA: 0x001F30BC File Offset: 0x001F20BC
		internal void b(am6 A_0)
		{
			if (this.a == null)
			{
				this.b = A_0;
				this.a = A_0;
			}
			else
			{
				am6 am = this.b;
				this.b = A_0;
				am.a(A_0);
			}
			this.f++;
		}

		// Token: 0x06003A0E RID: 14862 RVA: 0x001F3114 File Offset: 0x001F2114
		internal void a(PageElement A_0)
		{
			if (this.a == null)
			{
				this.a = (this.b = new am6(A_0));
			}
			else
			{
				this.b.a(this.b = new am6(A_0));
			}
			this.f++;
		}

		// Token: 0x06003A0F RID: 14863 RVA: 0x001F3178 File Offset: 0x001F2178
		internal void a(PageWriter A_0)
		{
			for (am6 am = this.a; am != null; am = am.b())
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
			}
		}

		// Token: 0x06003A10 RID: 14864 RVA: 0x001F3210 File Offset: 0x001F2210
		internal virtual void nk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			am6 am = this.h();
			A_0.SetDimensionsShift(x5.b(A_1), x5.b(A_2), A_0.Dimensions.Body.Width, A_0.Dimensions.Body.Height);
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

		// Token: 0x06003A11 RID: 14865 RVA: 0x001F32E4 File Offset: 0x001F22E4
		internal virtual void nl(PageWriter A_0, x5 A_1)
		{
			am6 am = this.h();
			A_0.SetDimensionsShift(0f, x5.b(A_1), A_0.Dimensions.Body.Width, A_0.Dimensions.Body.Height);
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

		// Token: 0x06003A12 RID: 14866 RVA: 0x001F33B4 File Offset: 0x001F23B4
		internal virtual void nm(PageWriter A_0, x5 A_1, x5 A_2, x5 A_3)
		{
			am6 am = this.h();
			A_0.SetDimensionsShift(x5.b(A_1), x5.b(A_2), x5.b(A_3), A_0.Dimensions.Body.Height);
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

		// Token: 0x04001B82 RID: 7042
		private am6 a;

		// Token: 0x04001B83 RID: 7043
		private am6 b;

		// Token: 0x04001B84 RID: 7044
		private ane c;

		// Token: 0x04001B85 RID: 7045
		private ane d;

		// Token: 0x04001B86 RID: 7046
		private anc e;

		// Token: 0x04001B87 RID: 7047
		private int f = 0;
	}
}
