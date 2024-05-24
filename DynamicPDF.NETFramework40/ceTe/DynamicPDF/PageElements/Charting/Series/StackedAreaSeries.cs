using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Axes;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x0200089E RID: 2206
	public abstract class StackedAreaSeries : StackedSeries
	{
		// Token: 0x06005A11 RID: 23057 RVA: 0x0033C0F5 File Offset: 0x0033B0F5
		internal StackedAreaSeries(XAxis A_0, YAxis A_1) : base(A_0, A_1, false)
		{
			base.DrawBehindAxis = true;
		}

		// Token: 0x06005A12 RID: 23058 RVA: 0x0033C10C File Offset: 0x0033B10C
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
					StackedAreaSeriesElement stackedAreaSeriesElement = (StackedAreaSeriesElement)base.b()[j];
					num3 += stackedAreaSeriesElement.a().c(i);
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

		// Token: 0x06005A13 RID: 23059 RVA: 0x0033C1C8 File Offset: 0x0033B1C8
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
					StackedAreaSeriesElement stackedAreaSeriesElement = (StackedAreaSeriesElement)base.b()[j];
					num3 += stackedAreaSeriesElement.a().c(i);
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

		// Token: 0x06005A14 RID: 23060 RVA: 0x0033C284 File Offset: 0x0033B284
		internal override void ib(PageWriter A_0)
		{
			int num = 0;
			for (int i = 0; i < base.b().Count; i++)
			{
				StackedAreaSeriesElement stackedAreaSeriesElement = (StackedAreaSeriesElement)base.b()[i];
				if (stackedAreaSeriesElement.a().d() > num)
				{
					num = stackedAreaSeriesElement.a().d();
				}
			}
			for (int i = 0; i < base.b().Count; i++)
			{
				StackedAreaSeriesElement stackedAreaSeriesElement = (StackedAreaSeriesElement)base.b()[i];
				if (stackedAreaSeriesElement != null)
				{
					if (stackedAreaSeriesElement.a().Count > 0)
					{
						stackedAreaSeriesElement.a(A_0);
					}
				}
			}
		}

		// Token: 0x06005A15 RID: 23061 RVA: 0x0033C338 File Offset: 0x0033B338
		internal int a()
		{
			int num = 0;
			for (int i = 0; i < base.b().Count; i++)
			{
				StackedAreaSeriesElement stackedAreaSeriesElement = (StackedAreaSeriesElement)base.b()[i];
				if (stackedAreaSeriesElement.a().Count > 0)
				{
					stackedAreaSeriesElement.a().c();
					stackedAreaSeriesElement.a().e();
				}
				if (stackedAreaSeriesElement.a().d() > num)
				{
					num = stackedAreaSeriesElement.a().d();
				}
			}
			return num;
		}

		// Token: 0x06005A16 RID: 23062 RVA: 0x0033C3D4 File Offset: 0x0033B3D4
		internal override void ic(PageWriter A_0)
		{
			int num = 0;
			for (int i = 0; i < base.b().Count; i++)
			{
				StackedAreaSeriesElement stackedAreaSeriesElement = (StackedAreaSeriesElement)base.b()[i];
				if (stackedAreaSeriesElement.a().Count > 0)
				{
					stackedAreaSeriesElement.a().c();
					stackedAreaSeriesElement.a().e();
				}
				if (stackedAreaSeriesElement.a().d() > num)
				{
					num = stackedAreaSeriesElement.a().d();
				}
			}
			for (int i = 0; i < base.b().Count; i++)
			{
				StackedAreaSeriesElement stackedAreaSeriesElement = (StackedAreaSeriesElement)base.b()[i];
				StackedAreaSeriesElement stackedAreaSeriesElement2 = null;
				if (i != 0)
				{
					stackedAreaSeriesElement2 = (StackedAreaSeriesElement)base.b()[i - 1];
					int num2 = 2;
					while (stackedAreaSeriesElement2.a().Count <= 0)
					{
						if (i - num2 < 0)
						{
							break;
						}
						stackedAreaSeriesElement2 = (StackedAreaSeriesElement)base.b()[i - num2];
						num2++;
					}
				}
				stackedAreaSeriesElement.a(A_0, stackedAreaSeriesElement2, i, base.b());
			}
			this.a(A_0);
		}

		// Token: 0x06005A17 RID: 23063 RVA: 0x0033C524 File Offset: 0x0033B524
		internal void a(PageWriter A_0)
		{
			for (int i = 0; i < base.b().Count; i++)
			{
				StackedAreaSeriesElement stackedAreaSeriesElement = (StackedAreaSeriesElement)base.b()[i];
				if (stackedAreaSeriesElement.a().Count > 0)
				{
					stackedAreaSeriesElement.a().a(stackedAreaSeriesElement.PlotArea, A_0);
				}
			}
		}

		// Token: 0x06005A18 RID: 23064 RVA: 0x0033C588 File Offset: 0x0033B588
		internal override float ig()
		{
			float num = 0f;
			for (int i = 0; i < base.b().Count; i++)
			{
				if (((PlotAreaElement)base.b()[i]) is StackedAreaSeriesElement)
				{
					((StackedAreaSeriesElement)base.b()[i]).a().c();
					if (num < (float)((StackedAreaSeriesElement)base.b()[i]).a().d())
					{
						num = (float)((StackedAreaSeriesElement)base.b()[i]).a().d();
					}
				}
			}
			return num;
		}
	}
}
