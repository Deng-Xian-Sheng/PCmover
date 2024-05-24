using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x0200078F RID: 1935
	public class UpcVersionASup2 : UpcVersionA
	{
		// Token: 0x06004E34 RID: 20020 RVA: 0x00274EB4 File Offset: 0x00273EB4
		public UpcVersionASup2(string value, float x, float y) : this(value, x, y, 1f)
		{
		}

		// Token: 0x06004E35 RID: 20021 RVA: 0x00274EC7 File Offset: 0x00273EC7
		public UpcVersionASup2(string value, float x, float y, float scale) : this(value.Substring(0, value.Length - 2), value.Substring(value.Length - 2), x, y, scale)
		{
		}

		// Token: 0x06004E36 RID: 20022 RVA: 0x00274EF3 File Offset: 0x00273EF3
		public UpcVersionASup2(string value, string supplementalValue, float x, float y) : this(value, supplementalValue, x, y, 1f)
		{
		}

		// Token: 0x06004E37 RID: 20023 RVA: 0x00274F08 File Offset: 0x00273F08
		public UpcVersionASup2(string value, string supplementalValue, float x, float y, float scale) : base(value, x, y, scale)
		{
			this.a = supplementalValue;
		}

		// Token: 0x17000620 RID: 1568
		// (get) Token: 0x06004E38 RID: 20024 RVA: 0x00274F20 File Offset: 0x00273F20
		// (set) Token: 0x06004E39 RID: 20025 RVA: 0x00274F38 File Offset: 0x00273F38
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

		// Token: 0x06004E3A RID: 20026 RVA: 0x00274F44 File Offset: 0x00273F44
		public override float GetSymbolWidth()
		{
			return this.XDimension * bc.b();
		}

		// Token: 0x06004E3B RID: 20027 RVA: 0x00274F64 File Offset: 0x00273F64
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
				base.b(writer, a_, this.X + this.XDimension * 113f, 0f);
				base.d(writer, a_, this.X + this.XDimension * 120f, 0f);
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

		// Token: 0x04002A4D RID: 10829
		private new string a;
	}
}
