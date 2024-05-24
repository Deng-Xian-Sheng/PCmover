using System;
using System.Collections;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007B3 RID: 1971
	public class XAxisList
	{
		// Token: 0x06005008 RID: 20488 RVA: 0x0027E5E6 File Offset: 0x0027D5E6
		internal XAxisList(PlotArea A_0)
		{
			this.f = A_0;
		}

		// Token: 0x06005009 RID: 20489 RVA: 0x0027E604 File Offset: 0x0027D604
		public void Add(XAxis xAxis)
		{
			this.a(xAxis);
			if (!this.a.Contains(xAxis))
			{
				this.a.Add(xAxis);
				if (xAxis.u() == null)
				{
					xAxis.a(this.f);
				}
			}
		}

		// Token: 0x170006B0 RID: 1712
		public XAxis this[int index]
		{
			get
			{
				return (XAxis)this.a[index];
			}
		}

		// Token: 0x170006B1 RID: 1713
		// (get) Token: 0x0600500B RID: 20491 RVA: 0x0027E67C File Offset: 0x0027D67C
		public int Count
		{
			get
			{
				return this.a.Count;
			}
		}

		// Token: 0x170006B2 RID: 1714
		// (get) Token: 0x0600500C RID: 20492 RVA: 0x0027E69C File Offset: 0x0027D69C
		// (set) Token: 0x0600500D RID: 20493 RVA: 0x0027E6D0 File Offset: 0x0027D6D0
		public NumericXAxis DefaultNumericAxis
		{
			get
			{
				if (this.b == null)
				{
					this.b = this.h();
				}
				return this.b;
			}
			set
			{
				this.b = value;
				this.Add(this.b);
			}
		}

		// Token: 0x170006B3 RID: 1715
		// (get) Token: 0x0600500E RID: 20494 RVA: 0x0027E6E8 File Offset: 0x0027D6E8
		// (set) Token: 0x0600500F RID: 20495 RVA: 0x0027E71C File Offset: 0x0027D71C
		public IndexedXAxis DefaultIndexedAxis
		{
			get
			{
				if (this.c == null)
				{
					this.c = this.i();
				}
				return this.c;
			}
			set
			{
				this.c = value;
				this.Add(this.c);
			}
		}

		// Token: 0x170006B4 RID: 1716
		// (get) Token: 0x06005010 RID: 20496 RVA: 0x0027E734 File Offset: 0x0027D734
		// (set) Token: 0x06005011 RID: 20497 RVA: 0x0027E768 File Offset: 0x0027D768
		public DateTimeXAxis DefaultDateTimeAxis
		{
			get
			{
				if (this.d == null)
				{
					this.d = this.k();
				}
				return this.d;
			}
			set
			{
				this.d = value;
				this.Add(this.d);
			}
		}

		// Token: 0x170006B5 RID: 1717
		// (get) Token: 0x06005012 RID: 20498 RVA: 0x0027E780 File Offset: 0x0027D780
		// (set) Token: 0x06005013 RID: 20499 RVA: 0x0027E7B4 File Offset: 0x0027D7B4
		public PercentageXAxis DefaultPercentageAxis
		{
			get
			{
				if (this.e == null)
				{
					this.e = this.j();
				}
				return this.e;
			}
			set
			{
				this.e = value;
				this.Add(this.e);
			}
		}

		// Token: 0x06005014 RID: 20500 RVA: 0x0027E7CC File Offset: 0x0027D7CC
		internal ArrayList a()
		{
			return this.a;
		}

		// Token: 0x06005015 RID: 20501 RVA: 0x0027E7E4 File Offset: 0x0027D7E4
		internal bool b()
		{
			bool result = false;
			for (int i = 0; i < this.a.Count; i++)
			{
				XAxis xaxis = (XAxis)this.a[i];
				if (xaxis.Visible && xaxis.AnchorType == XAxisAnchorType.Bottom && xaxis.Offset <= xaxis.LineWidth / 2f)
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06005016 RID: 20502 RVA: 0x0027E85C File Offset: 0x0027D85C
		internal bool c()
		{
			bool result = false;
			for (int i = 0; i < this.a.Count; i++)
			{
				XAxis xaxis = (XAxis)this.a[i];
				if (xaxis.Visible && xaxis.AnchorType == XAxisAnchorType.Top && Math.Abs(xaxis.Offset) <= xaxis.LineWidth / 2f)
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06005017 RID: 20503 RVA: 0x0027E8DC File Offset: 0x0027D8DC
		internal void d()
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				XAxis xaxis = (XAxis)this.a[i];
				xaxis.iw();
				xaxis.i();
			}
		}

		// Token: 0x06005018 RID: 20504 RVA: 0x0027E928 File Offset: 0x0027D928
		internal float e()
		{
			float num = 0f;
			for (int i = 0; i < this.a.Count; i++)
			{
				XAxis xaxis = (XAxis)this.a[i];
				XAxisLabelList xaxisLabelList = (XAxisLabelList)xaxis.r();
				float num2 = xaxisLabelList.a();
				if (num < num2)
				{
					num = num2;
				}
			}
			return num;
		}

		// Token: 0x06005019 RID: 20505 RVA: 0x0027E9A0 File Offset: 0x0027D9A0
		internal float f()
		{
			float num = 0f;
			for (int i = 0; i < this.a.Count; i++)
			{
				XAxis xaxis = (XAxis)this.a[i];
				XAxisLabelList xaxisLabelList = (XAxisLabelList)xaxis.r();
				float num2 = xaxisLabelList.b();
				if (num < num2)
				{
					num = num2;
				}
			}
			return num;
		}

		// Token: 0x0600501A RID: 20506 RVA: 0x0027EA18 File Offset: 0x0027DA18
		internal XAxis g()
		{
			XAxis result = null;
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
				result = (XAxis)this.a[0];
			}
			return result;
		}

		// Token: 0x0600501B RID: 20507 RVA: 0x0027EAAC File Offset: 0x0027DAAC
		internal NumericXAxis h()
		{
			NumericXAxis result;
			if (this.b != null)
			{
				result = this.b;
			}
			else
			{
				XAxis xaxis = null;
				for (int i = 0; i < this.a.Count; i++)
				{
					xaxis = (XAxis)this.a[i];
					if (xaxis is NumericXAxis)
					{
						return (NumericXAxis)xaxis;
					}
				}
				if (!(xaxis is NumericXAxis))
				{
					NumericXAxis numericXAxis = new NumericXAxis();
					this.Add(numericXAxis);
					result = numericXAxis;
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		// Token: 0x0600501C RID: 20508 RVA: 0x0027EB48 File Offset: 0x0027DB48
		internal IndexedXAxis i()
		{
			IndexedXAxis result;
			if (this.c != null)
			{
				result = this.c;
			}
			else
			{
				XAxis xaxis = null;
				for (int i = 0; i < this.a.Count; i++)
				{
					xaxis = (XAxis)this.a[i];
					if (xaxis is IndexedXAxis)
					{
						return (IndexedXAxis)xaxis;
					}
				}
				if (!(xaxis is IndexedXAxis))
				{
					IndexedXAxis indexedXAxis = new IndexedXAxis();
					this.Add(indexedXAxis);
					result = indexedXAxis;
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		// Token: 0x0600501D RID: 20509 RVA: 0x0027EBE4 File Offset: 0x0027DBE4
		internal PercentageXAxis j()
		{
			PercentageXAxis result;
			if (this.e != null)
			{
				result = this.e;
			}
			else
			{
				XAxis xaxis = null;
				for (int i = 0; i < this.a.Count; i++)
				{
					xaxis = (XAxis)this.a[i];
					if (xaxis is PercentageXAxis)
					{
						return (PercentageXAxis)xaxis;
					}
				}
				if (!(xaxis is PercentageXAxis))
				{
					PercentageXAxis percentageXAxis = new PercentageXAxis();
					this.Add(percentageXAxis);
					result = percentageXAxis;
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		// Token: 0x0600501E RID: 20510 RVA: 0x0027EC80 File Offset: 0x0027DC80
		internal DateTimeXAxis k()
		{
			DateTimeXAxis result;
			if (this.d != null)
			{
				result = this.d;
			}
			else
			{
				XAxis xaxis = null;
				for (int i = 0; i < this.a.Count; i++)
				{
					xaxis = (XAxis)this.a[i];
					if (xaxis is DateTimeXAxis)
					{
						return (DateTimeXAxis)xaxis;
					}
				}
				if (!(xaxis is DateTimeXAxis))
				{
					DateTimeXAxis dateTimeXAxis = new DateTimeXAxis();
					this.Add(dateTimeXAxis);
					result = dateTimeXAxis;
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		// Token: 0x0600501F RID: 20511 RVA: 0x0027ED1C File Offset: 0x0027DD1C
		private void a(XAxis A_0)
		{
			bool flag = false;
			PlotAreaList plotAreas = this.f.Chart.PlotAreas;
			for (int i = 0; i < plotAreas.Count; i++)
			{
				PlotArea plotArea = plotAreas[i];
				if (!plotArea.Equals(this.f))
				{
					if (plotArea.XAxes.a().Contains(A_0))
					{
						flag = true;
					}
				}
				i++;
			}
			if (flag)
			{
				throw new GeneratorException("Same XAxis is already present in another plotArea's XAxesList.");
			}
		}

		// Token: 0x06005020 RID: 20512 RVA: 0x0027EDAC File Offset: 0x0027DDAC
		internal void a(PageWriter A_0)
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				XAxis xaxis = (XAxis)this.a[i];
				xaxis.a(A_0);
			}
		}

		// Token: 0x06005021 RID: 20513 RVA: 0x0027EDF4 File Offset: 0x0027DDF4
		internal void b(PageWriter A_0)
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				XAxis xaxis = (XAxis)this.a[i];
				xaxis.b(A_0);
			}
		}

		// Token: 0x06005022 RID: 20514 RVA: 0x0027EE3C File Offset: 0x0027DE3C
		internal void c(PageWriter A_0)
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				XAxis xaxis = (XAxis)this.a[i];
				xaxis.c(A_0);
			}
		}

		// Token: 0x04002B2D RID: 11053
		private ArrayList a = new ArrayList();

		// Token: 0x04002B2E RID: 11054
		private NumericXAxis b;

		// Token: 0x04002B2F RID: 11055
		private IndexedXAxis c;

		// Token: 0x04002B30 RID: 11056
		private DateTimeXAxis d;

		// Token: 0x04002B31 RID: 11057
		private PercentageXAxis e;

		// Token: 0x04002B32 RID: 11058
		private PlotArea f;
	}
}
