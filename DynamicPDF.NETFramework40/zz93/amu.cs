using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace zz93
{
	// Token: 0x020005C3 RID: 1475
	internal class amu : Line
	{
		// Token: 0x06003A65 RID: 14949 RVA: 0x001F5386 File Offset: 0x001F4386
		internal amu(float A_0, float A_1, float A_2, float A_3, float A_4, Color A_5, LineStyle A_6) : base(A_0, A_1, A_2, A_3, A_4, A_5, A_6)
		{
		}

		// Token: 0x06003A66 RID: 14950 RVA: 0x001F53A7 File Offset: 0x001F43A7
		internal amu(Line A_0, x5 A_1, x5 A_2) : base(A_0, A_1, A_2)
		{
		}

		// Token: 0x06003A67 RID: 14951 RVA: 0x001F53C0 File Offset: 0x001F43C0
		internal amu(amu A_0) : base(A_0)
		{
			this.a = A_0.a;
		}

		// Token: 0x06003A68 RID: 14952 RVA: 0x001F53E3 File Offset: 0x001F43E3
		internal override void b5(dv A_0)
		{
			base.a(x5.f(base.a(), A_0.a(base.a())));
			base.b(x5.f(base.b(), A_0.a(base.b())));
		}

		// Token: 0x06003A69 RID: 14953 RVA: 0x001F5422 File Offset: 0x001F4422
		internal override void b6(acw A_0)
		{
		}

		// Token: 0x06003A6A RID: 14954 RVA: 0x001F5428 File Offset: 0x001F4428
		internal override x5 fa(x5 A_0)
		{
			return al1.b;
		}

		// Token: 0x06003A6B RID: 14955 RVA: 0x001F543F File Offset: 0x001F443F
		internal override void b9(x5 A_0)
		{
			base.a(x5.e(base.a(), A_0));
			base.b(x5.e(base.b(), A_0));
		}

		// Token: 0x06003A6C RID: 14956 RVA: 0x001F5468 File Offset: 0x001F4468
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

		// Token: 0x06003A6D RID: 14957 RVA: 0x001F5510 File Offset: 0x001F4510
		internal override PageElement fb(x5 A_0)
		{
			A_0 = x5.f(A_0, this.b7());
			amu amu;
			if (x5.c(base.a(), A_0))
			{
				x5 a_ = base.a();
				base.a(A_0);
				amu = new amu(this, a_, A_0);
			}
			else
			{
				x5 a_2 = base.b();
				base.b(A_0);
				amu = new amu(this, A_0, a_2);
			}
			if (x5.c(amu.b7(), x5.c()))
			{
				if (x5.c(amu.b(), amu.a()))
				{
					amu.a(x5.b());
				}
				else if (x5.c(amu.a(), amu.b()))
				{
					amu.b(x5.b());
				}
				else
				{
					amu.a(x5.c());
					amu.b(x5.c());
				}
			}
			return amu;
		}

		// Token: 0x06003A6E RID: 14958 RVA: 0x001F5608 File Offset: 0x001F4608
		internal override PageElement fc()
		{
			return new amu(this);
		}

		// Token: 0x06003A6F RID: 14959 RVA: 0x001F5624 File Offset: 0x001F4624
		internal override short fd()
		{
			return this.a;
		}

		// Token: 0x06003A70 RID: 14960 RVA: 0x001F563C File Offset: 0x001F463C
		internal void a(short A_0)
		{
			this.a = A_0;
		}

		// Token: 0x04001BA2 RID: 7074
		private new short a = short.MinValue;
	}
}
