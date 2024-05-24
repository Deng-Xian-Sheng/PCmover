using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x020004F8 RID: 1272
	internal class ahd : c8
	{
		// Token: 0x060033FC RID: 13308 RVA: 0x001CD905 File Offset: 0x001CC905
		internal ahd(afj A_0) : base(A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060033FD RID: 13309 RVA: 0x001CD918 File Offset: 0x001CC918
		internal override afj lt()
		{
			return this.a;
		}

		// Token: 0x060033FE RID: 13310 RVA: 0x001CD930 File Offset: 0x001CC930
		internal override void bw(DocumentWriter A_0)
		{
			throw new MergerException("Stream cannot be drawn.");
		}

		// Token: 0x0400191A RID: 6426
		private afj a;
	}
}
