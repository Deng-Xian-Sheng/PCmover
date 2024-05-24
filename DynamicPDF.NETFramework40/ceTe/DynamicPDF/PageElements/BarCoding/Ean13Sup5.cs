using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x02000787 RID: 1927
	public class Ean13Sup5 : Ean13
	{
		// Token: 0x06004E05 RID: 19973 RVA: 0x00274118 File Offset: 0x00273118
		public Ean13Sup5(string value, float x, float y) : this(value, x, y, 1f)
		{
		}

		// Token: 0x06004E06 RID: 19974 RVA: 0x0027412B File Offset: 0x0027312B
		public Ean13Sup5(string value, float x, float y, float scale) : this(value.Substring(0, value.Length - 5), value.Substring(value.Length - 5), x, y, scale)
		{
		}

		// Token: 0x06004E07 RID: 19975 RVA: 0x00274157 File Offset: 0x00273157
		public Ean13Sup5(string value, string supplementalValue, float x, float y) : this(value, supplementalValue, x, y, 1f)
		{
		}

		// Token: 0x06004E08 RID: 19976 RVA: 0x0027416C File Offset: 0x0027316C
		public Ean13Sup5(string value, string supplementalValue, float x, float y, float scale) : base(value, x, y, scale)
		{
			this.a = supplementalValue;
		}

		// Token: 0x1700061C RID: 1564
		// (get) Token: 0x06004E09 RID: 19977 RVA: 0x00274184 File Offset: 0x00273184
		// (set) Token: 0x06004E0A RID: 19978 RVA: 0x0027419C File Offset: 0x0027319C
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

		// Token: 0x06004E0B RID: 19979 RVA: 0x002741A8 File Offset: 0x002731A8
		public override float GetSymbolWidth()
		{
			return this.XDimension * ad.a();
		}

		// Token: 0x06004E0C RID: 19980 RVA: 0x002741C8 File Offset: 0x002731C8
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
				base.a(writer, a_, this.X + this.XDimension * 113f, 0f);
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			base.c(writer, a_, this.X + this.XDimension * 125f, 0f);
			if (writer.Document.Tag != null)
			{
				writer.SetGraphicsMode();
				Tag.a(writer);
			}
		}

		// Token: 0x04002A3E RID: 10814
		private new string a;
	}
}
