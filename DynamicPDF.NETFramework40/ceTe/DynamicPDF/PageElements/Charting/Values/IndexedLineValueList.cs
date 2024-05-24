using System;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x02000909 RID: 2313
	public class IndexedLineValueList : LineValueList
	{
		// Token: 0x06005E98 RID: 24216 RVA: 0x00357CF4 File Offset: 0x00356CF4
		internal IndexedLineValueList(IndexedLineSeries A_0) : base(A_0)
		{
		}

		// Token: 0x06005E99 RID: 24217 RVA: 0x00357D00 File Offset: 0x00356D00
		public void Add(IndexedLineValue lineValue)
		{
			base.a(lineValue);
			this.a(lineValue.Position);
			this.a(lineValue.Value);
		}

		// Token: 0x06005E9A RID: 24218 RVA: 0x00357D28 File Offset: 0x00356D28
		public LineValue Add(float value1)
		{
			LineValue lineValue = new LineValue(value1);
			base.a(lineValue);
			this.a(value1);
			this.a();
			return lineValue;
		}

		// Token: 0x06005E9B RID: 24219 RVA: 0x00357D5C File Offset: 0x00356D5C
		public LineValue[] Add(float[] value1)
		{
			LineValue[] array = new LineValue[value1.Length];
			for (int i = 0; i < value1.Length; i++)
			{
				LineValue lineValue = new LineValue(value1[i]);
				base.a(lineValue);
				this.a(value1[i]);
				this.a();
				array[i] = lineValue;
			}
			return array;
		}

		// Token: 0x06005E9C RID: 24220 RVA: 0x00357DB4 File Offset: 0x00356DB4
		public LineValue Add(float value1, int position)
		{
			IndexedLineValue indexedLineValue = new IndexedLineValue(value1, position);
			base.a(indexedLineValue);
			this.a(position);
			this.a(value1);
			return indexedLineValue;
		}

		// Token: 0x06005E9D RID: 24221 RVA: 0x00357DE8 File Offset: 0x00356DE8
		private void a()
		{
			LineSeries lineSeries = base.c();
			if (base.Count == 1)
			{
				this.a(0);
			}
			else if ((float)base.Count > lineSeries.ig())
			{
				lineSeries.iy(lineSeries.ig() + 1f);
			}
		}

		// Token: 0x06005E9E RID: 24222 RVA: 0x00357E44 File Offset: 0x00356E44
		internal void a(float A_0)
		{
			LineSeries lineSeries = base.c();
			lineSeries.a(A_0);
			lineSeries.b(A_0);
		}

		// Token: 0x06005E9F RID: 24223 RVA: 0x00357E6C File Offset: 0x00356E6C
		internal void a(int A_0)
		{
			LineSeries lineSeries = base.c();
			lineSeries.iy((float)A_0);
			lineSeries.i0((float)A_0);
		}
	}
}
