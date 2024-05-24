using System;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine
{
	// Token: 0x02000929 RID: 2345
	public class DetailReportPart : ReportPart
	{
		// Token: 0x06005F76 RID: 24438 RVA: 0x0035D8B6 File Offset: 0x0035C8B6
		internal DetailReportPart(akw A_0, Report A_1) : base(A_0, A_1)
		{
			this.a = A_0.a();
		}

		// Token: 0x17000A25 RID: 2597
		// (get) Token: 0x06005F77 RID: 24439 RVA: 0x0035D8D8 File Offset: 0x0035C8D8
		// (set) Token: 0x06005F78 RID: 24440 RVA: 0x0035D8F0 File Offset: 0x0035C8F0
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

		// Token: 0x06005F79 RID: 24441 RVA: 0x0035D8FC File Offset: 0x0035C8FC
		internal aml a(LayoutWriter A_0)
		{
			aml aml = new aml(x5.a(base.Height));
			aml.a(this, A_0);
			return aml;
		}

		// Token: 0x0400311E RID: 12574
		private bool a = false;
	}
}
