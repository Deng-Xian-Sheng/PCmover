using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008CF RID: 2255
	public abstract class ColumnValueList
	{
		// Token: 0x06005CC4 RID: 23748 RVA: 0x003489B9 File Offset: 0x003479B9
		internal ColumnValueList(ColumnSeries A_0)
		{
			this.b = A_0;
			this.a = new ArrayList();
		}

		// Token: 0x170009A7 RID: 2471
		// (get) Token: 0x06005CC5 RID: 23749 RVA: 0x003489E4 File Offset: 0x003479E4
		public int Count
		{
			get
			{
				return this.a.Count;
			}
		}

		// Token: 0x170009A8 RID: 2472
		public ColumnValue this[int index]
		{
			get
			{
				return (ColumnValue)this.a[index];
			}
		}

		// Token: 0x06005CC7 RID: 23751 RVA: 0x00348A28 File Offset: 0x00347A28
		internal void a(ColumnValue A_0)
		{
			if (!this.a.Contains(A_0))
			{
				this.a.Add(A_0);
				A_0.a(this.b);
				if (A_0 is DateTimeColumnValue)
				{
					this.b.ii(((DateTimeColumnValue)A_0).Position);
					this.b.ik(((DateTimeColumnValue)A_0).Position);
				}
				else if (A_0 is IndexedColumnValue)
				{
					this.b.iy((float)((IndexedColumnValue)A_0).Position);
					if (this.a.Count == 1)
					{
						this.b.i0(0f);
					}
					this.b.i0((float)((IndexedColumnValue)A_0).Position);
				}
				else
				{
					this.a();
				}
				this.a(A_0.Value);
				return;
			}
			throw new GeneratorException("Same ColumnValue object can't be added more than once.");
		}

		// Token: 0x06005CC8 RID: 23752 RVA: 0x00348B34 File Offset: 0x00347B34
		internal void b()
		{
			this.c = new float[this.a.Count];
			for (int i = 0; i < this.a.Count; i++)
			{
				ColumnValue columnValue = (ColumnValue)this.a[i];
				if (columnValue is IndexedColumnValue)
				{
					IndexedColumnValue indexedColumnValue = (IndexedColumnValue)columnValue;
					if (indexedColumnValue.Position < this.c.Length)
					{
						this.c[indexedColumnValue.Position] = indexedColumnValue.Value;
					}
					else
					{
						this.a(indexedColumnValue.Position);
						this.c[indexedColumnValue.Position] = indexedColumnValue.Value;
					}
				}
				else if (columnValue is DateTimeColumnValue)
				{
					DateTimeColumnValue dateTimeColumnValue = (DateTimeColumnValue)columnValue;
					int num = dateTimeColumnValue.@is();
					if (num < 0)
					{
						throw new GeneratorException("position should not be less than minDate.");
					}
					if (num < this.c.Length)
					{
						this.c[num] = dateTimeColumnValue.Value;
					}
					else
					{
						this.a(num);
						this.c[num] = dateTimeColumnValue.Value;
					}
				}
				else
				{
					this.c[i] = columnValue.Value;
					columnValue.a(i);
				}
			}
		}

		// Token: 0x06005CC9 RID: 23753 RVA: 0x00348CA4 File Offset: 0x00347CA4
		internal void a(PageWriter A_0, int A_1, int A_2)
		{
			if (this.a.Count > 0)
			{
				A_0.SetGraphicsMode();
				for (int i = 0; i < this.c.Length; i++)
				{
					if (!this.b.PlotArea.ClipToPlotArea || (this.b.PlotArea.ClipToPlotArea && i < this.b.m().j()))
					{
						ColumnValue columnValue = this.a(this.c[i], i);
						if (columnValue != null)
						{
							columnValue.a(A_0, i, A_1, A_2);
						}
					}
				}
				this.a(A_0);
			}
		}

		// Token: 0x06005CCA RID: 23754 RVA: 0x00348D64 File Offset: 0x00347D64
		internal void b(PageWriter A_0)
		{
			for (int i = 0; i < this.c.Length; i++)
			{
				if (!this.b.PlotArea.ClipToPlotArea || (this.b.PlotArea.ClipToPlotArea && i < this.b.m().j()))
				{
					ColumnValue columnValue = this.a(this.c[i], i);
					if (columnValue != null && columnValue.e() != 0f)
					{
						columnValue.a(A_0, i);
					}
				}
			}
		}

		// Token: 0x06005CCB RID: 23755 RVA: 0x00348E0C File Offset: 0x00347E0C
		private void a(PageWriter A_0)
		{
			if (this.a.Count > 0 && this.b.BorderColor != null)
			{
				A_0.SetLineWidth(this.b.BorderWidth);
				A_0.SetLineStyle(LineStyle.Solid);
				A_0.SetStrokeColor(this.b.BorderColor);
				for (int i = 0; i < this.c.Length; i++)
				{
					if (!this.b.PlotArea.ClipToPlotArea || (this.b.PlotArea.ClipToPlotArea && i < this.b.m().j()))
					{
						ColumnValue columnValue = this.a(this.c[i], i);
						if (columnValue != null && columnValue.e() != 0f)
						{
							columnValue.a(A_0);
						}
					}
				}
			}
		}

		// Token: 0x06005CCC RID: 23756 RVA: 0x00348F0C File Offset: 0x00347F0C
		private ColumnValue a(float A_0, int A_1)
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				ColumnValue columnValue = (ColumnValue)this.a[i];
				if (columnValue is IndexedColumnValue)
				{
					IndexedColumnValue indexedColumnValue = (IndexedColumnValue)columnValue;
					if (A_0 == indexedColumnValue.Value && A_1 == indexedColumnValue.Position)
					{
						return columnValue;
					}
				}
				else if (columnValue is DateTimeColumnValue)
				{
					DateTimeColumnValue dateTimeColumnValue = (DateTimeColumnValue)columnValue;
					if (A_0 == dateTimeColumnValue.Value && A_1 == dateTimeColumnValue.@is())
					{
						return columnValue;
					}
				}
				else if (A_0 == columnValue.Value && A_1 == columnValue.@is())
				{
					return columnValue;
				}
			}
			return null;
		}

		// Token: 0x06005CCD RID: 23757 RVA: 0x00349001 File Offset: 0x00348001
		private void a(float A_0)
		{
			this.b.a(A_0);
			this.b.b(A_0);
		}

		// Token: 0x06005CCE RID: 23758 RVA: 0x00349020 File Offset: 0x00348020
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

		// Token: 0x06005CCF RID: 23759 RVA: 0x003490A8 File Offset: 0x003480A8
		private void a(int A_0)
		{
			float[] destinationArray = new float[A_0 + 1];
			Array.Copy(this.c, 0, destinationArray, 0, this.c.Length);
			this.c = destinationArray;
		}

		// Token: 0x04003024 RID: 12324
		private ArrayList a;

		// Token: 0x04003025 RID: 12325
		private ColumnSeries b;

		// Token: 0x04003026 RID: 12326
		private float[] c = new float[1];
	}
}
