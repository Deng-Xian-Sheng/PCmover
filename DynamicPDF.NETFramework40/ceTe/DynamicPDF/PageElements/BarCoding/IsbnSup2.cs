using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x02000767 RID: 1895
	public class IsbnSup2 : Isbn
	{
		// Token: 0x06004CFE RID: 19710 RVA: 0x0026EA5B File Offset: 0x0026DA5B
		public IsbnSup2(string value, string supplementalValue, float x, float y) : this(value, supplementalValue, x, y, 1f)
		{
		}

		// Token: 0x06004CFF RID: 19711 RVA: 0x0026EA70 File Offset: 0x0026DA70
		public IsbnSup2(string value, string supplementalValue, float x, float y, float scale) : base(value, x, y, scale)
		{
			this.a = supplementalValue;
		}

		// Token: 0x170005EC RID: 1516
		// (get) Token: 0x06004D00 RID: 19712 RVA: 0x0026EA88 File Offset: 0x0026DA88
		// (set) Token: 0x06004D01 RID: 19713 RVA: 0x0026EAA0 File Offset: 0x0026DAA0
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

		// Token: 0x06004D02 RID: 19714 RVA: 0x0026EAAC File Offset: 0x0026DAAC
		public override float GetSymbolWidth()
		{
			return this.XDimension * ad.b();
		}

		// Token: 0x06004D03 RID: 19715 RVA: 0x0026EACC File Offset: 0x0026DACC
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

		// Token: 0x040029B4 RID: 10676
		private new string a;
	}
}
