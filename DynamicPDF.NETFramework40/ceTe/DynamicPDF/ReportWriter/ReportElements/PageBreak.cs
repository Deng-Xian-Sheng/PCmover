using System;
using ceTe.DynamicPDF.ReportWriter.IO;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter.ReportElements
{
	// Token: 0x02000841 RID: 2113
	public class PageBreak : ReportElement
	{
		// Token: 0x0600553B RID: 21819 RVA: 0x00297362 File Offset: 0x00296362
		internal PageBreak(rm A_0, v8 A_1)
		{
			this.a = A_1.a();
			A_0.b().DocumentLayout.a(A_1.f0(), this);
		}

		// Token: 0x0600553C RID: 21820 RVA: 0x00297394 File Offset: 0x00296394
		internal override void fi(xf A_0, LayoutWriter A_1)
		{
			if (A_0.i() == null)
			{
				A_0.a(new x2());
			}
			A_0.i().a(this.a);
		}

		// Token: 0x0600553D RID: 21821 RVA: 0x002973D0 File Offset: 0x002963D0
		internal override bool fj()
		{
			return false;
		}

		// Token: 0x0600553E RID: 21822 RVA: 0x002973E4 File Offset: 0x002963E4
		internal override ushort fk()
		{
			return 61440;
		}

		// Token: 0x170007FF RID: 2047
		// (get) Token: 0x0600553F RID: 21823 RVA: 0x002973FC File Offset: 0x002963FC
		// (set) Token: 0x06005540 RID: 21824 RVA: 0x0029741A File Offset: 0x0029641A
		public float Y
		{
			get
			{
				return x5.b(this.a);
			}
			set
			{
				this.a = x5.a(value);
			}
		}

		// Token: 0x04002D8A RID: 11658
		private x5 a;
	}
}
