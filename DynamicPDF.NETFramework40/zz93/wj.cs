using System;

namespace zz93
{
	// Token: 0x0200035A RID: 858
	internal class wj
	{
		// Token: 0x060024EB RID: 9451 RVA: 0x0015B99C File Offset: 0x0015A99C
		internal wj()
		{
		}

		// Token: 0x060024EC RID: 9452 RVA: 0x0015B9BC File Offset: 0x0015A9BC
		internal void a(vr A_0)
		{
			if (this.a == null)
			{
				this.b = A_0;
				this.a = A_0;
			}
			else
			{
				this.b.a(A_0);
				this.b = A_0;
			}
			this.c++;
		}

		// Token: 0x060024ED RID: 9453 RVA: 0x0015BA14 File Offset: 0x0015AA14
		internal int a()
		{
			return this.c;
		}

		// Token: 0x060024EE RID: 9454 RVA: 0x0015BA2C File Offset: 0x0015AA2C
		internal vr b()
		{
			return this.a;
		}

		// Token: 0x04001014 RID: 4116
		private vr a = null;

		// Token: 0x04001015 RID: 4117
		private vr b = null;

		// Token: 0x04001016 RID: 4118
		private int c = 0;
	}
}
