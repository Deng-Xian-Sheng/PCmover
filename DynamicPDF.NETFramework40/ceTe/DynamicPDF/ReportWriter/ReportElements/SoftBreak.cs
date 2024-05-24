using System;
using ceTe.DynamicPDF.ReportWriter.IO;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter.ReportElements
{
	// Token: 0x02000830 RID: 2096
	public class SoftBreak : ReportElement
	{
		// Token: 0x0600547C RID: 21628 RVA: 0x00295400 File Offset: 0x00294400
		internal SoftBreak(rm A_0, wk A_1)
		{
			this.a = A_1.a();
			A_0.b().DocumentLayout.a(A_1.f0(), this);
		}

		// Token: 0x0600547D RID: 21629 RVA: 0x00295430 File Offset: 0x00294430
		internal override void fi(xf A_0, LayoutWriter A_1)
		{
			if (A_0.j() == null)
			{
				A_0.b(new x2());
			}
			A_0.j().a(this.a);
		}

		// Token: 0x0600547E RID: 21630 RVA: 0x0029546C File Offset: 0x0029446C
		internal override bool fj()
		{
			return false;
		}

		// Token: 0x0600547F RID: 21631 RVA: 0x00295480 File Offset: 0x00294480
		internal override ushort fk()
		{
			return 61440;
		}

		// Token: 0x170007C8 RID: 1992
		// (get) Token: 0x06005480 RID: 21632 RVA: 0x00295498 File Offset: 0x00294498
		// (set) Token: 0x06005481 RID: 21633 RVA: 0x002954B6 File Offset: 0x002944B6
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

		// Token: 0x04002D41 RID: 11585
		private x5 a;
	}
}
