using System;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine
{
	// Token: 0x0200092A RID: 2346
	public class DetailSubReportPart : ReportPart
	{
		// Token: 0x06005F7A RID: 24442 RVA: 0x0035D92A File Offset: 0x0035C92A
		internal DetailSubReportPart(akx A_0, SubReport A_1) : base(A_0, A_1)
		{
			this.a = A_0.a();
		}

		// Token: 0x06005F7B RID: 24443 RVA: 0x0035D94C File Offset: 0x0035C94C
		internal aml a(LayoutWriter A_0)
		{
			aml aml = new aml(x5.a(base.Height));
			aml.a(this, A_0);
			return aml;
		}

		// Token: 0x17000A26 RID: 2598
		// (get) Token: 0x06005F7C RID: 24444 RVA: 0x0035D97C File Offset: 0x0035C97C
		// (set) Token: 0x06005F7D RID: 24445 RVA: 0x0035D994 File Offset: 0x0035C994
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

		// Token: 0x0400311F RID: 12575
		private bool a = false;
	}
}
