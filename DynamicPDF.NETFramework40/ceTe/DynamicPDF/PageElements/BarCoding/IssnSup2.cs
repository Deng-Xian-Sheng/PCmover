using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x0200076D RID: 1901
	public class IssnSup2 : Issn
	{
		// Token: 0x06004D29 RID: 19753 RVA: 0x0026FB23 File Offset: 0x0026EB23
		public IssnSup2(string value, string supplementalValue, float x, float y) : this(value, supplementalValue, x, y, 1f)
		{
		}

		// Token: 0x06004D2A RID: 19754 RVA: 0x0026FB38 File Offset: 0x0026EB38
		public IssnSup2(string value, string supplementalValue, float x, float y, float scale) : base(value, x, y, scale)
		{
			this.a = supplementalValue;
		}

		// Token: 0x170005F2 RID: 1522
		// (get) Token: 0x06004D2B RID: 19755 RVA: 0x0026FB50 File Offset: 0x0026EB50
		// (set) Token: 0x06004D2C RID: 19756 RVA: 0x0026FB68 File Offset: 0x0026EB68
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

		// Token: 0x06004D2D RID: 19757 RVA: 0x0026FB74 File Offset: 0x0026EB74
		public override float GetSymbolWidth()
		{
			return this.XDimension * ad.b();
		}

		// Token: 0x06004D2E RID: 19758 RVA: 0x0026FB94 File Offset: 0x0026EB94
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
				base.b(writer, a_, this.X + this.XDimension * 113f, base.b());
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			base.d(writer, a_, this.X + this.XDimension * 120f, base.b());
			if (writer.Document.Tag != null)
			{
				writer.SetGraphicsMode();
				Tag.a(writer);
			}
		}

		// Token: 0x040029C0 RID: 10688
		private new string a;
	}
}
