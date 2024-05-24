using System;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008FB RID: 2299
	public class Indexed100PercentStackedAreaValueList : Stacked100PercentAreaValueList
	{
		// Token: 0x06005E60 RID: 24160 RVA: 0x003574E4 File Offset: 0x003564E4
		internal Indexed100PercentStackedAreaValueList(Indexed100PercentStackedAreaSeriesElement A_0) : base(A_0)
		{
		}

		// Token: 0x06005E61 RID: 24161 RVA: 0x003574F0 File Offset: 0x003564F0
		public void Add(Indexed100PercentStackedAreaValue areaValue)
		{
			base.a(areaValue);
			this.a(areaValue.Position);
		}

		// Token: 0x06005E62 RID: 24162 RVA: 0x00357508 File Offset: 0x00356508
		public Stacked100PercentAreaValue Add(float val)
		{
			Stacked100PercentAreaValue stacked100PercentAreaValue = new Stacked100PercentAreaValue(val);
			base.a(stacked100PercentAreaValue);
			this.a();
			return stacked100PercentAreaValue;
		}

		// Token: 0x06005E63 RID: 24163 RVA: 0x00357534 File Offset: 0x00356534
		public Stacked100PercentAreaValue[] Add(float[] value1)
		{
			Stacked100PercentAreaValue[] array = new Stacked100PercentAreaValue[value1.Length];
			for (int i = 0; i < value1.Length; i++)
			{
				Stacked100PercentAreaValue stacked100PercentAreaValue = new Stacked100PercentAreaValue(value1[i]);
				base.a(stacked100PercentAreaValue);
				this.a();
				array[i] = stacked100PercentAreaValue;
			}
			return array;
		}

		// Token: 0x06005E64 RID: 24164 RVA: 0x00357584 File Offset: 0x00356584
		public Indexed100PercentStackedAreaValue Add(float value1, int position)
		{
			Indexed100PercentStackedAreaValue indexed100PercentStackedAreaValue = new Indexed100PercentStackedAreaValue(value1, position);
			base.a(indexed100PercentStackedAreaValue);
			this.a(position);
			return indexed100PercentStackedAreaValue;
		}

		// Token: 0x06005E65 RID: 24165 RVA: 0x003575B0 File Offset: 0x003565B0
		private void a()
		{
			if (base.Count == 1)
			{
				this.a(0);
			}
			else if ((float)base.Count > base.b().i1())
			{
				base.b().i2(base.b().i1() + 1f);
			}
		}

		// Token: 0x06005E66 RID: 24166 RVA: 0x00357612 File Offset: 0x00356612
		internal void a(int A_0)
		{
			base.b().i2((float)A_0);
			base.b().i4((float)A_0);
		}
	}
}
