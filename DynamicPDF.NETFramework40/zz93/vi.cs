using System;

namespace zz93
{
	// Token: 0x02000333 RID: 819
	internal class vi
	{
		// Token: 0x0600235F RID: 9055 RVA: 0x00150791 File Offset: 0x0014F791
		internal vi()
		{
		}

		// Token: 0x06002360 RID: 9056 RVA: 0x001507AC File Offset: 0x0014F7AC
		internal void a(object A_0)
		{
			if (this.b == null)
			{
				this.a = (this.b = new vi.a(A_0));
			}
			else
			{
				this.b = (this.b.b = new vi.a(A_0));
			}
		}

		// Token: 0x06002361 RID: 9057 RVA: 0x001507FF File Offset: 0x0014F7FF
		internal void a()
		{
			this.b = this.a;
		}

		// Token: 0x06002362 RID: 9058 RVA: 0x00150810 File Offset: 0x0014F810
		internal object b()
		{
			object result = this.b.a;
			this.b = this.b.b;
			return result;
		}

		// Token: 0x06002363 RID: 9059 RVA: 0x00150840 File Offset: 0x0014F840
		internal object c()
		{
			if (this.b == null)
			{
				this.b = this.a;
			}
			object result = this.b.a;
			this.b = this.b.b;
			return result;
		}

		// Token: 0x04000F2F RID: 3887
		private vi.a a = null;

		// Token: 0x04000F30 RID: 3888
		private vi.a b = null;

		// Token: 0x02000334 RID: 820
		internal class a
		{
			// Token: 0x06002364 RID: 9060 RVA: 0x0015088C File Offset: 0x0014F88C
			internal a(object A_0)
			{
				this.a = A_0;
				this.b = null;
			}

			// Token: 0x04000F31 RID: 3889
			internal object a;

			// Token: 0x04000F32 RID: 3890
			internal vi.a b;
		}
	}
}
