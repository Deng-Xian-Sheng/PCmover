using System;

namespace zz93
{
	// Token: 0x02000591 RID: 1425
	internal class ali
	{
		// Token: 0x060038C8 RID: 14536 RVA: 0x001E959C File Offset: 0x001E859C
		internal ali()
		{
		}

		// Token: 0x060038C9 RID: 14537 RVA: 0x001E95BC File Offset: 0x001E85BC
		internal void a(akt A_0)
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

		// Token: 0x060038CA RID: 14538 RVA: 0x001E9614 File Offset: 0x001E8614
		internal int a()
		{
			return this.c;
		}

		// Token: 0x060038CB RID: 14539 RVA: 0x001E962C File Offset: 0x001E862C
		internal akt b()
		{
			return this.a;
		}

		// Token: 0x04001B05 RID: 6917
		private akt a = null;

		// Token: 0x04001B06 RID: 6918
		private akt b = null;

		// Token: 0x04001B07 RID: 6919
		private int c = 0;
	}
}
