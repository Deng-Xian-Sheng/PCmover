using System;

namespace zz93
{
	// Token: 0x020004E9 RID: 1257
	internal class agy
	{
		// Token: 0x06003380 RID: 13184 RVA: 0x001CA02D File Offset: 0x001C902D
		internal agy(agp A_0, int A_1, byte[] A_2, int A_3)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
			this.d = (long)A_3;
			this.e = (long)(A_3 + A_2.Length);
		}

		// Token: 0x06003381 RID: 13185 RVA: 0x001CA064 File Offset: 0x001C9064
		internal byte[] a()
		{
			return this.c;
		}

		// Token: 0x06003382 RID: 13186 RVA: 0x001CA07C File Offset: 0x001C907C
		internal long b()
		{
			return this.d;
		}

		// Token: 0x06003383 RID: 13187 RVA: 0x001CA094 File Offset: 0x001C9094
		internal long c()
		{
			return this.e;
		}

		// Token: 0x06003384 RID: 13188 RVA: 0x001CA0AC File Offset: 0x001C90AC
		internal int d()
		{
			return this.b;
		}

		// Token: 0x06003385 RID: 13189 RVA: 0x001CA0C4 File Offset: 0x001C90C4
		internal agy e()
		{
			return this.a.a(this.b + 1);
		}

		// Token: 0x06003386 RID: 13190 RVA: 0x001CA0EC File Offset: 0x001C90EC
		internal agy f()
		{
			return this.a.a(this.b - 1);
		}

		// Token: 0x0400187C RID: 6268
		private agp a;

		// Token: 0x0400187D RID: 6269
		private int b;

		// Token: 0x0400187E RID: 6270
		private byte[] c;

		// Token: 0x0400187F RID: 6271
		private long d;

		// Token: 0x04001880 RID: 6272
		private long e;
	}
}
