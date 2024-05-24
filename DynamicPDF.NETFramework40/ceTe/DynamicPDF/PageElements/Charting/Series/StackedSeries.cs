using System;
using System.Collections;
using ceTe.DynamicPDF.PageElements.Charting.Axes;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x02000886 RID: 2182
	public abstract class StackedSeries : XYSeries
	{
		// Token: 0x060058EF RID: 22767 RVA: 0x003385DC File Offset: 0x003375DC
		internal StackedSeries(XAxis A_0, YAxis A_1, bool A_2) : base(A_0, A_1)
		{
			this.b = A_2;
			this.a = new ArrayList();
		}

		// Token: 0x170008F4 RID: 2292
		// (get) Token: 0x060058F0 RID: 22768 RVA: 0x00338604 File Offset: 0x00337604
		public int Count
		{
			get
			{
				return this.a.Count;
			}
		}

		// Token: 0x060058F1 RID: 22769 RVA: 0x00338624 File Offset: 0x00337624
		internal object b(int A_0)
		{
			return this.a[A_0];
		}

		// Token: 0x060058F2 RID: 22770 RVA: 0x00338644 File Offset: 0x00337644
		internal void a(StackedSeriesElementBase A_0)
		{
			if (!this.a.Contains(A_0))
			{
				this.a.Add(A_0);
				this.i();
				this.j();
				return;
			}
			throw new GeneratorException("Same StackedSeriesElement can't be added more than once.");
		}

		// Token: 0x060058F3 RID: 22771 RVA: 0x0033868C File Offset: 0x0033768C
		internal ArrayList b()
		{
			return this.a;
		}

		// Token: 0x060058F4 RID: 22772
		internal abstract void id();

		// Token: 0x060058F5 RID: 22773
		internal abstract void ie();

		// Token: 0x060058F6 RID: 22774 RVA: 0x003386A4 File Offset: 0x003376A4
		internal void c()
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				StackedSeriesElementBase stackedSeriesElementBase = (StackedSeriesElementBase)this.a[i];
				if (stackedSeriesElementBase.i3() < this.iz())
				{
					this.i0(stackedSeriesElementBase.i3());
				}
			}
		}

		// Token: 0x060058F7 RID: 22775 RVA: 0x00338704 File Offset: 0x00337704
		internal void d()
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				StackedSeriesElementBase stackedSeriesElementBase = (StackedSeriesElementBase)this.a[i];
				if (stackedSeriesElementBase.i1() > this.ig())
				{
					this.iy(stackedSeriesElementBase.i1());
				}
			}
		}

		// Token: 0x060058F8 RID: 22776 RVA: 0x00338764 File Offset: 0x00337764
		internal void e()
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				StackedSeriesElementBase stackedSeriesElementBase = (StackedSeriesElementBase)this.a[i];
				if (stackedSeriesElementBase.@in() != DateTime.MinValue)
				{
					this.ik(stackedSeriesElementBase.@in());
				}
			}
		}

		// Token: 0x060058F9 RID: 22777 RVA: 0x003387C8 File Offset: 0x003377C8
		internal void f()
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				StackedSeriesElementBase stackedSeriesElementBase = (StackedSeriesElementBase)this.a[i];
				if (stackedSeriesElementBase.il() != DateTime.MinValue)
				{
					this.ii(stackedSeriesElementBase.il());
				}
			}
		}

		// Token: 0x060058FA RID: 22778 RVA: 0x0033882C File Offset: 0x0033782C
		internal void g()
		{
			if (this is StackedBarSeries || this is Stacked100PercentBarSeries)
			{
				if (this.b)
				{
					base.a(base.PlotArea.XAxes.j());
				}
				else
				{
					base.a(base.PlotArea.XAxes.h());
				}
			}
			else if (base.PlotArea.Series.b(this))
			{
				base.a(base.PlotArea.XAxes.k());
			}
			else
			{
				base.a(base.PlotArea.XAxes.i());
			}
		}

		// Token: 0x060058FB RID: 22779 RVA: 0x003388E4 File Offset: 0x003378E4
		internal void h()
		{
			if (this is StackedBarSeries || this is Stacked100PercentBarSeries)
			{
				if (base.PlotArea.Series.b(this))
				{
					base.a(base.PlotArea.YAxes.l());
				}
				else
				{
					base.a(base.PlotArea.YAxes.k());
				}
			}
			else if (this.b)
			{
				base.a(base.PlotArea.YAxes.m());
			}
			else
			{
				base.a(base.PlotArea.YAxes.j());
			}
		}

		// Token: 0x060058FC RID: 22780 RVA: 0x0033899C File Offset: 0x0033799C
		internal void i()
		{
			if (base.m() != null && base.PlotArea != null)
			{
				base.PlotArea.XAxes.Add(base.m());
			}
			if (base.n() != null && base.PlotArea != null)
			{
				base.PlotArea.YAxes.Add(base.n());
			}
			for (int i = 0; i < this.a.Count; i++)
			{
				StackedSeriesElementBase stackedSeriesElementBase = (StackedSeriesElementBase)this.a[i];
				if (this.b)
				{
					if (stackedSeriesElementBase is StackedBarSeriesElement)
					{
						if (base.m() != null)
						{
							stackedSeriesElementBase.a(base.m());
						}
						if (base.n() != null && stackedSeriesElementBase.e() != base.n())
						{
							stackedSeriesElementBase.a(base.n());
						}
					}
					else
					{
						if (base.n() != null)
						{
							stackedSeriesElementBase.a(base.n());
						}
						if (base.m() != null && stackedSeriesElementBase.d() != base.m())
						{
							stackedSeriesElementBase.a(base.m());
						}
					}
				}
				else
				{
					if (base.m() != null && stackedSeriesElementBase.d() != base.m())
					{
						stackedSeriesElementBase.a(base.m());
					}
					if (base.n() != null && stackedSeriesElementBase.e() != base.n())
					{
						stackedSeriesElementBase.a(base.n());
					}
				}
			}
		}

		// Token: 0x060058FD RID: 22781 RVA: 0x00338B4C File Offset: 0x00337B4C
		internal void j()
		{
			if (base.Legend == null)
			{
				for (int i = 0; i < this.a.Count; i++)
				{
					StackedSeriesElementBase stackedSeriesElementBase = (StackedSeriesElementBase)this.a[i];
					if (stackedSeriesElementBase.Legend != null)
					{
						base.Legend = stackedSeriesElementBase.Legend;
						break;
					}
				}
			}
			for (int i = 0; i < this.a.Count; i++)
			{
				StackedSeriesElementBase stackedSeriesElementBase = (StackedSeriesElementBase)this.a[i];
				if (stackedSeriesElementBase.Legend == null && base.Legend != null)
				{
					stackedSeriesElementBase.Legend = base.Legend;
				}
				if (stackedSeriesElementBase.PlotArea == null && base.PlotArea != null)
				{
					stackedSeriesElementBase.a(base.PlotArea);
					base.PlotArea.Series.a(stackedSeriesElementBase);
					base.PlotArea.Series.b(stackedSeriesElementBase);
				}
			}
		}

		// Token: 0x060058FE RID: 22782 RVA: 0x00338C60 File Offset: 0x00337C60
		internal int k()
		{
			int num = 0;
			for (int i = 0; i < this.a.Count; i++)
			{
				if (((SeriesElement)this.a[i]) is StackedColumnSeriesElement)
				{
					num = Math.Max(num, ((StackedColumnSeriesElement)this.a[i]).a().c());
				}
				else if (((SeriesElement)this.a[i]) is StackedBarSeriesElement)
				{
					num = Math.Max(num, ((StackedBarSeriesElement)this.a[i]).a().b());
				}
			}
			return num;
		}

		// Token: 0x060058FF RID: 22783 RVA: 0x00338D20 File Offset: 0x00337D20
		internal int l()
		{
			int num = 0;
			for (int i = 0; i < this.a.Count; i++)
			{
				if (((SeriesElement)this.a[i]) is Stacked100PercentColumnSeriesElement)
				{
					num = Math.Max(num, ((Stacked100PercentColumnSeriesElement)this.a[i]).a().c());
				}
				else if (((SeriesElement)this.a[i]) is Stacked100PercentBarSeriesElement)
				{
					num = Math.Max(num, ((Stacked100PercentBarSeriesElement)this.a[i]).a().b());
				}
			}
			return num;
		}

		// Token: 0x04002F2F RID: 12079
		private new ArrayList a;

		// Token: 0x04002F30 RID: 12080
		private new bool b = false;
	}
}
