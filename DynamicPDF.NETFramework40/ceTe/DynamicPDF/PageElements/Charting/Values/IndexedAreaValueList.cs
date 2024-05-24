using System;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x02000903 RID: 2307
	public class IndexedAreaValueList : AreaValueList
	{
		// Token: 0x06005E80 RID: 24192 RVA: 0x00357984 File Offset: 0x00356984
		internal IndexedAreaValueList(IndexedAreaSeries A_0) : base(A_0)
		{
		}

		// Token: 0x06005E81 RID: 24193 RVA: 0x00357990 File Offset: 0x00356990
		public IndexedAreaValue Add(float value1, int position)
		{
			IndexedAreaValue indexedAreaValue = new IndexedAreaValue(value1, position);
			base.a(indexedAreaValue);
			this.a(position);
			this.a(value1);
			return indexedAreaValue;
		}

		// Token: 0x06005E82 RID: 24194 RVA: 0x003579C3 File Offset: 0x003569C3
		public void Add(IndexedAreaValue areaValue)
		{
			base.a(areaValue);
			this.a(areaValue.Position);
			this.a(areaValue.Value);
		}

		// Token: 0x06005E83 RID: 24195 RVA: 0x003579E8 File Offset: 0x003569E8
		public AreaValue Add(float value1)
		{
			AreaValue areaValue = new AreaValue(value1);
			base.a(areaValue);
			this.a(value1);
			this.a();
			return areaValue;
		}

		// Token: 0x06005E84 RID: 24196 RVA: 0x00357A1C File Offset: 0x00356A1C
		public AreaValue[] Add(float[] value1)
		{
			AreaValue[] array = new AreaValue[value1.Length];
			for (int i = 0; i < value1.Length; i++)
			{
				AreaValue areaValue = new AreaValue(value1[i]);
				base.a(areaValue);
				this.a();
				this.a(value1[i]);
				array[i] = areaValue;
			}
			return array;
		}

		// Token: 0x06005E85 RID: 24197 RVA: 0x00357A74 File Offset: 0x00356A74
		private void a()
		{
			AreaSeries areaSeries = base.c();
			if (base.Count == 1)
			{
				this.a(0);
			}
			else if ((float)base.Count > areaSeries.ig())
			{
				areaSeries.iy(areaSeries.ig() + 1f);
			}
		}

		// Token: 0x06005E86 RID: 24198 RVA: 0x00357AD0 File Offset: 0x00356AD0
		internal void a(float A_0)
		{
			AreaSeries areaSeries = base.c();
			areaSeries.a(A_0);
			areaSeries.b(A_0);
		}

		// Token: 0x06005E87 RID: 24199 RVA: 0x00357AF8 File Offset: 0x00356AF8
		internal void a(int A_0)
		{
			AreaSeries areaSeries = base.c();
			areaSeries.iy((float)A_0);
			areaSeries.i0((float)A_0);
		}
	}
}
