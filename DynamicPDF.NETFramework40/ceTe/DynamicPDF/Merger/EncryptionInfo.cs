using System;
using zz93;

namespace ceTe.DynamicPDF.Merger
{
	// Token: 0x020006E6 RID: 1766
	public class EncryptionInfo
	{
		// Token: 0x06004440 RID: 17472 RVA: 0x002334DD File Offset: 0x002324DD
		internal void a(SecurityInfo A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06004441 RID: 17473 RVA: 0x002334E7 File Offset: 0x002324E7
		internal void a(cd A_0)
		{
			this.b = A_0;
		}

		// Token: 0x170003AF RID: 943
		// (get) Token: 0x06004442 RID: 17474 RVA: 0x002334F4 File Offset: 0x002324F4
		public SecurityInfo SecurityInfo
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x170003B0 RID: 944
		// (get) Token: 0x06004443 RID: 17475 RVA: 0x0023350C File Offset: 0x0023250C
		public bool HasUserPassword
		{
			get
			{
				return this.b == cd.a || this.b == cd.c;
			}
		}

		// Token: 0x170003B1 RID: 945
		// (get) Token: 0x06004444 RID: 17476 RVA: 0x00233540 File Offset: 0x00232540
		public bool HasOwnerPassword
		{
			get
			{
				return this.b == cd.b || this.b == cd.c;
			}
		}

		// Token: 0x0400260F RID: 9743
		private SecurityInfo a = SecurityInfo.None;

		// Token: 0x04002610 RID: 9744
		private cd b = cd.d;
	}
}
