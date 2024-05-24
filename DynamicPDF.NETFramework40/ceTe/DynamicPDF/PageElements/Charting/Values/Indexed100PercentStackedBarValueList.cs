using System;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008FD RID: 2301
	public class Indexed100PercentStackedBarValueList : Stacked100PercentBarValueList
	{
		// Token: 0x06005E69 RID: 24169 RVA: 0x0035765C File Offset: 0x0035665C
		internal Indexed100PercentStackedBarValueList(Indexed100PercentStackedBarSeriesElement A_0) : base(A_0)
		{
		}

		// Token: 0x06005E6A RID: 24170 RVA: 0x00357668 File Offset: 0x00356668
		public Stacked100PercentBarValue Add(float value1)
		{
			Stacked100PercentBarValue stacked100PercentBarValue = new Stacked100PercentBarValue(value1);
			base.a(stacked100PercentBarValue);
			return stacked100PercentBarValue;
		}

		// Token: 0x06005E6B RID: 24171 RVA: 0x0035768C File Offset: 0x0035668C
		public Stacked100PercentBarValue[] Add(float[] value1)
		{
			Stacked100PercentBarValue[] array = new Stacked100PercentBarValue[value1.Length];
			for (int i = 0; i < value1.Length; i++)
			{
				array[i] = new Stacked100PercentBarValue(value1[i]);
				base.a(array[i]);
			}
			return array;
		}

		// Token: 0x06005E6C RID: 24172 RVA: 0x003576D4 File Offset: 0x003566D4
		public Indexed100PercentStackedBarValue Add(float value1, int position)
		{
			Indexed100PercentStackedBarValue indexed100PercentStackedBarValue = new Indexed100PercentStackedBarValue(value1, position);
			base.a(indexed100PercentStackedBarValue);
			return indexed100PercentStackedBarValue;
		}

		// Token: 0x06005E6D RID: 24173 RVA: 0x003576F7 File Offset: 0x003566F7
		public void Add(Indexed100PercentStackedBarValue indexedStackedBarValue)
		{
			base.a(indexedStackedBarValue);
		}
	}
}
