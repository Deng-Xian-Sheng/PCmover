using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Axes;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x02000895 RID: 2197
	public abstract class Stacked100PercentLineSeries : Stacked100PercentSeries
	{
		// Token: 0x06005986 RID: 22918 RVA: 0x0033AA9C File Offset: 0x00339A9C
		internal Stacked100PercentLineSeries(XAxis A_0, YAxis A_1) : base(A_0, A_1)
		{
			base.DrawBehindAxis = false;
		}

		// Token: 0x06005987 RID: 22919 RVA: 0x0033AAB4 File Offset: 0x00339AB4
		internal int a()
		{
			int num = 0;
			for (int i = 0; i < base.b().Count; i++)
			{
				Stacked100PercentLineSeriesElement stacked100PercentLineSeriesElement = (Stacked100PercentLineSeriesElement)base.b()[i];
				if (stacked100PercentLineSeriesElement.c().Count > 0)
				{
					stacked100PercentLineSeriesElement.c().d();
				}
				if (stacked100PercentLineSeriesElement.c().f() > num)
				{
					num = stacked100PercentLineSeriesElement.c().f();
				}
			}
			return num;
		}

		// Token: 0x06005988 RID: 22920 RVA: 0x0033AB40 File Offset: 0x00339B40
		internal override void id()
		{
			int num = this.a();
			float[] array = new float[num];
			for (int i = 0; i < num; i++)
			{
				float num2 = 0f;
				float num3 = 0f;
				for (int j = 0; j < base.b().Count; j++)
				{
					Stacked100PercentLineSeriesElement stacked100PercentLineSeriesElement = (Stacked100PercentLineSeriesElement)base.b()[j];
					num3 += stacked100PercentLineSeriesElement.c().c(i);
					if (num3 < num2)
					{
						num2 = num3;
					}
				}
				array[i] = num2;
			}
			if (num > 0)
			{
				Array.Sort<float>(array);
				base.b(array[0]);
			}
		}

		// Token: 0x06005989 RID: 22921 RVA: 0x0033ABFC File Offset: 0x00339BFC
		internal override void ie()
		{
			int num = this.a();
			float[] array = new float[num];
			for (int i = 0; i < num; i++)
			{
				float num2 = 0f;
				float num3 = 0f;
				for (int j = 0; j < base.b().Count; j++)
				{
					Stacked100PercentLineSeriesElement stacked100PercentLineSeriesElement = (Stacked100PercentLineSeriesElement)base.b()[j];
					num3 += stacked100PercentLineSeriesElement.c().c(i);
					if (num3 > num2)
					{
						num2 = num3;
					}
				}
				array[i] = num2;
			}
			if (num > 0)
			{
				Array.Sort<float>(array);
				base.a(array[num - 1]);
			}
		}

		// Token: 0x0600598A RID: 22922 RVA: 0x0033ACB8 File Offset: 0x00339CB8
		internal override void @if()
		{
			int num = this.a();
			float[] array = new float[num];
			float[] array2 = new float[num];
			for (int i = 0; i < num; i++)
			{
				float num2 = 0f;
				float num3 = 0f;
				float num4 = 0f;
				for (int j = 0; j < base.b().Count; j++)
				{
					Stacked100PercentLineSeriesElement stacked100PercentLineSeriesElement = (Stacked100PercentLineSeriesElement)base.b()[j];
					if (stacked100PercentLineSeriesElement.c().c(i) < 0f)
					{
						num4 += stacked100PercentLineSeriesElement.c().c(i) * -1f;
					}
					else
					{
						num4 += stacked100PercentLineSeriesElement.c().c(i);
					}
					if (num4 < num3)
					{
						num3 = num4;
					}
					if (num4 > num2)
					{
						num2 = num4;
					}
				}
				array[i] = num3;
				array2[i] = num2;
				if (100f * (array[i] / array2[i]) < base.p())
				{
					base.b(100f * (array[i] / array2[i]));
				}
			}
		}

		// Token: 0x0600598B RID: 22923 RVA: 0x0033ADF4 File Offset: 0x00339DF4
		internal override void ic(PageWriter A_0)
		{
			int num = 0;
			for (int i = 0; i < base.b().Count; i++)
			{
				Stacked100PercentLineSeriesElement stacked100PercentLineSeriesElement = (Stacked100PercentLineSeriesElement)base.b()[i];
				if (stacked100PercentLineSeriesElement.c().Count > 0)
				{
					stacked100PercentLineSeriesElement.c().d();
					stacked100PercentLineSeriesElement.c().c();
				}
				if (stacked100PercentLineSeriesElement.c().f() > num)
				{
					num = stacked100PercentLineSeriesElement.c().f();
				}
			}
			float[] a_ = this.a(num);
			for (int i = 0; i < base.b().Count; i++)
			{
				if (i != 0)
				{
					((Stacked100PercentLineSeriesElement)base.b()[i]).a(A_0, a_, i, base.b());
				}
				else
				{
					((Stacked100PercentLineSeriesElement)base.b()[i]).a(A_0, a_, i, base.b());
				}
			}
		}

		// Token: 0x0600598C RID: 22924 RVA: 0x0033AEFC File Offset: 0x00339EFC
		internal float[] a(int A_0)
		{
			float[] array = new float[A_0];
			for (int i = 0; i < A_0; i++)
			{
				float num = 0f;
				for (int j = 0; j < base.b().Count; j++)
				{
					Stacked100PercentLineSeriesElement stacked100PercentLineSeriesElement = (Stacked100PercentLineSeriesElement)base.b()[j];
					float num2;
					if (stacked100PercentLineSeriesElement.c().c(i) < 0f)
					{
						num2 = stacked100PercentLineSeriesElement.c().c(i) * -1f;
					}
					else
					{
						num2 = stacked100PercentLineSeriesElement.c().c(i);
					}
					num += num2;
				}
				array[i] = num;
			}
			return array;
		}

		// Token: 0x0600598D RID: 22925 RVA: 0x0033AFB8 File Offset: 0x00339FB8
		internal override void ib(PageWriter A_0)
		{
			int num = 0;
			for (int i = 0; i < base.b().Count; i++)
			{
				Stacked100PercentLineSeriesElement stacked100PercentLineSeriesElement = (Stacked100PercentLineSeriesElement)base.b()[i];
				if (stacked100PercentLineSeriesElement.c().f() > num)
				{
					num = stacked100PercentLineSeriesElement.c().f();
				}
			}
			float[] a_ = this.a(num);
			for (int i = 0; i < base.b().Count; i++)
			{
				Stacked100PercentLineSeriesElement stacked100PercentLineSeriesElement = (Stacked100PercentLineSeriesElement)base.b()[i];
				if (stacked100PercentLineSeriesElement != null)
				{
					if (stacked100PercentLineSeriesElement.c().Count > 0)
					{
						stacked100PercentLineSeriesElement.a(A_0, a_);
					}
				}
			}
		}

		// Token: 0x0600598E RID: 22926 RVA: 0x0033B080 File Offset: 0x0033A080
		internal override float ig()
		{
			float num = 0f;
			for (int i = 0; i < base.b().Count; i++)
			{
				if (((SeriesElement)base.b()[i]) is Stacked100PercentLineSeriesElement)
				{
					((Stacked100PercentLineSeriesElement)base.b()[i]).c().d();
					if (num < (float)((Stacked100PercentLineSeriesElement)base.b()[i]).c().f())
					{
						num = (float)((Stacked100PercentLineSeriesElement)base.b()[i]).c().f();
					}
				}
			}
			return num;
		}
	}
}
