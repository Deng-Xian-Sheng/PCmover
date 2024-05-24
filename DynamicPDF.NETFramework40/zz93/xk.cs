using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x02000381 RID: 897
	internal class xk : PageElement, ru
	{
		// Token: 0x0600261D RID: 9757 RVA: 0x00163220 File Offset: 0x00162220
		private xk(xk A_0)
		{
			this.a = A_0.a.f();
			this.b = A_0.b;
			this.c = A_0.c;
			this.d = A_0.d;
			this.e = A_0.e;
			this.f = A_0.f;
			this.g = A_0.g;
		}

		// Token: 0x0600261E RID: 9758 RVA: 0x0016329C File Offset: 0x0016229C
		internal xk(x5 A_0, x5 A_1, x5 A_2, bool A_3, short A_4, bool A_5, ReportElementList A_6)
		{
			this.b = A_0;
			this.c = A_1;
			this.a = new xh(A_2);
			this.d = A_3;
			this.e = A_4;
			this.f = A_5;
			this.g = A_6;
		}

		// Token: 0x0600261F RID: 9759 RVA: 0x001632F8 File Offset: 0x001622F8
		internal xh a()
		{
			return this.a;
		}

		// Token: 0x06002620 RID: 9760 RVA: 0x00163310 File Offset: 0x00162310
		public override void Draw(PageWriter writer)
		{
			this.a.f9(writer, this.b, this.c);
		}

		// Token: 0x06002621 RID: 9761 RVA: 0x0016332C File Offset: 0x0016232C
		internal override x5 b7()
		{
			return this.c;
		}

		// Token: 0x06002622 RID: 9762 RVA: 0x00163344 File Offset: 0x00162344
		internal override x5 b8()
		{
			return x5.f(this.c, this.a.d());
		}

		// Token: 0x06002623 RID: 9763 RVA: 0x0016336C File Offset: 0x0016236C
		internal override bool fe()
		{
			return this.d;
		}

		// Token: 0x06002624 RID: 9764 RVA: 0x00163384 File Offset: 0x00162384
		internal override short fd()
		{
			return this.e;
		}

		// Token: 0x06002625 RID: 9765 RVA: 0x0016339C File Offset: 0x0016239C
		internal void a(short A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06002626 RID: 9766 RVA: 0x001633A8 File Offset: 0x001623A8
		void ru.a(acm A_0)
		{
			x5 x = this.a.d();
			this.a.c();
			if (x5.g(x, this.a.d()))
			{
				A_0.a(this.c, x5.f(this.c, x), x5.e(this.a.d(), x));
			}
		}

		// Token: 0x06002627 RID: 9767 RVA: 0x00163412 File Offset: 0x00162412
		internal override void b5(dv A_0)
		{
			this.c = x5.f(this.c, A_0.a(this.c));
		}

		// Token: 0x06002628 RID: 9768 RVA: 0x00163434 File Offset: 0x00162434
		internal override x5 fa(x5 A_0)
		{
			x5 result;
			if (!this.d)
			{
				result = w0.d;
			}
			else
			{
				if (this.g.f())
				{
					this.a(A_0);
				}
				if (this.e == -32768)
				{
					result = w0.e;
				}
				else
				{
					w3 w = new w3();
					ArrayList a_ = new ArrayList();
					xh a_2 = new xh(x5.e(this.b8(), this.b7()));
					rp.a(w, A_0, this.a);
					rp rp = new rp(A_0);
					rp.a(w, A_0, false, a_2, a_, this.f);
					if (w.a == null)
					{
						result = w0.d;
					}
					else
					{
						result = w0.e;
					}
				}
			}
			return result;
		}

		// Token: 0x06002629 RID: 9769 RVA: 0x0016350C File Offset: 0x0016250C
		internal override PageElement fb(x5 A_0)
		{
			xh a_ = new xh(A_0);
			xh xh = new xh(x5.e(this.a.d(), A_0));
			w0 w = new w0(A_0, null, false);
			w.a(this.a, A_0, a_, xh, this.f);
			xk xk = new xk(this.b, x5.c(), xh.d(), true, this.e, this.f, this.g);
			xk.a = xh;
			this.a = a_;
			return (xh.h() == null) ? null : xk;
		}

		// Token: 0x0600262A RID: 9770 RVA: 0x001635A4 File Offset: 0x001625A4
		private void a(x5 A_0)
		{
			xx xx = this.a.h();
			this.a.b();
			bool flag = false;
			while (xx != null)
			{
				if (xx.a().cb() == 239 && ((xs)xx.a()).b(true))
				{
					flag = ((xs)xx.a()).f(x5.e(A_0, xx.a().b7()), A_0, true);
					this.a.a().a((xs)xx.a());
				}
				xx = xx.b();
			}
			if (flag)
			{
				this.a.c();
			}
		}

		// Token: 0x0600262B RID: 9771 RVA: 0x0016366B File Offset: 0x0016266B
		internal override void ca(x5 A_0)
		{
			this.c = x5.e(this.c, A_0);
		}

		// Token: 0x0600262C RID: 9772 RVA: 0x00163680 File Offset: 0x00162680
		internal override PageElement fc()
		{
			return new xk(this);
		}

		// Token: 0x040010AA RID: 4266
		private new xh a;

		// Token: 0x040010AB RID: 4267
		private x5 b;

		// Token: 0x040010AC RID: 4268
		private x5 c;

		// Token: 0x040010AD RID: 4269
		private new bool d;

		// Token: 0x040010AE RID: 4270
		private short e = short.MinValue;

		// Token: 0x040010AF RID: 4271
		private bool f;

		// Token: 0x040010B0 RID: 4272
		private ReportElementList g;
	}
}
