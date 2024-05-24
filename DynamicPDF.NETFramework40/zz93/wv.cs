using System;

namespace zz93
{
	// Token: 0x02000368 RID: 872
	internal class wv
	{
		// Token: 0x0600254C RID: 9548 RVA: 0x0015D178 File Offset: 0x0015C178
		internal void a(short A_0)
		{
			if (this.a == null)
			{
				this.a = (this.b = new wy(A_0));
			}
			else
			{
				wy e = new wy(A_0);
				this.b.e = e;
				this.b = e;
			}
		}

		// Token: 0x0600254D RID: 9549 RVA: 0x0015D1CC File Offset: 0x0015C1CC
		internal void a(short A_0, wx A_1)
		{
			if (this.a == null)
			{
				this.a = (this.b = new wy(A_0, A_1));
			}
			else
			{
				wy e = new wy(A_0, A_1);
				this.b.e = e;
				this.b = e;
			}
		}

		// Token: 0x0400105A RID: 4186
		internal wy a;

		// Token: 0x0400105B RID: 4187
		internal wy b;
	}
}
