using System;
using System.Collections;
using System.Text;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008E8 RID: 2280
	public abstract class LineValueList
	{
		// Token: 0x06005DA2 RID: 23970 RVA: 0x0035017F File Offset: 0x0034F17F
		internal LineValueList(LineSeries A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06005DA3 RID: 23971 RVA: 0x00350194 File Offset: 0x0034F194
		internal void a(LineValue A_0)
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

		// Token: 0x06005DA4 RID: 23972 RVA: 0x00350208 File Offset: 0x0034F208
		internal void b()
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
					if (this.c[i] != 3.4028235E+38f && !float.IsNaN(this.c[i]))
					{
						this.d[i] = 'm';
					}
				}
				else if (this.c[i] != 3.4028235E+38f && !float.IsNaN(this.c[i]))
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

		// Token: 0x06005DA5 RID: 23973 RVA: 0x00350334 File Offset: 0x0034F334
		internal LineSeries c()
		{
			return this.b;
		}

		// Token: 0x06005DA6 RID: 23974 RVA: 0x0035034C File Offset: 0x0034F34C
		internal void d()
		{
			this.c = new float[this.a.Count];
			for (int i = 0; i < this.a.Count; i++)
			{
				this.c[i] = float.MaxValue;
			}
			for (int j = 0; j < this.a.Count; j++)
			{
				LineValue lineValue = (LineValue)this.a[j];
				if (lineValue is IndexedLineValue)
				{
					IndexedLineValue indexedLineValue = (IndexedLineValue)lineValue;
					if (indexedLineValue.Position < this.c.Length)
					{
						this.c[indexedLineValue.Position] = indexedLineValue.Value;
					}
					else
					{
						this.a(indexedLineValue.Position);
						this.c[indexedLineValue.Position] = indexedLineValue.Value;
					}
				}
				else if (lineValue is DateTimeLineValue)
				{
					DateTimeLineValue dateTimeLineValue = (DateTimeLineValue)lineValue;
					int num = dateTimeLineValue.a();
					if (num < this.c.Length)
					{
						this.c[num] = dateTimeLineValue.Value;
					}
					else
					{
						this.a(num);
						this.c[num] = dateTimeLineValue.Value;
					}
				}
				else
				{
					this.c[j] = lineValue.Value;
					lineValue.a(j);
				}
			}
		}

		// Token: 0x06005DA7 RID: 23975 RVA: 0x003504D0 File Offset: 0x0034F4D0
		private void a(int A_0)
		{
			float[] array = new float[A_0 + 1];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = float.MaxValue;
			}
			Array.Copy(this.c, 0, array, 0, this.c.Length);
			this.c = array;
		}

		// Token: 0x06005DA8 RID: 23976 RVA: 0x00350520 File Offset: 0x0034F520
		internal LineValue a(float A_0, int A_1)
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				LineValue lineValue = (LineValue)this.a[i];
				if (lineValue is DateTimeLineValue)
				{
					DateTimeLineValue dateTimeLineValue = (DateTimeLineValue)lineValue;
					if (dateTimeLineValue.a() == A_1 && dateTimeLineValue.Value == A_0)
					{
						return lineValue;
					}
				}
				else if (lineValue is IndexedLineValue)
				{
					IndexedLineValue indexedLineValue = (IndexedLineValue)lineValue;
					if (indexedLineValue.Position == A_1 && indexedLineValue.Value == A_0)
					{
						return lineValue;
					}
				}
				else if (lineValue.b() == A_1 && lineValue.Value == A_0)
				{
					return lineValue;
				}
			}
			return null;
		}

		// Token: 0x06005DA9 RID: 23977 RVA: 0x00350618 File Offset: 0x0034F618
		internal int b(float A_0)
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

		// Token: 0x170009C5 RID: 2501
		public LineValue this[int index]
		{
			get
			{
				LineValue result;
				if (this.a != null && index < this.a.Count)
				{
					result = (LineValue)this.a[index];
				}
				else
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x170009C6 RID: 2502
		// (get) Token: 0x06005DAB RID: 23979 RVA: 0x003506A8 File Offset: 0x0034F6A8
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

		// Token: 0x06005DAC RID: 23980 RVA: 0x003506DC File Offset: 0x0034F6DC
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
					LineValue lineValue = this.a(this.c[i], i);
					if (lineValue != null)
					{
						if (lineValue.DataLabel != null)
						{
							valuePositionDataLabel = lineValue.DataLabel;
						}
						if (valuePositionDataLabel != null)
						{
							float num = lineValue.d();
							float num2 = lineValue.c();
							if (num == 0f && num2 == 0f)
							{
								float value = lineValue.Value;
								if (lineValue is IndexedLineValue)
								{
									num = (float)((IndexedLineValue)lineValue).Position * this.b.m().g();
								}
								else
								{
									num = (float)((DateTimeLineValue)lineValue).a() * this.b.m().g();
								}
								num2 = (value - this.b.n().v()) * this.b.n().g() / this.b.n().t() + this.b.n().g() * this.b.n().s();
								num2 = plotArea.Height + plotArea.Y - num2;
								num = plotArea.X + this.b.m().g() * this.b.m().s() + num;
							}
							if (!plotArea.ClipToPlotArea || (plotArea.ClipToPlotArea && num2 + 0.001f >= plotArea.Y && num2 + 0.001f <= plotArea.Y + plotArea.Height))
							{
								valuePositionDataLabel.a(plotArea.Chart);
								StringBuilder stringBuilder = new StringBuilder();
								stringBuilder.Append(valuePositionDataLabel.Prefix);
								if (valuePositionDataLabel.ShowValue)
								{
									stringBuilder.Append(lineValue.Value.ToString(this.b.ValueFormat));
								}
								if (valuePositionDataLabel.ShowPosition)
								{
									if (stringBuilder.Length > 0)
									{
										stringBuilder.Append(valuePositionDataLabel.Separator + this.b.m().r().b(i));
									}
									else
									{
										stringBuilder.Append(this.b.m().r().b(i));
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
								valuePositionDataLabel.a(A_0, num, num2, stringBuilder.ToString());
							}
						}
					}
				}
			}
		}

		// Token: 0x06005DAD RID: 23981 RVA: 0x00350A40 File Offset: 0x0034FA40
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
						LineValue lineValue = this.a(this.c[i], i);
						if (lineValue != null)
						{
							float num = lineValue.d();
							float num2 = lineValue.c();
							if (num == 0f && num2 == 0f)
							{
								float value = lineValue.Value;
								if (lineValue is IndexedLineValue)
								{
									num = (float)((IndexedLineValue)lineValue).Position * this.b.m().g();
								}
								else
								{
									num = (float)((DateTimeLineValue)lineValue).a() * this.b.m().g();
								}
								num2 = (value - this.b.n().v()) * this.b.n().g() / this.b.n().t() + this.b.n().g() * this.b.n().s();
								num2 = A_0.Height + A_0.Y - num2;
								num = A_0.X + this.b.m().g() * this.b.m().s() + num;
							}
							lineValue.b(num);
							lineValue.a(num2);
							if ((A_0.ClipToPlotArea && num2 <= A_0.Y + A_0.Height && num2 >= A_0.Y) || !A_0.ClipToPlotArea)
							{
								this.b.Marker.a(A_1, num, num2);
							}
						}
					}
				}
			}
		}

		// Token: 0x06005DAE RID: 23982 RVA: 0x00350C6C File Offset: 0x0034FC6C
		internal void b(PageWriter A_0)
		{
			PlotArea plotArea = this.b.PlotArea;
			bool flag = false;
			bool flag2 = true;
			if (this.c != null && this.c.Length > 0)
			{
				A_0.SetGraphicsMode();
				A_0.SetLineWidth(this.b.Width);
				A_0.SetStrokeColor(this.b.Color);
				A_0.SetLineStyle(this.b.LineStyle);
				A_0.SetLineCap(this.b.LineCap);
				A_0.SetLineJoin(this.b.LineJoin);
				if (plotArea.ClipToPlotArea)
				{
					float num;
					if (this.c.Length < plotArea.i().j())
					{
						num = (float)this.c.Length;
					}
					else
					{
						num = (float)plotArea.i().j();
					}
					int i = 0;
					while ((float)i < num - 1f)
					{
						if (i <= this.c.Length - 1)
						{
							if (this.c[i] != 3.4028235E+38f && this.c[i + 1] != 3.4028235E+38f && !float.IsNaN(this.c[i]) && !float.IsNaN(this.c[i + 1]))
							{
								LineValue lineValue = this.a(this.c[i], i);
								LineValue lineValue2 = this.a(this.c[i + 1], i + 1);
								if (lineValue != null && lineValue2 != null)
								{
									flag = true;
									lineValue.a(A_0, i, lineValue2, this.d[i], this.d[i + 1], flag2);
								}
								flag2 = false;
							}
							else if (!flag2)
							{
								A_0.Write_S();
								flag2 = true;
							}
						}
						i++;
					}
				}
				else
				{
					for (int i = 0; i < this.c.Length - 1; i++)
					{
						if (this.c[i] != 3.4028235E+38f && this.c[i + 1] != 3.4028235E+38f && !float.IsNaN(this.c[i]) && !float.IsNaN(this.c[i + 1]))
						{
							LineValue lineValue = this.a(this.c[i], i);
							LineValue lineValue2 = this.a(this.c[i + 1], i + 1);
							if (lineValue != null && lineValue2 != null)
							{
								flag = true;
								lineValue.a(A_0, i, lineValue2, flag2);
							}
							flag2 = false;
						}
						else if (!flag2)
						{
							A_0.Write_S();
							flag2 = true;
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

		// Token: 0x0400306C RID: 12396
		private ArrayList a;

		// Token: 0x0400306D RID: 12397
		private LineSeries b;

		// Token: 0x0400306E RID: 12398
		private float[] c;

		// Token: 0x0400306F RID: 12399
		private char[] d;
	}
}
