using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace zz93
{
	// Token: 0x02000384 RID: 900
	internal class xm : Line
	{
		// Token: 0x06002650 RID: 9808 RVA: 0x00163962 File Offset: 0x00162962
		internal xm(float A_0, float A_1, float A_2, float A_3, float A_4, Color A_5, LineStyle A_6) : base(A_0, A_1, A_2, A_3, A_4, A_5, A_6)
		{
		}

		// Token: 0x06002651 RID: 9809 RVA: 0x00163983 File Offset: 0x00162983
		internal xm(Line A_0, x5 A_1, x5 A_2) : base(A_0, A_1, A_2)
		{
		}

		// Token: 0x06002652 RID: 9810 RVA: 0x0016399C File Offset: 0x0016299C
		internal xm(xm A_0) : base(A_0)
		{
			this.a = A_0.a;
		}

		// Token: 0x06002653 RID: 9811 RVA: 0x001639BF File Offset: 0x001629BF
		internal override void b5(dv A_0)
		{
			base.a(x5.f(base.a(), A_0.a(base.a())));
			base.b(x5.f(base.b(), A_0.a(base.b())));
		}

		// Token: 0x06002654 RID: 9812 RVA: 0x001639FE File Offset: 0x001629FE
		internal override void b6(acw A_0)
		{
		}

		// Token: 0x06002655 RID: 9813 RVA: 0x00163A04 File Offset: 0x00162A04
		internal override x5 fa(x5 A_0)
		{
			return w0.b;
		}

		// Token: 0x06002656 RID: 9814 RVA: 0x00163A1B File Offset: 0x00162A1B
		internal override void b9(x5 A_0)
		{
			base.a(x5.e(base.a(), A_0));
			base.b(x5.e(base.b(), A_0));
		}

		// Token: 0x06002657 RID: 9815 RVA: 0x00163A44 File Offset: 0x00162A44
		internal override void ca(x5 A_0)
		{
			if (x5.h(base.a(), x5.b()))
			{
				base.a(x5.c());
				base.b(x5.e(base.b(), A_0));
			}
			else if (x5.h(base.b(), x5.b()))
			{
				base.b(x5.c());
				base.a(x5.e(base.a(), A_0));
			}
			else
			{
				base.a(x5.e(base.a(), A_0));
				base.b(x5.e(base.b(), A_0));
			}
		}

		// Token: 0x06002658 RID: 9816 RVA: 0x00163AEC File Offset: 0x00162AEC
		internal override PageElement fb(x5 A_0)
		{
			A_0 = x5.f(A_0, this.b7());
			xm xm;
			if (x5.c(base.a(), A_0))
			{
				x5 a_ = base.a();
				base.a(A_0);
				xm = new xm(this, a_, A_0);
			}
			else
			{
				x5 a_2 = base.b();
				base.b(A_0);
				xm = new xm(this, A_0, a_2);
			}
			if (x5.c(xm.b7(), x5.c()))
			{
				if (x5.c(xm.b(), xm.a()))
				{
					xm.a(x5.b());
				}
				else if (x5.c(xm.a(), xm.b()))
				{
					xm.b(x5.b());
				}
				else
				{
					xm.a(x5.c());
					xm.b(x5.c());
				}
			}
			return xm;
		}

		// Token: 0x06002659 RID: 9817 RVA: 0x00163BE4 File Offset: 0x00162BE4
		internal override PageElement fc()
		{
			return new xm(this);
		}

		// Token: 0x0600265A RID: 9818 RVA: 0x00163C00 File Offset: 0x00162C00
		internal override short fd()
		{
			return this.a;
		}

		// Token: 0x0600265B RID: 9819 RVA: 0x00163C18 File Offset: 0x00162C18
		internal void a(short A_0)
		{
			this.a = A_0;
		}

		// Token: 0x040010B5 RID: 4277
		private new short a = short.MinValue;
	}
}
