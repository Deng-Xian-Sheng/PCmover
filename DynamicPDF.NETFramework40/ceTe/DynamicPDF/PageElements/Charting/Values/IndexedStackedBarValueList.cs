using System;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x0200090D RID: 2317
	public class IndexedStackedBarValueList : StackedBarValueList
	{
		// Token: 0x06005EAB RID: 24235 RVA: 0x00358038 File Offset: 0x00357038
		internal IndexedStackedBarValueList(IndexedStackedBarSeriesElement A_0) : base(A_0)
		{
		}

		// Token: 0x06005EAC RID: 24236 RVA: 0x00358044 File Offset: 0x00357044
		public StackedBarValue Add(float value1)
		{
			StackedBarValue stackedBarValue = new StackedBarValue(value1);
			base.a(stackedBarValue);
			return stackedBarValue;
		}

		// Token: 0x06005EAD RID: 24237 RVA: 0x00358068 File Offset: 0x00357068
		public StackedBarValue[] Add(float[] value1)
		{
			StackedBarValue[] array = new StackedBarValue[value1.Length];
			for (int i = 0; i < value1.Length; i++)
			{
				array[i] = new StackedBarValue(value1[i]);
				base.a(array[i]);
			}
			return array;
		}

		// Token: 0x06005EAE RID: 24238 RVA: 0x003580B0 File Offset: 0x003570B0
		public IndexedStackedBarValue Add(float value1, int position)
		{
			IndexedStackedBarValue indexedStackedBarValue = new IndexedStackedBarValue(value1, position);
			base.a(indexedStackedBarValue);
			return indexedStackedBarValue;
		}

		// Token: 0x06005EAF RID: 24239 RVA: 0x003580D3 File Offset: 0x003570D3
		public void Add(IndexedStackedBarValue indexedStackedBarValue)
		{
			base.a(indexedStackedBarValue);
		}
	}
}
