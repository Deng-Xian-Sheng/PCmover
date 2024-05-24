using System;

namespace zz93
{
	// Token: 0x0200016B RID: 363
	internal class i7 : fd
	{
		// Token: 0x06000D3C RID: 3388 RVA: 0x00097F34 File Offset: 0x00096F34
		internal i7(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000D3D RID: 3389 RVA: 0x00097F48 File Offset: 0x00096F48
		internal override void cw(gi A_0)
		{
			int num = A_0.aj();
			int num2 = num;
			if (num2 <= 148329381)
			{
				if (num2 == 27497991)
				{
					this.a = new gt(g9.c);
					return;
				}
				if (num2 == 148329381)
				{
					this.a = new gt(g9.b);
					return;
				}
			}
			else
			{
				if (num2 == 505607249)
				{
					this.a = new gt(g9.a);
					this.a.d(true);
					return;
				}
				if (num2 == 960366471)
				{
					this.a = new gt(g9.a);
					return;
				}
			}
			this.a = new gt(g9.a);
		}

		// Token: 0x06000D3E RID: 3390 RVA: 0x00097FE0 File Offset: 0x00096FE0
		internal gt a()
		{
			return this.a;
		}

		// Token: 0x06000D3F RID: 3391 RVA: 0x00097FF8 File Offset: 0x00096FF8
		internal void a(gt A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06000D40 RID: 3392 RVA: 0x00098004 File Offset: 0x00097004
		internal override int cv()
		{
			return 1844443081;
		}

		// Token: 0x06000D41 RID: 3393 RVA: 0x0009801C File Offset: 0x0009701C
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x040006C6 RID: 1734
		private new gt a;
	}
}
