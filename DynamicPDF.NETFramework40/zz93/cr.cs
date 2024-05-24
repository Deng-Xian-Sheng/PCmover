using System;
using System.Security.Cryptography.X509Certificates;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x0200007D RID: 125
	internal struct cr
	{
		// Token: 0x060005C3 RID: 1475 RVA: 0x000552AC File Offset: 0x000542AC
		internal bool a()
		{
			return this.f;
		}

		// Token: 0x060005C4 RID: 1476 RVA: 0x000552C4 File Offset: 0x000542C4
		internal void a(bool A_0)
		{
			this.f = A_0;
		}

		// Token: 0x060005C5 RID: 1477 RVA: 0x000552D0 File Offset: 0x000542D0
		internal int b()
		{
			return this.a;
		}

		// Token: 0x060005C6 RID: 1478 RVA: 0x000552E8 File Offset: 0x000542E8
		internal void a(int A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x000552F4 File Offset: 0x000542F4
		internal X509Certificate2 c()
		{
			return this.d;
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x0005530C File Offset: 0x0005430C
		internal void a(X509Certificate2 A_0)
		{
			this.d = A_0;
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x00055318 File Offset: 0x00054318
		internal int d()
		{
			return this.b;
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x00055330 File Offset: 0x00054330
		internal void b(int A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x0005533C File Offset: 0x0005433C
		internal int e()
		{
			return this.c;
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x00055354 File Offset: 0x00054354
		internal void c(int A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060005CD RID: 1485 RVA: 0x00055360 File Offset: 0x00054360
		internal TimestampServer f()
		{
			return this.e;
		}

		// Token: 0x060005CE RID: 1486 RVA: 0x00055378 File Offset: 0x00054378
		internal void a(TimestampServer A_0)
		{
			this.e = A_0;
		}

		// Token: 0x060005CF RID: 1487 RVA: 0x00055384 File Offset: 0x00054384
		internal int g()
		{
			int result;
			if (this.e != null && this.e.Url != string.Empty)
			{
				result = 12208;
			}
			else
			{
				result = 5848;
			}
			return result;
		}

		// Token: 0x04000316 RID: 790
		private int a;

		// Token: 0x04000317 RID: 791
		private int b;

		// Token: 0x04000318 RID: 792
		private int c;

		// Token: 0x04000319 RID: 793
		private X509Certificate2 d;

		// Token: 0x0400031A RID: 794
		private TimestampServer e;

		// Token: 0x0400031B RID: 795
		private bool f;
	}
}
