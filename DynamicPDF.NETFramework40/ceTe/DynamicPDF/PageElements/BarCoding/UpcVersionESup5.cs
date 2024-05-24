using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x02000794 RID: 1940
	public class UpcVersionESup5 : UpcVersionE
	{
		// Token: 0x06004E51 RID: 20049 RVA: 0x00275600 File Offset: 0x00274600
		public UpcVersionESup5(string value, float x, float y) : this(value, x, y, 1f)
		{
		}

		// Token: 0x06004E52 RID: 20050 RVA: 0x00275613 File Offset: 0x00274613
		public UpcVersionESup5(string value, float x, float y, float scale) : this(value.Substring(0, value.Length - 5), value.Substring(value.Length - 5), x, y, scale)
		{
		}

		// Token: 0x06004E53 RID: 20051 RVA: 0x0027563F File Offset: 0x0027463F
		public UpcVersionESup5(string value, string supplementalValue, float x, float y) : this(value, supplementalValue, x, y, 1f)
		{
		}

		// Token: 0x06004E54 RID: 20052 RVA: 0x00275654 File Offset: 0x00274654
		public UpcVersionESup5(string value, string supplementalValue, float x, float y, float scale) : base(value, x, y, scale)
		{
			this.a = supplementalValue;
		}

		// Token: 0x17000623 RID: 1571
		// (get) Token: 0x06004E55 RID: 20053 RVA: 0x0027566C File Offset: 0x0027466C
		// (set) Token: 0x06004E56 RID: 20054 RVA: 0x00275684 File Offset: 0x00274684
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

		// Token: 0x06004E57 RID: 20055 RVA: 0x00275690 File Offset: 0x00274690
		public override float GetSymbolWidth()
		{
			return this.XDimension * bd.a();
		}

		// Token: 0x06004E58 RID: 20056 RVA: 0x002756B0 File Offset: 0x002746B0
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
				base.a(writer, a_, this.X + this.XDimension * 70f, 0f);
				base.c(writer, a_, this.X + this.XDimension * 82f, 0f);
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

		// Token: 0x04002A53 RID: 10835
		private new string a;
	}
}
