using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Axes;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008A7 RID: 2215
	public abstract class StackedColumnSeries : StackedSeries
	{
		// Token: 0x06005A63 RID: 23139 RVA: 0x0033D120 File Offset: 0x0033C120
		internal StackedColumnSeries(XAxis A_0, YAxis A_1) : base(A_0, A_1, false)
		{
			base.DrawBehindAxis = true;
		}

		// Token: 0x06005A64 RID: 23140 RVA: 0x0033D136 File Offset: 0x0033C136
		internal void a(int A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06005A65 RID: 23141 RVA: 0x0033D140 File Offset: 0x0033C140
		internal override void id()
		{
			StackedColumnSeriesElement[] array = this.a();
			int num = base.k();
			float[] array2 = new float[num];
			float[] array3 = new float[1];
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < array.Length; j++)
				{
					array3 = array[j].a().b();
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

		// Token: 0x06005A66 RID: 23142 RVA: 0x0033D20C File Offset: 0x0033C20C
		internal override void ie()
		{
			StackedColumnSeriesElement[] array = this.a();
			int num = base.k();
			float[] array2 = new float[num];
			float[] array3 = new float[1];
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < array.Length; j++)
				{
					array3 = array[j].a().b();
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

		// Token: 0x06005A67 RID: 23143 RVA: 0x0033D2D8 File Offset: 0x0033C2D8
		internal override void ic(PageWriter A_0)
		{
			StackedColumnSeriesElement[] array = this.a();
			int a_;
			if (this is DateTimeStackedColumnSeries)
			{
				a_ = base.PlotArea.Series.g();
			}
			else
			{
				a_ = base.PlotArea.Series.f();
			}
			for (int i = 0; i < array.Length; i++)
			{
				array[i].a(A_0, array, i, this.a, a_);
			}
		}

		// Token: 0x06005A68 RID: 23144 RVA: 0x0033D34C File Offset: 0x0033C34C
		internal override void ib(PageWriter A_0)
		{
			for (int i = 0; i < base.b().Count; i++)
			{
				((StackedColumnSeriesElement)base.b()[i]).a(A_0);
			}
		}

		// Token: 0x06005A69 RID: 23145 RVA: 0x0033D390 File Offset: 0x0033C390
		private StackedColumnSeriesElement[] a()
		{
			StackedColumnSeriesElement[] array = new StackedColumnSeriesElement[base.b().Count];
			for (int i = 0; i < base.b().Count; i++)
			{
				array[i] = (StackedColumnSeriesElement)base.b()[i];
				array[i].a().d();
			}
			return array;
		}

		// Token: 0x04002F7A RID: 12154
		private new int a;
	}
}
