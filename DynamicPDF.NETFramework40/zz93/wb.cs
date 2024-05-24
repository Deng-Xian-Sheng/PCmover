using System;

namespace zz93
{
	// Token: 0x02000352 RID: 850
	internal class wb
	{
		// Token: 0x06002439 RID: 9273 RVA: 0x001554C4 File Offset: 0x001544C4
		internal wb()
		{
		}

		// Token: 0x0600243A RID: 9274 RVA: 0x001554E4 File Offset: 0x001544E4
		internal void a(wa A_0)
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

		// Token: 0x0600243B RID: 9275 RVA: 0x0015553C File Offset: 0x0015453C
		internal int a()
		{
			return this.c;
		}

		// Token: 0x0600243C RID: 9276 RVA: 0x00155554 File Offset: 0x00154554
		internal wa b()
		{
			return this.a;
		}

		// Token: 0x04000FBE RID: 4030
		private wa a = null;

		// Token: 0x04000FBF RID: 4031
		private wa b = null;

		// Token: 0x04000FC0 RID: 4032
		private int c = 0;
	}
}
