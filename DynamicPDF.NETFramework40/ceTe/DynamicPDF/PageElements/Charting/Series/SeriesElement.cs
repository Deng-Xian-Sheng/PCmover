using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x02000883 RID: 2179
	public abstract class SeriesElement : PlotAreaElement
	{
		// Token: 0x060058C7 RID: 22727 RVA: 0x003379B4 File Offset: 0x003369B4
		internal SeriesElement()
		{
		}

		// Token: 0x060058C8 RID: 22728 RVA: 0x003379C0 File Offset: 0x003369C0
		internal SeriesElement(string A_0, Color A_1, Legend A_2)
		{
			this.a = A_0;
			if (A_2 != null)
			{
				base.Legend = A_2;
			}
			this.b = A_1;
		}

		// Token: 0x170008EC RID: 2284
		// (get) Token: 0x060058C9 RID: 22729 RVA: 0x003379F4 File Offset: 0x003369F4
		// (set) Token: 0x060058CA RID: 22730 RVA: 0x00337A0C File Offset: 0x00336A0C
		public Color Color
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

		// Token: 0x170008ED RID: 2285
		// (get) Token: 0x060058CB RID: 22731 RVA: 0x00337A18 File Offset: 0x00336A18
		public string Name
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x060058CC RID: 22732 RVA: 0x00337A30 File Offset: 0x00336A30
		internal void a(string A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060058CD RID: 22733 RVA: 0x00337A3A File Offset: 0x00336A3A
		internal void a(LegendLabel A_0)
		{
			this.c = A_0;
		}

		// Token: 0x170008EE RID: 2286
		// (get) Token: 0x060058CE RID: 22734 RVA: 0x00337A44 File Offset: 0x00336A44
		public LegendLabel LegendLabel
		{
			get
			{
				return this.c;
			}
		}

		// Token: 0x04002F23 RID: 12067
		private new string a;

		// Token: 0x04002F24 RID: 12068
		private Color b;

		// Token: 0x04002F25 RID: 12069
		private LegendLabel c;
	}
}
