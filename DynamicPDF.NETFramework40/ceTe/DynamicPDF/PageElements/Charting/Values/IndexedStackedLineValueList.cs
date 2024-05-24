using System;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x02000911 RID: 2321
	public class IndexedStackedLineValueList : StackedLineValueList
	{
		// Token: 0x06005EB9 RID: 24249 RVA: 0x003581E0 File Offset: 0x003571E0
		internal IndexedStackedLineValueList(IndexedStackedLineSeriesElement A_0) : base(A_0)
		{
		}

		// Token: 0x06005EBA RID: 24250 RVA: 0x003581EC File Offset: 0x003571EC
		public void Add(IndexedStackedLineValue lineValue)
		{
			base.a(lineValue);
			this.a(lineValue.Position);
		}

		// Token: 0x06005EBB RID: 24251 RVA: 0x00358204 File Offset: 0x00357204
		public StackedLineValue Add(float value1)
		{
			StackedLineValue stackedLineValue = new StackedLineValue(value1);
			base.a(stackedLineValue);
			this.a();
			return stackedLineValue;
		}

		// Token: 0x06005EBC RID: 24252 RVA: 0x00358230 File Offset: 0x00357230
		public StackedLineValue[] Add(float[] value1)
		{
			StackedLineValue[] array = new StackedLineValue[value1.Length];
			for (int i = 0; i < value1.Length; i++)
			{
				StackedLineValue stackedLineValue = new StackedLineValue(value1[i]);
				base.a(stackedLineValue);
				this.a();
				array[i] = stackedLineValue;
			}
			return array;
		}

		// Token: 0x06005EBD RID: 24253 RVA: 0x00358280 File Offset: 0x00357280
		public StackedLineValue Add(float value1, int position)
		{
			IndexedStackedLineValue indexedStackedLineValue = new IndexedStackedLineValue(value1, position);
			base.a(indexedStackedLineValue);
			this.a(position);
			return indexedStackedLineValue;
		}

		// Token: 0x06005EBE RID: 24254 RVA: 0x003582AC File Offset: 0x003572AC
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

		// Token: 0x06005EBF RID: 24255 RVA: 0x0035830E File Offset: 0x0035730E
		internal void a(int A_0)
		{
			base.b().i2((float)A_0);
			base.b().i4((float)A_0);
		}
	}
}
