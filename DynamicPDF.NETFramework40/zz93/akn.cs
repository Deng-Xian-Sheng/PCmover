using System;

namespace zz93
{
	// Token: 0x02000571 RID: 1393
	internal class akn
	{
		// Token: 0x0600375F RID: 14175 RVA: 0x001DF228 File Offset: 0x001DE228
		internal akn(string A_0)
		{
			this.c = 0;
			this.b = new al5(A_0.ToCharArray(), 0, A_0.Length);
			if (this.b.b(false))
			{
				this.a = this.b.c(false);
			}
			else if (this.b.o())
			{
				this.a = this.b.h();
			}
			else
			{
				this.a = this.b.f();
			}
			this.d = this.b.e();
		}

		// Token: 0x06003760 RID: 14176 RVA: 0x001DF2DC File Offset: 0x001DE2DC
		internal akn(ald A_0, char[] A_1, int A_2, int A_3)
		{
			this.c = A_2;
			this.b = new al5(A_0, A_1, A_2, A_3);
			if (this.b.b(false))
			{
				this.a = this.b.c(false);
			}
			else if (this.b.o())
			{
				this.a = this.b.h();
			}
			else
			{
				this.a = this.b.f();
			}
			this.d = this.b.e();
		}

		// Token: 0x06003761 RID: 14177 RVA: 0x001DF388 File Offset: 0x001DE388
		internal ahq a()
		{
			return this.a;
		}

		// Token: 0x06003762 RID: 14178 RVA: 0x001DF3A0 File Offset: 0x001DE3A0
		internal string b()
		{
			return this.b.b(this.c);
		}

		// Token: 0x06003763 RID: 14179 RVA: 0x001DF3C4 File Offset: 0x001DE3C4
		internal bool c()
		{
			return this.d != null && this.d.b() != 0;
		}

		// Token: 0x06003764 RID: 14180 RVA: 0x001DF3F4 File Offset: 0x001DE3F4
		internal ahs d()
		{
			return this.d;
		}

		// Token: 0x04001A33 RID: 6707
		private ahq a;

		// Token: 0x04001A34 RID: 6708
		private al5 b;

		// Token: 0x04001A35 RID: 6709
		private int c;

		// Token: 0x04001A36 RID: 6710
		private ahs d = null;
	}
}
