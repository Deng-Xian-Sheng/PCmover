using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x02000893 RID: 2195
	public abstract class Stacked100PercentColumnSeriesElement : Stacked100PercentSeriesElement
	{
		// Token: 0x0600596F RID: 22895 RVA: 0x0033A838 File Offset: 0x00339838
		internal Stacked100PercentColumnSeriesElement(string A_0, Color A_1, float A_2, Color A_3, Legend A_4) : base(A_0, A_1, A_4)
		{
			this.b = A_2;
			this.c = A_3;
		}

		// Token: 0x17000906 RID: 2310
		// (get) Token: 0x06005970 RID: 22896 RVA: 0x0033A864 File Offset: 0x00339864
		// (set) Token: 0x06005971 RID: 22897 RVA: 0x0033A87C File Offset: 0x0033987C
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

		// Token: 0x17000907 RID: 2311
		// (get) Token: 0x06005972 RID: 22898 RVA: 0x0033A888 File Offset: 0x00339888
		// (set) Token: 0x06005973 RID: 22899 RVA: 0x0033A8A0 File Offset: 0x003398A0
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

		// Token: 0x17000908 RID: 2312
		// (get) Token: 0x06005974 RID: 22900 RVA: 0x0033A8AC File Offset: 0x003398AC
		// (set) Token: 0x06005975 RID: 22901 RVA: 0x0033A8C4 File Offset: 0x003398C4
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

		// Token: 0x06005976 RID: 22902 RVA: 0x0033A8D0 File Offset: 0x003398D0
		internal Stacked100PercentColumnValueList a()
		{
			return this.a;
		}

		// Token: 0x06005977 RID: 22903 RVA: 0x0033A8E8 File Offset: 0x003398E8
		internal void a(Stacked100PercentColumnValueList A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06005978 RID: 22904 RVA: 0x0033A8F2 File Offset: 0x003398F2
		internal void a(PageWriter A_0)
		{
			this.a.a(A_0);
		}

		// Token: 0x06005979 RID: 22905 RVA: 0x0033A902 File Offset: 0x00339902
		internal void a(PageWriter A_0, Stacked100PercentColumnSeriesElement[] A_1, int A_2, int A_3, int A_4, float[] A_5)
		{
			this.a.a(A_0, A_1, A_2, A_3, A_4, A_5);
		}

		// Token: 0x04002F45 RID: 12101
		private new Stacked100PercentColumnValueList a;

		// Token: 0x04002F46 RID: 12102
		private new float b = 1f;

		// Token: 0x04002F47 RID: 12103
		private Color c;

		// Token: 0x04002F48 RID: 12104
		private BarColumnPercentageDataLabel d;
	}
}
