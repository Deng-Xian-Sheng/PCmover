using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008A9 RID: 2217
	public abstract class StackedColumnSeriesElement : StackedSeriesElement
	{
		// Token: 0x06005A76 RID: 23158 RVA: 0x0033D5B8 File Offset: 0x0033C5B8
		internal StackedColumnSeriesElement(string A_0, Color A_1, float A_2, Color A_3, Legend A_4) : base(A_0, A_1, A_4)
		{
			this.b = A_2;
			this.c = A_3;
		}

		// Token: 0x17000937 RID: 2359
		// (get) Token: 0x06005A77 RID: 23159 RVA: 0x0033D5E4 File Offset: 0x0033C5E4
		// (set) Token: 0x06005A78 RID: 23160 RVA: 0x0033D5FC File Offset: 0x0033C5FC
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

		// Token: 0x17000938 RID: 2360
		// (get) Token: 0x06005A79 RID: 23161 RVA: 0x0033D608 File Offset: 0x0033C608
		// (set) Token: 0x06005A7A RID: 23162 RVA: 0x0033D620 File Offset: 0x0033C620
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

		// Token: 0x17000939 RID: 2361
		// (get) Token: 0x06005A7B RID: 23163 RVA: 0x0033D62C File Offset: 0x0033C62C
		// (set) Token: 0x06005A7C RID: 23164 RVA: 0x0033D644 File Offset: 0x0033C644
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

		// Token: 0x06005A7D RID: 23165 RVA: 0x0033D650 File Offset: 0x0033C650
		internal StackedColumnValueList a()
		{
			return this.a;
		}

		// Token: 0x06005A7E RID: 23166 RVA: 0x0033D668 File Offset: 0x0033C668
		internal void a(StackedColumnValueList A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06005A7F RID: 23167 RVA: 0x0033D672 File Offset: 0x0033C672
		internal void a(PageWriter A_0)
		{
			this.a.a(A_0);
		}

		// Token: 0x06005A80 RID: 23168 RVA: 0x0033D682 File Offset: 0x0033C682
		internal void a(PageWriter A_0, StackedColumnSeriesElement[] A_1, int A_2, int A_3, int A_4)
		{
			this.a.a(A_0, A_1, A_2, A_3, A_4);
		}

		// Token: 0x04002F7D RID: 12157
		private new StackedColumnValueList a;

		// Token: 0x04002F7E RID: 12158
		private new float b = 1f;

		// Token: 0x04002F7F RID: 12159
		private Color c;

		// Token: 0x04002F80 RID: 12160
		private BarColumnValuePositionDataLabel d;
	}
}
