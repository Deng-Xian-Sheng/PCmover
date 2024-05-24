using System;

namespace zz93
{
	// Token: 0x0200015D RID: 349
	internal class it : fd
	{
		// Token: 0x06000CF0 RID: 3312 RVA: 0x00095D56 File Offset: 0x00094D56
		internal it()
		{
		}

		// Token: 0x06000CF1 RID: 3313 RVA: 0x00095D61 File Offset: 0x00094D61
		internal it(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000CF2 RID: 3314 RVA: 0x00095D74 File Offset: 0x00094D74
		internal override void cw(gi A_0)
		{
			int num = A_0.aj();
			int num2 = num;
			if (num2 <= 141185593)
			{
				if (num2 == 7021096)
				{
					this.a = new iu(gn.a);
					return;
				}
				if (num2 == 141185593)
				{
					this.a = new iu(gn.c);
					return;
				}
			}
			else
			{
				if (num2 == 258612623)
				{
					this.a = new iu(gn.d);
					return;
				}
				if (num2 == 448574430)
				{
					this.a = new iu(gn.b);
					return;
				}
				if (num2 == 505607249)
				{
					this.a = new iu(gn.a);
					this.a.d(true);
					return;
				}
			}
			this.a = new iu(gn.a);
		}

		// Token: 0x06000CF3 RID: 3315 RVA: 0x00095E20 File Offset: 0x00094E20
		internal iu a()
		{
			return this.a;
		}

		// Token: 0x06000CF4 RID: 3316 RVA: 0x00095E38 File Offset: 0x00094E38
		internal void a(iu A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06000CF5 RID: 3317 RVA: 0x00095E44 File Offset: 0x00094E44
		internal override int cv()
		{
			return 1982903832;
		}

		// Token: 0x06000CF6 RID: 3318 RVA: 0x00095E5C File Offset: 0x00094E5C
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x040006A6 RID: 1702
		private new iu a;
	}
}
