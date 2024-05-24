using System;
using ceTe.DynamicPDF.LayoutEngine.Layout;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;

namespace zz93
{
	// Token: 0x020005D1 RID: 1489
	internal class am8 : LayoutTextArea
	{
		// Token: 0x06003AF4 RID: 15092 RVA: 0x001FA1A8 File Offset: 0x001F91A8
		internal am8(RecordArea A_0, char[] A_1) : base(A_0, A_1)
		{
			this.a = A_0;
		}

		// Token: 0x06003AF5 RID: 15093 RVA: 0x001FA1BC File Offset: 0x001F91BC
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

		// Token: 0x04001BD4 RID: 7124
		private new RecordArea a;
	}
}
