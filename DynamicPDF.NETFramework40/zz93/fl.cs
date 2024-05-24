using System;

namespace zz93
{
	// Token: 0x020000E9 RID: 233
	internal class fl : fd
	{
		// Token: 0x06000A51 RID: 2641 RVA: 0x000844E4 File Offset: 0x000834E4
		internal fl(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000A52 RID: 2642 RVA: 0x000844F8 File Offset: 0x000834F8
		internal override void cw(gi A_0)
		{
			int num = A_0.aj();
			int num2 = num;
			if (num2 <= 7021096)
			{
				if (num2 == 2250341)
				{
					this.a = new fy(g0.d);
					return;
				}
				if (num2 == 7021096)
				{
					this.a = new fy(g0.a);
					return;
				}
			}
			else
			{
				if (num2 == 12428921)
				{
					this.a = new fy(g0.c);
					return;
				}
				if (num2 == 448574430)
				{
					this.a = new fy(g0.b);
					return;
				}
				if (num2 == 505607249)
				{
					this.a = new fy(g0.d);
					this.a.d(true);
					return;
				}
			}
			this.a = new fy(g0.d);
		}

		// Token: 0x06000A53 RID: 2643 RVA: 0x000845A4 File Offset: 0x000835A4
		internal fy a()
		{
			return this.a;
		}

		// Token: 0x06000A54 RID: 2644 RVA: 0x000845BC File Offset: 0x000835BC
		internal override int cv()
		{
			return 503613957;
		}

		// Token: 0x06000A55 RID: 2645 RVA: 0x000845D4 File Offset: 0x000835D4
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x04000515 RID: 1301
		private new fy a;
	}
}
