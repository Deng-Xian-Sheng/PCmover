using System;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008B2 RID: 2226
	public class Indexed100PercentStackedBarSeriesElement : Stacked100PercentBarSeriesElement
	{
		// Token: 0x06005AE3 RID: 23267 RVA: 0x0033E65D File Offset: 0x0033D65D
		public Indexed100PercentStackedBarSeriesElement(string name) : this(name, null, 0f, null, null)
		{
		}

		// Token: 0x06005AE4 RID: 23268 RVA: 0x0033E671 File Offset: 0x0033D671
		public Indexed100PercentStackedBarSeriesElement(string name, Color color) : this(name, color, 0f, null, null)
		{
		}

		// Token: 0x06005AE5 RID: 23269 RVA: 0x0033E685 File Offset: 0x0033D685
		public Indexed100PercentStackedBarSeriesElement(string name, Color color, Legend legend) : this(name, color, 0f, null, legend)
		{
		}

		// Token: 0x06005AE6 RID: 23270 RVA: 0x0033E699 File Offset: 0x0033D699
		public Indexed100PercentStackedBarSeriesElement(string name, Color color, float borderWidth) : this(name, color, borderWidth, null, null)
		{
		}

		// Token: 0x06005AE7 RID: 23271 RVA: 0x0033E6A9 File Offset: 0x0033D6A9
		public Indexed100PercentStackedBarSeriesElement(string name, float borderWidth, Color borderColor) : this(name, null, borderWidth, borderColor, null)
		{
		}

		// Token: 0x06005AE8 RID: 23272 RVA: 0x0033E6B9 File Offset: 0x0033D6B9
		public Indexed100PercentStackedBarSeriesElement(string name, Color color, float borderWidth, Color borderColor) : this(name, color, borderWidth, borderColor, null)
		{
		}

		// Token: 0x06005AE9 RID: 23273 RVA: 0x0033E6CA File Offset: 0x0033D6CA
		public Indexed100PercentStackedBarSeriesElement(string name, Color color, float borderWidth, Color borderColor, Legend legend) : base(name, color, borderWidth, borderColor, legend)
		{
			base.a(new Indexed100PercentStackedBarValueList(this));
		}

		// Token: 0x1700094C RID: 2380
		// (get) Token: 0x06005AEA RID: 23274 RVA: 0x0033E700 File Offset: 0x0033D700
		public Indexed100PercentStackedBarValueList Values
		{
			get
			{
				return (Indexed100PercentStackedBarValueList)base.a();
			}
		}

		// Token: 0x06005AEB RID: 23275 RVA: 0x0033E720 File Offset: 0x0033D720
		internal override float i1()
		{
			return this.b;
		}

		// Token: 0x06005AEC RID: 23276 RVA: 0x0033E738 File Offset: 0x0033D738
		internal override void i2(float A_0)
		{
			if (A_0 > this.b)
			{
				this.b = A_0;
			}
		}

		// Token: 0x06005AED RID: 23277 RVA: 0x0033E760 File Offset: 0x0033D760
		internal override float i3()
		{
			return this.a;
		}

		// Token: 0x06005AEE RID: 23278 RVA: 0x0033E778 File Offset: 0x0033D778
		internal override void i4(float A_0)
		{
			if (A_0 < this.a)
			{
				this.a = A_0;
			}
		}

		// Token: 0x04002F96 RID: 12182
		private new float a = 2.1474836E+09f;

		// Token: 0x04002F97 RID: 12183
		private new float b = -2.1474836E+09f;
	}
}
