using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x0200089C RID: 2204
	public abstract class LineSeries : LegendXYSeries
	{
		// Token: 0x060059EC RID: 23020 RVA: 0x0033BC58 File Offset: 0x0033AC58
		internal LineSeries(string A_0, XAxis A_1, NumericYAxis A_2, Color A_3, LineStyle A_4, float A_5, Marker A_6, Legend A_7) : base(A_0, A_1, A_2, A_3)
		{
			base.DrawBehindAxis = false;
			if (A_7 != null)
			{
				base.Legend = A_7;
			}
			this.f = A_4;
			this.e = A_5;
			this.h = A_6;
		}

		// Token: 0x060059ED RID: 23021 RVA: 0x0033BCC0 File Offset: 0x0033ACC0
		internal static float b()
		{
			return LineSeries.c;
		}

		// Token: 0x060059EE RID: 23022 RVA: 0x0033BCD8 File Offset: 0x0033ACD8
		internal static LineStyle a()
		{
			return LineSeries.d;
		}

		// Token: 0x1700091D RID: 2333
		// (get) Token: 0x060059EF RID: 23023 RVA: 0x0033BCF0 File Offset: 0x0033ACF0
		// (set) Token: 0x060059F0 RID: 23024 RVA: 0x0033BD08 File Offset: 0x0033AD08
		public string ValueFormat
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

		// Token: 0x1700091E RID: 2334
		// (get) Token: 0x060059F1 RID: 23025 RVA: 0x0033BD14 File Offset: 0x0033AD14
		// (set) Token: 0x060059F2 RID: 23026 RVA: 0x0033BD2C File Offset: 0x0033AD2C
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

		// Token: 0x1700091F RID: 2335
		// (get) Token: 0x060059F3 RID: 23027 RVA: 0x0033BD38 File Offset: 0x0033AD38
		// (set) Token: 0x060059F4 RID: 23028 RVA: 0x0033BD50 File Offset: 0x0033AD50
		public Marker Marker
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

		// Token: 0x17000920 RID: 2336
		// (get) Token: 0x060059F5 RID: 23029 RVA: 0x0033BD5C File Offset: 0x0033AD5C
		// (set) Token: 0x060059F6 RID: 23030 RVA: 0x0033BD74 File Offset: 0x0033AD74
		public LineCap LineCap
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

		// Token: 0x17000921 RID: 2337
		// (get) Token: 0x060059F7 RID: 23031 RVA: 0x0033BD80 File Offset: 0x0033AD80
		// (set) Token: 0x060059F8 RID: 23032 RVA: 0x0033BD98 File Offset: 0x0033AD98
		public LineJoin LineJoin
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

		// Token: 0x17000922 RID: 2338
		// (get) Token: 0x060059F9 RID: 23033 RVA: 0x0033BDA4 File Offset: 0x0033ADA4
		// (set) Token: 0x060059FA RID: 23034 RVA: 0x0033BDBC File Offset: 0x0033ADBC
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

		// Token: 0x17000923 RID: 2339
		// (get) Token: 0x060059FB RID: 23035 RVA: 0x0033BDC8 File Offset: 0x0033ADC8
		// (set) Token: 0x060059FC RID: 23036 RVA: 0x0033BDE0 File Offset: 0x0033ADE0
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

		// Token: 0x060059FD RID: 23037 RVA: 0x0033BDEC File Offset: 0x0033ADEC
		internal LineValueList c()
		{
			return this.a;
		}

		// Token: 0x060059FE RID: 23038 RVA: 0x0033BE04 File Offset: 0x0033AE04
		internal void a(LineValueList A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060059FF RID: 23039 RVA: 0x0033BE0E File Offset: 0x0033AE0E
		internal override void ib(PageWriter A_0)
		{
			this.a.a(A_0);
		}

		// Token: 0x06005A00 RID: 23040 RVA: 0x0033BE20 File Offset: 0x0033AE20
		internal override void ic(PageWriter A_0)
		{
			if (this.a.Count > 0)
			{
				this.a.d();
				this.a.b();
				this.a.b(A_0);
			}
		}

		// Token: 0x04002F5E RID: 12126
		private new LineValueList a;

		// Token: 0x04002F5F RID: 12127
		private new ValuePositionDataLabel b;

		// Token: 0x04002F60 RID: 12128
		private static float c = 1f;

		// Token: 0x04002F61 RID: 12129
		private static LineStyle d = LineStyle.Solid;

		// Token: 0x04002F62 RID: 12130
		private float e;

		// Token: 0x04002F63 RID: 12131
		private LineStyle f;

		// Token: 0x04002F64 RID: 12132
		private string g = "#.##";

		// Token: 0x04002F65 RID: 12133
		private Marker h;

		// Token: 0x04002F66 RID: 12134
		private LineCap i = LineCap.Butt;

		// Token: 0x04002F67 RID: 12135
		private LineJoin j = LineJoin.Miter;
	}
}
