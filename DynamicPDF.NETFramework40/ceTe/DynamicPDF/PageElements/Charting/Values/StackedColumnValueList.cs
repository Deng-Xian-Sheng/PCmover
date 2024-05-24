using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008F4 RID: 2292
	public abstract class StackedColumnValueList
	{
		// Token: 0x06005E28 RID: 24104 RVA: 0x003556AF File Offset: 0x003546AF
		internal StackedColumnValueList(StackedColumnSeriesElement A_0)
		{
			this.b = A_0;
			this.a = new ArrayList();
		}

		// Token: 0x170009D6 RID: 2518
		// (get) Token: 0x06005E29 RID: 24105 RVA: 0x003556D8 File Offset: 0x003546D8
		public int Count
		{
			get
			{
				return this.a.Count;
			}
		}

		// Token: 0x170009D7 RID: 2519
		public StackedColumnValue this[int index]
		{
			get
			{
				return (StackedColumnValue)this.a[index];
			}
		}

		// Token: 0x06005E2B RID: 24107 RVA: 0x0035571C File Offset: 0x0035471C
		internal void a(StackedColumnValue A_0)
		{
			if (!this.a.Contains(A_0))
			{
				this.a.Add(A_0);
				A_0.a(this.b);
				if (A_0 is DateTimeStackedColumnValue)
				{
					this.b.im(((DateTimeStackedColumnValue)A_0).Position);
					this.b.io(((DateTimeStackedColumnValue)A_0).Position);
				}
				else if (A_0 is IndexedStackedColumnValue)
				{
					this.b.i2((float)((IndexedStackedColumnValue)A_0).Position);
					if (this.a.Count == 1)
					{
						this.b.i4(0f);
					}
					this.b.i4((float)((IndexedStackedColumnValue)A_0).Position);
				}
				else
				{
					this.a();
				}
				return;
			}
			throw new GeneratorException("Same StackedColumnValue object can't be added more than once.");
		}

		// Token: 0x06005E2C RID: 24108 RVA: 0x0035581C File Offset: 0x0035481C
		internal float[] b()
		{
			return this.c;
		}

		// Token: 0x06005E2D RID: 24109 RVA: 0x00355834 File Offset: 0x00354834
		internal int c()
		{
			return this.c.Length;
		}

		// Token: 0x06005E2E RID: 24110 RVA: 0x00355850 File Offset: 0x00354850
		internal void d()
		{
			this.c = new float[this.a.Count];
			for (int i = 0; i < this.a.Count; i++)
			{
				StackedColumnValue stackedColumnValue = (StackedColumnValue)this.a[i];
				if (stackedColumnValue is IndexedStackedColumnValue)
				{
					IndexedStackedColumnValue indexedStackedColumnValue = (IndexedStackedColumnValue)stackedColumnValue;
					if (indexedStackedColumnValue.Position < this.c.Length)
					{
						this.c[indexedStackedColumnValue.Position] = indexedStackedColumnValue.Value;
					}
					else
					{
						this.a(indexedStackedColumnValue.Position);
						this.c[indexedStackedColumnValue.Position] = indexedStackedColumnValue.Value;
					}
				}
				else if (stackedColumnValue is DateTimeStackedColumnValue)
				{
					DateTimeStackedColumnValue dateTimeStackedColumnValue = (DateTimeStackedColumnValue)stackedColumnValue;
					int num = dateTimeStackedColumnValue.iu();
					if (num < 0)
					{
						throw new GeneratorException("position should not be less than minDate.");
					}
					if (num < this.c.Length)
					{
						this.c[num] = dateTimeStackedColumnValue.Value;
					}
					else
					{
						this.a(num);
						this.c[num] = dateTimeStackedColumnValue.Value;
					}
				}
				else
				{
					this.c[i] = stackedColumnValue.Value;
					stackedColumnValue.a(i);
				}
			}
		}

		// Token: 0x06005E2F RID: 24111 RVA: 0x003559C0 File Offset: 0x003549C0
		internal void a(PageWriter A_0)
		{
			for (int i = 0; i < this.c.Length; i++)
			{
				if (!this.b.PlotArea.ClipToPlotArea || (this.b.PlotArea.ClipToPlotArea && i < this.b.d().j()))
				{
					StackedColumnValue stackedColumnValue = this.a(this.c[i], i);
					if (stackedColumnValue != null && stackedColumnValue.c() != 0f)
					{
						stackedColumnValue.a(A_0, i);
					}
				}
			}
		}

		// Token: 0x06005E30 RID: 24112 RVA: 0x00355A68 File Offset: 0x00354A68
		internal void b(PageWriter A_0)
		{
			if (this.a.Count > 0 && this.b.BorderColor != null)
			{
				A_0.SetLineWidth(this.b.BorderWidth);
				A_0.SetLineStyle(LineStyle.Solid);
				A_0.SetStrokeColor(this.b.BorderColor);
				for (int i = 0; i < this.c.Length; i++)
				{
					if (!this.b.PlotArea.ClipToPlotArea || (this.b.PlotArea.ClipToPlotArea && i < this.b.d().j()))
					{
						StackedColumnValue stackedColumnValue = this.a(this.c[i], i);
						if (stackedColumnValue != null && stackedColumnValue.c() != 0f)
						{
							stackedColumnValue.a(A_0);
						}
					}
				}
			}
		}

		// Token: 0x06005E31 RID: 24113 RVA: 0x00355B68 File Offset: 0x00354B68
		internal void a(PageWriter A_0, StackedColumnSeriesElement[] A_1, int A_2, int A_3, int A_4)
		{
			if (this.a.Count > 0)
			{
				A_0.SetGraphicsMode();
				for (int i = 0; i < this.c.Length; i++)
				{
					if (!this.b.PlotArea.ClipToPlotArea || (this.b.PlotArea.ClipToPlotArea && i < this.b.d().j()))
					{
						StackedColumnValue stackedColumnValue = this.a(this.c[i], i);
						if (stackedColumnValue != null)
						{
							StackedColumnValue a_;
							if (stackedColumnValue.Value >= 0f)
							{
								a_ = this.a(A_1, A_2, 0, i);
							}
							else
							{
								a_ = this.a(A_1, A_2, 1, i);
							}
							stackedColumnValue.a(A_0, a_, i, A_3, A_4, A_2);
						}
					}
				}
				this.b(A_0);
			}
		}

		// Token: 0x06005E32 RID: 24114 RVA: 0x00355C60 File Offset: 0x00354C60
		private StackedColumnValue a(StackedColumnSeriesElement[] A_0, int A_1, int A_2, int A_3)
		{
			float[] array = new float[1];
			StackedColumnValue result;
			if (A_1 == 0)
			{
				result = null;
			}
			else
			{
				for (int i = A_1 - 1; i >= 0; i--)
				{
					array = A_0[i].a().b();
					if (A_3 < array.Length)
					{
						StackedColumnValue stackedColumnValue = A_0[i].a().a(array[A_3], A_3);
						if (stackedColumnValue != null)
						{
							if (stackedColumnValue.Value >= 0f && A_2 == 0)
							{
								return stackedColumnValue;
							}
							if (stackedColumnValue.Value < 0f && A_2 == 1)
							{
								return stackedColumnValue;
							}
						}
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06005E33 RID: 24115 RVA: 0x00355D38 File Offset: 0x00354D38
		private StackedColumnValue a(float A_0, int A_1)
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				StackedColumnValue stackedColumnValue = (StackedColumnValue)this.a[i];
				if (stackedColumnValue is IndexedStackedColumnValue)
				{
					IndexedStackedColumnValue indexedStackedColumnValue = (IndexedStackedColumnValue)stackedColumnValue;
					if (A_0 == indexedStackedColumnValue.Value && A_1 == indexedStackedColumnValue.Position)
					{
						return stackedColumnValue;
					}
				}
				else if (stackedColumnValue is DateTimeStackedColumnValue)
				{
					DateTimeStackedColumnValue dateTimeStackedColumnValue = (DateTimeStackedColumnValue)stackedColumnValue;
					if (A_0 == dateTimeStackedColumnValue.Value && A_1 == dateTimeStackedColumnValue.iu())
					{
						return stackedColumnValue;
					}
				}
				else if (A_0 == stackedColumnValue.Value && A_1 == stackedColumnValue.iu())
				{
					return stackedColumnValue;
				}
			}
			return null;
		}

		// Token: 0x06005E34 RID: 24116 RVA: 0x00355E30 File Offset: 0x00354E30
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

		// Token: 0x06005E35 RID: 24117 RVA: 0x00355EB8 File Offset: 0x00354EB8
		private void a(int A_0)
		{
			float[] destinationArray = new float[A_0 + 1];
			Array.Copy(this.c, 0, destinationArray, 0, this.c.Length);
			this.c = destinationArray;
		}

		// Token: 0x0400309B RID: 12443
		private ArrayList a;

		// Token: 0x0400309C RID: 12444
		private StackedColumnSeriesElement b;

		// Token: 0x0400309D RID: 12445
		private float[] c = new float[1];
	}
}
