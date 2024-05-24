using System;

namespace zz93
{
	// Token: 0x02000337 RID: 823
	internal class vk
	{
		// Token: 0x0600236A RID: 9066 RVA: 0x00150984 File Offset: 0x0014F984
		internal vk(string A_0)
		{
			this.c = 0;
			this.b = new w5(A_0.ToCharArray(), 0, A_0.Length);
			if (this.b.b(false))
			{
				this.a = this.b.c(false);
			}
			else if (this.b.p())
			{
				this.a = this.b.i();
			}
			else
			{
				this.a = this.b.g();
			}
			this.d = this.b.f();
		}

		// Token: 0x0600236B RID: 9067 RVA: 0x00150A38 File Offset: 0x0014FA38
		internal vk(wd A_0, char[] A_1, int A_2, int A_3)
		{
			this.c = A_2;
			this.b = new w5(A_0, A_1, A_2, A_3);
			if (this.b.b(false))
			{
				this.a = this.b.c(false);
			}
			else if (this.b.p())
			{
				this.a = this.b.i();
			}
			else
			{
				this.a = this.b.g();
			}
			this.d = this.b.f();
		}

		// Token: 0x0600236C RID: 9068 RVA: 0x00150AE4 File Offset: 0x0014FAE4
		internal q7 a()
		{
			return this.a;
		}

		// Token: 0x0600236D RID: 9069 RVA: 0x00150AFC File Offset: 0x0014FAFC
		internal string b()
		{
			return this.b.b(this.c);
		}

		// Token: 0x0600236E RID: 9070 RVA: 0x00150B20 File Offset: 0x0014FB20
		internal bool c()
		{
			return this.d != null && this.d.b() != 0;
		}

		// Token: 0x0600236F RID: 9071 RVA: 0x00150B50 File Offset: 0x0014FB50
		internal sz d()
		{
			return this.d;
		}

		// Token: 0x04000F38 RID: 3896
		private q7 a;

		// Token: 0x04000F39 RID: 3897
		private w5 b;

		// Token: 0x04000F3A RID: 3898
		private int c;

		// Token: 0x04000F3B RID: 3899
		private sz d = null;
	}
}
