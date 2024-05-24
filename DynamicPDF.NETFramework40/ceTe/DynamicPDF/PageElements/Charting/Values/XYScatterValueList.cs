using System;
using System.Collections;
using System.Text;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x02000913 RID: 2323
	public class XYScatterValueList
	{
		// Token: 0x06005ECD RID: 24269 RVA: 0x0035A98F File Offset: 0x0035998F
		internal XYScatterValueList(XYScatterSeries A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06005ECE RID: 24270 RVA: 0x0035A9A4 File Offset: 0x003599A4
		public XYScatterValue Add(float val, float position)
		{
			XYScatterValue xyscatterValue = new XYScatterValue(val, position);
			xyscatterValue.a(this.b);
			if (this.a != null)
			{
				if (this.a.Contains(xyscatterValue))
				{
					throw new GeneratorException("Same XYScatterValue object can't be added more than once.");
				}
				this.a.Add(xyscatterValue);
			}
			else
			{
				this.a = new ArrayList();
				this.a.Add(xyscatterValue);
			}
			this.b(position);
			this.a(val);
			return xyscatterValue;
		}

		// Token: 0x06005ECF RID: 24271 RVA: 0x0035AA34 File Offset: 0x00359A34
		public void Add(XYScatterValue val)
		{
			val.a(this.b);
			if (this.a != null)
			{
				if (this.a.Contains(val))
				{
					throw new GeneratorException("Same XYScatterValue object can't be added more than once.");
				}
				this.a.Add(val);
			}
			else
			{
				this.a = new ArrayList();
				this.a.Add(val);
			}
			this.b(val.ScatterXValue);
			this.a(val.ScatterYValue);
		}

		// Token: 0x06005ED0 RID: 24272 RVA: 0x0035AAC0 File Offset: 0x00359AC0
		internal void a(float A_0)
		{
			this.b.a(A_0);
			this.b.b(A_0);
		}

		// Token: 0x06005ED1 RID: 24273 RVA: 0x0035AADD File Offset: 0x00359ADD
		internal void b(float A_0)
		{
			this.b.iy(A_0);
			this.b.i0(A_0);
		}

		// Token: 0x170009EC RID: 2540
		// (get) Token: 0x06005ED2 RID: 24274 RVA: 0x0035AAFC File Offset: 0x00359AFC
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

		// Token: 0x170009ED RID: 2541
		public XYScatterValue this[int index]
		{
			get
			{
				XYScatterValue result;
				if (this.a != null && index < this.a.Count)
				{
					result = (XYScatterValue)this.a[index];
				}
				else
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x06005ED4 RID: 24276 RVA: 0x0035AB74 File Offset: 0x00359B74
		internal void a(PageWriter A_0)
		{
			XYScatterDataLabel xyscatterDataLabel = null;
			if (this.b.DataLabel != null)
			{
				xyscatterDataLabel = this.b.DataLabel;
			}
			PlotArea plotArea = this.b.PlotArea;
			for (int i = 0; i < this.a.Count; i++)
			{
				XYScatterValue xyscatterValue = (XYScatterValue)this.a[i];
				float a_ = xyscatterValue.b();
				float num = xyscatterValue.a();
				if (xyscatterValue.DataLabel != null)
				{
					xyscatterDataLabel = xyscatterValue.DataLabel;
				}
				if (xyscatterDataLabel != null)
				{
					if (!plotArea.ClipToPlotArea || (plotArea.ClipToPlotArea && num + 0.001f >= plotArea.Y && num + 0.001f <= plotArea.Y + plotArea.Height))
					{
						xyscatterDataLabel.a(plotArea.Chart);
						StringBuilder stringBuilder = new StringBuilder();
						stringBuilder.Append(xyscatterDataLabel.Prefix);
						if (xyscatterDataLabel.ShowYValue)
						{
							stringBuilder.Append(xyscatterValue.ScatterYValue.ToString(this.b.YValueFormat));
						}
						if (xyscatterDataLabel.ShowXValue)
						{
							if (stringBuilder.Length > 0)
							{
								stringBuilder.Append(xyscatterDataLabel.Separator + xyscatterValue.ScatterXValue.ToString());
							}
							else
							{
								stringBuilder.Append(xyscatterValue.ScatterXValue);
							}
						}
						if (xyscatterDataLabel.Series)
						{
							if (stringBuilder.Length > 0)
							{
								stringBuilder.Append(xyscatterDataLabel.Separator + this.b.Name);
							}
							else
							{
								stringBuilder.Append(this.b.Name);
							}
						}
						stringBuilder.Append(xyscatterDataLabel.Suffix);
						xyscatterDataLabel.a(A_0, a_, num, stringBuilder.ToString());
					}
				}
			}
		}

		// Token: 0x06005ED5 RID: 24277 RVA: 0x0035AD88 File Offset: 0x00359D88
		internal void a(PlotArea A_0, PageWriter A_1)
		{
			if (this.b.Marker != null)
			{
				for (int i = 0; i < this.a.Count; i++)
				{
					XYScatterValue xyscatterValue = (XYScatterValue)this.a[i];
					if (this.b.Marker.Color == null)
					{
						this.b.Marker.Color = this.b.Color;
					}
					float a_ = xyscatterValue.b();
					float num = xyscatterValue.a();
					if (!A_0.ClipToPlotArea || (A_0.ClipToPlotArea && num + 0.001f >= A_0.Y && num + 0.001f <= A_0.Y + A_0.Height))
					{
						this.b.Marker.a(A_1, a_, num);
					}
				}
			}
		}

		// Token: 0x06005ED6 RID: 24278 RVA: 0x0035AE84 File Offset: 0x00359E84
		internal void a(PageWriter A_0, bool A_1)
		{
			PlotArea plotArea = this.b.PlotArea;
			if (this.a != null && this.a.Count > 0)
			{
				A_0.SetGraphicsMode();
				A_0.SetLineWidth(this.b.Width);
				A_0.SetStrokeColor(this.b.Color);
				A_0.SetLineStyle(this.b.LineStyle);
				A_0.SetLineCap(this.b.LineCap);
				A_0.SetLineJoin(this.b.LineJoin);
				if (plotArea.ClipToPlotArea)
				{
					for (int i = 0; i < this.a.Count - 1; i++)
					{
						XYScatterValue xyscatterValue = (XYScatterValue)this.a[i];
						XYScatterValue a_ = (XYScatterValue)this.a[i + 1];
						xyscatterValue.a(A_0, i, A_1, a_);
					}
				}
				else
				{
					for (int i = 0; i <= this.a.Count - 1; i++)
					{
						XYScatterValue xyscatterValue = (XYScatterValue)this.a[i];
						xyscatterValue.a(A_0, i, A_1);
					}
				}
				if (A_1 && this.b.LineStyle != LineStyle.None)
				{
					A_0.Write_S();
				}
				A_0.SetLineStyle(LineStyle.Solid);
				this.a(plotArea, A_0);
			}
		}

		// Token: 0x040030BB RID: 12475
		private ArrayList a;

		// Token: 0x040030BC RID: 12476
		private XYScatterSeries b;
	}
}
