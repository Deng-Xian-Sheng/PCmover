using System;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x02000907 RID: 2311
	public class IndexedColumnValueList : ColumnValueList
	{
		// Token: 0x06005E91 RID: 24209 RVA: 0x00357C20 File Offset: 0x00356C20
		internal IndexedColumnValueList(IndexedColumnSeries A_0) : base(A_0)
		{
		}

		// Token: 0x06005E92 RID: 24210 RVA: 0x00357C2C File Offset: 0x00356C2C
		public ColumnValue Add(float value1)
		{
			ColumnValue columnValue = new ColumnValue(value1);
			base.a(columnValue);
			return columnValue;
		}

		// Token: 0x06005E93 RID: 24211 RVA: 0x00357C50 File Offset: 0x00356C50
		public ColumnValue[] Add(float[] value1)
		{
			ColumnValue[] array = new ColumnValue[value1.Length];
			for (int i = 0; i < value1.Length; i++)
			{
				array[i] = new ColumnValue(value1[i]);
				base.a(array[i]);
			}
			return array;
		}

		// Token: 0x06005E94 RID: 24212 RVA: 0x00357C98 File Offset: 0x00356C98
		public IndexedColumnValue Add(float value1, int position)
		{
			IndexedColumnValue indexedColumnValue = new IndexedColumnValue(value1, position);
			base.a(indexedColumnValue);
			return indexedColumnValue;
		}

		// Token: 0x06005E95 RID: 24213 RVA: 0x00357CBB File Offset: 0x00356CBB
		public void Add(IndexedColumnValue indexedColumnValue)
		{
			base.a(indexedColumnValue);
		}
	}
}
