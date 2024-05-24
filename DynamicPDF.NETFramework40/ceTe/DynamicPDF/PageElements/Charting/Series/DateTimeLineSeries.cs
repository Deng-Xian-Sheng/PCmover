using System;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x0200089D RID: 2205
	public class DateTimeLineSeries : LineSeries
	{
		// Token: 0x06005A02 RID: 23042 RVA: 0x0033BE80 File Offset: 0x0033AE80
		public DateTimeLineSeries(string name) : this(name, null, null, LineSeries.b(), LineSeries.a(), null, null, null)
		{
		}

		// Token: 0x06005A03 RID: 23043 RVA: 0x0033BEA8 File Offset: 0x0033AEA8
		public DateTimeLineSeries(string name, DateTimeXAxis xAxis, NumericYAxis yAxis) : this(name, xAxis, yAxis, LineSeries.b(), LineSeries.a(), null, null, null)
		{
		}

		// Token: 0x06005A04 RID: 23044 RVA: 0x0033BED0 File Offset: 0x0033AED0
		public DateTimeLineSeries(string name, DateTimeXAxis xAxis, NumericYAxis yAxis, Color color) : this(name, xAxis, yAxis, LineSeries.b(), LineSeries.a(), color, null, null)
		{
		}

		// Token: 0x06005A05 RID: 23045 RVA: 0x0033BEF8 File Offset: 0x0033AEF8
		public DateTimeLineSeries(string name, DateTimeXAxis xAxis, NumericYAxis yAxis, Color color, float lineWidth) : this(name, xAxis, yAxis, lineWidth, LineSeries.a(), color, null, null)
		{
		}

		// Token: 0x06005A06 RID: 23046 RVA: 0x0033BF1C File Offset: 0x0033AF1C
		public DateTimeLineSeries(string name, DateTimeXAxis xAxis, NumericYAxis yAxis, Color color, float lineWidth, LineStyle style) : this(name, xAxis, yAxis, lineWidth, style, color, null, null)
		{
		}

		// Token: 0x06005A07 RID: 23047 RVA: 0x0033BF40 File Offset: 0x0033AF40
		public DateTimeLineSeries(string name, DateTimeXAxis xAxis, NumericYAxis yAxis, Color color, float lineWidth, LineStyle style, Legend legend) : this(name, xAxis, yAxis, lineWidth, style, color, null, legend)
		{
		}

		// Token: 0x06005A08 RID: 23048 RVA: 0x0033BF64 File Offset: 0x0033AF64
		public DateTimeLineSeries(string name, DateTimeXAxis xAxis, NumericYAxis yAxis, Color color, float lineWidth, LineStyle style, Marker marker) : this(name, xAxis, yAxis, lineWidth, style, color, marker, null)
		{
		}

		// Token: 0x06005A09 RID: 23049 RVA: 0x0033BF88 File Offset: 0x0033AF88
		public DateTimeLineSeries(string name, DateTimeXAxis xAxis, NumericYAxis yAxis, float lineWidth, LineStyle style, Color color, Marker marker, Legend legend) : base(name, xAxis, yAxis, color, style, lineWidth, marker, legend)
		{
			base.a(new DateTimeLineValueList(this));
		}

		// Token: 0x17000924 RID: 2340
		// (get) Token: 0x06005A0A RID: 23050 RVA: 0x0033BFD0 File Offset: 0x0033AFD0
		public DateTimeXAxis XAxis
		{
			get
			{
				return (DateTimeXAxis)base.m();
			}
		}

		// Token: 0x17000925 RID: 2341
		// (get) Token: 0x06005A0B RID: 23051 RVA: 0x0033BFF0 File Offset: 0x0033AFF0
		public NumericYAxis YAxis
		{
			get
			{
				return (NumericYAxis)base.n();
			}
		}

		// Token: 0x06005A0C RID: 23052 RVA: 0x0033C010 File Offset: 0x0033B010
		internal override DateTime ih()
		{
			return this.b;
		}

		// Token: 0x06005A0D RID: 23053 RVA: 0x0033C028 File Offset: 0x0033B028
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

		// Token: 0x06005A0E RID: 23054 RVA: 0x0033C074 File Offset: 0x0033B074
		internal override DateTime ij()
		{
			return this.a;
		}

		// Token: 0x06005A0F RID: 23055 RVA: 0x0033C08C File Offset: 0x0033B08C
		internal override void ik(DateTime A_0)
		{
			if (this.a == DateTime.MinValue)
			{
				this.a = A_0;
			}
			else if (DateTime.Compare(A_0, this.a) < 0)
			{
				this.a = A_0;
			}
		}

		// Token: 0x17000926 RID: 2342
		// (get) Token: 0x06005A10 RID: 23056 RVA: 0x0033C0D8 File Offset: 0x0033B0D8
		public DateTimeLineValueList Values
		{
			get
			{
				return (DateTimeLineValueList)base.c();
			}
		}

		// Token: 0x04002F68 RID: 12136
		private new DateTime a = DateTime.MinValue;

		// Token: 0x04002F69 RID: 12137
		private new DateTime b = DateTime.MinValue;
	}
}
