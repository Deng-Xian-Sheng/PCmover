using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008F0 RID: 2288
	public abstract class StackedBarValueList
	{
		// Token: 0x06005DFD RID: 24061 RVA: 0x00353F23 File Offset: 0x00352F23
		internal StackedBarValueList(StackedBarSeriesElement A_0)
		{
			this.b = A_0;
			this.a = new ArrayList();
		}

		// Token: 0x170009D0 RID: 2512
		// (get) Token: 0x06005DFE RID: 24062 RVA: 0x00353F4C File Offset: 0x00352F4C
		public int Count
		{
			get
			{
				return this.a.Count;
			}
		}

		// Token: 0x170009D1 RID: 2513
		public StackedBarValue this[int index]
		{
			get
			{
				return (StackedBarValue)this.a[index];
			}
		}

		// Token: 0x06005E00 RID: 24064 RVA: 0x00353F90 File Offset: 0x00352F90
		internal void a(StackedBarValue A_0)
		{
			if (!this.a.Contains(A_0))
			{
				this.a.Add(A_0);
				A_0.a(this.b);
				if (A_0 is DateTimeStackedBarValue)
				{
					this.b.im(((DateTimeStackedBarValue)A_0).Position);
					this.b.io(((DateTimeStackedBarValue)A_0).Position);
				}
				else if (A_0 is IndexedStackedBarValue)
				{
					this.b.i2((float)((IndexedStackedBarValue)A_0).Position);
					if (this.a.Count == 1)
					{
						this.b.i4(0f);
					}
					this.b.i4((float)((IndexedStackedBarValue)A_0).Position);
				}
				else
				{
					this.a();
				}
				return;
			}
			throw new GeneratorException("Same StackedBarValue object can't be added more than once.");
		}

		// Token: 0x06005E01 RID: 24065 RVA: 0x00354090 File Offset: 0x00353090
		internal int b()
		{
			return this.c.Length;
		}

		// Token: 0x06005E02 RID: 24066 RVA: 0x003540AC File Offset: 0x003530AC
		internal float[] c()
		{
			return this.c;
		}

		// Token: 0x06005E03 RID: 24067 RVA: 0x003540C4 File Offset: 0x003530C4
		internal void d()
		{
			this.c = new float[this.a.Count];
			for (int i = 0; i < this.a.Count; i++)
			{
				StackedBarValue stackedBarValue = (StackedBarValue)this.a[i];
				if (stackedBarValue is IndexedStackedBarValue)
				{
					IndexedStackedBarValue indexedStackedBarValue = (IndexedStackedBarValue)stackedBarValue;
					if (indexedStackedBarValue.Position < this.c.Length)
					{
						this.c[indexedStackedBarValue.Position] = indexedStackedBarValue.Value;
					}
					else
					{
						this.a(indexedStackedBarValue.Position);
						this.c[indexedStackedBarValue.Position] = indexedStackedBarValue.Value;
					}
				}
				else if (stackedBarValue is DateTimeStackedBarValue)
				{
					DateTimeStackedBarValue dateTimeStackedBarValue = (DateTimeStackedBarValue)stackedBarValue;
					int num = dateTimeStackedBarValue.it();
					if (num < 0)
					{
						throw new GeneratorException("position should not be less than minDate.");
					}
					if (num < this.c.Length)
					{
						this.c[num] = dateTimeStackedBarValue.Value;
					}
					else
					{
						this.a(num);
						this.c[num] = dateTimeStackedBarValue.Value;
					}
				}
				else
				{
					this.c[i] = stackedBarValue.Value;
					stackedBarValue.a(i);
				}
			}
		}

		// Token: 0x06005E04 RID: 24068 RVA: 0x00354230 File Offset: 0x00353230
		internal void a(PageWriter A_0)
		{
			for (int i = 0; i < this.c.Length; i++)
			{
				if (!this.b.PlotArea.ClipToPlotArea || (this.b.PlotArea.ClipToPlotArea && i < this.b.e().j()))
				{
					StackedBarValue stackedBarValue = this.a(this.c[i], i);
					if (stackedBarValue != null && stackedBarValue.c() != 0f)
					{
						stackedBarValue.a(A_0, i);
					}
				}
			}
		}

		// Token: 0x06005E05 RID: 24069 RVA: 0x003542DC File Offset: 0x003532DC
		internal void b(PageWriter A_0)
		{
			if (this.a.Count > 0 && this.b.BorderColor != null)
			{
				A_0.SetLineWidth(this.b.BorderWidth);
				A_0.SetLineStyle(LineStyle.Solid);
				A_0.SetStrokeColor(this.b.BorderColor);
				for (int i = 0; i < this.c.Length; i++)
				{
					if (!this.b.PlotArea.ClipToPlotArea || (this.b.PlotArea.ClipToPlotArea && i < this.b.e().j()))
					{
						StackedBarValue stackedBarValue = this.a(this.c[i], i);
						if (stackedBarValue != null && stackedBarValue.c() != 0f)
						{
							stackedBarValue.a(A_0);
						}
					}
				}
			}
		}

		// Token: 0x06005E06 RID: 24070 RVA: 0x003543DC File Offset: 0x003533DC
		internal void a(PageWriter A_0, StackedBarSeriesElement[] A_1, int A_2, int A_3, int A_4)
		{
			if (this.a.Count > 0)
			{
				A_0.SetGraphicsMode();
				for (int i = 0; i < this.c.Length; i++)
				{
					if (!this.b.PlotArea.ClipToPlotArea || (this.b.PlotArea.ClipToPlotArea && i < this.b.e().j()))
					{
						StackedBarValue stackedBarValue = this.a(this.c[i], i);
						if (stackedBarValue != null)
						{
							StackedBarValue a_;
							if (stackedBarValue.Value >= 0f)
							{
								a_ = this.a(A_1, A_2, 0, i);
							}
							else
							{
								a_ = this.a(A_1, A_2, 1, i);
							}
							stackedBarValue.a(A_0, a_, i, A_3, A_4, A_2);
						}
					}
				}
				this.b(A_0);
			}
		}

		// Token: 0x06005E07 RID: 24071 RVA: 0x003544D4 File Offset: 0x003534D4
		private StackedBarValue a(float A_0, int A_1)
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				StackedBarValue stackedBarValue = (StackedBarValue)this.a[i];
				if (stackedBarValue is IndexedStackedBarValue)
				{
					IndexedStackedBarValue indexedStackedBarValue = (IndexedStackedBarValue)stackedBarValue;
					if (A_0 == indexedStackedBarValue.Value && A_1 == indexedStackedBarValue.Position)
					{
						return stackedBarValue;
					}
				}
				else if (stackedBarValue is DateTimeStackedBarValue)
				{
					DateTimeStackedBarValue dateTimeStackedBarValue = (DateTimeStackedBarValue)stackedBarValue;
					if (A_0 == dateTimeStackedBarValue.Value && A_1 == dateTimeStackedBarValue.it())
					{
						return stackedBarValue;
					}
				}
				else if (A_0 == stackedBarValue.Value && A_1 == stackedBarValue.it())
				{
					return stackedBarValue;
				}
			}
			return null;
		}

		// Token: 0x06005E08 RID: 24072 RVA: 0x003545CC File Offset: 0x003535CC
		private StackedBarValue a(StackedBarSeriesElement[] A_0, int A_1, int A_2, int A_3)
		{
			float[] array = new float[1];
			StackedBarValue result;
			if (A_1 == 0)
			{
				result = null;
			}
			else
			{
				for (int i = A_1 - 1; i >= 0; i--)
				{
					array = A_0[i].a().c();
					if (A_3 < array.Length)
					{
						StackedBarValue stackedBarValue = A_0[i].a().a(array[A_3], A_3);
						if (stackedBarValue != null)
						{
							if (stackedBarValue.Value >= 0f && A_2 == 0)
							{
								return stackedBarValue;
							}
							if (stackedBarValue.Value < 0f && A_2 == 1)
							{
								return stackedBarValue;
							}
						}
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06005E09 RID: 24073 RVA: 0x003546A4 File Offset: 0x003536A4
		private void a()
		{
			if (this.a.Count == 1)
			{
				this.b.i4(0f);
				this.b.i2(0f);
			}
			else if ((float)this.a.Count > this.b.i1())
			{
				this.b.i2(this.b.i1() + 1f);
			}
		}

		// Token: 0x06005E0A RID: 24074 RVA: 0x0035472C File Offset: 0x0035372C
		private void a(int A_0)
		{
			float[] destinationArray = new float[A_0 + 1];
			Array.Copy(this.c, 0, destinationArray, 0, this.c.Length);
			this.c = destinationArray;
		}

		// Token: 0x0400308C RID: 12428
		private ArrayList a;

		// Token: 0x0400308D RID: 12429
		private StackedBarSeriesElement b;

		// Token: 0x0400308E RID: 12430
		private float[] c = new float[1];
	}
}
