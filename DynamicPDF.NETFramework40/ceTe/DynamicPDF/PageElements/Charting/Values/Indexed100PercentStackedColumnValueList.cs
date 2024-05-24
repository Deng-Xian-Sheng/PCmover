using System;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008FF RID: 2303
	public class Indexed100PercentStackedColumnValueList : Stacked100PercentColumnValueList
	{
		// Token: 0x06005E70 RID: 24176 RVA: 0x00357730 File Offset: 0x00356730
		internal Indexed100PercentStackedColumnValueList(Indexed100PercentStackedColumnSeriesElement A_0) : base(A_0)
		{
		}

		// Token: 0x06005E71 RID: 24177 RVA: 0x0035773C File Offset: 0x0035673C
		public Stacked100PercentColumnValue Add(float value1)
		{
			Stacked100PercentColumnValue stacked100PercentColumnValue = new Stacked100PercentColumnValue(value1);
			base.a(stacked100PercentColumnValue);
			return stacked100PercentColumnValue;
		}

		// Token: 0x06005E72 RID: 24178 RVA: 0x00357760 File Offset: 0x00356760
		public Stacked100PercentColumnValue[] Add(float[] value1)
		{
			Stacked100PercentColumnValue[] array = new Stacked100PercentColumnValue[value1.Length];
			for (int i = 0; i < value1.Length; i++)
			{
				array[i] = new Stacked100PercentColumnValue(value1[i]);
				base.a(array[i]);
			}
			return array;
		}

		// Token: 0x06005E73 RID: 24179 RVA: 0x003577A8 File Offset: 0x003567A8
		public Indexed100PercentStackedColumnValue Add(float value1, int position)
		{
			Indexed100PercentStackedColumnValue indexed100PercentStackedColumnValue = new Indexed100PercentStackedColumnValue(value1, position);
			base.a(indexed100PercentStackedColumnValue);
			return indexed100PercentStackedColumnValue;
		}

		// Token: 0x06005E74 RID: 24180 RVA: 0x003577CB File Offset: 0x003567CB
		public void Add(Indexed100PercentStackedColumnValue indexedStackedColumnValue)
		{
			base.a(indexedStackedColumnValue);
		}
	}
}
