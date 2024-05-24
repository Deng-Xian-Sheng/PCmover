using System;

namespace zz93
{
	// Token: 0x02000140 RID: 320
	internal class h0 : fd
	{
		// Token: 0x06000C1E RID: 3102 RVA: 0x0009099C File Offset: 0x0008F99C
		internal h0(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000C1F RID: 3103 RVA: 0x000909B0 File Offset: 0x0008F9B0
		internal override void cw(gi A_0)
		{
			int num = A_0.aj();
			if (num != 6662337)
			{
				if (num != 505607249)
				{
					if (num != 893228481)
					{
						this.a = new gg(null);
						this.a.a(true);
					}
					else
					{
						this.a = new gg("avoid");
					}
				}
				else
				{
					this.a = new gg(null);
					this.a.d(true);
				}
			}
			else
			{
				this.a = new gg(null);
				this.a.a(true);
			}
		}

		// Token: 0x06000C20 RID: 3104 RVA: 0x00090A44 File Offset: 0x0008FA44
		internal override int cv()
		{
			return 397142149;
		}

		// Token: 0x06000C21 RID: 3105 RVA: 0x00090A5C File Offset: 0x0008FA5C
		internal gg a()
		{
			return this.a;
		}

		// Token: 0x06000C22 RID: 3106 RVA: 0x00090A74 File Offset: 0x0008FA74
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x04000646 RID: 1606
		private new gg a;
	}
}
