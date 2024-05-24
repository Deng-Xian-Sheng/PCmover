using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x0200088F RID: 2191
	public abstract class Stacked100PercentBarSeriesElement : Stacked100PercentSeriesElement
	{
		// Token: 0x06005943 RID: 22851 RVA: 0x00339FA4 File Offset: 0x00338FA4
		internal Stacked100PercentBarSeriesElement(string A_0, Color A_1, float A_2, Color A_3, Legend A_4) : base(A_0, A_1, A_4)
		{
			this.b = A_2;
			this.c = A_3;
		}

		// Token: 0x170008FF RID: 2303
		// (get) Token: 0x06005944 RID: 22852 RVA: 0x00339FD0 File Offset: 0x00338FD0
		// (set) Token: 0x06005945 RID: 22853 RVA: 0x00339FE8 File Offset: 0x00338FE8
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

		// Token: 0x17000900 RID: 2304
		// (get) Token: 0x06005946 RID: 22854 RVA: 0x00339FF4 File Offset: 0x00338FF4
		// (set) Token: 0x06005947 RID: 22855 RVA: 0x0033A00C File Offset: 0x0033900C
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

		// Token: 0x17000901 RID: 2305
		// (get) Token: 0x06005948 RID: 22856 RVA: 0x0033A018 File Offset: 0x00339018
		// (set) Token: 0x06005949 RID: 22857 RVA: 0x0033A030 File Offset: 0x00339030
		public BarColumnPercentageDataLabel DataLabel
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

		// Token: 0x0600594A RID: 22858 RVA: 0x0033A03C File Offset: 0x0033903C
		internal Stacked100PercentBarValueList a()
		{
			return this.a;
		}

		// Token: 0x0600594B RID: 22859 RVA: 0x0033A054 File Offset: 0x00339054
		internal void a(Stacked100PercentBarValueList A_0)
		{
			this.a = A_0;
		}

		// Token: 0x0600594C RID: 22860 RVA: 0x0033A05E File Offset: 0x0033905E
		internal void a(PageWriter A_0)
		{
			this.a.a(A_0);
		}

		// Token: 0x0600594D RID: 22861 RVA: 0x0033A06E File Offset: 0x0033906E
		internal void a(PageWriter A_0, Stacked100PercentBarSeriesElement[] A_1, int A_2, int A_3, int A_4, float[] A_5)
		{
			this.a.a(A_0, A_1, A_2, A_3, A_4, A_5);
		}

		// Token: 0x04002F3C RID: 12092
		private new Stacked100PercentBarValueList a;

		// Token: 0x04002F3D RID: 12093
		private new float b = 1f;

		// Token: 0x04002F3E RID: 12094
		private Color c;

		// Token: 0x04002F3F RID: 12095
		private BarColumnPercentageDataLabel d;
	}
}
