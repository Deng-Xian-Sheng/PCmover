using System;

namespace zz93
{
	// Token: 0x020005D5 RID: 1493
	internal class anb
	{
		// Token: 0x06003B27 RID: 15143 RVA: 0x001FAFD7 File Offset: 0x001F9FD7
		internal anb(x5 A_0, x5 A_1, alt A_2)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
		}

		// Token: 0x06003B28 RID: 15144 RVA: 0x001FAFF8 File Offset: 0x001F9FF8
		internal x5 a()
		{
			x5 x = x5.b();
			for (alw e = this.c.a; e != null; e = e.e)
			{
				if (e.b != null && x5.c(x, e.b.a().b7()))
				{
					x = e.b.a().b7();
				}
			}
			return x;
		}

		// Token: 0x06003B29 RID: 15145 RVA: 0x001FB070 File Offset: 0x001FA070
		internal x5 b()
		{
			return this.a;
		}

		// Token: 0x06003B2A RID: 15146 RVA: 0x001FB088 File Offset: 0x001FA088
		internal void a(x5 A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06003B2B RID: 15147 RVA: 0x001FB094 File Offset: 0x001FA094
		internal x5 c()
		{
			return this.b;
		}

		// Token: 0x06003B2C RID: 15148 RVA: 0x001FB0AC File Offset: 0x001FA0AC
		internal void b(x5 A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06003B2D RID: 15149 RVA: 0x001FB0B8 File Offset: 0x001FA0B8
		internal alt d()
		{
			return this.c;
		}

		// Token: 0x06003B2E RID: 15150 RVA: 0x001FB0D0 File Offset: 0x001FA0D0
		internal void a(amk A_0)
		{
			am6 am = A_0.h();
			alw e = this.c.a;
			while (am != null || e != null)
			{
				if (am == null && e != null)
				{
					e.b = null;
					e = e.e;
					am = A_0.h();
				}
				if (e == null)
				{
					break;
				}
				if (am.a().fd() == e.a)
				{
					e.b = am;
					e = e.e;
				}
				am = am.b();
			}
		}

		// Token: 0x06003B2F RID: 15151 RVA: 0x001FB16C File Offset: 0x001FA16C
		internal void c(x5 A_0)
		{
			this.a = x5.f(this.a, A_0);
			this.b = x5.f(this.b, A_0);
		}

		// Token: 0x06003B30 RID: 15152 RVA: 0x001FB194 File Offset: 0x001FA194
		internal void d(x5 A_0)
		{
			if (x5.d(this.a, A_0))
			{
				A_0 = x5.e(A_0, this.a);
			}
			this.a = x5.e(this.a, A_0);
			this.b = x5.e(this.b, A_0);
		}

		// Token: 0x04001BE0 RID: 7136
		private x5 a;

		// Token: 0x04001BE1 RID: 7137
		private x5 b;

		// Token: 0x04001BE2 RID: 7138
		private alt c;
	}
}
