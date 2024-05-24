using System;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x02000899 RID: 2201
	public class DateTimeAreaSeries : AreaSeries
	{
		// Token: 0x060059BB RID: 22971 RVA: 0x0033B629 File Offset: 0x0033A629
		public DateTimeAreaSeries(string name) : this(name, null, null, null, null, null)
		{
		}

		// Token: 0x060059BC RID: 22972 RVA: 0x0033B63A File Offset: 0x0033A63A
		public DateTimeAreaSeries(string name, DateTimeXAxis xAxis, NumericYAxis yAxis) : this(name, xAxis, yAxis, null, null, null)
		{
		}

		// Token: 0x060059BD RID: 22973 RVA: 0x0033B64B File Offset: 0x0033A64B
		public DateTimeAreaSeries(string name, DateTimeXAxis xAxis, NumericYAxis yAxis, Color color) : this(name, xAxis, yAxis, color, null, null)
		{
		}

		// Token: 0x060059BE RID: 22974 RVA: 0x0033B65D File Offset: 0x0033A65D
		public DateTimeAreaSeries(string name, DateTimeXAxis xAxis, NumericYAxis yAxis, Color color, Legend legend) : this(name, xAxis, yAxis, color, null, legend)
		{
		}

		// Token: 0x060059BF RID: 22975 RVA: 0x0033B670 File Offset: 0x0033A670
		public DateTimeAreaSeries(string name, DateTimeXAxis xAxis, NumericYAxis yAxis, Color color, Marker marker) : this(name, xAxis, yAxis, color, marker, null)
		{
		}

		// Token: 0x060059C0 RID: 22976 RVA: 0x0033B683 File Offset: 0x0033A683
		public DateTimeAreaSeries(string name, DateTimeXAxis xAxis, NumericYAxis yAxis, Color color, Marker marker, Legend legend) : base(name, xAxis, yAxis, color, marker, legend)
		{
			base.a(new DateTimeAreaValueList(this));
		}

		// Token: 0x17000914 RID: 2324
		// (get) Token: 0x060059C1 RID: 22977 RVA: 0x0033B6BC File Offset: 0x0033A6BC
		public DateTimeXAxis XAxis
		{
			get
			{
				return (DateTimeXAxis)base.m();
			}
		}

		// Token: 0x17000915 RID: 2325
		// (get) Token: 0x060059C2 RID: 22978 RVA: 0x0033B6DC File Offset: 0x0033A6DC
		public NumericYAxis YAxis
		{
			get
			{
				return (NumericYAxis)base.n();
			}
		}

		// Token: 0x060059C3 RID: 22979 RVA: 0x0033B6FC File Offset: 0x0033A6FC
		internal override DateTime ih()
		{
			return this.b;
		}

		// Token: 0x060059C4 RID: 22980 RVA: 0x0033B714 File Offset: 0x0033A714
		internal override void ii(DateTime A_0)
		{
			if (this.b == DateTime.MinValue)
			{
				this.b = A_0;
			}
			else if (DateTime.Compare(A_0, this.b) > 0)
			{
				this.b = A_0;
			}
		}

		// Token: 0x060059C5 RID: 22981 RVA: 0x0033B760 File Offset: 0x0033A760
		internal override DateTime ij()
		{
			return this.a;
		}

		// Token: 0x060059C6 RID: 22982 RVA: 0x0033B778 File Offset: 0x0033A778
		internal override void ik(DateTime A_0)
		{
			if (this.a == DateTime.MinValue)
			{
				this.a = A_0;
			}
			else if (A_0.CompareTo(this.a) < 0)
			{
				this.a = A_0;
			}
		}

		// Token: 0x17000916 RID: 2326
		// (get) Token: 0x060059C7 RID: 22983 RVA: 0x0033B7C4 File Offset: 0x0033A7C4
		public DateTimeAreaValueList Values
		{
			get
			{
				return (DateTimeAreaValueList)base.a();
			}
		}

		// Token: 0x04002F58 RID: 12120
		private new DateTime a = DateTime.MinValue;

		// Token: 0x04002F59 RID: 12121
		private new DateTime b = DateTime.MinValue;
	}
}
