using System;

namespace zz93
{
	// Token: 0x020000E8 RID: 232
	internal class fk : fd
	{
		// Token: 0x06000A4B RID: 2635 RVA: 0x000843D1 File Offset: 0x000833D1
		internal fk()
		{
		}

		// Token: 0x06000A4C RID: 2636 RVA: 0x000843DC File Offset: 0x000833DC
		internal fk(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000A4D RID: 2637 RVA: 0x000843F0 File Offset: 0x000833F0
		internal override void cw(gi A_0)
		{
			int num = A_0.aj();
			int num2 = num;
			if (num2 <= 7021096)
			{
				if (num2 == 136794)
				{
					this.a = new ip(io.a);
					return;
				}
				if (num2 == 7021096)
				{
					this.a = new ip(io.d);
					return;
				}
			}
			else
			{
				if (num2 == 426354259)
				{
					this.a = new ip(io.b);
					return;
				}
				if (num2 == 448574430)
				{
					this.a = new ip(io.c);
					return;
				}
				if (num2 == 505607249)
				{
					this.a = new ip(io.a);
					this.a.d(true);
					return;
				}
			}
			this.a = new ip(io.a);
		}

		// Token: 0x06000A4E RID: 2638 RVA: 0x0008449C File Offset: 0x0008349C
		internal ip a()
		{
			return this.a;
		}

		// Token: 0x06000A4F RID: 2639 RVA: 0x000844B4 File Offset: 0x000834B4
		internal override int cv()
		{
			return 275611842;
		}

		// Token: 0x06000A50 RID: 2640 RVA: 0x000844CC File Offset: 0x000834CC
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x04000514 RID: 1300
		private new ip a;
	}
}
