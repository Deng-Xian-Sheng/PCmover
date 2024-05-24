using System;
using ceTe.DynamicPDF.LayoutEngine.Layout;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;

namespace zz93
{
	// Token: 0x020005D3 RID: 1491
	internal class am9 : LayoutTextArea
	{
		// Token: 0x06003B23 RID: 15139 RVA: 0x001FAF54 File Offset: 0x001F9F54
		internal am9(RecordBox A_0, string A_1) : base(A_0, A_1)
		{
			this.a = A_0;
		}

		// Token: 0x06003B24 RID: 15140 RVA: 0x001FAF68 File Offset: 0x001F9F68
		internal override void nr(char[] A_0)
		{
			if (this.a != null)
			{
				A_0 = this.a.a(A_0);
			}
			base.nr(A_0);
			if (this.a != null)
			{
				this.a.a(A_0, this);
			}
		}

		// Token: 0x04001BDF RID: 7135
		private new RecordBox a;
	}
}
