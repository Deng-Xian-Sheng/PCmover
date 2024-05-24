using System;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008B0 RID: 2224
	public class Indexed100PercentStackedAreaSeriesElement : Stacked100PercentAreaSeriesElement
	{
		// Token: 0x06005ACD RID: 23245 RVA: 0x0033E3D5 File Offset: 0x0033D3D5
		public Indexed100PercentStackedAreaSeriesElement(string name) : this(name, null, null, null)
		{
		}

		// Token: 0x06005ACE RID: 23246 RVA: 0x0033E3E4 File Offset: 0x0033D3E4
		public Indexed100PercentStackedAreaSeriesElement(string name, Color color) : this(name, color, null, null)
		{
		}

		// Token: 0x06005ACF RID: 23247 RVA: 0x0033E3F3 File Offset: 0x0033D3F3
		public Indexed100PercentStackedAreaSeriesElement(string name, Color color, Marker marker) : this(name, color, marker, null)
		{
		}

		// Token: 0x06005AD0 RID: 23248 RVA: 0x0033E402 File Offset: 0x0033D402
		public Indexed100PercentStackedAreaSeriesElement(string name, Color color, Legend legend) : this(name, color, null, legend)
		{
		}

		// Token: 0x06005AD1 RID: 23249 RVA: 0x0033E411 File Offset: 0x0033D411
		public Indexed100PercentStackedAreaSeriesElement(string name, Color color, Marker marker, Legend legend) : base(name, color, marker, legend)
		{
			base.a(new Indexed100PercentStackedAreaValueList(this));
		}

		// Token: 0x06005AD2 RID: 23250 RVA: 0x0033E444 File Offset: 0x0033D444
		internal override float i1()
		{
			return this.b;
		}

		// Token: 0x06005AD3 RID: 23251 RVA: 0x0033E45C File Offset: 0x0033D45C
		internal override void i2(float A_0)
		{
			if (A_0 > this.b)
			{
				this.b = A_0;
			}
		}

		// Token: 0x06005AD4 RID: 23252 RVA: 0x0033E484 File Offset: 0x0033D484
		internal override float i3()
		{
			return this.a;
		}

		// Token: 0x06005AD5 RID: 23253 RVA: 0x0033E49C File Offset: 0x0033D49C
		internal override void i4(float A_0)
		{
			if (A_0 < this.a)
			{
				this.a = A_0;
			}
		}

		// Token: 0x17000948 RID: 2376
		// (get) Token: 0x06005AD6 RID: 23254 RVA: 0x0033E4C4 File Offset: 0x0033D4C4
		public Indexed100PercentStackedAreaValueList Values
		{
			get
			{
				return (Indexed100PercentStackedAreaValueList)base.a();
			}
		}

		// Token: 0x04002F92 RID: 12178
		private new float a = 2.1474836E+09f;

		// Token: 0x04002F93 RID: 12179
		private new float b = -2.1474836E+09f;
	}
}
