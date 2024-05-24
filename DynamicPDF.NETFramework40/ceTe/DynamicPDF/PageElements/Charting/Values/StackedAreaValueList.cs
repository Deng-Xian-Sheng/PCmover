using System;
using System.Collections;
using System.Text;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008EC RID: 2284
	public abstract class StackedAreaValueList
	{
		// Token: 0x06005DCE RID: 24014 RVA: 0x0035251F File Offset: 0x0035151F
		internal StackedAreaValueList(StackedAreaSeriesElement A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06005DCF RID: 24015 RVA: 0x00352534 File Offset: 0x00351534
		internal StackedAreaSeriesElement b()
		{
			return this.b;
		}

		// Token: 0x06005DD0 RID: 24016 RVA: 0x0035254C File Offset: 0x0035154C
		internal void a(StackedAreaValue A_0)
		{
			A_0.a(this.b);
			if (this.a != null)
			{
				if (this.a.Contains(A_0))
				{
					throw new GeneratorException("Same AreaValue object can't be added more than once.");
				}
				this.a.Add(A_0);
			}
			else
			{
				this.a = new ArrayList();
				this.a.Add(A_0);
			}
		}

		// Token: 0x06005DD1 RID: 24017 RVA: 0x003525C0 File Offset: 0x003515C0
		internal void c()
		{
			this.c = new float[this.a.Count];
			for (int i = 0; i < this.a.Count; i++)
			{
				StackedAreaValue stackedAreaValue = (StackedAreaValue)this.a[i];
				if (stackedAreaValue is IndexedStackedAreaValue)
				{
					IndexedStackedAreaValue indexedStackedAreaValue = (IndexedStackedAreaValue)stackedAreaValue;
					if (indexedStackedAreaValue.Position < this.c.Length)
					{
						this.c[indexedStackedAreaValue.Position] = indexedStackedAreaValue.Value;
					}
					else
					{
						this.a(indexedStackedAreaValue.Position);
						this.c[indexedStackedAreaValue.Position] = indexedStackedAreaValue.Value;
					}
				}
				else if (stackedAreaValue is DateTimeStackedAreaValue)
				{
					DateTimeStackedAreaValue dateTimeStackedAreaValue = (DateTimeStackedAreaValue)stackedAreaValue;
					int num = dateTimeStackedAreaValue.a();
					if (num < this.c.Length)
					{
						this.c[num] = dateTimeStackedAreaValue.Value;
					}
					else
					{
						this.a(num);
						this.c[num] = dateTimeStackedAreaValue.Value;
					}
				}
				else
				{
					this.c[i] = stackedAreaValue.Value;
					stackedAreaValue.a(i);
				}
			}
		}

		// Token: 0x06005DD2 RID: 24018 RVA: 0x00352710 File Offset: 0x00351710
		private void a(int A_0)
		{
			float[] destinationArray = new float[A_0 + 1];
			Array.Copy(this.c, 0, destinationArray, 0, this.c.Length);
			this.c = destinationArray;
		}

		// Token: 0x170009CA RID: 2506
		public StackedAreaValue this[int index]
		{
			get
			{
				StackedAreaValue result;
				if (this.a != null && index < this.a.Count)
				{
					result = (StackedAreaValue)this.a[index];
				}
				else
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x170009CB RID: 2507
		// (get) Token: 0x06005DD4 RID: 24020 RVA: 0x00352790 File Offset: 0x00351790
		public int Count
		{
			get
			{
				int result;
				if (this.a != null)
				{
					result = this.a.Count;
				}
				else
				{
					result = 0;
				}
				return result;
			}
		}

		// Token: 0x06005DD5 RID: 24021 RVA: 0x003527C0 File Offset: 0x003517C0
		internal StackedAreaValue a(float A_0, int A_1)
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				StackedAreaValue stackedAreaValue = (StackedAreaValue)this.a[i];
				if (stackedAreaValue is DateTimeStackedAreaValue)
				{
					DateTimeStackedAreaValue dateTimeStackedAreaValue = (DateTimeStackedAreaValue)stackedAreaValue;
					if (dateTimeStackedAreaValue.a() == A_1 && dateTimeStackedAreaValue.Value == A_0)
					{
						return stackedAreaValue;
					}
				}
				else if (stackedAreaValue is IndexedStackedAreaValue)
				{
					IndexedStackedAreaValue indexedStackedAreaValue = (IndexedStackedAreaValue)stackedAreaValue;
					if (indexedStackedAreaValue.Position == A_1 && indexedStackedAreaValue.Value == A_0)
					{
						return stackedAreaValue;
					}
				}
				else if (stackedAreaValue.f() == A_1 && stackedAreaValue.Value == A_0)
				{
					return stackedAreaValue;
				}
			}
			return null;
		}

		// Token: 0x06005DD6 RID: 24022 RVA: 0x003528B8 File Offset: 0x003518B8
		internal int d()
		{
			int result;
			if (this.c != null)
			{
				result = this.c.Length;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x06005DD7 RID: 24023 RVA: 0x003528E4 File Offset: 0x003518E4
		internal void e()
		{
			this.d = new ArrayList();
			for (int i = 0; i < this.c.Length; i++)
			{
				if (this.c[i] != 0f)
				{
					StackedAreaValue stackedAreaValue = this.a(this.c[i], i);
					this.d.Add(stackedAreaValue);
				}
				else
				{
					StackedAreaValue stackedAreaValue = new StackedAreaValue(0f);
					stackedAreaValue.a(this.b);
					this.d.Add(stackedAreaValue);
				}
			}
		}

		// Token: 0x06005DD8 RID: 24024 RVA: 0x00352974 File Offset: 0x00351974
		internal StackedAreaValue b(int A_0)
		{
			StackedAreaValue result;
			if (this.d != null && A_0 <= this.d.Count)
			{
				result = (StackedAreaValue)this.d[A_0];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06005DD9 RID: 24025 RVA: 0x003529BC File Offset: 0x003519BC
		internal void a(PageWriter A_0)
		{
			ValuePositionDataLabel valuePositionDataLabel = null;
			if (this.b.DataLabel != null)
			{
				valuePositionDataLabel = this.b.DataLabel;
			}
			PlotArea plotArea = this.b.PlotArea;
			for (int i = 0; i < this.d.Count; i++)
			{
				StackedAreaValue stackedAreaValue = (StackedAreaValue)this.d[i];
				float a_ = stackedAreaValue.i();
				float num = stackedAreaValue.h();
				if (stackedAreaValue.DataLabel != null)
				{
					valuePositionDataLabel = stackedAreaValue.DataLabel;
				}
				if (valuePositionDataLabel != null)
				{
					if (!plotArea.ClipToPlotArea || (plotArea.ClipToPlotArea && num + 0.001f >= plotArea.Y && num + 0.001f <= plotArea.Y + plotArea.Height))
					{
						valuePositionDataLabel.a(plotArea.Chart);
						StringBuilder stringBuilder = new StringBuilder();
						stringBuilder.Append(valuePositionDataLabel.Prefix);
						if (valuePositionDataLabel.ShowValue)
						{
							stringBuilder.Append(stackedAreaValue.Value.ToString(this.b.ValueFormat));
						}
						if (valuePositionDataLabel.ShowPosition)
						{
							if (stringBuilder.Length > 0)
							{
								stringBuilder.Append(valuePositionDataLabel.Separator + this.b.d().r().b(i));
							}
							else
							{
								stringBuilder.Append(this.b.d().r().b(i));
							}
						}
						if (valuePositionDataLabel.ShowSeries)
						{
							if (stringBuilder.Length > 0)
							{
								stringBuilder.Append(valuePositionDataLabel.Separator + this.b.Name);
							}
							else
							{
								stringBuilder.Append(this.b.Name);
							}
						}
						stringBuilder.Append(valuePositionDataLabel.Suffix);
						valuePositionDataLabel.a(A_0, a_, num, stringBuilder.ToString());
					}
				}
			}
		}

		// Token: 0x06005DDA RID: 24026 RVA: 0x00352BE4 File Offset: 0x00351BE4
		internal void a(PlotArea A_0, PageWriter A_1)
		{
			for (int i = 0; i < this.d.Count; i++)
			{
				StackedAreaValue stackedAreaValue = (StackedAreaValue)this.d[i];
				float a_ = stackedAreaValue.i();
				float num = stackedAreaValue.h();
				if (this.b.Marker != null)
				{
					if (this.b.Marker.Color == null)
					{
						this.b.Marker.Color = this.b.Color;
					}
					if (!A_0.ClipToPlotArea || (A_0.ClipToPlotArea && num + 0.001f >= A_0.Y && num + 0.001f <= A_0.Y + A_0.Height))
					{
						this.b.Marker.a(A_1, a_, num);
					}
				}
			}
		}

		// Token: 0x06005DDB RID: 24027 RVA: 0x00352CE0 File Offset: 0x00351CE0
		internal ArrayList f()
		{
			return this.d;
		}

		// Token: 0x06005DDC RID: 24028 RVA: 0x00352CF8 File Offset: 0x00351CF8
		internal float c(int A_0)
		{
			float result;
			if (this.c != null && A_0 < this.c.Length)
			{
				result = this.c[A_0];
			}
			else
			{
				result = 0f;
			}
			return result;
		}

		// Token: 0x06005DDD RID: 24029 RVA: 0x00352D38 File Offset: 0x00351D38
		internal float a(int A_0, int A_1, ArrayList A_2)
		{
			float num = 0f;
			for (int i = 0; i <= A_0; i++)
			{
				StackedAreaSeriesElement stackedAreaSeriesElement = (StackedAreaSeriesElement)A_2[i];
				float num2 = stackedAreaSeriesElement.a().c(A_1);
				num += num2;
			}
			return num;
		}

		// Token: 0x06005DDE RID: 24030 RVA: 0x00352D90 File Offset: 0x00351D90
		internal void a(PageWriter A_0, PlotArea A_1, StackedAreaSeriesElement A_2, int A_3, ArrayList A_4)
		{
			if (this.d.Count < this.b.d().j())
			{
				StackedAreaSeriesElement a_ = ((StackedAreaValue)this.a[0]).g();
				for (int i = this.d.Count + 1; i <= this.b.d().j(); i++)
				{
					StackedAreaValue stackedAreaValue = new StackedAreaValue(0f);
					stackedAreaValue.a(a_);
					this.d.Add(stackedAreaValue);
				}
			}
			if (this.c != null && this.c.Length > 0)
			{
				StackedAreaValue stackedAreaValue2 = null;
				bool flag = false;
				A_0.SetGraphicsMode();
				A_0.SetFillColor(this.b.Color);
				if (!A_1.ClipToPlotArea)
				{
					for (int j = 0; j < this.d.Count; j++)
					{
						StackedAreaValue stackedAreaValue3 = (StackedAreaValue)this.d[j];
						if (A_2 != null)
						{
							stackedAreaValue2 = A_2.a().b(j);
						}
						if (stackedAreaValue3 != null)
						{
							float num = this.a(A_3, j, A_4);
							stackedAreaValue3.a(A_0, A_1, j, this.d.Count, stackedAreaValue2, A_2, num);
						}
					}
				}
				else
				{
					for (int j = 0; j < this.b.d().j() - 1; j++)
					{
						StackedAreaValue stackedAreaValue3 = (StackedAreaValue)this.d[j];
						StackedAreaValue stackedAreaValue4 = (StackedAreaValue)this.d[j + 1];
						if (A_2 != null)
						{
							stackedAreaValue2 = A_2.a().b(j);
						}
						if (stackedAreaValue3 != null && stackedAreaValue4 != null)
						{
							float num = this.a(A_3, j, A_4);
							float a_2 = this.a(A_3, j + 1, A_4);
							float a_3 = this.a(A_3, 0, A_4);
							stackedAreaValue3.a(A_0, j, this.b.d().j(), stackedAreaValue4, A_2, num, a_2, stackedAreaValue2, (StackedAreaValue)this.d[0], a_3);
							flag = true;
						}
					}
					if (flag)
					{
						A_0.Write_f();
					}
				}
				this.a(A_1, A_0);
			}
		}

		// Token: 0x0400307C RID: 12412
		private ArrayList a;

		// Token: 0x0400307D RID: 12413
		private StackedAreaSeriesElement b;

		// Token: 0x0400307E RID: 12414
		private float[] c;

		// Token: 0x0400307F RID: 12415
		private ArrayList d;
	}
}
