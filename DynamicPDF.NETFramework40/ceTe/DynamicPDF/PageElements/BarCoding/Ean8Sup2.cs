using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x02000789 RID: 1929
	public class Ean8Sup2 : Ean8
	{
		// Token: 0x06004E12 RID: 19986 RVA: 0x002744EC File Offset: 0x002734EC
		public Ean8Sup2(string value, float x, float y) : this(value, x, y, 1f)
		{
		}

		// Token: 0x06004E13 RID: 19987 RVA: 0x002744FF File Offset: 0x002734FF
		public Ean8Sup2(string value, float x, float y, float scale) : this(value.Substring(0, value.Length - 2), value.Substring(value.Length - 2), x, y, scale)
		{
		}

		// Token: 0x06004E14 RID: 19988 RVA: 0x0027452B File Offset: 0x0027352B
		public Ean8Sup2(string value, string supplementalValue, float x, float y) : this(value, supplementalValue, x, y, 1f)
		{
		}

		// Token: 0x06004E15 RID: 19989 RVA: 0x00274540 File Offset: 0x00273540
		public Ean8Sup2(string value, string supplementalValue, float x, float y, float scale) : base(value, x, y, scale)
		{
			this.a = supplementalValue;
		}

		// Token: 0x1700061D RID: 1565
		// (get) Token: 0x06004E16 RID: 19990 RVA: 0x00274558 File Offset: 0x00273558
		// (set) Token: 0x06004E17 RID: 19991 RVA: 0x00274570 File Offset: 0x00273570
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

		// Token: 0x06004E18 RID: 19992 RVA: 0x0027457C File Offset: 0x0027357C
		public override float GetSymbolWidth()
		{
			return ae.b() * this.XDimension;
		}

		// Token: 0x06004E19 RID: 19993 RVA: 0x0027459C File Offset: 0x0027359C
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
				base.b(writer, a_, this.X + this.XDimension * 77f, 0f);
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			base.d(writer, a_, this.X + this.XDimension * 84f, 0f);
			if (writer.Document.Tag != null)
			{
				writer.SetGraphicsMode();
				Tag.a(writer);
			}
		}

		// Token: 0x04002A3F RID: 10815
		private new string a;
	}
}
