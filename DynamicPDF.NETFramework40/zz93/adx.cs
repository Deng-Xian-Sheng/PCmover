using System;
using System.IO;

namespace zz93
{
	// Token: 0x0200047A RID: 1146
	internal abstract class adx : sa
	{
		// Token: 0x06002F64 RID: 12132 RVA: 0x001ADC9C File Offset: 0x001ACC9C
		internal adx(ushort A_0, Stream A_1, byte[] A_2, int A_3) : base(A_1, A_2, A_3)
		{
			this.a = new int[(int)A_0];
		}

		// Token: 0x06002F65 RID: 12133
		internal abstract void jp(ad8 A_0, bool A_1);

		// Token: 0x06002F66 RID: 12134 RVA: 0x001ADCB8 File Offset: 0x001ACCB8
		internal int[] a()
		{
			return this.a;
		}

		// Token: 0x04001692 RID: 5778
		private new int[] a;
	}
}
