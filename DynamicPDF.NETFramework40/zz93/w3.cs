using System;

namespace zz93
{
	// Token: 0x02000370 RID: 880
	internal class w3
	{
		// Token: 0x06002580 RID: 9600 RVA: 0x0015F2B0 File Offset: 0x0015E2B0
		internal void a(xx A_0, x5 A_1)
		{
			if (this.a == null)
			{
				this.a = (this.b = new ww(A_1, A_0));
			}
			else
			{
				ww ww = new ww(A_1, A_0);
				if (this.b == null)
				{
					this.b = this.c;
				}
				if (this.b.c == null)
				{
					this.b.c = ww;
					ww.d = this.b;
					this.b = ww;
				}
				else
				{
					ww.c = this.b.c;
					ww.d = this.b;
					this.b.c.d = ww;
					this.b.c = ww;
					this.b = ww;
				}
			}
		}

		// Token: 0x06002581 RID: 9601 RVA: 0x0015F38C File Offset: 0x0015E38C
		internal void b(xx A_0, x5 A_1)
		{
			if (this.a == null)
			{
				this.a = (this.b = new ww(A_1, A_0));
			}
			else
			{
				ww ww = new ww(A_1, A_0);
				if (this.b == this.a)
				{
					ww.c = this.b;
					this.b.d = ww;
					this.a = (this.b = ww);
				}
				else if (this.b == null)
				{
					ww.d = this.c;
					this.c.c = ww;
					this.b = ww;
				}
				else
				{
					ww.c = this.b;
					ww.d = this.b.d;
					this.b.d.c = ww;
					this.b.d = ww;
					this.b = ww;
				}
			}
		}

		// Token: 0x06002582 RID: 9602 RVA: 0x0015F488 File Offset: 0x0015E488
		internal void a()
		{
			this.b = this.a;
		}

		// Token: 0x06002583 RID: 9603 RVA: 0x0015F498 File Offset: 0x0015E498
		internal ww b()
		{
			ww result;
			if (this.b == null)
			{
				result = null;
			}
			else
			{
				this.c = this.b;
				this.b = this.b.c;
				result = this.c;
			}
			return result;
		}

		// Token: 0x06002584 RID: 9604 RVA: 0x0015F4E4 File Offset: 0x0015E4E4
		internal void a(x5 A_0)
		{
			ww ww = this.a;
			while (ww != null)
			{
				if (x5.a(ww.a, A_0))
				{
					this.a(ww);
					if (ww.c != null && ww.b == ww.c.b)
					{
						ww = ww.c;
						this.a(ww);
					}
				}
				else if (ww.c != null && ww.b == ww.c.b)
				{
					ww = ww.c;
				}
				if (ww != null)
				{
					ww = ww.c;
				}
			}
			this.b = this.a;
		}

		// Token: 0x06002585 RID: 9605 RVA: 0x0015F5B4 File Offset: 0x0015E5B4
		internal void a(object A_0)
		{
			ww ww = this.a;
			while (ww != null)
			{
				if (ww.b == A_0)
				{
					this.a(ww);
					if (ww.c != null && ww.b == ww.c.b)
					{
						ww = ww.c;
						this.a(ww);
					}
					break;
				}
				if (ww != null)
				{
					ww = ww.c;
				}
			}
			this.b = this.a;
		}

		// Token: 0x06002586 RID: 9606 RVA: 0x0015F64C File Offset: 0x0015E64C
		internal void a(ww A_0)
		{
			if (A_0 == this.a)
			{
				if (A_0.c != null)
				{
					A_0.c.d = null;
				}
				this.a = A_0.c;
			}
			else
			{
				if (A_0.c != null)
				{
					A_0.c.d = A_0.d;
				}
				A_0.d.c = A_0.c;
			}
		}

		// Token: 0x04001086 RID: 4230
		internal ww a;

		// Token: 0x04001087 RID: 4231
		private ww b;

		// Token: 0x04001088 RID: 4232
		private ww c;
	}
}
