using System;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x0200033E RID: 830
	internal abstract class vr
	{
		// Token: 0x06002391 RID: 9105
		internal abstract string f0();

		// Token: 0x06002392 RID: 9106 RVA: 0x00151868 File Offset: 0x00150868
		internal vr u()
		{
			return this.a;
		}

		// Token: 0x06002393 RID: 9107 RVA: 0x00151880 File Offset: 0x00150880
		internal void a(vr A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06002394 RID: 9108
		internal abstract ReportElement fz(rm A_0);

		// Token: 0x04000F51 RID: 3921
		private vr a;
	}
}
