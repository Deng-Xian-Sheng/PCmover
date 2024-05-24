using System;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x02000901 RID: 2305
	public class Indexed100PercentStackedLineValueList : Stacked100PercentLineValueList
	{
		// Token: 0x06005E77 RID: 24183 RVA: 0x00357804 File Offset: 0x00356804
		internal Indexed100PercentStackedLineValueList(Indexed100PercentStackedLineSeriesElement A_0) : base(A_0)
		{
		}

		// Token: 0x06005E78 RID: 24184 RVA: 0x00357810 File Offset: 0x00356810
		public void Add(Indexed100PercentStackedLineValue lineValue)
		{
			base.a(lineValue);
			this.a(lineValue.Position);
		}

		// Token: 0x06005E79 RID: 24185 RVA: 0x00357828 File Offset: 0x00356828
		public Stacked100PercentLineValue Add(float value1)
		{
			Stacked100PercentLineValue stacked100PercentLineValue = new Stacked100PercentLineValue(value1);
			base.a(stacked100PercentLineValue);
			this.a();
			return stacked100PercentLineValue;
		}

		// Token: 0x06005E7A RID: 24186 RVA: 0x00357854 File Offset: 0x00356854
		public Stacked100PercentLineValue[] Add(float[] value1)
		{
			Stacked100PercentLineValue[] array = new Stacked100PercentLineValue[value1.Length];
			for (int i = 0; i < value1.Length; i++)
			{
				Stacked100PercentLineValue stacked100PercentLineValue = new Stacked100PercentLineValue(value1[i]);
				base.a(stacked100PercentLineValue);
				this.a();
				array[i] = stacked100PercentLineValue;
			}
			return array;
		}

		// Token: 0x06005E7B RID: 24187 RVA: 0x003578A4 File Offset: 0x003568A4
		public Indexed100PercentStackedLineValue Add(float value1, int position)
		{
			Indexed100PercentStackedLineValue indexed100PercentStackedLineValue = new Indexed100PercentStackedLineValue(value1, position);
			base.a(indexed100PercentStackedLineValue);
			this.a(position);
			return indexed100PercentStackedLineValue;
		}

		// Token: 0x06005E7C RID: 24188 RVA: 0x003578D0 File Offset: 0x003568D0
		private void a()
		{
			if (base.Count == 1)
			{
				this.a(0);
			}
			else if ((float)base.e().Count > base.b().i1())
			{
				base.b().i2(base.b().i1() + 1f);
			}
		}

		// Token: 0x06005E7D RID: 24189 RVA: 0x00357937 File Offset: 0x00356937
		internal void a(int A_0)
		{
			base.b().i2((float)A_0);
			base.b().i4((float)A_0);
		}
	}
}
