using System;

namespace zz93
{
	// Token: 0x020000A9 RID: 169
	internal class dv
	{
		// Token: 0x060007F5 RID: 2037 RVA: 0x00071B60 File Offset: 0x00070B60
		internal dv(acm.a[] A_0)
		{
			this.a = new dv.a[A_0.Length];
			this.a(A_0[0].b(), A_0[0].c());
			for (int i = 1; i < A_0.Length; i++)
			{
				this.a(A_0[i]);
			}
		}

		// Token: 0x060007F6 RID: 2038 RVA: 0x00071BC0 File Offset: 0x00070BC0
		private void a(acm.a A_0)
		{
			x5 a_ = this.a(A_0.a());
			x5 a_2 = this.a(A_0.b());
			x5 a_3 = x5.e(a_2, a_);
			if (x5.c(A_0.c(), a_3) || x5.d(A_0.c(), x5.c()))
			{
				int num = this.b - 1;
				if (x5.h(A_0.b(), this.a[num].a()))
				{
					this.a[num].a(x5.f(A_0.c(), a_));
				}
				else
				{
					this.a(A_0.b(), x5.f(A_0.c(), a_));
				}
			}
		}

		// Token: 0x060007F7 RID: 2039 RVA: 0x00071C80 File Offset: 0x00070C80
		private void a(x5 A_0, x5 A_1)
		{
			this.a[this.b++] = new dv.a(A_0, A_1);
		}

		// Token: 0x060007F8 RID: 2040 RVA: 0x00071CB0 File Offset: 0x00070CB0
		internal x5 a(x5 A_0)
		{
			int num = this.a(A_0, 0, this.b - 1);
			x5 result;
			if (num >= 0)
			{
				result = this.a[num].b();
			}
			else
			{
				result = x5.c();
			}
			return result;
		}

		// Token: 0x060007F9 RID: 2041 RVA: 0x00071CF0 File Offset: 0x00070CF0
		internal x5 a()
		{
			x5 result;
			if (this.b == 0)
			{
				result = x5.c();
			}
			else
			{
				result = this.a[this.b - 1].b();
			}
			return result;
		}

		// Token: 0x060007FA RID: 2042 RVA: 0x00071D30 File Offset: 0x00070D30
		private int a(x5 A_0, int A_1, int A_2)
		{
			int result;
			if (A_1 == A_2)
			{
				if (x5.a(A_0, this.a[A_1].a()))
				{
					result = A_1;
				}
				else
				{
					result = -1;
				}
			}
			else
			{
				int num = (A_1 + A_2 + 1) / 2;
				if (x5.h(A_0, this.a[num].a()))
				{
					result = num;
				}
				else if (x5.c(A_0, this.a[num].a()))
				{
					int num2 = this.a(A_0, num, A_2);
					if (num > num2)
					{
						result = num;
					}
					else
					{
						result = num2;
					}
				}
				else
				{
					result = this.a(A_0, A_1, num - 1);
				}
			}
			return result;
		}

		// Token: 0x04000458 RID: 1112
		private dv.a[] a;

		// Token: 0x04000459 RID: 1113
		private int b = 0;

		// Token: 0x020000AA RID: 170
		internal class a
		{
			// Token: 0x060007FB RID: 2043 RVA: 0x00071DDB File Offset: 0x00070DDB
			internal a(x5 A_0, x5 A_1)
			{
				this.a = A_0;
				this.b = A_1;
			}

			// Token: 0x060007FC RID: 2044 RVA: 0x00071DF4 File Offset: 0x00070DF4
			internal x5 a()
			{
				return this.a;
			}

			// Token: 0x060007FD RID: 2045 RVA: 0x00071E0C File Offset: 0x00070E0C
			internal x5 b()
			{
				return this.b;
			}

			// Token: 0x060007FE RID: 2046 RVA: 0x00071E24 File Offset: 0x00070E24
			internal void a(x5 A_0)
			{
				this.b = A_0;
			}

			// Token: 0x0400045A RID: 1114
			private x5 a;

			// Token: 0x0400045B RID: 1115
			private x5 b;
		}
	}
}
