using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000092 RID: 146
	internal class c9 : c8
	{
		// Token: 0x06000725 RID: 1829 RVA: 0x0006204A File Offset: 0x0006104A
		internal c9(da A_0) : base(null)
		{
			this.a = A_0;
		}

		// Token: 0x06000726 RID: 1830 RVA: 0x00062064 File Offset: 0x00061064
		internal override void bv(DocumentWriter A_0)
		{
			A_0.WriteReferenceShallow(this.a);
		}

		// Token: 0x06000727 RID: 1831 RVA: 0x00062074 File Offset: 0x00061074
		internal override void bw(DocumentWriter A_0)
		{
			A_0.WriteReference(this.a);
		}

		// Token: 0x040003CA RID: 970
		private Resource a = null;
	}
}
