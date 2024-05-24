using System;
using System.Collections;
using System.Text;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008DE RID: 2270
	public abstract class Stacked100PercentLineValueList
	{
		// Token: 0x06005D66 RID: 23910 RVA: 0x0034E897 File Offset: 0x0034D897
		internal Stacked100PercentLineValueList(Stacked100PercentLineSeriesElement A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06005D67 RID: 23911 RVA: 0x0034E8AC File Offset: 0x0034D8AC
		internal Stacked100PercentLineSeriesElement b()
		{
			return this.b;
		}

		// Token: 0x06005D68 RID: 23912 RVA: 0x0034E8C4 File Offset: 0x0034D8C4
		internal void a(Stacked100PercentLineValue A_0)
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

		// Token: 0x06005D69 RID: 23913 RVA: 0x0034E938 File Offset: 0x0034D938
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

		// Token: 0x06005D6A RID: 23914 RVA: 0x0034EA40 File Offset: 0x0034DA40
		internal void d()
		{
			this.c = new float[this.a.Count];
			for (int i = 0; i < this.a.Count; i++)
			{
				this.c[i] = float.MaxValue;
			}
			for (int j = 0; j < this.a.Count; j++)
			{
				Stacked100PercentLineValue stacked100PercentLineValue = (Stacked100PercentLineValue)this.a[j];
				if (stacked100PercentLineValue is Indexed100PercentStackedLineValue)
				{
					Indexed100PercentStackedLineValue indexed100PercentStackedLineValue = (Indexed100PercentStackedLineValue)stacked100PercentLineValue;
					if (indexed100PercentStackedLineValue.Position < this.c.Length)
					{
						this.c[indexed100PercentStackedLineValue.Position] = indexed100PercentStackedLineValue.Value;
					}
					else
					{
						this.a(indexed100PercentStackedLineValue.Position);
						this.c[indexed100PercentStackedLineValue.Position] = indexed100PercentStackedLineValue.Value;
					}
				}
				else if (stacked100PercentLineValue is DateTime100PercentStackedLineValue)
				{
					DateTime100PercentStackedLineValue dateTime100PercentStackedLineValue = (DateTime100PercentStackedLineValue)stacked100PercentLineValue;
					int num = dateTime100PercentStackedLineValue.a();
					if (num < this.c.Length)
					{
						this.c[num] = dateTime100PercentStackedLineValue.Value;
					}
					else
					{
						this.a(num);
						this.c[num] = dateTime100PercentStackedLineValue.Value;
					}
				}
				else
				{
					this.c[j] = stacked100PercentLineValue.Value;
					stacked100PercentLineValue.a(j);
				}
			}
		}

		// Token: 0x06005D6B RID: 23915 RVA: 0x0034EBC4 File Offset: 0x0034DBC4
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

		// Token: 0x170009BD RID: 2493
		// (get) Token: 0x06005D6C RID: 23916 RVA: 0x0034EC1C File Offset: 0x0034DC1C
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

		// Token: 0x170009BE RID: 2494
		public Stacked100PercentLineValue this[int index]
		{
			get
			{
				Stacked100PercentLineValue result;
				if (this.a != null && index < this.a.Count)
				{
					result = (Stacked100PercentLineValue)this.a[index];
				}
				else
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x06005D6E RID: 23918 RVA: 0x0034EC98 File Offset: 0x0034DC98
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

		// Token: 0x06005D6F RID: 23919 RVA: 0x0034ECD8 File Offset: 0x0034DCD8
		internal ArrayList e()
		{
			return this.a;
		}

		// Token: 0x06005D70 RID: 23920 RVA: 0x0034ECF0 File Offset: 0x0034DCF0
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

		// Token: 0x06005D71 RID: 23921 RVA: 0x0034ED4C File Offset: 0x0034DD4C
		internal Stacked100PercentLineValue a(float A_0, int A_1)
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				Stacked100PercentLineValue stacked100PercentLineValue = (Stacked100PercentLineValue)this.a[i];
				if (stacked100PercentLineValue is DateTime100PercentStackedLineValue)
				{
					DateTime100PercentStackedLineValue dateTime100PercentStackedLineValue = (DateTime100PercentStackedLineValue)stacked100PercentLineValue;
					if (dateTime100PercentStackedLineValue.a() == A_1 && dateTime100PercentStackedLineValue.Value == A_0)
					{
						return stacked100PercentLineValue;
					}
				}
				else if (stacked100PercentLineValue is Indexed100PercentStackedLineValue)
				{
					Indexed100PercentStackedLineValue indexed100PercentStackedLineValue = (Indexed100PercentStackedLineValue)stacked100PercentLineValue;
					if (indexed100PercentStackedLineValue.Position == A_1 && indexed100PercentStackedLineValue.Value == A_0)
					{
						return stacked100PercentLineValue;
					}
				}
				else if (stacked100PercentLineValue.b() == A_1 && stacked100PercentLineValue.Value == A_0)
				{
					return stacked100PercentLineValue;
				}
			}
			return null;
		}

		// Token: 0x06005D72 RID: 23922 RVA: 0x0034EE44 File Offset: 0x0034DE44
		internal int f()
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

		// Token: 0x06005D73 RID: 23923 RVA: 0x0034EE70 File Offset: 0x0034DE70
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

		// Token: 0x06005D74 RID: 23924 RVA: 0x0034EEB8 File Offset: 0x0034DEB8
		internal float a(int A_0, int A_1, ArrayList A_2)
		{
			float num = 0f;
			for (int i = 0; i <= A_0; i++)
			{
				Stacked100PercentLineSeriesElement stacked100PercentLineSeriesElement = (Stacked100PercentLineSeriesElement)A_2[i];
				float num2 = stacked100PercentLineSeriesElement.c().b(A_1);
				if (num2 != 3.4028235E+38f)
				{
					num += num2;
				}
			}
			return num;
		}

		// Token: 0x06005D75 RID: 23925 RVA: 0x0034EF1C File Offset: 0x0034DF1C
		internal void a(PageWriter A_0, float[] A_1, int A_2, ArrayList A_3)
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
						for (int i = 0; i < this.c.Length - 1; i++)
						{
							if (this.c[i] != 3.4028235E+38f && this.c[i + 1] != 3.4028235E+38f)
							{
								Stacked100PercentLineValue stacked100PercentLineValue = this.a(this.c[i], i);
								Stacked100PercentLineValue stacked100PercentLineValue2 = this.a(this.c[i + 1], i + 1);
								if (stacked100PercentLineValue != null && stacked100PercentLineValue2 != null)
								{
									flag = true;
									float a_2 = this.a(A_2, i, A_3);
									float a_3 = this.a(A_2, i + 1, A_3);
									stacked100PercentLineValue.a(A_0, i, stacked100PercentLineValue2, A_1[i], A_1[i + 1], a_2, a_3, a_, this.d[i], this.d[i + 1]);
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
								Stacked100PercentLineValue stacked100PercentLineValue = this.a(this.c[i], i);
								Stacked100PercentLineValue stacked100PercentLineValue2 = this.a(this.c[i + 1], i + 1);
								if (stacked100PercentLineValue != null && stacked100PercentLineValue2 != null)
								{
									flag = true;
									float a_2 = this.a(A_2, i, A_3);
									float a_3 = this.a(A_2, i + 1, A_3);
									stacked100PercentLineValue.a(A_0, i, stacked100PercentLineValue2, A_1[i], A_1[i + 1], a_2, a_3);
								}
							}
						}
					}
					if (flag && this.b.LineStyle != LineStyle.None)
					{
						A_0.Write_S();
					}
				}
				this.a(plotArea, A_0);
			}
		}

		// Token: 0x06005D76 RID: 23926 RVA: 0x0034F1F0 File Offset: 0x0034E1F0
		internal void a(PageWriter A_0, float[] A_1)
		{
			PercentageDataLabel percentageDataLabel = null;
			if (this.b.DataLabel != null)
			{
				percentageDataLabel = this.b.DataLabel;
			}
			PlotArea plotArea = this.b.PlotArea;
			for (int i = 0; i < this.c.Length; i++)
			{
				if (this.c[i] != 3.4028235E+38f)
				{
					Stacked100PercentLineValue stacked100PercentLineValue = this.a(this.c[i], i);
					if (stacked100PercentLineValue != null)
					{
						float a_ = stacked100PercentLineValue.d();
						float num = stacked100PercentLineValue.c();
						if (stacked100PercentLineValue.DataLabel != null)
						{
							percentageDataLabel = stacked100PercentLineValue.DataLabel;
						}
						if (percentageDataLabel != null)
						{
							if (!plotArea.ClipToPlotArea || (plotArea.ClipToPlotArea && num + 0.001f >= plotArea.Y && num + 0.001f <= plotArea.Y + plotArea.Height))
							{
								percentageDataLabel.a(plotArea.Chart);
								StringBuilder stringBuilder = new StringBuilder();
								stringBuilder.Append(percentageDataLabel.Prefix);
								if (percentageDataLabel.ShowValue)
								{
									stringBuilder.Append(stacked100PercentLineValue.Value.ToString(this.b.ValueFormat));
								}
								if (percentageDataLabel.ShowPosition)
								{
									if (stringBuilder.Length > 0)
									{
										stringBuilder.Append(percentageDataLabel.Separator + this.b.d().r().b(i));
									}
									else
									{
										stringBuilder.Append(this.b.d().r().b(i));
									}
								}
								if (percentageDataLabel.ShowSeries)
								{
									if (stringBuilder.Length > 0)
									{
										stringBuilder.Append(percentageDataLabel.Separator + this.b.Name);
									}
									else
									{
										stringBuilder.Append(this.b.Name);
									}
								}
								if (percentageDataLabel.ShowPercentage)
								{
									int num2 = this.b.PercentageFormat.IndexOf('%');
									float num3;
									if (num2 == -1)
									{
										num3 = stacked100PercentLineValue.Value / A_1[i] * 100f;
									}
									else
									{
										num3 = stacked100PercentLineValue.Value / A_1[i];
									}
									if (stringBuilder.Length > 0)
									{
										stringBuilder.Append(percentageDataLabel.Separator + num3.ToString(this.b.PercentageFormat));
									}
									else
									{
										stringBuilder.Append(num3.ToString(this.b.PercentageFormat));
									}
								}
								stringBuilder.Append(percentageDataLabel.Suffix);
								percentageDataLabel.a(A_0, a_, num, stringBuilder.ToString());
							}
						}
					}
				}
			}
		}

		// Token: 0x06005D77 RID: 23927 RVA: 0x0034F4E8 File Offset: 0x0034E4E8
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
						Stacked100PercentLineValue stacked100PercentLineValue = this.a(this.c[i], i);
						if (stacked100PercentLineValue != null)
						{
							float num = stacked100PercentLineValue.d();
							float num2 = stacked100PercentLineValue.c();
							if (num == 0f && num2 == 0f)
							{
								float value = stacked100PercentLineValue.Value;
								num = (float)this.a(stacked100PercentLineValue.Value) * this.b.d().g();
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

		// Token: 0x0400305E RID: 12382
		private ArrayList a;

		// Token: 0x0400305F RID: 12383
		private Stacked100PercentLineSeriesElement b;

		// Token: 0x04003060 RID: 12384
		private float[] c;

		// Token: 0x04003061 RID: 12385
		private char[] d;
	}
}
