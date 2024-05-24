using System;

namespace zz93
{
	// Token: 0x020004DC RID: 1244
	internal class agl : yx
	{
		// Token: 0x060032BE RID: 12990 RVA: 0x001C48B4 File Offset: 0x001C38B4
		internal agl()
		{
			this.c = (this.d = new agn(512));
		}

		// Token: 0x060032BF RID: 12991 RVA: 0x001C48F4 File Offset: 0x001C38F4
		internal override void k4(y0 A_0)
		{
			do
			{
				this.a();
				this.e += this.c.a(A_0);
			}
			while (!A_0.d());
		}

		// Token: 0x060032C0 RID: 12992 RVA: 0x001C4934 File Offset: 0x001C3934
		internal override void k5(y0 A_0)
		{
			do
			{
				this.a();
				this.e += this.c.a(A_0);
			}
			while (!A_0.c());
		}

		// Token: 0x060032C1 RID: 12993 RVA: 0x001C4974 File Offset: 0x001C3974
		internal void a()
		{
			if (this.c.b() >= this.c.a().Length)
			{
				if (this.c.c() == null)
				{
					this.c.a(new agn(this.c.a().Length + 512));
				}
				else
				{
					this.c.c().a(0);
				}
				this.c = this.c.c();
			}
		}

		// Token: 0x060032C2 RID: 12994 RVA: 0x001C4A08 File Offset: 0x001C3A08
		internal override bp k6()
		{
			agm result = new agm(this.d, this.f, this.e);
			this.d = this.c;
			this.f = this.c.b();
			this.e = 0;
			return result;
		}

		// Token: 0x0400184F RID: 6223
		private const int a = 512;

		// Token: 0x04001850 RID: 6224
		private const int b = 512;

		// Token: 0x04001851 RID: 6225
		private agn c;

		// Token: 0x04001852 RID: 6226
		private agn d;

		// Token: 0x04001853 RID: 6227
		private int e = 0;

		// Token: 0x04001854 RID: 6228
		private int f = 0;
	}
}
