using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Axes;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008AB RID: 2219
	public abstract class StackedLineSeries : StackedSeries
	{
		// Token: 0x06005A8D RID: 23181 RVA: 0x0033D824 File Offset: 0x0033C824
		internal StackedLineSeries(XAxis A_0, YAxis A_1) : base(A_0, A_1, false)
		{
			base.DrawBehindAxis = false;
		}

		// Token: 0x06005A8E RID: 23182 RVA: 0x0033D83C File Offset: 0x0033C83C
		internal int a()
		{
			int num = 0;
			for (int i = 0; i < base.b().Count; i++)
			{
				StackedLineSeriesElement stackedLineSeriesElement = (StackedLineSeriesElement)base.b()[i];
				if (stackedLineSeriesElement.c().Count > 0)
				{
					stackedLineSeriesElement.c().d();
				}
				if (stackedLineSeriesElement.c().e() > num)
				{
					num = stackedLineSeriesElement.c().e();
				}
			}
			return num;
		}

		// Token: 0x06005A8F RID: 23183 RVA: 0x0033D8C8 File Offset: 0x0033C8C8
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
					StackedLineSeriesElement stackedLineSeriesElement = (StackedLineSeriesElement)base.b()[j];
					num3 += stackedLineSeriesElement.c().c(i);
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

		// Token: 0x06005A90 RID: 23184 RVA: 0x0033D984 File Offset: 0x0033C984
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
					StackedLineSeriesElement stackedLineSeriesElement = (StackedLineSeriesElement)base.b()[j];
					num3 += stackedLineSeriesElement.c().c(i);
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

		// Token: 0x06005A91 RID: 23185 RVA: 0x0033DA40 File Offset: 0x0033CA40
		internal override void ic(PageWriter A_0)
		{
			int num = 0;
			for (int i = 0; i < base.b().Count; i++)
			{
				StackedLineSeriesElement stackedLineSeriesElement = (StackedLineSeriesElement)base.b()[i];
				if (stackedLineSeriesElement.c().Count > 0)
				{
					stackedLineSeriesElement.c().d();
					stackedLineSeriesElement.c().c();
				}
				if (stackedLineSeriesElement.c().e() > num)
				{
					num = stackedLineSeriesElement.c().e();
				}
			}
			for (int i = 0; i < base.b().Count; i++)
			{
				if (i != 0)
				{
					((StackedLineSeriesElement)base.b()[i]).a(A_0, i, base.b());
				}
				else
				{
					((StackedLineSeriesElement)base.b()[i]).a(A_0, i, base.b());
				}
			}
		}

		// Token: 0x06005A92 RID: 23186 RVA: 0x0033DB34 File Offset: 0x0033CB34
		internal float[] a(int A_0)
		{
			float[] array = new float[A_0];
			for (int i = 0; i < A_0; i++)
			{
				float num = 0f;
				for (int j = 0; j < base.b().Count; j++)
				{
					StackedLineSeriesElement stackedLineSeriesElement = (StackedLineSeriesElement)base.b()[j];
					float num2;
					if (stackedLineSeriesElement.c().c(i) < 0f)
					{
						num2 = stackedLineSeriesElement.c().c(i) * -1f;
					}
					else
					{
						num2 = stackedLineSeriesElement.c().c(i);
					}
					num += num2;
				}
				array[i] = num;
			}
			return array;
		}

		// Token: 0x06005A93 RID: 23187 RVA: 0x0033DBF0 File Offset: 0x0033CBF0
		internal override void ib(PageWriter A_0)
		{
			int num = 0;
			for (int i = 0; i < base.b().Count; i++)
			{
				StackedLineSeriesElement stackedLineSeriesElement = (StackedLineSeriesElement)base.b()[i];
				if (stackedLineSeriesElement.c().e() > num)
				{
					num = stackedLineSeriesElement.c().e();
				}
			}
			for (int i = 0; i < base.b().Count; i++)
			{
				StackedLineSeriesElement stackedLineSeriesElement = (StackedLineSeriesElement)base.b()[i];
				if (stackedLineSeriesElement != null)
				{
					if (stackedLineSeriesElement.c().Count > 0)
					{
						stackedLineSeriesElement.a(A_0);
					}
				}
			}
		}

		// Token: 0x06005A94 RID: 23188 RVA: 0x0033DCA4 File Offset: 0x0033CCA4
		internal override float ig()
		{
			float num = 0f;
			for (int i = 0; i < base.b().Count; i++)
			{
				if (((SeriesElement)base.b()[i]) is StackedLineSeriesElement)
				{
					((StackedLineSeriesElement)base.b()[i]).c().d();
					if (num < (float)((StackedLineSeriesElement)base.b()[i]).c().e())
					{
						num = (float)((StackedLineSeriesElement)base.b()[i]).c().e();
					}
				}
			}
			return num;
		}
	}
}
