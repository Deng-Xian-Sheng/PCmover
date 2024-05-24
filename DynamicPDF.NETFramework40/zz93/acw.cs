using System;

namespace zz93
{
	// Token: 0x02000453 RID: 1107
	internal abstract class acw
	{
		// Token: 0x06002DB9 RID: 11705 RVA: 0x0019F560 File Offset: 0x0019E560
		public acw(x5 A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06002DBA RID: 11706 RVA: 0x0019F5B4 File Offset: 0x0019E5B4
		public x5 b()
		{
			return this.d;
		}

		// Token: 0x06002DBB RID: 11707 RVA: 0x0019F5CC File Offset: 0x0019E5CC
		internal void c(x5 A_0, x5 A_1)
		{
			this.b(A_0, A_1);
			this.a(A_0);
		}

		// Token: 0x06002DBC RID: 11708 RVA: 0x0019F5E0 File Offset: 0x0019E5E0
		internal void a(x5 A_0, x5 A_1, x5 A_2)
		{
			this.b(A_0, A_1);
			this.a(A_2);
		}

		// Token: 0x06002DBD RID: 11709 RVA: 0x0019F5F4 File Offset: 0x0019E5F4
		private void b(x5 A_0, x5 A_1)
		{
			this.b(A_0);
			if (x5.b(A_0, this.f))
			{
				this.a(A_0, A_1);
			}
		}

		// Token: 0x06002DBE RID: 11710 RVA: 0x0019F628 File Offset: 0x0019E628
		private void a(x5 A_0, x5 A_1)
		{
			if (this.c == this.b.Length)
			{
				acw.a[] array = new acw.a[this.c * 2];
				this.b.CopyTo(array, 0);
				this.b = array;
			}
			this.b[this.c++] = new acw.a(A_0, A_1);
		}

		// Token: 0x06002DBF RID: 11711 RVA: 0x0019F69C File Offset: 0x0019E69C
		private void b(x5 A_0)
		{
			if (x5.d(A_0, this.e))
			{
				this.e = A_0;
				this.f = x5.f(A_0, acw.a);
			}
		}

		// Token: 0x06002DC0 RID: 11712 RVA: 0x0019F6D8 File Offset: 0x0019E6D8
		private void a(x5 A_0)
		{
			if (x5.c(A_0, this.g))
			{
				this.g = A_0;
			}
		}

		// Token: 0x06002DC1 RID: 11713 RVA: 0x0019F704 File Offset: 0x0019E704
		private x5 a()
		{
			x5 x = x5.a();
			for (int i = 0; i < this.c; i++)
			{
				if (x5.b(this.b[i].a, this.f) && x5.c(this.b[i].b, x))
				{
					x = this.b[i].b;
				}
			}
			return x;
		}

		// Token: 0x06002DC2 RID: 11714 RVA: 0x0019F788 File Offset: 0x0019E788
		internal x5 a(bool A_0)
		{
			x5 result;
			if (this.c == 0)
			{
				result = this.d;
			}
			else
			{
				x5 x = this.a();
				if (x5.d(this.g, x))
				{
					if (A_0)
					{
						result = x5.b();
					}
					else
					{
						result = x5.a();
					}
				}
				else if (x5.a(this.d, x))
				{
					if (x5.b(this.d, this.g))
					{
						result = this.d;
					}
					else
					{
						result = this.g;
					}
				}
				else if (A_0)
				{
					result = x;
				}
				else
				{
					result = x5.a();
				}
			}
			return result;
		}

		// Token: 0x040015BA RID: 5562
		private static x5 a = new x5(20000L);

		// Token: 0x040015BB RID: 5563
		private acw.a[] b = new acw.a[8];

		// Token: 0x040015BC RID: 5564
		private int c = 0;

		// Token: 0x040015BD RID: 5565
		private x5 d;

		// Token: 0x040015BE RID: 5566
		private x5 e = x5.b();

		// Token: 0x040015BF RID: 5567
		private x5 f = x5.b();

		// Token: 0x040015C0 RID: 5568
		private x5 g = x5.a();

		// Token: 0x02000454 RID: 1108
		private struct a
		{
			// Token: 0x06002DC4 RID: 11716 RVA: 0x0019F84F File Offset: 0x0019E84F
			public a(x5 A_0, x5 A_1)
			{
				this.a = A_0;
				this.b = A_1;
			}

			// Token: 0x040015C1 RID: 5569
			public x5 a;

			// Token: 0x040015C2 RID: 5570
			public x5 b;
		}
	}
}
