using System;
using System.Collections.Generic;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020004B4 RID: 1204
	internal class afh : abe
	{
		// Token: 0x0600318C RID: 12684 RVA: 0x001BBC56 File Offset: 0x001BAC56
		internal afh(agp A_0, List<abd> A_1) : base(A_1)
		{
			this.a = A_0;
		}

		// Token: 0x0600318D RID: 12685 RVA: 0x001BBC6C File Offset: 0x001BAC6C
		internal override ag9 hy()
		{
			return ag9.e;
		}

		// Token: 0x0600318E RID: 12686 RVA: 0x001BBC80 File Offset: 0x001BAC80
		internal override void hz(DocumentWriter A_0)
		{
			if (base.p())
			{
				agx a_ = A_0.a(this.a);
				this.h9(a_, A_0);
			}
		}

		// Token: 0x0600318F RID: 12687 RVA: 0x001BBCB4 File Offset: 0x001BACB4
		internal override void h9(agx A_0, DocumentWriter A_1)
		{
			if (base.p())
			{
				A_1.WriteArrayOpen();
				base.a(A_0, A_1);
				A_1.WriteArrayClose();
			}
		}

		// Token: 0x04001727 RID: 5927
		private new agp a;
	}
}
