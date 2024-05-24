using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Axes;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x02000888 RID: 2184
	public abstract class Stacked100PercentAreaSeries : Stacked100PercentSeries
	{
		// Token: 0x06005902 RID: 22786 RVA: 0x00338DEB File Offset: 0x00337DEB
		internal Stacked100PercentAreaSeries(XAxis A_0, YAxis A_1) : base(A_0, A_1)
		{
			base.DrawBehindAxis = true;
		}

		// Token: 0x06005903 RID: 22787 RVA: 0x00338E00 File Offset: 0x00337E00
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
					Stacked100PercentAreaSeriesElement stacked100PercentAreaSeriesElement = (Stacked100PercentAreaSeriesElement)base.b()[j];
					num3 += stacked100PercentAreaSeriesElement.a().c(i);
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

		// Token: 0x06005904 RID: 22788 RVA: 0x00338EBC File Offset: 0x00337EBC
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
					Stacked100PercentAreaSeriesElement stacked100PercentAreaSeriesElement = (Stacked100PercentAreaSeriesElement)base.b()[j];
					num3 += stacked100PercentAreaSeriesElement.a().c(i);
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

		// Token: 0x06005905 RID: 22789 RVA: 0x00338F78 File Offset: 0x00337F78
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
					Stacked100PercentAreaSeriesElement stacked100PercentAreaSeriesElement = (Stacked100PercentAreaSeriesElement)base.b()[j];
					if (stacked100PercentAreaSeriesElement.a().c(i) < 0f)
					{
						num4 += stacked100PercentAreaSeriesElement.a().c(i) * -1f;
					}
					else
					{
						num4 += stacked100PercentAreaSeriesElement.a().c(i);
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

		// Token: 0x06005906 RID: 22790 RVA: 0x003390B4 File Offset: 0x003380B4
		internal override void ib(PageWriter A_0)
		{
			int num = 0;
			for (int i = 0; i < base.b().Count; i++)
			{
				Stacked100PercentAreaSeriesElement stacked100PercentAreaSeriesElement = (Stacked100PercentAreaSeriesElement)base.b()[i];
				if (stacked100PercentAreaSeriesElement.a().d() > num)
				{
					num = stacked100PercentAreaSeriesElement.a().d();
				}
			}
			float[] a_ = this.a(num);
			for (int i = 0; i < base.b().Count; i++)
			{
				Stacked100PercentAreaSeriesElement stacked100PercentAreaSeriesElement = (Stacked100PercentAreaSeriesElement)base.b()[i];
				if (stacked100PercentAreaSeriesElement != null)
				{
					if (stacked100PercentAreaSeriesElement.a().Count > 0)
					{
						stacked100PercentAreaSeriesElement.a(A_0, a_);
					}
				}
			}
		}

		// Token: 0x06005907 RID: 22791 RVA: 0x0033917C File Offset: 0x0033817C
		internal int a()
		{
			int num = 0;
			for (int i = 0; i < base.b().Count; i++)
			{
				Stacked100PercentAreaSeriesElement stacked100PercentAreaSeriesElement = (Stacked100PercentAreaSeriesElement)base.b()[i];
				if (stacked100PercentAreaSeriesElement.a().Count > 0)
				{
					stacked100PercentAreaSeriesElement.a().c();
					stacked100PercentAreaSeriesElement.a().e();
				}
				if (stacked100PercentAreaSeriesElement.a().d() > num)
				{
					num = stacked100PercentAreaSeriesElement.a().d();
				}
			}
			return num;
		}

		// Token: 0x06005908 RID: 22792 RVA: 0x00339218 File Offset: 0x00338218
		internal override void ic(PageWriter A_0)
		{
			int num = 0;
			for (int i = 0; i < base.b().Count; i++)
			{
				Stacked100PercentAreaSeriesElement stacked100PercentAreaSeriesElement = (Stacked100PercentAreaSeriesElement)base.b()[i];
				if (stacked100PercentAreaSeriesElement.a().Count > 0)
				{
					stacked100PercentAreaSeriesElement.a().c();
					stacked100PercentAreaSeriesElement.a().e();
				}
				if (stacked100PercentAreaSeriesElement.a().d() > num)
				{
					num = stacked100PercentAreaSeriesElement.a().d();
				}
			}
			float[] a_ = this.a(num);
			for (int i = 0; i < base.b().Count; i++)
			{
				Stacked100PercentAreaSeriesElement stacked100PercentAreaSeriesElement = (Stacked100PercentAreaSeriesElement)base.b()[i];
				Stacked100PercentAreaSeriesElement stacked100PercentAreaSeriesElement2 = null;
				if (i != 0)
				{
					stacked100PercentAreaSeriesElement2 = (Stacked100PercentAreaSeriesElement)base.b()[i - 1];
					int num2 = 2;
					while (stacked100PercentAreaSeriesElement2.a().Count <= 0)
					{
						if (i - num2 < 0)
						{
							break;
						}
						stacked100PercentAreaSeriesElement2 = (Stacked100PercentAreaSeriesElement)base.b()[i - num2];
						num2++;
					}
				}
				stacked100PercentAreaSeriesElement.a(A_0, stacked100PercentAreaSeriesElement2, a_, i, base.b());
			}
			this.a(A_0);
		}

		// Token: 0x06005909 RID: 22793 RVA: 0x00339378 File Offset: 0x00338378
		internal void a(PageWriter A_0)
		{
			for (int i = 0; i < base.b().Count; i++)
			{
				Stacked100PercentAreaSeriesElement stacked100PercentAreaSeriesElement = (Stacked100PercentAreaSeriesElement)base.b()[i];
				if (stacked100PercentAreaSeriesElement.a().Count > 0)
				{
					stacked100PercentAreaSeriesElement.a().a(stacked100PercentAreaSeriesElement.PlotArea, A_0);
				}
			}
		}

		// Token: 0x0600590A RID: 22794 RVA: 0x003393DC File Offset: 0x003383DC
		internal float[] a(int A_0)
		{
			float[] array = new float[A_0];
			for (int i = 0; i < A_0; i++)
			{
				float num = 0f;
				for (int j = 0; j < base.b().Count; j++)
				{
					Stacked100PercentAreaSeriesElement stacked100PercentAreaSeriesElement = (Stacked100PercentAreaSeriesElement)base.b()[j];
					if (stacked100PercentAreaSeriesElement.a().Count > 0)
					{
						float num2;
						if (stacked100PercentAreaSeriesElement.a().c(i) < 0f)
						{
							num2 = stacked100PercentAreaSeriesElement.a().c(i) * -1f;
						}
						else
						{
							num2 = stacked100PercentAreaSeriesElement.a().c(i);
						}
						num += num2;
					}
				}
				array[i] = num;
			}
			return array;
		}

		// Token: 0x0600590B RID: 22795 RVA: 0x003394B4 File Offset: 0x003384B4
		internal override float ig()
		{
			float num = 0f;
			for (int i = 0; i < base.b().Count; i++)
			{
				if (((PlotAreaElement)base.b()[i]) is Stacked100PercentAreaSeriesElement)
				{
					((Stacked100PercentAreaSeriesElement)base.b()[i]).a().c();
					if (num < (float)((Stacked100PercentAreaSeriesElement)base.b()[i]).a().d())
					{
						num = (float)((Stacked100PercentAreaSeriesElement)base.b()[i]).a().d();
					}
				}
			}
			return num;
		}
	}
}
