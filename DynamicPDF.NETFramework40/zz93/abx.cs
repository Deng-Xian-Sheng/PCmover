using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x0200042F RID: 1071
	internal class abx : c8
	{
		// Token: 0x06002C7B RID: 11387 RVA: 0x00196CDC File Offset: 0x00195CDC
		internal abx(ag6 A_0) : base(A_0.d())
		{
			this.a = A_0;
		}

		// Token: 0x06002C7C RID: 11388 RVA: 0x00196CF4 File Offset: 0x00195CF4
		internal override ag6 h7()
		{
			return this.a;
		}

		// Token: 0x06002C7D RID: 11389 RVA: 0x00196D0C File Offset: 0x00195D0C
		internal override void bw(DocumentWriter A_0)
		{
			throw new MergerException("Object Stream cannot be drawn.");
		}

		// Token: 0x040014E8 RID: 5352
		private ag6 a;
	}
}
