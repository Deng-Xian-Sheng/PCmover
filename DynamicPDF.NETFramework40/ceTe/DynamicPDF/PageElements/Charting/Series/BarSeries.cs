using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x02000882 RID: 2178
	public abstract class BarSeries : LegendXYSeries
	{
		// Token: 0x060058B9 RID: 22713 RVA: 0x00337828 File Offset: 0x00336828
		internal BarSeries(string A_0, NumericXAxis A_1, YAxis A_2, Color A_3, float A_4, Color A_5, Legend A_6) : base(A_0, A_1, A_2, A_3)
		{
			base.DrawBehindAxis = true;
			if (A_6 != null)
			{
				base.Legend = A_6;
			}
			this.b = A_4;
			this.c = A_5;
		}

		// Token: 0x170008E8 RID: 2280
		// (get) Token: 0x060058BA RID: 22714 RVA: 0x00337884 File Offset: 0x00336884
		// (set) Token: 0x060058BB RID: 22715 RVA: 0x0033789C File Offset: 0x0033689C
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

		// Token: 0x170008E9 RID: 2281
		// (get) Token: 0x060058BC RID: 22716 RVA: 0x003378A8 File Offset: 0x003368A8
		// (set) Token: 0x060058BD RID: 22717 RVA: 0x003378C0 File Offset: 0x003368C0
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

		// Token: 0x170008EA RID: 2282
		// (get) Token: 0x060058BE RID: 22718 RVA: 0x003378CC File Offset: 0x003368CC
		// (set) Token: 0x060058BF RID: 22719 RVA: 0x003378E4 File Offset: 0x003368E4
		public BarColumnValuePositionDataLabel DataLabel
		{
			get
			{
				return this.e;
			}
			set
			{
				this.e = value;
			}
		}

		// Token: 0x170008EB RID: 2283
		// (get) Token: 0x060058C0 RID: 22720 RVA: 0x003378F0 File Offset: 0x003368F0
		// (set) Token: 0x060058C1 RID: 22721 RVA: 0x00337908 File Offset: 0x00336908
		public string ValueFormat
		{
			get
			{
				return this.f;
			}
			set
			{
				this.f = value;
			}
		}

		// Token: 0x060058C2 RID: 22722 RVA: 0x00337914 File Offset: 0x00336914
		internal BarValueList a()
		{
			return this.a;
		}

		// Token: 0x060058C3 RID: 22723 RVA: 0x0033792C File Offset: 0x0033692C
		internal void a(BarValueList A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060058C4 RID: 22724 RVA: 0x00337936 File Offset: 0x00336936
		internal void a(int A_0)
		{
			this.d = A_0;
		}

		// Token: 0x060058C5 RID: 22725 RVA: 0x00337940 File Offset: 0x00336940
		internal override void ic(PageWriter A_0)
		{
			this.a.b();
			int a_;
			if (this is DateTimeBarSeries)
			{
				a_ = base.PlotArea.Series.e();
			}
			else
			{
				a_ = base.PlotArea.Series.d();
			}
			this.a.a(A_0, this.d, a_);
		}

		// Token: 0x060058C6 RID: 22726 RVA: 0x003379A4 File Offset: 0x003369A4
		internal override void ib(PageWriter A_0)
		{
			this.a.b(A_0);
		}

		// Token: 0x04002F1D RID: 12061
		private new BarValueList a;

		// Token: 0x04002F1E RID: 12062
		private new float b = 1f;

		// Token: 0x04002F1F RID: 12063
		private Color c;

		// Token: 0x04002F20 RID: 12064
		private int d;

		// Token: 0x04002F21 RID: 12065
		private BarColumnValuePositionDataLabel e;

		// Token: 0x04002F22 RID: 12066
		private string f = "#.##";
	}
}
