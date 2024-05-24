using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x02000768 RID: 1896
	public class IsbnSup5 : Isbn
	{
		// Token: 0x06004D04 RID: 19716 RVA: 0x0026EBB0 File Offset: 0x0026DBB0
		public IsbnSup5(string value, string supplementalValue, float x, float y) : this(value, supplementalValue, x, y, 1f)
		{
		}

		// Token: 0x06004D05 RID: 19717 RVA: 0x0026EBC5 File Offset: 0x0026DBC5
		public IsbnSup5(string value, string supplementalValue, float x, float y, float scale) : base(value, x, y, scale)
		{
			this.a = supplementalValue;
		}

		// Token: 0x170005ED RID: 1517
		// (get) Token: 0x06004D06 RID: 19718 RVA: 0x0026EBE0 File Offset: 0x0026DBE0
		// (set) Token: 0x06004D07 RID: 19719 RVA: 0x0026EBF8 File Offset: 0x0026DBF8
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

		// Token: 0x06004D08 RID: 19720 RVA: 0x0026EC04 File Offset: 0x0026DC04
		public override float GetSymbolWidth()
		{
			return this.XDimension * ad.a();
		}

		// Token: 0x06004D09 RID: 19721 RVA: 0x0026EC24 File Offset: 0x0026DC24
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

		// Token: 0x040029B5 RID: 10677
		private new string a;
	}
}
