using System;
using System.Collections;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF.PageElements.Charting
{
	// Token: 0x020007AC RID: 1964
	public class PlotAreaList
	{
		// Token: 0x06004FA0 RID: 20384 RVA: 0x0027C3D2 File Offset: 0x0027B3D2
		internal PlotAreaList(Chart A_0)
		{
			this.b = A_0;
			this.a = new ArrayList();
		}

		// Token: 0x06004FA1 RID: 20385 RVA: 0x0027C3F0 File Offset: 0x0027B3F0
		public PlotArea Add(float x, float y, float width, float height)
		{
			PlotArea plotArea = new PlotArea(x, y, width, height);
			this.a.Add(plotArea);
			plotArea.a(this.b);
			if (this.a.Count == 1)
			{
				this.c = plotArea;
			}
			return plotArea;
		}

		// Token: 0x06004FA2 RID: 20386 RVA: 0x0027C444 File Offset: 0x0027B444
		internal PlotArea a()
		{
			if (this.c == null)
			{
				float num = this.b.Width / 4f;
				float num2 = this.b.Height / 4f;
				this.c = new PlotArea(this.b.X + num, this.b.Y + num2, this.b.Width / 2f, this.b.Height / 2f);
				this.c.a(this.b);
				this.a.Add(this.c);
			}
			return this.c;
		}

		// Token: 0x17000692 RID: 1682
		public PlotArea this[int index]
		{
			get
			{
				return (PlotArea)this.a[index];
			}
		}

		// Token: 0x17000693 RID: 1683
		// (get) Token: 0x06004FA4 RID: 20388 RVA: 0x0027C524 File Offset: 0x0027B524
		public int Count
		{
			get
			{
				return this.a.Count;
			}
		}

		// Token: 0x06004FA5 RID: 20389 RVA: 0x0027C544 File Offset: 0x0027B544
		internal void b()
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				PlotArea plotArea = (PlotArea)this.a[i];
				if (plotArea.Series.a() > 0f)
				{
					plotArea.Series.l();
				}
			}
		}

		// Token: 0x06004FA6 RID: 20390 RVA: 0x0027C5A8 File Offset: 0x0027B5A8
		internal float c()
		{
			float num = 0f;
			for (int i = 0; i < this.a.Count; i++)
			{
				PlotArea plotArea = (PlotArea)this.a[i];
				float num2 = plotArea.XAxes.f();
				if (num < num2)
				{
					num = num2;
				}
			}
			return num;
		}

		// Token: 0x06004FA7 RID: 20391 RVA: 0x0027C618 File Offset: 0x0027B618
		internal float d()
		{
			float num = 0f;
			for (int i = 0; i < this.a.Count; i++)
			{
				PlotArea plotArea = (PlotArea)this.a[i];
				float num2 = plotArea.XAxes.e();
				if (num < num2)
				{
					num = num2;
				}
			}
			return num;
		}

		// Token: 0x06004FA8 RID: 20392 RVA: 0x0027C688 File Offset: 0x0027B688
		internal void a(float A_0, float[] A_1, float[] A_2, float A_3, float A_4)
		{
			float num = 0f;
			for (int i = 0; i < this.a.Count; i++)
			{
				PlotArea plotArea = (PlotArea)this.a[i];
				num += A_1[i];
				plotArea.X = A_0;
				plotArea.Y = num;
				plotArea.Width = A_3;
				plotArea.Height = A_4;
				num += A_2[i] + A_4;
			}
		}

		// Token: 0x06004FA9 RID: 20393 RVA: 0x0027C700 File Offset: 0x0027B700
		internal void a(PageWriter A_0)
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				PlotArea plotArea = (PlotArea)this.a[i];
				if (plotArea.Chart.AutoLayout)
				{
					if (plotArea.Width <= 0f)
					{
						plotArea.Width = plotArea.Chart.Width / 2f;
						plotArea.X = plotArea.Chart.X + plotArea.Chart.Width / 2f;
					}
					if (plotArea.Height <= 0f)
					{
						plotArea.Height = plotArea.Chart.Height / 2f;
						plotArea.Y = plotArea.Chart.Y + plotArea.Chart.Height / 2f;
					}
				}
				if (plotArea.Width <= 0f || plotArea.Height <= 0f)
				{
					throw new GeneratorException("width and height of the PlotArea should be greater than 0");
				}
				plotArea.Draw(A_0);
			}
		}

		// Token: 0x04002B05 RID: 11013
		private ArrayList a;

		// Token: 0x04002B06 RID: 11014
		private Chart b;

		// Token: 0x04002B07 RID: 11015
		private PlotArea c;
	}
}
