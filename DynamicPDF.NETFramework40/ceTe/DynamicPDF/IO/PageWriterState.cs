using System;

namespace ceTe.DynamicPDF.IO
{
	// Token: 0x020006E0 RID: 1760
	public class PageWriterState
	{
		// Token: 0x17000398 RID: 920
		// (get) Token: 0x06004409 RID: 17417 RVA: 0x00232AF8 File Offset: 0x00231AF8
		// (set) Token: 0x0600440A RID: 17418 RVA: 0x00232B10 File Offset: 0x00231B10
		public float CharacterSpacing
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

		// Token: 0x17000399 RID: 921
		// (get) Token: 0x0600440B RID: 17419 RVA: 0x00232B1C File Offset: 0x00231B1C
		// (set) Token: 0x0600440C RID: 17420 RVA: 0x00232B34 File Offset: 0x00231B34
		public float WordSpacing
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

		// Token: 0x1700039A RID: 922
		// (get) Token: 0x0600440D RID: 17421 RVA: 0x00232B40 File Offset: 0x00231B40
		// (set) Token: 0x0600440E RID: 17422 RVA: 0x00232B58 File Offset: 0x00231B58
		public float HorizontalScaling
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

		// Token: 0x1700039B RID: 923
		// (get) Token: 0x0600440F RID: 17423 RVA: 0x00232B64 File Offset: 0x00231B64
		// (set) Token: 0x06004410 RID: 17424 RVA: 0x00232B7C File Offset: 0x00231B7C
		public float Leading
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

		// Token: 0x1700039C RID: 924
		// (get) Token: 0x06004411 RID: 17425 RVA: 0x00232B88 File Offset: 0x00231B88
		// (set) Token: 0x06004412 RID: 17426 RVA: 0x00232BA0 File Offset: 0x00231BA0
		public Font Font
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

		// Token: 0x1700039D RID: 925
		// (get) Token: 0x06004413 RID: 17427 RVA: 0x00232BAC File Offset: 0x00231BAC
		// (set) Token: 0x06004414 RID: 17428 RVA: 0x00232BC4 File Offset: 0x00231BC4
		public float FontSize
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

		// Token: 0x1700039E RID: 926
		// (get) Token: 0x06004415 RID: 17429 RVA: 0x00232BD0 File Offset: 0x00231BD0
		// (set) Token: 0x06004416 RID: 17430 RVA: 0x00232BE8 File Offset: 0x00231BE8
		public TextRenderingMode TextRenderingMode
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

		// Token: 0x1700039F RID: 927
		// (get) Token: 0x06004417 RID: 17431 RVA: 0x00232BF4 File Offset: 0x00231BF4
		// (set) Token: 0x06004418 RID: 17432 RVA: 0x00232C0C File Offset: 0x00231C0C
		public float TextRise
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

		// Token: 0x170003A0 RID: 928
		// (get) Token: 0x06004419 RID: 17433 RVA: 0x00232C18 File Offset: 0x00231C18
		// (set) Token: 0x0600441A RID: 17434 RVA: 0x00232C30 File Offset: 0x00231C30
		public float LineWidth
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

		// Token: 0x170003A1 RID: 929
		// (get) Token: 0x0600441B RID: 17435 RVA: 0x00232C3C File Offset: 0x00231C3C
		// (set) Token: 0x0600441C RID: 17436 RVA: 0x00232C54 File Offset: 0x00231C54
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

		// Token: 0x170003A2 RID: 930
		// (get) Token: 0x0600441D RID: 17437 RVA: 0x00232C60 File Offset: 0x00231C60
		// (set) Token: 0x0600441E RID: 17438 RVA: 0x00232C78 File Offset: 0x00231C78
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

		// Token: 0x170003A3 RID: 931
		// (get) Token: 0x0600441F RID: 17439 RVA: 0x00232C84 File Offset: 0x00231C84
		// (set) Token: 0x06004420 RID: 17440 RVA: 0x00232C9C File Offset: 0x00231C9C
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

		// Token: 0x170003A4 RID: 932
		// (get) Token: 0x06004421 RID: 17441 RVA: 0x00232CA8 File Offset: 0x00231CA8
		// (set) Token: 0x06004422 RID: 17442 RVA: 0x00232CC0 File Offset: 0x00231CC0
		public LineStyle LineStyle
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

		// Token: 0x170003A5 RID: 933
		// (get) Token: 0x06004423 RID: 17443 RVA: 0x00232CCC File Offset: 0x00231CCC
		// (set) Token: 0x06004424 RID: 17444 RVA: 0x00232CE4 File Offset: 0x00231CE4
		public Color StrokeColor
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

		// Token: 0x170003A6 RID: 934
		// (get) Token: 0x06004425 RID: 17445 RVA: 0x00232CF0 File Offset: 0x00231CF0
		// (set) Token: 0x06004426 RID: 17446 RVA: 0x00232D08 File Offset: 0x00231D08
		public Color FillColor
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

		// Token: 0x170003A7 RID: 935
		// (get) Token: 0x06004427 RID: 17447 RVA: 0x00232D14 File Offset: 0x00231D14
		// (set) Token: 0x06004428 RID: 17448 RVA: 0x00232D2C File Offset: 0x00231D2C
		public ColorSpace StrokeColorSpace
		{
			get
			{
				return this.p;
			}
			set
			{
				this.p = value;
			}
		}

		// Token: 0x170003A8 RID: 936
		// (get) Token: 0x06004429 RID: 17449 RVA: 0x00232D38 File Offset: 0x00231D38
		// (set) Token: 0x0600442A RID: 17450 RVA: 0x00232D50 File Offset: 0x00231D50
		public ColorSpace FillColorSpace
		{
			get
			{
				return this.q;
			}
			set
			{
				this.q = value;
			}
		}

		// Token: 0x0600442B RID: 17451 RVA: 0x00232D5C File Offset: 0x00231D5C
		public PageWriterState(PageWriterState state)
		{
			this.a = state.CharacterSpacing;
			this.b = state.WordSpacing;
			this.c = state.HorizontalScaling;
			this.d = state.Leading;
			this.e = state.Font;
			this.f = state.FontSize;
			this.g = state.TextRenderingMode;
			this.h = state.TextRise;
			this.i = state.LineWidth;
			this.j = state.LineCap;
			this.k = state.LineJoin;
			this.l = state.MiterLimit;
			this.m = state.LineStyle;
			this.n = state.StrokeColor;
			this.o = state.FillColor;
			this.p = state.StrokeColorSpace;
			this.q = state.FillColorSpace;
		}

		// Token: 0x0600442C RID: 17452 RVA: 0x00232E40 File Offset: 0x00231E40
		public PageWriterState()
		{
			this.a = 0f;
			this.b = 0f;
			this.c = 100f;
			this.d = 0f;
			this.e = null;
			this.f = -1f;
			this.g = TextRenderingMode.Fill;
			this.h = 0f;
			this.i = 1f;
			this.j = LineCap.Butt;
			this.k = LineJoin.Miter;
			this.l = 10f;
			this.m = LineStyle.Solid;
			this.n = Grayscale.Black;
			this.o = Grayscale.Black;
			this.p = ColorSpace.DeviceGray;
			this.q = ColorSpace.DeviceGray;
		}

		// Token: 0x040025E8 RID: 9704
		private float a;

		// Token: 0x040025E9 RID: 9705
		private float b;

		// Token: 0x040025EA RID: 9706
		private float c;

		// Token: 0x040025EB RID: 9707
		private float d;

		// Token: 0x040025EC RID: 9708
		private Font e;

		// Token: 0x040025ED RID: 9709
		private float f;

		// Token: 0x040025EE RID: 9710
		private TextRenderingMode g;

		// Token: 0x040025EF RID: 9711
		private float h;

		// Token: 0x040025F0 RID: 9712
		private float i;

		// Token: 0x040025F1 RID: 9713
		private LineCap j;

		// Token: 0x040025F2 RID: 9714
		private LineJoin k;

		// Token: 0x040025F3 RID: 9715
		private float l;

		// Token: 0x040025F4 RID: 9716
		private LineStyle m;

		// Token: 0x040025F5 RID: 9717
		private Color n;

		// Token: 0x040025F6 RID: 9718
		private Color o;

		// Token: 0x040025F7 RID: 9719
		private ColorSpace p;

		// Token: 0x040025F8 RID: 9720
		private ColorSpace q;
	}
}
