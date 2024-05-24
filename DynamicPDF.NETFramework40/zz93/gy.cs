using System;

namespace zz93
{
	// Token: 0x0200011A RID: 282
	internal class gy : fd
	{
		// Token: 0x06000B36 RID: 2870 RVA: 0x0008A1C4 File Offset: 0x000891C4
		internal gy(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000B37 RID: 2871 RVA: 0x0008A1D8 File Offset: 0x000891D8
		internal override void cw(gi A_0)
		{
			int num = A_0.aj();
			if (num != 124584)
			{
				if (num != 165534)
				{
					if (num != 505607249)
					{
						this.a = new gq(gp.b);
					}
					else
					{
						this.a = new gq(gp.b);
						this.a.d(true);
					}
				}
				else
				{
					this.a = new gq(gp.a);
				}
			}
			else
			{
				this.a = new gq(gp.b);
			}
		}

		// Token: 0x06000B38 RID: 2872 RVA: 0x0008A24C File Offset: 0x0008924C
		internal gq a()
		{
			return this.a;
		}

		// Token: 0x06000B39 RID: 2873 RVA: 0x0008A264 File Offset: 0x00089264
		internal override int cv()
		{
			return 67814465;
		}

		// Token: 0x06000B3A RID: 2874 RVA: 0x0008A27C File Offset: 0x0008927C
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x040005BF RID: 1471
		private new gq a;
	}
}
