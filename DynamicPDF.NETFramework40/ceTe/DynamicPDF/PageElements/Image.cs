using System;
using System.Drawing;
using System.IO;
using ceTe.DynamicPDF.Imaging;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x0200072D RID: 1837
	public class Image : RotatingPageElement, IArea, ICoordinate
	{
		// Token: 0x06004943 RID: 18755 RVA: 0x00259845 File Offset: 0x00258845
		public Image(string filePath, float x, float y) : this(ImageData.GetImage(filePath), x, y)
		{
		}

		// Token: 0x06004944 RID: 18756 RVA: 0x00259858 File Offset: 0x00258858
		public Image(ImageData imageData, float x, float y) : this(imageData, x, y, imageData.ScaleX, imageData.ScaleY)
		{
		}

		// Token: 0x06004945 RID: 18757 RVA: 0x00259872 File Offset: 0x00258872
		public Image(Bitmap bitmap, float x, float y) : this(new BitmapImageData(bitmap), x, y)
		{
		}

		// Token: 0x06004946 RID: 18758 RVA: 0x00259885 File Offset: 0x00258885
		public Image(string filePath, float x, float y, float scale) : this(ImageData.GetImage(filePath), x, y, scale, scale)
		{
		}

		// Token: 0x06004947 RID: 18759 RVA: 0x0025989C File Offset: 0x0025889C
		public Image(ImageData imageData, float x, float y, float scale) : this(imageData, x, y, scale, scale)
		{
		}

		// Token: 0x06004948 RID: 18760 RVA: 0x002598B0 File Offset: 0x002588B0
		private Image(ImageData A_0, float A_1, float A_2, float A_3, float A_4) : base(A_1, A_2, 0f)
		{
			if (A_0 is GifImageData)
			{
				base.o();
			}
			this.e = A_0;
			this.a = A_3;
			this.b = A_4;
		}

		// Token: 0x06004949 RID: 18761 RVA: 0x0025991B File Offset: 0x0025891B
		public Image(Stream stream, float x, float y, float scale) : this(ImageData.GetImage(stream), x, y, scale)
		{
		}

		// Token: 0x0600494A RID: 18762 RVA: 0x00259930 File Offset: 0x00258930
		public Image(Bitmap bitmap, float x, float y, float scale) : this(new BitmapImageData(bitmap), x, y, scale)
		{
		}

		// Token: 0x170004FE RID: 1278
		// (get) Token: 0x0600494B RID: 18763 RVA: 0x00259948 File Offset: 0x00258948
		// (set) Token: 0x0600494C RID: 18764 RVA: 0x00259960 File Offset: 0x00258960
		public Align Align
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

		// Token: 0x170004FF RID: 1279
		// (get) Token: 0x0600494D RID: 18765 RVA: 0x0025996C File Offset: 0x0025896C
		// (set) Token: 0x0600494E RID: 18766 RVA: 0x00259984 File Offset: 0x00258984
		public VAlign VAlign
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

		// Token: 0x17000500 RID: 1280
		// (get) Token: 0x0600494F RID: 18767 RVA: 0x00259990 File Offset: 0x00258990
		// (set) Token: 0x06004950 RID: 18768 RVA: 0x002599A8 File Offset: 0x002589A8
		public float ScaleX
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

		// Token: 0x17000501 RID: 1281
		// (get) Token: 0x06004951 RID: 18769 RVA: 0x002599B4 File Offset: 0x002589B4
		// (set) Token: 0x06004952 RID: 18770 RVA: 0x002599CC File Offset: 0x002589CC
		public float ScaleY
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

		// Token: 0x17000502 RID: 1282
		// (get) Token: 0x06004953 RID: 18771 RVA: 0x002599D8 File Offset: 0x002589D8
		// (set) Token: 0x06004954 RID: 18772 RVA: 0x002599F6 File Offset: 0x002589F6
		public float HorizontalDpi
		{
			get
			{
				return 72f / this.a;
			}
			set
			{
				this.a = 72f / value;
			}
		}

		// Token: 0x17000503 RID: 1283
		// (get) Token: 0x06004955 RID: 18773 RVA: 0x00259A08 File Offset: 0x00258A08
		// (set) Token: 0x06004956 RID: 18774 RVA: 0x00259A26 File Offset: 0x00258A26
		public float VerticalDpi
		{
			get
			{
				return 72f / this.b;
			}
			set
			{
				this.b = 72f / value;
			}
		}

		// Token: 0x17000504 RID: 1284
		// (get) Token: 0x06004957 RID: 18775 RVA: 0x00259A38 File Offset: 0x00258A38
		// (set) Token: 0x06004958 RID: 18776 RVA: 0x00259A5D File Offset: 0x00258A5D
		public float Width
		{
			get
			{
				return this.a * (float)this.e.Width;
			}
			set
			{
				this.a = value / (float)this.e.Width;
			}
		}

		// Token: 0x17000505 RID: 1285
		// (get) Token: 0x06004959 RID: 18777 RVA: 0x00259A74 File Offset: 0x00258A74
		// (set) Token: 0x0600495A RID: 18778 RVA: 0x00259A99 File Offset: 0x00258A99
		public override float Height
		{
			get
			{
				return this.b * (float)this.e.Height;
			}
			set
			{
				this.b = value / (float)this.e.Height;
			}
		}

		// Token: 0x17000506 RID: 1286
		// (get) Token: 0x0600495B RID: 18779 RVA: 0x00259AB0 File Offset: 0x00258AB0
		public ImageData ImageData
		{
			get
			{
				return this.e;
			}
		}

		// Token: 0x0600495C RID: 18780 RVA: 0x00259AC8 File Offset: 0x00258AC8
		protected override void DrawRotated(PageWriter writer)
		{
			float num = this.a * (float)this.e.Width;
			float num2 = this.b * (float)this.e.Height;
			float pdfX = this.b(writer.Dimensions.GetPdfX(this.X), num);
			float pdfY = this.a(writer.Dimensions.GetPdfY(this.Y), num2);
			if ((this.g != null && this.g != string.Empty) || writer.Document.Tag != null)
			{
				writer.SetGraphicsMode();
				if (this.Tag == null)
				{
					writer.a(true);
					if (writer.Document.j() == null && writer.Document.Tag == null)
					{
						writer.Document.RequireLicense(1);
						writer.Document.a(new r2());
						writer.Page.a(writer.Document.k());
						writer.Document.j().a(writer.Page.f(), writer.DocumentWriter.GetObjectNumber());
					}
					else if (writer.Document.j() != null & writer.Document.Tag == null)
					{
						writer.Document.RequireLicense(1);
						writer.Page.a(writer.Document.k());
						writer.Document.j().a(writer.Page.f(), writer.DocumentWriter.GetObjectNumber());
					}
					new StructureElement(TagType.Figure, true)
					{
						Order = this.TagOrder,
						AlternateText = this.AlternateText
					}.e(writer, this);
				}
				else if (writer.Document.Tag != null)
				{
					if (this.Tag.g())
					{
						if (((StructureElement)this.Tag).AlternateText == null)
						{
							((StructureElement)this.Tag).AlternateText = this.g;
						}
					}
					this.Tag.e(writer, this);
				}
			}
			this.e.Draw(writer, pdfX, pdfY, num, num2);
			if (this.g != null || writer.Document.Tag != null)
			{
				Tag.a(writer);
			}
		}

		// Token: 0x0600495D RID: 18781 RVA: 0x00259D68 File Offset: 0x00258D68
		public void SetBounds(float maximumWidth, float maximumHeight)
		{
			float num = maximumWidth / this.e.ScaleX / (float)this.e.Width;
			float num2 = maximumHeight / this.e.ScaleY / (float)this.e.Height;
			if (num > num2)
			{
				this.a = this.e.ScaleX * num2;
				this.b = this.e.ScaleY * num2;
			}
			else
			{
				this.a = this.e.ScaleX * num;
				this.b = this.e.ScaleY * num;
			}
		}

		// Token: 0x0600495E RID: 18782 RVA: 0x00259E09 File Offset: 0x00258E09
		public void SetSize(float width, float height)
		{
			this.a = width / (float)this.e.Width;
			this.b = height / (float)this.e.Height;
		}

		// Token: 0x0600495F RID: 18783 RVA: 0x00259E34 File Offset: 0x00258E34
		public void SetDpi(float dpi)
		{
			this.a = (this.b = 72f / dpi);
		}

		// Token: 0x06004960 RID: 18784 RVA: 0x00259E58 File Offset: 0x00258E58
		public void SetDpi(float horizontalDpi, float verticalDpi)
		{
			this.a = 72f / horizontalDpi;
			this.b = 72f / verticalDpi;
		}

		// Token: 0x06004961 RID: 18785 RVA: 0x00259E78 File Offset: 0x00258E78
		private float b(float A_0, float A_1)
		{
			float result;
			switch (this.c)
			{
			case Align.Left:
				result = A_0;
				break;
			case Align.Center:
				result = A_0 - A_1 / 2f;
				break;
			default:
				result = A_0 - A_1;
				break;
			}
			return result;
		}

		// Token: 0x06004962 RID: 18786 RVA: 0x00259EB4 File Offset: 0x00258EB4
		private float a(float A_0, float A_1)
		{
			float result;
			switch (this.d)
			{
			case VAlign.Top:
				result = A_0 - A_1;
				break;
			case VAlign.Center:
				result = A_0 - A_1 / 2f;
				break;
			default:
				result = A_0;
				break;
			}
			return result;
		}

		// Token: 0x17000507 RID: 1287
		// (get) Token: 0x06004963 RID: 18787 RVA: 0x00259EF4 File Offset: 0x00258EF4
		// (set) Token: 0x06004964 RID: 18788 RVA: 0x00259F0C File Offset: 0x00258F0C
		public string AlternateText
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

		// Token: 0x06004965 RID: 18789 RVA: 0x00259F18 File Offset: 0x00258F18
		internal override byte cb()
		{
			return 55;
		}

		// Token: 0x06004966 RID: 18790 RVA: 0x00259F2C File Offset: 0x00258F2C
		internal override x5 b8()
		{
			return x5.f(base.b7(), x5.a(this.Height));
		}

		// Token: 0x06004967 RID: 18791 RVA: 0x00259F58 File Offset: 0x00258F58
		internal override x5 fa(x5 A_0)
		{
			return w0.d;
		}

		// Token: 0x06004968 RID: 18792 RVA: 0x00259F70 File Offset: 0x00258F70
		internal override short fd()
		{
			return this.f;
		}

		// Token: 0x06004969 RID: 18793 RVA: 0x00259F88 File Offset: 0x00258F88
		internal void a(short A_0)
		{
			this.f = A_0;
		}

		// Token: 0x0600496A RID: 18794 RVA: 0x00259F94 File Offset: 0x00258F94
		internal override PageElement fc()
		{
			return new Image(this.e, this.X, this.Y, this.a, this.b)
			{
				d = this.d,
				c = this.c,
				f = this.f
			};
		}

		// Token: 0x040027F3 RID: 10227
		private new float a;

		// Token: 0x040027F4 RID: 10228
		private float b;

		// Token: 0x040027F5 RID: 10229
		private Align c = Align.Left;

		// Token: 0x040027F6 RID: 10230
		private new VAlign d = VAlign.Top;

		// Token: 0x040027F7 RID: 10231
		private ImageData e;

		// Token: 0x040027F8 RID: 10232
		private short f = short.MinValue;

		// Token: 0x040027F9 RID: 10233
		private string g = null;
	}
}
