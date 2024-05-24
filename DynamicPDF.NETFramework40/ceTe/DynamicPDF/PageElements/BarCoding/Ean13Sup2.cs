using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x02000786 RID: 1926
	public class Ean13Sup2 : Ean13
	{
		// Token: 0x06004DFD RID: 19965 RVA: 0x00273F85 File Offset: 0x00272F85
		public Ean13Sup2(string value, float x, float y) : this(value, x, y, 1f)
		{
		}

		// Token: 0x06004DFE RID: 19966 RVA: 0x00273F98 File Offset: 0x00272F98
		public Ean13Sup2(string value, float x, float y, float scale) : this(value.Substring(0, value.Length - 2), value.Substring(value.Length - 2), x, y, scale)
		{
		}

		// Token: 0x06004DFF RID: 19967 RVA: 0x00273FC4 File Offset: 0x00272FC4
		public Ean13Sup2(string value, string supplementalValue, float x, float y) : this(value, supplementalValue, x, y, 1f)
		{
		}

		// Token: 0x06004E00 RID: 19968 RVA: 0x00273FD9 File Offset: 0x00272FD9
		public Ean13Sup2(string value, string supplementalValue, float x, float y, float scale) : base(value, x, y, scale)
		{
			this.a = supplementalValue;
		}

		// Token: 0x1700061B RID: 1563
		// (get) Token: 0x06004E01 RID: 19969 RVA: 0x00273FF4 File Offset: 0x00272FF4
		// (set) Token: 0x06004E02 RID: 19970 RVA: 0x0027400C File Offset: 0x0027300C
		public string SupplementalValue
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

		// Token: 0x06004E03 RID: 19971 RVA: 0x00274018 File Offset: 0x00273018
		public override float GetSymbolWidth()
		{
			return this.XDimension * ad.b();
		}

		// Token: 0x06004E04 RID: 19972 RVA: 0x00274038 File Offset: 0x00273038
		protected override void DrawBarCode(PageWriter writer)
		{
			if (writer.Document.Tag != null)
			{
				base.b(true);
			}
			char[] a_ = this.a.ToCharArray();
			base.DrawBarCode(writer);
			try
			{
				base.b(writer, a_, this.X + this.XDimension * 113f, 0f);
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			base.d(writer, a_, this.X + this.XDimension * 120f, 0f);
			if (writer.Document.Tag != null)
			{
				writer.SetGraphicsMode();
				Tag.a(writer);
			}
		}

		// Token: 0x04002A3D RID: 10813
		private new string a;
	}
}
