using System;
using System.Collections;
using System.Text;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008D2 RID: 2258
	public abstract class Stacked100PercentAreaValueList
	{
		// Token: 0x06005CEA RID: 23786 RVA: 0x0034A583 File Offset: 0x00349583
		internal Stacked100PercentAreaValueList(Stacked100PercentAreaSeriesElement A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06005CEB RID: 23787 RVA: 0x0034A598 File Offset: 0x00349598
		internal Stacked100PercentAreaSeriesElement b()
		{
			return this.b;
		}

		// Token: 0x06005CEC RID: 23788 RVA: 0x0034A5B0 File Offset: 0x003495B0
		internal void a(Stacked100PercentAreaValue A_0)
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

		// Token: 0x06005CED RID: 23789 RVA: 0x0034A624 File Offset: 0x00349624
		internal void c()
		{
			this.c = new float[this.a.Count];
			for (int i = 0; i < this.a.Count; i++)
			{
				Stacked100PercentAreaValue stacked100PercentAreaValue = (Stacked100PercentAreaValue)this.a[i];
				if (stacked100PercentAreaValue is Indexed100PercentStackedAreaValue)
				{
					Indexed100PercentStackedAreaValue indexed100PercentStackedAreaValue = (Indexed100PercentStackedAreaValue)stacked100PercentAreaValue;
					if (indexed100PercentStackedAreaValue.Position < this.c.Length)
					{
						this.c[indexed100PercentStackedAreaValue.Position] = indexed100PercentStackedAreaValue.Value;
					}
					else
					{
						this.a(indexed100PercentStackedAreaValue.Position);
						this.c[indexed100PercentStackedAreaValue.Position] = indexed100PercentStackedAreaValue.Value;
					}
				}
				else if (stacked100PercentAreaValue is DateTime100PercentStackedAreaValue)
				{
					DateTime100PercentStackedAreaValue dateTime100PercentStackedAreaValue = (DateTime100PercentStackedAreaValue)stacked100PercentAreaValue;
					int num = dateTime100PercentStackedAreaValue.a();
					if (num < this.c.Length)
					{
						this.c[num] = dateTime100PercentStackedAreaValue.Value;
					}
					else
					{
						this.a(num);
						this.c[num] = dateTime100PercentStackedAreaValue.Value;
					}
				}
				else
				{
					this.c[i] = stacked100PercentAreaValue.Value;
					stacked100PercentAreaValue.a(i);
				}
			}
		}

		// Token: 0x06005CEE RID: 23790 RVA: 0x0034A770 File Offset: 0x00349770
		private void a(int A_0)
		{
			float[] destinationArray = new float[A_0 + 1];
			Array.Copy(this.c, 0, destinationArray, 0, this.c.Length);
			this.c = destinationArray;
		}

		// Token: 0x170009AC RID: 2476
		public Stacked100PercentAreaValue this[int index]
		{
			get
			{
				Stacked100PercentAreaValue result;
				if (this.a != null && index < this.a.Count)
				{
					result = (Stacked100PercentAreaValue)this.a[index];
				}
				else
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x170009AD RID: 2477
		// (get) Token: 0x06005CF0 RID: 23792 RVA: 0x0034A7F0 File Offset: 0x003497F0
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

		// Token: 0x06005CF1 RID: 23793 RVA: 0x0034A820 File Offset: 0x00349820
		internal Stacked100PercentAreaValue a(float A_0, int A_1)
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				Stacked100PercentAreaValue stacked100PercentAreaValue = (Stacked100PercentAreaValue)this.a[i];
				if (stacked100PercentAreaValue is DateTime100PercentStackedAreaValue)
				{
					DateTime100PercentStackedAreaValue dateTime100PercentStackedAreaValue = (DateTime100PercentStackedAreaValue)stacked100PercentAreaValue;
					if (dateTime100PercentStackedAreaValue.a() == A_1 && dateTime100PercentStackedAreaValue.Value == A_0)
					{
						return stacked100PercentAreaValue;
					}
				}
				else if (stacked100PercentAreaValue is Indexed100PercentStackedAreaValue)
				{
					Indexed100PercentStackedAreaValue indexed100PercentStackedAreaValue = (Indexed100PercentStackedAreaValue)stacked100PercentAreaValue;
					if (indexed100PercentStackedAreaValue.Position == A_1 && indexed100PercentStackedAreaValue.Value == A_0)
					{
						return stacked100PercentAreaValue;
					}
				}
				else if (stacked100PercentAreaValue.f() == A_1 && stacked100PercentAreaValue.Value == A_0)
				{
					return stacked100PercentAreaValue;
				}
			}
			return null;
		}

		// Token: 0x06005CF2 RID: 23794 RVA: 0x0034A918 File Offset: 0x00349918
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

		// Token: 0x06005CF3 RID: 23795 RVA: 0x0034A944 File Offset: 0x00349944
		internal void e()
		{
			this.d = new ArrayList();
			for (int i = 0; i < this.c.Length; i++)
			{
				if (this.c[i] != 0f)
				{
					Stacked100PercentAreaValue stacked100PercentAreaValue = this.a(this.c[i], i);
					this.d.Add(stacked100PercentAreaValue);
				}
				else
				{
					Stacked100PercentAreaValue stacked100PercentAreaValue = new Stacked100PercentAreaValue(0f);
					stacked100PercentAreaValue.a(this.b);
					this.d.Add(stacked100PercentAreaValue);
				}
			}
		}

		// Token: 0x06005CF4 RID: 23796 RVA: 0x0034A9D4 File Offset: 0x003499D4
		internal Stacked100PercentAreaValue b(int A_0)
		{
			Stacked100PercentAreaValue result;
			if (this.d != null && A_0 <= this.d.Count)
			{
				result = (Stacked100PercentAreaValue)this.d[A_0];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06005CF5 RID: 23797 RVA: 0x0034AA1C File Offset: 0x00349A1C
		internal void a(PageWriter A_0, float[] A_1)
		{
			PercentageDataLabel percentageDataLabel = null;
			if (this.b.DataLabel != null)
			{
				percentageDataLabel = this.b.DataLabel;
			}
			PlotArea plotArea = this.b.PlotArea;
			for (int i = 0; i < this.d.Count; i++)
			{
				Stacked100PercentAreaValue stacked100PercentAreaValue = (Stacked100PercentAreaValue)this.d[i];
				float a_ = stacked100PercentAreaValue.i();
				float num = stacked100PercentAreaValue.h();
				if (stacked100PercentAreaValue.DataLabel != null)
				{
					percentageDataLabel = stacked100PercentAreaValue.DataLabel;
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
							stringBuilder.Append(stacked100PercentAreaValue.Value.ToString(this.b.ValueFormat));
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
								num3 = stacked100PercentAreaValue.Value / A_1[i] * 100f;
							}
							else
							{
								num3 = stacked100PercentAreaValue.Value / A_1[i];
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

		// Token: 0x06005CF6 RID: 23798 RVA: 0x0034ACEC File Offset: 0x00349CEC
		internal void a(PlotArea A_0, PageWriter A_1)
		{
			for (int i = 0; i < this.d.Count; i++)
			{
				Stacked100PercentAreaValue stacked100PercentAreaValue = (Stacked100PercentAreaValue)this.d[i];
				float a_ = stacked100PercentAreaValue.i();
				float num = stacked100PercentAreaValue.h();
				if (this.b.Marker != null)
				{
					if (this.b.Marker.Color == null)
					{
						this.b.Marker.Color = this.b.Color;
					}
					if ((A_0.ClipToPlotArea && num <= A_0.Y + A_0.Height && num >= A_0.Y) || !A_0.ClipToPlotArea)
					{
						this.b.Marker.a(A_1, a_, num);
					}
				}
			}
		}

		// Token: 0x06005CF7 RID: 23799 RVA: 0x0034ADD4 File Offset: 0x00349DD4
		internal ArrayList f()
		{
			return this.d;
		}

		// Token: 0x06005CF8 RID: 23800 RVA: 0x0034ADEC File Offset: 0x00349DEC
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

		// Token: 0x06005CF9 RID: 23801 RVA: 0x0034AE30 File Offset: 0x00349E30
		internal float a(int A_0, int A_1, ArrayList A_2)
		{
			float num = 0f;
			for (int i = 0; i <= A_0; i++)
			{
				Stacked100PercentAreaSeriesElement stacked100PercentAreaSeriesElement = (Stacked100PercentAreaSeriesElement)A_2[i];
				float num2 = stacked100PercentAreaSeriesElement.a().c(A_1);
				num += num2;
			}
			return num;
		}

		// Token: 0x06005CFA RID: 23802 RVA: 0x0034AE88 File Offset: 0x00349E88
		internal void a(PageWriter A_0, PlotArea A_1, Stacked100PercentAreaSeriesElement A_2, float[] A_3, int A_4, ArrayList A_5)
		{
			if (this.d.Count < this.b.d().j())
			{
				Stacked100PercentAreaSeriesElement a_ = ((Stacked100PercentAreaValue)this.a[0]).g();
				for (int i = this.d.Count + 1; i <= this.b.d().j(); i++)
				{
					Stacked100PercentAreaValue stacked100PercentAreaValue = new Stacked100PercentAreaValue(0f);
					stacked100PercentAreaValue.a(a_);
					this.d.Add(stacked100PercentAreaValue);
				}
			}
			if (this.c != null && this.c.Length > 0)
			{
				A_0.SetGraphicsMode();
				A_0.SetFillColor(this.b.Color);
				Stacked100PercentAreaValue stacked100PercentAreaValue2 = null;
				bool flag = false;
				if (!A_1.ClipToPlotArea)
				{
					for (int j = 0; j < this.d.Count; j++)
					{
						Stacked100PercentAreaValue stacked100PercentAreaValue3 = (Stacked100PercentAreaValue)this.d[j];
						if (A_2 != null)
						{
							stacked100PercentAreaValue2 = A_2.a().b(j);
						}
						if (stacked100PercentAreaValue3 != null)
						{
							float num = this.a(A_4, j, A_5);
							stacked100PercentAreaValue3.a(A_0, A_1, j, this.d.Count, stacked100PercentAreaValue2, A_2, A_3[j], num);
						}
					}
				}
				else
				{
					for (int j = 0; j < this.b.d().j() - 1; j++)
					{
						Stacked100PercentAreaValue stacked100PercentAreaValue3 = (Stacked100PercentAreaValue)this.d[j];
						Stacked100PercentAreaValue stacked100PercentAreaValue4 = (Stacked100PercentAreaValue)this.d[j + 1];
						if (A_2 != null)
						{
							stacked100PercentAreaValue2 = A_2.a().b(j);
						}
						if (stacked100PercentAreaValue3 != null && stacked100PercentAreaValue4 != null)
						{
							float num = this.a(A_4, j, A_5);
							float a_2 = this.a(A_4, j + 1, A_5);
							float a_3 = this.a(A_4, 0, A_5);
							stacked100PercentAreaValue3.a(A_0, j, A_3[j], A_3[j + 1], num, a_2, this.b.d().j(), stacked100PercentAreaValue4, stacked100PercentAreaValue2, A_2, (Stacked100PercentAreaValue)this.d[0], a_3);
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

		// Token: 0x04003033 RID: 12339
		private ArrayList a;

		// Token: 0x04003034 RID: 12340
		private Stacked100PercentAreaSeriesElement b;

		// Token: 0x04003035 RID: 12341
		private float[] c;

		// Token: 0x04003036 RID: 12342
		private ArrayList d;
	}
}
