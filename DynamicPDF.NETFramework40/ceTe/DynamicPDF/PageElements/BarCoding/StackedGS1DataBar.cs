using System;
using System.Collections;
using System.Collections.Generic;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x0200077D RID: 1917
	public class StackedGS1DataBar : TaggablePageElement, ICoordinate
	{
		// Token: 0x06004DA7 RID: 19879 RVA: 0x00272574 File Offset: 0x00271574
		public StackedGS1DataBar(string value, float x, float y, float rowHeight, StackedGS1DataBarType gs1type) : this(value, x, y, rowHeight, 1.5f, true, Font.Helvetica, 12f, gs1type)
		{
		}

		// Token: 0x06004DA8 RID: 19880 RVA: 0x002725A4 File Offset: 0x002715A4
		public StackedGS1DataBar(string value, float x, float y, float rowHeight, StackedGS1DataBarType gs1type, bool showText) : this(value, x, y, rowHeight, 1.5f, showText, Font.Helvetica, 12f, gs1type)
		{
		}

		// Token: 0x06004DA9 RID: 19881 RVA: 0x002725D4 File Offset: 0x002715D4
		public StackedGS1DataBar(string value, float x, float y, float rowHeight, StackedGS1DataBarType gs1type, Font font, float fontSize) : this(value, x, y, rowHeight, 1.5f, true, font, fontSize, gs1type)
		{
		}

		// Token: 0x06004DAA RID: 19882 RVA: 0x002725FC File Offset: 0x002715FC
		public StackedGS1DataBar(string value, float x, float y, float rowHeight, StackedGS1DataBarType gs1type, float xDimension) : this(value, x, y, rowHeight, xDimension, true, Font.Helvetica, 12f, gs1type)
		{
		}

		// Token: 0x06004DAB RID: 19883 RVA: 0x00272628 File Offset: 0x00271628
		public StackedGS1DataBar(string value, float x, float y, float rowHeight, StackedGS1DataBarType gs1type, float xDimension, bool showText) : this(value, x, y, rowHeight, xDimension, showText, Font.Helvetica, 12f, gs1type)
		{
		}

		// Token: 0x06004DAC RID: 19884 RVA: 0x00272654 File Offset: 0x00271654
		public StackedGS1DataBar(string value, float x, float y, float rowHeight, StackedGS1DataBarType gs1type, float xDimension, Font font, float fontSize) : this(value, x, y, rowHeight, xDimension, true, font, fontSize, gs1type)
		{
		}

		// Token: 0x06004DAD RID: 19885 RVA: 0x00272678 File Offset: 0x00271678
		private StackedGS1DataBar(string A_0, float A_1, float A_2, float A_3, float A_4, bool A_5, Font A_6, float A_7, StackedGS1DataBarType A_8)
		{
			base.d(3);
			this.i = A_0;
			this.e = A_8;
			this.h = A_5;
			this.k = A_6;
			this.m = A_7;
			this.a = A_1;
			this.b = A_2;
			this.f = A_3;
			this.d = A_4;
		}

		// Token: 0x17000609 RID: 1545
		// (get) Token: 0x06004DAE RID: 19886 RVA: 0x00272734 File Offset: 0x00271734
		// (set) Token: 0x06004DAF RID: 19887 RVA: 0x0027274C File Offset: 0x0027174C
		public int PixelsPerXDimension
		{
			get
			{
				return this.o;
			}
			set
			{
				this.o = value;
			}
		}

		// Token: 0x1700060A RID: 1546
		// (get) Token: 0x06004DB0 RID: 19888 RVA: 0x00272758 File Offset: 0x00271758
		// (set) Token: 0x06004DB1 RID: 19889 RVA: 0x00272770 File Offset: 0x00271770
		public float X
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x1700060B RID: 1547
		// (get) Token: 0x06004DB2 RID: 19890 RVA: 0x0027277C File Offset: 0x0027177C
		// (set) Token: 0x06004DB3 RID: 19891 RVA: 0x00272794 File Offset: 0x00271794
		public float Y
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x1700060C RID: 1548
		// (get) Token: 0x06004DB4 RID: 19892 RVA: 0x002727A0 File Offset: 0x002717A0
		// (set) Token: 0x06004DB5 RID: 19893 RVA: 0x002727B8 File Offset: 0x002717B8
		public float Angle
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
			}
		}

		// Token: 0x1700060D RID: 1549
		// (get) Token: 0x06004DB6 RID: 19894 RVA: 0x002727C4 File Offset: 0x002717C4
		// (set) Token: 0x06004DB7 RID: 19895 RVA: 0x002727DC File Offset: 0x002717DC
		public float XDimension
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

		// Token: 0x1700060E RID: 1550
		// (get) Token: 0x06004DB8 RID: 19896 RVA: 0x002727E8 File Offset: 0x002717E8
		// (set) Token: 0x06004DB9 RID: 19897 RVA: 0x00272800 File Offset: 0x00271800
		public int ExpandedStackedSegmentCount
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

		// Token: 0x1700060F RID: 1551
		// (get) Token: 0x06004DBA RID: 19898 RVA: 0x0027280C File Offset: 0x0027180C
		public int RowCount
		{
			get
			{
				ag ag = new ag(this.i, (int)this.e, false, this.g, true);
				return ag.g();
			}
		}

		// Token: 0x17000610 RID: 1552
		// (get) Token: 0x06004DBB RID: 19899 RVA: 0x00272840 File Offset: 0x00271840
		// (set) Token: 0x06004DBC RID: 19900 RVA: 0x00272858 File Offset: 0x00271858
		public float RowHeight
		{
			get
			{
				return this.f;
			}
			set
			{
				this.f = value;
			}
		}

		// Token: 0x17000611 RID: 1553
		// (get) Token: 0x06004DBD RID: 19901 RVA: 0x00272864 File Offset: 0x00271864
		// (set) Token: 0x06004DBE RID: 19902 RVA: 0x0027287C File Offset: 0x0027187C
		public bool ShowText
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

		// Token: 0x17000612 RID: 1554
		// (get) Token: 0x06004DBF RID: 19903 RVA: 0x00272888 File Offset: 0x00271888
		// (set) Token: 0x06004DC0 RID: 19904 RVA: 0x002728A0 File Offset: 0x002718A0
		public Color TextColor
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

		// Token: 0x17000613 RID: 1555
		// (get) Token: 0x06004DC1 RID: 19905 RVA: 0x002728AC File Offset: 0x002718AC
		// (set) Token: 0x06004DC2 RID: 19906 RVA: 0x002728C4 File Offset: 0x002718C4
		public Color Color
		{
			get
			{
				return this.n;
			}
			set
			{
				this.n = value;
			}
		}

		// Token: 0x17000614 RID: 1556
		// (get) Token: 0x06004DC3 RID: 19907 RVA: 0x002728D0 File Offset: 0x002718D0
		// (set) Token: 0x06004DC4 RID: 19908 RVA: 0x002728E8 File Offset: 0x002718E8
		public Font Font
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

		// Token: 0x17000615 RID: 1557
		// (get) Token: 0x06004DC5 RID: 19909 RVA: 0x002728F4 File Offset: 0x002718F4
		// (set) Token: 0x06004DC6 RID: 19910 RVA: 0x0027290C File Offset: 0x0027190C
		public Align TextAlign
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

		// Token: 0x17000616 RID: 1558
		// (get) Token: 0x06004DC7 RID: 19911 RVA: 0x00272918 File Offset: 0x00271918
		// (set) Token: 0x06004DC8 RID: 19912 RVA: 0x00272930 File Offset: 0x00271930
		public float FontSize
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

		// Token: 0x06004DC9 RID: 19913 RVA: 0x0027293C File Offset: 0x0027193C
		public float GetSymbolWidth()
		{
			float result;
			try
			{
				ag ag = new ag(this.i, (int)this.e, false, this.g, true);
				result = ag.k() * this.XDimension;
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (ao ao)
			{
				throw new dt(ao.Message);
			}
			catch (an an)
			{
				throw new ds(an.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			return result;
		}

		// Token: 0x06004DCA RID: 19914 RVA: 0x002729E8 File Offset: 0x002719E8
		public float GetSymbolHeight()
		{
			float result;
			try
			{
				ag ag = new ag(this.i, (int)this.e, false, this.g, true);
				float a_ = (float)ag.j()[0].Length * this.XDimension;
				List<string> list = new List<string>();
				float num = 0f;
				float num2 = this.a(ag.h(), a_, out list, out num);
				result = (float)ag.g() * this.f + (float)((ag.g() - 1) * ag.i()) * this.XDimension + num2;
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (ao ao)
			{
				throw new dt(ao.Message);
			}
			catch (an an)
			{
				throw new ds(an.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			return result;
		}

		// Token: 0x06004DCB RID: 19915 RVA: 0x00272AEC File Offset: 0x00271AEC
		public override void Draw(PageWriter writer)
		{
			writer.SetGraphicsMode();
			if (writer.Document.Tag != null)
			{
				this.a(writer);
			}
			writer.SetFillColor(this.Color);
			ag ag;
			BitArray[] array;
			try
			{
				ag = new ag(this.i, (int)this.e, false, this.g, true);
				array = ag.j();
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (ao ao)
			{
				throw new dt(ao.Message);
			}
			catch (an an)
			{
				throw new ds(an.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			float num = (float)array[0].Length * this.XDimension;
			List<string> list = new List<string>();
			float num2 = 0f;
			this.a(ag.h(), num, out list, out num2);
			float num3 = this.Y;
			if (this.Angle != 0f)
			{
				writer.SetDimensionsSimpleRotate(this.X, this.Y, this.Angle);
			}
			for (int i = 0; i < array.Length; i++)
			{
				float a_ = num;
				if (i % 2 == 0)
				{
					int num4 = array[i].Length * this.PixelsPerXDimension;
					int num5 = 1;
					float num6 = (this.e == StackedGS1DataBarType.Stacked && i == 2) ? (this.RowHeight + 2f) : this.RowHeight;
					byte[] a_2 = BarCode.a(array[i], this.PixelsPerXDimension, 1, array[i].Length, num5);
					if (this.e == StackedGS1DataBarType.ExpandedStacked)
					{
						a_ = (float)array[i].Length * this.XDimension;
					}
					writer.a(this.X, num3 += num6, a_, num6, num4, num5, a_2);
				}
				else
				{
					float num6 = (float)ag.i() * this.XDimension;
					int num4 = array[i].Length / ag.i();
					int num5 = ag.i();
					byte[] a_2 = BarCode.a(array[i], this.PixelsPerXDimension, this.PixelsPerXDimension, array[i].Length / ag.i(), num5);
					writer.a(this.X, num3 += num6, a_, num6, num4 * this.PixelsPerXDimension, num5 * this.PixelsPerXDimension, a_2);
				}
			}
			if (this.ShowText)
			{
				writer.SetTextMode();
				writer.SetTextDefaults();
				writer.SetFont(this.Font, this.FontSize);
				writer.SetFillColor(this.TextColor);
				num3 += this.Font.GetBaseLine(this.FontSize, this.Font.GetDefaultLeading(this.FontSize));
				foreach (string text in list)
				{
					switch (this.TextAlign)
					{
					case Align.Left:
						writer.Write_Tm(this.X, num3);
						break;
					case Align.Center:
						writer.Write_Tm(this.X + (num - this.Font.GetTextWidth(text, this.FontSize)) / 2f, num3);
						break;
					default:
						writer.Write_Tm(this.X + num - this.Font.GetTextWidth(text, this.FontSize), num3);
						break;
					}
					writer.Write_Tj_(text.ToCharArray(), false);
					num3 += num2;
				}
			}
			if (writer.Document.Tag != null)
			{
				writer.SetGraphicsMode();
				Tag.a(writer);
			}
			if (this.Angle != 0f)
			{
				writer.ResetDimensions();
			}
		}

		// Token: 0x06004DCC RID: 19916 RVA: 0x00272F0C File Offset: 0x00271F0C
		internal float a(string A_0, float A_1, out List<string> A_2, out float A_3)
		{
			A_2 = null;
			float result;
			if (this.ShowText)
			{
				A_2 = BarCode.b(A_0);
				List<string> list = new List<string>();
				float num = 0f;
				A_3 = BarCode.a(this.FontSize, this.Font);
				this.a(A_2, ref list, A_0, A_3, A_1, ref num);
				if (num == 0f)
				{
					num = A_3;
				}
				A_2 = list;
				result = num;
			}
			else
			{
				A_3 = 0f;
				result = 0f;
			}
			return result;
		}

		// Token: 0x06004DCD RID: 19917 RVA: 0x00272F90 File Offset: 0x00271F90
		private void a(List<string> A_0, ref List<string> A_1, string A_2, float A_3, float A_4, ref float A_5)
		{
			int index = A_0.Count - 1;
			List<string> list = new List<string>();
			float textWidth;
			do
			{
				textWidth = this.Font.GetTextWidth(A_2, this.FontSize);
				if (textWidth > A_4)
				{
					list.Insert(0, A_0[index]);
					A_2 = A_2.Replace(A_0[index--], "");
				}
			}
			while (textWidth > A_4);
			if (A_2.Length == 0)
			{
				A_2 = A_0[0];
				list.RemoveAt(0);
			}
			A_1.Add(A_2);
			A_5 += A_3;
			if (list.Count > 0)
			{
				A_2 = "";
				for (int i = 0; i < list.Count; i++)
				{
					A_2 += list[i];
				}
				this.a(list, ref A_1, A_2, A_3, A_4, ref A_5);
			}
		}

		// Token: 0x06004DCE RID: 19918 RVA: 0x0027308C File Offset: 0x0027208C
		internal void a(PageWriter A_0)
		{
			if (this.Tag == null)
			{
				this.Tag = new StructureElement(TagType.Figure, true);
				((StructureElement)this.Tag).Order = this.TagOrder;
			}
			this.Tag.e(A_0, this);
		}

		// Token: 0x06004DCF RID: 19919 RVA: 0x002730E4 File Offset: 0x002720E4
		internal override byte cb()
		{
			return 34;
		}

		// Token: 0x04002A1D RID: 10781
		private new float a = 0f;

		// Token: 0x04002A1E RID: 10782
		private float b = 0f;

		// Token: 0x04002A1F RID: 10783
		private float c;

		// Token: 0x04002A20 RID: 10784
		private new float d;

		// Token: 0x04002A21 RID: 10785
		private StackedGS1DataBarType e;

		// Token: 0x04002A22 RID: 10786
		private float f;

		// Token: 0x04002A23 RID: 10787
		private int g = 4;

		// Token: 0x04002A24 RID: 10788
		private bool h;

		// Token: 0x04002A25 RID: 10789
		private string i;

		// Token: 0x04002A26 RID: 10790
		private Color j = Grayscale.Black;

		// Token: 0x04002A27 RID: 10791
		private Font k = Font.Helvetica;

		// Token: 0x04002A28 RID: 10792
		private Align l = Align.Center;

		// Token: 0x04002A29 RID: 10793
		private float m = 12f;

		// Token: 0x04002A2A RID: 10794
		private Color n = Grayscale.Black;

		// Token: 0x04002A2B RID: 10795
		private new int o = 3;
	}
}
