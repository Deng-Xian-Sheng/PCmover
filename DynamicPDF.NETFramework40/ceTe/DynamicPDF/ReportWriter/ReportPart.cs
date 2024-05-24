using System;
using ceTe.DynamicPDF.ReportWriter.ReportElements;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter
{
	// Token: 0x02000811 RID: 2065
	public class ReportPart
	{
		// Token: 0x06005393 RID: 21395 RVA: 0x002922F0 File Offset: 0x002912F0
		internal ReportPart(vm A_0, Report A_1)
		{
			this.a = A_0.fw();
			this.b = A_0.fx();
			if (A_0.fy() != null)
			{
				this.c = new ReportElementList(A_1, A_0.fy());
			}
		}

		// Token: 0x06005394 RID: 21396 RVA: 0x00292344 File Offset: 0x00291344
		internal ReportPart(vm A_0, SubReport A_1)
		{
			this.a = A_0.fw();
			this.b = A_0.fx();
			if (A_0.fy() != null)
			{
				this.c = new ReportElementList(A_1, A_0.fy());
			}
		}

		// Token: 0x17000792 RID: 1938
		// (get) Token: 0x06005395 RID: 21397 RVA: 0x00292398 File Offset: 0x00291398
		public bool HasElements
		{
			get
			{
				return this.c != null && this.c.Count > 0;
			}
		}

		// Token: 0x17000793 RID: 1939
		// (get) Token: 0x06005396 RID: 21398 RVA: 0x002923C4 File Offset: 0x002913C4
		public ReportElementList Elements
		{
			get
			{
				return this.c;
			}
		}

		// Token: 0x17000794 RID: 1940
		// (get) Token: 0x06005397 RID: 21399 RVA: 0x002923DC File Offset: 0x002913DC
		// (set) Token: 0x06005398 RID: 21400 RVA: 0x002923FA File Offset: 0x002913FA
		public float Height
		{
			get
			{
				return x5.b(this.b);
			}
			set
			{
				this.b = x5.a(value);
			}
		}

		// Token: 0x17000795 RID: 1941
		// (get) Token: 0x06005399 RID: 21401 RVA: 0x0029240C File Offset: 0x0029140C
		// (set) Token: 0x0600539A RID: 21402 RVA: 0x00292424 File Offset: 0x00291424
		public string Id
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

		// Token: 0x04002CCB RID: 11467
		private string a;

		// Token: 0x04002CCC RID: 11468
		private x5 b;

		// Token: 0x04002CCD RID: 11469
		private ReportElementList c = null;
	}
}
