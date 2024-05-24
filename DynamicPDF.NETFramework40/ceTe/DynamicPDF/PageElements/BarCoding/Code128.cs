using System;
using System.Collections;
using System.Text;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x02000781 RID: 1921
	public class Code128 : TextBarCode
	{
		// Token: 0x06004DD8 RID: 19928 RVA: 0x00273388 File Offset: 0x00272388
		public Code128(string value, float x, float y, float height) : base(value, x, y, height, 1f)
		{
		}

		// Token: 0x06004DD9 RID: 19929 RVA: 0x002733BA File Offset: 0x002723BA
		public Code128(string value, float x, float y, float height, bool showText) : base(value, x, y, height, 1f, showText)
		{
		}

		// Token: 0x06004DDA RID: 19930 RVA: 0x002733F0 File Offset: 0x002723F0
		public Code128(string value, float x, float y, float height, Font font, float fontSize) : base(value, x, y, height, 1f, true, font, fontSize)
		{
		}

		// Token: 0x06004DDB RID: 19931 RVA: 0x00273432 File Offset: 0x00272432
		public Code128(string value, float x, float y, float height, float xDimension) : base(value, x, y, height, xDimension)
		{
		}

		// Token: 0x06004DDC RID: 19932 RVA: 0x00273461 File Offset: 0x00272461
		public Code128(string value, float x, float y, float height, float xDimension, bool showText) : base(value, x, y, height, xDimension, showText)
		{
		}

		// Token: 0x06004DDD RID: 19933 RVA: 0x00273494 File Offset: 0x00272494
		public Code128(string value, float x, float y, float height, float xDimension, Font font, float fontSize) : base(value, x, y, height, xDimension, true, font, fontSize)
		{
		}

		// Token: 0x17000617 RID: 1559
		// (get) Token: 0x06004DDE RID: 19934 RVA: 0x002734D4 File Offset: 0x002724D4
		// (set) Token: 0x06004DDF RID: 19935 RVA: 0x002734EC File Offset: 0x002724EC
		public bool ProcessTilde
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

		// Token: 0x17000618 RID: 1560
		// (get) Token: 0x06004DE0 RID: 19936 RVA: 0x002734F8 File Offset: 0x002724F8
		// (set) Token: 0x06004DE1 RID: 19937 RVA: 0x00273510 File Offset: 0x00272510
		public int LookAhead
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
			}
		}

		// Token: 0x17000619 RID: 1561
		// (get) Token: 0x06004DE2 RID: 19938 RVA: 0x0027351C File Offset: 0x0027251C
		// (set) Token: 0x06004DE3 RID: 19939 RVA: 0x00273534 File Offset: 0x00272534
		public bool ContinueToNextSymbol
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

		// Token: 0x1700061A RID: 1562
		// (get) Token: 0x06004DE4 RID: 19940 RVA: 0x00273540 File Offset: 0x00272540
		// (set) Token: 0x06004DE5 RID: 19941 RVA: 0x00273558 File Offset: 0x00272558
		public bool IsUCCEAN128
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x06004DE6 RID: 19942 RVA: 0x00273564 File Offset: 0x00272564
		public override float GetSymbolWidth()
		{
			dq dq = new dq(this.Value, this.X, this.XDimension, this.LookAhead, this.ContinueToNextSymbol, this.IsUCCEAN128, this.d);
			return dq.g();
		}

		// Token: 0x06004DE7 RID: 19943 RVA: 0x002735AC File Offset: 0x002725AC
		protected override void DrawBarCode(PageWriter writer)
		{
			dq dq = new dq(this.Value, this.X, this.XDimension, this.LookAhead, this.ContinueToNextSymbol, this.IsUCCEAN128, this.d);
			BitArray bitArray = null;
			try
			{
				bitArray = dq.f();
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			writer.SetGraphicsMode();
			if (writer.Document.Tag != null)
			{
				base.a(writer);
			}
			writer.SetFillColor(base.Color);
			float num = this.Height;
			TextLineList a_ = null;
			float num2 = dq.g();
			if (base.ShowText)
			{
				int num3 = 0;
				int num4 = 0;
				byte[] array = new byte[this.Value.Length];
				for (int i = 0; i < this.Value.Length; i++)
				{
					if (this.Value[i] > '\u0080')
					{
						array[num3] = (byte)(this.Value[i] & '\u007f');
						num3++;
						num4++;
					}
					else if (this.Value[i] < '\u0080')
					{
						array[num3] = (byte)this.Value[i];
						num3++;
						num4++;
					}
				}
				byte[] array2 = new byte[num4];
				Array.Copy(array, array2, num4);
				float textWidth = base.Font.GetTextWidth(Encoding.ASCII.GetChars(array2), base.FontSize);
				float a_2 = (num2 < textWidth) ? textWidth : num2;
				if (base.ShowText)
				{
					num -= base.a(this.Value, a_2, out a_);
				}
			}
			int a_3 = bitArray.Length * base.PixelsPerXDimension;
			int num5 = 1;
			byte[] a_4 = BarCode.a(bitArray, base.PixelsPerXDimension, 1, bitArray.Length, num5);
			writer.a(this.X, this.Y + num, num2, (float)((int)num), a_3, num5, a_4);
			if (base.ShowText)
			{
				base.a(writer, a_, this.Y + num);
			}
			if (writer.Document.Tag != null)
			{
				writer.SetGraphicsMode();
				Tag.a(writer);
			}
		}

		// Token: 0x04002A34 RID: 10804
		private new bool a = false;

		// Token: 0x04002A35 RID: 10805
		private new bool b = false;

		// Token: 0x04002A36 RID: 10806
		private int c = 32;

		// Token: 0x04002A37 RID: 10807
		private new bool d = false;
	}
}
