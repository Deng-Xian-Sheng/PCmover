using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008C9 RID: 2249
	public class XYScatterSeries : LegendXYSeries
	{
		// Token: 0x06005C4F RID: 23631 RVA: 0x00345978 File Offset: 0x00344978
		public XYScatterSeries(string name) : this(name, null, null, null, XYScatterSeries.c, XYScatterSeries.d, null, null, false)
		{
		}

		// Token: 0x06005C50 RID: 23632 RVA: 0x003459A0 File Offset: 0x003449A0
		public XYScatterSeries(string name, bool lineDisplay) : this(name, null, null, null, XYScatterSeries.c, XYScatterSeries.d, null, null, lineDisplay)
		{
		}

		// Token: 0x06005C51 RID: 23633 RVA: 0x003459C8 File Offset: 0x003449C8
		public XYScatterSeries(string name, Marker marker) : this(name, null, null, null, XYScatterSeries.c, XYScatterSeries.d, null, marker, false)
		{
		}

		// Token: 0x06005C52 RID: 23634 RVA: 0x003459F0 File Offset: 0x003449F0
		public XYScatterSeries(string name, NumericXAxis xAxis, NumericYAxis yAxis) : this(name, xAxis, yAxis, null, XYScatterSeries.c, XYScatterSeries.d, null, null, false)
		{
		}

		// Token: 0x06005C53 RID: 23635 RVA: 0x00345A18 File Offset: 0x00344A18
		public XYScatterSeries(string name, NumericXAxis xAxis, NumericYAxis yAxis, Color lineColor) : this(name, xAxis, yAxis, lineColor, XYScatterSeries.c, XYScatterSeries.d, null, null, false)
		{
		}

		// Token: 0x06005C54 RID: 23636 RVA: 0x00345A40 File Offset: 0x00344A40
		public XYScatterSeries(string name, NumericXAxis xAxis, NumericYAxis yAxis, Color lineColor, float lineWidth) : this(name, xAxis, yAxis, lineColor, lineWidth, XYScatterSeries.d, null, null, false)
		{
		}

		// Token: 0x06005C55 RID: 23637 RVA: 0x00345A68 File Offset: 0x00344A68
		public XYScatterSeries(string name, NumericXAxis xAxis, NumericYAxis yAxis, Color lineColor, float lineWidth, LineStyle lineStyle) : this(name, xAxis, yAxis, lineColor, lineWidth, lineStyle, null, null, false)
		{
		}

		// Token: 0x06005C56 RID: 23638 RVA: 0x00345A8C File Offset: 0x00344A8C
		public XYScatterSeries(string name, NumericXAxis xAxis, NumericYAxis yAxis, Color lineColor, float lineWidth, LineStyle lineStyle, Marker marker) : this(name, xAxis, yAxis, lineColor, lineWidth, lineStyle, null, marker, false)
		{
		}

		// Token: 0x06005C57 RID: 23639 RVA: 0x00345AB0 File Offset: 0x00344AB0
		public XYScatterSeries(string name, NumericXAxis xAxis, NumericYAxis yAxis, Color lineColor, float lineWidth, LineStyle lineStyle, Legend legend) : this(name, xAxis, yAxis, lineColor, lineWidth, lineStyle, legend, null, false)
		{
		}

		// Token: 0x06005C58 RID: 23640 RVA: 0x00345AD4 File Offset: 0x00344AD4
		public XYScatterSeries(string name, NumericXAxis xAxis, NumericYAxis yAxis, Color lineColor, float lineWidth, LineStyle lineStyle, Legend legend, Marker marker, bool lineDisplay) : base(name, xAxis, yAxis, lineColor)
		{
			base.DrawBehindAxis = false;
			if (legend != null)
			{
				base.Legend = legend;
			}
			this.LineStyle = lineStyle;
			this.e = lineWidth;
			this.j = lineDisplay;
			this.i = marker;
			this.a = new XYScatterValueList(this);
		}

		// Token: 0x1700098F RID: 2447
		// (get) Token: 0x06005C59 RID: 23641 RVA: 0x00345B80 File Offset: 0x00344B80
		// (set) Token: 0x06005C5A RID: 23642 RVA: 0x00345B98 File Offset: 0x00344B98
		public string XValueFormat
		{
			get
			{
				return this.g;
			}
			set
			{
				this.g = value;
			}
		}

		// Token: 0x17000990 RID: 2448
		// (get) Token: 0x06005C5B RID: 23643 RVA: 0x00345BA4 File Offset: 0x00344BA4
		// (set) Token: 0x06005C5C RID: 23644 RVA: 0x00345BBC File Offset: 0x00344BBC
		public string YValueFormat
		{
			get
			{
				return this.h;
			}
			set
			{
				this.h = value;
			}
		}

		// Token: 0x17000991 RID: 2449
		// (get) Token: 0x06005C5D RID: 23645 RVA: 0x00345BC8 File Offset: 0x00344BC8
		// (set) Token: 0x06005C5E RID: 23646 RVA: 0x00345BE0 File Offset: 0x00344BE0
		public XYScatterDataLabel DataLabel
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

		// Token: 0x17000992 RID: 2450
		// (get) Token: 0x06005C5F RID: 23647 RVA: 0x00345BEC File Offset: 0x00344BEC
		// (set) Token: 0x06005C60 RID: 23648 RVA: 0x00345C04 File Offset: 0x00344C04
		public Marker Marker
		{
			get
			{
				return this.i;
			}
			set
			{
				this.i = value;
			}
		}

		// Token: 0x17000993 RID: 2451
		// (get) Token: 0x06005C61 RID: 23649 RVA: 0x00345C10 File Offset: 0x00344C10
		// (set) Token: 0x06005C62 RID: 23650 RVA: 0x00345C28 File Offset: 0x00344C28
		public LineJoin LineJoin
		{
			get
			{
				return this.l;
			}
			set
			{
				this.l = value;
			}
		}

		// Token: 0x17000994 RID: 2452
		// (get) Token: 0x06005C63 RID: 23651 RVA: 0x00345C34 File Offset: 0x00344C34
		// (set) Token: 0x06005C64 RID: 23652 RVA: 0x00345C4C File Offset: 0x00344C4C
		public LineCap LineCap
		{
			get
			{
				return this.k;
			}
			set
			{
				this.k = value;
			}
		}

		// Token: 0x17000995 RID: 2453
		// (get) Token: 0x06005C65 RID: 23653 RVA: 0x00345C58 File Offset: 0x00344C58
		// (set) Token: 0x06005C66 RID: 23654 RVA: 0x00345C70 File Offset: 0x00344C70
		public bool LineDisplay
		{
			get
			{
				return this.j;
			}
			set
			{
				this.j = value;
			}
		}

		// Token: 0x17000996 RID: 2454
		// (get) Token: 0x06005C67 RID: 23655 RVA: 0x00345C7C File Offset: 0x00344C7C
		// (set) Token: 0x06005C68 RID: 23656 RVA: 0x00345C94 File Offset: 0x00344C94
		public float Width
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

		// Token: 0x17000997 RID: 2455
		// (get) Token: 0x06005C69 RID: 23657 RVA: 0x00345CA0 File Offset: 0x00344CA0
		public XYScatterValueList Values
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x17000998 RID: 2456
		// (get) Token: 0x06005C6A RID: 23658 RVA: 0x00345CB8 File Offset: 0x00344CB8
		// (set) Token: 0x06005C6B RID: 23659 RVA: 0x00345CD0 File Offset: 0x00344CD0
		public LineStyle LineStyle
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

		// Token: 0x17000999 RID: 2457
		// (get) Token: 0x06005C6C RID: 23660 RVA: 0x00345CDC File Offset: 0x00344CDC
		public NumericXAxis XAxis
		{
			get
			{
				return (NumericXAxis)base.m();
			}
		}

		// Token: 0x1700099A RID: 2458
		// (get) Token: 0x06005C6D RID: 23661 RVA: 0x00345CFC File Offset: 0x00344CFC
		public NumericYAxis YAxis
		{
			get
			{
				return (NumericYAxis)base.n();
			}
		}

		// Token: 0x06005C6E RID: 23662 RVA: 0x00345D1C File Offset: 0x00344D1C
		internal override float ig()
		{
			return this.n;
		}

		// Token: 0x06005C6F RID: 23663 RVA: 0x00345D34 File Offset: 0x00344D34
		internal override void iy(float A_0)
		{
			if (A_0 > this.n)
			{
				this.n = A_0;
			}
		}

		// Token: 0x06005C70 RID: 23664 RVA: 0x00345D5C File Offset: 0x00344D5C
		internal override float iz()
		{
			return this.m;
		}

		// Token: 0x06005C71 RID: 23665 RVA: 0x00345D74 File Offset: 0x00344D74
		internal override void i0(float A_0)
		{
			if (A_0 < this.m)
			{
				this.m = A_0;
			}
		}

		// Token: 0x06005C72 RID: 23666 RVA: 0x00345D99 File Offset: 0x00344D99
		internal override void ib(PageWriter A_0)
		{
			this.a.a(A_0);
		}

		// Token: 0x06005C73 RID: 23667 RVA: 0x00345DA9 File Offset: 0x00344DA9
		internal override void ic(PageWriter A_0)
		{
			this.a.a(A_0, this.j);
		}

		// Token: 0x04002FF7 RID: 12279
		private new XYScatterValueList a;

		// Token: 0x04002FF8 RID: 12280
		private new XYScatterDataLabel b = null;

		// Token: 0x04002FF9 RID: 12281
		private static float c = 1f;

		// Token: 0x04002FFA RID: 12282
		private static LineStyle d = LineStyle.Solid;

		// Token: 0x04002FFB RID: 12283
		private float e;

		// Token: 0x04002FFC RID: 12284
		private LineStyle f;

		// Token: 0x04002FFD RID: 12285
		private string g = "#.##";

		// Token: 0x04002FFE RID: 12286
		private string h = "#.##";

		// Token: 0x04002FFF RID: 12287
		private Marker i;

		// Token: 0x04003000 RID: 12288
		private bool j = false;

		// Token: 0x04003001 RID: 12289
		private LineCap k = LineCap.Butt;

		// Token: 0x04003002 RID: 12290
		private LineJoin l = LineJoin.Miter;

		// Token: 0x04003003 RID: 12291
		private float m = 2.1474836E+09f;

		// Token: 0x04003004 RID: 12292
		private float n = -2.1474836E+09f;
	}
}
