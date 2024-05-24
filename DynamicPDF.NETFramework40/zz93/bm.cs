using System;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x0200004E RID: 78
	internal class bm
	{
		// Token: 0x060002A9 RID: 681 RVA: 0x0003E0B4 File Offset: 0x0003D0B4
		internal bm(byte[] A_0)
		{
			this.a = new IccProfile(A_0);
			this.b = this.a.a();
		}

		// Token: 0x060002AA RID: 682 RVA: 0x0003E0DC File Offset: 0x0003D0DC
		internal IccProfile a()
		{
			return this.a;
		}

		// Token: 0x060002AB RID: 683 RVA: 0x0003E0F4 File Offset: 0x0003D0F4
		internal int b()
		{
			return this.b;
		}

		// Token: 0x040001E0 RID: 480
		private IccProfile a;

		// Token: 0x040001E1 RID: 481
		private int b;
	}
}
