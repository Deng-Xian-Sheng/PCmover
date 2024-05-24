using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x02000881 RID: 2177
	public abstract class AreaSeries : LegendXYSeries
	{
		// Token: 0x060058AE RID: 22702 RVA: 0x003376F4 File Offset: 0x003366F4
		internal AreaSeries(string A_0, XAxis A_1, NumericYAxis A_2, Color A_3, Marker A_4, Legend A_5) : base(A_0, A_1, A_2, A_3)
		{
			base.DrawBehindAxis = true;
			if (A_5 != null)
			{
				base.Legend = A_5;
			}
			this.c = A_4;
		}

		// Token: 0x170008E5 RID: 2277
		// (get) Token: 0x060058AF RID: 22703 RVA: 0x0033773C File Offset: 0x0033673C
		// (set) Token: 0x060058B0 RID: 22704 RVA: 0x00337754 File Offset: 0x00336754
		public string ValueFormat
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

		// Token: 0x170008E6 RID: 2278
		// (get) Token: 0x060058B1 RID: 22705 RVA: 0x00337760 File Offset: 0x00336760
		// (set) Token: 0x060058B2 RID: 22706 RVA: 0x00337778 File Offset: 0x00336778
		public ValuePositionDataLabel DataLabel
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

		// Token: 0x170008E7 RID: 2279
		// (get) Token: 0x060058B3 RID: 22707 RVA: 0x00337784 File Offset: 0x00336784
		// (set) Token: 0x060058B4 RID: 22708 RVA: 0x0033779C File Offset: 0x0033679C
		public Marker Marker
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

		// Token: 0x060058B5 RID: 22709 RVA: 0x003377A8 File Offset: 0x003367A8
		internal AreaValueList a()
		{
			return this.a;
		}

		// Token: 0x060058B6 RID: 22710 RVA: 0x003377C0 File Offset: 0x003367C0
		internal void a(AreaValueList A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060058B7 RID: 22711 RVA: 0x003377CA File Offset: 0x003367CA
		internal override void ib(PageWriter A_0)
		{
			this.a.a(A_0);
		}

		// Token: 0x060058B8 RID: 22712 RVA: 0x003377DC File Offset: 0x003367DC
		internal override void ic(PageWriter A_0)
		{
			if (this.a.Count > 0)
			{
				this.a.b();
				this.a.d();
				this.a.b(A_0);
			}
		}

		// Token: 0x04002F19 RID: 12057
		private new AreaValueList a;

		// Token: 0x04002F1A RID: 12058
		private new ValuePositionDataLabel b;

		// Token: 0x04002F1B RID: 12059
		private Marker c;

		// Token: 0x04002F1C RID: 12060
		private string d = "#.##";
	}
}
