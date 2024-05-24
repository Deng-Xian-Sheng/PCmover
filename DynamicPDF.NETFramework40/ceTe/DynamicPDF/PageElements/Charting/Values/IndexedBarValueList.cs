using System;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x02000905 RID: 2309
	public class IndexedBarValueList : BarValueList
	{
		// Token: 0x06005E8A RID: 24202 RVA: 0x00357B4C File Offset: 0x00356B4C
		internal IndexedBarValueList(IndexedBarSeries A_0) : base(A_0)
		{
		}

		// Token: 0x06005E8B RID: 24203 RVA: 0x00357B58 File Offset: 0x00356B58
		public BarValue Add(float value1)
		{
			BarValue barValue = new BarValue(value1);
			base.a(barValue);
			return barValue;
		}

		// Token: 0x06005E8C RID: 24204 RVA: 0x00357B7C File Offset: 0x00356B7C
		public BarValue[] Add(float[] value1)
		{
			BarValue[] array = new BarValue[value1.Length];
			for (int i = 0; i < value1.Length; i++)
			{
				array[i] = new BarValue(value1[i]);
				base.a(array[i]);
			}
			return array;
		}

		// Token: 0x06005E8D RID: 24205 RVA: 0x00357BC4 File Offset: 0x00356BC4
		public IndexedBarValue Add(float value1, int position)
		{
			IndexedBarValue indexedBarValue = new IndexedBarValue(value1, position);
			base.a(indexedBarValue);
			return indexedBarValue;
		}

		// Token: 0x06005E8E RID: 24206 RVA: 0x00357BE7 File Offset: 0x00356BE7
		public void Add(IndexedBarValue indexedBarValue)
		{
			base.a(indexedBarValue);
		}
	}
}
