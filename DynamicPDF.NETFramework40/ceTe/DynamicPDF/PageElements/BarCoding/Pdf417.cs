using System;
using System.Collections;
using System.Text;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x02000771 RID: 1905
	public class Pdf417 : Dim2Barcode
	{
		// Token: 0x06004D47 RID: 19783 RVA: 0x00270560 File Offset: 0x0026F560
		public Pdf417(string value, float x, float y, int columns, float xDimension) : base(x, y)
		{
			this.a = value;
			this.b.a(Encoding.Default.GetBytes(value));
			this.b.i(columns);
			base.XDimension = xDimension;
		}

		// Token: 0x06004D48 RID: 19784 RVA: 0x002705B8 File Offset: 0x0026F5B8
		public Pdf417(byte[] values, float x, float y, int columns, float xDimension) : base(x, y)
		{
			this.b.a(values);
			this.b.i(columns);
			base.XDimension = xDimension;
		}

		// Token: 0x06004D49 RID: 19785 RVA: 0x002705F4 File Offset: 0x0026F5F4
		internal Pdf417(byte[] A_0, float A_1, float A_2, int A_3, int A_4, float A_5) : base(A_1, A_2)
		{
			this.b.a(A_0);
			this.b.i(A_3);
			this.b.h(A_4);
			base.XDimension = A_5;
		}

		// Token: 0x06004D4A RID: 19786 RVA: 0x0027064C File Offset: 0x0026F64C
		internal Pdf417(string A_0, float A_1, float A_2, int A_3, int A_4, float A_5) : base(A_1, A_2)
		{
			this.a = A_0;
			this.b.a(Encoding.Default.GetBytes(A_0));
			this.b.i(A_3);
			this.b.h(A_4);
			base.XDimension = A_5;
		}

		// Token: 0x170005F6 RID: 1526
		// (get) Token: 0x06004D4B RID: 19787 RVA: 0x002706B4 File Offset: 0x0026F6B4
		// (set) Token: 0x06004D4C RID: 19788 RVA: 0x002706CC File Offset: 0x0026F6CC
		public string Value
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
				this.b.a(Encoding.Default.GetBytes(value));
			}
		}

		// Token: 0x170005F7 RID: 1527
		// (get) Token: 0x06004D4D RID: 19789 RVA: 0x002706F0 File Offset: 0x0026F6F0
		// (set) Token: 0x06004D4E RID: 19790 RVA: 0x0027070E File Offset: 0x0026F70E
		public float YDimension
		{
			get
			{
				return 3f * base.XDimension;
			}
			set
			{
				base.XDimension = value / 3f;
			}
		}

		// Token: 0x170005F8 RID: 1528
		// (get) Token: 0x06004D4F RID: 19791 RVA: 0x00270720 File Offset: 0x0026F720
		// (set) Token: 0x06004D50 RID: 19792 RVA: 0x00270744 File Offset: 0x0026F744
		public float YDimensionsPerInch
		{
			get
			{
				return 3f * base.XDimension * 72f;
			}
			set
			{
				base.XDimension = value / 72f / 3f;
			}
		}

		// Token: 0x170005F9 RID: 1529
		// (get) Token: 0x06004D51 RID: 19793 RVA: 0x0027075C File Offset: 0x0026F75C
		// (set) Token: 0x06004D52 RID: 19794 RVA: 0x00270780 File Offset: 0x0026F780
		public float YDimensionsPerCentiMeter
		{
			get
			{
				return 3f * base.XDimension * 28.346457f;
			}
			set
			{
				base.XDimension = value / 28.346457f / 3f;
			}
		}

		// Token: 0x170005FA RID: 1530
		// (get) Token: 0x06004D53 RID: 19795 RVA: 0x00270798 File Offset: 0x0026F798
		// (set) Token: 0x06004D54 RID: 19796 RVA: 0x002707BC File Offset: 0x0026F7BC
		public float YDimensionMils
		{
			get
			{
				return 3f * base.XDimension * 13.888889f;
			}
			set
			{
				base.XDimension = value / 13.888889f / 3f;
			}
		}

		// Token: 0x170005FB RID: 1531
		// (get) Token: 0x06004D55 RID: 19797 RVA: 0x002707D4 File Offset: 0x0026F7D4
		// (set) Token: 0x06004D56 RID: 19798 RVA: 0x002707F8 File Offset: 0x0026F7F8
		public float YDimensionMilliMeters
		{
			get
			{
				return 3f * base.XDimension * 0.35277778f;
			}
			set
			{
				base.XDimension = value / 0.35277778f / 3f;
			}
		}

		// Token: 0x170005FC RID: 1532
		// (get) Token: 0x06004D57 RID: 19799 RVA: 0x00270810 File Offset: 0x0026F810
		// (set) Token: 0x06004D58 RID: 19800 RVA: 0x0027082D File Offset: 0x0026F82D
		public bool CompactPdf417
		{
			get
			{
				return this.b.c();
			}
			set
			{
				this.b.a(value);
			}
		}

		// Token: 0x170005FD RID: 1533
		// (get) Token: 0x06004D59 RID: 19801 RVA: 0x00270840 File Offset: 0x0026F840
		// (set) Token: 0x06004D5A RID: 19802 RVA: 0x0027085D File Offset: 0x0026F85D
		public Compaction Compaction
		{
			get
			{
				return (Compaction)this.b.d();
			}
			set
			{
				this.b.d((int)value);
			}
		}

		// Token: 0x170005FE RID: 1534
		// (get) Token: 0x06004D5B RID: 19803 RVA: 0x00270870 File Offset: 0x0026F870
		// (set) Token: 0x06004D5C RID: 19804 RVA: 0x00270890 File Offset: 0x0026F890
		public ErrorCorrection ErrorCorrection
		{
			get
			{
				return (ErrorCorrection)this.b.a();
			}
			set
			{
				if (this.b.o().Length >= 415 && value == ErrorCorrection.Level8)
				{
					throw new GeneratorException("LEVEL8 may not be selected.");
				}
				if (this.b.o().Length >= 671 && (value == ErrorCorrection.Level7 || value == ErrorCorrection.Level8))
				{
					throw new GeneratorException("Neither LEVEL7 nor LEVEL8 may be selected.");
				}
				if (this.b.o().Length >= 799 && (value == ErrorCorrection.Level6 || value == ErrorCorrection.Level7 || value == ErrorCorrection.Level8))
				{
					throw new GeneratorException("Neither LEVEL6, LEVEL7 nor LEVEL8 may be selected.");
				}
				this.b.c((int)value);
			}
		}

		// Token: 0x06004D5D RID: 19805 RVA: 0x00270950 File Offset: 0x0026F950
		internal override x5 b7()
		{
			return x5.a(base.Y);
		}

		// Token: 0x06004D5E RID: 19806 RVA: 0x00270970 File Offset: 0x0026F970
		internal override x5 b8()
		{
			return x5.f(this.b7(), x5.a(this.GetSymbolHeight()));
		}

		// Token: 0x06004D5F RID: 19807 RVA: 0x0027099C File Offset: 0x0026F99C
		public override float GetSymbolWidth()
		{
			float result;
			try
			{
				if (!this.b.z())
				{
					this.b.ai();
					this.b.e(false);
				}
				if (this.CompactPdf417)
				{
					this.b.a((float)(35 + 17 * this.b.m()));
				}
				else
				{
					this.b.a((float)(17 * this.b.m() + 69));
				}
				result = this.b.b() * base.XDimension;
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (ao ao)
			{
				throw new dt(ao.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			return result;
		}

		// Token: 0x06004D60 RID: 19808 RVA: 0x00270A94 File Offset: 0x0026FA94
		public override float GetSymbolHeight()
		{
			float result;
			try
			{
				if (!this.b.z())
				{
					this.b.ai();
					this.b.e(false);
				}
				result = (float)this.b.l() * this.YDimension;
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (ao ao)
			{
				throw new dt(ao.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			return result;
		}

		// Token: 0x06004D61 RID: 19809 RVA: 0x00270B3C File Offset: 0x0026FB3C
		public override void Draw(PageWriter writer)
		{
			if (!this.b.z())
			{
				this.b.ai();
			}
			try
			{
				this.d(writer);
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (ao ao)
			{
				throw new dt(ao.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
		}

		// Token: 0x06004D62 RID: 19810 RVA: 0x00270BC8 File Offset: 0x0026FBC8
		private void b(PageWriter A_0)
		{
			Color color = base.Color;
			A_0.SetGraphicsMode();
			A_0.SetFillColor(color);
			BitArray bitArray = this.b.ag();
			float symbolWidth = this.GetSymbolWidth();
			int num = 3 * base.PixelsPerXDimension;
			int num2 = bitArray.Length / this.b.l();
			int num3 = this.b.l();
			byte[] a_ = BarCode.a(bitArray, base.PixelsPerXDimension, num, num2, num3);
			A_0.a(base.X, base.Y + this.GetSymbolHeight(), symbolWidth, this.GetSymbolHeight(), num2 * base.PixelsPerXDimension, num3 * num, a_);
		}

		// Token: 0x06004D63 RID: 19811 RVA: 0x00270C6C File Offset: 0x0026FC6C
		private void a(PageWriter A_0)
		{
			Color color = base.Color;
			A_0.SetGraphicsMode();
			A_0.SetFillColor(color);
			BitArray bitArray = this.b.ah();
			float symbolWidth = this.GetSymbolWidth();
			int num = 3 * base.PixelsPerXDimension;
			int num2 = bitArray.Length / this.b.l();
			int num3 = this.b.l();
			byte[] a_ = BarCode.a(bitArray, base.PixelsPerXDimension, num, num2, num3);
			A_0.a(base.X, base.Y + this.GetSymbolHeight(), symbolWidth, this.GetSymbolHeight(), num2 * base.PixelsPerXDimension, num3 * num, a_);
		}

		// Token: 0x06004D64 RID: 19812 RVA: 0x00270D10 File Offset: 0x0026FD10
		internal void c(PageWriter A_0)
		{
			if (A_0.Document.Tag != null)
			{
				A_0.SetGraphicsMode();
				base.e(A_0);
			}
			if (!this.b.c())
			{
				this.b(A_0);
			}
			else
			{
				this.a(A_0);
			}
			if (A_0.Document.Tag != null)
			{
				Tag.a(A_0);
			}
		}

		// Token: 0x06004D65 RID: 19813 RVA: 0x00270D84 File Offset: 0x0026FD84
		internal void d(PageWriter A_0)
		{
			float angle = base.Angle;
			if (angle != 0f)
			{
				A_0.SetDimensionsSimpleRotate(base.X, base.Y, angle);
				this.c(A_0);
				A_0.ResetDimensions();
			}
			else
			{
				this.c(A_0);
			}
		}

		// Token: 0x040029C9 RID: 10697
		private new string a;

		// Token: 0x040029CA RID: 10698
		internal aw b = new aw();
	}
}
