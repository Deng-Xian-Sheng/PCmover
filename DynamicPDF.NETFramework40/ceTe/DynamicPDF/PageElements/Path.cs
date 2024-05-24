using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x0200073C RID: 1852
	public class Path : TaggablePageElement, ICoordinate
	{
		// Token: 0x06004AB2 RID: 19122 RVA: 0x00260560 File Offset: 0x0025F560
		public Path(float x, float y) : this(x, y, Path.n, Path.o, 1f, Path.p, false)
		{
		}

		// Token: 0x06004AB3 RID: 19123 RVA: 0x00260582 File Offset: 0x0025F582
		public Path(float x, float y, Color lineColor) : this(x, y, lineColor, Path.o, 1f, Path.p, false)
		{
		}

		// Token: 0x06004AB4 RID: 19124 RVA: 0x002605A0 File Offset: 0x0025F5A0
		public Path(float x, float y, Color lineColor, Color fillColor) : this(x, y, lineColor, fillColor, 1f, Path.p, false)
		{
		}

		// Token: 0x06004AB5 RID: 19125 RVA: 0x002605BB File Offset: 0x0025F5BB
		public Path(float x, float y, Color lineColor, float lineWidth, LineStyle lineStyle) : this(x, y, lineColor, Path.o, lineWidth, lineStyle, false)
		{
		}

		// Token: 0x06004AB6 RID: 19126 RVA: 0x002605D3 File Offset: 0x0025F5D3
		public Path(float x, float y, Color lineColor, float lineWidth, LineStyle lineStyle, bool closePath) : this(x, y, lineColor, Path.o, lineWidth, lineStyle, closePath)
		{
		}

		// Token: 0x06004AB7 RID: 19127 RVA: 0x002605EC File Offset: 0x0025F5EC
		public Path(float x, float y, Color lineColor, Color fillColor, float lineWidth, LineStyle lineStyle, bool closePath)
		{
			this.d = x;
			this.e = y;
			if (lineWidth <= 0f)
			{
				lineWidth = 0f;
			}
			this.f = lineWidth;
			this.i = lineStyle;
			this.h = lineColor;
			this.g = fillColor;
			this.m = closePath;
		}

		// Token: 0x17000565 RID: 1381
		// (get) Token: 0x06004AB8 RID: 19128 RVA: 0x002606B4 File Offset: 0x0025F6B4
		// (set) Token: 0x06004AB9 RID: 19129 RVA: 0x002606CC File Offset: 0x0025F6CC
		public LineStyle LineStyle
		{
			get
			{
				return this.i;
			}
			set
			{
				this.i = value;
			}
		}

		// Token: 0x17000566 RID: 1382
		// (get) Token: 0x06004ABA RID: 19130 RVA: 0x002606D8 File Offset: 0x0025F6D8
		// (set) Token: 0x06004ABB RID: 19131 RVA: 0x002606F0 File Offset: 0x0025F6F0
		public LineCap LineCap
		{
			get
			{
				return this.j;
			}
			set
			{
				this.j = value;
			}
		}

		// Token: 0x17000567 RID: 1383
		// (get) Token: 0x06004ABC RID: 19132 RVA: 0x002606FC File Offset: 0x0025F6FC
		// (set) Token: 0x06004ABD RID: 19133 RVA: 0x00260714 File Offset: 0x0025F714
		public LineJoin LineJoin
		{
			get
			{
				return this.k;
			}
			set
			{
				this.k = value;
			}
		}

		// Token: 0x17000568 RID: 1384
		// (get) Token: 0x06004ABE RID: 19134 RVA: 0x00260720 File Offset: 0x0025F720
		// (set) Token: 0x06004ABF RID: 19135 RVA: 0x00260738 File Offset: 0x0025F738
		public float MiterLimit
		{
			get
			{
				return this.l;
			}
			set
			{
				this.l = value;
			}
		}

		// Token: 0x17000569 RID: 1385
		// (get) Token: 0x06004AC0 RID: 19136 RVA: 0x00260744 File Offset: 0x0025F744
		public SubPathList SubPaths
		{
			get
			{
				return this.c;
			}
		}

		// Token: 0x1700056A RID: 1386
		// (get) Token: 0x06004AC1 RID: 19137 RVA: 0x0026075C File Offset: 0x0025F75C
		// (set) Token: 0x06004AC2 RID: 19138 RVA: 0x00260774 File Offset: 0x0025F774
		public float LineWidth
		{
			get
			{
				return this.f;
			}
			set
			{
				if (value <= 0f)
				{
					this.f = 0f;
				}
				else
				{
					this.f = value;
				}
			}
		}

		// Token: 0x1700056B RID: 1387
		// (get) Token: 0x06004AC3 RID: 19139 RVA: 0x002607A4 File Offset: 0x0025F7A4
		// (set) Token: 0x06004AC4 RID: 19140 RVA: 0x002607BC File Offset: 0x0025F7BC
		public Color LineColor
		{
			get
			{
				return this.h;
			}
			set
			{
				this.h = value;
			}
		}

		// Token: 0x1700056C RID: 1388
		// (get) Token: 0x06004AC5 RID: 19141 RVA: 0x002607C8 File Offset: 0x0025F7C8
		// (set) Token: 0x06004AC6 RID: 19142 RVA: 0x002607E0 File Offset: 0x0025F7E0
		public Color FillColor
		{
			get
			{
				return this.g;
			}
			set
			{
				this.g = value;
			}
		}

		// Token: 0x1700056D RID: 1389
		// (get) Token: 0x06004AC7 RID: 19143 RVA: 0x002607EC File Offset: 0x0025F7EC
		// (set) Token: 0x06004AC8 RID: 19144 RVA: 0x00260804 File Offset: 0x0025F804
		public float X
		{
			get
			{
				return this.d;
			}
			set
			{
				this.d = value;
			}
		}

		// Token: 0x1700056E RID: 1390
		// (get) Token: 0x06004AC9 RID: 19145 RVA: 0x00260810 File Offset: 0x0025F810
		// (set) Token: 0x06004ACA RID: 19146 RVA: 0x00260828 File Offset: 0x0025F828
		public float Y
		{
			get
			{
				return this.e;
			}
			set
			{
				this.e = value;
			}
		}

		// Token: 0x1700056F RID: 1391
		// (get) Token: 0x06004ACB RID: 19147 RVA: 0x00260834 File Offset: 0x0025F834
		// (set) Token: 0x06004ACC RID: 19148 RVA: 0x0026084C File Offset: 0x0025F84C
		public bool ClosePath
		{
			get
			{
				return this.m;
			}
			set
			{
				this.m = value;
			}
		}

		// Token: 0x06004ACD RID: 19149 RVA: 0x00260858 File Offset: 0x0025F858
		public override void Draw(PageWriter writer)
		{
			base.Draw(writer);
			writer.SetGraphicsMode();
			if (writer.Document.Tag != null)
			{
				if (this.Tag == null)
				{
					this.Tag = new StructureElement(TagType.Figure, true);
					((StructureElement)this.Tag).Order = this.TagOrder;
				}
				this.Tag.e(writer, this);
			}
			bool flag = true;
			bool flag3;
			bool flag2;
			if (this.f > 0f && this.g != null)
			{
				writer.SetLineWidth(this.f);
				writer.SetStrokeColor(this.h);
				writer.SetLineStyle(this.i);
				writer.SetFillColor(this.g);
				flag2 = (flag3 = true);
			}
			else if (this.f > 0f)
			{
				writer.SetLineWidth(this.f);
				writer.SetStrokeColor(this.h);
				writer.SetLineStyle(this.i);
				flag2 = true;
				flag3 = false;
			}
			else if (this.g != null)
			{
				writer.SetFillColor(this.g);
				flag3 = true;
				flag2 = false;
			}
			else
			{
				flag2 = false;
				flag3 = false;
				flag = false;
			}
			if (this.i == LineStyle.None)
			{
				flag2 = false;
			}
			if (flag)
			{
				writer.SetLineCap(this.j);
				writer.SetLineJoin(this.k);
				writer.SetMiterLimit(this.l);
				writer.Write_m_(this.d, this.e);
				this.c.a(writer);
				if (this.m)
				{
					if (flag3)
					{
						if (flag2)
						{
							writer.Write_b_();
						}
						else
						{
							writer.Write_f();
						}
					}
					else
					{
						writer.Write_s_();
					}
				}
				else if (flag3)
				{
					if (flag2)
					{
						writer.Write_B();
					}
					else
					{
						writer.Write_f();
					}
				}
				else
				{
					writer.Write_S();
				}
			}
			if (writer.Document.Tag != null)
			{
				Tag.a(writer);
			}
		}

		// Token: 0x06004ACE RID: 19150 RVA: 0x00260A89 File Offset: 0x0025FA89
		internal override x5 b7()
		{
			throw new GeneratorException("Path does not support the Top property.");
		}

		// Token: 0x06004ACF RID: 19151 RVA: 0x00260A96 File Offset: 0x0025FA96
		internal override x5 b8()
		{
			throw new GeneratorException("Path does not support the Bottom property.");
		}

		// Token: 0x06004AD0 RID: 19152 RVA: 0x00260AA4 File Offset: 0x0025FAA4
		internal override byte cb()
		{
			return 50;
		}

		// Token: 0x06004AD1 RID: 19153 RVA: 0x00260AB8 File Offset: 0x0025FAB8
		internal float[] a(PageWriter A_0, float A_1, float A_2)
		{
			float num = A_1;
			float num2 = 0f;
			float num3 = A_2;
			float num4 = 0f;
			foreach (object obj in this.SubPaths)
			{
				SubPath subPath = (SubPath)obj;
				if (subPath is CurveSubPath)
				{
					if (((CurveSubPath)subPath).X < num)
					{
						num = ((CurveSubPath)subPath).X;
					}
					if (((CurveSubPath)subPath).X > num2)
					{
						num2 = ((CurveSubPath)subPath).X;
					}
					if (((CurveSubPath)subPath).DestinationControlPointX < num)
					{
						num = ((CurveSubPath)subPath).DestinationControlPointX;
					}
					if (((CurveSubPath)subPath).DestinationControlPointX > num2)
					{
						num2 = ((CurveSubPath)subPath).DestinationControlPointX;
					}
					if (((CurveSubPath)subPath).SourceControlPointX < num)
					{
						num = ((CurveSubPath)subPath).SourceControlPointX;
					}
					if (((CurveSubPath)subPath).SourceControlPointX > num2)
					{
						num2 = ((CurveSubPath)subPath).SourceControlPointX;
					}
					if (((CurveSubPath)subPath).Y < num3)
					{
						num3 = ((CurveSubPath)subPath).Y;
					}
					if (((CurveSubPath)subPath).Y > num4)
					{
						num4 = ((CurveSubPath)subPath).Y;
					}
					if (((CurveSubPath)subPath).DestinationControlPointY < num3)
					{
						num3 = ((CurveSubPath)subPath).DestinationControlPointY;
					}
					if (((CurveSubPath)subPath).DestinationControlPointY > num4)
					{
						num4 = ((CurveSubPath)subPath).DestinationControlPointY;
					}
					if (((CurveSubPath)subPath).SourceControlPointY < num3)
					{
						num3 = ((CurveSubPath)subPath).SourceControlPointY;
					}
					if (((CurveSubPath)subPath).SourceControlPointY > num4)
					{
						num4 = ((CurveSubPath)subPath).SourceControlPointY;
					}
				}
				if (subPath is LineSubPath)
				{
					if (((LineSubPath)subPath).X < num)
					{
						num = ((LineSubPath)subPath).X;
					}
					if (((LineSubPath)subPath).X > num2)
					{
						num2 = ((LineSubPath)subPath).X;
					}
					if (((LineSubPath)subPath).Y < num3)
					{
						num3 = ((LineSubPath)subPath).Y;
					}
					if (((LineSubPath)subPath).Y > num4)
					{
						num4 = ((LineSubPath)subPath).Y;
					}
				}
				if (subPath is CurveFromSubPath)
				{
					if (((CurveFromSubPath)subPath).X < num)
					{
						num = ((CurveFromSubPath)subPath).X;
					}
					if (((CurveFromSubPath)subPath).X > num2)
					{
						num2 = ((CurveFromSubPath)subPath).X;
					}
					if (((CurveFromSubPath)subPath).SourceControlPointX < num)
					{
						num = ((CurveFromSubPath)subPath).SourceControlPointX;
					}
					if (((CurveFromSubPath)subPath).SourceControlPointX > num2)
					{
						num2 = ((CurveFromSubPath)subPath).SourceControlPointX;
					}
					if (((CurveFromSubPath)subPath).Y < num3)
					{
						num3 = ((CurveFromSubPath)subPath).Y;
					}
					if (((CurveFromSubPath)subPath).Y > num4)
					{
						num4 = ((CurveFromSubPath)subPath).Y;
					}
					if (((CurveFromSubPath)subPath).SourceControlPointY < num3)
					{
						num3 = ((CurveFromSubPath)subPath).SourceControlPointY;
					}
					if (((CurveFromSubPath)subPath).SourceControlPointY > num4)
					{
						num4 = ((CurveFromSubPath)subPath).SourceControlPointY;
					}
				}
				if (subPath is CurveToSubPath)
				{
					if (((CurveToSubPath)subPath).X < num)
					{
						num = ((CurveToSubPath)subPath).X;
					}
					if (((CurveToSubPath)subPath).X > num2)
					{
						num2 = ((CurveToSubPath)subPath).X;
					}
					if (((CurveToSubPath)subPath).DestinationControlPointX < num)
					{
						num = ((CurveToSubPath)subPath).DestinationControlPointX;
					}
					if (((CurveToSubPath)subPath).DestinationControlPointX > num2)
					{
						num2 = ((CurveToSubPath)subPath).DestinationControlPointX;
					}
					if (((CurveToSubPath)subPath).Y < num3)
					{
						num3 = ((CurveToSubPath)subPath).Y;
					}
					if (((CurveToSubPath)subPath).Y > num4)
					{
						num4 = ((CurveToSubPath)subPath).Y;
					}
					if (((CurveToSubPath)subPath).DestinationControlPointY < num3)
					{
						num3 = ((CurveToSubPath)subPath).DestinationControlPointY;
					}
					if (((CurveToSubPath)subPath).DestinationControlPointY > num4)
					{
						num4 = ((CurveToSubPath)subPath).DestinationControlPointY;
					}
				}
			}
			num += A_0.Page.Dimensions.LeftMargin;
			if (num < 0f)
			{
				num = 0f;
			}
			num2 += A_0.Page.Dimensions.LeftMargin;
			if (num3 < 0f)
			{
				num3 = 0f;
			}
			num3 = A_0.Page.Dimensions.Height - A_0.Page.Dimensions.TopMargin - num3;
			num4 = A_0.Page.Dimensions.Height - A_0.Page.Dimensions.TopMargin - num4;
			return new float[]
			{
				num,
				num4,
				num2,
				num3
			};
		}

		// Token: 0x04002887 RID: 10375
		private new const float a = 1f;

		// Token: 0x04002888 RID: 10376
		private const bool b = false;

		// Token: 0x04002889 RID: 10377
		private SubPathList c = new SubPathList();

		// Token: 0x0400288A RID: 10378
		private new float d = 0f;

		// Token: 0x0400288B RID: 10379
		private float e = 0f;

		// Token: 0x0400288C RID: 10380
		private float f = 1f;

		// Token: 0x0400288D RID: 10381
		private Color g = Path.o;

		// Token: 0x0400288E RID: 10382
		private Color h = Path.n;

		// Token: 0x0400288F RID: 10383
		private LineStyle i = LineStyle.Solid;

		// Token: 0x04002890 RID: 10384
		private LineCap j = LineCap.Butt;

		// Token: 0x04002891 RID: 10385
		private LineJoin k = LineJoin.Miter;

		// Token: 0x04002892 RID: 10386
		private float l = 10f;

		// Token: 0x04002893 RID: 10387
		private bool m;

		// Token: 0x04002894 RID: 10388
		private static Color n = Grayscale.Black;

		// Token: 0x04002895 RID: 10389
		private new static Color o = null;

		// Token: 0x04002896 RID: 10390
		private static LineStyle p = LineStyle.Solid;
	}
}
