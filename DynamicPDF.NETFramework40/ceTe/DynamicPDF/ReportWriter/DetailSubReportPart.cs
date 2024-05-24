using System;
using ceTe.DynamicPDF.ReportWriter.IO;
using ceTe.DynamicPDF.ReportWriter.ReportElements;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter
{
	// Token: 0x02000813 RID: 2067
	public class DetailSubReportPart : ReportPart
	{
		// Token: 0x0600539F RID: 21407 RVA: 0x002924A2 File Offset: 0x002914A2
		internal DetailSubReportPart(vo A_0, SubReport A_1) : base(A_0, A_1)
		{
			this.a = A_0.a();
		}

		// Token: 0x060053A0 RID: 21408 RVA: 0x002924C4 File Offset: 0x002914C4
		internal xh a(LayoutWriter A_0)
		{
			xh xh = new xh(x5.a(base.Height));
			xh.a(this, A_0);
			return xh;
		}

		// Token: 0x17000797 RID: 1943
		// (get) Token: 0x060053A1 RID: 21409 RVA: 0x002924F4 File Offset: 0x002914F4
		// (set) Token: 0x060053A2 RID: 21410 RVA: 0x0029250C File Offset: 0x0029150C
		public bool AutoSplit
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x04002CCF RID: 11471
		private bool a = false;
	}
}
