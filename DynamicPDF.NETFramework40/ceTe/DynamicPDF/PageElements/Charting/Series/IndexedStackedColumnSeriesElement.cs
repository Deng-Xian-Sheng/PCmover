using System;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008C0 RID: 2240
	public class IndexedStackedColumnSeriesElement : StackedColumnSeriesElement
	{
		// Token: 0x06005B99 RID: 23449 RVA: 0x0033FB69 File Offset: 0x0033EB69
		public IndexedStackedColumnSeriesElement(string name) : this(name, null, 0f, null, null)
		{
		}

		// Token: 0x06005B9A RID: 23450 RVA: 0x0033FB7D File Offset: 0x0033EB7D
		public IndexedStackedColumnSeriesElement(string name, Color color) : this(name, color, 0f, null, null)
		{
		}

		// Token: 0x06005B9B RID: 23451 RVA: 0x0033FB91 File Offset: 0x0033EB91
		public IndexedStackedColumnSeriesElement(string name, Color color, Legend legend) : this(name, color, 0f, null, legend)
		{
		}

		// Token: 0x06005B9C RID: 23452 RVA: 0x0033FBA5 File Offset: 0x0033EBA5
		public IndexedStackedColumnSeriesElement(string name, Color color, float borderWidth) : this(name, color, borderWidth, null, null)
		{
		}

		// Token: 0x06005B9D RID: 23453 RVA: 0x0033FBB5 File Offset: 0x0033EBB5
		public IndexedStackedColumnSeriesElement(string name, float borderWidth, Color borderColor) : this(name, null, borderWidth, borderColor, null)
		{
		}

		// Token: 0x06005B9E RID: 23454 RVA: 0x0033FBC5 File Offset: 0x0033EBC5
		public IndexedStackedColumnSeriesElement(string name, Color color, float borderWidth, Color borderColor) : this(name, color, borderWidth, borderColor, null)
		{
		}

		// Token: 0x06005B9F RID: 23455 RVA: 0x0033FBD6 File Offset: 0x0033EBD6
		public IndexedStackedColumnSeriesElement(string name, Color color, float borderWidth, Color borderColor, Legend legend) : base(name, color, borderWidth, borderColor, legend)
		{
			base.a(new IndexedStackedColumnValueList(this));
		}

		// Token: 0x1700096C RID: 2412
		// (get) Token: 0x06005BA0 RID: 23456 RVA: 0x0033FC0C File Offset: 0x0033EC0C
		public IndexedStackedColumnValueList Values
		{
			get
			{
				return (IndexedStackedColumnValueList)base.a();
			}
		}

		// Token: 0x06005BA1 RID: 23457 RVA: 0x0033FC2C File Offset: 0x0033EC2C
		internal override float i1()
		{
			return this.b;
		}

		// Token: 0x06005BA2 RID: 23458 RVA: 0x0033FC44 File Offset: 0x0033EC44
		internal override void i2(float A_0)
		{
			if (A_0 > this.b)
			{
				this.b = A_0;
			}
		}

		// Token: 0x06005BA3 RID: 23459 RVA: 0x0033FC6C File Offset: 0x0033EC6C
		internal override float i3()
		{
			return this.a;
		}

		// Token: 0x06005BA4 RID: 23460 RVA: 0x0033FC84 File Offset: 0x0033EC84
		internal override void i4(float A_0)
		{
			if (A_0 < this.a)
			{
				this.a = A_0;
			}
		}

		// Token: 0x04002FB2 RID: 12210
		private new float a = 2.1474836E+09f;

		// Token: 0x04002FB3 RID: 12211
		private new float b = -2.1474836E+09f;
	}
}
