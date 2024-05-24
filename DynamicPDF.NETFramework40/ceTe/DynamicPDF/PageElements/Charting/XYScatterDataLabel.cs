using System;

namespace ceTe.DynamicPDF.PageElements.Charting
{
	// Token: 0x020007B2 RID: 1970
	public class XYScatterDataLabel : XYDataLabel
	{
		// Token: 0x06004FFF RID: 20479 RVA: 0x0027E52E File Offset: 0x0027D52E
		public XYScatterDataLabel(bool yValue)
		{
			this.c = yValue;
		}

		// Token: 0x06005000 RID: 20480 RVA: 0x0027E540 File Offset: 0x0027D540
		public XYScatterDataLabel(bool yValue, bool series)
		{
			this.c = yValue;
			this.a = series;
		}

		// Token: 0x06005001 RID: 20481 RVA: 0x0027E559 File Offset: 0x0027D559
		public XYScatterDataLabel(bool xValue, bool yValue, bool series)
		{
			this.b = xValue;
			this.c = yValue;
			this.a = series;
		}

		// Token: 0x170006AD RID: 1709
		// (get) Token: 0x06005002 RID: 20482 RVA: 0x0027E57C File Offset: 0x0027D57C
		// (set) Token: 0x06005003 RID: 20483 RVA: 0x0027E594 File Offset: 0x0027D594
		public bool ShowXValue
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x170006AE RID: 1710
		// (get) Token: 0x06005004 RID: 20484 RVA: 0x0027E5A0 File Offset: 0x0027D5A0
		// (set) Token: 0x06005005 RID: 20485 RVA: 0x0027E5B8 File Offset: 0x0027D5B8
		public bool ShowYValue
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
			}
		}

		// Token: 0x170006AF RID: 1711
		// (get) Token: 0x06005006 RID: 20486 RVA: 0x0027E5C4 File Offset: 0x0027D5C4
		// (set) Token: 0x06005007 RID: 20487 RVA: 0x0027E5DC File Offset: 0x0027D5DC
		public bool Series
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

		// Token: 0x04002B2A RID: 11050
		private new bool a;

		// Token: 0x04002B2B RID: 11051
		private bool b;

		// Token: 0x04002B2C RID: 11052
		private bool c;
	}
}
