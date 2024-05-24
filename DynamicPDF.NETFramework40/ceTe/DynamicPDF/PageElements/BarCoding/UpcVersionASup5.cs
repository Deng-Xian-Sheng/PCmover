using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x02000790 RID: 1936
	public class UpcVersionASup5 : UpcVersionA
	{
		// Token: 0x06004E3C RID: 20028 RVA: 0x00275044 File Offset: 0x00274044
		public UpcVersionASup5(string value, float x, float y) : this(value, x, y, 1f)
		{
		}

		// Token: 0x06004E3D RID: 20029 RVA: 0x00275057 File Offset: 0x00274057
		public UpcVersionASup5(string value, float x, float y, float scale) : this(value.Substring(0, value.Length - 5), value.Substring(value.Length - 5), x, y, scale)
		{
		}

		// Token: 0x06004E3E RID: 20030 RVA: 0x00275083 File Offset: 0x00274083
		public UpcVersionASup5(string value, string supplementalValue, float x, float y) : this(value, supplementalValue, x, y, 1f)
		{
		}

		// Token: 0x06004E3F RID: 20031 RVA: 0x00275098 File Offset: 0x00274098
		public UpcVersionASup5(string value, string supplementalValue, float x, float y, float scale) : base(value, x, y, scale)
		{
			this.a = supplementalValue;
		}

		// Token: 0x17000621 RID: 1569
		// (get) Token: 0x06004E40 RID: 20032 RVA: 0x002750B0 File Offset: 0x002740B0
		// (set) Token: 0x06004E41 RID: 20033 RVA: 0x002750C8 File Offset: 0x002740C8
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

		// Token: 0x06004E42 RID: 20034 RVA: 0x002750D4 File Offset: 0x002740D4
		public override float GetSymbolWidth()
		{
			return this.XDimension * bc.a();
		}

		// Token: 0x06004E43 RID: 20035 RVA: 0x002750F4 File Offset: 0x002740F4
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
				base.a(writer, a_, this.X + this.XDimension * 113f, 0f);
				base.c(writer, a_, this.X + this.XDimension * 125f, 0f);
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

		// Token: 0x04002A4E RID: 10830
		private new string a;
	}
}
