using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x0200041D RID: 1053
	internal class abf : abd
	{
		// Token: 0x06002BD5 RID: 11221 RVA: 0x001942DB File Offset: 0x001932DB
		internal abf(bool A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06002BD6 RID: 11222 RVA: 0x001942F0 File Offset: 0x001932F0
		internal override ag9 hy()
		{
			return ag9.a;
		}

		// Token: 0x06002BD7 RID: 11223 RVA: 0x00194304 File Offset: 0x00193304
		internal bool a()
		{
			return this.a;
		}

		// Token: 0x06002BD8 RID: 11224 RVA: 0x0019431C File Offset: 0x0019331C
		internal override void hz(DocumentWriter A_0)
		{
			if (base.p())
			{
				A_0.WriteBoolean(this.a);
			}
		}

		// Token: 0x040014A0 RID: 5280
		private bool a;
	}
}
