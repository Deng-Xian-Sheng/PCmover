using System;

namespace zz93
{
	// Token: 0x02000141 RID: 321
	internal class h1 : fd
	{
		// Token: 0x06000C23 RID: 3107 RVA: 0x00090A8C File Offset: 0x0008FA8C
		internal h1(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000C24 RID: 3108 RVA: 0x00090AA0 File Offset: 0x0008FAA0
		internal override void cw(gi A_0)
		{
			int num = A_0.aj();
			int num2 = num;
			if (num2 <= 436701568)
			{
				if (num2 == 258479786)
				{
					this.a = new gj(g6.a);
					return;
				}
				if (num2 == 436701568)
				{
					this.a = new gj(g6.b);
					return;
				}
			}
			else
			{
				if (num2 == 505607249)
				{
					this.a = new gj(g6.a);
					this.a.d(true);
					return;
				}
				if (num2 == 677839623)
				{
					this.a = new gj(g6.c);
					return;
				}
				if (num2 == 891372530)
				{
					this.a = new gj(g6.d);
					return;
				}
			}
			this.a = new gj(g6.a);
		}

		// Token: 0x06000C25 RID: 3109 RVA: 0x00090B4C File Offset: 0x0008FB4C
		internal gj a()
		{
			return this.a;
		}

		// Token: 0x06000C26 RID: 3110 RVA: 0x00090B64 File Offset: 0x0008FB64
		internal override int cv()
		{
			return 440052479;
		}

		// Token: 0x06000C27 RID: 3111 RVA: 0x00090B7C File Offset: 0x0008FB7C
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x04000647 RID: 1607
		private new gj a;
	}
}
