using System;

namespace zz93
{
	// Token: 0x02000124 RID: 292
	internal class g8
	{
		// Token: 0x06000B41 RID: 2881 RVA: 0x0008A54C File Offset: 0x0008954C
		internal g8()
		{
		}

		// Token: 0x06000B42 RID: 2882 RVA: 0x0008A558 File Offset: 0x00089558
		internal id a()
		{
			return this.a;
		}

		// Token: 0x06000B43 RID: 2883 RVA: 0x0008A570 File Offset: 0x00089570
		internal bool a(int A_0)
		{
			for (id id = this.a; id != null; id = id.c())
			{
				if (id.b() == A_0)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000B44 RID: 2884 RVA: 0x0008A5B4 File Offset: 0x000895B4
		internal void a(d0 A_0, int A_1)
		{
			if (this.a == null)
			{
				this.a = new id();
				this.a.a(A_0);
				this.a.a(A_1);
				this.a.a(null);
			}
			else
			{
				this.b = new id();
				this.b.a(A_0);
				this.b.a(A_1);
				this.b.a(this.a);
				this.a = this.b;
			}
		}

		// Token: 0x06000B45 RID: 2885 RVA: 0x0008A650 File Offset: 0x00089650
		internal void a(int A_0, ij A_1)
		{
			if (this.a(A_0))
			{
				if (this.a.b() == A_0)
				{
					while (this.a != null && this.a.b() == A_0)
					{
						A_1.h().a(this.a);
						this.a = this.a.c();
					}
				}
				else
				{
					id id = this.b(A_0);
					id = id.c();
					while (id != null && id.b() == A_0)
					{
						A_1.h().a(id);
						id = id.c();
					}
					this.a.a(id);
				}
				this.b = this.a;
			}
		}

		// Token: 0x06000B46 RID: 2886 RVA: 0x0008A728 File Offset: 0x00089728
		internal id b(int A_0)
		{
			for (id id = this.a; id != null; id = id.c())
			{
				if (id.b() == A_0)
				{
					return id;
				}
			}
			return null;
		}

		// Token: 0x04000600 RID: 1536
		private id a;

		// Token: 0x04000601 RID: 1537
		private id b;
	}
}
