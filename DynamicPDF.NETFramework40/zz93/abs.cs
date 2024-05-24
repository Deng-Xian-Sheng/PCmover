using System;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x0200042A RID: 1066
	internal abstract class abs
	{
		// Token: 0x06002C47 RID: 11335 RVA: 0x00196460 File Offset: 0x00195460
		internal abs(PdfDocument A_0)
		{
			this.b = A_0;
			if (abs.a < 9223372036854775807L)
			{
				long num = abs.a;
				abs.a = num + 1L;
				this.c = num;
			}
			else
			{
				this.c = long.MaxValue;
				abs.a = long.MinValue;
			}
		}

		// Token: 0x06002C48 RID: 11336 RVA: 0x001964CC File Offset: 0x001954CC
		internal long i()
		{
			return this.c;
		}

		// Token: 0x06002C49 RID: 11337 RVA: 0x001964E4 File Offset: 0x001954E4
		internal PdfDocument j()
		{
			return this.b;
		}

		// Token: 0x06002C4A RID: 11338
		internal abstract aba h4();

		// Token: 0x06002C4B RID: 11339
		internal abstract void h5(aba A_0);

		// Token: 0x040014D6 RID: 5334
		private static long a = 0L;

		// Token: 0x040014D7 RID: 5335
		private PdfDocument b;

		// Token: 0x040014D8 RID: 5336
		private long c;
	}
}
