using System;
using System.Collections;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007B4 RID: 1972
	public class YAxisList
	{
		// Token: 0x06005023 RID: 20515 RVA: 0x0027EE82 File Offset: 0x0027DE82
		internal YAxisList(PlotArea A_0)
		{
			this.f = A_0;
		}

		// Token: 0x06005024 RID: 20516 RVA: 0x0027EEA0 File Offset: 0x0027DEA0
		public void Add(YAxis yAxis)
		{
			this.a(yAxis);
			if (!this.a.Contains(yAxis))
			{
				this.a.Add(yAxis);
				if (yAxis.u() == null)
				{
					yAxis.a(this.f);
				}
			}
		}

		// Token: 0x170006B6 RID: 1718
		public YAxis this[int index]
		{
			get
			{
				return (YAxis)this.a[index];
			}
		}

		// Token: 0x170006B7 RID: 1719
		// (get) Token: 0x06005026 RID: 20518 RVA: 0x0027EF18 File Offset: 0x0027DF18
		public int Count
		{
			get
			{
				return this.a.Count;
			}
		}

		// Token: 0x170006B8 RID: 1720
		// (get) Token: 0x06005027 RID: 20519 RVA: 0x0027EF38 File Offset: 0x0027DF38
		// (set) Token: 0x06005028 RID: 20520 RVA: 0x0027EF6C File Offset: 0x0027DF6C
		public NumericYAxis DefaultNumericAxis
		{
			get
			{
				if (this.b == null)
				{
					this.b = this.j();
				}
				return this.b;
			}
			set
			{
				this.b = value;
				this.Add(this.b);
			}
		}

		// Token: 0x170006B9 RID: 1721
		// (get) Token: 0x06005029 RID: 20521 RVA: 0x0027EF84 File Offset: 0x0027DF84
		// (set) Token: 0x0600502A RID: 20522 RVA: 0x0027EFB8 File Offset: 0x0027DFB8
		public IndexedYAxis DefaultIndexedAxis
		{
			get
			{
				if (this.c == null)
				{
					this.c = this.k();
				}
				return this.c;
			}
			set
			{
				this.c = value;
				this.Add(this.c);
			}
		}

		// Token: 0x170006BA RID: 1722
		// (get) Token: 0x0600502B RID: 20523 RVA: 0x0027EFD0 File Offset: 0x0027DFD0
		// (set) Token: 0x0600502C RID: 20524 RVA: 0x0027F004 File Offset: 0x0027E004
		public DateTimeYAxis DefaultDateTimeAxis
		{
			get
			{
				if (this.d == null)
				{
					this.d = this.l();
				}
				return this.d;
			}
			set
			{
				this.d = value;
				this.Add(this.d);
			}
		}

		// Token: 0x170006BB RID: 1723
		// (get) Token: 0x0600502D RID: 20525 RVA: 0x0027F01C File Offset: 0x0027E01C
		// (set) Token: 0x0600502E RID: 20526 RVA: 0x0027F050 File Offset: 0x0027E050
		public PercentageYAxis DefaultPercentageAxis
		{
			get
			{
				if (this.e == null)
				{
					this.e = this.m();
				}
				return this.e;
			}
			set
			{
				this.e = value;
				this.Add(this.e);
			}
		}

		// Token: 0x0600502F RID: 20527 RVA: 0x0027F068 File Offset: 0x0027E068
		internal ArrayList a()
		{
			return this.a;
		}

		// Token: 0x06005030 RID: 20528 RVA: 0x0027F080 File Offset: 0x0027E080
		internal bool b()
		{
			bool result = false;
			for (int i = 0; i < this.a.Count; i++)
			{
				YAxis yaxis = (YAxis)this.a[i];
				if (yaxis.Visible && yaxis.AnchorType == YAxisAnchorType.Left && yaxis.Offset <= yaxis.LineWidth / 2f)
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06005031 RID: 20529 RVA: 0x0027F0F8 File Offset: 0x0027E0F8
		internal bool c()
		{
			bool result = false;
			for (int i = 0; i < this.a.Count; i++)
			{
				YAxis yaxis = (YAxis)this.a[i];
				if (yaxis.Visible && yaxis.AnchorType == YAxisAnchorType.Right && Math.Abs(yaxis.Offset) <= yaxis.LineWidth / 2f)
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06005032 RID: 20530 RVA: 0x0027F178 File Offset: 0x0027E178
		internal float d()
		{
			float num = 0f;
			for (int i = 0; i < this.a.Count; i++)
			{
				YAxis yaxis = (YAxis)this.a[i];
				if (yaxis.AnchorType == YAxisAnchorType.Left)
				{
					if (yaxis.Offset == 0f && num < yaxis.LineWidth / 2f)
					{
						num = yaxis.LineWidth / 2f;
					}
					else if (yaxis.Offset < yaxis.LineWidth / 2f && num < yaxis.LineWidth / 2f - yaxis.Offset)
					{
						num = yaxis.LineWidth / 2f - yaxis.Offset;
					}
				}
			}
			return num;
		}

		// Token: 0x06005033 RID: 20531 RVA: 0x0027F268 File Offset: 0x0027E268
		internal float e()
		{
			float num = 0f;
			for (int i = 0; i < this.a.Count; i++)
			{
				YAxis yaxis = (YAxis)this.a[i];
				if (yaxis.AnchorType == YAxisAnchorType.Right)
				{
					if (yaxis.Offset == 0f && num < yaxis.LineWidth / 2f)
					{
						num = yaxis.LineWidth / 2f;
					}
					else if (Math.Abs(yaxis.Offset) < yaxis.LineWidth / 2f && num < yaxis.LineWidth / 2f - Math.Abs(yaxis.Offset))
					{
						num = yaxis.LineWidth / 2f - Math.Abs(yaxis.Offset);
					}
				}
			}
			return num;
		}

		// Token: 0x06005034 RID: 20532 RVA: 0x0027F364 File Offset: 0x0027E364
		internal void f()
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				YAxis yaxis = (YAxis)this.a[i];
				yaxis.iw();
				yaxis.i();
			}
		}

		// Token: 0x06005035 RID: 20533 RVA: 0x0027F3B0 File Offset: 0x0027E3B0
		internal float g()
		{
			float num = 0f;
			for (int i = 0; i < this.a.Count; i++)
			{
				YAxis yaxis = (YAxis)this.a[i];
				YAxisLabelList yaxisLabelList = (YAxisLabelList)yaxis.r();
				float num2 = yaxisLabelList.j();
				if (num < num2)
				{
					num = num2;
				}
			}
			return num;
		}

		// Token: 0x06005036 RID: 20534 RVA: 0x0027F428 File Offset: 0x0027E428
		internal float h()
		{
			float num = 0f;
			for (int i = 0; i < this.a.Count; i++)
			{
				YAxis yaxis = (YAxis)this.a[i];
				YAxisLabelList yaxisLabelList = (YAxisLabelList)yaxis.r();
				float num2 = yaxisLabelList.ix();
				if (num < num2)
				{
					num = num2;
				}
			}
			return num;
		}

		// Token: 0x06005037 RID: 20535 RVA: 0x0027F4A0 File Offset: 0x0027E4A0
		internal YAxis i()
		{
			YAxis result = null;
			if (this.b != null)
			{
				result = this.b;
			}
			else if (this.c != null)
			{
				result = this.c;
			}
			else if (this.d != null)
			{
				result = this.d;
			}
			else if (this.e != null)
			{
				result = this.e;
			}
			else if (this.a.Count != 0)
			{
				result = (YAxis)this.a[0];
			}
			return result;
		}

		// Token: 0x06005038 RID: 20536 RVA: 0x0027F534 File Offset: 0x0027E534
		internal NumericYAxis j()
		{
			NumericYAxis result;
			if (this.b != null)
			{
				result = this.b;
			}
			else
			{
				YAxis yaxis = null;
				for (int i = 0; i < this.a.Count; i++)
				{
					yaxis = (YAxis)this.a[i];
					if (yaxis is NumericYAxis)
					{
						return (NumericYAxis)yaxis;
					}
				}
				if (!(yaxis is NumericYAxis))
				{
					NumericYAxis numericYAxis = new NumericYAxis();
					this.Add(numericYAxis);
					result = numericYAxis;
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		// Token: 0x06005039 RID: 20537 RVA: 0x0027F5D0 File Offset: 0x0027E5D0
		internal IndexedYAxis k()
		{
			IndexedYAxis result;
			if (this.c != null)
			{
				result = this.c;
			}
			else
			{
				YAxis yaxis = null;
				for (int i = 0; i < this.a.Count; i++)
				{
					yaxis = (YAxis)this.a[i];
					if (yaxis is IndexedYAxis)
					{
						return (IndexedYAxis)yaxis;
					}
				}
				if (!(yaxis is IndexedYAxis))
				{
					IndexedYAxis indexedYAxis = new IndexedYAxis();
					this.Add(indexedYAxis);
					result = indexedYAxis;
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		// Token: 0x0600503A RID: 20538 RVA: 0x0027F66C File Offset: 0x0027E66C
		internal DateTimeYAxis l()
		{
			DateTimeYAxis result;
			if (this.d != null)
			{
				result = this.d;
			}
			else
			{
				YAxis yaxis = null;
				for (int i = 0; i < this.a.Count; i++)
				{
					yaxis = (YAxis)this.a[i];
					if (yaxis is DateTimeYAxis)
					{
						return (DateTimeYAxis)yaxis;
					}
				}
				if (!(yaxis is DateTimeYAxis))
				{
					DateTimeYAxis dateTimeYAxis = new DateTimeYAxis();
					this.Add(dateTimeYAxis);
					result = dateTimeYAxis;
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		// Token: 0x0600503B RID: 20539 RVA: 0x0027F708 File Offset: 0x0027E708
		internal PercentageYAxis m()
		{
			PercentageYAxis result;
			if (this.e != null)
			{
				result = this.e;
			}
			else
			{
				YAxis yaxis = null;
				for (int i = 0; i < this.a.Count; i++)
				{
					yaxis = (YAxis)this.a[i];
					if (yaxis is PercentageYAxis)
					{
						return (PercentageYAxis)yaxis;
					}
				}
				if (!(yaxis is PercentageYAxis))
				{
					PercentageYAxis percentageYAxis = new PercentageYAxis();
					this.Add(percentageYAxis);
					result = percentageYAxis;
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		// Token: 0x0600503C RID: 20540 RVA: 0x0027F7A4 File Offset: 0x0027E7A4
		private void a(YAxis A_0)
		{
			bool flag = false;
			PlotAreaList plotAreas = this.f.Chart.PlotAreas;
			for (int i = 0; i < plotAreas.Count; i++)
			{
				PlotArea plotArea = plotAreas[i];
				if (!plotArea.Equals(this.f))
				{
					if (plotArea.YAxes.a().Contains(A_0))
					{
						flag = true;
					}
				}
			}
			if (flag)
			{
				throw new GeneratorException("Same YAxis is already present in another plotArea's YAxesList..");
			}
		}

		// Token: 0x0600503D RID: 20541 RVA: 0x0027F82C File Offset: 0x0027E82C
		internal void a(PageWriter A_0)
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				YAxis yaxis = (YAxis)this.a[i];
				yaxis.a(A_0);
			}
		}

		// Token: 0x0600503E RID: 20542 RVA: 0x0027F874 File Offset: 0x0027E874
		internal void b(PageWriter A_0)
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				YAxis yaxis = (YAxis)this.a[i];
				yaxis.b(A_0);
			}
		}

		// Token: 0x0600503F RID: 20543 RVA: 0x0027F8BC File Offset: 0x0027E8BC
		internal void c(PageWriter A_0)
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				YAxis yaxis = (YAxis)this.a[i];
				yaxis.c(A_0);
			}
		}

		// Token: 0x04002B33 RID: 11059
		private ArrayList a = new ArrayList();

		// Token: 0x04002B34 RID: 11060
		private NumericYAxis b;

		// Token: 0x04002B35 RID: 11061
		private IndexedYAxis c;

		// Token: 0x04002B36 RID: 11062
		private DateTimeYAxis d;

		// Token: 0x04002B37 RID: 11063
		private PercentageYAxis e;

		// Token: 0x04002B38 RID: 11064
		private PlotArea f;
	}
}
