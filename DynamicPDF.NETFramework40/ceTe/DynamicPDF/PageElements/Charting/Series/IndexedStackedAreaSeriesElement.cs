using System;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008BC RID: 2236
	public class IndexedStackedAreaSeriesElement : StackedAreaSeriesElement
	{
		// Token: 0x06005B6B RID: 23403 RVA: 0x0033F625 File Offset: 0x0033E625
		public IndexedStackedAreaSeriesElement(string name) : this(name, null, null, null)
		{
		}

		// Token: 0x06005B6C RID: 23404 RVA: 0x0033F634 File Offset: 0x0033E634
		public IndexedStackedAreaSeriesElement(string name, Color color) : this(name, color, null, null)
		{
		}

		// Token: 0x06005B6D RID: 23405 RVA: 0x0033F643 File Offset: 0x0033E643
		public IndexedStackedAreaSeriesElement(string name, Color color, Marker marker) : this(name, color, marker, null)
		{
		}

		// Token: 0x06005B6E RID: 23406 RVA: 0x0033F652 File Offset: 0x0033E652
		public IndexedStackedAreaSeriesElement(string name, Color color, Legend legend) : this(name, color, null, legend)
		{
		}

		// Token: 0x06005B6F RID: 23407 RVA: 0x0033F661 File Offset: 0x0033E661
		public IndexedStackedAreaSeriesElement(string name, Color color, Marker marker, Legend legend) : base(name, color, marker, legend)
		{
			base.a(new IndexedStackedAreaValueList(this));
		}

		// Token: 0x06005B70 RID: 23408 RVA: 0x0033F694 File Offset: 0x0033E694
		internal override float i1()
		{
			return this.b;
		}

		// Token: 0x06005B71 RID: 23409 RVA: 0x0033F6AC File Offset: 0x0033E6AC
		internal override void i2(float A_0)
		{
			if (A_0 > this.b)
			{
				this.b = A_0;
			}
		}

		// Token: 0x06005B72 RID: 23410 RVA: 0x0033F6D4 File Offset: 0x0033E6D4
		internal override float i3()
		{
			return this.a;
		}

		// Token: 0x06005B73 RID: 23411 RVA: 0x0033F6EC File Offset: 0x0033E6EC
		internal override void i4(float A_0)
		{
			if (A_0 < this.a)
			{
				this.a = A_0;
			}
		}

		// Token: 0x17000964 RID: 2404
		// (get) Token: 0x06005B74 RID: 23412 RVA: 0x0033F714 File Offset: 0x0033E714
		public IndexedStackedAreaValueList Values
		{
			get
			{
				return (IndexedStackedAreaValueList)base.a();
			}
		}

		// Token: 0x04002FAA RID: 12202
		private new float a = 2.1474836E+09f;

		// Token: 0x04002FAB RID: 12203
		private new float b = -2.1474836E+09f;
	}
}
