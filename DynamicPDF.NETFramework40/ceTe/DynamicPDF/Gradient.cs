using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF
{
	// Token: 0x02000650 RID: 1616
	public class Gradient : Pattern
	{
		// Token: 0x06003D2F RID: 15663 RVA: 0x00213BFC File Offset: 0x00212BFC
		public Gradient(float x1, float y1, float x2, float y2, RgbColor color1, RgbColor color2)
		{
			this.a = x1;
			this.b = y1;
			this.c = x2;
			this.d = y2;
			if (color2.ColorSpace != color1.ColorSpace)
			{
				throw new Exception("Gradient Colors must be of the same color space.");
			}
			this.e = color1;
			this.f = color2;
		}

		// Token: 0x06003D30 RID: 15664 RVA: 0x00213C68 File Offset: 0x00212C68
		public Gradient(float x1, float y1, float x2, float y2, CmykColor color1, CmykColor color2)
		{
			this.a = x1;
			this.b = y1;
			this.c = x2;
			this.d = y2;
			if (color2.ColorSpace != color1.ColorSpace)
			{
				throw new Exception("Gradient Colors must be of the same color space.");
			}
			this.e = color1;
			this.f = color2;
		}

		// Token: 0x06003D31 RID: 15665 RVA: 0x00213CD4 File Offset: 0x00212CD4
		public Gradient(float x1, float y1, float x2, float y2, Grayscale color1, Grayscale color2)
		{
			this.a = x1;
			this.b = y1;
			this.c = x2;
			this.d = y2;
			if (color2.ColorSpace != color1.ColorSpace)
			{
				throw new Exception("Gradient Colors must be of the same color space.");
			}
			this.e = color1;
			this.f = color2;
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06003D32 RID: 15666 RVA: 0x00213D40 File Offset: 0x00212D40
		// (set) Token: 0x06003D33 RID: 15667 RVA: 0x00213D58 File Offset: 0x00212D58
		public float X1
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

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06003D34 RID: 15668 RVA: 0x00213D64 File Offset: 0x00212D64
		// (set) Token: 0x06003D35 RID: 15669 RVA: 0x00213D7C File Offset: 0x00212D7C
		public float Y1
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

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x06003D36 RID: 15670 RVA: 0x00213D88 File Offset: 0x00212D88
		// (set) Token: 0x06003D37 RID: 15671 RVA: 0x00213DA0 File Offset: 0x00212DA0
		public float X2
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

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x06003D38 RID: 15672 RVA: 0x00213DAC File Offset: 0x00212DAC
		// (set) Token: 0x06003D39 RID: 15673 RVA: 0x00213DC4 File Offset: 0x00212DC4
		public float Y2
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

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x06003D3A RID: 15674 RVA: 0x00213DD0 File Offset: 0x00212DD0
		public DeviceColor Color1
		{
			get
			{
				return this.e;
			}
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x06003D3B RID: 15675 RVA: 0x00213DE8 File Offset: 0x00212DE8
		public DeviceColor Color2
		{
			get
			{
				return this.f;
			}
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x06003D3C RID: 15676 RVA: 0x00213E00 File Offset: 0x00212E00
		public override ColorSpace ColorSpace
		{
			get
			{
				return ColorSpace.Pattern;
			}
		}

		// Token: 0x06003D3D RID: 15677 RVA: 0x00213E18 File Offset: 0x00212E18
		public override bool Equals(object obj)
		{
			return obj is Gradient && this.a == ((Gradient)obj).a && this.c == ((Gradient)obj).c && this.b == ((Gradient)obj).b && this.d == ((Gradient)obj).d && this.e.Equals(((Gradient)obj).e) && this.f.Equals(((Gradient)obj).f);
		}

		// Token: 0x06003D3E RID: 15678 RVA: 0x00213EB0 File Offset: 0x00212EB0
		public override int GetHashCode()
		{
			return this.e.GetHashCode() ^ this.f.GetHashCode();
		}

		// Token: 0x06003D3F RID: 15679 RVA: 0x00213ED9 File Offset: 0x00212ED9
		public override void DrawStroke(PageWriter writer)
		{
			writer.SetStrokeColorSpace(ColorSpace.Pattern);
			writer.Write_SCN(this);
		}

		// Token: 0x06003D40 RID: 15680 RVA: 0x00213EF0 File Offset: 0x00212EF0
		public override void DrawFill(PageWriter writer)
		{
			writer.SetFillColorSpace(ColorSpace.Pattern);
			writer.Write_scn_(this);
		}

		// Token: 0x06003D41 RID: 15681 RVA: 0x00213F07 File Offset: 0x00212F07
		internal new void a()
		{
			this.g = null;
		}

		// Token: 0x06003D42 RID: 15682 RVA: 0x00213F14 File Offset: 0x00212F14
		internal Gradient.a b()
		{
			return this.g;
		}

		// Token: 0x06003D43 RID: 15683 RVA: 0x00213F2C File Offset: 0x00212F2C
		internal override RgbColor m()
		{
			RgbColor rgbColor = this.Color1.m();
			RgbColor rgbColor2 = this.Color2.m();
			float num = rgbColor.R + rgbColor2.R;
			float num2 = rgbColor.G + rgbColor2.G;
			float num3 = rgbColor.B + rgbColor2.B;
			num /= 2f;
			num2 /= 2f;
			num3 /= 2f;
			return new RgbColor(num, num2, num3);
		}

		// Token: 0x06003D44 RID: 15684 RVA: 0x00213FA8 File Offset: 0x00212FA8
		public Resource GetResource(PageWriter writer)
		{
			if (this.g == null)
			{
				this.g = new Gradient.a(writer, this);
			}
			else
			{
				float pdfX = writer.Dimensions.GetPdfX(this.a);
				float pdfY = writer.Dimensions.GetPdfY(this.b);
				float pdfX2 = writer.Dimensions.GetPdfX(this.c);
				float pdfY2 = writer.Dimensions.GetPdfY(this.d);
				if (!this.g.a(pdfX, pdfY, pdfX2, pdfY2))
				{
					this.g = new Gradient.a(writer, pdfX, pdfY, pdfX2, pdfY2, this.e, this.f);
				}
			}
			return this.g;
		}

		// Token: 0x040020E8 RID: 8424
		private new float a;

		// Token: 0x040020E9 RID: 8425
		private new float b;

		// Token: 0x040020EA RID: 8426
		private new float c;

		// Token: 0x040020EB RID: 8427
		private new float d;

		// Token: 0x040020EC RID: 8428
		private DeviceColor e;

		// Token: 0x040020ED RID: 8429
		private DeviceColor f;

		// Token: 0x040020EE RID: 8430
		private Gradient.a g = null;

		// Token: 0x02000651 RID: 1617
		internal new class a : Resource
		{
			// Token: 0x06003D45 RID: 15685 RVA: 0x00214064 File Offset: 0x00213064
			public a(PageWriter A_0, Gradient A_1)
			{
				this.n = A_0.Dimensions.GetPdfX(A_1.X1);
				this.o = A_0.Dimensions.GetPdfY(A_1.Y1);
				this.p = A_0.Dimensions.GetPdfX(A_1.X2);
				this.q = A_0.Dimensions.GetPdfY(A_1.Y2);
				this.l = A_1.Color1;
				this.m = A_1.Color2;
				this.r = A_0;
			}

			// Token: 0x06003D46 RID: 15686 RVA: 0x002140F5 File Offset: 0x002130F5
			public a(PageWriter A_0, float A_1, float A_2, float A_3, float A_4, DeviceColor A_5, DeviceColor A_6)
			{
				this.n = A_1;
				this.o = A_2;
				this.p = A_3;
				this.q = A_4;
				this.l = A_5;
				this.m = A_6;
				this.r = A_0;
			}

			// Token: 0x06003D47 RID: 15687 RVA: 0x00214138 File Offset: 0x00213138
			public new bool a(float A_0, float A_1, float A_2, float A_3)
			{
				return this.n == A_0 && this.o == A_1 && this.p == A_2 && this.q == A_3;
			}

			// Token: 0x06003D48 RID: 15688 RVA: 0x00214180 File Offset: 0x00213180
			internal new void b(float A_0, float A_1, float A_2, float A_3)
			{
				this.n = this.r.Dimensions.GetPdfX(A_0);
				this.o = this.r.Dimensions.GetPdfY(A_1);
				this.p = this.r.Dimensions.GetPdfX(A_2);
				this.q = this.r.Dimensions.GetPdfY(A_3);
			}

			// Token: 0x06003D49 RID: 15689 RVA: 0x002141EC File Offset: 0x002131EC
			public override void Draw(DocumentWriter writer)
			{
				writer.WriteBeginObject();
				writer.WriteDictionaryOpen();
				writer.WriteName(Gradient.a.a);
				writer.WriteNumber(2);
				writer.WriteName(Gradient.a.b);
				writer.WriteDictionaryOpen();
				writer.WriteName(Gradient.a.c);
				writer.WriteNumber(2);
				writer.WriteName(Gradient.a.d);
				this.l.ColorSpace.DrawColorSpace(writer);
				writer.WriteName(Gradient.a.e);
				writer.WriteArrayOpen();
				writer.WriteNumber(this.n);
				writer.WriteNumber(this.o);
				writer.WriteNumber(this.p);
				writer.WriteNumber(this.q);
				writer.WriteArrayClose();
				writer.WriteName(Gradient.a.h);
				writer.WriteArrayOpen();
				writer.WriteBoolean(true);
				writer.WriteBoolean(true);
				writer.WriteArrayClose();
				writer.WriteName(Gradient.a.f);
				writer.WriteDictionaryOpen();
				writer.WriteName(Gradient.a.g);
				writer.WriteNumber(2);
				writer.WriteName(78);
				writer.WriteNumber1();
				writer.WriteName(Gradient.a.i);
				writer.WriteArrayOpen();
				writer.WriteNumber0();
				writer.WriteNumber1();
				writer.WriteArrayClose();
				writer.WriteName(Gradient.a.j);
				this.l.gr(writer);
				writer.WriteName(Gradient.a.k);
				this.m.gr(writer);
				writer.WriteDictionaryClose();
				writer.WriteDictionaryClose();
				writer.WriteDictionaryClose();
				writer.WriteEndObject();
			}

			// Token: 0x040020EF RID: 8431
			private new static byte[] a = new byte[]
			{
				80,
				97,
				116,
				116,
				101,
				114,
				110,
				84,
				121,
				112,
				101
			};

			// Token: 0x040020F0 RID: 8432
			private new static byte[] b = new byte[]
			{
				83,
				104,
				97,
				100,
				105,
				110,
				103
			};

			// Token: 0x040020F1 RID: 8433
			private new static byte[] c = new byte[]
			{
				83,
				104,
				97,
				100,
				105,
				110,
				103,
				84,
				121,
				112,
				101
			};

			// Token: 0x040020F2 RID: 8434
			private new static byte[] d = new byte[]
			{
				67,
				111,
				108,
				111,
				114,
				83,
				112,
				97,
				99,
				101
			};

			// Token: 0x040020F3 RID: 8435
			private new static byte[] e = new byte[]
			{
				67,
				111,
				111,
				114,
				100,
				115
			};

			// Token: 0x040020F4 RID: 8436
			private new static byte[] f = new byte[]
			{
				70,
				117,
				110,
				99,
				116,
				105,
				111,
				110
			};

			// Token: 0x040020F5 RID: 8437
			private new static byte[] g = new byte[]
			{
				70,
				117,
				110,
				99,
				116,
				105,
				111,
				110,
				84,
				121,
				112,
				101
			};

			// Token: 0x040020F6 RID: 8438
			private new static byte[] h = new byte[]
			{
				69,
				120,
				116,
				101,
				110,
				100
			};

			// Token: 0x040020F7 RID: 8439
			private new static byte[] i = new byte[]
			{
				68,
				111,
				109,
				97,
				105,
				110
			};

			// Token: 0x040020F8 RID: 8440
			private static byte[] j = new byte[]
			{
				67,
				48
			};

			// Token: 0x040020F9 RID: 8441
			private static byte[] k = new byte[]
			{
				67,
				49
			};

			// Token: 0x040020FA RID: 8442
			private DeviceColor l;

			// Token: 0x040020FB RID: 8443
			private DeviceColor m;

			// Token: 0x040020FC RID: 8444
			private float n;

			// Token: 0x040020FD RID: 8445
			private float o;

			// Token: 0x040020FE RID: 8446
			private float p;

			// Token: 0x040020FF RID: 8447
			private float q;

			// Token: 0x04002100 RID: 8448
			private PageWriter r;
		}
	}
}
