using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x02000897 RID: 2199
	public abstract class Stacked100PercentLineSeriesElement : Stacked100PercentSeriesElement
	{
		// Token: 0x0600599B RID: 22939 RVA: 0x0033B2FC File Offset: 0x0033A2FC
		internal Stacked100PercentLineSeriesElement(string A_0, Color A_1, LineStyle A_2, float A_3, Marker A_4, Legend A_5) : base(A_0, A_1, A_5)
		{
			this.e = A_2;
			this.d = A_3;
			this.f = A_4;
		}

		// Token: 0x0600599C RID: 22940 RVA: 0x0033B330 File Offset: 0x0033A330
		internal static float b()
		{
			return Stacked100PercentLineSeriesElement.b;
		}

		// Token: 0x0600599D RID: 22941 RVA: 0x0033B348 File Offset: 0x0033A348
		internal static LineStyle a()
		{
			return Stacked100PercentLineSeriesElement.c;
		}

		// Token: 0x1700090D RID: 2317
		// (get) Token: 0x0600599E RID: 22942 RVA: 0x0033B360 File Offset: 0x0033A360
		// (set) Token: 0x0600599F RID: 22943 RVA: 0x0033B378 File Offset: 0x0033A378
		public Marker Marker
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

		// Token: 0x1700090E RID: 2318
		// (get) Token: 0x060059A0 RID: 22944 RVA: 0x0033B384 File Offset: 0x0033A384
		// (set) Token: 0x060059A1 RID: 22945 RVA: 0x0033B39C File Offset: 0x0033A39C
		public PercentageDataLabel DataLabel
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

		// Token: 0x1700090F RID: 2319
		// (get) Token: 0x060059A2 RID: 22946 RVA: 0x0033B3A8 File Offset: 0x0033A3A8
		// (set) Token: 0x060059A3 RID: 22947 RVA: 0x0033B3C0 File Offset: 0x0033A3C0
		public LineCap LineCap
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

		// Token: 0x17000910 RID: 2320
		// (get) Token: 0x060059A4 RID: 22948 RVA: 0x0033B3CC File Offset: 0x0033A3CC
		// (set) Token: 0x060059A5 RID: 22949 RVA: 0x0033B3E4 File Offset: 0x0033A3E4
		public LineJoin LineJoin
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

		// Token: 0x17000911 RID: 2321
		// (get) Token: 0x060059A6 RID: 22950 RVA: 0x0033B3F0 File Offset: 0x0033A3F0
		// (set) Token: 0x060059A7 RID: 22951 RVA: 0x0033B408 File Offset: 0x0033A408
		public float Width
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

		// Token: 0x17000912 RID: 2322
		// (get) Token: 0x060059A8 RID: 22952 RVA: 0x0033B414 File Offset: 0x0033A414
		// (set) Token: 0x060059A9 RID: 22953 RVA: 0x0033B42C File Offset: 0x0033A42C
		public LineStyle LineStyle
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

		// Token: 0x060059AA RID: 22954 RVA: 0x0033B438 File Offset: 0x0033A438
		internal Stacked100PercentLineValueList c()
		{
			return this.a;
		}

		// Token: 0x060059AB RID: 22955 RVA: 0x0033B450 File Offset: 0x0033A450
		internal void a(Stacked100PercentLineValueList A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060059AC RID: 22956 RVA: 0x0033B45A File Offset: 0x0033A45A
		internal void a(PageWriter A_0, float[] A_1)
		{
			this.a.a(A_0, A_1);
		}

		// Token: 0x060059AD RID: 22957 RVA: 0x0033B46B File Offset: 0x0033A46B
		internal void a(PageWriter A_0, float[] A_1, int A_2, ArrayList A_3)
		{
			this.a.a(A_0, A_1, A_2, A_3);
		}

		// Token: 0x04002F4D RID: 12109
		private new Stacked100PercentLineValueList a;

		// Token: 0x04002F4E RID: 12110
		private new static float b = 1f;

		// Token: 0x04002F4F RID: 12111
		private static LineStyle c = LineStyle.Solid;

		// Token: 0x04002F50 RID: 12112
		private float d;

		// Token: 0x04002F51 RID: 12113
		private LineStyle e;

		// Token: 0x04002F52 RID: 12114
		private Marker f;

		// Token: 0x04002F53 RID: 12115
		private LineCap g = LineCap.Butt;

		// Token: 0x04002F54 RID: 12116
		private LineJoin h = LineJoin.Miter;

		// Token: 0x04002F55 RID: 12117
		private PercentageDataLabel i;
	}
}
