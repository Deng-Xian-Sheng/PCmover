using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x02000885 RID: 2181
	public abstract class ColumnSeries : LegendXYSeries
	{
		// Token: 0x060058E1 RID: 22753 RVA: 0x00338450 File Offset: 0x00337450
		internal ColumnSeries(string A_0, XAxis A_1, NumericYAxis A_2, Color A_3, float A_4, Color A_5, Legend A_6) : base(A_0, A_1, A_2, A_3)
		{
			base.DrawBehindAxis = true;
			if (A_6 != null)
			{
				base.Legend = A_6;
			}
			this.b = A_4;
			this.c = A_5;
		}

		// Token: 0x170008F0 RID: 2288
		// (get) Token: 0x060058E2 RID: 22754 RVA: 0x003384AC File Offset: 0x003374AC
		// (set) Token: 0x060058E3 RID: 22755 RVA: 0x003384C4 File Offset: 0x003374C4
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

		// Token: 0x170008F1 RID: 2289
		// (get) Token: 0x060058E4 RID: 22756 RVA: 0x003384D0 File Offset: 0x003374D0
		// (set) Token: 0x060058E5 RID: 22757 RVA: 0x003384E8 File Offset: 0x003374E8
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

		// Token: 0x170008F2 RID: 2290
		// (get) Token: 0x060058E6 RID: 22758 RVA: 0x003384F4 File Offset: 0x003374F4
		// (set) Token: 0x060058E7 RID: 22759 RVA: 0x0033850C File Offset: 0x0033750C
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

		// Token: 0x170008F3 RID: 2291
		// (get) Token: 0x060058E8 RID: 22760 RVA: 0x00338518 File Offset: 0x00337518
		// (set) Token: 0x060058E9 RID: 22761 RVA: 0x00338530 File Offset: 0x00337530
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

		// Token: 0x060058EA RID: 22762 RVA: 0x0033853C File Offset: 0x0033753C
		internal ColumnValueList a()
		{
			return this.a;
		}

		// Token: 0x060058EB RID: 22763 RVA: 0x00338554 File Offset: 0x00337554
		internal void a(ColumnValueList A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060058EC RID: 22764 RVA: 0x0033855E File Offset: 0x0033755E
		internal void a(int A_0)
		{
			this.d = A_0;
		}

		// Token: 0x060058ED RID: 22765 RVA: 0x00338568 File Offset: 0x00337568
		internal override void ic(PageWriter A_0)
		{
			this.a.b();
			int a_;
			if (this is DateTimeColumnSeries)
			{
				a_ = base.PlotArea.Series.c();
			}
			else
			{
				a_ = base.PlotArea.Series.b();
			}
			this.a.a(A_0, this.d, a_);
		}

		// Token: 0x060058EE RID: 22766 RVA: 0x003385CC File Offset: 0x003375CC
		internal override void ib(PageWriter A_0)
		{
			this.a.b(A_0);
		}

		// Token: 0x04002F29 RID: 12073
		private new ColumnValueList a;

		// Token: 0x04002F2A RID: 12074
		private new float b = 1f;

		// Token: 0x04002F2B RID: 12075
		private Color c;

		// Token: 0x04002F2C RID: 12076
		private int d;

		// Token: 0x04002F2D RID: 12077
		private BarColumnValuePositionDataLabel e;

		// Token: 0x04002F2E RID: 12078
		private string f = "#.##";
	}
}
