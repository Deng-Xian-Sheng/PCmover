using System;
using System.Collections;
using System.Text;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008F8 RID: 2296
	public abstract class StackedLineValueList
	{
		// Token: 0x06005E49 RID: 24137 RVA: 0x003566BB File Offset: 0x003556BB
		internal StackedLineValueList(StackedLineSeriesElement A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06005E4A RID: 24138 RVA: 0x003566D0 File Offset: 0x003556D0
		internal StackedLineSeriesElement b()
		{
			return this.b;
		}

		// Token: 0x06005E4B RID: 24139 RVA: 0x003566E8 File Offset: 0x003556E8
		internal void a(StackedLineValue A_0)
		{
			A_0.a(this.b);
			if (this.a != null)
			{
				if (this.a.Contains(A_0))
				{
					throw new GeneratorException("Same LineValue object can't be added more than once.");
				}
				this.a.Add(A_0);
			}
			else
			{
				this.a = new ArrayList();
				this.a.Add(A_0);
			}
		}

		// Token: 0x06005E4C RID: 24140 RVA: 0x0035675C File Offset: 0x0035575C
		internal void c()
		{
			this.d = new char[this.c.Length];
			for (int i = 0; i < this.d.Length; i++)
			{
				this.d[i] = 'x';
			}
			for (int i = 0; i < this.d.Length; i++)
			{
				if (i == 0)
				{
					if (this.c[i] != 3.4028235E+38f)
					{
						this.d[i] = 'm';
					}
				}
				else if (this.c[i] != 3.4028235E+38f)
				{
					if (this.d[i - 1] == 'm')
					{
						this.d[i] = 'l';
					}
					else if (this.d[i - 1] == 'x')
					{
						this.d[i] = 'm';
					}
					else if (this.d[i - 1] == 'l')
					{
						this.d[i] = 'l';
					}
				}
			}
		}

		// Token: 0x06005E4D RID: 24141 RVA: 0x00356864 File Offset: 0x00355864
		internal void d()
		{
			this.c = new float[this.a.Count];
			for (int i = 0; i < this.a.Count; i++)
			{
				this.c[i] = float.MaxValue;
			}
			for (int j = 0; j < this.a.Count; j++)
			{
				StackedLineValue stackedLineValue = (StackedLineValue)this.a[j];
				if (stackedLineValue is IndexedStackedLineValue)
				{
					IndexedStackedLineValue indexedStackedLineValue = (IndexedStackedLineValue)stackedLineValue;
					if (indexedStackedLineValue.Position < this.c.Length)
					{
						this.c[indexedStackedLineValue.Position] = indexedStackedLineValue.Value;
					}
					else
					{
						this.a(indexedStackedLineValue.Position);
						this.c[indexedStackedLineValue.Position] = indexedStackedLineValue.Value;
					}
				}
				else if (stackedLineValue is DateTimeStackedLineValue)
				{
					DateTimeStackedLineValue dateTimeStackedLineValue = (DateTimeStackedLineValue)stackedLineValue;
					int num = dateTimeStackedLineValue.a();
					if (num < this.c.Length)
					{
						this.c[num] = dateTimeStackedLineValue.Value;
					}
					else
					{
						this.a(num);
						this.c[num] = dateTimeStackedLineValue.Value;
					}
				}
				else
				{
					this.c[j] = stackedLineValue.Value;
					stackedLineValue.a(j);
				}
			}
		}

		// Token: 0x06005E4E RID: 24142 RVA: 0x003569E8 File Offset: 0x003559E8
		private void a(int A_0)
		{
			float[] array = new float[A_0 + 1];
			for (int i = 0; i < this.a.Count; i++)
			{
				array[i] = float.MaxValue;
			}
			Array.Copy(this.c, 0, array, 0, this.c.Length);
			this.c = array;
		}

		// Token: 0x170009DB RID: 2523
		// (get) Token: 0x06005E4F RID: 24143 RVA: 0x00356A40 File Offset: 0x00355A40
		public int Count
		{
			get
			{
				int result;
				if (this.a == null)
				{
					result = 0;
				}
				else
				{
					result = this.a.Count;
				}
				return result;
			}
		}

		// Token: 0x170009DC RID: 2524
		public StackedLineValue this[int index]
		{
			get
			{
				StackedLineValue result;
				if (this.a != null && index < this.a.Count)
				{
					result = (StackedLineValue)this.a[index];
				}
				else
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x06005E51 RID: 24145 RVA: 0x00356ABC File Offset: 0x00355ABC
		internal float b(int A_0)
		{
			float result;
			if (this.c != null && A_0 < this.c.Length)
			{
				result = this.c[A_0];
			}
			else
			{
				result = float.MaxValue;
			}
			return result;
		}

		// Token: 0x06005E52 RID: 24146 RVA: 0x00356AFC File Offset: 0x00355AFC
		internal float c(int A_0)
		{
			float result;
			if (this.c != null && A_0 < this.c.Length)
			{
				if (this.c[A_0] != 3.4028235E+38f)
				{
					result = this.c[A_0];
				}
				else
				{
					result = 0f;
				}
			}
			else
			{
				result = 0f;
			}
			return result;
		}

		// Token: 0x06005E53 RID: 24147 RVA: 0x00356B58 File Offset: 0x00355B58
		internal StackedLineValue a(float A_0, int A_1)
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				StackedLineValue stackedLineValue = (StackedLineValue)this.a[i];
				if (stackedLineValue is DateTimeStackedLineValue)
				{
					DateTimeStackedLineValue dateTimeStackedLineValue = (DateTimeStackedLineValue)stackedLineValue;
					if (dateTimeStackedLineValue.a() == A_1 && dateTimeStackedLineValue.Value == A_0)
					{
						return stackedLineValue;
					}
				}
				else if (stackedLineValue is IndexedStackedLineValue)
				{
					IndexedStackedLineValue indexedStackedLineValue = (IndexedStackedLineValue)stackedLineValue;
					if (indexedStackedLineValue.Position == A_1 && indexedStackedLineValue.Value == A_0)
					{
						return stackedLineValue;
					}
				}
				else if (stackedLineValue.b() == A_1 && stackedLineValue.Value == A_0)
				{
					return stackedLineValue;
				}
			}
			return null;
		}

		// Token: 0x06005E54 RID: 24148 RVA: 0x00356C50 File Offset: 0x00355C50
		internal int e()
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

		// Token: 0x06005E55 RID: 24149 RVA: 0x00356C7C File Offset: 0x00355C7C
		internal int a(float A_0)
		{
			for (int i = 0; i < this.c.Length; i++)
			{
				if (A_0 == this.c[i])
				{
					return i;
				}
			}
			return int.MaxValue;
		}

		// Token: 0x06005E56 RID: 24150 RVA: 0x00356CC4 File Offset: 0x00355CC4
		internal float a(int A_0, int A_1, ArrayList A_2)
		{
			float num = 0f;
			for (int i = 0; i <= A_0; i++)
			{
				StackedLineSeriesElement stackedLineSeriesElement = (StackedLineSeriesElement)A_2[i];
				float num2 = stackedLineSeriesElement.c().b(A_1);
				if (num2 != 3.4028235E+38f)
				{
					num += num2;
				}
			}
			return num;
		}

		// Token: 0x06005E57 RID: 24151 RVA: 0x00356D28 File Offset: 0x00355D28
		internal void a(PageWriter A_0, int A_1, ArrayList A_2)
		{
			PlotArea plotArea = this.b.PlotArea;
			bool flag = false;
			if (this.c != null && this.c.Length > 0)
			{
				A_0.SetGraphicsMode();
				A_0.SetLineWidth(this.b.Width);
				A_0.SetStrokeColor(this.b.Color);
				A_0.SetLineStyle(this.b.LineStyle);
				A_0.SetLineCap(this.b.LineCap);
				A_0.SetLineJoin(this.b.LineJoin);
				bool a_ = true;
				if (this.c != null && this.c.Length > 0)
				{
					if (plotArea.ClipToPlotArea)
					{
						for (int i = 0; i < this.b.d().j() - 1; i++)
						{
							if (this.c[i] != 3.4028235E+38f && this.c[i + 1] != 3.4028235E+38f)
							{
								StackedLineValue stackedLineValue = this.a(this.c[i], i);
								StackedLineValue stackedLineValue2 = this.a(this.c[i + 1], i + 1);
								if (stackedLineValue != null && stackedLineValue2 != null)
								{
									flag = true;
									float a_2 = this.a(A_1, i, A_2);
									float a_3 = this.a(A_1, i + 1, A_2);
									stackedLineValue.a(A_0, i, stackedLineValue2, a_2, a_3, a_, this.d[i], this.d[i + 1]);
									a_ = false;
								}
							}
						}
					}
					else
					{
						for (int i = 0; i < this.c.Length - 1; i++)
						{
							if (this.c[i] != 3.4028235E+38f && this.c[i + 1] != 3.4028235E+38f)
							{
								StackedLineValue stackedLineValue = this.a(this.c[i], i);
								StackedLineValue stackedLineValue2 = this.a(this.c[i + 1], i + 1);
								if (stackedLineValue != null && stackedLineValue2 != null)
								{
									flag = true;
									float a_2 = this.a(A_1, i, A_2);
									float a_3 = this.a(A_1, i + 1, A_2);
									stackedLineValue.a(A_0, i, stackedLineValue2, a_2, a_3, a_);
									a_ = false;
								}
							}
						}
					}
				}
				if (flag && this.b.LineStyle != LineStyle.None)
				{
					A_0.Write_S();
				}
				this.a(plotArea, A_0);
			}
		}

		// Token: 0x06005E58 RID: 24152 RVA: 0x00356FF0 File Offset: 0x00355FF0
		internal void a(PageWriter A_0)
		{
			ValuePositionDataLabel valuePositionDataLabel = null;
			if (this.b.DataLabel != null)
			{
				valuePositionDataLabel = this.b.DataLabel;
			}
			PlotArea plotArea = this.b.PlotArea;
			for (int i = 0; i < this.c.Length; i++)
			{
				if (this.c[i] != 3.4028235E+38f)
				{
					StackedLineValue stackedLineValue = this.a(this.c[i], i);
					if (stackedLineValue != null)
					{
						float a_ = stackedLineValue.d();
						float num = stackedLineValue.c();
						if (stackedLineValue.DataLabel != null)
						{
							valuePositionDataLabel = stackedLineValue.DataLabel;
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
									stringBuilder.Append(stackedLineValue.Value.ToString(this.b.ValueFormat));
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
			}
		}

		// Token: 0x06005E59 RID: 24153 RVA: 0x00357240 File Offset: 0x00356240
		internal void a(PlotArea A_0, PageWriter A_1)
		{
			if (this.b.Marker != null)
			{
				if (this.b.Marker.Color == null)
				{
					this.b.Marker.Color = this.b.Color;
				}
				for (int i = 0; i < this.c.Length; i++)
				{
					if (this.c[i] != 3.4028235E+38f)
					{
						StackedLineValue stackedLineValue = this.a(this.c[i], i);
						if (stackedLineValue != null)
						{
							float num = stackedLineValue.d();
							float num2 = stackedLineValue.c();
							if (num == 0f && num2 == 0f)
							{
								float value = stackedLineValue.Value;
								num = (float)this.a(stackedLineValue.Value) * this.b.d().g();
								num2 = (value - this.b.e().v()) * this.b.e().g() / this.b.e().t() + this.b.e().g() * this.b.e().s();
								num2 = A_0.Height + A_0.Y - num2;
								num = A_0.X + this.b.d().g() * this.b.d().s() + num;
							}
							if ((A_0.ClipToPlotArea && num2 <= A_0.Y + A_0.Height && num2 >= A_0.Y) || !A_0.ClipToPlotArea)
							{
								this.b.Marker.a(A_1, num, num2);
							}
						}
					}
				}
			}
		}

		// Token: 0x040030A5 RID: 12453
		private ArrayList a;

		// Token: 0x040030A6 RID: 12454
		private StackedLineSeriesElement b;

		// Token: 0x040030A7 RID: 12455
		private float[] c;

		// Token: 0x040030A8 RID: 12456
		private char[] d;
	}
}
