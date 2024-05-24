using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000422 RID: 1058
	internal class abk
	{
		// Token: 0x06002C04 RID: 11268 RVA: 0x00194E24 File Offset: 0x00193E24
		internal abk(abu A_0, abd A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x06002C05 RID: 11269 RVA: 0x00194E4C File Offset: 0x00193E4C
		internal abu a()
		{
			return this.a;
		}

		// Token: 0x06002C06 RID: 11270 RVA: 0x00194E64 File Offset: 0x00193E64
		internal bool b()
		{
			return this.c;
		}

		// Token: 0x06002C07 RID: 11271 RVA: 0x00194E7C File Offset: 0x00193E7C
		internal void a(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06002C08 RID: 11272 RVA: 0x00194E88 File Offset: 0x00193E88
		internal abd c()
		{
			return this.b;
		}

		// Token: 0x06002C09 RID: 11273 RVA: 0x00194EA0 File Offset: 0x00193EA0
		internal abk d()
		{
			return this.d;
		}

		// Token: 0x06002C0A RID: 11274 RVA: 0x00194EB8 File Offset: 0x00193EB8
		internal void a(abk A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06002C0B RID: 11275 RVA: 0x00194EC2 File Offset: 0x00193EC2
		internal void b(abk A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06002C0C RID: 11276 RVA: 0x00194ECC File Offset: 0x00193ECC
		internal void a(DocumentWriter A_0)
		{
			if (this.b())
			{
				this.a.hz(A_0);
				this.b.hz(A_0);
			}
		}

		// Token: 0x06002C0D RID: 11277 RVA: 0x00194F04 File Offset: 0x00193F04
		internal void a(agx A_0, DocumentWriter A_1)
		{
			if (this.b())
			{
				this.a.h9(A_0, A_1);
				this.b.h9(A_0, A_1);
			}
		}

		// Token: 0x040014AE RID: 5294
		private abu a;

		// Token: 0x040014AF RID: 5295
		private abd b;

		// Token: 0x040014B0 RID: 5296
		private bool c = true;

		// Token: 0x040014B1 RID: 5297
		private abk d = null;
	}
}
