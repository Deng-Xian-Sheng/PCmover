using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008DA RID: 2266
	public abstract class Stacked100PercentColumnValueList
	{
		// Token: 0x06005D45 RID: 23877 RVA: 0x0034D807 File Offset: 0x0034C807
		internal Stacked100PercentColumnValueList(Stacked100PercentColumnSeriesElement A_0)
		{
			this.b = A_0;
			this.a = new ArrayList();
		}

		// Token: 0x170009B8 RID: 2488
		// (get) Token: 0x06005D46 RID: 23878 RVA: 0x0034D830 File Offset: 0x0034C830
		public int Count
		{
			get
			{
				return this.a.Count;
			}
		}

		// Token: 0x170009B9 RID: 2489
		public Stacked100PercentColumnValue this[int index]
		{
			get
			{
				return (Stacked100PercentColumnValue)this.a[index];
			}
		}

		// Token: 0x06005D48 RID: 23880 RVA: 0x0034D874 File Offset: 0x0034C874
		internal void a(Stacked100PercentColumnValue A_0)
		{
			if (!this.a.Contains(A_0))
			{
				this.a.Add(A_0);
				A_0.a(this.b);
				if (A_0 is DateTime100PercentStackedColumnValue)
				{
					this.b.im(((DateTime100PercentStackedColumnValue)A_0).Position);
					this.b.io(((DateTime100PercentStackedColumnValue)A_0).Position);
				}
				else if (A_0 is Indexed100PercentStackedColumnValue)
				{
					this.b.i2((float)((Indexed100PercentStackedColumnValue)A_0).Position);
					if (this.a.Count == 1)
					{
						this.b.i4(0f);
					}
					this.b.i4((float)((Indexed100PercentStackedColumnValue)A_0).Position);
				}
				else
				{
					this.a();
				}
				return;
			}
			throw new GeneratorException("Same StackedColumnValue object can't be added more than once.");
		}

		// Token: 0x06005D49 RID: 23881 RVA: 0x0034D974 File Offset: 0x0034C974
		internal float[] b()
		{
			return this.c;
		}

		// Token: 0x06005D4A RID: 23882 RVA: 0x0034D98C File Offset: 0x0034C98C
		internal int c()
		{
			return this.c.Length;
		}

		// Token: 0x06005D4B RID: 23883 RVA: 0x0034D9A8 File Offset: 0x0034C9A8
		internal void d()
		{
			this.c = new float[this.a.Count];
			for (int i = 0; i < this.a.Count; i++)
			{
				Stacked100PercentColumnValue stacked100PercentColumnValue = (Stacked100PercentColumnValue)this.a[i];
				if (stacked100PercentColumnValue is Indexed100PercentStackedColumnValue)
				{
					Indexed100PercentStackedColumnValue indexed100PercentStackedColumnValue = (Indexed100PercentStackedColumnValue)stacked100PercentColumnValue;
					if (indexed100PercentStackedColumnValue.Position < this.c.Length)
					{
						this.c[indexed100PercentStackedColumnValue.Position] = indexed100PercentStackedColumnValue.Value;
					}
					else
					{
						this.a(indexed100PercentStackedColumnValue.Position);
						this.c[indexed100PercentStackedColumnValue.Position] = indexed100PercentStackedColumnValue.Value;
					}
				}
				else if (stacked100PercentColumnValue is DateTime100PercentStackedColumnValue)
				{
					DateTime100PercentStackedColumnValue dateTime100PercentStackedColumnValue = (DateTime100PercentStackedColumnValue)stacked100PercentColumnValue;
					int num = dateTime100PercentStackedColumnValue.iq();
					if (num < 0)
					{
						throw new GeneratorException("position should not be less than minDate.");
					}
					if (num < this.c.Length)
					{
						this.c[num] = dateTime100PercentStackedColumnValue.Value;
					}
					else
					{
						this.a(num);
						this.c[num] = dateTime100PercentStackedColumnValue.Value;
					}
				}
				else
				{
					this.c[i] = stacked100PercentColumnValue.Value;
					stacked100PercentColumnValue.a(i);
				}
			}
		}

		// Token: 0x06005D4C RID: 23884 RVA: 0x0034DB18 File Offset: 0x0034CB18
		internal void a(PageWriter A_0)
		{
			for (int i = 0; i < this.c.Length; i++)
			{
				if (!this.b.PlotArea.ClipToPlotArea || (this.b.PlotArea.ClipToPlotArea && i < this.b.d().j()))
				{
					Stacked100PercentColumnValue stacked100PercentColumnValue = this.a(this.c[i], i);
					if (stacked100PercentColumnValue != null && stacked100PercentColumnValue.c() != 0f)
					{
						stacked100PercentColumnValue.a(A_0, i);
					}
				}
			}
		}

		// Token: 0x06005D4D RID: 23885 RVA: 0x0034DBC0 File Offset: 0x0034CBC0
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
						Stacked100PercentColumnValue stacked100PercentColumnValue = this.a(this.c[i], i);
						if (stacked100PercentColumnValue != null && stacked100PercentColumnValue.c() != 0f)
						{
							stacked100PercentColumnValue.a(A_0);
						}
					}
				}
			}
		}

		// Token: 0x06005D4E RID: 23886 RVA: 0x0034DCC0 File Offset: 0x0034CCC0
		internal void a(PageWriter A_0, Stacked100PercentColumnSeriesElement[] A_1, int A_2, int A_3, int A_4, float[] A_5)
		{
			if (this.a.Count > 0)
			{
				A_0.SetGraphicsMode();
				for (int i = 0; i < this.c.Length; i++)
				{
					if (!this.b.PlotArea.ClipToPlotArea || (this.b.PlotArea.ClipToPlotArea && i < this.b.d().j()))
					{
						Stacked100PercentColumnValue stacked100PercentColumnValue = this.a(this.c[i], i);
						if (stacked100PercentColumnValue != null)
						{
							Stacked100PercentColumnValue a_;
							if (stacked100PercentColumnValue.Value >= 0f)
							{
								a_ = this.a(A_1, A_2, 0, i);
							}
							else
							{
								a_ = this.a(A_1, A_2, 1, i);
							}
							stacked100PercentColumnValue.a(A_0, a_, i, A_3, A_4, A_2, A_5[i]);
						}
					}
				}
				this.b(A_0);
			}
		}

		// Token: 0x06005D4F RID: 23887 RVA: 0x0034DDBC File Offset: 0x0034CDBC
		private Stacked100PercentColumnValue a(Stacked100PercentColumnSeriesElement[] A_0, int A_1, int A_2, int A_3)
		{
			float[] array = new float[1];
			Stacked100PercentColumnValue result;
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
						Stacked100PercentColumnValue stacked100PercentColumnValue = A_0[i].a().a(array[A_3], A_3);
						if (stacked100PercentColumnValue != null)
						{
							if (stacked100PercentColumnValue.Value >= 0f && A_2 == 0)
							{
								return stacked100PercentColumnValue;
							}
							if (stacked100PercentColumnValue.Value < 0f && A_2 == 1)
							{
								return stacked100PercentColumnValue;
							}
						}
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06005D50 RID: 23888 RVA: 0x0034DE94 File Offset: 0x0034CE94
		private Stacked100PercentColumnValue a(float A_0, int A_1)
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				Stacked100PercentColumnValue stacked100PercentColumnValue = (Stacked100PercentColumnValue)this.a[i];
				if (stacked100PercentColumnValue is Indexed100PercentStackedColumnValue)
				{
					Indexed100PercentStackedColumnValue indexed100PercentStackedColumnValue = (Indexed100PercentStackedColumnValue)stacked100PercentColumnValue;
					if (A_0 == indexed100PercentStackedColumnValue.Value && A_1 == indexed100PercentStackedColumnValue.Position)
					{
						return stacked100PercentColumnValue;
					}
				}
				else if (stacked100PercentColumnValue is DateTime100PercentStackedColumnValue)
				{
					DateTime100PercentStackedColumnValue dateTime100PercentStackedColumnValue = (DateTime100PercentStackedColumnValue)stacked100PercentColumnValue;
					if (A_0 == dateTime100PercentStackedColumnValue.Value && A_1 == dateTime100PercentStackedColumnValue.iq())
					{
						return stacked100PercentColumnValue;
					}
				}
				else if (A_0 == stacked100PercentColumnValue.Value && A_1 == stacked100PercentColumnValue.iq())
				{
					return stacked100PercentColumnValue;
				}
			}
			return null;
		}

		// Token: 0x06005D51 RID: 23889 RVA: 0x0034DF8C File Offset: 0x0034CF8C
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

		// Token: 0x06005D52 RID: 23890 RVA: 0x0034E014 File Offset: 0x0034D014
		private void a(int A_0)
		{
			float[] destinationArray = new float[A_0 + 1];
			Array.Copy(this.c, 0, destinationArray, 0, this.c.Length);
			this.c = destinationArray;
		}

		// Token: 0x04003054 RID: 12372
		private ArrayList a;

		// Token: 0x04003055 RID: 12373
		private Stacked100PercentColumnSeriesElement b;

		// Token: 0x04003056 RID: 12374
		private float[] c = new float[1];
	}
}
