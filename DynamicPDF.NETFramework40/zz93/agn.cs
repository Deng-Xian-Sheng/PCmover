using System;

namespace zz93
{
	// Token: 0x020004DE RID: 1246
	internal class agn
	{
		// Token: 0x060032CB RID: 13003 RVA: 0x001C4E10 File Offset: 0x001C3E10
		internal agn(int A_0)
		{
			this.b = new byte[A_0];
		}

		// Token: 0x060032CC RID: 13004 RVA: 0x001C4E38 File Offset: 0x001C3E38
		internal byte[] a()
		{
			return this.b;
		}

		// Token: 0x060032CD RID: 13005 RVA: 0x001C4E50 File Offset: 0x001C3E50
		internal int b()
		{
			return this.c;
		}

		// Token: 0x060032CE RID: 13006 RVA: 0x001C4E68 File Offset: 0x001C3E68
		internal void a(int A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060032CF RID: 13007 RVA: 0x001C4E74 File Offset: 0x001C3E74
		internal agn c()
		{
			return this.a;
		}

		// Token: 0x060032D0 RID: 13008 RVA: 0x001C4E8C File Offset: 0x001C3E8C
		internal void a(agn A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060032D1 RID: 13009 RVA: 0x001C4E98 File Offset: 0x001C3E98
		internal int a(y0 A_0)
		{
			int num = A_0.c(this.b, this.c, this.b.Length - this.c);
			this.c += num;
			return num;
		}

		// Token: 0x04001858 RID: 6232
		private agn a = null;

		// Token: 0x04001859 RID: 6233
		private byte[] b;

		// Token: 0x0400185A RID: 6234
		private int c = 0;
	}
}
