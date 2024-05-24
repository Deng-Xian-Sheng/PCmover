using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Axes;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x0200088D RID: 2189
	public abstract class Stacked100PercentBarSeries : Stacked100PercentSeries
	{
		// Token: 0x0600592E RID: 22830 RVA: 0x0033996D File Offset: 0x0033896D
		internal Stacked100PercentBarSeries(XAxis A_0, YAxis A_1) : base(A_0, A_1)
		{
			base.DrawBehindAxis = true;
		}

		// Token: 0x0600592F RID: 22831 RVA: 0x00339982 File Offset: 0x00338982
		internal void a(int A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06005930 RID: 22832 RVA: 0x0033998C File Offset: 0x0033898C
		internal override void id()
		{
			Stacked100PercentBarSeriesElement[] array = this.a();
			int num = base.l();
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

		// Token: 0x06005931 RID: 22833 RVA: 0x00339A58 File Offset: 0x00338A58
		internal override void ie()
		{
			Stacked100PercentBarSeriesElement[] array = this.a();
			int num = base.l();
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

		// Token: 0x06005932 RID: 22834 RVA: 0x00339B24 File Offset: 0x00338B24
		internal override void @if()
		{
			Stacked100PercentBarSeriesElement[] array = this.a();
			int num = base.l();
			float[] array2 = new float[num];
			float[] array3 = new float[num];
			float[] array4 = new float[1];
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < array.Length; j++)
				{
					array4 = array[j].a().c();
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

		// Token: 0x06005933 RID: 22835 RVA: 0x00339C38 File Offset: 0x00338C38
		internal override void ic(PageWriter A_0)
		{
			Stacked100PercentBarSeriesElement[] a_ = this.a();
			int a_2;
			if (this is DateTime100PercentStackedBarSeries)
			{
				a_2 = base.PlotArea.Series.i();
			}
			else
			{
				a_2 = base.PlotArea.Series.h();
			}
			this.a(A_0, a_, this.a, a_2);
		}

		// Token: 0x06005934 RID: 22836 RVA: 0x00339C94 File Offset: 0x00338C94
		internal override void ib(PageWriter A_0)
		{
			for (int i = 0; i < base.b().Count; i++)
			{
				((Stacked100PercentBarSeriesElement)base.b()[i]).a(A_0);
			}
		}

		// Token: 0x06005935 RID: 22837 RVA: 0x00339CD8 File Offset: 0x00338CD8
		private void a(PageWriter A_0, Stacked100PercentBarSeriesElement[] A_1, int A_2, int A_3)
		{
			float[] array = new float[base.l()];
			float[] array2 = new float[1];
			for (int i = 0; i < array.Length; i++)
			{
				for (int j = 0; j < A_1.Length; j++)
				{
					array2 = A_1[j].a().c();
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

		// Token: 0x06005936 RID: 22838 RVA: 0x00339D84 File Offset: 0x00338D84
		private Stacked100PercentBarSeriesElement[] a()
		{
			Stacked100PercentBarSeriesElement[] array = new Stacked100PercentBarSeriesElement[base.b().Count];
			for (int i = 0; i < base.b().Count; i++)
			{
				array[i] = (Stacked100PercentBarSeriesElement)base.b()[i];
				array[i].a().d();
			}
			return array;
		}

		// Token: 0x04002F39 RID: 12089
		private new int a;
	}
}
