using System;

namespace zz93
{
	// Token: 0x0200059E RID: 1438
	internal class alt
	{
		// Token: 0x0600393C RID: 14652 RVA: 0x001EA93C File Offset: 0x001E993C
		internal void a(short A_0)
		{
			if (this.a == null)
			{
				this.a = (this.b = new alw(A_0));
			}
			else
			{
				alw e = new alw(A_0);
				this.b.e = e;
				this.b = e;
			}
		}

		// Token: 0x0600393D RID: 14653 RVA: 0x001EA990 File Offset: 0x001E9990
		internal void a(short A_0, alv A_1)
		{
			if (this.a == null)
			{
				this.a = (this.b = new alw(A_0, A_1));
			}
			else
			{
				alw e = new alw(A_0, A_1);
				this.b.e = e;
				this.b = e;
			}
		}

		// Token: 0x04001B3A RID: 6970
		internal alw a;

		// Token: 0x04001B3B RID: 6971
		internal alw b;
	}
}
