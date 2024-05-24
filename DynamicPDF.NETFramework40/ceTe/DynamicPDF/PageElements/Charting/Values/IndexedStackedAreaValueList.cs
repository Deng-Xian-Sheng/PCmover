using System;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x0200090B RID: 2315
	public class IndexedStackedAreaValueList : StackedAreaValueList
	{
		// Token: 0x06005EA2 RID: 24226 RVA: 0x00357EC0 File Offset: 0x00356EC0
		internal IndexedStackedAreaValueList(IndexedStackedAreaSeriesElement A_0) : base(A_0)
		{
		}

		// Token: 0x06005EA3 RID: 24227 RVA: 0x00357ECC File Offset: 0x00356ECC
		public void Add(IndexedStackedAreaValue areaValue)
		{
			base.a(areaValue);
			this.a(areaValue.Position);
		}

		// Token: 0x06005EA4 RID: 24228 RVA: 0x00357EE4 File Offset: 0x00356EE4
		public StackedAreaValue Add(float value1)
		{
			StackedAreaValue stackedAreaValue = new StackedAreaValue(value1);
			base.a(stackedAreaValue);
			this.a();
			return stackedAreaValue;
		}

		// Token: 0x06005EA5 RID: 24229 RVA: 0x00357F10 File Offset: 0x00356F10
		public StackedAreaValue[] Add(float[] value1)
		{
			StackedAreaValue[] array = new StackedAreaValue[value1.Length];
			for (int i = 0; i < value1.Length; i++)
			{
				StackedAreaValue stackedAreaValue = new StackedAreaValue(value1[i]);
				base.a(stackedAreaValue);
				this.a();
				array[i] = stackedAreaValue;
			}
			return array;
		}

		// Token: 0x06005EA6 RID: 24230 RVA: 0x00357F60 File Offset: 0x00356F60
		public StackedAreaValue Add(float value1, int position)
		{
			IndexedStackedAreaValue indexedStackedAreaValue = new IndexedStackedAreaValue(value1, position);
			base.a(indexedStackedAreaValue);
			this.a(position);
			return indexedStackedAreaValue;
		}

		// Token: 0x06005EA7 RID: 24231 RVA: 0x00357F8C File Offset: 0x00356F8C
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

		// Token: 0x06005EA8 RID: 24232 RVA: 0x00357FEE File Offset: 0x00356FEE
		internal void a(int A_0)
		{
			base.b().i2((float)A_0);
			base.b().i4((float)A_0);
		}
	}
}
