using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Axes;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x02000891 RID: 2193
	public abstract class Stacked100PercentColumnSeries : Stacked100PercentSeries
	{
		// Token: 0x0600595A RID: 22874 RVA: 0x0033A208 File Offset: 0x00339208
		internal Stacked100PercentColumnSeries(XAxis A_0, YAxis A_1) : base(A_0, A_1)
		{
			base.DrawBehindAxis = true;
		}

		// Token: 0x0600595B RID: 22875 RVA: 0x0033A21D File Offset: 0x0033921D
		internal void a(int A_0)
		{
			this.a = A_0;
		}

		// Token: 0x0600595C RID: 22876 RVA: 0x0033A228 File Offset: 0x00339228
		internal override void id()
		{
			Stacked100PercentColumnSeriesElement[] array = this.a();
			int num = base.l();
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

		// Token: 0x0600595D RID: 22877 RVA: 0x0033A2F4 File Offset: 0x003392F4
		internal override void ie()
		{
			Stacked100PercentColumnSeriesElement[] array = this.a();
			int num = base.l();
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

		// Token: 0x0600595E RID: 22878 RVA: 0x0033A3C0 File Offset: 0x003393C0
		internal override void @if()
		{
			Stacked100PercentColumnSeriesElement[] array = this.a();
			int num = base.l();
			float[] array2 = new float[num];
			float[] array3 = new float[num];
			float[] array4 = new float[1];
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < array.Length; j++)
				{
					array4 = array[j].a().b();
					if (i < array4.Length)
					{
						array2[i] += Math.Abs(array4[i]);
						if (array4[i] < 0f)
						{
							array3[i] += array4[i];
						}
					}
				}
				if (100f * (array3[i] / array2[i]) < base.p())
				{
					base.b(100f * (array3[i] / array2[i]));
				}
			}
		}

		// Token: 0x0600595F RID: 22879 RVA: 0x0033A4D4 File Offset: 0x003394D4
		internal override void ic(PageWriter A_0)
		{
			Stacked100PercentColumnSeriesElement[] a_ = this.a();
			int a_2;
			if (this is DateTime100PercentStackedColumnSeries)
			{
				a_2 = base.PlotArea.Series.g();
			}
			else
			{
				a_2 = base.PlotArea.Series.f();
			}
			this.a(A_0, a_, this.a, a_2);
		}

		// Token: 0x06005960 RID: 22880 RVA: 0x0033A530 File Offset: 0x00339530
		internal override void ib(PageWriter A_0)
		{
			for (int i = 0; i < base.b().Count; i++)
			{
				((Stacked100PercentColumnSeriesElement)base.b()[i]).a(A_0);
			}
		}

		// Token: 0x06005961 RID: 22881 RVA: 0x0033A574 File Offset: 0x00339574
		private void a(PageWriter A_0, Stacked100PercentColumnSeriesElement[] A_1, int A_2, int A_3)
		{
			float[] array = new float[base.l()];
			float[] array2 = new float[1];
			for (int i = 0; i < array.Length; i++)
			{
				for (int j = 0; j < A_1.Length; j++)
				{
					array2 = A_1[j].a().b();
					if (i < array2.Length)
					{
						array[i] += Math.Abs(array2[i]);
					}
				}
			}
			for (int j = 0; j < A_1.Length; j++)
			{
				A_1[j].a(A_0, A_1, j, A_2, A_3, array);
			}
		}

		// Token: 0x06005962 RID: 22882 RVA: 0x0033A620 File Offset: 0x00339620
		private Stacked100PercentColumnSeriesElement[] a()
		{
			Stacked100PercentColumnSeriesElement[] array = new Stacked100PercentColumnSeriesElement[base.b().Count];
			for (int i = 0; i < base.b().Count; i++)
			{
				array[i] = (Stacked100PercentColumnSeriesElement)base.b()[i];
				array[i].a().d();
			}
			return array;
		}

		// Token: 0x04002F42 RID: 12098
		private new int a;
	}
}
