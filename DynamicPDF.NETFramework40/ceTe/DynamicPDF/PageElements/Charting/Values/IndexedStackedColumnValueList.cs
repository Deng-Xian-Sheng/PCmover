using System;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x0200090F RID: 2319
	public class IndexedStackedColumnValueList : StackedColumnValueList
	{
		// Token: 0x06005EB2 RID: 24242 RVA: 0x0035810C File Offset: 0x0035710C
		internal IndexedStackedColumnValueList(IndexedStackedColumnSeriesElement A_0) : base(A_0)
		{
		}

		// Token: 0x06005EB3 RID: 24243 RVA: 0x00358118 File Offset: 0x00357118
		public StackedColumnValue Add(float value1)
		{
			StackedColumnValue stackedColumnValue = new StackedColumnValue(value1);
			base.a(stackedColumnValue);
			return stackedColumnValue;
		}

		// Token: 0x06005EB4 RID: 24244 RVA: 0x0035813C File Offset: 0x0035713C
		public StackedColumnValue[] Add(float[] value1)
		{
			StackedColumnValue[] array = new StackedColumnValue[value1.Length];
			for (int i = 0; i < value1.Length; i++)
			{
				array[i] = new StackedColumnValue(value1[i]);
				base.a(array[i]);
			}
			return array;
		}

		// Token: 0x06005EB5 RID: 24245 RVA: 0x00358184 File Offset: 0x00357184
		public IndexedStackedColumnValue Add(float value1, int position)
		{
			IndexedStackedColumnValue indexedStackedColumnValue = new IndexedStackedColumnValue(value1, position);
			base.a(indexedStackedColumnValue);
			return indexedStackedColumnValue;
		}

		// Token: 0x06005EB6 RID: 24246 RVA: 0x003581A7 File Offset: 0x003571A7
		public void Add(IndexedStackedColumnValue indexedStackedColumnValue)
		{
			base.a(indexedStackedColumnValue);
		}
	}
}
