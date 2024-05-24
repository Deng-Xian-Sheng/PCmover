using System;

namespace zz93
{
	// Token: 0x02000163 RID: 355
	internal class iz : fd
	{
		// Token: 0x06000D11 RID: 3345 RVA: 0x00096474 File Offset: 0x00095474
		internal iz(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000D12 RID: 3346 RVA: 0x00096488 File Offset: 0x00095488
		internal override void cw(gi A_0)
		{
			int num = A_0.aj();
			int num2 = num;
			if (num2 <= 180347975)
			{
				if (num2 == 2250341)
				{
					this.a = new gr(i1.a);
					return;
				}
				if (num2 == 180347975)
				{
					this.a = new gr(i1.b);
					return;
				}
			}
			else
			{
				if (num2 == 505607249)
				{
					this.a = new gr(i1.a);
					this.a.d(true);
					return;
				}
				if (num2 == 510007529)
				{
					this.a = new gr(i1.c);
					return;
				}
				if (num2 == 510027490)
				{
					this.a = new gr(i1.d);
					return;
				}
			}
			this.a = new gr(i1.a);
		}

		// Token: 0x06000D13 RID: 3347 RVA: 0x00096534 File Offset: 0x00095534
		internal gr a()
		{
			return this.a;
		}

		// Token: 0x06000D14 RID: 3348 RVA: 0x0009654C File Offset: 0x0009554C
		internal override int cv()
		{
			return 2098498396;
		}

		// Token: 0x06000D15 RID: 3349 RVA: 0x00096564 File Offset: 0x00095564
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x040006AD RID: 1709
		private new gr a;
	}
}
