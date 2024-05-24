using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008AD RID: 2221
	public abstract class StackedLineSeriesElement : StackedSeriesElement
	{
		// Token: 0x06005AA1 RID: 23201 RVA: 0x0033DF28 File Offset: 0x0033CF28
		internal StackedLineSeriesElement(string A_0, Color A_1, LineStyle A_2, float A_3, Marker A_4, Legend A_5) : base(A_0, A_1, A_5)
		{
			this.e = A_2;
			this.d = A_3;
			this.f = A_4;
		}

		// Token: 0x06005AA2 RID: 23202 RVA: 0x0033DF5C File Offset: 0x0033CF5C
		internal static float b()
		{
			return StackedLineSeriesElement.b;
		}

		// Token: 0x06005AA3 RID: 23203 RVA: 0x0033DF74 File Offset: 0x0033CF74
		internal static LineStyle a()
		{
			return StackedLineSeriesElement.c;
		}

		// Token: 0x1700093E RID: 2366
		// (get) Token: 0x06005AA4 RID: 23204 RVA: 0x0033DF8C File Offset: 0x0033CF8C
		// (set) Token: 0x06005AA5 RID: 23205 RVA: 0x0033DFA4 File Offset: 0x0033CFA4
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

		// Token: 0x1700093F RID: 2367
		// (get) Token: 0x06005AA6 RID: 23206 RVA: 0x0033DFB0 File Offset: 0x0033CFB0
		// (set) Token: 0x06005AA7 RID: 23207 RVA: 0x0033DFC8 File Offset: 0x0033CFC8
		public ValuePositionDataLabel DataLabel
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

		// Token: 0x17000940 RID: 2368
		// (get) Token: 0x06005AA8 RID: 23208 RVA: 0x0033DFD4 File Offset: 0x0033CFD4
		// (set) Token: 0x06005AA9 RID: 23209 RVA: 0x0033DFEC File Offset: 0x0033CFEC
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

		// Token: 0x17000941 RID: 2369
		// (get) Token: 0x06005AAA RID: 23210 RVA: 0x0033DFF8 File Offset: 0x0033CFF8
		// (set) Token: 0x06005AAB RID: 23211 RVA: 0x0033E010 File Offset: 0x0033D010
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

		// Token: 0x17000942 RID: 2370
		// (get) Token: 0x06005AAC RID: 23212 RVA: 0x0033E01C File Offset: 0x0033D01C
		// (set) Token: 0x06005AAD RID: 23213 RVA: 0x0033E034 File Offset: 0x0033D034
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

		// Token: 0x17000943 RID: 2371
		// (get) Token: 0x06005AAE RID: 23214 RVA: 0x0033E040 File Offset: 0x0033D040
		// (set) Token: 0x06005AAF RID: 23215 RVA: 0x0033E058 File Offset: 0x0033D058
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

		// Token: 0x06005AB0 RID: 23216 RVA: 0x0033E064 File Offset: 0x0033D064
		internal StackedLineValueList c()
		{
			return this.a;
		}

		// Token: 0x06005AB1 RID: 23217 RVA: 0x0033E07C File Offset: 0x0033D07C
		internal void a(StackedLineValueList A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06005AB2 RID: 23218 RVA: 0x0033E086 File Offset: 0x0033D086
		internal void a(PageWriter A_0)
		{
			this.a.a(A_0);
		}

		// Token: 0x06005AB3 RID: 23219 RVA: 0x0033E096 File Offset: 0x0033D096
		internal void a(PageWriter A_0, int A_1, ArrayList A_2)
		{
			this.a.a(A_0, A_1, A_2);
		}

		// Token: 0x04002F85 RID: 12165
		private new StackedLineValueList a;

		// Token: 0x04002F86 RID: 12166
		private new static float b = 1f;

		// Token: 0x04002F87 RID: 12167
		private static LineStyle c = LineStyle.Solid;

		// Token: 0x04002F88 RID: 12168
		private float d;

		// Token: 0x04002F89 RID: 12169
		private LineStyle e;

		// Token: 0x04002F8A RID: 12170
		private Marker f;

		// Token: 0x04002F8B RID: 12171
		private LineCap g = LineCap.Butt;

		// Token: 0x04002F8C RID: 12172
		private LineJoin h = LineJoin.Miter;

		// Token: 0x04002F8D RID: 12173
		private ValuePositionDataLabel i;
	}
}
