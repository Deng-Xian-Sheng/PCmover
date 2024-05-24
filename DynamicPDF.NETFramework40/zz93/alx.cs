using System;

namespace zz93
{
	// Token: 0x020005A2 RID: 1442
	internal class alx
	{
		// Token: 0x06003944 RID: 14660 RVA: 0x001EAAFC File Offset: 0x001E9AFC
		internal void a(am6 A_0, x5 A_1)
		{
			if (this.a == null)
			{
				this.a = (this.b = new alu(A_1, A_0));
			}
			else
			{
				alu alu = new alu(A_1, A_0);
				if (this.b == null)
				{
					this.b = this.c;
				}
				if (this.b.c == null)
				{
					this.b.c = alu;
					alu.d = this.b;
					this.b = alu;
				}
				else
				{
					alu.c = this.b.c;
					alu.d = this.b;
					this.b.c.d = alu;
					this.b.c = alu;
					this.b = alu;
				}
			}
		}

		// Token: 0x06003945 RID: 14661 RVA: 0x001EABD8 File Offset: 0x001E9BD8
		internal void b(am6 A_0, x5 A_1)
		{
			if (this.a == null)
			{
				this.a = (this.b = new alu(A_1, A_0));
			}
			else
			{
				alu alu = new alu(A_1, A_0);
				if (this.b == this.a)
				{
					alu.c = this.b;
					this.b.d = alu;
					this.a = (this.b = alu);
				}
				else if (this.b == null)
				{
					alu.d = this.c;
					this.c.c = alu;
					this.b = alu;
				}
				else
				{
					alu.c = this.b;
					alu.d = this.b.d;
					this.b.d.c = alu;
					this.b.d = alu;
					this.b = alu;
				}
			}
		}

		// Token: 0x06003946 RID: 14662 RVA: 0x001EACD4 File Offset: 0x001E9CD4
		internal void a()
		{
			this.b = this.a;
		}

		// Token: 0x06003947 RID: 14663 RVA: 0x001EACE4 File Offset: 0x001E9CE4
		internal alu b()
		{
			alu result;
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

		// Token: 0x06003948 RID: 14664 RVA: 0x001EAD30 File Offset: 0x001E9D30
		internal void a(x5 A_0)
		{
			alu alu = this.a;
			while (alu != null)
			{
				if (x5.a(alu.a, A_0))
				{
					this.a(alu);
					if (alu.c != null && alu.b == alu.c.b)
					{
						alu = alu.c;
						this.a(alu);
					}
				}
				else if (alu.c != null && alu.b == alu.c.b)
				{
					alu = alu.c;
				}
				if (alu != null)
				{
					alu = alu.c;
				}
			}
			this.b = this.a;
		}

		// Token: 0x06003949 RID: 14665 RVA: 0x001EAE00 File Offset: 0x001E9E00
		internal void a(object A_0)
		{
			alu alu = this.a;
			while (alu != null)
			{
				if (alu.b == A_0)
				{
					this.a(alu);
					if (alu.c != null && alu.b == alu.c.b)
					{
						alu = alu.c;
						this.a(alu);
					}
					break;
				}
				if (alu != null)
				{
					alu = alu.c;
				}
			}
			this.b = this.a;
		}

		// Token: 0x0600394A RID: 14666 RVA: 0x001EAE98 File Offset: 0x001E9E98
		internal void a(alu A_0)
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

		// Token: 0x04001B4A RID: 6986
		internal alu a;

		// Token: 0x04001B4B RID: 6987
		private alu b;

		// Token: 0x04001B4C RID: 6988
		private alu c;
	}
}
