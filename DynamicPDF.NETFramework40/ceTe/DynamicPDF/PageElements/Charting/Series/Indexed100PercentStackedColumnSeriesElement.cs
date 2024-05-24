using System;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008B4 RID: 2228
	public class Indexed100PercentStackedColumnSeriesElement : Stacked100PercentColumnSeriesElement
	{
		// Token: 0x06005AFB RID: 23291 RVA: 0x0033E919 File Offset: 0x0033D919
		public Indexed100PercentStackedColumnSeriesElement(string name) : this(name, null, 0f, null, null)
		{
		}

		// Token: 0x06005AFC RID: 23292 RVA: 0x0033E92D File Offset: 0x0033D92D
		public Indexed100PercentStackedColumnSeriesElement(string name, Color color) : this(name, color, 0f, null, null)
		{
		}

		// Token: 0x06005AFD RID: 23293 RVA: 0x0033E941 File Offset: 0x0033D941
		public Indexed100PercentStackedColumnSeriesElement(string name, Color color, Legend legend) : this(name, color, 0f, null, legend)
		{
		}

		// Token: 0x06005AFE RID: 23294 RVA: 0x0033E955 File Offset: 0x0033D955
		public Indexed100PercentStackedColumnSeriesElement(string name, Color color, float borderWidth) : this(name, color, borderWidth, null, null)
		{
		}

		// Token: 0x06005AFF RID: 23295 RVA: 0x0033E965 File Offset: 0x0033D965
		public Indexed100PercentStackedColumnSeriesElement(string name, float borderWidth, Color borderColor) : this(name, null, borderWidth, borderColor, null)
		{
		}

		// Token: 0x06005B00 RID: 23296 RVA: 0x0033E975 File Offset: 0x0033D975
		public Indexed100PercentStackedColumnSeriesElement(string name, Color color, float borderWidth, Color borderColor) : this(name, color, borderWidth, borderColor, null)
		{
		}

		// Token: 0x06005B01 RID: 23297 RVA: 0x0033E986 File Offset: 0x0033D986
		public Indexed100PercentStackedColumnSeriesElement(string name, Color color, float borderWidth, Color borderColor, Legend legend) : base(name, color, borderWidth, borderColor, legend)
		{
			base.a(new Indexed100PercentStackedColumnValueList(this));
		}

		// Token: 0x17000950 RID: 2384
		// (get) Token: 0x06005B02 RID: 23298 RVA: 0x0033E9BC File Offset: 0x0033D9BC
		public Indexed100PercentStackedColumnValueList Values
		{
			get
			{
				return (Indexed100PercentStackedColumnValueList)base.a();
			}
		}

		// Token: 0x06005B03 RID: 23299 RVA: 0x0033E9DC File Offset: 0x0033D9DC
		internal override float i1()
		{
			return this.b;
		}

		// Token: 0x06005B04 RID: 23300 RVA: 0x0033E9F4 File Offset: 0x0033D9F4
		internal override void i2(float A_0)
		{
			if (A_0 > this.b)
			{
				this.b = A_0;
			}
		}

		// Token: 0x06005B05 RID: 23301 RVA: 0x0033EA1C File Offset: 0x0033DA1C
		internal override float i3()
		{
			return this.a;
		}

		// Token: 0x06005B06 RID: 23302 RVA: 0x0033EA34 File Offset: 0x0033DA34
		internal override void i4(float A_0)
		{
			if (A_0 < this.a)
			{
				this.a = A_0;
			}
		}

		// Token: 0x04002F9A RID: 12186
		private new float a = 2.1474836E+09f;

		// Token: 0x04002F9B RID: 12187
		private new float b = -2.1474836E+09f;
	}
}
