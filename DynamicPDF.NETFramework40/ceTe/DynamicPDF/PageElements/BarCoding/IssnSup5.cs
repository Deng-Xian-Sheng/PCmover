using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x0200076E RID: 1902
	public class IssnSup5 : Issn
	{
		// Token: 0x06004D2F RID: 19759 RVA: 0x0026FC78 File Offset: 0x0026EC78
		public IssnSup5(string value, string supplementalValue, float x, float y) : this(value, supplementalValue, x, y, 1f)
		{
		}

		// Token: 0x06004D30 RID: 19760 RVA: 0x0026FC8D File Offset: 0x0026EC8D
		public IssnSup5(string value, string supplementalValue, float x, float y, float scale) : base(value, x, y, scale)
		{
			this.a = supplementalValue;
		}

		// Token: 0x170005F3 RID: 1523
		// (get) Token: 0x06004D31 RID: 19761 RVA: 0x0026FCA8 File Offset: 0x0026ECA8
		// (set) Token: 0x06004D32 RID: 19762 RVA: 0x0026FCC0 File Offset: 0x0026ECC0
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

		// Token: 0x06004D33 RID: 19763 RVA: 0x0026FCCC File Offset: 0x0026ECCC
		public override float GetSymbolWidth()
		{
			return this.XDimension * ad.a();
		}

		// Token: 0x06004D34 RID: 19764 RVA: 0x0026FCEC File Offset: 0x0026ECEC
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
				base.a(writer, a_, this.X + this.XDimension * 113f, base.b());
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			base.c(writer, a_, this.X + this.XDimension * 125f, base.b());
			if (writer.Document.Tag != null)
			{
				writer.SetGraphicsMode();
				Tag.a(writer);
			}
		}

		// Token: 0x040029C1 RID: 10689
		private new string a;
	}
}
