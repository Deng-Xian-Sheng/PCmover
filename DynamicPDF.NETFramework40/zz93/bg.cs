using System;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x02000047 RID: 71
	internal class bg
	{
		// Token: 0x0600028E RID: 654 RVA: 0x0003DCD9 File Offset: 0x0003CCD9
		internal bg(Certificate A_0, TimestampServer A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x0600028F RID: 655 RVA: 0x0003DCF4 File Offset: 0x0003CCF4
		internal Certificate a()
		{
			return this.a;
		}

		// Token: 0x06000290 RID: 656 RVA: 0x0003DD0C File Offset: 0x0003CD0C
		internal TimestampServer b()
		{
			return this.b;
		}

		// Token: 0x040001AE RID: 430
		private Certificate a;

		// Token: 0x040001AF RID: 431
		private TimestampServer b;
	}
}
