using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008CD RID: 2253
	public abstract class BarValueList
	{
		// Token: 0x06005CA4 RID: 23716 RVA: 0x00347895 File Offset: 0x00346895
		internal BarValueList(BarSeries A_0)
		{
			this.b = A_0;
			this.a = new ArrayList();
		}

		// Token: 0x170009A2 RID: 2466
		// (get) Token: 0x06005CA5 RID: 23717 RVA: 0x003478C0 File Offset: 0x003468C0
		public int Count
		{
			get
			{
				return this.a.Count;
			}
		}

		// Token: 0x170009A3 RID: 2467
		public BarValue this[int index]
		{
			get
			{
				return (BarValue)this.a[index];
			}
		}

		// Token: 0x06005CA7 RID: 23719 RVA: 0x00347904 File Offset: 0x00346904
		internal void a(BarValue A_0)
		{
			if (!this.a.Contains(A_0))
			{
				this.a.Add(A_0);
				A_0.a(this.b);
				if (A_0 is DateTimeBarValue)
				{
					this.b.ii(((DateTimeBarValue)A_0).Position);
					this.b.ik(((DateTimeBarValue)A_0).Position);
				}
				else if (A_0 is IndexedBarValue)
				{
					this.b.iy((float)((IndexedBarValue)A_0).Position);
					if (this.a.Count == 1)
					{
						this.b.i0(0f);
					}
					this.b.i0((float)((IndexedBarValue)A_0).Position);
				}
				else
				{
					this.a();
				}
				this.a(A_0.Value);
				return;
			}
			throw new GeneratorException("Same BarValue object can't be added more than once.");
		}

		// Token: 0x06005CA8 RID: 23720 RVA: 0x00347A10 File Offset: 0x00346A10
		internal void b()
		{
			this.c = new float[this.a.Count];
			for (int i = 0; i < this.a.Count; i++)
			{
				BarValue barValue = (BarValue)this.a[i];
				if (barValue is IndexedBarValue)
				{
					IndexedBarValue indexedBarValue = (IndexedBarValue)barValue;
					if (indexedBarValue.Position < this.c.Length)
					{
						this.c[indexedBarValue.Position] = indexedBarValue.Value;
					}
					else
					{
						this.a(indexedBarValue.Position);
						this.c[indexedBarValue.Position] = indexedBarValue.Value;
					}
				}
				else if (barValue is DateTimeBarValue)
				{
					DateTimeBarValue dateTimeBarValue = (DateTimeBarValue)barValue;
					int num = dateTimeBarValue.ir();
					if (num < 0)
					{
						throw new GeneratorException("position should not be less than minDate.");
					}
					if (num < this.c.Length)
					{
						this.c[num] = dateTimeBarValue.Value;
					}
					else
					{
						this.a(num);
						this.c[num] = dateTimeBarValue.Value;
					}
				}
				else
				{
					this.c[i] = barValue.Value;
					barValue.a(i);
				}
			}
		}

		// Token: 0x06005CA9 RID: 23721 RVA: 0x00347B7C File Offset: 0x00346B7C
		internal void a(PageWriter A_0, int A_1, int A_2)
		{
			if (this.a.Count > 0)
			{
				A_0.SetGraphicsMode();
				for (int i = 0; i < this.c.Length; i++)
				{
					if (!this.b.PlotArea.ClipToPlotArea || (this.b.PlotArea.ClipToPlotArea && i < this.b.n().j()))
					{
						BarValue barValue = this.a(this.c[i], i);
						if (barValue != null)
						{
							barValue.a(A_0, i, A_1, A_2);
						}
					}
				}
				this.a(A_0);
			}
		}

		// Token: 0x06005CAA RID: 23722 RVA: 0x00347C3C File Offset: 0x00346C3C
		internal void b(PageWriter A_0)
		{
			for (int i = 0; i < this.c.Length; i++)
			{
				if (!this.b.PlotArea.ClipToPlotArea || (this.b.PlotArea.ClipToPlotArea && i < this.b.n().j()))
				{
					BarValue barValue = this.a(this.c[i], i);
					if (barValue != null && barValue.e() != 0f)
					{
						barValue.a(A_0, i);
					}
				}
			}
		}

		// Token: 0x06005CAB RID: 23723 RVA: 0x00347CE4 File Offset: 0x00346CE4
		private void a(PageWriter A_0)
		{
			if (this.a.Count > 0 && this.b.BorderColor != null)
			{
				A_0.SetLineWidth(this.b.BorderWidth);
				A_0.SetLineStyle(LineStyle.Solid);
				A_0.SetStrokeColor(this.b.BorderColor);
				for (int i = 0; i < this.c.Length; i++)
				{
					if (!this.b.PlotArea.ClipToPlotArea || (this.b.PlotArea.ClipToPlotArea && i < this.b.n().j()))
					{
						BarValue barValue = this.a(this.c[i], i);
						if (barValue != null && barValue.e() != 0f)
						{
							barValue.a(A_0);
						}
					}
				}
			}
		}

		// Token: 0x06005CAC RID: 23724 RVA: 0x00347DE4 File Offset: 0x00346DE4
		private BarValue a(float A_0, int A_1)
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				BarValue barValue = (BarValue)this.a[i];
				if (barValue is IndexedBarValue)
				{
					IndexedBarValue indexedBarValue = (IndexedBarValue)barValue;
					if (A_0 == indexedBarValue.Value && A_1 == indexedBarValue.Position)
					{
						return barValue;
					}
				}
				else if (barValue is DateTimeBarValue)
				{
					DateTimeBarValue dateTimeBarValue = (DateTimeBarValue)barValue;
					if (A_0 == dateTimeBarValue.Value && A_1 == dateTimeBarValue.ir())
					{
						return barValue;
					}
				}
				else if (A_0 == barValue.Value && A_1 == barValue.ir())
				{
					return barValue;
				}
			}
			return null;
		}

		// Token: 0x06005CAD RID: 23725 RVA: 0x00347ED9 File Offset: 0x00346ED9
		private void a(float A_0)
		{
			this.b.a(A_0);
			this.b.b(A_0);
		}

		// Token: 0x06005CAE RID: 23726 RVA: 0x00347EF8 File Offset: 0x00346EF8
		private void a()
		{
			if (this.a.Count == 1)
			{
				this.b.i0(0f);
				this.b.iy(0f);
			}
			else if ((float)this.a.Count > this.b.ig())
			{
				this.b.iy(this.b.ig() + 1f);
			}
		}

		// Token: 0x06005CAF RID: 23727 RVA: 0x00347F80 File Offset: 0x00346F80
		private void a(int A_0)
		{
			float[] destinationArray = new float[A_0 + 1];
			Array.Copy(this.c, 0, destinationArray, 0, this.c.Length);
			this.c = destinationArray;
		}

		// Token: 0x04003018 RID: 12312
		private ArrayList a;

		// Token: 0x04003019 RID: 12313
		private BarSeries b;

		// Token: 0x0400301A RID: 12314
		private float[] c = new float[1];
	}
}
