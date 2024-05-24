using System;
using System.Reflection;

namespace zz93
{
	// Token: 0x02000146 RID: 326
	[DefaultMember("Item")]
	internal class h6
	{
		// Token: 0x06000C37 RID: 3127 RVA: 0x00090D32 File Offset: 0x0008FD32
		internal h6(int A_0, object A_1)
		{
			this.a = A_0;
		}

		// Token: 0x06000C38 RID: 3128 RVA: 0x00090D44 File Offset: 0x0008FD44
		internal bool a(int A_0)
		{
			return A_0 == this.a || (this.b != null && this.b.a(A_0));
		}

		// Token: 0x06000C39 RID: 3129 RVA: 0x00090D8C File Offset: 0x0008FD8C
		internal h6 b(int A_0)
		{
			h6 result;
			if (A_0 == this.a)
			{
				result = this.b;
			}
			else if (this.b == null)
			{
				result = null;
			}
			else
			{
				result = this.b.b(A_0);
			}
			return result;
		}

		// Token: 0x06000C3A RID: 3130 RVA: 0x00090DD8 File Offset: 0x0008FDD8
		internal void a(int A_0, h6 A_1)
		{
			this.b.a(A_0, A_1);
		}

		// Token: 0x06000C3B RID: 3131 RVA: 0x00090DEC File Offset: 0x0008FDEC
		internal void a(int A_0, object A_1)
		{
			if (this.b == null)
			{
				this.b = new h6(A_0, A_1);
			}
			else if (!this.a(A_0))
			{
				this.b.a(A_0, A_1);
			}
		}

		// Token: 0x0400064D RID: 1613
		private int a;

		// Token: 0x0400064E RID: 1614
		private h6 b;
	}
}
