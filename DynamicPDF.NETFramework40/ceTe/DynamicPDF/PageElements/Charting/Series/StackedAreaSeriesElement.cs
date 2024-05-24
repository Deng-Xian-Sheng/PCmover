using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008A1 RID: 2209
	public abstract class StackedAreaSeriesElement : StackedSeriesElement
	{
		// Token: 0x06005A26 RID: 23078 RVA: 0x0033C81E File Offset: 0x0033B81E
		internal StackedAreaSeriesElement(string A_0, Color A_1, Marker A_2, Legend A_3) : base(A_0, A_1, A_3)
		{
			this.b = A_2;
		}

		// Token: 0x1700092A RID: 2346
		// (get) Token: 0x06005A27 RID: 23079 RVA: 0x0033C834 File Offset: 0x0033B834
		// (set) Token: 0x06005A28 RID: 23080 RVA: 0x0033C84C File Offset: 0x0033B84C
		public Marker Marker
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

		// Token: 0x1700092B RID: 2347
		// (get) Token: 0x06005A29 RID: 23081 RVA: 0x0033C858 File Offset: 0x0033B858
		// (set) Token: 0x06005A2A RID: 23082 RVA: 0x0033C870 File Offset: 0x0033B870
		public ValuePositionDataLabel DataLabel
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

		// Token: 0x06005A2B RID: 23083 RVA: 0x0033C87C File Offset: 0x0033B87C
		internal StackedAreaValueList a()
		{
			return this.a;
		}

		// Token: 0x06005A2C RID: 23084 RVA: 0x0033C894 File Offset: 0x0033B894
		internal void a(StackedAreaValueList A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06005A2D RID: 23085 RVA: 0x0033C89E File Offset: 0x0033B89E
		internal void a(PageWriter A_0)
		{
			this.a.a(A_0);
		}

		// Token: 0x06005A2E RID: 23086 RVA: 0x0033C8AE File Offset: 0x0033B8AE
		internal void a(PageWriter A_0, StackedAreaSeriesElement A_1, int A_2, ArrayList A_3)
		{
			this.a.a(A_0, base.PlotArea, A_1, A_2, A_3);
		}

		// Token: 0x04002F6C RID: 12140
		private new StackedAreaValueList a;

		// Token: 0x04002F6D RID: 12141
		private new Marker b;

		// Token: 0x04002F6E RID: 12142
		private ValuePositionDataLabel c;
	}
}
