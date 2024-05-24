using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008A5 RID: 2213
	public abstract class StackedBarSeriesElement : StackedSeriesElement
	{
		// Token: 0x06005A4C RID: 23116 RVA: 0x0033CEBC File Offset: 0x0033BEBC
		internal StackedBarSeriesElement(string A_0, Color A_1, float A_2, Color A_3, Legend A_4) : base(A_0, A_1, A_4)
		{
			this.b = A_2;
			this.c = A_3;
		}

		// Token: 0x17000930 RID: 2352
		// (get) Token: 0x06005A4D RID: 23117 RVA: 0x0033CEE8 File Offset: 0x0033BEE8
		// (set) Token: 0x06005A4E RID: 23118 RVA: 0x0033CF00 File Offset: 0x0033BF00
		public float BorderWidth
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

		// Token: 0x17000931 RID: 2353
		// (get) Token: 0x06005A4F RID: 23119 RVA: 0x0033CF0C File Offset: 0x0033BF0C
		// (set) Token: 0x06005A50 RID: 23120 RVA: 0x0033CF24 File Offset: 0x0033BF24
		public BarColumnValuePositionDataLabel DataLabel
		{
			get
			{
				return this.d;
			}
			set
			{
				this.d = value;
			}
		}

		// Token: 0x17000932 RID: 2354
		// (get) Token: 0x06005A51 RID: 23121 RVA: 0x0033CF30 File Offset: 0x0033BF30
		// (set) Token: 0x06005A52 RID: 23122 RVA: 0x0033CF48 File Offset: 0x0033BF48
		public Color BorderColor
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

		// Token: 0x06005A53 RID: 23123 RVA: 0x0033CF54 File Offset: 0x0033BF54
		internal StackedBarValueList a()
		{
			return this.a;
		}

		// Token: 0x06005A54 RID: 23124 RVA: 0x0033CF6C File Offset: 0x0033BF6C
		internal void a(StackedBarValueList A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06005A55 RID: 23125 RVA: 0x0033CF76 File Offset: 0x0033BF76
		internal void a(PageWriter A_0)
		{
			this.a.a(A_0);
		}

		// Token: 0x06005A56 RID: 23126 RVA: 0x0033CF86 File Offset: 0x0033BF86
		internal void a(PageWriter A_0, StackedBarSeriesElement[] A_1, int A_2, int A_3, int A_4)
		{
			this.a.a(A_0, A_1, A_2, A_3, A_4);
		}

		// Token: 0x04002F74 RID: 12148
		private new StackedBarValueList a;

		// Token: 0x04002F75 RID: 12149
		private new float b = 1f;

		// Token: 0x04002F76 RID: 12150
		private Color c;

		// Token: 0x04002F77 RID: 12151
		private BarColumnValuePositionDataLabel d;
	}
}
