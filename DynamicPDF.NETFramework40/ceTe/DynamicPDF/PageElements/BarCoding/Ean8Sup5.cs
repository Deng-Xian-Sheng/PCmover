using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x0200078A RID: 1930
	public class Ean8Sup5 : Ean8
	{
		// Token: 0x06004E1A RID: 19994 RVA: 0x0027467C File Offset: 0x0027367C
		public Ean8Sup5(string value, float x, float y) : this(value, x, y, 1f)
		{
		}

		// Token: 0x06004E1B RID: 19995 RVA: 0x0027468F File Offset: 0x0027368F
		public Ean8Sup5(string value, float x, float y, float scale) : this(value.Substring(0, value.Length - 5), value.Substring(value.Length - 5), x, y, scale)
		{
		}

		// Token: 0x06004E1C RID: 19996 RVA: 0x002746BB File Offset: 0x002736BB
		public Ean8Sup5(string value, string supplementalValue, float x, float y) : this(value, supplementalValue, x, y, 1f)
		{
		}

		// Token: 0x06004E1D RID: 19997 RVA: 0x002746D0 File Offset: 0x002736D0
		public Ean8Sup5(string value, string supplementalValue, float x, float y, float scale) : base(value, x, y, scale)
		{
			this.a = supplementalValue;
		}

		// Token: 0x1700061E RID: 1566
		// (get) Token: 0x06004E1E RID: 19998 RVA: 0x002746E8 File Offset: 0x002736E8
		// (set) Token: 0x06004E1F RID: 19999 RVA: 0x00274700 File Offset: 0x00273700
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

		// Token: 0x06004E20 RID: 20000 RVA: 0x0027470C File Offset: 0x0027370C
		public override float GetSymbolWidth()
		{
			return ae.a() * this.XDimension;
		}

		// Token: 0x06004E21 RID: 20001 RVA: 0x0027472C File Offset: 0x0027372C
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
				base.a(writer, a_, this.X + this.XDimension * 77f, 0f);
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			base.c(writer, a_, this.X + this.XDimension * 89f, 0f);
			if (writer.Document.Tag != null)
			{
				writer.SetGraphicsMode();
				Tag.a(writer);
			}
		}

		// Token: 0x04002A40 RID: 10816
		private new string a;
	}
}
