using System;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x0200004D RID: 77
	internal class bl
	{
		// Token: 0x060002A6 RID: 678 RVA: 0x0003E048 File Offset: 0x0003D048
		internal bl(yc A_0, bk[] A_1, uint A_2)
		{
			byte[] iccProfile = A_0.a(A_2, A_1);
			this.a = new IccProfile(iccProfile);
			this.b = this.a.a();
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x0003E084 File Offset: 0x0003D084
		internal IccProfile a()
		{
			return this.a;
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0003E09C File Offset: 0x0003D09C
		internal int b()
		{
			return this.b;
		}

		// Token: 0x040001DE RID: 478
		private IccProfile a;

		// Token: 0x040001DF RID: 479
		private int b;
	}
}
