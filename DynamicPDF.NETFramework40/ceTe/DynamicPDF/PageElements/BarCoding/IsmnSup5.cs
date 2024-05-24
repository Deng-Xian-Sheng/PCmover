using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x0200076B RID: 1899
	public class IsmnSup5 : Ismn
	{
		// Token: 0x06004D19 RID: 19737 RVA: 0x0026F364 File Offset: 0x0026E364
		public IsmnSup5(string value, string supplementalValue, float x, float y) : this(value, supplementalValue, x, y, 1f)
		{
		}

		// Token: 0x06004D1A RID: 19738 RVA: 0x0026F379 File Offset: 0x0026E379
		public IsmnSup5(string value, string supplementalValue, float x, float y, float scale) : base(value, x, y, scale)
		{
			this.a = supplementalValue;
		}

		// Token: 0x170005F0 RID: 1520
		// (get) Token: 0x06004D1B RID: 19739 RVA: 0x0026F394 File Offset: 0x0026E394
		// (set) Token: 0x06004D1C RID: 19740 RVA: 0x0026F3AC File Offset: 0x0026E3AC
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

		// Token: 0x06004D1D RID: 19741 RVA: 0x0026F3B8 File Offset: 0x0026E3B8
		public override float GetSymbolWidth()
		{
			return this.XDimension * ad.a();
		}

		// Token: 0x06004D1E RID: 19742 RVA: 0x0026F3D8 File Offset: 0x0026E3D8
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
				base.a(writer, a_, this.X + this.XDimension * 113f, base.a());
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			base.c(writer, a_, this.X + this.XDimension * 125f, base.a());
			if (writer.Document.Tag != null)
			{
				writer.SetGraphicsMode();
				Tag.a(writer);
			}
		}

		// Token: 0x040029BB RID: 10683
		private new string a;
	}
}
