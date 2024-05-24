using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Axes;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008A3 RID: 2211
	public abstract class StackedBarSeries : StackedSeries
	{
		// Token: 0x06005A39 RID: 23097 RVA: 0x0033CA1D File Offset: 0x0033BA1D
		internal StackedBarSeries(XAxis A_0, YAxis A_1) : base(A_0, A_1, false)
		{
			base.DrawBehindAxis = true;
		}

		// Token: 0x06005A3A RID: 23098 RVA: 0x0033CA33 File Offset: 0x0033BA33
		internal void a(int A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06005A3B RID: 23099 RVA: 0x0033CA40 File Offset: 0x0033BA40
		internal override void id()
		{
			StackedBarSeriesElement[] array = this.a();
			int num = base.k();
			float[] array2 = new float[num];
			float[] array3 = new float[1];
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < array.Length; j++)
				{
					array3 = array[j].a().c();
					if (i < array3.Length)
					{
						if (array3[i] < 0f)
						{
							array2[i] += array3[i];
						}
					}
				}
			}
			if (num > 0)
			{
				Array.Sort<float>(array2);
				base.b(array2[0]);
			}
		}

		// Token: 0x06005A3C RID: 23100 RVA: 0x0033CB0C File Offset: 0x0033BB0C
		internal override void ie()
		{
			StackedBarSeriesElement[] array = this.a();
			int num = base.k();
			float[] array2 = new float[num];
			float[] array3 = new float[1];
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < array.Length; j++)
				{
					array3 = array[j].a().c();
					if (i < array3.Length)
					{
						if (array3[i] > 0f)
						{
							array2[i] += array3[i];
						}
					}
				}
			}
			if (num > 0)
			{
				Array.Sort<float>(array2);
				base.a(array2[num - 1]);
			}
		}

		// Token: 0x06005A3D RID: 23101 RVA: 0x0033CBDC File Offset: 0x0033BBDC
		internal override void ic(PageWriter A_0)
		{
			StackedBarSeriesElement[] array = this.a();
			int a_;
			if (this is DateTimeStackedBarSeries)
			{
				a_ = base.PlotArea.Series.i();
			}
			else
			{
				a_ = base.PlotArea.Series.h();
			}
			for (int i = 0; i < array.Length; i++)
			{
				array[i].a(A_0, array, i, this.a, a_);
			}
		}

		// Token: 0x06005A3E RID: 23102 RVA: 0x0033CC50 File Offset: 0x0033BC50
		internal override void ib(PageWriter A_0)
		{
			for (int i = 0; i < base.b().Count; i++)
			{
				((StackedBarSeriesElement)base.b()[i]).a(A_0);
			}
		}

		// Token: 0x06005A3F RID: 23103 RVA: 0x0033CC94 File Offset: 0x0033BC94
		private StackedBarSeriesElement[] a()
		{
			StackedBarSeriesElement[] array = new StackedBarSeriesElement[base.b().Count];
			for (int i = 0; i < base.b().Count; i++)
			{
				array[i] = (StackedBarSeriesElement)base.b()[i];
				array[i].a().d();
			}
			return array;
		}

		// Token: 0x04002F71 RID: 12145
		private new int a;
	}
}
