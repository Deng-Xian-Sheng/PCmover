using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x0200041B RID: 1051
	internal abstract class abd
	{
		// Token: 0x06002BC8 RID: 11208
		internal abstract void hz(DocumentWriter A_0);

		// Token: 0x06002BC9 RID: 11209 RVA: 0x0019417A File Offset: 0x0019317A
		internal virtual void h9(agx A_0, DocumentWriter A_1)
		{
			this.hz(A_1);
		}

		// Token: 0x06002BCA RID: 11210
		internal abstract ag9 hy();

		// Token: 0x06002BCB RID: 11211 RVA: 0x00194188 File Offset: 0x00193188
		internal bool p()
		{
			return this.a;
		}

		// Token: 0x06002BCC RID: 11212 RVA: 0x001941A0 File Offset: 0x001931A0
		internal void a(bool A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06002BCD RID: 11213 RVA: 0x001941AC File Offset: 0x001931AC
		internal virtual abd h6()
		{
			return this;
		}

		// Token: 0x0400149E RID: 5278
		private bool a = true;
	}
}
