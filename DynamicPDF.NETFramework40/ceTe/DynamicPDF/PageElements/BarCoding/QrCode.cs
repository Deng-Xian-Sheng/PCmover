using System;
using System.Collections;
using System.Text;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x02000775 RID: 1909
	public class QrCode : Dim2Barcode
	{
		// Token: 0x06004D85 RID: 19845 RVA: 0x00271A20 File Offset: 0x00270A20
		public QrCode(string text, float x, float y) : this(text, x, y, 3f, QrCodeEncoding.Auto, QrCodeErrorCorrectionLevel.L, QrCodeVersion.Auto)
		{
		}

		// Token: 0x06004D86 RID: 19846 RVA: 0x00271A37 File Offset: 0x00270A37
		public QrCode(string text, float x, float y, float xDimension) : this(text, x, y, xDimension, QrCodeEncoding.Auto, QrCodeErrorCorrectionLevel.L, QrCodeVersion.Auto)
		{
		}

		// Token: 0x06004D87 RID: 19847 RVA: 0x00271A4B File Offset: 0x00270A4B
		public QrCode(string text, float x, float y, float xDimension, QrCodeEncoding encoding) : this(text, x, y, xDimension, encoding, QrCodeErrorCorrectionLevel.L, QrCodeVersion.Auto)
		{
		}

		// Token: 0x06004D88 RID: 19848 RVA: 0x00271A60 File Offset: 0x00270A60
		public QrCode(string text, float x, float y, float xDimension, QrCodeEncoding encoding, QrCodeErrorCorrectionLevel errorCorrectionLevel) : this(text, x, y, xDimension, encoding, errorCorrectionLevel, QrCodeVersion.Auto)
		{
		}

		// Token: 0x06004D89 RID: 19849 RVA: 0x00271A76 File Offset: 0x00270A76
		public QrCode(string text, float x, float y, QrCodeEncoding encoding) : this(text, x, y, 3f, encoding, QrCodeErrorCorrectionLevel.L, QrCodeVersion.Auto)
		{
		}

		// Token: 0x06004D8A RID: 19850 RVA: 0x00271A8E File Offset: 0x00270A8E
		public QrCode(string text, float x, float y, QrCodeEncoding encoding, QrCodeErrorCorrectionLevel errorCorrectionLevel) : this(text, x, y, 3f, encoding, errorCorrectionLevel, QrCodeVersion.Auto)
		{
		}

		// Token: 0x06004D8B RID: 19851 RVA: 0x00271AA7 File Offset: 0x00270AA7
		public QrCode(string text, float x, float y, QrCodeEncoding encoding, QrCodeErrorCorrectionLevel errorCorrectionLevel, QrCodeVersion version) : this(text, x, y, 3f, encoding, errorCorrectionLevel, version)
		{
		}

		// Token: 0x06004D8C RID: 19852 RVA: 0x00271AC0 File Offset: 0x00270AC0
		public QrCode(string text, float x, float y, float xDimension, QrCodeEncoding encoding, QrCodeErrorCorrectionLevel errorCorrectionLevel, QrCodeVersion version)
		{
			this.d = 4;
			this.f = 40;
			this.h = 2;
			this.i = 40;
			this.j = new a2();
			base..ctor(x, y);
			this.b = text;
			this.c = Encoding.UTF8.GetBytes(text);
			this.d = (int)encoding;
			this.e = (int)errorCorrectionLevel;
			base.XDimension = xDimension;
			this.f = (int)version;
			this.g = text.ToCharArray();
			if (encoding == QrCodeEncoding.Auto)
			{
				this.d = this.j.a(this.g);
			}
			if (encoding == QrCodeEncoding.Byte)
			{
				try
				{
					this.i = this.j.a(this.c.Length, this.d, (int)errorCorrectionLevel);
				}
				catch
				{
					throw new QrCodeException("Data exceeds the capacity of QR code.");
				}
			}
			else
			{
				try
				{
					this.i = this.j.a(text.Length, this.d, (int)errorCorrectionLevel);
				}
				catch
				{
					throw new QrCodeException("Data exceeds the capacity of QR code.");
				}
			}
			if (version == QrCodeVersion.Auto)
			{
				this.f = this.i;
			}
			if (this.f < this.i)
			{
				throw new QrCodeException("Data exceeds the capacity of the selected QR code Version.");
			}
		}

		// Token: 0x06004D8D RID: 19853 RVA: 0x00271C38 File Offset: 0x00270C38
		public QrCode(byte[] value, float x, float y) : this(value, x, y, 3f, QrCodeErrorCorrectionLevel.L, QrCodeVersion.Auto)
		{
		}

		// Token: 0x06004D8E RID: 19854 RVA: 0x00271C4E File Offset: 0x00270C4E
		public QrCode(byte[] value, float x, float y, float xDimension) : this(value, x, y, xDimension, QrCodeErrorCorrectionLevel.L, QrCodeVersion.Auto)
		{
		}

		// Token: 0x06004D8F RID: 19855 RVA: 0x00271C61 File Offset: 0x00270C61
		public QrCode(byte[] value, float x, float y, float xDimension, QrCodeErrorCorrectionLevel errorCorrectionLevel) : this(value, x, y, xDimension, errorCorrectionLevel, QrCodeVersion.Auto)
		{
		}

		// Token: 0x06004D90 RID: 19856 RVA: 0x00271C75 File Offset: 0x00270C75
		public QrCode(byte[] value, float x, float y, QrCodeErrorCorrectionLevel errorCorrectionLevel) : this(value, x, y, 3f, errorCorrectionLevel, QrCodeVersion.Auto)
		{
		}

		// Token: 0x06004D91 RID: 19857 RVA: 0x00271C8C File Offset: 0x00270C8C
		public QrCode(byte[] value, float x, float y, QrCodeErrorCorrectionLevel errorCorrectionLevel, QrCodeVersion version) : this(value, x, y, 3f, errorCorrectionLevel, version)
		{
		}

		// Token: 0x06004D92 RID: 19858 RVA: 0x00271CA4 File Offset: 0x00270CA4
		public QrCode(byte[] value, float x, float y, float xDimension, QrCodeErrorCorrectionLevel errorCorrectionLevel, QrCodeVersion version)
		{
			this.d = 4;
			this.f = 40;
			this.h = 2;
			this.i = 40;
			this.j = new a2();
			base..ctor(x, y);
			this.c = value;
			this.d = 2;
			this.e = (int)errorCorrectionLevel;
			base.XDimension = xDimension;
			this.f = (int)version;
			try
			{
				this.i = this.j.a(this.c.Length, this.d, (int)errorCorrectionLevel);
			}
			catch
			{
				throw new QrCodeException("Data exceeds the capacity of QR code.");
			}
			if (version == QrCodeVersion.Auto)
			{
				this.f = this.i;
			}
			if (this.f < this.i)
			{
				throw new QrCodeException("Data exceeds the capacity of the selected QR code Version.");
			}
		}

		// Token: 0x17000606 RID: 1542
		// (get) Token: 0x06004D93 RID: 19859 RVA: 0x00271D8C File Offset: 0x00270D8C
		public QrCodeVersion Version
		{
			get
			{
				return (QrCodeVersion)this.f;
			}
		}

		// Token: 0x17000607 RID: 1543
		// (get) Token: 0x06004D95 RID: 19861 RVA: 0x00271DB0 File Offset: 0x00270DB0
		// (set) Token: 0x06004D94 RID: 19860 RVA: 0x00271DA4 File Offset: 0x00270DA4
		public QrCodeFnc1 Fnc1
		{
			get
			{
				return (QrCodeFnc1)this.h;
			}
			set
			{
				this.h = (int)value;
			}
		}

		// Token: 0x06004D96 RID: 19862 RVA: 0x00271DC8 File Offset: 0x00270DC8
		public override void Draw(PageWriter writer)
		{
			if (writer.Document.Tag != null)
			{
				base.e(writer);
			}
			writer.SetFillColor(base.Color);
			int num = (int)this.j.c(this.f);
			BitArray a_ = this.j.a(this.b, this.c, this.f, this.e, this.h, this.d);
			int num2 = num;
			int num3 = num;
			byte[] a_2 = BarCode.a(a_, base.PixelsPerXDimension, base.PixelsPerXDimension, num2, num3);
			if (base.Angle != 0f)
			{
				writer.SetDimensionsSimpleRotate(base.X, base.Y, base.Angle);
			}
			writer.SetFillColor(base.Color);
			writer.a(base.X, base.Y + this.GetSymbolHeight(), this.GetSymbolWidth(), this.GetSymbolHeight(), num2 * base.PixelsPerXDimension, num3 * base.PixelsPerXDimension, a_2);
			if (base.Angle != 0f)
			{
				writer.ResetDimensions();
			}
		}

		// Token: 0x06004D97 RID: 19863 RVA: 0x00271EEC File Offset: 0x00270EEC
		public override float GetSymbolWidth()
		{
			return (float)this.j.c(this.f) * base.XDimension;
		}

		// Token: 0x06004D98 RID: 19864 RVA: 0x00271F18 File Offset: 0x00270F18
		public override float GetSymbolHeight()
		{
			return (float)this.j.c(this.f) * base.XDimension;
		}

		// Token: 0x040029D2 RID: 10706
		private new const float a = 3f;

		// Token: 0x040029D3 RID: 10707
		private string b;

		// Token: 0x040029D4 RID: 10708
		private byte[] c;

		// Token: 0x040029D5 RID: 10709
		private new int d;

		// Token: 0x040029D6 RID: 10710
		private new int e;

		// Token: 0x040029D7 RID: 10711
		private int f;

		// Token: 0x040029D8 RID: 10712
		private char[] g;

		// Token: 0x040029D9 RID: 10713
		private int h;

		// Token: 0x040029DA RID: 10714
		private int i;

		// Token: 0x040029DB RID: 10715
		private a2 j;
	}
}
