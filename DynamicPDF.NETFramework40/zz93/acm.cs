using System;

namespace zz93
{
	// Token: 0x02000448 RID: 1096
	internal class acm
	{
		// Token: 0x06002D26 RID: 11558 RVA: 0x0019B12B File Offset: 0x0019A12B
		internal acm()
		{
		}

		// Token: 0x06002D27 RID: 11559 RVA: 0x0019B14C File Offset: 0x0019A14C
		internal void a(x5 A_0, x5 A_1, x5 A_2)
		{
			if (this.a == null)
			{
				this.a = (this.b = new acm.a(A_0, A_1, A_2));
			}
			else
			{
				acm.a a;
				this.b.a(a = new acm.a(A_0, A_1, A_2));
				this.b = a;
			}
			this.c++;
		}

		// Token: 0x06002D28 RID: 11560 RVA: 0x0019B1B4 File Offset: 0x0019A1B4
		internal dv a()
		{
			acm.a[] array = new acm.a[this.c];
			acm.a a = this.a;
			for (int i = 0; i < this.c; i++)
			{
				array[i] = a;
				a = a.d();
			}
			this.a(array, 0, this.c - 1);
			return new dv(array);
		}

		// Token: 0x06002D29 RID: 11561 RVA: 0x0019B214 File Offset: 0x0019A214
		internal bool b()
		{
			return this.a != null;
		}

		// Token: 0x06002D2A RID: 11562 RVA: 0x0019B234 File Offset: 0x0019A234
		private void a(acm.a[] A_0, int A_1, int A_2)
		{
			if (A_2 > A_1)
			{
				int i = A_1;
				int num = A_2;
				int num2 = (A_1 + A_2 + 1) / 2;
				acm.a a = A_0[num2];
				while (i <= num)
				{
					while (i < A_2 && A_0[i].b(a))
					{
						i++;
					}
					while (num > A_1 && a.b(A_0[num]))
					{
						num--;
					}
					if (i <= num)
					{
						acm.a a2 = A_0[i];
						A_0[i] = A_0[num];
						A_0[num] = a2;
						i++;
						num--;
					}
				}
				if (A_1 < num)
				{
					this.a(A_0, A_1, num);
				}
				if (i < A_2)
				{
					this.a(A_0, i, A_2);
				}
			}
		}

		// Token: 0x0400155E RID: 5470
		private acm.a a = null;

		// Token: 0x0400155F RID: 5471
		private acm.a b = null;

		// Token: 0x04001560 RID: 5472
		private int c = 0;

		// Token: 0x02000449 RID: 1097
		internal class a
		{
			// Token: 0x06002D2B RID: 11563 RVA: 0x0019B2FE File Offset: 0x0019A2FE
			internal a(x5 A_0, x5 A_1, x5 A_2)
			{
				this.a = A_0;
				this.b = A_1;
				this.c = A_2;
			}

			// Token: 0x06002D2C RID: 11564 RVA: 0x0019B320 File Offset: 0x0019A320
			internal x5 a()
			{
				return this.a;
			}

			// Token: 0x06002D2D RID: 11565 RVA: 0x0019B338 File Offset: 0x0019A338
			internal x5 b()
			{
				return this.b;
			}

			// Token: 0x06002D2E RID: 11566 RVA: 0x0019B350 File Offset: 0x0019A350
			internal x5 c()
			{
				return this.c;
			}

			// Token: 0x06002D2F RID: 11567 RVA: 0x0019B368 File Offset: 0x0019A368
			internal acm.a d()
			{
				return this.d;
			}

			// Token: 0x06002D30 RID: 11568 RVA: 0x0019B380 File Offset: 0x0019A380
			internal void a(acm.a A_0)
			{
				this.d = A_0;
			}

			// Token: 0x06002D31 RID: 11569 RVA: 0x0019B38C File Offset: 0x0019A38C
			internal bool b(acm.a A_0)
			{
				return x5.d(this.b, A_0.b) || (x5.h(this.b, A_0.b) && x5.d(this.a, A_0.a));
			}

			// Token: 0x04001561 RID: 5473
			private x5 a;

			// Token: 0x04001562 RID: 5474
			private x5 b;

			// Token: 0x04001563 RID: 5475
			private x5 c;

			// Token: 0x04001564 RID: 5476
			private acm.a d;
		}
	}
}
