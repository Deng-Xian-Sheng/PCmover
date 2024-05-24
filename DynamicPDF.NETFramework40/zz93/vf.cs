using System;

namespace zz93
{
	// Token: 0x02000330 RID: 816
	internal class vf
	{
		// Token: 0x0600234B RID: 9035 RVA: 0x0014F9DE File Offset: 0x0014E9DE
		internal vf()
		{
		}

		// Token: 0x0600234C RID: 9036 RVA: 0x0014FA08 File Offset: 0x0014EA08
		internal void a()
		{
			if (this.d == null)
			{
				this.a = (this.c = (this.d = new ve()));
			}
			else
			{
				ve ve;
				this.d.a(ve = new ve());
				this.d = ve;
			}
		}

		// Token: 0x0600234D RID: 9037 RVA: 0x0014FA64 File Offset: 0x0014EA64
		internal void a(object A_0)
		{
			if (this.b == null)
			{
				this.b = this.a;
				this.b.a(A_0);
			}
			while (this.b != this.d)
			{
				this.b = this.b.b();
				this.b.a(A_0);
			}
		}

		// Token: 0x0600234E RID: 9038 RVA: 0x0014FAD4 File Offset: 0x0014EAD4
		internal void b(object A_0)
		{
			this.a.a(A_0);
		}

		// Token: 0x0600234F RID: 9039 RVA: 0x0014FAE4 File Offset: 0x0014EAE4
		internal object b()
		{
			object result;
			if (this.c == null)
			{
				result = this.a.a();
			}
			else
			{
				object obj = this.c.a();
				this.c = this.c.b();
				result = obj;
			}
			return result;
		}

		// Token: 0x06002350 RID: 9040 RVA: 0x0014FB34 File Offset: 0x0014EB34
		internal object c()
		{
			return this.a.a();
		}

		// Token: 0x04000F20 RID: 3872
		private ve a = null;

		// Token: 0x04000F21 RID: 3873
		private ve b = null;

		// Token: 0x04000F22 RID: 3874
		private ve c = null;

		// Token: 0x04000F23 RID: 3875
		private ve d = null;
	}
}
