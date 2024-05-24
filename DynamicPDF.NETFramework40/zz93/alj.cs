using System;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;

namespace zz93
{
	// Token: 0x02000592 RID: 1426
	internal class alj : akt
	{
		// Token: 0x060038CC RID: 14540 RVA: 0x001E9644 File Offset: 0x001E8644
		internal alj(ald A_0)
		{
			while (A_0.y())
			{
				int num = A_0.u();
				if (num != 57)
				{
					if (num != 2660)
					{
						throw new DlexParseException("A pageBreak element contains an invalid attribute.");
					}
					this.a = A_0.a7();
				}
				else
				{
					this.b = x5.a(A_0.ar());
				}
			}
			if (!A_0.z())
			{
				A_0.aa();
				A_0.aa();
			}
		}

		// Token: 0x060038CD RID: 14541 RVA: 0x001E96C8 File Offset: 0x001E86C8
		internal override LayoutElement mt(alo A_0)
		{
			return new SoftBreak(A_0, this);
		}

		// Token: 0x060038CE RID: 14542 RVA: 0x001E96E4 File Offset: 0x001E86E4
		internal x5 a()
		{
			return this.b;
		}

		// Token: 0x060038CF RID: 14543 RVA: 0x001E96FC File Offset: 0x001E86FC
		internal override string mu()
		{
			return this.a;
		}

		// Token: 0x04001B08 RID: 6920
		private string a;

		// Token: 0x04001B09 RID: 6921
		private x5 b;
	}
}
