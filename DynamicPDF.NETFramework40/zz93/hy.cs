using System;

namespace zz93
{
	// Token: 0x0200013E RID: 318
	internal class hy : fd
	{
		// Token: 0x06000C14 RID: 3092 RVA: 0x00090740 File Offset: 0x0008F740
		internal hy(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000C15 RID: 3093 RVA: 0x00090754 File Offset: 0x0008F754
		internal override void cw(gi A_0)
		{
			int num = A_0.aj();
			if (num <= 448574430)
			{
				if (num == 6662337)
				{
					this.a = new gh(gf.e);
					this.a.a(true);
					return;
				}
				if (num == 7021096)
				{
					this.a = new gh(gf.c);
					return;
				}
				if (num == 448574430)
				{
					this.a = new gh(gf.d);
					return;
				}
			}
			else
			{
				if (num == 505607249)
				{
					this.a = new gh(gf.e);
					this.a.d(true);
					return;
				}
				if (num == 705063489)
				{
					this.a = new gh(gf.a);
					return;
				}
				if (num == 893228481)
				{
					this.a = new gh(gf.b);
					return;
				}
			}
			this.a = new gh(gf.e);
			this.a.a(true);
		}

		// Token: 0x06000C16 RID: 3094 RVA: 0x00090834 File Offset: 0x0008F834
		internal override int cv()
		{
			return 272801619;
		}

		// Token: 0x06000C17 RID: 3095 RVA: 0x0009084C File Offset: 0x0008F84C
		internal gh a()
		{
			return this.a;
		}

		// Token: 0x06000C18 RID: 3096 RVA: 0x00090864 File Offset: 0x0008F864
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x04000644 RID: 1604
		private new gh a;
	}
}
