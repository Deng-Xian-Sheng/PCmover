using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x020005BD RID: 1469
	internal class amo : PageElement, ru
	{
		// Token: 0x06003A30 RID: 14896 RVA: 0x001F3CA4 File Offset: 0x001F2CA4
		private amo(amo A_0)
		{
			this.a = A_0.a.f();
			this.b = A_0.b;
			this.c = A_0.c;
			this.d = A_0.d;
			this.e = A_0.e;
			this.f = A_0.f;
			this.g = A_0.g;
		}

		// Token: 0x06003A31 RID: 14897 RVA: 0x001F3D20 File Offset: 0x001F2D20
		internal amo(x5 A_0, x5 A_1, x5 A_2, bool A_3, short A_4, bool A_5, LayoutElementList A_6)
		{
			this.b = A_0;
			this.c = A_1;
			this.a = new aml(A_2);
			this.d = A_3;
			this.e = A_4;
			this.f = A_5;
			this.g = A_6;
		}

		// Token: 0x06003A32 RID: 14898 RVA: 0x001F3D7C File Offset: 0x001F2D7C
		internal aml a()
		{
			return this.a;
		}

		// Token: 0x06003A33 RID: 14899 RVA: 0x001F3D94 File Offset: 0x001F2D94
		public override void Draw(PageWriter writer)
		{
			this.a.nk(writer, this.b, this.c);
		}

		// Token: 0x06003A34 RID: 14900 RVA: 0x001F3DB0 File Offset: 0x001F2DB0
		internal override x5 b7()
		{
			return this.c;
		}

		// Token: 0x06003A35 RID: 14901 RVA: 0x001F3DC8 File Offset: 0x001F2DC8
		internal override x5 b8()
		{
			return x5.f(this.c, this.a.d());
		}

		// Token: 0x06003A36 RID: 14902 RVA: 0x001F3DF0 File Offset: 0x001F2DF0
		internal override bool fe()
		{
			return this.d;
		}

		// Token: 0x06003A37 RID: 14903 RVA: 0x001F3E08 File Offset: 0x001F2E08
		internal override short fd()
		{
			return this.e;
		}

		// Token: 0x06003A38 RID: 14904 RVA: 0x001F3E20 File Offset: 0x001F2E20
		internal void a(short A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06003A39 RID: 14905 RVA: 0x001F3E2C File Offset: 0x001F2E2C
		void ru.a(acm A_0)
		{
			x5 x = this.a.d();
			this.a.c();
			if (x5.g(x, this.a.d()))
			{
				A_0.a(this.c, x5.f(this.c, x), x5.e(this.a.d(), x));
			}
		}

		// Token: 0x06003A3A RID: 14906 RVA: 0x001F3E96 File Offset: 0x001F2E96
		internal override void b5(dv A_0)
		{
			this.c = x5.f(this.c, A_0.a(this.c));
		}

		// Token: 0x06003A3B RID: 14907 RVA: 0x001F3EB8 File Offset: 0x001F2EB8
		internal override x5 fa(x5 A_0)
		{
			x5 result;
			if (!this.d)
			{
				result = al1.d;
			}
			else
			{
				if (this.g.f())
				{
					this.a(A_0);
				}
				if (this.e == -32768)
				{
					result = al1.e;
				}
				else
				{
					alx alx = new alx();
					ArrayList a_ = new ArrayList();
					aml a_2 = new aml(x5.e(this.b8(), this.b7()));
					al0.a(alx, A_0, this.a);
					al0 al = new al0(A_0);
					al.a(alx, A_0, false, a_2, a_, this.f);
					if (alx.a == null)
					{
						result = al1.d;
					}
					else
					{
						result = al1.e;
					}
				}
			}
			return result;
		}

		// Token: 0x06003A3C RID: 14908 RVA: 0x001F3F90 File Offset: 0x001F2F90
		internal override PageElement fb(x5 A_0)
		{
			aml a_ = new aml(A_0);
			aml aml = new aml(x5.e(this.a.d(), A_0));
			al1 al = new al1(A_0, null, false);
			al.a(this.a, A_0, a_, aml, this.f);
			amo amo = new amo(this.b, x5.c(), aml.d(), true, this.e, this.f, this.g);
			amo.a = aml;
			this.a = a_;
			return (aml.h() == null) ? null : amo;
		}

		// Token: 0x06003A3D RID: 14909 RVA: 0x001F4028 File Offset: 0x001F3028
		private void a(x5 A_0)
		{
			am6 am = this.a.h();
			this.a.b();
			bool flag = false;
			while (am != null)
			{
				if (am.a().cb() == 239 && ((am1)am.a()).b(true))
				{
					flag = ((am1)am.a()).f(x5.e(A_0, am.a().b7()), A_0, true);
					this.a.a().a((am1)am.a());
				}
				am = am.b();
			}
			if (flag)
			{
				this.a.c();
			}
		}

		// Token: 0x06003A3E RID: 14910 RVA: 0x001F40EF File Offset: 0x001F30EF
		internal override void ca(x5 A_0)
		{
			this.c = x5.e(this.c, A_0);
		}

		// Token: 0x06003A3F RID: 14911 RVA: 0x001F4104 File Offset: 0x001F3104
		internal override PageElement fc()
		{
			return new amo(this);
		}

		// Token: 0x04001B91 RID: 7057
		private new aml a;

		// Token: 0x04001B92 RID: 7058
		private x5 b;

		// Token: 0x04001B93 RID: 7059
		private x5 c;

		// Token: 0x04001B94 RID: 7060
		private new bool d;

		// Token: 0x04001B95 RID: 7061
		private short e = short.MinValue;

		// Token: 0x04001B96 RID: 7062
		private bool f;

		// Token: 0x04001B97 RID: 7063
		private LayoutElementList g;
	}
}
