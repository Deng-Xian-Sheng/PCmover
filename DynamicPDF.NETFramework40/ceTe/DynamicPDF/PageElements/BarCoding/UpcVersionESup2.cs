using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x02000793 RID: 1939
	public class UpcVersionESup2 : UpcVersionE
	{
		// Token: 0x06004E49 RID: 20041 RVA: 0x00275470 File Offset: 0x00274470
		public UpcVersionESup2(string value, float x, float y) : this(value, x, y, 1f)
		{
		}

		// Token: 0x06004E4A RID: 20042 RVA: 0x00275483 File Offset: 0x00274483
		public UpcVersionESup2(string value, float x, float y, float scale) : this(value.Substring(0, value.Length - 2), value.Substring(value.Length - 2), x, y, scale)
		{
		}

		// Token: 0x06004E4B RID: 20043 RVA: 0x002754AF File Offset: 0x002744AF
		public UpcVersionESup2(string value, string supplementalValue, float x, float y) : this(value, supplementalValue, x, y, 1f)
		{
		}

		// Token: 0x06004E4C RID: 20044 RVA: 0x002754C4 File Offset: 0x002744C4
		public UpcVersionESup2(string value, string supplementalValue, float x, float y, float scale) : base(value, x, y, scale)
		{
			this.a = supplementalValue;
		}

		// Token: 0x17000622 RID: 1570
		// (get) Token: 0x06004E4D RID: 20045 RVA: 0x002754DC File Offset: 0x002744DC
		// (set) Token: 0x06004E4E RID: 20046 RVA: 0x002754F4 File Offset: 0x002744F4
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

		// Token: 0x06004E4F RID: 20047 RVA: 0x00275500 File Offset: 0x00274500
		public override float GetSymbolWidth()
		{
			return this.XDimension * bd.b();
		}

		// Token: 0x06004E50 RID: 20048 RVA: 0x00275520 File Offset: 0x00274520
		protected override void DrawBarCode(PageWriter writer)
		{
			try
			{
				if (writer.Document.Tag != null)
				{
					base.b(true);
				}
				char[] a_ = this.a.ToCharArray();
				base.DrawBarCode(writer);
				base.b(writer, a_, this.X + this.XDimension * 70f, 0f);
				base.d(writer, a_, this.X + this.XDimension * 77f, 0f);
				if (writer.Document.Tag != null)
				{
					writer.SetGraphicsMode();
					Tag.a(writer);
				}
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
		}

		// Token: 0x04002A52 RID: 10834
		private new string a;
	}
}
