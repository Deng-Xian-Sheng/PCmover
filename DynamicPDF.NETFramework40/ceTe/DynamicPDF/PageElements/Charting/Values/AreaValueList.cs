using System;
using System.Collections;
using System.Text;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008CB RID: 2251
	public abstract class AreaValueList
	{
		// Token: 0x06005C84 RID: 23684 RVA: 0x003465DD File Offset: 0x003455DD
		internal AreaValueList(AreaSeries A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06005C85 RID: 23685 RVA: 0x003465F0 File Offset: 0x003455F0
		internal void a(AreaValue A_0)
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

		// Token: 0x06005C86 RID: 23686 RVA: 0x00346664 File Offset: 0x00345664
		internal void b()
		{
			this.c = new float[this.a.Count];
			for (int i = 0; i < this.a.Count; i++)
			{
				AreaValue areaValue = (AreaValue)this.a[i];
				if (areaValue is IndexedAreaValue)
				{
					IndexedAreaValue indexedAreaValue = (IndexedAreaValue)areaValue;
					if (indexedAreaValue.Position < this.c.Length)
					{
						this.c[indexedAreaValue.Position] = indexedAreaValue.Value;
					}
					else
					{
						this.a(indexedAreaValue.Position);
						this.c[indexedAreaValue.Position] = indexedAreaValue.Value;
					}
				}
				else if (areaValue is DateTimeAreaValue)
				{
					DateTimeAreaValue dateTimeAreaValue = (DateTimeAreaValue)areaValue;
					int num = dateTimeAreaValue.a();
					if (num < this.c.Length)
					{
						this.c[num] = dateTimeAreaValue.Value;
					}
					else
					{
						this.a(num);
						this.c[num] = dateTimeAreaValue.Value;
					}
				}
				else
				{
					this.c[i] = areaValue.Value;
					areaValue.a(i);
				}
			}
		}

		// Token: 0x06005C87 RID: 23687 RVA: 0x003467B4 File Offset: 0x003457B4
		private void a(int A_0)
		{
			float[] destinationArray = new float[A_0 + 1];
			Array.Copy(this.c, 0, destinationArray, 0, this.c.Length);
			this.c = destinationArray;
		}

		// Token: 0x1700099D RID: 2461
		// (get) Token: 0x06005C88 RID: 23688 RVA: 0x003467EC File Offset: 0x003457EC
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

		// Token: 0x06005C89 RID: 23689 RVA: 0x0034681C File Offset: 0x0034581C
		internal AreaSeries c()
		{
			return this.b;
		}

		// Token: 0x1700099E RID: 2462
		public AreaValue this[int index]
		{
			get
			{
				AreaValue result;
				if (this.a != null && index < this.a.Count)
				{
					result = (AreaValue)this.a[index];
				}
				else
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x06005C8B RID: 23691 RVA: 0x0034687C File Offset: 0x0034587C
		internal AreaValue a(float A_0, int A_1)
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				AreaValue areaValue = (AreaValue)this.a[i];
				if (areaValue is DateTimeAreaValue)
				{
					DateTimeAreaValue dateTimeAreaValue = (DateTimeAreaValue)areaValue;
					if (dateTimeAreaValue.a() == A_1 && dateTimeAreaValue.Value == A_0)
					{
						return areaValue;
					}
				}
				else if (areaValue is IndexedAreaValue)
				{
					IndexedAreaValue indexedAreaValue = (IndexedAreaValue)areaValue;
					if (indexedAreaValue.Position == A_1 && indexedAreaValue.Value == A_0)
					{
						return areaValue;
					}
				}
				else if (areaValue.b() == A_1 && areaValue.Value == A_0)
				{
					return areaValue;
				}
			}
			return null;
		}

		// Token: 0x06005C8C RID: 23692 RVA: 0x00346974 File Offset: 0x00345974
		internal void d()
		{
			this.d = new ArrayList();
			for (int i = 0; i < this.c.Length; i++)
			{
				if (this.c[i] != 0f)
				{
					AreaValue areaValue = this.a(this.c[i], i);
					this.d.Add(areaValue);
				}
				else
				{
					AreaValue areaValue = new AreaValue(0f);
					areaValue.a(this.b);
					this.d.Add(areaValue);
				}
			}
		}

		// Token: 0x06005C8D RID: 23693 RVA: 0x00346A04 File Offset: 0x00345A04
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
				AreaValue areaValue = (AreaValue)this.d[i];
				float a_ = areaValue.e();
				float num = areaValue.d();
				if (areaValue.DataLabel != null)
				{
					valuePositionDataLabel = areaValue.DataLabel;
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
							stringBuilder.Append(areaValue.Value.ToString(this.b.ValueFormat));
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
						valuePositionDataLabel.a(A_0, a_, num, stringBuilder.ToString());
					}
				}
			}
		}

		// Token: 0x06005C8E RID: 23694 RVA: 0x00346C30 File Offset: 0x00345C30
		internal void a(PlotArea A_0, PageWriter A_1)
		{
			for (int i = 0; i < this.d.Count; i++)
			{
				AreaValue areaValue = (AreaValue)this.d[i];
				float a_ = areaValue.e();
				float num = areaValue.d();
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

		// Token: 0x06005C8F RID: 23695 RVA: 0x00346D18 File Offset: 0x00345D18
		internal void b(PageWriter A_0)
		{
			PlotArea plotArea = this.b.PlotArea;
			if (this.d.Count < this.b.m().j())
			{
				AreaSeries a_ = ((AreaValue)this.a[0]).c();
				for (int i = this.d.Count; i <= this.b.m().j(); i++)
				{
					AreaValue areaValue = new AreaValue(0f);
					areaValue.a(a_);
					this.d.Add(areaValue);
				}
			}
			A_0.SetGraphicsMode();
			A_0.SetFillColor(this.b.Color);
			if (plotArea.ClipToPlotArea)
			{
				for (int i = 0; i < this.b.m().j() - 1; i++)
				{
					AreaValue areaValue = (AreaValue)this.d[i];
					AreaValue a_2 = (AreaValue)this.d[i + 1];
					areaValue.a(A_0, i, this.b.m().j(), a_2);
				}
			}
			else
			{
				for (int i = 0; i < this.d.Count; i++)
				{
					AreaValue areaValue = (AreaValue)this.d[i];
					areaValue.a(A_0, i, this.d.Count);
				}
			}
			this.a(plotArea, A_0);
		}

		// Token: 0x0400300B RID: 12299
		private ArrayList a;

		// Token: 0x0400300C RID: 12300
		private AreaSeries b;

		// Token: 0x0400300D RID: 12301
		private float[] c;

		// Token: 0x0400300E RID: 12302
		private ArrayList d;
	}
}
