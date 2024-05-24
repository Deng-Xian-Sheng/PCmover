using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x0200076A RID: 1898
	public class IsmnSup2 : Ismn
	{
		// Token: 0x06004D13 RID: 19731 RVA: 0x0026F20F File Offset: 0x0026E20F
		public IsmnSup2(string value, string supplementalValue, float x, float y) : this(value, supplementalValue, x, y, 1f)
		{
		}

		// Token: 0x06004D14 RID: 19732 RVA: 0x0026F224 File Offset: 0x0026E224
		public IsmnSup2(string value, string supplementalValue, float x, float y, float scale) : base(value, x, y, scale)
		{
			this.a = supplementalValue;
		}

		// Token: 0x170005EF RID: 1519
		// (get) Token: 0x06004D15 RID: 19733 RVA: 0x0026F23C File Offset: 0x0026E23C
		// (set) Token: 0x06004D16 RID: 19734 RVA: 0x0026F254 File Offset: 0x0026E254
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

		// Token: 0x06004D17 RID: 19735 RVA: 0x0026F260 File Offset: 0x0026E260
		public override float GetSymbolWidth()
		{
			return this.XDimension * ad.b();
		}

		// Token: 0x06004D18 RID: 19736 RVA: 0x0026F280 File Offset: 0x0026E280
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
				base.b(writer, a_, this.X + this.XDimension * 113f, base.a());
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			base.d(writer, a_, this.X + this.XDimension * 120f, base.a());
			if (writer.Document.Tag != null)
			{
				writer.SetGraphicsMode();
				Tag.a(writer);
			}
		}

		// Token: 0x040029BA RID: 10682
		private new string a;
	}
}
