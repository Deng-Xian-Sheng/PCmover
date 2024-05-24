using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x02000763 RID: 1891
	public class IntelligentMailBarCode : TextBarCode
	{
		// Token: 0x06004CD8 RID: 19672 RVA: 0x0026DDA4 File Offset: 0x0026CDA4
		public IntelligentMailBarCode(string value, float x, float y) : this(value, x, y, 9f, 3.2727273f, false)
		{
		}

		// Token: 0x06004CD9 RID: 19673 RVA: 0x0026DDBD File Offset: 0x0026CDBD
		public IntelligentMailBarCode(string value, float x, float y, bool showText) : this(value, x, y, 9f, 3.2727273f, showText)
		{
		}

		// Token: 0x06004CDA RID: 19674 RVA: 0x0026DDD8 File Offset: 0x0026CDD8
		internal IntelligentMailBarCode(string A_0, float A_1, float A_2, float A_3, float A_4, bool A_5) : base(A_0, A_1, A_2, A_3, A_4, A_5)
		{
			base.FontSize = 10f;
			this.Height = 9f + BarCode.a(base.FontSize, base.Font) + 2.016f;
		}

		// Token: 0x170005E8 RID: 1512
		// (get) Token: 0x06004CDB RID: 19675 RVA: 0x0026DE38 File Offset: 0x0026CE38
		// (set) Token: 0x06004CDC RID: 19676 RVA: 0x0026DE50 File Offset: 0x0026CE50
		public bool ShowTextAbove
		{
			get
			{
				return this.d;
			}
			set
			{
				this.d = value;
			}
		}

		// Token: 0x170005E9 RID: 1513
		// (get) Token: 0x06004CDD RID: 19677 RVA: 0x0026DE5C File Offset: 0x0026CE5C
		// (set) Token: 0x06004CDE RID: 19678 RVA: 0x0026DE74 File Offset: 0x0026CE74
		public MailerIDLength MailerIDLength
		{
			get
			{
				return this.e;
			}
			set
			{
				this.e = value;
			}
		}

		// Token: 0x170005EA RID: 1514
		// (get) Token: 0x06004CDF RID: 19679 RVA: 0x0026DE80 File Offset: 0x0026CE80
		public float SymbolHeight
		{
			get
			{
				return this.Height - (base.ShowText ? (BarCode.a(base.FontSize, base.Font) + 2.016f) : 0f);
			}
		}

		// Token: 0x06004CE0 RID: 19680 RVA: 0x0026DEC0 File Offset: 0x0026CEC0
		public override float GetSymbolWidth()
		{
			al al = new al(this.Value, 1f, (int)this.e);
			return al.g() * this.XDimension;
		}

		// Token: 0x06004CE1 RID: 19681 RVA: 0x0026DEF8 File Offset: 0x0026CEF8
		protected override void DrawBarCode(PageWriter writer)
		{
			if (writer.Document.Tag != null)
			{
				base.a(writer);
			}
			writer.SetGraphicsMode();
			writer.SetFillColor(base.Color);
			al al = null;
			BitArray bitArray;
			try
			{
				al = new al(this.Value, 1f, (int)this.e);
				bitArray = al.e();
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			TextLineList a_ = null;
			float num = al.g() * this.XDimension;
			float textWidth = base.Font.GetTextWidth(this.Value, base.FontSize);
			float a_2 = (num < textWidth) ? textWidth : num;
			float num2 = this.Y;
			float num3 = base.a(this.a(), a_2, out a_);
			if (base.ShowText && this.ShowTextAbove)
			{
				num2 += num3 + 2.016f;
			}
			int num4 = 3 * base.PixelsPerXDimension;
			int num5 = bitArray.Length / 3;
			int num6 = 3;
			byte[] a_3 = BarCode.a(bitArray, base.PixelsPerXDimension, num4, num5, num6);
			writer.a(this.X, num2 + this.SymbolHeight, num, this.SymbolHeight, num5 * base.PixelsPerXDimension, num6 * num4, a_3);
			if (base.ShowText && this.ShowTextAbove)
			{
				base.a(writer, a_, this.Y);
			}
			else if (base.ShowText)
			{
				base.a(writer, a_, this.Y + this.SymbolHeight + 2.016f);
			}
			if (writer.Document.Tag != null)
			{
				Tag.a(writer);
			}
		}

		// Token: 0x06004CE2 RID: 19682 RVA: 0x0026E0E4 File Offset: 0x0026D0E4
		private string a()
		{
			string text = base.Value;
			int length = text.Length;
			text = text.Replace("-", " ");
			if (text[2] != ' ')
			{
				text = text.Insert(2, " ");
			}
			if (text[6] != ' ')
			{
				text = text.Insert(6, " ");
			}
			if (this.MailerIDLength == MailerIDLength.Length6 && text[13] != ' ')
			{
				text = text.Insert(13, " ");
			}
			else if (text[16] != ' ')
			{
				text = text.Insert(16, " ");
			}
			if (length > 23 && text[23] != ' ')
			{
				text = text.Insert(23, " ");
			}
			if (length > 29 && text[29] != ' ')
			{
				text = text.Insert(29, " ");
			}
			if (length > 34 && text[34] != ' ')
			{
				text = text.Insert(34, " ");
			}
			return text;
		}

		// Token: 0x040029AB RID: 10667
		private new const float a = 10f;

		// Token: 0x040029AC RID: 10668
		private new const float b = 2.016f;

		// Token: 0x040029AD RID: 10669
		private const float c = 9f;

		// Token: 0x040029AE RID: 10670
		private new bool d = false;

		// Token: 0x040029AF RID: 10671
		private MailerIDLength e = MailerIDLength.Length6;
	}
}
