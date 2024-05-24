using System;
using ceTe.DynamicPDF.ReportWriter.IO;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter
{
	// Token: 0x02000812 RID: 2066
	public class DetailReportPart : ReportPart
	{
		// Token: 0x0600539B RID: 21403 RVA: 0x0029242E File Offset: 0x0029142E
		internal DetailReportPart(vn A_0, Report A_1) : base(A_0, A_1)
		{
			this.a = A_0.a();
		}

		// Token: 0x17000796 RID: 1942
		// (get) Token: 0x0600539C RID: 21404 RVA: 0x00292450 File Offset: 0x00291450
		// (set) Token: 0x0600539D RID: 21405 RVA: 0x00292468 File Offset: 0x00291468
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

		// Token: 0x0600539E RID: 21406 RVA: 0x00292474 File Offset: 0x00291474
		internal xh a(LayoutWriter A_0)
		{
			xh xh = new xh(x5.a(base.Height));
			xh.a(this, A_0);
			return xh;
		}

		// Token: 0x04002CCE RID: 11470
		private bool a = false;
	}
}
