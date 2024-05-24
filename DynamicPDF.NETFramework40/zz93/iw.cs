using System;

namespace zz93
{
	// Token: 0x02000160 RID: 352
	internal class iw : fd
	{
		// Token: 0x06000D01 RID: 3329 RVA: 0x0009613D File Offset: 0x0009513D
		internal iw()
		{
		}

		// Token: 0x06000D02 RID: 3330 RVA: 0x00096148 File Offset: 0x00095148
		internal iw(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000D03 RID: 3331 RVA: 0x0009615C File Offset: 0x0009515C
		internal ix[] a()
		{
			return this.a;
		}

		// Token: 0x06000D04 RID: 3332 RVA: 0x00096174 File Offset: 0x00095174
		internal void a(ix[] A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06000D05 RID: 3333 RVA: 0x00096180 File Offset: 0x00095180
		internal override int cv()
		{
			return 633671921;
		}

		// Token: 0x06000D06 RID: 3334 RVA: 0x00096198 File Offset: 0x00095198
		internal override fn cx()
		{
			return this.a[0];
		}

		// Token: 0x06000D07 RID: 3335 RVA: 0x000961B4 File Offset: 0x000951B4
		private void a(int A_0, ref int A_1)
		{
			if (A_0 <= 505607249)
			{
				if (A_0 == 2250341)
				{
					this.a = new ix[4];
					A_1 = 0;
					this.a[A_1] = new ix(gx.a);
					return;
				}
				if (A_0 == 505607249)
				{
					this.a[A_1] = new ix(gx.a);
					this.a[A_1].d(true);
					return;
				}
			}
			else
			{
				if (A_0 == 510131891)
				{
					this.a[A_1] = new ix(gx.b);
					return;
				}
				if (A_0 == 679057223)
				{
					this.a[A_1] = new ix(gx.c);
					return;
				}
				if (A_0 == 2062126999)
				{
					this.a[A_1] = new ix(gx.d);
					return;
				}
			}
			this.a[A_1] = new ix(gx.d);
		}

		// Token: 0x06000D08 RID: 3336 RVA: 0x00096280 File Offset: 0x00095280
		internal override void cw(gi A_0)
		{
			int a_ = A_0.aj();
			this.a = new ix[4];
			int num = 0;
			this.a(a_, ref num);
			while (A_0.a0() && A_0.aw())
			{
				a_ = A_0.aj();
				num++;
				this.a(a_, ref num);
			}
		}

		// Token: 0x040006AA RID: 1706
		private new ix[] a;
	}
}
