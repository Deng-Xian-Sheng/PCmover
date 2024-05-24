using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008D6 RID: 2262
	public abstract class Stacked100PercentBarValueList
	{
		// Token: 0x06005D19 RID: 23833 RVA: 0x0034C04B File Offset: 0x0034B04B
		internal Stacked100PercentBarValueList(Stacked100PercentBarSeriesElement A_0)
		{
			this.b = A_0;
			this.a = new ArrayList();
		}

		// Token: 0x170009B2 RID: 2482
		// (get) Token: 0x06005D1A RID: 23834 RVA: 0x0034C074 File Offset: 0x0034B074
		public int Count
		{
			get
			{
				return this.a.Count;
			}
		}

		// Token: 0x170009B3 RID: 2483
		public Stacked100PercentBarValue this[int index]
		{
			get
			{
				return (Stacked100PercentBarValue)this.a[index];
			}
		}

		// Token: 0x06005D1C RID: 23836 RVA: 0x0034C0B8 File Offset: 0x0034B0B8
		internal void a(Stacked100PercentBarValue A_0)
		{
			if (!this.a.Contains(A_0))
			{
				this.a.Add(A_0);
				A_0.a(this.b);
				if (A_0 is DateTime100PercentStackedBarValue)
				{
					this.b.im(((DateTime100PercentStackedBarValue)A_0).Position);
					this.b.io(((DateTime100PercentStackedBarValue)A_0).Position);
				}
				else if (A_0 is Indexed100PercentStackedBarValue)
				{
					this.b.i2((float)((Indexed100PercentStackedBarValue)A_0).Position);
					if (this.a.Count == 1)
					{
						this.b.i4(0f);
					}
					this.b.i4((float)((Indexed100PercentStackedBarValue)A_0).Position);
				}
				else
				{
					this.a();
				}
				return;
			}
			throw new GeneratorException("Same StackedBarValue object can't be added more than once.");
		}

		// Token: 0x06005D1D RID: 23837 RVA: 0x0034C1B8 File Offset: 0x0034B1B8
		internal int b()
		{
			return this.c.Length;
		}

		// Token: 0x06005D1E RID: 23838 RVA: 0x0034C1D4 File Offset: 0x0034B1D4
		internal float[] c()
		{
			return this.c;
		}

		// Token: 0x06005D1F RID: 23839 RVA: 0x0034C1EC File Offset: 0x0034B1EC
		internal void d()
		{
			this.c = new float[this.a.Count];
			for (int i = 0; i < this.a.Count; i++)
			{
				Stacked100PercentBarValue stacked100PercentBarValue = (Stacked100PercentBarValue)this.a[i];
				if (stacked100PercentBarValue is Indexed100PercentStackedBarValue)
				{
					Indexed100PercentStackedBarValue indexed100PercentStackedBarValue = (Indexed100PercentStackedBarValue)stacked100PercentBarValue;
					if (indexed100PercentStackedBarValue.Position < this.c.Length)
					{
						this.c[indexed100PercentStackedBarValue.Position] = indexed100PercentStackedBarValue.Value;
					}
					else
					{
						this.a(indexed100PercentStackedBarValue.Position);
						this.c[indexed100PercentStackedBarValue.Position] = indexed100PercentStackedBarValue.Value;
					}
				}
				else if (stacked100PercentBarValue is DateTime100PercentStackedBarValue)
				{
					DateTime100PercentStackedBarValue dateTime100PercentStackedBarValue = (DateTime100PercentStackedBarValue)stacked100PercentBarValue;
					int num = dateTime100PercentStackedBarValue.ip();
					if (num < 0)
					{
						throw new GeneratorException("position should not be less than minDate.");
					}
					if (num < this.c.Length)
					{
						this.c[num] = dateTime100PercentStackedBarValue.Value;
					}
					else
					{
						this.a(num);
						this.c[num] = dateTime100PercentStackedBarValue.Value;
					}
				}
				else
				{
					this.c[i] = stacked100PercentBarValue.Value;
					stacked100PercentBarValue.a(i);
				}
			}
		}

		// Token: 0x06005D20 RID: 23840 RVA: 0x0034C358 File Offset: 0x0034B358
		internal void a(PageWriter A_0)
		{
			for (int i = 0; i < this.c.Length; i++)
			{
				if (!this.b.PlotArea.ClipToPlotArea || (this.b.PlotArea.ClipToPlotArea && i < this.b.e().j()))
				{
					Stacked100PercentBarValue stacked100PercentBarValue = this.a(this.c[i], i);
					if (stacked100PercentBarValue != null && stacked100PercentBarValue.c() != 0f)
					{
						stacked100PercentBarValue.a(A_0, i);
					}
				}
			}
		}

		// Token: 0x06005D21 RID: 23841 RVA: 0x0034C404 File Offset: 0x0034B404
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
						Stacked100PercentBarValue stacked100PercentBarValue = this.a(this.c[i], i);
						if (stacked100PercentBarValue != null && stacked100PercentBarValue.c() != 0f)
						{
							stacked100PercentBarValue.a(A_0);
						}
					}
				}
			}
		}

		// Token: 0x06005D22 RID: 23842 RVA: 0x0034C504 File Offset: 0x0034B504
		internal void a(PageWriter A_0, Stacked100PercentBarSeriesElement[] A_1, int A_2, int A_3, int A_4, float[] A_5)
		{
			if (this.a.Count > 0)
			{
				A_0.SetGraphicsMode();
				for (int i = 0; i < this.c.Length; i++)
				{
					if (!this.b.PlotArea.ClipToPlotArea || (this.b.PlotArea.ClipToPlotArea && i < this.b.e().j()))
					{
						Stacked100PercentBarValue stacked100PercentBarValue = this.a(this.c[i], i);
						if (stacked100PercentBarValue != null)
						{
							Stacked100PercentBarValue a_;
							if (stacked100PercentBarValue.Value >= 0f)
							{
								a_ = this.a(A_1, A_2, 0, i);
							}
							else
							{
								a_ = this.a(A_1, A_2, 1, i);
							}
							stacked100PercentBarValue.a(A_0, a_, i, A_3, A_4, A_2, A_5[i]);
						}
					}
				}
				this.b(A_0);
			}
		}

		// Token: 0x06005D23 RID: 23843 RVA: 0x0034C600 File Offset: 0x0034B600
		private Stacked100PercentBarValue a(float A_0, int A_1)
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				Stacked100PercentBarValue stacked100PercentBarValue = (Stacked100PercentBarValue)this.a[i];
				if (stacked100PercentBarValue is Indexed100PercentStackedBarValue)
				{
					Indexed100PercentStackedBarValue indexed100PercentStackedBarValue = (Indexed100PercentStackedBarValue)stacked100PercentBarValue;
					if (A_0 == indexed100PercentStackedBarValue.Value && A_1 == indexed100PercentStackedBarValue.Position)
					{
						return stacked100PercentBarValue;
					}
				}
				else if (stacked100PercentBarValue is DateTime100PercentStackedBarValue)
				{
					DateTime100PercentStackedBarValue dateTime100PercentStackedBarValue = (DateTime100PercentStackedBarValue)stacked100PercentBarValue;
					if (A_0 == dateTime100PercentStackedBarValue.Value && A_1 == dateTime100PercentStackedBarValue.ip())
					{
						return stacked100PercentBarValue;
					}
				}
				else if (A_0 == stacked100PercentBarValue.Value && A_1 == stacked100PercentBarValue.ip())
				{
					return stacked100PercentBarValue;
				}
			}
			return null;
		}

		// Token: 0x06005D24 RID: 23844 RVA: 0x0034C6F8 File Offset: 0x0034B6F8
		private Stacked100PercentBarValue a(Stacked100PercentBarSeriesElement[] A_0, int A_1, int A_2, int A_3)
		{
			float[] array = new float[1];
			Stacked100PercentBarValue result;
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
						Stacked100PercentBarValue stacked100PercentBarValue = A_0[i].a().a(array[A_3], A_3);
						if (stacked100PercentBarValue != null)
						{
							if (stacked100PercentBarValue.Value >= 0f && A_2 == 0)
							{
								return stacked100PercentBarValue;
							}
							if (stacked100PercentBarValue.Value < 0f && A_2 == 1)
							{
								return stacked100PercentBarValue;
							}
						}
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06005D25 RID: 23845 RVA: 0x0034C7D0 File Offset: 0x0034B7D0
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

		// Token: 0x06005D26 RID: 23846 RVA: 0x0034C858 File Offset: 0x0034B858
		private void a(int A_0)
		{
			float[] destinationArray = new float[A_0 + 1];
			Array.Copy(this.c, 0, destinationArray, 0, this.c.Length);
			this.c = destinationArray;
		}

		// Token: 0x04003044 RID: 12356
		private ArrayList a;

		// Token: 0x04003045 RID: 12357
		private Stacked100PercentBarSeriesElement b;

		// Token: 0x04003046 RID: 12358
		private float[] c = new float[1];
	}
}
