using System;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x0200004F RID: 79
	internal class bn
	{
		// Token: 0x060002AC RID: 684 RVA: 0x0003E10C File Offset: 0x0003D10C
		internal bn(byte[] A_0)
		{
			this.a = new IccProfile(A_0);
			this.b = this.a.a();
		}

		// Token: 0x060002AD RID: 685 RVA: 0x0003E134 File Offset: 0x0003D134
		internal IccProfile a()
		{
			return this.a;
		}

		// Token: 0x060002AE RID: 686 RVA: 0x0003E14C File Offset: 0x0003D14C
		internal int b()
		{
			return this.b;
		}

		// Token: 0x040001E2 RID: 482
		private IccProfile a;

		// Token: 0x040001E3 RID: 483
		private int b;
	}
}
